using NUnit.Framework;
using ProCP;
using ProCP.Contracts;
using ProCP.Services;
using ProCP.FlightAndBaggage;
using System.Collections.Generic;
using Shouldly;
using System.Threading;
using ProCP.Nodes;
using Moq;
using System;
using ProCP.Abstractions;

namespace ProCp_test
{
    [TestFixture]

    public class TransportingNodeTest
    {
        [Test]
        public void ConveyorAssignLengthTest()
        {
            var settings = new SimulationSettings();
            var timerServiceMock = new Mock<ITimerTracker>();
            var conveyor = new ConveyorOneToOne(3, "conv", timerServiceMock.Object, settings.Cs);
            conveyor.Length.ShouldBe(3);
        }

        [Test]
        public void ConveyorAssignNodeIdTest()
        {
            var settings = new SimulationSettings();
            var timerServiceMock = new Mock<ITimerTracker>();
            var conveyor = new ConveyorOneToOne(3, "conv", timerServiceMock.Object, settings.Cs);
            conveyor.NodeId.ShouldBe("conv");
        }

        [Test]
        public void ConveyorAssignConveryTest()
        {
            var settings = new SimulationSettings();
            var timerServiceMock = new Mock<ITimerTracker>();
            var conveyor = new ConveyorOneToOne(3, "conv", timerServiceMock.Object, settings.Cs);
            conveyor.NodeId.ShouldBe("conv");
        }
        [Test]
        public void ConveyorSetDestinationTest()
        {
            var settings = new SimulationSettings();
            var timerServiceMock = new Mock<ITimerTracker>();
            var pscMock = new Mock<IProcessingNode>();

            pscMock.Setup(psc => psc.Destination).Returns(typeof(PrimarySecurity).Name);
            var bag = new Mock<Baggage>();
            var conveyor = new ConveyorOneToOne(1, "conv", timerServiceMock.Object, settings.Cs);

            conveyor.SetSingleNextNode(pscMock.Object);

            conveyor.Destination.ShouldBe(typeof(PrimarySecurity).Name);
        }

        [Test]
        public void ConveyorSetStatueBusyTest()
        {
            var settings = new SimulationSettings();
            var timerServiceMock = new Mock<ITimerTracker>();
            var bag = new Mock<Baggage>();
            var conveyor = new ConveyorOneToOne(1, "conv", timerServiceMock.Object, settings.Cs);

            conveyor.PassBaggage(bag.Object);

            conveyor.NodeStatus.ShouldBe(NodeStatus.Busy);
        }

        [Test]
        public void ConveyorMoveBaggageTest()
        {
            //var engine = new Engine();
            //var timeService = new TimerTracker();
            //var nd = new NodeCreationService(timeService);
            //var startlist = new List<IStartStop>();
            //nd.SetSimulationSettings(settings);
            //var dispatcher = nd.CreateCheckinDispatcher("1");
            //var checkin = nd.CreateCheckinDesk(1);
            //var conv = nd.CreateConveyorOneToOne(2, 1);
            //checkin.AddNextNodes(conv);
            //startlist.Add(dispatcher);
            //startlist.Add(conv);
            //var testingBag = new Baggage();
            //checkin.Process(testingBag);
            var settings = new SimulationSettings();
            var timerServiceMock = new Mock<ITimerTracker>();
            var pscMock = new Mock<IProcessingNode>();
            pscMock.Setup(psc => psc.Destination).Returns(typeof(PrimarySecurity).Name);
            var bag = new Mock<Baggage>();
            var conveyor = new ConveyorOneToOne(5, "conv", timerServiceMock.Object, settings.Cs);

            conveyor.SetSingleNextNode(pscMock.Object);
            conveyor.Start();
            conveyor.PassBaggage(bag.Object);
            Thread.Sleep((int)conveyor.MovingSpeed * 5);

            Should.NotThrow(() => conveyor.PassBaggage(new Mock<Baggage>().Object));
        }

        [Test]
        public void ConveyorPassBaggageTest()
        {
            var settings = new SimulationSettings();
            var timerServiceMock = new Mock<ITimerTracker>();
            var pscMock = new Mock<IProcessingNode>();

            pscMock.Setup(psc => psc.Destination).Returns(typeof(PrimarySecurity).Name);
            pscMock.Setup(psc => psc.NodeStatus).Returns(NodeStatus.Free);

            var bag = new Mock<Baggage>();
            var conveyor = new ConveyorOneToOne(1, "conv", timerServiceMock.Object, settings.Cs);

            conveyor.SetSingleNextNode(pscMock.Object);
            conveyor.Start();
            conveyor.PassBaggage(bag.Object);

            Thread.Sleep((int)conveyor.MovingSpeed * 3);

            pscMock.Verify(psc => psc.PassBaggage(bag.Object), Times.Once);

            Should.NotThrow(() => conveyor.PassBaggage(new Mock<Baggage>().Object));
        }

        [Test]
        public void ConveyorStopTest()
        {
            //if simulation is on pause or stop conveyor shouldn't pass the baggage
            var settings = new SimulationSettings();
            var timerServiceMock = new Mock<ITimerTracker>();
            var pscMock = new Mock<IProcessingNode>();

            pscMock.Setup(psc => psc.Destination).Returns(typeof(PrimarySecurity).Name);

            var bag = new Mock<Baggage>();
            var conveyor = new ConveyorOneToOne(5, "conv", timerServiceMock.Object, settings.Cs);

            conveyor.SetSingleNextNode(pscMock.Object);
            conveyor.Start();
            conveyor.Stop();

            conveyor.PassBaggage(bag.Object);
            Thread.Sleep((int)conveyor.MovingSpeed * 5);

            Should.Throw<ArgumentException>(() => conveyor.PassBaggage(new Mock<Baggage>().Object));
        }

        [Test]
        public void ConveyoryIsBusyTest()
        {
            var settings = new SimulationSettings();
            var timerServiceMock = new Mock<ITimerTracker>();
            var pscMock = new Mock<IProcessingNode>();
            pscMock.Setup(psc => psc.Destination).Returns(typeof(PrimarySecurity).Name);
            var bag = new Mock<Baggage>();

            var conveyor = new ConveyorOneToOne(1, "conv", timerServiceMock.Object, settings.Cs);
            conveyor.SetSingleNextNode(pscMock.Object);
            conveyor.Start();
            conveyor.PassBaggage(bag.Object);

            Thread.Sleep((int)conveyor.MovingSpeed * 5);

            Should.Throw<ArgumentException>(() => conveyor.PassBaggage(new Mock<Baggage>().Object));
        }

    }
}
