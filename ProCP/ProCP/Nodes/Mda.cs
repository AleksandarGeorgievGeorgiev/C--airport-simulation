using ProCP.Contracts;
using ProCP.FlightAndBaggage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCP.Nodes
{
    public class Mda : IMda
    {
        private List<IChainNode> listOfNextNode;
        public Queue<IBaggage> BaggageQueue { get; set; }
        public string NodeId { get; set; }
        public Action OnNodeStatusChangedToFree { get; set; }
        public NodeStatus NodeNodeStatus { get; set; }
        public string Destination { get; set; }
        public Mda(string nodeId, string destination)
        {
            this.listOfNextNode = new List<IChainNode>();
            this.NodeId = nodeId;
            this.Destination = destination;
            NodeNodeStatus = NodeStatus.Free;
            this.BaggageQueue = new Queue<IBaggage>();
        }

        public void AddNextNode(IChainNode node)
        {
            this.listOfNextNode.Add(node);
        }

        public void PassBaggageToConveyor()
        {
            IBaggage b = this.BaggageQueue.Dequeue();
            foreach (var nextNode in this.listOfNextNode)
            {
                if (nextNode is ITransportingNode tranportNode)
                {
                    if (tranportNode.Destination == b.Destination)
                    {
                        tranportNode.PassBaggage(b);
                    }
                }
            }
        }
        public void PassBaggage(IBaggage b)
        {
            // conveyor pass baggage to the mda
            if (this.BaggageQueue.Count <= 10)
            {
                this.BaggageQueue.Enqueue(b);
            }
            else
            {
                this.NodeNodeStatus = NodeStatus.Busy;
            }
        }
    }
    }
}
