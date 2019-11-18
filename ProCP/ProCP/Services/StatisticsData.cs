using ProCP.FlightAndBaggage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCP.Services
{
    public class StatisticsData
    {
        /* Here you must have properties like:
         * 1) list for bags failed Primary security
           2) list for bags succeeded in Primary security
           3) property for the first dispatched bag
           4) property for the last dispatched bag
           5) property for the first collected bag at a dropoff
           6) property for the last collected bag at a dropoff*/

        public List<Baggage> BagsFailedPsc { get; set; }
        public List<Baggage> BagsSucceededPsc { get; set; }
        public double FirstDispatchedBag { get; set; }
        public Baggage LastDispatchedBag { get; set; }
        public double FirstCollectedBag { get; set; }
        public double LastCollectedBag { get; set; }
        public List<Baggage> TotalBagsTransfered { get; set; }

        //transfferd bags per flight 
        public IEnumerable<IGrouping<string, Baggage>> BagsGroupedPerFlight { get; set; }
        public Dictionary<string, int> BagsPerFlight { get; set; }

        //elapsed times per flight
        public IEnumerable<IGrouping<string, Baggage>> ElapsedTimesGroupedPerFlight { get; set; }

        public Dictionary<string, string> ElapsedTimesPerFlight { get; set; }

        //
        public Dictionary<string, double> TransportingTimePerConveyorBeforePrimarySecurity { get; set; }
        public long? AverageTimeOfTottalBags { get; set; }

        //simulation elapsed time
        public string SimulationTimeElapsed { get; set; }

        public StatisticsData()
        {
            BagsFailedPsc = new List<Baggage>();
            BagsSucceededPsc = new List<Baggage>();
            TotalBagsTransfered = new List<Baggage>();
            TransportingTimePerConveyorBeforePrimarySecurity = new Dictionary<string, double>();
            BagsPerFlight = new Dictionary<string, int>();
            ElapsedTimesPerFlight = new Dictionary<string, string>();
        }

    }
}
