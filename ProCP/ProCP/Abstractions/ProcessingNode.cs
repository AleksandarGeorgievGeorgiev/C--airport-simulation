using ProCP.Contracts;
using ProCP.FlightAndBaggage;
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


        public void AddNextNode(IChainNode node)
        {
            nextNodes.Add(node);
        }

        public abstract void Process(IBaggage b);

        public override void PassBaggage(IBaggage b)
        {
            NodeNodeStatus = NodeStatus.Busy;
            currentBag = b;

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

        public void ProcessInternal(IBaggage b)
        {
            Process(b);
            NextNode = nextNodes.FirstOrDefault(n => n.Destination == b.Destination);
            currentBag.TransportationStartTime = TimerService.GetTicksSinceSimulationStart();
            Move();
        }

        private void Move()
        {
            if (NextNode.NodeNodeStatus == NodeStatus.Free && currentBag != null)
            {
                NextNode.OnNodeStatusChangedToFree -= Move;
                NextNode.PassBaggage(currentBag);
                NodeNodeStatus = NodeStatus.Free;
            }
            else if (NextNode.NodeNodeStatus == NodeStatus.Busy)
            {
                NextNode.OnNodeStatusChangedToFree += Move;
            }
        }
    }
}
