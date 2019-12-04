using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProCP.Abstractions;
using ProCP.Contracts;
using ProCP.FlightAndBaggage;
using ProCP.Services;

namespace ProCP.Nodes
{
    class FinalSecurity: ProcessingNode, IPrimarySecurity
    {
        private IPrimarySecuritySettings _psSettings;
        private Random _rand;
        public Queue<IBaggage> bagsTaken = new Queue<IBaggage>();
        private List<IBaggage> _dangerousBaggage;

        public FinalSecurity(IPrimarySecuritySettings settings, string nodeId, ITimerTracker timeService) : base(nodeId, timeService)
        {
            this._psSettings = settings;
            this._rand = new Random();
            this.currentBag = null;
            this._dangerousBaggage = new List<IBaggage>();
        }


        public override void Process(IBaggage b)
        {
            System.Diagnostics.Debug.WriteLine("psc" + b.Destination);

            var isFail = _rand.Next(0, 101) < _psSettings.PercentageFailedBags;

            b.AddLog(TimerService.GetTimeSinceSimulationStart(), TimerService.ConvertMillisecondsToTimeSpan(_psSettings.ProcessingSpeed),
                $"Final security check ID-{NodeId} processing - { (isFail ? LoggingConstants.FinalSecurityCheckFailed: LoggingConstants.FinalSecurityCheckSucceeded)}");
            if (!isFail)
            {
                b.Destination = typeof(Mda).Name;
                return;
            }

            bagsTaken.Enqueue(b);
            currentBag = null;
            this._dangerousBaggage.Add(b);
        }
    }
}
