using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCP.FlightAndBaggage
{
    public interface IBaggage
    {
        BaggageType Type { get; set; }
        string FlightNumber { get; set; }
        string Description { get; set; }
        List<BaggageEventLog> Logs { get; set; }
        string TransporterId { get; set; }
        void AddLog(TimeSpan logCreation, string description);
    }
}
