﻿using LiveCharts;
using LiveCharts.Wpf;
using ProCP.Data;
using ProCP.FlightAndBaggage;
using ProCP.Services;
using ProCP.Visuals;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
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
        IData readAndWrite;
        public Form1()
        {
            InitializeComponent();
            _engine = new Engine();
            _simulationSettings = new SimulationSettings();
            _timer = new System.Windows.Forms.Timer();
            _timer.Tick += _timer_Tick;
            _timer.Interval = 5000;
            _grid = new Grid(animationBox.Width, animationBox.Height, _simulationSettings);
            gbFlightInfo.Enabled = false;
            gbSettings.Enabled = false;
            gbStartStop.Enabled = false;
            departureTimePicker.Value = DateTime.Now;
            departureTimePicker.Format = DateTimePickerFormat.Time;
            departureTimePicker.ShowUpDown = true;

            cartesianChart1.DataClick += CartesianChart1OnDataClick;


            pieChartBagsSecurity.Series.Add(new PieSeries() { Title = "Succeeded", Values = new ChartValues<int> { 30 }, DataLabels = true });
            pieChartBagsSecurity.Series.Add(new PieSeries() { Title = "Failed", Values = new ChartValues<int> { 20 }, DataLabels = true });

            PrePopulateCharts();

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

        public void PrePopulateCharts()
        {
            cartesianChart1.Series.Add(new ColumnSeries() { Title = "Flight number: RA123", Values = new ChartValues<int> { 20 }, DataLabels = true });
            PrimarySecurityChart.Series.Add(new ColumnSeries() { Title = "drop off number: 85", Values = new ChartValues<int> { 100 }, DataLabels = true });
            cartesianChartSuccBagsPerFlight.Series.Add(new ColumnSeries() { Title = "flight number: RA123", Values = new ChartValues<int> { 100 }, DataLabels = true });
            cartesianChartFailedBagsPerFlight.Series.Add(new ColumnSeries() { Title = "flight number: RA123", Values = new ChartValues<int> { 10 }, DataLabels = true });
        }

        private void CartesianChart1OnDataClick(object sender, ChartPoint chartPoint)
        {
            MessageBox.Show("You clicked (" + chartPoint.X + "," + chartPoint.Y + ")");
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            _engine.Run(_simulationSettings);
            _timer.Start();
            btnCheckin.Enabled = false;
            btnConveyor.Enabled = false;
            btnDropoff.Enabled = false;
            btnSecurity.Enabled = false;
            gbSettings.Enabled = false;
            gbFlightInfo.Enabled = false;
            MapImportExportgroupBox.Enabled = false;
        }

        private void StatisticsChartData(StatisticsData data)
        {
            //clean charts
            pieChartBagsSecurity.Series.Clear();
            PrimarySecurityChart.Series.Clear();
            cartesianChart1.Series.Clear();
            cartesianChartSuccBagsPerFlight.Series.Clear();
            cartesianChartFailedBagsPerFlight.Series.Clear();

            //pie chart
            pieChartBagsSecurity.Series.Add(new PieSeries() { Title = "Succeeded", Values = new ChartValues<int> { data.BagsSucceededPsc.Count }, DataLabels = true });
            pieChartBagsSecurity.Series.Add(new PieSeries() { Title = "Failed", Values = new ChartValues<int> { data.BagsFailedPsc.Count }, DataLabels = true });
            pieChartBagsSecurity.LegendLocation = LegendLocation.Right;

            //column chart bags per dropOff
            foreach (var flight in data.BagsPerFlight)
            {
                PrimarySecurityChart.Series.Add(new ColumnSeries() { Title = "DropOff number " + flight.Key, Values = new ChartValues<int> { flight.Value } });
            }

            //cartesian chart elapsed times per flight
            foreach (var flight in data.ElapsedTimesPerFlight)
            {
                cartesianChart1.Series.Add(new ColumnSeries() { Title = "Flight number " + flight.Key, Values = new ChartValues<int> { int.Parse(flight.Value) } });
            }

            foreach (var flight in data.PscSucceededBagsPerFlight)
            {
                cartesianChartSuccBagsPerFlight.Series.Add(new ColumnSeries() { Title = "Flight number " + flight.Key, Values = new ChartValues<int> { flight.Value } });
            }

            foreach (var flight in data.PscFailedBagsPerFlight)
            {
                cartesianChartFailedBagsPerFlight.Series.Add(new ColumnSeries() { Title = "Flight number " + flight.Key, Values = new ChartValues<int> { flight.Value } });
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
            var simulationElapsedTime = "0";
            if (data.SimulationTimeElapsed != null)
            {
                simulationElapsedTime = data.SimulationTimeElapsed.Max().ToString();
            }

            string[] row0 = { simulationElapsedTime, Baggage.AllBaggage.Count().ToString(), _simulationSettings.Flights.Count().ToString() };
            generalStatsTable.Rows.Add(row0);
            generalStatsTable.Columns[0].DisplayIndex = 0;
        }

        private void animationBox_Paint_1(object sender, PaintEventArgs e)
        {
            _grid.DrawGrid(e);
        }

        //inform about drawing component fail or not
        public void ConnectComponentHelper(GridTile t, GridTile selectedTile)
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
                this.ConnectComponentHelper(currentTile, t);
            }
            else if (this.buildType == BuildType.Conveyor)
            {
                currentTile = new ConveyorTile(t.Column, t.Row, this._grid.GetTileWidth(), this._grid.GetTileHeight());
                this.ConnectComponentHelper(currentTile, t);
            }
            else if (this.buildType == BuildType.Mda)
            {
                //mda later on
                currentTile = new MDATile(t.Column, t.Row, this._grid.GetTileWidth(), this._grid.GetTileHeight());
                this.ConnectComponentHelper(currentTile, t);
                //enable other component
                btnCheckin.Enabled = true;
                btnConveyor.Enabled = true;
                btnDropoff.Enabled = true;
                btnSecurity.Enabled = true;
            }
            else if (this.buildType == BuildType.Security)
            {
                currentTile = new SecurityTile(t.Column, t.Row, this._grid.GetTileWidth(), this._grid.GetTileHeight());
                this.ConnectComponentHelper(currentTile, t);
            }
            else if (this.buildType == BuildType.DropOff)
            {
                currentTile = new DropOffTile(t.Column, t.Row, this._grid.GetTileWidth(), this._grid.GetTileHeight());
                this.ConnectComponentHelper(currentTile, t);
                if (currentTile.NextTiles != null)
                {
                    gbSettings.Enabled = true;
                    gbFlightInfo.Enabled = true;
                    MapImportExportgroupBox.Enabled = true;
                    comboBoxCurrentDropOffs.Items.Add(currentTile.NodeId.ToString());
                }
            }
            else if (this.buildType == BuildType.Delete)
            {
                this._grid.DeleteNode(t);
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
            if (String.IsNullOrEmpty(textBoxFlightNumber.Text) || String.IsNullOrEmpty(textBoxNumberOfBags.Text))
            {
                MessageBox.Show("Fill in all the required fields!");
                return;
            }
            if (comboBoxCurrentDropOffs.SelectedItem == null)
            {
                MessageBox.Show("Gate selection is necessary!");
                return;
            }

            var checkinTiles = _simulationSettings.FrontNodes.Where(n => n is CheckInTile);

            var newFlight = new Flight()
            {
                BaggageCount = int.Parse(textBoxNumberOfBags.Text),
                DipartureTime = departureTimePicker.Value,
                FlightNumber = textBoxFlightNumber.Text,
                DropoffId = comboBoxCurrentDropOffs.SelectedItem.ToString()
            };

            if (_simulationSettings.Flights.Any(f => f.FlightNumber == newFlight.FlightNumber))
            {
                MessageBox.Show("This flight already exists");
                return;
            }

            _simulationSettings.Flights.Add(newFlight);


            lbFlights.Items.Add("Flight number: " + newFlight.FlightNumber.ToString());

            if (_simulationSettings.Flights.Count() == 1)
            {
                gbStartStop.Enabled = true;
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
                lbFlights.Items.Remove(lbFlights.SelectedItem);
            }
            else
            {
                MessageBox.Show("First select a flight");
            }
        }

        private void cartesianChart1_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<GridTile> temp = this._grid.CheckTheConnection();
            foreach (var tile in temp)
            {
                var t = tile;
                while (t != null)
                {
                    MessageBox.Show("current Id: " + t.NodeId + " Type: " + t.GetType().ToString() + " next node id: " + t.NextTiles[0].NodeId);
                    t = t.NextTiles[0];
                    if (t is DropOffTile)
                    {
                        MessageBox.Show("current Id: " + t.NodeId + " Type: " + t.GetType().ToString());
                        break;
                    }
                }
            }
        }

        private void buttonImport_Click(object sender, EventArgs e)
        {

            btnCheckin.Enabled = true;
            btnDropoff.Enabled = true;
            btnConveyor.Enabled = true;
            btnSecurity.Enabled = true;
            string filePath = "";
            if (!this.ImportExportHelper(ref filePath, ref readAndWrite))
            {
                MessageBox.Show("Choose file");
                return;
            }
            this._grid = readAndWrite.ReadData(filePath);
            this._simulationSettings.FrontNodes = _grid.CheckTheConnection();
            this.FindDropOffsAfterGridImport(_simulationSettings.FrontNodes);
            this.animationBox.Invalidate();
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            string filePath = "";
            if (!this.ImportExportHelper(ref filePath, ref readAndWrite))
            {
                MessageBox.Show("Choose file");
                return;
            }
            readAndWrite.WriteData(filePath, this._grid);
        }

        public bool ImportExportHelper(ref string filePath, ref IData readAndWrite)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog1.FileName;
                readAndWrite = new ReadFromImageFile();
                gbFlightInfo.Enabled = true;
                gbSettings.Enabled = true;
                gbStartStop.Enabled = true;
                return true;
            }
            return false;
        }

        public void FindDropOffsAfterGridImport(List<GridTile> tiles)
        {
            foreach (var tile in tiles)
            {
                if (tile is DropOffTile)
                {
                    if (!comboBoxCurrentDropOffs.Items.Contains(tile.NodeId.ToString()))
                    {
                        comboBoxCurrentDropOffs.Items.Add(tile.NodeId.ToString());
                    }
                }

                FindDropOffsAfterGridImport(tile.NextTiles);
            }
        }

        private void buttonDeleteTile_Click(object sender, EventArgs e)
        {
            this.buildType = BuildType.Delete;
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("This action will reset everything! Do you want to save you statistics ?", "Export Statistics", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                _engine.WriteStatsToCsv(_simulationSettings, dataStats);
            }

            _engine.Stop();
            _timer.Stop();
            textBoxFlightNumber.Text = "";
            textBoxNumberOfBags.Text = "";
            comboBoxCurrentDropOffs.SelectedItem = null;
            lbFlights.Items.Clear();
            _grid.gridTiles.Clear();
            _grid = new Grid(animationBox.Width, animationBox.Height, _simulationSettings);
            //dataStats.ElapsedTimesPerFlight.Clear();
            //dataStats.SimulationTimeElapsed = "";
            //dataStats.TotalBagsTransfered.Clear();
            //dataStats.PscSucceededBagsPerFlight.Clear();
            //dataStats.PscFailedBagsPerFlight.Clear();
            //dataStats.BagsFailedPsc.Clear();
            //dataStats.BagsSucceededPsc.Clear();
            //dataStats.BagsPerFlight.Clear();
            Baggage.AllBaggage = new System.Collections.Concurrent.ConcurrentBag<Baggage>();
            _simulationSettings.FrontNodes.Clear();
            _simulationSettings.Flights.Clear();
            gbStartStop.Enabled = false;
            btnMain.Enabled = true;
            MapImportExportgroupBox.Enabled = true;
            animationBox.Invalidate();


            //clear stats
            pieChartBagsSecurity.Series.Clear();
            PrimarySecurityChart.Series.Clear();
            cartesianChart1.Series.Clear();
            cartesianChartSuccBagsPerFlight.Series.Clear();
            cartesianChartFailedBagsPerFlight.Series.Clear();
        }

        private void BtnSpeed1_Click(object sender, EventArgs e)
        {
            _simulationSettings.Cs.Speed = 1000;
        }

        private void BtnSpeed2_Click(object sender, EventArgs e)
        {
            _simulationSettings.Cs.Speed = 800;
        }

        private void BtnSpeed3_Click(object sender, EventArgs e)
        {
            _simulationSettings.Cs.Speed = 600;
        }

        private void BtnSpeed4_Click(object sender, EventArgs e)
        {
            _simulationSettings.Cs.Speed = 400;
        }

        private void CmbEmployees_SelectedIndexChanged(object sender, EventArgs e)
        {
            _simulationSettings.DropOffSettings.NumberOfWorker = Convert.ToInt32(cmbEmployees.SelectedItem.ToString());
        }
    }
}