using System;
using System.Windows;
using System.Windows.Controls;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.Wpf;

namespace SwitchSimulator
{
    public partial class MainWindow : Window
    {
        // This method is called when the window is created.
        public MainWindow()
        {
            InitializeComponent();
        }

        // This method is called when the user clicks the Switch button.
        private void SwitchButton_Click(object sender, RoutedEventArgs e)
        {
            // Read the input voltage from the text box.
            double inputVoltage = double.Parse(InputVoltageTextBox.Text);
            double outputVoltage = CalculateOutputVoltage(inputVoltage);
            OutputVoltageTextBox.Text = outputVoltage.ToString();

            // Create a plot model.
            PlotModel plotModel = new PlotModel();
            plotModel.Title = "Voltage Graph";

            LinearAxis xAxis = new LinearAxis();
            xAxis.Position = AxisPosition.Bottom;
            xAxis.Title = "Time (ms)";
            plotModel.Axes.Add(xAxis);

            LinearAxis yAxis = new LinearAxis();
            yAxis.Position = AxisPosition.Left;
            yAxis.Title = "Voltage (V)";
            plotModel.Axes.Add(yAxis);

            LineSeries lineSeries = new LineSeries();
            lineSeries.Title = "Output Voltage";
            lineSeries.Color = OxyColors.Blue;

            // Add points to the line series.
            for (int i = 0; i <= 360; i += 10)
            {
                double time = i / 10.0;
                double voltage = CalculateOutputVoltage(Math.Sin(i * Math.PI / 180.0) * inputVoltage);
                lineSeries.Points.Add(new DataPoint(time, voltage));
            }

            // Add the line series to the plot model.
            plotModel.Series.Add(lineSeries);

            PlotView plotView = new PlotView();
            plotView.Model = plotModel;
            GraphGrid.Children.Clear();
            GraphGrid.Children.Add(plotView);
        }

        // This method calculates the output voltage.
        private double CalculateOutputVoltage(double inputVoltage)
        {
            double beta = 100.0;
            double baseVoltage = 0.7;
            double saturationVoltage = 0.2;
            double resistance = 1000.0;
            double current = (inputVoltage - baseVoltage) / resistance;
            double outputVoltage = Math.Max(0, Math.Min(beta * current, saturationVoltage)) * resistance;
            return outputVoltage;
        }
    }
}
