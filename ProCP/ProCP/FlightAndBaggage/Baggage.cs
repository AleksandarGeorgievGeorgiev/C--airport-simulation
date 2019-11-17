using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCP.FlightAndBaggage
{
    public enum BaggageType
    {
        Small, Medium, Large
    }
    public class Baggage : IBaggage
    {
        public static ConcurrentBag<Baggage> AllBaggage = new ConcurrentBag<Baggage>();

        public Baggage()
        {
            Logs = new ConcurrentBag<BaggageEventLog>();
            Flight = new Flight();

            AllBaggage.Add(this);
        }

        public BaggageType Type { get; set; }
        public IFlight Flight { get; set; }
        public string Description { get; set; }
        public ConcurrentBag<BaggageEventLog> Logs { get; set; }
        public string TransporterId { get; set; }
        public long? TransportationStartTime { get; set; }
        public string Destination { get; set; }

        public void AddLog(TimeSpan logCreation, TimeSpan timeElapsed, string description)
        {
            Logs.Add(new BaggageEventLog
            {
                LogCreated = logCreation,
                Description = description,
                TimeElapsed = timeElapsed
            });
        }
    }
}
