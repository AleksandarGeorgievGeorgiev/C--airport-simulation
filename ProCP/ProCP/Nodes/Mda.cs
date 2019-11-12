using ProCP.Abstractions;
using ProCP.Contracts;
using ProCP.FlightAndBaggage;
using ProCP.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCP.Nodes
{
    public class Mda : ChainNode, IMda
    {
        private Dictionary<string, IChainNode> _listOfNextNode;
        private Dictionary<string, Queue<IBaggage>> _transporterQueues;
        public Mda(string nodeId, ITimerTracker timerService) : base(nodeId, timerService)
        {
            _listOfNextNode = new Dictionary<string, IChainNode>();
            _transporterQueues = new Dictionary<string, Queue<IBaggage>>();
        }

        public override string Destination => this.GetType().Name;

        public void AddNextNodes(IConveyorOneToOne node)
        {
            _listOfNextNode.Add(node.Destination, node);
            _transporterQueues.Add(node.Destination, new Queue<IBaggage>());


            Task.Run(() =>
            {
                DistributeBaggage(node.Destination);
            });
        }

        private void DistributeBaggage(string destination)
        {
            var nextNode = _listOfNextNode[destination];

            nextNode.OnNodeStatusChangedToFree += () =>
            {
                if (_transporterQueues[destination].Count > 0)
                {
                    if (nextNode.NodeNodeStatus == NodeStatus.Free)
                    {
                        var tempBag = _transporterQueues[destination].Dequeue();

                        if (tempBag == null)
                        {
                            return;
                        }

                        tempBag.TransportationStartTime = TimerService.GetTicksSinceSimulationStart();
                        nextNode.PassBaggage(tempBag);
                    }
                }
            };
        }

        public override void PassBaggage(IBaggage b)
        {
            AddBagTransportationLog(b);

            SortBaggageToTransporterNode(b);

            b.AddLog(TimerService.GetTimeSinceSimulationStart(), TimerService.ConvertMillisecondsToTimeSpan(1000), "Mda processing. Sorted to dropoff " + b.Destination);

            _transporterQueues[b.Destination].Enqueue(b);
        }

        private void SortBaggageToTransporterNode(IBaggage b)
        {
            foreach (var node in _listOfNextNode)
            {
                if (node.Value.NextNode.Destination == b.Flight.FlightNumber)
                {
                    b.Destination = node.Value.NextNode.Destination;
                }
            }
        }

        public void AddBagTransportationLog(IBaggage b)
        {
            if (b.TransportationStartTime != null)
            {
                var transportationStart = b.TransportationStartTime ?? 0;
                var transportingTimeElapsed = TimerService.GetTicksSinceSimulationStart() - transportationStart;
                b.AddLog(TimerService.GetTimeSinceSimulationStart(),
                    new TimeSpan(transportingTimeElapsed),
                    string.Format(LoggingConstants.BagReceivedInTemplate, Destination, b.TransporterId));
                b.TransportationStartTime = null;
            }
        }
    }
}
