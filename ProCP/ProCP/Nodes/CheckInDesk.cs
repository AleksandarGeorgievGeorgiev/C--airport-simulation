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

        public override string Destination => this.GetType().Name;

        public override void Process(IBaggage b)
        {
            //replace the new TimeSpan with real calculation for the time spent int this unit
            //b.AddLog(new TimeSpan(), "Checkin processing");
        }
    }
}
