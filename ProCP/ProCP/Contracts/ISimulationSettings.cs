using ProCP.FlightAndBaggage;
using ProCP.Visuals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCP.Contracts
{
    public interface ISimulationSettings
    {
        PrimarySecuritySettings Ps { get; set; }
        ConveyorSettings Cs { get; set; }
        DropOffSettings DropOffSettings { get; set; }
        List<Flight> Flights { get; set; }
        List<GridTile> FrontNodes { get; set; }

    }

    public interface IPrimarySecuritySettings
    {
        int ProcessingSpeed { get; set; }
        double PercentageFailedBags { get; set; }
    }

    public interface IConveyorSettings
    {
        long Speed { get; set; }
    }

    public interface IDropoffSettings
    {
        int NumberOfWorker { get; set; }
    }
}
