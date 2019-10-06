using ProCP.Abstractions;
using ProCP.Contracts;
using ProCP.FlightAndBaggage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCP.Node
{
    public class AutomatedSecurity : ProcessingNode, IAutomatedSecurity
    {
        public override void PassBaggage(Baggage b)
        {
            throw new NotImplementedException();
        }
    }
}
