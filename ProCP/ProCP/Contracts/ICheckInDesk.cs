using ProCP.FlightAndBaggage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCP.Contracts
{
    public interface ICheckInDesk : IChainNode, IProcessingNode
    {
        IFlight Flight { get; set; }
        void AssignFlight(IFlight Flight);
    }
}
