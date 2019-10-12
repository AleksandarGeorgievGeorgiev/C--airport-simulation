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
        public string Destination { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string NodeId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Action OnStatusChangedToFree { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Status NodeStatus { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void PassBaggage(IBaggage b)
        {
            throw new NotImplementedException();
        }
    }
}
