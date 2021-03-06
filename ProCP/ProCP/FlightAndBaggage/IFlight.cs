﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCP.FlightAndBaggage
{
    public interface IFlight
    {
        DateTime DipartureTime { get; set; }
        int BaggageCount { get; set; }
        string FlightNumber { get; set; }
        int DispatchedBaggageCount { get; set; } 
        bool HasCheckin { get; set; }
        bool HasDropOff { get; set; }
        string DropoffId { get; set; }
    }
}
