using System;
using System.Windows;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;

namespace EmitterCircuitPlotter
{
    public partial class MainWindow : Window
    {
        // The plot model.
        private PlotModel plotModel;

        // This method is called when the window is loaded.
        public MainWindow()
        {
            InitializeComponent();

            plotModel = new PlotModel();
            plotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, Title = "Time (s)" });
            plotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Title = "Voltage (V)" });
            PlotControl.Model = plotModel;
        }

        // This method is called when the user clicks the "Plot" button.
        private void OnPlotButtonClicked(object sender, RoutedEventArgs e)
        {
            // Get the amplitude and frequency.
            double amplitude;
            if (!double.TryParse(AmplitudeTextBox.Text, out amplitude))
            {
                MessageBox.Show("Invalid amplitude value.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Get the frequency.
            double frequency;
            if (!double.TryParse(FrequencyTextBox.Text, out frequency))
            {
                MessageBox.Show("Invalid frequency value.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Get the circuit parameters.
            double beta;
            if (!double.TryParse(BetaTextBox.Text, out beta))
            {
                MessageBox.Show("Invalid beta value.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            double rc;
            if (!double.TryParse(RCTextBox.Text, out rc))
            {
                MessageBox.Show("Invalid RC value.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Plot the data.
            var dataSeries = new LineSeries();
            var step = 0.001;
            for (double time = 0; time <= 1; time += step)
            {
                var input = amplitude * Math.Sin(2 * Math.PI * frequency * time);

                // Calculate the output of the Emitter-Transistor Circuit.
                var vbe = 0.7; // Base-emitter voltage.
                var ib = input / (beta * vbe + rc);
                var output = ib * rc;

                dataSeries.Points.Add(new DataPoint(time, output));
            }

            plotModel.Series.Clear();
            plotModel.Series.Add(dataSeries);
            plotModel.InvalidatePlot(true);
        }
    }
}
