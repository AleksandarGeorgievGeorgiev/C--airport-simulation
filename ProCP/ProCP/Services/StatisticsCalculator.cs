using ProCP.Contracts;
using ProCP.FlightAndBaggage;
using ProCP.Nodes;
using System;
using System.Collections.Concurrent;
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
                BagsTimesDispatchedAndCollectedStats(statisticsData, baggages);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return statisticsData;
        }

        //
        public static void SetTransferdBagsCount(StatisticsData data, ConcurrentBag<Baggage> baggages)
        {
            if (baggages != null)
            {
                data.TotalBagsTransfered = baggages
                    .Where(bag => bag.Logs.Any(log => log.Description.Contains("drop off processing"))).ToList();
            }
        }

        public static void SetPscFailedAndSucceededBags(StatisticsData data, ConcurrentBag<Baggage> baggages)
        {
            data.BagsFailedPsc = baggages.Where(bag => bag.Logs.Any(log => log.Description.Contains(LoggingConstants.PrimarySecurityCheckFailed))).ToList();
            data.BagsSucceededPsc = baggages.Where(bag => bag.Logs.Any(log => log.Description.Contains(LoggingConstants.PrimarySecurityCheckSucceeded))).ToList();
        }
        public static void AverageTimeCheckInDropOff(StatisticsData data, ConcurrentBag<Baggage> baggages)
        {
            List<long?> timeList = new List<long?>();
            data.TotalBagsTransfered = baggages
                .Where(bag => bag.Logs.Any(log => log.Description.Contains("drop off processing"))).ToList();
            foreach (Baggage b in data.TotalBagsTransfered)
            {
                long dateTime = DateTime.Now.Ticks;
                long? TimeDifference = b.TransportationStartTime - dateTime;
                timeList.Add(TimeDifference);
            }
            long? averageTime = 0;
            int n = timeList.Count;
            foreach (long? t in timeList)
            {
                averageTime += t;
            }
            long? meanTime = averageTime / n;
            data.AverageTimeOfTottalBags = meanTime;
        }


        public static void SetAVGWaitingTimePerTransporter(StatisticsData data, ConcurrentBag<Baggage> baggages)
        {
            var primarySecurityNodes = NodeCreationService.Nodes.OfType<IPrimarySecurity>().ToList();
        }

        public static void BagsPerFlight(StatisticsData data, ConcurrentBag<Baggage> baggages)
        {
            data.BagsTransferredPerFlight = data.TotalBagsTransfered.GroupBy(b => b.Flight.FlightNumber);

            foreach (var group in data.BagsTransferredPerFlight)
            {
                data.BagsPerFlight.Add(group.Key, group.Count());
            }
        }

        public static void TransportationTimePerConveyorBeforeSecurity(StatisticsData data, ConcurrentBag<Baggage> baggages)
        {
            var allTransporterTimes = baggages.Where(b => b.Logs.Any(l => l.Description.Contains("Primary security"))).ToList();


        }

        public static void BagsTimesDispatchedAndCollectedStats(StatisticsData data, ConcurrentBag<Baggage> baggages)
        {
            if (baggages == null)
            {
                return;
            }
            var bagsOrderedbyFirstCreation = baggages.OrderBy(b => b.Logs.FirstOrDefault().LogCreated).ToList();

            data.FirstDispatchedBag = bagsOrderedbyFirstCreation.FirstOrDefault().Logs.FirstOrDefault().LogCreated.TotalSeconds;
            data.LastCollectedBag = bagsOrderedbyFirstCreation.LastOrDefault().Logs.LastOrDefault().LogCreated.TotalSeconds;

            var simulationElapsedTime = (data.LastCollectedBag - data.FirstDispatchedBag).ToString().Split(new Char[] { '.'})[0];
        }
    }
}
