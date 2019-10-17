using System;
using System.Collections.Generic;
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
        public static List<Baggage> AllBaggage = new List<Baggage>();

        public Baggage()
        {
            Logs = new List<BaggageEventLog>();
            AllBaggage.Add(this);
        }

        public BaggageType Type { get; set; }
        public IFlight Flight { get; set; }
        public string Description { get; set; }
        public List<BaggageEventLog> Logs { get; set; }
        public string TransporterId { get; set; }
        public long TransportationStartTime { get; set; }
        public string Destination { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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
