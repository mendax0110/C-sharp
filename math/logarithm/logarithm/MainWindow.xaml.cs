using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using OxyPlot;
using OxyPlot.Series;

namespace LogCalculator
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            // Get the base and value from the input fields
            double baseValue = double.Parse(BaseTextBox.Text);
            double value = double.Parse(ValueTextBox.Text);

            // Calculate the log and ln of the value
            double logResult = Math.Log(value, baseValue);
            double lnResult = Math.Log(value);

            // Add the results to the plot model
            PlotModel model = new PlotModel();
            model.Series.Add(new LineSeries
            {
                Title = "Results",
                Points = { new DataPoint(baseValue, logResult), new DataPoint(Math.E, lnResult) }
            });
            ResultsChart.Model = model;
        }
    }
}
