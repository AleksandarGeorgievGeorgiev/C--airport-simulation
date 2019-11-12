using ProCP.Contracts;
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
        public static List<IChainNode> Nodes;
        private ISimulationSettings _settings;
        private ITimerTracker _timerService;

        public NodeCreationService(ITimerTracker timerService)
        {
            Nodes = new List<IChainNode>();
            _timerService = timerService;
        }

        public void SetSimulationSettings(ISimulationSettings settings)
        {
            this._settings = settings;
        }
        public ICheckInDesk CreateCheckinDesk()
        {
            ValidateSettings();
            var checkin = new CheckInDesk(Guid.NewGuid().ToString(), _timerService);
            Nodes.Add(checkin);
            return checkin;
        }
        public IPrimarySecurity CreatePrimarySecurity()
        {
            ValidateSettings();
            var primarySecurity = new PrimarySecurity(_settings.Ps, Guid.NewGuid().ToString(), _timerService);
            Nodes.Add(primarySecurity);
            return primarySecurity;
        }
        public IConveyorOneToOne CreateConveyorOneToOne(int length)
        {
            ValidateSettings();
            var conveyorOneToOne = new ConveyorOneToOne(length, Guid.NewGuid().ToString(), _timerService, _settings.Cs);
            Nodes.Add(conveyorOneToOne);
            return conveyorOneToOne;
        }
        public IMda CreateMda()
        {
            ValidateSettings();
            var mda = new Mda(Guid.NewGuid().ToString(), _timerService);
            Nodes.Add(mda);
            return mda;
        }
        public IDispatcher CreateCheckinDispatcher()
        {
            ValidateSettings();
            var dispatcher = new Dispatcher(Guid.NewGuid().ToString(), _timerService, _settings);
            Nodes.Add(dispatcher);
            return dispatcher;
        }
        public IDropOff CreateDropoff()
        {
            ValidateSettings();
            var dropoff = new DropOff(Guid.NewGuid().ToString(), _timerService, _settings.DropOffSettings);
            Nodes.Add(dropoff);
            return dropoff;
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
