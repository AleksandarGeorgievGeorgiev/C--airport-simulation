using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProCP.Services;

namespace ProCP.Data
{
    abstract class BaseDataReader
    {
        protected NodeCreationService _nodeCreationService;
        protected TimerTracker _timerTracker;
        protected SimulationSettings _settings;
        protected StatisticsCalculator _calculator;
    }
}
