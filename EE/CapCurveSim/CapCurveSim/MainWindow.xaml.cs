using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SineWave
{
    public partial class MainWindow : Window
    {
        private const int NumSamples = 100;
        private readonly double[] _samples = new double[NumSamples];
        private readonly Polyline _polyline = new Polyline();

        public MainWindow()
        {
            InitializeComponent();

            _polyline.Stroke = Brushes.Blue;
            _polyline.StrokeThickness = 2;
            canvas.Children.Add(_polyline);

            CompositionTarget.Rendering += CompositionTarget_Rendering;
        }

        private void CompositionTarget_Rendering(object sender, EventArgs e)
        {
            for (int i = 1; i < NumSamples; i++)
            {
                _samples[i - 1] = _samples[i];
            }

            // Compute the next sample
            double t = (DateTime.Now - DateTime.MinValue).TotalSeconds;
            _samples[NumSamples - 1] = Math.Sin(t * 2 * Math.PI);

            // Update the polyline
            PointCollection points = new PointCollection(NumSamples);
            for (int i = 0; i < NumSamples; i++)
            {
                double x = i * canvas.ActualWidth / NumSamples;
                double y = _samples[i] * canvas.ActualHeight / 2 + canvas.ActualHeight / 2;
                points.Add(new Point(x, y));
            }
            _polyline.Points = points;
        }
    }
}
