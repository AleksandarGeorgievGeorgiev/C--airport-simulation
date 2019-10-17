using ProCP.Contracts;
using ProCP.FlightAndBaggage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCP.Nodes
{
    class Dispatcher : IDispatcher
    {
        public string NodeId { get; set; }
        public Action OnNodeStatusChangedToFree { get; set; }
        public NodeStatus NodeNodeStatus { get; set; }
        public string Destination { get; set; }

        public List<ICheckIn> checkins;
        public List<Queue<Baggage>> checkinQueues;

        public Dispatcher()
        {
            checkins = new List<ICheckIn>();
            checkinQueues = new List<Queue<Baggage>>();
        }

        public void AddNextNode(IChainNode node)
        {
            checkins.Add((ICheckIn)node);
        }

        public void PassBaggage(IBaggage b)
        {
            throw new NotImplementedException();
        }
    }
}
