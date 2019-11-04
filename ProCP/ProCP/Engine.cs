using ProCP.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCP
{
    public class Engine
    {
        private NodeCreationService _nodeCreationService;
        private TimerTracker _timerTracker;
        private SimulationSettings _settings;
        private StatisticsCalculator _calculator;
        

        public Engine()
        {
            _timerTracker = new TimerTracker();
            _nodeCreationService = new NodeCreationService(_timerTracker);
            _calculator = new StatisticsCalculator();
        }

        public void RunDemo(SimulationSettings settings)
        {
            _settings = settings;

            //create nodes

            _nodeCreationService.SetSimulationSettings(_settings);
            var checkInDispatcher = _nodeCreationService.CreateCheckinDispatcher();
            var checkIn = _nodeCreationService.CreateCheckinDesk();
            checkIn.AssignFlight(_settings.Flights.Find(f => f.FlightNumber == "test 1"));
            var conveyorCheckToSecurity = _nodeCreationService.CreateConveyorOneToOne(10);
            var primarySecurity = _nodeCreationService.CreatePrimarySecurity();
            var conveyorSecurityToMda = _nodeCreationService.CreateConveyorOneToOne(5);
            var Mda = _nodeCreationService.CreateMda();
            var conveyorToDropOff = _nodeCreationService.CreateConveyorOneToOne(15);
            var dropOff1 = _nodeCreationService.CreateDropoff();
            dropOff1.AssighFlight(_settings.Flights.Find(f => f.FlightNumber == "test 1"));


            //connect nodes

            checkInDispatcher.SetCheckIns(checkIn);
            checkIn.AddNextNode(conveyorCheckToSecurity);
            conveyorCheckToSecurity.SetNextNode(primarySecurity);
            primarySecurity.AddNextNode(conveyorSecurityToMda);
            conveyorSecurityToMda.SetNextNode(Mda);
            conveyorToDropOff.SetNextNode(dropOff1);
            Mda.AddNextNodes(conveyorToDropOff);

            //checkInDispatcher.SetCheckIns(checkIn);
            //checkIn.NextNode = conveyorCheckToSecurity;
            //conveyorCheckToSecurity.NextNode = primarySecurity;
            //primarySecurity.NextNode = conveyorSecurityToMda;
            //conveyorSecurityToMda.NextNode = Mda;
            //conveyorToDropOff.NextNode = dropOff1;
            //Mda.AddNextNodes(conveyorToDropOff);

            //start simulation conveyors

            conveyorCheckToSecurity.Start();
            conveyorSecurityToMda.Start();
            conveyorToDropOff.Start();

            //start dispatcher and time tracker
            _timerTracker.RunNewWatch();
            checkInDispatcher.Start();

        }

        public Func<StatisticsData> GetStatisticsCalculator() => () => StatisticsCalculator.CalculateStatistics();
    }
}
