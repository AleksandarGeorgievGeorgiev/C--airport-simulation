using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using ProCP;
using ProCP.Contracts;
using ProCP.Services;
using ProCP.Visuals;
using System.Collections.Generic;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace ProCp_test
{
    [TestFixture]

    public class NodeCreationServiceTest
    {

        [Test]
        public void ICheckInDesk_Create()
        {
            TimerTracker timer = new TimerTracker();
            ITimerTracker itimer = timer;
            SimulationSettings simsettings = new SimulationSettings();
            ISimulationSettings isimsettings = simsettings;
            var NodeCreation = new NodeCreationService(itimer);
            NodeCreation.SetSimulationSettings(isimsettings);

            var CheckInDesk = NodeCreation.CreateCheckinDesk(1);
            Assert.IsNotNull(CheckInDesk);
        }


        [Test]
        public void CreatePrimarySecurity_Create()
        {
            TimerTracker timer = new TimerTracker();
            ITimerTracker itimer = timer;
            SimulationSettings simsettings = new SimulationSettings();
            ISimulationSettings isimsettings = simsettings;
            var NodeCreation = new NodeCreationService(itimer);
            NodeCreation.SetSimulationSettings(isimsettings);

            var PrimarySecurity = NodeCreation.CreatePrimarySecurity(2);
            Assert.IsNotNull(PrimarySecurity);
        }


        [Test]
        public void CreateConveyorOneToOne_Create()
        {
            TimerTracker timer = new TimerTracker();
            ITimerTracker itimer = timer;
            SimulationSettings simsettings = new SimulationSettings();
            ISimulationSettings isimsettings = simsettings;
            var NodeCreation = new NodeCreationService(itimer);
            NodeCreation.SetSimulationSettings(isimsettings);

            var ConveyorOneToOne = NodeCreation.CreateConveyorOneToOne(3, 1);
            Assert.IsNotNull(ConveyorOneToOne);
        }


        [Test]
        public void CreateMda_Create()
        {
            TimerTracker timer = new TimerTracker();
            ITimerTracker itimer = timer;
            SimulationSettings simsettings = new SimulationSettings();
            ISimulationSettings isimsettings = simsettings;
            var NodeCreation = new NodeCreationService(itimer);
            NodeCreation.SetSimulationSettings(isimsettings);

            var Mda = NodeCreation.CreateMda(4);
            Assert.IsNotNull(Mda);
        }


        [Test]
        public void CreateCheckinDispatcher_Create()
        {
            TimerTracker timer = new TimerTracker();
            ITimerTracker itimer = timer;
            SimulationSettings simsettings = new SimulationSettings();
            ISimulationSettings isimsettings = simsettings;
            var NodeCreation = new NodeCreationService(itimer);
            NodeCreation.SetSimulationSettings(isimsettings);

            var CheckInDispatcher = NodeCreation.CreateCheckinDispatcher("");
            Assert.IsNotNull(CheckInDispatcher);
        }

        [Test]
        public void CreateDropoff_Create()
        {
            TimerTracker timer = new TimerTracker();
            ITimerTracker itimer = timer;
            SimulationSettings simsettings = new SimulationSettings();
            ISimulationSettings isimsettings = simsettings;
            var NodeCreation = new NodeCreationService(itimer);
            NodeCreation.SetSimulationSettings(isimsettings);

            var DropOff = NodeCreation.CreateDropoff(5);
            Assert.IsNotNull(DropOff);
        }

        //[Test]
        //public void CreateNodes_Create()
        //{
        //    GridTile frontNode = new GridTile(3, 3, 1, 1);
        //    TimerTracker timer = new TimerTracker();
        //    ITimerTracker itimer = timer;
        //    SimulationSettings simsettings = new SimulationSettings();
        //    ISimulationSettings isimsettings = simsettings;
        //    var NodeCreation = new NodeCreationService(itimer);
        //    NodeCreation.CreateNode(frontNode);
        //    //Assert.ThrowsException();
        //}

        [Test]
        public void getNodesOfType_Type() 
        {
        

        }

        [Test]
        public void ConnectNodes_NextNode()
        {


        }

    }
}
