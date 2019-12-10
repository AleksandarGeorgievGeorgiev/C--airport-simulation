using ProCP.Contracts;
using ProCP.FlightAndBaggage;
using ProCP.Visuals;
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
        public List<Flight> Flights { get; set; }
        public ConveyorSettings Cs { get; set; }
        public DropOffSettings DropOffSettings { get; set; }
        public List<GridTile> FrontNodes { get; set; }

        public SimulationSettings()
        {
            DropOffSettings = new DropOffSettings();
            Cs = new ConveyorSettings();
            Ps = new PrimarySecuritySettings();
            Flights = new List<Flight>();
            FrontNodes = new List<GridTile>();

        }
    }

    public class PrimarySecuritySettings : IPrimarySecuritySettings
    {
        public double PercentageFailedBags { get; set; } = 10;
        public int ProcessingSpeed { get; set; } = 1000;
    }

    public class ConveyorSettings : IConveyorSettings
    {
        public long Speed { get; set; } = 1000;
    }

    public class DropOffSettings : IDropoffSettings
    {
        public int NumberOfWorker { get; set; } = 1;
    }
}
