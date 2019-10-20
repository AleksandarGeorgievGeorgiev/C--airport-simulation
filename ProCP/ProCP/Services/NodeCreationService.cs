﻿using ProCP.Contracts;
using ProCP.Nodes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCP.Services
{
    public class NodeCreationService
    {
        public List<IChainNode> Nodes { get; set; }
        private ISimulationSettings _settings;
        private ITimerTracker _timerService;

        public NodeCreationService()
        {
            Nodes = new List<IChainNode>();
            _timerService = new TImerTracker();
        }

        public void SetSimulationSettings(ISimulationSettings settings)
        {
            this._settings = settings;
        }
        public void CreateCheckinDesk()
        {
            ValidateSettings();
            var checkin = new CheckInDesk(Guid.NewGuid().ToString(), _timerService);
            Nodes.Add(checkin);
        }
        public void CreatePrimarySecurity()
        {
            ValidateSettings();
            var primarySecurity = new PrimarySecurity(_settings.Ps, Guid.NewGuid().ToString(), _timerService);
            Nodes.Add(primarySecurity);
        }
        public void CreateConveyorOneToOne(int length)
        {
            ValidateSettings();
            var conveyorOneToOne = new ConveyorOneToOne(length, Guid.NewGuid().ToString(), _timerService, _settings.Cs);
            Nodes.Add(conveyorOneToOne);
        }
        public void CreateMda()
        {
            ValidateSettings();
            var mda = new Mda(Guid.NewGuid().ToString(), _timerService);
            Nodes.Add(mda);
        }
        public void CreateCheckinDispatcher()
        {
            ValidateSettings();
            var dispatcher = new Dispatcher(Guid.NewGuid().ToString(), _timerService);
            Nodes.Add(dispatcher);
        }
        public void CreateDropoff()
        {
            ValidateSettings();
            var dropoff = new DropOff(Guid.NewGuid().ToString(), _timerService);
            Nodes.Add(dropoff);
        }

        public void ValidateSettings()
        {
            if (_settings == null)
            {
                throw new NoNullAllowedException("The simulation settings have not been set");
            }
        }
    }
}
