using ProCP.Contracts;
using ProCP.FlightAndBaggage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCP
{
    public class SimulationSettings: ISimulationSettings
    {
        public PrimarySecuritySettings Ps { get; set; }
        public List<IFlight> Flights { get; set; }
        public ConveyorSettings Cs { get; set; }

        public SimulationSettings()
        {
            Ps = new PrimarySecuritySettings();
            Flights = new List<IFlight>();
        }
    }

    public class PrimarySecuritySettings : IPrimarySecuritySettings
    {
        public double PercentageFailedBags { get; set; }
        public int ProcessingSpeed { get; set; } = 1000;
    }

    public class ConveyorSettings : IConveyorSettings
    {
        public long Speed { get; set; } = 1000;
    }
}
