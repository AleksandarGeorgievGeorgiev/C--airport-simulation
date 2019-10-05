using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProCP.FlightAndBaggage;

namespace ProCP.Contracts
{
    public enum Status
    {
        Busy, Free
    }
    interface IChainNode
    {
        int NodeId { get; set; }
        Action OnStatusChangedToFree { get; set; }
        Status NodeStatus { get; set; }
        // implement baggage class 
        void PassBaggage(Baggage b);
    }
}
