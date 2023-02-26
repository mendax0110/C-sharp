using System;
using System.Windows;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;

namespace EmitterCircuitPlotter
{
    public partial class MainWindow : Window
    {
        private PlotModel plotModel;

        public MainWindow()
        {
            InitializeComponent();

            plotModel = new PlotModel();
            plotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, Title = "Time (s)" });
            plotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Title = "Voltage (V)" });
            PlotControl.Model = plotModel;
        }

        private void OnPlotButtonClicked(object sender, RoutedEventArgs e)
        {
            double amplitude;
            if (!double.TryParse(AmplitudeTextBox.Text, out amplitude))
            {
                MessageBox.Show("Invalid amplitude value.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            double frequency;
            if (!double.TryParse(FrequencyTextBox.Text, out frequency))
            {
                MessageBox.Show("Invalid frequency value.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var dataSeries = new LineSeries();
            var step = 0.001;
            for (double time = 0; time <= 1; time += step)
            {
                var input = amplitude * Math.Sin(2 * Math.PI * frequency * time);
                var output = Math.Max(0, input);
                dataSeries.Points.Add(new DataPoint(time, output));
            }

            plotModel.Series.Clear();
            plotModel.Series.Add(dataSeries);
            plotModel.InvalidatePlot(true);
        }
    }
}
