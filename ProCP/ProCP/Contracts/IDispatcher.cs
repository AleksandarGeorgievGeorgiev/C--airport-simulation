using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCP.Contracts
{
    interface IDispatcher: IChainNode
    {
        void AddNextNode(IChainNode node);
    }
}
