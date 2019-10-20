using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProCP.Contracts;

namespace ProCP.Services
{
    public class TImerTracker : ITimerTracker
    {
        private Stopwatch _watch;

        public TImerTracker()
        {
            _watch = new Stopwatch();
        }

        public void Start()
        {
            _watch.Start();
        }

        public void Stop()
        {
            _watch.Stop();
        }

        public long GetTicksSinceSimulationStart()
        {
            var elapsedTicks = _watch.Elapsed.Ticks;
            return (long)(elapsedTicks * 1);
        }

        public TimeSpan GetTimeSinceSimulationStart()
        {
            var elapsedTicks = _watch.Elapsed.Ticks;
            elapsedTicks = (long)Math.Round((float)elapsedTicks * 1);
            return new TimeSpan(elapsedTicks);
        }

        public TimeSpan ConvertMillisecondsToTimeSpan(int milliseconds)
        {
            return new TimeSpan(ticks: milliseconds * 10000);
        }

        public void SetSettings(ISimulationSettings settings)
        {
            var _simulationSettings = settings;
            _simulationSettings.Flights = _simulationSettings.Flights.OrderBy(f => f.DipartureTime).ToList();
        }
    }
}
