﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProCP.FlightAndBaggage;

namespace ProCP.Contracts
{
    interface IProcessingNode
    {
        void Process(Baggage b);
    }
}
