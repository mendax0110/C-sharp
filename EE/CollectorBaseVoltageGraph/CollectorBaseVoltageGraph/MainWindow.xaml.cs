using System;
using System.Collections.Generic;
using System.Windows;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;

namespace CollectorBaseVoltageGraph
{
    public partial class MainWindow : Window
    {
        private PlotModel plotModel;

        public MainWindow()
        {
            InitializeComponent();

            plotModel = new PlotModel { Title = "Collector-Base Voltage Graph" };
            plotView.Model = plotModel;

            // Set up the X-axis for the graph
            plotModel.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Bottom,
                Title = "Voltage (V)"
            });

            // Set up the Y-axis for the graph
            plotModel.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Left,
                Title = "Current (mA)"
            });
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            // Retrieve the collector and base voltages from the UI
            double collectorVoltage = double.Parse(CollectorTextBox.Text);
            double baseVoltage = double.Parse(BaseTextBox.Text);

            // Calculate the resulting voltages and currents
            List<DataPoint> dcPoints = new List<DataPoint>();
            List<DataPoint> acPoints = new List<DataPoint>();
            double iC, iC_AC, iC_DC, vCE;
            for (vCE = 0; vCE <= 10; vCE += 0.1)
            {
                iC_DC = CalculateCurrent(collectorVoltage, baseVoltage, vCE, out iC_AC);
                dcPoints.Add(new DataPoint(vCE, iC_DC));
                acPoints.Add(new DataPoint(vCE, iC_AC));
            }

            // Add the resulting voltages and currents to the graph
            plotModel.Series.Clear();
            var dcSeries = new LineSeries
            {
                Title = "DC",
                Color = OxyColors.Blue,
                StrokeThickness = 1,
                MarkerSize = 1,
                MarkerStroke = OxyColors.Blue,
                MarkerType = MarkerType.None,
            };
            dcSeries.Points.AddRange(dcPoints);
            plotModel.Series.Add(dcSeries);

            var acSeries = new LineSeries
            {
                Title = "AC",
                Color = OxyColors.Red,
                StrokeThickness = 1,
                MarkerSize = 1,
                MarkerStroke = OxyColors.Red,
                MarkerType = MarkerType.None,
            };
            acSeries.Points.AddRange(acPoints);
            plotModel.Series.Add(acSeries);

            plotModel.InvalidatePlot(true);
        }

        private double CalculateCurrent(double Vc, double Vb, double Vce, out double iC_AC)
        {
            double iC, iC_sat;
            double beta = 100;
            double Vbe = 0.7;
            double Vt = 0.025;
            double R1 = 2200;
            double R2 = 6800;
            double RC = 1000;
            double RE = 220;
            double RL = 4700;
            double Vin = 10;

            // Calculate the DC current through the transistor
            iC = (Vin - Vb - Vbe) / ((R1 / (R1 + R2)) * (1 + beta) * RE + RC);
            if (iC < 0) iC = 0;

            // Calculate the AC current through the transistor
            iC_AC = iC * Math.Sin(2 * Math.PI * 100 * Vce);

            return iC_AC;
        }
    }
}
