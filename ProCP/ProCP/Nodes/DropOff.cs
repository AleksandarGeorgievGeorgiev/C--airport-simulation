using ProCP.Abstractions;
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
    public class DropOff : ChainNode, IDropOff
    {
        private int _processingSpeed;
        private readonly IDropoffSettings _dropoffSettings;
        public List<IBaggage> _pickedUpBags;
        public DropOff(string nodeId, ITimerTracker timer, IDropoffSettings settings) : base(nodeId, timer)
        {
            _dropoffSettings = settings;
            _pickedUpBags = new List<IBaggage>();
        }

        public int Capacity { get; set; }
        public int Workers { get; set; }

        public int ProcessingSpeed
        {
            get
            {
                return _processingSpeed;
            }
            set
            {
                switch (_dropoffSettings.NumberOfWorker)
                {
                    case 2:
                        _processingSpeed = 1000;
                        break;
                    case 4:
                        _processingSpeed = 800;
                        break;
                    case 6:
                        _processingSpeed = 600;
                        break;
                    default:
                        _processingSpeed = 1000;
                        break;
                }

                _processingSpeed = value;
            }
        }

        public IFlight Flight { get; set; }

        public void AssignFlight(IFlight flight)
        {
            Flight = flight;
        }
        public override string Destination => this.NodeId;

        public override void PassBaggage(IBaggage b)
        {
            b.Destination = Destination;
            _pickedUpBags.Add(b);
            b.AddLog(TimerService.GetTimeSinceSimulationStart() + new TimeSpan(ProcessingSpeed), TimerService.ConvertMillisecondsToTimeSpan(ProcessingSpeed), "drop off processing");
        }
    }
}
