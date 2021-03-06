﻿using ProCP.Contracts;
using ProCP.Services;
using ProCP.Services.CSVStatsExport;
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
        private CSVWriteService _CSVWriteService;
        

        public Engine()
        {
            _timerTracker = new TimerTracker();
            _nodeCreationService = new NodeCreationService(_timerTracker);
            _calculator = new StatisticsCalculator();
            _CSVWriteService = new CSVWriteService();
        }

        public void Run(SimulationSettings settings)
        {
            _settings = settings;
            _nodeCreationService.SetSimulationSettings(_settings);

            //create nodes
            var dispatcher = _nodeCreationService.CreateCheckinDispatcher(Guid.NewGuid().ToString());
            var nodes = _nodeCreationService.CreateNodes(_settings.FrontNodes).ToList();
            dispatcher.SetCheckIns(NodeCreationService.Nodes.OfType<ICheckInDesk>().ToList());
            _startStopNodes = NodeCreationService.Nodes.OfType<IStartStop>().ToList();

            //start nodes
            _timerTracker.RunNewWatch();
            _startStopNodes.ForEach(n => n.Start());
        }

        public void Stop()
        {
            NodeCreationService.Nodes.Clear();
        }

        public List<IDropOff> GetDropoffs(SimulationSettings settings)
        {
            var dropoffs = NodeCreationService.Nodes.OfType<IDropOff>().ToList();
            
            return dropoffs;
        }

        public void WriteStatsToCsv(SimulationSettings settings, StatisticsData data)
        {
            _CSVWriteService.WriteToCSV(settings, data);
        }

        public Func<StatisticsData> GetStatisticsCalculator() => () => StatisticsCalculator.CalculateStatistics();
    }
}
