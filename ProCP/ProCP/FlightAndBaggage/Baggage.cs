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
        public BaggageType Type { get; set; }
        public string FlightNumber { get; set; }
        public string Description { get; set; }
        public List<BaggageEventLog> Logs { get; set; }
        public string TransporterId { get; set; }

        public void AddLog(TimeSpan logCreation, string description)
        {
            Logs.Add(new BaggageEventLog
            {
                LogCreated = logCreation,
                Description = description
            });
        }
    }
}
