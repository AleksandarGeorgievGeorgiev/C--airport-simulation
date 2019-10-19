﻿using ProCP.Abstractions;
using ProCP.Contracts;
using ProCP.FlightAndBaggage;
using ProCP.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ProCP.Nodes
{
    public class PrimarySecurity : ProcessingNode, IPrimarySecurity
    {
        IPrimarySecuritySettings _psSettings;
        private readonly Random _randomGen;
        public PrimarySecurity(IPrimarySecuritySettings settings, string nodeId, ITimerTracker timeService) : base(nodeId, timeService)
        {
            _psSettings = settings;
            _randomGen = new Random();
        }

        public override string Destination { get; }

        //TODO: we can prompt the user to enter a failure percetange for the securities 
        //and use it here to calculate the passing rate of the security
        //this must be done in the Process()
        public override void Process(IBaggage b)
        {
            var isFail = _randomGen.Next(0, 101) < _psSettings.PercentageFailedBags;

            b.AddLog(TimerService.GetTimeSinceSimulationStart(), TimerService.ConvertMillisecondsToTimeSpan(_psSettings.ProcessingSpeed),
                $"Primary security check ID-{NodeId} processing - { (isFail ? LoggingConstants.PrimarySecurityCheckFailed : LoggingConstants.PrimarySecurityCheckSucceeded)}");

            b.Destination = isFail ? "collected by security" : typeof(Mda).Name;
        }
    }
}
