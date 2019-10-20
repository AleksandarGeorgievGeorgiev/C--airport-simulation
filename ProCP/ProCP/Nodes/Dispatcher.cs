using ProCP.Abstractions;
using ProCP.Contracts;
using ProCP.FlightAndBaggage;
using ProCP.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ProCP.Nodes
{
    class Dispatcher : ChainNode, IDispatcher, IStartStop
    {
        public override string Destination => this.GetType().Name;

        public List<ICheckIn> checkins;
        public List<Queue<Baggage>> checkinQueues;
        private List<Timer> _flightTimers;

        public Dispatcher(string nodeId, ITimerTracker timeService) : base(nodeId, timeService)
        {
            checkins = new List<ICheckIn>();
            checkinQueues = new List<Queue<Baggage>>();
        }

        public void SetCheckIns(List<ICheckIn> checkins)
        {
            foreach (var checkin in checkins)
            {
                checkins.Add(checkin);
            }

            SetupCheckinQueues();
        }

        private void SetupCheckinQueues()
        {
            foreach (var index in Enumerable.Range(0, checkins.Count))
            {
                checkinQueues.Add(new Queue<Baggage>());
            }
        }

        public void Start()
        {
            foreach (Timer t in _flightTimers)
            {
                t.Start();
            }
        }

        public void Stop()
        {
            foreach (Timer t in _flightTimers)
            {
                t.Stop();
            }

        }

        public void SetupFlightTimers(List<IFlight> flights)
        {
            _flightTimers = new List<Timer>();

            foreach (var flight in flights)
            {
                var timer = new Timer();
                _flightTimers.Add(timer);
                timer.Interval = 1000;

                timer.Elapsed += (sender, args) =>
                {
                    if (flight.BaggageCount > flight.DispatchedBaggageCount)
                    {
                        DispatchBaggage(flight);
                    }
                    else
                    {
                        timer.Stop();
                    }
                };
            }
        }

        private void DispatchBaggage(IFlight flight)
        {
            var baggage = new Baggage();
            baggage.Flight.FlightNumber = flight.FlightNumber;
            int chosen = FindMostSuitableCheckin(baggage);
            var checkIn = checkins[chosen];
            var queue = checkinQueues[chosen];

            baggage.TransportationStartTime = TimerService.GetTicksSinceSimulationStart();
            baggage.TransporterId = "Queue CheckIn";

            if (checkIn.NodeNodeStatus == NodeStatus.Free)
            {
                checkIn.PassBaggage(baggage);
                if (OnNodeStatusChangedToFree != null)
                {
                    checkIn.OnNodeStatusChangedToFree -= () => PassQueuedBaggage(chosen);
                }
            }
            else
            {
                queue.Enqueue(baggage);
                checkIn.OnNodeStatusChangedToFree += () => PassQueuedBaggage(chosen);
            }
            flight.DispatchedBaggageCount++;

        }

        private void PassQueuedBaggage(int chosen)
        {
            var checkIn = checkins[chosen];
            var queue = checkinQueues[chosen];

            if (queue.Count != 0)
            {
                checkIn.PassBaggage(queue.Dequeue());
            }
        }

        private int FindMostSuitableCheckin(Baggage baggage)
        {
            int chosenIndex = 0;

            foreach (var checkIn in Enumerable.Range(0, checkins.Count))
            {
                if (checkins.ElementAt(checkIn).Destination == baggage.Destination)
                {
                    if (checkins.ElementAt(checkIn).NodeNodeStatus == NodeStatus.Free)
                    {
                        chosenIndex = checkIn;
                        return chosenIndex;
                    }
                    chosenIndex = checkIn;
                }
            }
            return chosenIndex;

        }

        public void AddNextNode(IChainNode node)
        {
            checkins.Add((ICheckIn)node);
        }

        public override void PassBaggage(IBaggage b)
        {
            throw new NotImplementedException();
        }
    }
}
