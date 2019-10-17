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
        public Queue<IBaggage> BaggageQueue { get; set; }
        public string NodeId { get; set; }
        public Action OnStatusChangedToFree { get; set; }
        public Status NodeStatus { get; set; }
        public string Destination { get; set; }

        public Mda(string nodeId, string destination)
        {
            this.NodeId = nodeId;
            this.Destination = destination;
            NodeStatus = Status.Free;
            this.BaggageQueue = new Queue<IBaggage>();
        }

        public void AddNextNode(IChainNode node)
        {
            throw new NotImplementedException();
        }

        public void PassBaggageToConveyor()
        {
            
        }
        public bool PassBaggage(IBaggage b)
        {
            if (this.BaggageQueue.Count <= 10)
            {
                this.BaggageQueue.Enqueue(b);
                return true;
            }
            else
            {
                this.NodeStatus = Status.Busy;
                return false;
            }
        }
    }
}
