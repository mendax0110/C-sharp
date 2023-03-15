using System;
using System.Windows;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Wpf;

namespace LimitsFunction
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void PlotButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double limitValue = double.Parse(LimitTextBox.Text);

                // Calculate the function
                double y = CalculateFunction(limitValue);

                // Create the plot model
                var plotModel = new PlotModel { Title = $"f(x) = {(y == double.NaN ? "undefined" : y.ToString())}" };

                // Add the function plot
                var functionSeries = new LineSeries();
                functionSeries.Points.Add(new DataPoint(limitValue - 0.1, CalculateFunction(limitValue - 0.1)));
                functionSeries.Points.Add(new DataPoint(limitValue, y));
                functionSeries.Points.Add(new DataPoint(limitValue + 0.1, CalculateFunction(limitValue + 0.1)));
                plotModel.Series.Add(functionSeries);

                // Set the plot model as the plot view model
                PlotView.Model = plotModel;
            }
            catch
            {
                // catch the error and print message
                MessageBox.Show("The Values are wrong", "Error");
            }
        }

        private double CalculateFunction(double x)
        {
            return Math.Sin(x) / x;
            //return x + 1;
        }
    }
}
