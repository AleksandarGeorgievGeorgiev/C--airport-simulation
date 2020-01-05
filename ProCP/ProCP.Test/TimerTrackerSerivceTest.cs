using NUnit.Framework;
using ProCP.Services;
using Shouldly;
using System.Threading;

namespace ProCP.Test
{
    [TestFixture]
    public class TimerTrackerSerivceTest
    {
        [Test]
        public void TimerService_ShouldRunNewTimer_OnRunNewTimer()
        {
            var timerService = new TimerTracker();

            timerService.RunNewWatch();
            Thread.Sleep(2000);
            timerService.Stop();

            timerService.GetTimeSinceSimulationStart().TotalMilliseconds.ShouldBeGreaterThan(2000);

            timerService.RunNewWatch();
            timerService.Stop();
            timerService.GetTimeSinceSimulationStart().TotalMilliseconds.ShouldBeLessThan(2000);
        }

        [Test]
        public void TimerService_ShouldReturnSameTimeSinceStart_FromBothMethods()
        {
            var timerService = new TimerTracker();

            timerService.RunNewWatch();
            Thread.Sleep(2000);
            timerService.Stop();

            timerService.GetTicksSinceSimulationStart().ShouldBeInRange(timerService.GetTimeSinceSimulationStart().Ticks - 5, timerService.GetTimeSinceSimulationStart().Ticks + 5);
        }

        [Test]
        public void TimerService_ConvertMillisecondsToTimeSpan_ShouldConvertCorrectly()
        {
            var timerService = new TimerTracker();

            timerService.ConvertMillisecondsToTimeSpan(1000).TotalSeconds.ShouldBe(1);
        }
    }
}
