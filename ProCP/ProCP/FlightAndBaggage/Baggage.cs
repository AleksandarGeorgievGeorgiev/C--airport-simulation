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
        public BaggageType Type { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string FlightNumber { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Description { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<BaggageEventLog> Logs { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string TransporterId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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
