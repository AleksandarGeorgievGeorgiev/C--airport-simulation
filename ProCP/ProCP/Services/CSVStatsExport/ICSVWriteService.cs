namespace ProCP.Services.CSVStatsExport
{
    public interface ICSVWriteService
    {
        void WriteToCSV(SimulationSettings settings, StatisticsData data);
    }
}