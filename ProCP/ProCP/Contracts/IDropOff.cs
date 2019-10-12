using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCP.Contracts
{
    public interface IDropOff : IChainNode
    {
        int Capacity { get; set; }
        int Workers { get; set; }
    }
}
