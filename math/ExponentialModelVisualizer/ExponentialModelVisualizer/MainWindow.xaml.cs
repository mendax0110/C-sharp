using System;
using System.Linq;
using System.Windows;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Wpf;

namespace ExponentialModelVisualizer
{
    public partial class MainWindow : Window
    {
        private PlotModel plotModel;
        private OxyPlot.Series.LineSeries lineSeries;
        private OxyPlot.Series.ScatterSeries scatterSeries;

        public MainWindow()
        {
            InitializeComponent();

            // Create the plot model and series
            plotModel = new PlotModel();
            lineSeries = new OxyPlot.Series.LineSeries();
            scatterSeries = new OxyPlot.Series.ScatterSeries();
            plotModel.Series.Add(lineSeries);
            plotModel.Series.Add(scatterSeries);

            // Assign the plot model to the OxyPlot chart
            plot.Model = plotModel;
        }


        private void btnVisualize_Click(object sender, RoutedEventArgs e)
        {
            // Clear the data from the previous visualization
            scatterSeries.Points.Clear();
            lineSeries.Points.Clear();

            // Parse the x and y values from the text boxes
            double[] xValues = txtXValues.Text.Split(',').Select(x => double.Parse(x)).ToArray();
            double[] yValues = txtYValues.Text.Split(',').Select(y => double.Parse(y)).ToArray();

            // Add the data points to the scatter series
            for (int i = 0; i < xValues.Length; i++)
            {
                scatterSeries.Points.Add(new ScatterPoint(xValues[i], yValues[i]));
            }

            // Fit an exponential curve to the data using linear regression
            double[] coefficients = FitExponentialCurve(xValues, yValues);
            double a = coefficients[0];
            double b = coefficients[1];

            // Generate points for the exponential curve
            for (double x = xValues.Min(); x <= xValues.Max(); x += 0.1)
            {
                double y = a * Math.Exp(b * x);
                lineSeries.Points.Add(new DataPoint(x, y));
            }

            // Update the plot model
            plotModel.InvalidatePlot(true);
        }

        private double[] FitExponentialCurve(double[] xValues, double[] yValues)
        {
            // Use linq to fit an exponential curve y = a * exp(b * x) to the data
            var X = xValues.Select(x => new[] { x, Math.Log(yValues[Array.IndexOf(xValues, x)]) });
            var Y = yValues.Select(y => Math.Log(y));
            var LR = X.Zip(Y, (x, y) => x.Concat(new[] { y }).ToArray()).ToArray();
            var transpose = Enumerable.Range(0, LR[0].Length).Select(i => LR.Select(row => row[i]).ToArray()).ToArray();
            var a = transpose[0].Average();
            var b = transpose[1].Average();
            for (var i = 0; i < transpose[0].Length; i++)
            {
                transpose[0][i] -= a;
                transpose[1][i] -= b;
            }
            var B = transpose[1].Sum(y => y * y) / transpose[0].Sum(x => x * x);
            var A = transpose[1].Sum(y => y * y) / transpose[0].Sum(x => x * x);
            var coefficients = new[] { Math.Exp(A), B };
            return coefficients;
        }
    }
}
