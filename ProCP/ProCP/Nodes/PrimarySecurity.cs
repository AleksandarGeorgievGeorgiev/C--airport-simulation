using ProCP.Abstractions;
using ProCP.Contracts;
using ProCP.FlightAndBaggage;
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
        private int _processingSpeed;
        private double _percetange;
        private Timer _timer;
        public PrimarySecurity(IPrimarySecuritySettings settings, string nodeId, Timer timer) : base(nodeId, timer)
        {
            _percetange = settings.PercentageFailedBags;
            _timer = timer;
        }

        public int ProcessingSpeed
        {
            get
            {
                return _processingSpeed;
            }
            set
            {
                switch (_processingSpeed)
                {
                    case 1:
                        _timer.Interval = 1200;
                        break;
                    case 2:
                        _timer.Interval = 1000;
                        break;
                    case 3:
                        _timer.Interval = 800;
                        break;
                    case 4:
                        _timer.Interval = 600;
                        break;
                    default:
                        break;
                }
            }
        }
        public override string Destination { get; }

        //TODO: we can prompt the user to enter a failure percetange for the securities 
        //and use it here to calculate the passing rate of the security
        //this must be done in the Process()
        public override void Process(IBaggage b)
        {
            if (!_timer.Enabled)
            {
                _timer.Start();
            }
            _timer.Stop();
            //logic with the percentage and add log to the bag logs
            _timer.Start();
        }
    }
}
