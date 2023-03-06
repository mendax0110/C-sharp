using System;
using System.Windows;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;

namespace EmitterCircuitCalculator
{
    public partial class MainWindow : Window
    {
        private PlotModel plotModel;

        public MainWindow()
        {
            InitializeComponent();

            // Set up the plot model
            plotModel = new PlotModel();
            plotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Title = "Voltage (V)" });
            plotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, Title = "Current (A)" });
            plotModel.Series.Add(new LineSeries { Title = "Collector Voltage", Color = OxyColors.Blue });
            plotModel.Series.Add(new LineSeries { Title = "Emitter Voltage", Color = OxyColors.Red });
            plotModel.Series.Add(new LineSeries { Title = "Collector Current", Color = OxyColors.Green });
            plotModel.Series.Add(new LineSeries { Title = "Base Current", Color = OxyColors.Purple });

            // Set the plot as the DataContext for the plot control
            plot.DataContext = plotModel;
        }

        private void calculateButton_Click(object sender, RoutedEventArgs e)
        {
            // Get the input values
            double collectorVoltage = double.Parse(collectorVoltageTextBox.Text);
            double baseVoltage = double.Parse(baseVoltageTextBox.Text);
            double emitterResistor = double.Parse(emitterResistorTextBox.Text);

            // Calculate the output values for an emitter circuit
            double emitterVoltage = baseVoltage - collectorVoltage;
            double collectorCurrent = emitterVoltage / emitterResistor;
            double baseCurrent = collectorCurrent / (Math.Exp(emitterVoltage / (0.026 * 300)) - 1);

            // Update the plot data
            ((LineSeries)plotModel.Series[0]).Points.Clear();
            ((LineSeries)plotModel.Series[1]).Points.Clear();
            ((LineSeries)plotModel.Series[2]).Points.Clear();
            ((LineSeries)plotModel.Series[3]).Points.Clear();

            for (double i = 0; i <= collectorCurrent; i += 0.001)
            {
                double vC = i * emitterResistor;
                double vE = baseVoltage - emitterResistor * i;
                ((LineSeries)plotModel.Series[0]).Points.Add(new DataPoint(i, vC));
                ((LineSeries)plotModel.Series[1]).Points.Add(new DataPoint(i, vE));
                ((LineSeries)plotModel.Series[2]).Points.Add(new DataPoint(i, i));
                ((LineSeries)plotModel.Series[3]).Points.Add(new DataPoint(i, baseCurrent));
            }

            // Update the output values in the UI
            emitterVoltageTextBlock.Text = emitterVoltage.ToString("F2");
            collectorCurrentTextBlock.Text = collectorCurrent.ToString("F4");
            baseCurrentTextBlock.Text = baseCurrent.ToString("F4");

            // Refresh the plot
            plot.InvalidatePlot();
        }
    }
}
