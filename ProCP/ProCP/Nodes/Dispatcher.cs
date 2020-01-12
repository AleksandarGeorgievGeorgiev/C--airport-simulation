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
    class Dispatcher : ChainNode, IDispatcher
    {
        public override string Destination => this.GetType().Name;

        public List<ICheckInDesk> checkins;
        public List<Queue<Baggage>> checkinQueues;
        private List<Timer> _flightTimers;
        private readonly ISimulationSettings _simulationSettings;


        public Dispatcher(string nodeId, ITimerTracker timeService, ISimulationSettings simulationSettings) : base(nodeId, timeService)
        {
            _simulationSettings = simulationSettings;
            checkins = new List<ICheckInDesk>();
            checkinQueues = new List<Queue<Baggage>>();
            SetupFlightTimers();
        }

        public void SetCheckIns(List<ICheckInDesk> nodes)
        {
            checkins = nodes;
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

        public void SetupFlightTimers()
        {
            _flightTimers = new List<Timer>();

            foreach (var flight in _simulationSettings.Flights)
            {
                var timer = new Timer();
                _flightTimers.Add(timer);
                timer.Interval = CalculateDispatchTime(flight);

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
            var baggage = new Baggage()
            {
                Flight = flight
            };


            int chosen = FindMostSuitableCheckin(baggage);
            var checkIn = checkins[chosen];
            var queue = checkinQueues[chosen];

            baggage.TransportationStartTime = TimerService.GetTicksSinceSimulationStart();
            baggage.TransporterId = "Queue CheckIn";

            if (checkIn.NodeStatus == NodeStatus.Free)
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
            var chosenIndex = 0;
            var shortestQueue = checkinQueues[0].Count;

            foreach (var index in Enumerable.Range(0, checkins.Count))
            {
                if (checkins[index].NodeStatus == NodeStatus.Free)
                {
                    return index;
                }

                if (checkinQueues[index].Count < shortestQueue)
                {
                    shortestQueue = checkinQueues[index].Count;
                    chosenIndex = index;
                }
            }

            return chosenIndex;
        }

        public int CalculateDispatchTime(Flight flight)
        {
            var currentTime = DateTime.Now;
            var interval = new TimeSpan();
            interval = currentTime - flight.DipartureTime;
            interval = flight.DipartureTime - currentTime;
            var dispatchRate = (interval.Seconds) * 1000;

            return dispatchRate;
        }

        public override void PassBaggage(IBaggage b)
        {
            throw new NotImplementedException();
        }
    }
}
