using ProCP.Contracts;
using ProCP.FlightAndBaggage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCP.Nodes
{
    class DropOff : IDropOff
    {
        public int Capacity { get; set; }
        public int Workers { get; set; }
        public string Destination { get; set; }
        public string NodeId { get; set; }
        public Action OnStatusChangedToFree { get; set; }
        public Status NodeStatus { get; set; }

        public void PassBaggage(IBaggage b)
        {
            throw new NotImplementedException();
        }
    }
}
