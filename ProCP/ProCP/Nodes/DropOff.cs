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
                    case 1:
                        _processingSpeed = 1200;
                        break;
                    case 5:
                        _processingSpeed = 1000;
                        break;
                    case 8:
                        _processingSpeed = 800;
                        break;
                    default:
                        _processingSpeed = 1000;
                        break;
                }
            }
        }

        public IFlight Flight { get; set; }

        public void AssighFlight(IFlight flight)
        {
            Flight = flight;
        }
        public override string Destination => Flight.FlightNumber;

        public override void PassBaggage(IBaggage b)
        {
            b.AddLog(TimerService.GetTimeSinceSimulationStart(), TimerService.ConvertMillisecondsToTimeSpan(ProcessingSpeed), "drop off processing");
            b.Destination = Destination;
            _pickedUpBags.Add(b);
        }
    }
}
