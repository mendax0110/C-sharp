using System;
using System.Windows;
using System.Windows.Controls;
using OxyPlot.Series;
using OxyPlot.Axes;
using OxyPlot;

namespace EmitterSineWave
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private PlotModel plotModel;

        public MainWindow()
        {
            InitializeComponent();
            InitializePlot();
        }

        private void InitializePlot()
        {
            plotModel = new PlotModel { Title = "Emitter Sine Wave" };
            var xAxis = new LinearAxis { Position = AxisPosition.Bottom, Title = "Time (s)" };
            var yAxis = new LinearAxis { Position = AxisPosition.Left, Title = "Voltage (V)" };
            plotModel.Axes.Add(xAxis);
            plotModel.Axes.Add(yAxis);
            plotModel.InvalidatePlot(true);
            plotView.DataContext = plotModel;
        }

        private DataPoint[] sinePoints;


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (transistorType.SelectedIndex == 0) // NPN
            {
                double amplitude = 1.0;
                double frequency = 100.0;
                double bias = 0.7;

                double period = 1.0 / frequency;
                double dt = period / 100.0; // 100 samples per period
                int numSamples = (int)Math.Round(period * 10.0 / dt); // 10 periods
                double t = 0.0;

                sinePoints = new DataPoint[numSamples];

                for (int i = 0; i < numSamples; i++)
                {
                    double v = amplitude * Math.Sin(2.0 * Math.PI * frequency * t) + bias;
                    sinePoints[i] = new DataPoint(t, v);
                    t += dt;
                }

                var sineSeries = new LineSeries { Title = "NPN Sine Wave", ItemsSource = sinePoints };
                plotModel.Series.Clear();
                plotModel.Series.Add(sineSeries);
                plotModel.InvalidatePlot(true);
                plotView.DataContext = sineSeries;
            }
            else if (transistorType.SelectedIndex == 1) // PNP
            {
                double amplitude = 1.0;
                double frequency = 100.0;
                double bias = -0.7;
                double period = 1.0 / frequency;
                double dt = period / 100.0; // 100 samples per period
                int numSamples = (int)Math.Round(period * 10.0 / dt); // 10 periods
                double t = 0.0;

                sinePoints = new DataPoint[numSamples];

                for (int i = 0; i < numSamples; i++)
                {
                    double v = amplitude * Math.Sin(2.0 * Math.PI * frequency * t) + bias;
                    sinePoints[i] = new DataPoint(t, v);
                    t += dt;
                }

                var sineSeries = new LineSeries { Title = "PNP Sine Wave", ItemsSource = sinePoints };
                plotModel.Series.Clear();
                plotModel.Series.Add(sineSeries);
                plotModel.InvalidatePlot(true);
                plotView.DataContext = sineSeries;
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            plotModel.Series.Clear();
            plotModel.Title = $"Emitter Sine Wave ({transistorType.SelectedItem})";
            plotModel.InvalidatePlot(true);
        }
    }
}
