using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCP.Services.CSVStatsExport
{
    public class CSVExportModel
    {
        public string FlightNumber { get; set; }
        public int TotalBags { get; set; }
        public int SucceededBags { get; set; }
        public int FailedBags { get; set; }
        public string TimeElapsed { get; set; }
        public int TotalNumberOfCheckins { get; set; }
        public int DropoffsWorkers { get; set; }
        public int ConveyorsSpeed { get; set; }
    }
}
