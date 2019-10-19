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
        TimeSpan ConvertMillisecondsToTimeSpan(int milliseconds);
        TimeSpan GetTimeSinceSimulationStart();
        long GetTicksSinceSimulationStart();
    }
}
