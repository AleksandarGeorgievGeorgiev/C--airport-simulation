using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProCP.Abstractions;
using ProCP.Contracts;
using ProCP.FlightAndBaggage;
using ProCP.Services;

namespace ProCP.Nodes.OwnImplementation
{
    abstract class BaseSecurity: ProcessingNode, IPrimarySecurity
    {
        //base on chain of responsibility design pattern.

        IPrimarySecuritySettings _psSettings;
        private readonly Random _randomGen;
        public List<IBaggage> bagsTaken = new List<IBaggage>();
        protected bool _isFail;
        public BaseSecurity(IPrimarySecuritySettings settings, string nodeId, ITimerTracker timeService) : base(nodeId, timeService)
        {
            _psSettings = settings;
            _randomGen = new Random();
            /*_percetange = settings.PercentageFailedBags;
            _timer = timer;*/
            this.currentBag = null;
        }
        public override void Process(IBaggage b)
        {
            System.Diagnostics.Debug.WriteLine("psc" + b.Destination);

            _isFail = _randomGen.Next(0, 101) < _psSettings.PercentageFailedBags;

            b.AddLog(TimerService.GetTimeSinceSimulationStart(), TimerService.ConvertMillisecondsToTimeSpan(_psSettings.ProcessingSpeed),
                $"Primary security check ID-{NodeId} processing - { (_isFail ? LoggingConstants.PrimarySecurityCheckFailed : LoggingConstants.PrimarySecurityCheckSucceeded)}");
        }
    }
}
