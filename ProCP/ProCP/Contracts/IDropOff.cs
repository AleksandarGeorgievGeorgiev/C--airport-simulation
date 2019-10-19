using ProCP.FlightAndBaggage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCP.Contracts
{
    public interface IDropOff : IProcessingNode
    {
        int DropOffNumber { get; }
        string Destination { get; }
        Action OnNodeStatusChangedToFree { get; set; }
        void PassBaggage(IBaggage baggage);
        int Capacity { get; set; }
        int Workers { get; set; }
    }
}
