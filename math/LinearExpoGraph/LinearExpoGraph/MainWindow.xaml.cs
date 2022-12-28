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

namespace FunctionGraph
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void DrawButton_Click(object sender, RoutedEventArgs e)
        {
            // Get the input values from the text boxes
            double x1 = double.Parse(X1TextBox.Text);
            double y1 = double.Parse(Y1TextBox.Text);
            double x2 = double.Parse(X2TextBox.Text);
            double y2 = double.Parse(Y2TextBox.Text);

            // Calculate the slope and y-intercept of the linear function
            double slope = (y2 - y1) / (x2 - x1);
            double yIntercept = y1 - slope * x1;

            // Calculate the y-values for the linear function for the given x-values
            double y1Linear = slope * x1 + yIntercept;
            double y2Linear = slope * x2 + yIntercept;

            // Calculate the y-values for the exponential function for the given x-values
            double y1Exponential = Math.Pow(2, x1);
            double y2Exponential = Math.Pow(2, x2);

            // Clear the existing data points
            LinearFunction.Points.Clear();
            ExponentialFunction.Points.Clear();

            // Add the new data points
            LinearFunction.Points.Add(new Point(x1 * 50 + 300, -y1Linear * 50 + 200));
            LinearFunction.Points.Add(new Point(x2 * 50 + 300, -y2Linear * 50 + 200));
            ExponentialFunction.Points.Add(new Point(x1 * 50 + 300, -y1Exponential * 50 + 200));
            ExponentialFunction.Points.Add(new Point(x2 * 50 + 300, -y2Exponential * 50 + 200));
        }
    }
}
