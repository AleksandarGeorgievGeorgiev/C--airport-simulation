using ProCP.Abstractions;
using ProCP.Contracts;
using ProCP.FlightAndBaggage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCP.Node
{
    public class ConveyorOneToOne : TransportingNode, IConveyorOneToOne
    {
        public int Length { get; set; }
        public int MovingSpeed { get; set; }
    }
}
