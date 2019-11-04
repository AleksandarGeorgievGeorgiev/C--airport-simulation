using ProCP.FlightAndBaggage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCP.Contracts
{
    public interface IDropOff : IChainNode
    {
        void AssighFlight(IFlight flight);
        int Capacity { get; set; }
        int Workers { get; set; }
        IFlight Flight { get; set; }
    }
}
