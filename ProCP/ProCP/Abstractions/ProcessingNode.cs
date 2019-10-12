using ProCP.Contracts;
using ProCP.FlightAndBaggage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ProCP.Abstractions
{
    public abstract class ProcessingNode : ChainNode, IProcessingNode
    {
        public ProcessingNode(string nodeId, Timer timer) : base(nodeId, timer)
        {

        }

        public abstract void Process(IBaggage b);

        public override void PassBaggage(IBaggage b)
        {
            throw new NotImplementedException();
        }

        public void ProcessInternal()
        {

        }
    }
}
