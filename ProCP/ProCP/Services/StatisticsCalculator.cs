using ProCP.Contracts;
using ProCP.FlightAndBaggage;
using ProCP.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCP.Services
{
    public class StatisticsCalculator
    {
        public static StatisticsData CalculateStatistics()
        {
            var baggages = Baggage.AllBaggage;

            var statisticsData = new StatisticsData();

            try
            {
                SetTransferdBagsCount(statisticsData, baggages);
                SetPscFailedAndSucceededBags(statisticsData, baggages);
                BagsPerFlight(statisticsData, baggages);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return statisticsData;
        }

        //
        public static void SetTransferdBagsCount(StatisticsData data, List<Baggage> baggages)
        {
            data.TotalBagsTransfered = baggages
                .Where(bag => bag.Logs.Any(log => log.Description.Contains("drop off processing"))).ToList();
        }

        public static void SetPscFailedAndSucceededBags(StatisticsData data, List<Baggage> baggages)
        {
            data.BagsFailedPsc = baggages.Where(bag => bag.Logs.Any(log => log.Description.Contains(LoggingConstants.PrimarySecurityCheckFailed))).ToList();
            data.BagsSucceededPsc = baggages.Where(bag => bag.Logs.Any(log => log.Description.Contains(LoggingConstants.PrimarySecurityCheckSucceeded))).ToList();
        }
        public static void AverageTimeCheckInDropOff (StatisticsData data, List<Baggage> baggages)
        {
            var bagsOrderedbyFirstLog = baggages.OrderBy(b => b.Logs.LastOrDefault()?.LogCreated).ToList();

            data.FirstDispatchedBag = bagsOrderedbyFirstLog.FirstOrDefault();

            data.LastCollectedBag = bagsOrderedbyFirstLog.FirstOrDefault()?.Logs.LastOrDefault().LogCreated.TotalSeconds ?? 0;

            List<long?> timeList = new List<long?>();
            data.TotalBagsTransfered = baggages
                .Where(bag => bag.Logs.Any(log => log.Description.Contains("drop off processing"))).ToList();
            foreach (Baggage b in data.TotalBagsTransfered)
            {
                long dateTime = DateTime.Now.Ticks;
                long? TimeDifference = b.TransportationStartTime - dateTime;
                timeList.Add(TimeDifference);
            }
            long? averageTime=0;
            int n = timeList.Count;
            foreach(long? t in timeList)
            {
                averageTime+= t;
            }
            long? meanTime =averageTime / n;
            data.AverageTimeOfTottalBags = meanTime;
        }


        public static void SetAVGWaitingTimePerTransporter(StatisticsData data, List<Baggage> baggages)
        {
            var primarySecurityNodes = NodeCreationService.Nodes.OfType<IPrimarySecurity>().ToList();
        }              
        
        public static void BagsPerFlight(StatisticsData data, List<Baggage> baggages)
        {
            data.BagsTransferredPerFlight = data.TotalBagsTransfered.GroupBy(b => b.Flight.FlightNumber);

            foreach (var group in data.BagsTransferredPerFlight)
            {
                data.BagsPerFlight.Add(group.Key, group.Count());
            }    
        }

        public static void TransportationTimePerConveyorBeforeSecurity(StatisticsData data, List<Baggage> baggages)
        {
            var allTransporterTimes = baggages.Where(b => b.Logs.Any(l => l.Description.Contains("Primary security"))).ToList();

            
        }
    }
}
