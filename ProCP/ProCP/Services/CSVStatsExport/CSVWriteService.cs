using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProCP.Services.CSVStatsExport
{
    public class CSVWriteService : ICSVWriteService
    {
        private CSVExportModel _exportModel;
        private List<CSVExportModel> _objectsToExport;

        public CSVWriteService()
        {
            _objectsToExport = new List<CSVExportModel>();
        }

        private void CreateCsvExportMode(SimulationSettings settings)
        {

            foreach (var flight in settings.Flights)
            {
                _exportModel = new CSVExportModel();
                _exportModel.FlightNumber = flight.FlightNumber;
                _exportModel.TotalBags = flight.BaggageCount;
                _exportModel.ConveyorsSpeed = (int)settings.Cs.Speed;
                _exportModel.DropoffsWorkers = settings.DropOffSettings.NumberOfWorker;
                _exportModel.TotalNumberOfCheckins = settings.FrontNodes.Count();
                _objectsToExport.Add(_exportModel);
            }
        }

        private void AppendCsvInformationWithStats(StatisticsData data)
        {
            foreach (var item in data.ElapsedTimesPerFlight)
            {
                var flightToExport = _objectsToExport.FirstOrDefault(f => f.FlightNumber == item.Key);

                flightToExport.TimeElapsed = item.Value;
            }

            foreach (var item in data.PscSucceededBagsPerFlight)
            {
                var flightToExport = _objectsToExport.FirstOrDefault(f => f.FlightNumber == item.Key);

                flightToExport.SucceededBags = item.Value;
            }

            foreach (var item in data.PscFailedBagsPerFlight)
            {
                var flightToExport = _objectsToExport.FirstOrDefault(f => f.FlightNumber == item.Key);

                flightToExport.FailedBags = item.Value;
            }
        }

        public void WriteToCSV(SimulationSettings settings, StatisticsData data)
        {
            CreateCsvExportMode(settings);
            AppendCsvInformationWithStats(data);

            SaveFileDialog sfd = new SaveFileDialog();
            try
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (var writer = new StreamWriter(sfd.FileName))
                    {
                        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                        {
                            csv.WriteRecords(_objectsToExport);
                        }
                    }
                }
            }
            catch (IOException ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
