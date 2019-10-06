using ProCP.Contracts;
using ProCP.FlightAndBaggage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCP.Abstractions
{
    public abstract class ProcessingNode : ChainNode, IProcessingNode
    {
        public void Process(Baggage b)
        {
            throw new NotImplementedException();
        }
    }
}
