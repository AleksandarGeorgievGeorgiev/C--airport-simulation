using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProCP.Contracts;
using ProCP.FlightAndBaggage;


namespace ProCP.Node
{
    abstract class ChainNode : IChainNode
    {
        public int NodeId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Action OnStatusChangedToFree { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Status NodeStatus { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ChainNode NextNode { get; set; }
        public ChainNode()
        {

        }
        public void PassBaggage(Baggage b)
        {
            throw new NotImplementedException();
        }
    }
}
