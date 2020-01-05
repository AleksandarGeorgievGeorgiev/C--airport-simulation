using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCP.Contracts
{
    public interface IMultiNextNode
    {
        void AddNextNodes(IChainNode node);
    }
}
