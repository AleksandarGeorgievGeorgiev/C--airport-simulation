using ProCP.Abstractions;
using ProCP.Contracts;
using ProCP.FlightAndBaggage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCP.Node
{
    public class CheckInDesk : ProcessingNode, ICheckIn
    {
        public override void PassBaggage(Baggage b)
        {
            throw new NotImplementedException();
        }

        public void Process(Baggage b)
        {
            throw new NotImplementedException();
        }
    }
}
