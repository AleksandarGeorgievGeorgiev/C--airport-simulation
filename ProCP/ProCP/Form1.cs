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
        private Grid _grid;
        BuildType buildType;
        public Form1()
        {
            InitializeComponent();
            _engine = new Engine();
            _simulationSettings = new SimulationSettings();
            _timer = new System.Windows.Forms.Timer();
            _timer.Tick += _timer_Tick;
            _timer.Interval = 5000;
            _grid = new Grid(animationBox.Width, animationBox.Height, _simulationSettings);
            gbFlightInfo.Visible = false;
            gbSettings.Visible = false;
            MapImportExportgroupBox.Visible = false;
            gbStartStop.Visible = false;
            //create flight
            //var flight = new Flight()
            //{
            //    BaggageCount = 20,
            //    DipartureTime = new TimeSpan(5, 45, 00),
            //    FlightNumber = "34353",
            //};

            //_simulationSettings.Flights.Add(flight);

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

            //pie chart
            pieChartBagsSecurity.Series.Add(new PieSeries() { Title = "Succeeded", Values = new ChartValues<int> { 30 }, DataLabels = true });
            pieChartBagsSecurity.Series.Add(new PieSeries() { Title = "Failed", Values = new ChartValues<int> { 20 }, DataLabels = true });
            pieChartBagsSecurity.LegendLocation = LegendLocation.Right;

            //adding series will update and animate the chart automatically
            //also adding values updates and animates the chart automatically
            //primariySecurityChart.Series[1].Values.Add(12d);

            SetupGeneralStatsTable();

            ///Mda has to be created first
            btnCheckin.Enabled = false;
            btnDropoff.Enabled = false;
            btnConveyor.Enabled = false;
            btnSecurity.Enabled = false;
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
            pieChartBagsSecurity.LegendLocation = LegendLocation.Right;

            //column chart
            foreach (var flight in data.BagsPerFlight)
            {
                PrimarySecurityChart.Series.Add(new ColumnSeries() { Title = "Flight number " + flight.Key, Values = new ChartValues<int> { flight.Value } });
            }

            //cartesian chart
            foreach (var flight in data.ElapsedTimesPerFlight)
            {
                cartesianChart1.Series.Add(new ColumnSeries() { Title = "Flight number " + flight.Key, Values = new ChartValues<int> { int.Parse(flight.Value) } });
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

            string[] row0 = { data.SimulationTimeElapsed, Baggage.AllBaggage.Count().ToString(), _simulationSettings.Flights.Count().ToString() };

            generalStatsTable.Rows.Add(row0);
            generalStatsTable.Columns[0].DisplayIndex = 0;
        }


        private void animationBox_Paint_1(object sender, PaintEventArgs e)
        {
            _grid.DrawGrid(e);
        }

        //inform about drawing component fail or not
        public void DrawAndConnectComponentHelper(GridTile t, GridTile selectedTile)
        {
            if (!this._grid.ConnectingComponentValidaion(t, selectedTile))
            {
                MessageBox.Show("Cant draw a component here");
                return;
            }
            this._grid.ConnectTile(t);
        }

        private void animationBox_MouseDown(object sender, MouseEventArgs e)
        {
            //for drawing the checkins, drop-off, mda,...
            GridTile t = this._grid.FindTileInPixelCoordinates(e.X, e.Y);
            GridTile currentTile;
            if (this.buildType == BuildType.CheckIn)
            {
                currentTile = new CheckInTile(t.Column, t.Row, this._grid.GetTileWidth(), this._grid.GetTileHeight());
                this.DrawAndConnectComponentHelper(currentTile, t);
            }
            else if (this.buildType == BuildType.Conveyor)
            {
                currentTile = new ConveyorTile(t.Column, t.Row, this._grid.GetTileWidth(), this._grid.GetTileHeight());
                this.DrawAndConnectComponentHelper(currentTile, t);
            }
            else if (this.buildType == BuildType.Mda)
            {
                //mda later on
                currentTile = new MDATile(t.Column, t.Row, this._grid.GetTileWidth(), this._grid.GetTileHeight());
                this.DrawAndConnectComponentHelper(currentTile, t);
                //enable other component
                btnCheckin.Enabled = true;
                btnConveyor.Enabled = true;
                btnDropoff.Enabled = true;
                btnSecurity.Enabled = true;
            }
            else if (this.buildType == BuildType.Security)
            {
                currentTile = new SecurityTile(t.Column, t.Row, this._grid.GetTileWidth(), this._grid.GetTileHeight());
                this.DrawAndConnectComponentHelper(currentTile, t);
            }
            else if (this.buildType == BuildType.DropOff)
            {
                currentTile = new DropOffTile(t.Column, t.Row, this._grid.GetTileWidth(), this._grid.GetTileHeight());
                this.DrawAndConnectComponentHelper(currentTile, t);
                if (currentTile.NextTiles != null)
                {
                    gbFlightInfo.Visible = true;
                    MapImportExportgroupBox.Visible = true;
                }
            }

            //redraw the grid
            this.animationBox.Invalidate();
        }

        private void btnCheckin_Click(object sender, EventArgs e)
        {
            this.buildType = BuildType.CheckIn;
        }

        private void btnDropoff_Click(object sender, EventArgs e)
        {
            this.buildType = BuildType.DropOff;
        }

        private void btnConveyor_Click(object sender, EventArgs e)
        {
            this.buildType = BuildType.Conveyor;
        }

        private void btnSecurity_Click(object sender, EventArgs e)
        {
            this.buildType = BuildType.Security;
        }

        private void btnMain_Click(object sender, EventArgs e)
        {
            this.buildType = BuildType.Mda;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // if the number of currently made flights is bigger than the number of currently created checkins just return and show a message 
            // else create flights

            var checkinTiles = _simulationSettings.FrontNodes.Where(n => n is CheckInTile);

            var newFlight = new Flight()
            {
                BaggageCount = int.Parse(textBoxNumberOfBags.Text),
                DipartureTime = new TimeSpan(departureTime.Value.Ticks),
                FlightNumber = textBoxFlightNumber.Text,
            };

            if (_simulationSettings.Flights.Any(f => f.FlightNumber == newFlight.FlightNumber))
            {
                MessageBox.Show("This flight already exists");
                return;
            }

            _simulationSettings.Flights.Add(newFlight);

            if (checkinTiles.Count() < _simulationSettings.Flights.Count())
            {
                _simulationSettings.Flights.Remove(newFlight);
                MessageBox.Show("You exceeded the number of flights. Create more checkins and dropoffs");
                return;
            }

            lbFlights.Items.Add("Flight number: " + newFlight.FlightNumber.ToString());

            if (_simulationSettings.Flights.Count() == 1)
            {
                gbSettings.Visible = true;
                gbStartStop.Visible = true;
            }
            //List<GridTile> temp = this._grid.CheckTheConnection();
            //foreach(var tile in temp)
            //{
            //    var t = tile;
            //    while(t != null)
            //    {
            //        MessageBox.Show("current Id: " + t.NodeId + " Type: " + t.GetType().ToString() + " next node id: " + t.NextTiles[0].NodeId);
            //        t = t.NextTiles[0];
            //    }
            //}
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var selectedFlightNumber = lbFlights.SelectedItem.ToString().Split(' ')[2];
            var flight = _simulationSettings.Flights.FirstOrDefault(f => f.FlightNumber == selectedFlightNumber);
            if (selectedFlightNumber != null)
            {
                lbFlights.Items.Remove(flight);
                _simulationSettings.Flights.Remove(flight);

                foreach (var existingflight in _simulationSettings.Flights)
                {
                    lbFlights.Items.Add("Flight number: " + existingflight.FlightNumber.ToString());
                };
            }
            else
            {
                MessageBox.Show("First select a flight");
            }



            //List<GridTile> temp = this._grid.CheckTheConnection();
            //foreach (var tile in temp)
            //{
            //    var t = tile;
            //    while (t != null)
            //    {
            //        if(t is MDATile m)
            //        {
            //            //some problem in the constructor that might cause the mdatile to connect to itself
            //            MessageBox.Show(m.NextTiles.Count.ToString() + " type 1: " + m.NextTiles[0].GetType().ToString() + " type2: " + m.NextTiles[1].GetType().ToString());
            //            break;
            //        }
            //        t = t.NextTiles[0];
            //    }
            //}
        }
    }
}