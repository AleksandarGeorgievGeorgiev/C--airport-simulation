using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProCP.FlightAndBaggage;

namespace ProCP.Contracts
{
    public interface IProcessingNode : IMultiNextNode
    {
        void Process(IBaggage b);
    }
}
