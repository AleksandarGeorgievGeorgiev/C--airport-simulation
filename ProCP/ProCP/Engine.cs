﻿using ProCP.Contracts;
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
            var nodes = _nodeCreationService.CreateNodes(_settings.FrontNodes).ToList();
            nodes.Add(_nodeCreationService.CreateCheckinDispatcher(Guid.NewGuid().ToString()));
            _startStopNodes = nodes.OfType<IStartStop>().ToList();

            //start nodes
            _timerTracker.RunNewWatch();
            _startStopNodes.ForEach(n => n.Start());
            
        }

        public Func<StatisticsData> GetStatisticsCalculator() => () => StatisticsCalculator.CalculateStatistics();
    }
}
