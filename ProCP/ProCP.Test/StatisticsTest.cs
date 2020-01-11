using NUnit.Framework;
using ProCP;
using ProCP.Contracts;
using ProCP.FlightAndBaggage;
using ProCP.Nodes;
using ProCP.Services;
using ProCP.Visuals;
using System.Collections.Generic;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace ProCp_test
{
    [TestFixture]

    public class StatisticsTest
    {

        [Test]
        public void CalculateStatisticsTest()
        {
            var engine = new Engine();
            var settings= new SimulationSettings();
            var timeService = new TimerTracker();
            var nd = new NodeCreationService(timeService);
            var startlist = new List<IStartStop>();
            nd.SetSimulationSettings(settings);
            var dispatcher = nd.CreateCheckinDispatcher("1");
            var checkin = nd.CreateCheckinDesk(1);
            var conv = nd.CreateConveyorOneToOne(2, 1);
            var securetyTile = nd.CreatePrimarySecurity(3);
            var convTile1 = nd.CreateConveyorOneToOne(4, 1);
            var mdaTile = nd.CreateMda(5);
            var convTile2 = nd.CreateConveyorOneToOne(6,1);
            var dropOffTile = nd.CreateDropoff(7);

            var flight = new Flight()
            {
                BaggageCount = 10,
                DipartureTime = new System.DateTime(),
                FlightNumber = "flight1"
            };

            settings.Cs.Speed = 1;
            checkin.AssignFlight(flight);
            dropOffTile.AssignFlight(flight);

            conv.SetSingleNextNode(securetyTile);
            convTile1.SetSingleNextNode(mdaTile);
            convTile2.SetSingleNextNode(dropOffTile);
            checkin.AddNextNodes(conv);
            securetyTile.AddNextNodes(convTile1);
            mdaTile.AddNextNodes(convTile2);

            startlist.Add(dispatcher);
            startlist.Add(conv);
            startlist.Add(convTile1);
            startlist.Add(convTile2);

            settings.Flights.Add(flight);

            //engine.RunDemo(settings);
            timeService.RunNewWatch();
            startlist.ForEach(n => n.Start());
            var calculator = engine.GetStatisticsCalculator();

            var statData = calculator();

            Assert.AreEqual(statData.TotalBagsTransfered.Count, 10);
        }
    }
}
