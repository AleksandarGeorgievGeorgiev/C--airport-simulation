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
        public ProcessingNode(string nodeId) : base(nodeId)
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
