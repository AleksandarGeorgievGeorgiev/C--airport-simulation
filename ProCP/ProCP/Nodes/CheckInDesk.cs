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
    public class CheckInDesk : ProcessingNode, ICheckIn
    {
        public CheckInDesk(string nodeId, Timer timer) : base(nodeId, timer)
        {
        }

        public override string Destination { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void Process(IBaggage b)
        {
            throw new NotImplementedException();
        }
    }
}
