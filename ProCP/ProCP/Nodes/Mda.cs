using ProCP.Abstractions;
using ProCP.Contracts;
using ProCP.FlightAndBaggage;
using ProCP.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCP.Nodes
{
    public class Mda : ChainNode, IMda
    {
        public Mda(string nodeId, ITimerTracker timerService) : base(nodeId, timerService)
        {

        }

        public override string Destination => this.GetType().Name;

        public void AddNextNodes(IChainNode node)
        {
            throw new NotImplementedException();
        }

        public override void PassBaggage(IBaggage b)
        {
            throw new NotImplementedException();
        }
    }
}
