using ProCP.Contracts;
using ProCP.FlightAndBaggage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCP.Node
{
    public class Mda : IMda
    {
        public int NodeId { get; set; }
        public Action OnStatusChangedToFree { get; set; }
        public Status NodeStatus { get; set; }
        public void AddNextNode(IChainNode node)
        {
            throw new NotImplementedException();
        }

        public void PassBaggage(Baggage b)
        {
            throw new NotImplementedException();
        }
    }
}
