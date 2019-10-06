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
    public interface IChainNode
    {
        int NodeId { get; set; }
        Action OnStatusChangedToFree { get; set; }
        Status NodeStatus { get; set; }
        void PassBaggage(Baggage b);
    }
}
