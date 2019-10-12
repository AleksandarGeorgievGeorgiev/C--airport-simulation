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
        public Action OnStatusChangedToFree { get; set; }
        public Status NodeStatus { get; set; }
        public string Destination { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void AddNextNode(IChainNode node)
        {
            throw new NotImplementedException();
        }

        public void PassBaggage(IBaggage b)
        {
            throw new NotImplementedException();
        }
    }
}
