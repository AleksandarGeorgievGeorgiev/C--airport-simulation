using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCP.Contracts
{
    public interface IDropOff
    {
        int Capacity { get; set; }
        int Workers { get; set; }
    }
}
