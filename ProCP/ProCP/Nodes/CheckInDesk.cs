using ProCP.Abstractions;
using ProCP.Contracts;
using ProCP.FlightAndBaggage;
using ProCP.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ProCP.Nodes
{
    public class CheckInDesk : ProcessingNode, ICheckInDesk
    {
        public CheckInDesk(string nodeId, ITimerTracker timer) : base(nodeId, timer)
        {

        }

        public IFlight Flight { get; set; }

        public void AssignFlight(IFlight flight)
        {
            Flight = flight;
        }

        public override void Process(IBaggage b)
        {
            System.Diagnostics.Debug.WriteLine("checkin" + b.Destination);
            b.AddLog(TimerService.GetTimeSinceSimulationStart(), TimerService.ConvertMillisecondsToTimeSpan(1000), $"Checkin processing");
            b.Destination = typeof(PrimarySecurity).Name;
        }
    }
}
