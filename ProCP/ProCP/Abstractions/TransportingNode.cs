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
        public TransportingNode(string nodeId) : base(nodeId)
        {
        }

        public override void PassBaggage(IBaggage b)
        {
            throw new NotImplementedException();
        }
    }
}
