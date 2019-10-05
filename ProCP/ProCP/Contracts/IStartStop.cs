﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCP.Contracts
{
    interface IStartStop: ITransportingNode
    {
        void Start();
        void Stop();
    }
}
