using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCP.Contracts
{
    public interface ITransportingNode: IChainNode
    {
        int Length { get; set; }
        int MovingSpeed { get; set; }
    }
}
