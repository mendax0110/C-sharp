using System;
using System.Windows;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;

namespace VoltageDivBiTransistor
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            double voltage, resistor1, resistor2, beta;
            if (double.TryParse(VoltageInput.Text, out voltage) &&
                double.TryParse(Resistor1Input.Text, out resistor1) &&
                double.TryParse(Resistor2Input.Text, out resistor2) &&
                double.TryParse(BetaInput.Text, out beta))
            {
                double totalResistance = resistor1 + resistor2;
                double current = voltage / totalResistance;
                double voltageAtEmitter = current * resistor1;
                double voltageAtCollector = voltage - voltageAtEmitter;
                double collectorCurrent = beta * current;
                double voltageAtLoad = collectorCurrent * resistor2;

                // Create data points for the voltage divider
                var voltageDividerPoints = new DataPoint[]
                {
                    new DataPoint(0, voltage),
                    new DataPoint(1, voltageAtCollector),
                    new DataPoint(2, 0)
                };

                // Create data points for the bipolar transistor
                var bipolarTransistorPoints = new DataPoint[]
                {
                    new DataPoint(0, voltage),
                    new DataPoint(1, voltageAtEmitter),
                    new DataPoint(2, voltageAtCollector),
                    new DataPoint(3, voltageAtLoad),
                    new DataPoint(4, 0)
                };

                // Create a new plot model and series
                var plotModel = new PlotModel { Title = "Voltage Divider with Bipolar Transistor" };
                var voltageDividerSeries = new LineSeries { Title = "Voltage Divider" };
                var bipolarTransistorSeries = new LineSeries { Title = "Bipolar Transistor" };

                // Add the data points to the series
                voltageDividerSeries.Points.AddRange(voltageDividerPoints);
                bipolarTransistorSeries.Points.AddRange(bipolarTransistorPoints);

                // Add the series to the plot model
                plotModel.Series.Add(voltageDividerSeries);
                plotModel.Series.Add(bipolarTransistorSeries);

                // Set the x-axis and y-axis titles
                plotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, Title = "Time (s)" });
                plotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Title = "Voltage (V)" });

                // Set the plot model as the data context for the plot control
                DataContext.Equals(plotModel);
            }
            else
            {
                MessageBox.Show("Invalid input values. Please enter valid numbers.");
            }
        }
    }
}
