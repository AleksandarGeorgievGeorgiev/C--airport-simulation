using ProCP.Contracts;
using ProCP.FlightAndBaggage;
using ProCP.Nodes;
using ProCP.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ProCP.Abstractions
{
    public abstract class ProcessingNode : ChainNode, IProcessingNode
    {
        protected List<IChainNode> nextNodes;
        protected IBaggage currentBag;

        public ProcessingNode(string nodeId, ITimerTracker timer) : base(nodeId, timer)
        {
            nextNodes = new List<IChainNode>();
        }


        public void AddNextNodes(IChainNode node)
        {
            nextNodes.Add(node);
        }

        public override string Destination => GetType().Name;


        public abstract void Process(IBaggage b);

        public override void PassBaggage(IBaggage b)
        {
            NodeStatus = NodeStatus.Busy;
            currentBag = b;

            if (b == null)
            {
                return;
            }

            if (b.TransportationStartTime != null)
            {
                var transportationStart = b.TransportationStartTime ?? 0;
                var transportingTimeElapsed = TimerService.GetTicksSinceSimulationStart() - transportationStart;
                b.AddLog(TimerService.GetTimeSinceSimulationStart(),
                    new TimeSpan(transportingTimeElapsed),
                    string.Format(LoggingConstants.BagReceivedInTemplate, Destination, b.TransporterId));
                b.TransportationStartTime = null;
            }
            ProcessInternal(b);
        }

        private void ProcessInternal(IBaggage b)
        {
            Process(b);
            if (currentBag == null) 
            {
                NodeStatus = NodeStatus.Free;
                return;
            }
            NextNode = nextNodes.FirstOrDefault(n => n.Destination == b.Destination);
            currentBag.TransportationStartTime = TimerService.GetTicksSinceSimulationStart();
            Move();
        }

        private void Move()
        {
            if (currentBag != null && NextNode.NodeStatus == NodeStatus.Free)
            {
                NextNode.OnNodeStatusChangedToFree -= Move;
                NextNode.PassBaggage(currentBag);
                NodeStatus = NodeStatus.Free;
            }
            else if (NextNode.NodeStatus == NodeStatus.Busy)
            {
                NextNode.OnNodeStatusChangedToFree += Move;
            }
        }
    }
}
