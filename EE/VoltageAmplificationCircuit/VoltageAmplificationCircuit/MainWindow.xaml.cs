using System;
using System.Collections.Generic;
using System.Windows;
using OxyPlot;
using OxyPlot.Series;

namespace VoltageAmplificationCircuit
{
    public partial class MainWindow : Window
    {
        private const double R1 = 10000;
        private const double R2 = 10000;
        private const double Vcc = 12;
        private const double Vbe = 0.7;
        private const double Hfe = 100;

        public MainWindow()
        {
            InitializeComponent();
        }

        // handler for the calculate butten
        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            double inputVoltage;

            if (!double.TryParse(InputVoltageTextBox.Text, out inputVoltage))
            {
                MessageBox.Show("Invalid input voltage!");
                return;
            }

            double outputVoltage = CalculateOutputVoltage(inputVoltage);
            VoltageSeries.ItemsSource = GenerateDataPoints(inputVoltage, outputVoltage);
        }

        // handler for the calculation of the voltage
        private double CalculateOutputVoltage(double inputVoltage)
        {
            double baseVoltage = inputVoltage * R2 / (R1 + R2);
            double collectorVoltage = Vcc - (Hfe + 1) * baseVoltage - Vbe;
            return collectorVoltage;
        }

        // handler for generating the datapoints on the graph
        private IEnumerable<DataPoint> GenerateDataPoints(double inputVoltage, double outputVoltage)
        {
            const int numPoints = 100;
            const double delta = 0.1;

            List<DataPoint> dataPoints = new List<DataPoint>();

            for (int i = 0; i < numPoints; i++)
            {
                double v = inputVoltage - delta * numPoints / 2 + i * delta;
                double vo = CalculateOutputVoltage(v);
                dataPoints.Add(new DataPoint(v, vo));
            }

            return dataPoints;
        }
    }
}
