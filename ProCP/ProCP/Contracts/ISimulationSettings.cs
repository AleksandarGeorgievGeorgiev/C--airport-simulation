using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCP.Contracts
{
    public interface ISimulationSettings
    {
        PrimarySecuritySettings Pss { get; set; }
    }

    public interface IPrimarySecuritySettings
    {
        int ProcessingSpeed { get; set; }
        double PercentageFailedBags { get; set; }
    }
}
