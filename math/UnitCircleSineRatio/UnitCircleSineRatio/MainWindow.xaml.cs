using System;
using System.Collections.ObjectModel;
using System.Windows;
using OxyPlot;
using OxyPlot.Wpf;
using OxyPlot.Series;

namespace UnitCircleSineRatio
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        public ObservableCollection<DataPoint> DataPoints { get; set; } = new ObservableCollection<DataPoint>();

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            // Parse the radius input from the user
            double radius = double.Parse(txtRadius.Text);

            // Calculate the sine value
            double sine = Math.Sin(radius);

            // Display the sine value
            lblSine.Content = "Sine: " + sine.ToString();

            // Clear any existing data-points form the chart
            DataPoints.Clear();

            // Generate data-points for the sine curve
            for (double x = -radius; x <= radius; x += 0.1)
            {
                double y = Math.Sin(x);
                DataPoints.Add(new DataPoint(x, y));
            }
        }
    }
}

       
