using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProCP.FlightAndBaggage;

namespace ProCP.Contracts
{
    public interface IChainNode
    {
        string Destination { get; }
        string NodeId { get; set; }
        Action OnNodeStatusChangedToFree { get; set; }
        NodeStatus NodeNodeStatus { get; set; }
        void PassBaggage(IBaggage b);
    }
}
