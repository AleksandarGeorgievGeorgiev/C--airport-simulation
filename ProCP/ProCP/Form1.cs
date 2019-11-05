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
using System.Timers;
using LiveCharts.Wpf;
using Brushes = System.Windows.Media.Brushes;

namespace ProCP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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



            //////////////////Primary Security////////////////////////
            primariySecurityChart.Series = new SeriesCollection
            {
                new ColumnSeries
                {
                Title = "Number Baggages",

                    Values = new ChartValues<double> { 10, 10, 13, 29 }
                }
            };

            //adding series will update and animate the chart automatically
            primariySecurityChart.Series.Add(new ColumnSeries
            {
                Title = "Number of Security Police",
                Values = new ChartValues<double> { 2, 2, 5, 5 }
            });

            //also adding values updates and animates the chart automatically
            //primariySecurityChart.Series[1].Values.Add(12d);

            primariySecurityChart.AxisX.Add(new Axis
            {
                Title = "Security Check",
                Labels = new[] { "Gate1", "Gate2", "Gate3", "Gate4" }
            });

            primariySecurityChart.AxisY.Add(new Axis
            {
                Title = "Time",
                LabelFormatter = value => value.ToString("N")
            });
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

        private void cartesianChart1_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }
    }
}