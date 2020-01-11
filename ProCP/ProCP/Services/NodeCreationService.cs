using ProCP.Contracts;
using ProCP.Nodes;
using ProCP.Visuals;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ProCP.Services
{
    public class NodeCreationService
    {
        public static List<IChainNode> Nodes;
        private ISimulationSettings _settings;
        private ITimerTracker _timerService;

        public NodeCreationService(ITimerTracker timerService)
        {
            Nodes = new List<IChainNode>();
            _timerService = timerService;
        }


        public IEnumerable<IChainNode> CreateNodes(IEnumerable<GridTile> nodes)
        {
            var createdNodes = new List<IChainNode>();

            foreach (var node in nodes ?? Enumerable.Empty<GridTile>())
            {
                var existingNode = Nodes.FirstOrDefault(n => n.NodeId == node.NodeId.ToString());

                if (existingNode == null)
                {
                    existingNode = CreateNode(node);
                }

                createdNodes.Add(existingNode);

                var chiledNodes = CreateNodes(node.NextTiles).ToList();
                ConnectNodes(existingNode, chiledNodes);
            }

            return createdNodes;
        }

        public void ConnectNodes(IChainNode node, List<IChainNode> nextNodes)
        {
            foreach (var chainNode in nextNodes)
            {
                if (node is ISingleNextNode single)
                {
                    single.SetSingleNextNode(chainNode);
                }
                else if (node is IMultiNextNode multi)
                {
                    multi.AddNextNodes(chainNode);
                }
            }
        }

        private IEnumerable<T> GetNodesOfType<T>(IEnumerable<IChainNode> nodes)
        {
            return nodes.OfType<T>();
        }

        public IChainNode CreateNode(GridTile frontNode)
        {
            if (frontNode is CheckInTile)
            {
                return CreateCheckinDesk(frontNode.NodeId);
            }
            if (frontNode is ConveyorTile)
            {
                return CreateConveyorOneToOne(frontNode.NodeId, frontNode.Length);
            }
            if (frontNode is SecurityTile)
            {
                return CreatePrimarySecurity(frontNode.NodeId);
            }
            if (frontNode is MDATile)
            {
                return CreateMda(frontNode.NodeId);
            }
            if (frontNode is DropOffTile)
            {
                return CreateDropoff(frontNode.NodeId);
            }
            throw new ArgumentException("Unsupported node type");
        }

        public void SetSimulationSettings(ISimulationSettings settings)
        {
            this._settings = settings;
        }
        public ICheckInDesk CreateCheckinDesk(int nodeId)
        {
            ValidateSettings();
            var checkin = new CheckInDesk(nodeId.ToString(), _timerService);
            Nodes.Add(checkin);
            var sortedFlights = _settings.Flights.OrderBy(f => f.DipartureTime);
            foreach (var flight in sortedFlights)
            {
                if (checkin.Flight != null)
                {
                    continue;
                }
                if (flight.HasCheckin == true)
                {
                    continue;
                }
                checkin.AssignFlight(flight);
                flight.HasCheckin = true;
            }

            return checkin;
        }
        public IPrimarySecurity CreatePrimarySecurity(int nodeId)
        {
            ValidateSettings();
            var primarySecurity = new PrimarySecurity(_settings.Ps, nodeId.ToString(), _timerService);
            Nodes.Add(primarySecurity);
            return primarySecurity;
        }
        public IConveyorOneToOne CreateConveyorOneToOne(int nodeId, int length)
        {
            ValidateSettings();
            var conveyorOneToOne = new ConveyorOneToOne(length, nodeId.ToString(), _timerService, _settings.Cs);
            Nodes.Add(conveyorOneToOne);
            return conveyorOneToOne;
        }
        public IMda CreateMda(int nodeId)
        {
            ValidateSettings();
            var mda = new Mda(nodeId.ToString(), _timerService);
            Nodes.Add(mda);
            return mda;
        }
        public IDispatcher CreateCheckinDispatcher(string nodeId)
        {
            ValidateSettings();
            var dispatcher = new Dispatcher(nodeId.ToString(), _timerService, _settings);
            Nodes.Add(dispatcher);
            return dispatcher;
        }
        public IDropOff CreateDropoff(int nodeId)
        {
            ValidateSettings();
            var dropoff = new DropOff(nodeId.ToString(), _timerService, _settings.DropOffSettings);
            Nodes.Add(dropoff);
            var sortedFlights = _settings.Flights.OrderBy(f => f.DipartureTime);
            foreach (var flight in sortedFlights)
            {
                if (dropoff.Flight != null)
                {
                    continue;
                }
                if (flight.HasDropOff == true)
                {
                    continue;
                }
                dropoff.AssignFlight(flight);
                flight.HasDropOff = true;
            }
            return dropoff;
        }

        public void ValidateSettings()
        {
            if (_settings == null)
            {
                throw new NoNullAllowedException("The simulation settings have not been set");
            }
        }
    }
}
