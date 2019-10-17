using ProCP.Abstractions;
using ProCP.Contracts;
using ProCP.FlightAndBaggage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ProCP.Nodes
{
    public class DropOff : ProcessingNode, IProcessingNode, IDropOff
    {
        public DropOff(int dropOffNumber, string nodeId, Timer timer) : base(nodeId, timer)
        {
            DropOffNumber = dropOffNumber;
        }

        public int Capacity { get; set; }
        public int Workers { get; set; }
        public override string Destination => this.GetType().Name;

        public int DropOffNumber { get; }

        public override void Process(IBaggage b)
        {
            throw new NotImplementedException();
        }
    }
}
