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
    public class ConveyorOneToOne : TransportingNode, IConveyorOneToOne
    {
        public ConveyorOneToOne(int legth, string nodeId, Timer timer) : base(legth, nodeId, timer)
        {
        }

        public override string Destination { get; set; }

        public override void Move()
        {
            throw new NotImplementedException();
        }

        public override void PassBaggage(IBaggage b)
        {
            throw new NotImplementedException();
        }
    }
}
