using ProCP.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCP.Node
{
    class DropOff : IDropOff
    {
        public int Capacity { get; set; }
        public int Workers { get; set; }
    }
}
