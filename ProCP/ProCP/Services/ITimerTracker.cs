using ProCP.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCP.Services
{
    public interface ITimerTracker : IStartStop
    {
        void RunNewWatch();
        TimeSpan ConvertMillisecondsToTimeSpan(int milliseconds);
        TimeSpan GetTimeSinceSimulationStart();
        long GetTicksSinceSimulationStart();
        void SetSettings(ISimulationSettings settings);
    }
}
