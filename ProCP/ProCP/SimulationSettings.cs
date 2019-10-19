using ProCP.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCP
{
    public class SimulationSettings: ISimulationSettings
    {
        public PrimarySecuritySettings Pss { get; set; }
        public SimulationSettings()
        {
            Pss = new PrimarySecuritySettings();
        }
    }

    public class PrimarySecuritySettings : IPrimarySecuritySettings
    {
        public double PercentageFailedBags { get; set; }
        public int ProcessingSpeed { get; set; } = 1000;
    }
}
