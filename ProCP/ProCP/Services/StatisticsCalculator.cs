using ProCP.FlightAndBaggage;
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
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return statisticsData;
        }

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
    }
}
