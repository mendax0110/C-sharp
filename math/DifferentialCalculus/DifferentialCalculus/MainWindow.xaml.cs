using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Wpf;

namespace DifferentialCalculus
{
    public partial class MainWindow : Window
    {
        public PlotModel PlotModel { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            // Initialize the plot model
            PlotModel = new PlotModel();
            PlotModel.Title = "Differentiated Data";
            PlotModel.Series.Add(new LineSeries());
        }


        private void differentiateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Parse data from the text box
                List<DataPoint> data = dataTextBox.Text.Split(',')
                .Select((value, index) => 
                {
                    if (index % 2 == 0)
                    {
                        double x = double.Parse(value);
                        double y = 0;
                        if (index < dataTextBox.Text.Split(',').Length - 1)
                        {
                            double.TryParse(dataTextBox.Text.Split(',')[index + 1], out y);
                        }
                        return new DataPoint(x, y);
                    }
                    return new DataPoint(double.NaN, double.NaN); // Return invalid values when the condition is not met
                })
                .Where(point => !double.IsNaN(point.X) && !double.IsNaN(point.Y))
                .ToList();

                // Differentiate the data
                List<DataPoint> differentiatedData = CentralDifference(data);

                // Print the differentiated data to the console
                foreach (var point in differentiatedData)
                {
                    Console.WriteLine($"x={point.X}, y={point.Y}");
                }

                // Display the differentiated data on the plot
                PlotModel.Series.Clear();
                PlotModel.Series.Add(new LineSeries
                {
                    ItemsSource = differentiatedData,
                    Title = "Differentiated Data"
                });
                PlotModel.InvalidatePlot(true);
                MessageBox.Show("Plot updated!");

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private List<DataPoint> CentralDifference(List<DataPoint> data)
        {
            List<DataPoint> differentiatedData = new List<DataPoint>();

            // Compute the slope for the first point using a one-sided difference formula
            double x1 = data[0].X;
            double y1 = (data[1].Y - data[0].Y) / (data[1].X - data[0].X);
            differentiatedData.Add(new DataPoint(x1, y1));

            // Compute the slopes for the middle points using a central difference formula
            for (int i = 1; i < data.Count - 1; i++)
            {
                double x = data[i].X;
                double y = (data[i + 1].Y - data[i - 1].Y) / (data[i + 1].X - data[i - 1].X);

                differentiatedData.Add(new DataPoint(x, y));
            }

            // Compute the slope for the last point using a one-sided difference formula
            double xn = data[data.Count - 1].X;
            double yn = (data[data.Count - 1].Y - data[data.Count - 2].Y) / (data[data.Count - 1].X - data[data.Count - 2].X);
            differentiatedData.Add(new DataPoint(xn, yn));

            return differentiatedData;
        }
    }
}
