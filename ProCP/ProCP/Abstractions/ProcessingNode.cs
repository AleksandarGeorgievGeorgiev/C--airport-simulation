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
        public List<IChainNode> nextNodes;
        public IBaggage currentBag;

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
            ProcessInternal(b);
        }

        public void ProcessInternal(IBaggage b)
        {
            Process(b);
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
