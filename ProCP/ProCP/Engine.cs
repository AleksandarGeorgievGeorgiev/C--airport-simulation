using ProCP.Contracts;
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
        private List<IStartStop> _startStopNodes;
        

        public Engine()
        {
            _timerTracker = new TimerTracker();
            _nodeCreationService = new NodeCreationService(_timerTracker);
            _calculator = new StatisticsCalculator();
        }

        public void RunDemo(SimulationSettings settings)
        {
            _settings = settings;
            _nodeCreationService.SetSimulationSettings(_settings);

            //create nodes
            var dispatcher = _nodeCreationService.CreateCheckinDispatcher(Guid.NewGuid().ToString());
            var nodes = _nodeCreationService.CreateNodes(_settings.FrontNodes).ToList();
            AssignFlightsToCheckInAndDropOff();
            dispatcher.SetCheckIns(NodeCreationService.Nodes.OfType<ICheckInDesk>().ToList());
            _startStopNodes = NodeCreationService.Nodes.OfType<IStartStop>().ToList();

            //start nodes
            _timerTracker.RunNewWatch();
            _startStopNodes.ForEach(n => n.Start());
        }

        public void AssignFlightsToCheckInAndDropOff()
        {
            var sortedFlights = _settings.Flights.OrderBy(f => f.DipartureTime);
            foreach (var flight in sortedFlights)
            {
                var freeCheckin = NodeCreationService.Nodes.OfType<ICheckInDesk>().FirstOrDefault(c => c.Flight is null);
                freeCheckin.AssignFlight(flight);
                var freeDropoff = NodeCreationService.Nodes.OfType<IDropOff>().FirstOrDefault(d => d.Flight is null);
                freeDropoff.AssignFlight(flight);
            }
        }

        public Func<StatisticsData> GetStatisticsCalculator() => () => StatisticsCalculator.CalculateStatistics();
    }
}
