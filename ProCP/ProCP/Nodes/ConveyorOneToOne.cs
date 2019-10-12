using ProCP.Abstractions;
using ProCP.Contracts;
using ProCP.FlightAndBaggage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCP.Nodes
{
    public class ConveyorOneToOne : TransportingNode, IConveyorOneToOne
    {
        public ConveyorOneToOne(string nodeId) : base(nodeId)
        {
        }

        public int Length { get; set; }
        public int MovingSpeed { get; set; }
        public override string Destination { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
