using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProCP.FlightAndBaggage;

namespace ProCP.Abstractions
{
    public abstract class TransportingNode : ChainNode
    {
        public override void PassBaggage(Baggage b)
        {
            throw new NotImplementedException();
        }
    }
}
