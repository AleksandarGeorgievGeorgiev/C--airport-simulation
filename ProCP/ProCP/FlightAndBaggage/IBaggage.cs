using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCP.FlightAndBaggage
{
    public interface IBaggage
    {
        BaggageType Type { get; set; }
        IFlight Flight { get; set; }
        string Description { get; set; }
        string Destination { get; set; }
        ConcurrentBag<BaggageEventLog> Logs { get; set; }
        long? TransportationStartTime { get; set; }
        //Node id
        string TransporterId { get; set; }
        void AddLog(TimeSpan logCreation, TimeSpan timeElapsed, string description);
    }
}
