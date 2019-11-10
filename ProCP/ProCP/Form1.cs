using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Controls;
using System.Windows.Media;
using LiveCharts;
using LiveCharts.Wpf;
using Brushes = System.Windows.Media.Brushes;
using ProCP.FlightAndBaggage;
using ProCP.Services;

namespace ProCP
{
    public partial class Form1 : Form
    {
        private Engine _engine;
        private SimulationSettings _simulationSettings;
        private Timer _timer;
        private StatisticsData dataStats = new StatisticsData();
        public Form1()
        {
            InitializeComponent();
            _engine = new Engine();
            _simulationSettings = new SimulationSettings();
            _timer = new System.Windows.Forms.Timer();
            _timer.Tick += _timer_Tick;
            _timer.Interval = 5000;

            //create flight
            var flight = new Flight()
            {
                BaggageCount = 20,
                DipartureTime = new TimeSpan(5, 45, 00),
                FlightNumber = "test 1",
            };

            _simulationSettings.Flights.Add(flight);

            //
            cartesianChart1.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Time",
                    Values = new ChartValues<int> {10, 25, 55, 45, 60},
                    PointGeometry = DefaultGeometries.Circle,
                    PointGeometrySize = 15
                }
            };

            cartesianChart1.AxisX.Add(new Axis
            {
                Title = "Flight Number",
                Labels = new[] { "Flight to Miami", "Flight to Chicago", "Flight to Eindhoven", "Flight to Seattle", "Flight to Cologne" },
                Height = 12
            });

            cartesianChart1.AxisY.Add(new Axis
            {
                Title = "Transfer Time",
                LabelFormatter = value => value.ToString()
            });

            cartesianChart1.LegendLocation = LegendLocation.Right;

            //modifying any series values will also animate and update the chart


            cartesianChart1.DataClick += CartesianChart1OnDataClick;

            //adding series will update and animate the chart automatically
            //also adding values updates and animates the chart automatically
            //primariySecurityChart.Series[1].Values.Add(12d);
        }

        private void _timer_Tick(object sender, EventArgs e)
        {
            var calculator = _engine.GetStatisticsCalculator();
            dataStats = calculator();

            StatisticsChartData(dataStats);
        }

        private void CartesianChart1OnDataClick(object sender, ChartPoint chartPoint)
        {
            MessageBox.Show("You clicked (" + chartPoint.X + "," + chartPoint.Y + ")");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            FormBorderStyle = FormBorderStyle.Sizable;
            WindowState = FormWindowState.Maximized;
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void cartesianChart2_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            _engine.RunDemo(_simulationSettings);
            _timer.Start();
        }

        private void StatisticsChartData(StatisticsData data)
        {
            //clean charts
            pieChartBagsSecurity.Series.Clear();
            PrimarySecurityChart.Series.Clear();




            //pie chart
            pieChartBagsSecurity.Series.Add(new PieSeries() { Title = "Succeeded", Values = new ChartValues<int> { data.BagsSucceededPsc.Count }, DataLabels = true });
            pieChartBagsSecurity.Series.Add(new PieSeries() { Title = "Failed", Values = new ChartValues<int> { data.BagsFailedPsc.Count }, DataLabels = true });

            //column chart
            foreach (var flight in data.BagsPerFlight)
            {
                PrimarySecurityChart.Series.Add(new ColumnSeries() { Title = flight.Key, Values = new ChartValues<int> { flight.Value }, DataLabels = true } );
            }
        }
    }
}