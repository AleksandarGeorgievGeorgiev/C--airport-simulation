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
    class SecondSecurity: BaseSecurity
    {
        public SecondSecurity(IPrimarySecuritySettings settings, string nodeId, ITimerTracker timeService) : base(settings, nodeId, timeService) { }

        public override void Process(IBaggage b)
        {
            base.Process(b);
            if (!_isFail)
            {
                //b.Destination = typeof(Mda).Name;
                b.Destination = typeof(FinalSecurity).Name;
                return;
            }

            bagsTaken.Add(b);
            currentBag = null;
        }
    }
}
