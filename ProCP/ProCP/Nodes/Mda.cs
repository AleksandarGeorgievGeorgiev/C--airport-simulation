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
        public string NodeId { get; set; }
        public Action OnNodeStatusChangedToFree { get; set; }
        public NodeStatus NodeNodeStatus { get; set; }
        public string Destination { get; set; }

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
