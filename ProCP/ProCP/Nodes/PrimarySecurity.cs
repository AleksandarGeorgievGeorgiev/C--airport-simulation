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
    public class PrimarySecurity : ProcessingNode, IPrimarySecurity
    {
        public PrimarySecurity(string nodeId, Timer timer) : base(nodeId, timer)
        {
        }

        public override string Destination { get; set; }


        public override void Process(IBaggage b)
        {
            throw new NotImplementedException();
        }
    }
}
