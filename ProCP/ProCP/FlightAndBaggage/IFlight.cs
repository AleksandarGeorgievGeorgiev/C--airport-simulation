﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCP.FlightAndBaggage
{
    public interface IFlight
    {
        TimeSpan DipartureTime { get; set; }
        int BaggageCount { get; set; }
        string FlightNumber { get; set; }
        string Gate { get; set; }
        int DispatchedBaggageCount { get; set; }
    }
}