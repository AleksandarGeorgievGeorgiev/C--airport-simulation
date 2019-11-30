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

            //line A
            _nodeCreationService.SetSimulationSettings(_settings);
            var checkInDispatcher = _nodeCreationService.CreateCheckinDispatcher();
            var checkIn = _nodeCreationService.CreateCheckinDesk();
            checkIn.AssignFlight(_settings.Flights.Find(f => f.FlightNumber == "1234"));
            var conveyorCheckToSecurity = _nodeCreationService.CreateConveyorOneToOne(10);
            var primarySecurity = _nodeCreationService.CreatePrimarySecurity();
            var conveyorSecurityToMda = _nodeCreationService.CreateConveyorOneToOne(5);
            var Mda = _nodeCreationService.CreateMda();
            var conveyorToDropOff = _nodeCreationService.CreateConveyorOneToOne(15);
            var dropOff1 = _nodeCreationService.CreateDropoff();
            dropOff1.AssignFlight(_settings.Flights.Find(f => f.FlightNumber == "1234"));

            //line B
            var checkIn2 = _nodeCreationService.CreateCheckinDesk();
            checkIn2.AssignFlight(_settings.Flights.Find(f => f.FlightNumber == "34353"));
            var conveyorCheckToSecurity2 = _nodeCreationService.CreateConveyorOneToOne(12);
            var primarySecurity2 = _nodeCreationService.CreatePrimarySecurity();
            var conveyorSecurityToMda2 = _nodeCreationService.CreateConveyorOneToOne(8);
            var conveyorToDropOff2 = _nodeCreationService.CreateConveyorOneToOne(5);
            var dropOff2 = _nodeCreationService.CreateDropoff();
            dropOff2.AssignFlight(_settings.Flights.Find(f => f.FlightNumber == "34353"));


            //connect nodes

            //line A
            checkInDispatcher.SetCheckIns(checkIn);
            checkIn.AddNextNode(conveyorCheckToSecurity);
            conveyorCheckToSecurity.SetNextNode(primarySecurity);
            primarySecurity.AddNextNode(conveyorSecurityToMda);
            conveyorSecurityToMda.SetNextNode(Mda);
            conveyorToDropOff.SetNextNode(dropOff1);
            Mda.AddNextNodes(conveyorToDropOff);

            //line B
            checkInDispatcher.SetCheckIns(checkIn2);
            checkIn2.AddNextNode(conveyorCheckToSecurity2);
            conveyorCheckToSecurity2.SetNextNode(primarySecurity2);
            primarySecurity2.AddNextNode(conveyorSecurityToMda2);
            conveyorSecurityToMda2.SetNextNode(Mda);
            conveyorToDropOff2.SetNextNode(dropOff2);
            Mda.AddNextNodes(conveyorToDropOff2);




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
            conveyorCheckToSecurity2.Start();
            conveyorSecurityToMda2.Start();
            conveyorToDropOff2.Start();

            //start dispatcher and time tracker
            _timerTracker.RunNewWatch();
            checkInDispatcher.Start();

        }

        public Func<StatisticsData> GetStatisticsCalculator() => () => StatisticsCalculator.CalculateStatistics();
    }
}
