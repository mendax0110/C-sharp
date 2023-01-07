using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;

namespace LogGraph
{
    public partial class MainWindow : Window
    {
        private PlotModel plotModel;
        private LineSeries lnSeries;
        private LineSeries logSeries;
        private double min;
        private double max;
        private int numPoints;

        public MainWindow()
        {
            InitializeComponent();

            plotModel = new PlotModel { Title = "ln and log" };
            plotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, Title = "x" });
            plotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Title = "y" });
            lnSeries = new LineSeries { Title = "ln(x)" };
            logSeries = new LineSeries { Title = "log(x)" };
            plotModel.Series.Add(lnSeries);
            plotModel.Series.Add(logSeries);

            plotView.Model = plotModel;
        }

        private void UpdatePlot()
        {
            min = Double.Parse(minInput.Text);
            max = Double.Parse(maxInput.Text);
            numPoints = Int32.Parse(numPointsInput.Text);

            lnSeries.Points.Clear();
            logSeries.Points.Clear();
            for (int i = 0; i < numPoints; i++)
            {
                double x = min + (max - min) * i / (numPoints - 1);
                lnSeries.Points.Add(new DataPoint(x, Math.Log(x)));
                logSeries.Points.Add(new DataPoint(x, Math.Log10(x)));
            }

            plotModel.InvalidatePlot(true);
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            UpdatePlot();
        }
    }
}
