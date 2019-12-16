using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCP.FlightAndBaggage
{
    public class Flight : IFlight
    {
        public TimeSpan DipartureTime { get; set; }
        public int BaggageCount { get; set; }
        public string FlightNumber { get; set; }
        public int DispatchedBaggageCount { get; set; } = 0;
        public bool HasCheckin { get; set; } = false;
        public bool HasDropOff { get; set; } = false;
    }
}
