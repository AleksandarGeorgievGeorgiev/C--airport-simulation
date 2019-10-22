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

        public Engine()
        {
            _timerTracker = new TimerTracker();
            _nodeCreationService = new NodeCreationService(_timerTracker);
        }

        public void RunDemo(SimulationSettings settings)
        {
            _settings = settings;

            //create nodes

            var checkInDispatcher = _nodeCreationService.CreateCheckinDispatcher();
            var checkIn = _nodeCreationService.CreateCheckinDesk();
            var conveyorCheckToSecurity = _nodeCreationService.CreateConveyorOneToOne(10);
            var primarySecurity = _nodeCreationService.CreatePrimarySecurity();
            var conveyorSecurityToMda = _nodeCreationService.CreateConveyorOneToOne(10);
            var Mda = _nodeCreationService.CreateMda();
            var conveyorToDropOff = _nodeCreationService.CreateConveyorOneToOne(10);
            var dropOff1 = _nodeCreationService.CreateDropoff();

            //connect nodes

            checkInDispatcher.AddNextNode(checkIn);
            checkInDispatcher.SetCheckIns();
            checkIn.NextNode = conveyorCheckToSecurity;
            conveyorCheckToSecurity.NextNode = primarySecurity;
            primarySecurity.NextNode = conveyorSecurityToMda;
            conveyorSecurityToMda.NextNode = Mda;
            Mda.AddNextNode(conveyorToDropOff);
            conveyorToDropOff.NextNode = dropOff1;

            //start simulation conveyors

            conveyorCheckToSecurity.Start();
            conveyorSecurityToMda.Start();
            conveyorToDropOff.Start();

            //start dispatcher and time tracker
            _timerTracker.RunNewWatch();
            checkInDispatcher.Start();
        }
    }
}
