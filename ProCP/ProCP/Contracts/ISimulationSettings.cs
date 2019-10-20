using ProCP.FlightAndBaggage;
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
        List<IFlight> Flights { get; set; }
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
}
