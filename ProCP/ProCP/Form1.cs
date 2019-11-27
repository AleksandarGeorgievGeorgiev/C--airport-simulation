﻿using System;
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
using ProCP.Visuals;
using Grid = ProCP.Visuals.Grid;

namespace ProCP
{
    public partial class Form1 : Form
    {
        private Engine _engine;
        private SimulationSettings _simulationSettings;
        private Timer _timer;
        private StatisticsData dataStats = new StatisticsData();
        Grid theGrid;
        public Form1()
        {
            InitializeComponent();
            _engine = new Engine();
            _simulationSettings = new SimulationSettings();
            _timer = new System.Windows.Forms.Timer();
            _timer.Tick += _timer_Tick;
            _timer.Interval = 5000;
            theGrid = new Grid(animationBox.Width, animationBox.Height);
            //create flight
            var flight = new Flight()
            {
                BaggageCount = 20,
                DipartureTime = new TimeSpan(5, 45, 00),
                FlightNumber = "34353",
            };

            _simulationSettings.Flights.Add(flight);
            _simulationSettings.Flights.Add(new Flight()
            {
                BaggageCount = 20,
                DipartureTime = new TimeSpan(5, 55, 00),
                FlightNumber = "1234",
            });

            //
            cartesianChart1.Series.Add(new ColumnSeries() { Title = "2132", Values = new ChartValues<int> { 20 } });
            cartesianChart1.AxisY.Add(new Axis()
            {
                Title = "Time (min)"
            });
            cartesianChart1.AxisX.Add(new Axis()
            {
                Title = "Flight"
            });

            cartesianChart1.LegendLocation = LegendLocation.Right;

            //modifying any series values will also animate and update the chart


            cartesianChart1.DataClick += CartesianChart1OnDataClick;


            PrimarySecurityChart.Series.Add(new ColumnSeries() { Title = "85", Values = new ChartValues<int> { 20 } });
            PrimarySecurityChart.AxisY.Add(new Axis()
            {
                Title = "Baggage amount"
            });
            PrimarySecurityChart.AxisX.Add(new Axis()
            {
                Title = "Flight"
            });

            PrimarySecurityChart.LegendLocation = LegendLocation.Right;



            //adding series will update and animate the chart automatically
            //also adding values updates and animates the chart automatically
            //primariySecurityChart.Series[1].Values.Add(12d);

            SetupGeneralStatsTable();
        }

        private void _timer_Tick(object sender, EventArgs e)
        {
            var calculator = _engine.GetStatisticsCalculator();
            dataStats = calculator();

            StatisticsChartData(dataStats);
            PopulateTable(dataStats);
        }

        private void CartesianChart1OnDataClick(object sender, ChartPoint chartPoint)
        {
            MessageBox.Show("You clicked (" + chartPoint.X + "," + chartPoint.Y + ")");
        }

        private void Form1_Load(object sender, EventArgs e)
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
            cartesianChart1.Series.Clear();

            //pie chart
            pieChartBagsSecurity.Series.Add(new PieSeries() { Title = "Succeeded", Values = new ChartValues<int> { data.BagsSucceededPsc.Count }, DataLabels = true });
            pieChartBagsSecurity.Series.Add(new PieSeries() { Title = "Failed", Values = new ChartValues<int> { data.BagsFailedPsc.Count }, DataLabels = true });

            //column chart
            foreach (var flight in data.BagsPerFlight)
            {
                PrimarySecurityChart.Series.Add(new ColumnSeries() { Title = flight.Key, Values = new ChartValues<int> { flight.Value }} );
            }

            //cartesian chart
            foreach (var flight in data.ElapsedTimesPerFlight)
            {
                cartesianChart1.Series.Add(new ColumnSeries() { Title = flight.Key, Values = new ChartValues<int> { int.Parse(flight.Value)} });
            }
        }

        private void SetupGeneralStatsTable()
        {
            generalStatsTable.ColumnCount = 3;
            generalStatsTable.GridColor = System.Drawing.Color.Black;
            generalStatsTable.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            generalStatsTable.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            generalStatsTable.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;


            generalStatsTable.Columns[0].Name = "Simulation time elapsed";
            generalStatsTable.Columns[1].Name = "Total number of bags";
            generalStatsTable.Columns[2].Name = "Number of fligths";

            generalStatsTable.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            generalStatsTable.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            generalStatsTable.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void PopulateTable(StatisticsData data)
        {
            generalStatsTable.Rows.Clear();

            string[] row0 = { data.SimulationTimeElapsed, Baggage.AllBaggage.Count().ToString(), _simulationSettings.Flights.Count().ToString()};

            generalStatsTable.Rows.Add(row0);
            generalStatsTable.Columns[0].DisplayIndex = 0;
        }


        private void animationBox_Paint_1(object sender, PaintEventArgs e)
        {
            theGrid.DrawGrid(e);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureLogo_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void animationBox_Click(object sender, EventArgs e)
        {

        }
    }
}