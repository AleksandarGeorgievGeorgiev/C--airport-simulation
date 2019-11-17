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
    class SecondSecurity: ProcessingNode, IPrimarySecurity
    {
        private IPrimarySecuritySettings _psSettings;
        private Random _rand;
        public Queue<IBaggage> bagsTaken = new Queue<IBaggage>();

        public SecondSecurity(IPrimarySecuritySettings settings, string nodeId, ITimerTracker timeService) : base(nodeId, timeService)
        {
            this._psSettings = settings;
            this._rand = new Random();
            this.currentBag = null;
        }


        public override void Process(IBaggage b)
        {
            System.Diagnostics.Debug.WriteLine("psc" + b.Destination);

            var isFail = _rand.Next(0, 101) < _psSettings.PercentageFailedBags;

            b.AddLog(TimerService.GetTimeSinceSimulationStart(), TimerService.ConvertMillisecondsToTimeSpan(_psSettings.ProcessingSpeed),
                $"Second security check ID-{NodeId} processing - { (isFail ? LoggingConstants.SecondSecurityCheckFailed : LoggingConstants.SecondSecurityCheckSucceeded)}");
            if (!isFail)
            {
                //b.Destination = typeof(Mda).Name;
                b.Destination = typeof(FinalSecurity).Name;
                return;
            }

            bagsTaken.Enqueue(b);
            currentBag = null;
        }


    }
}
