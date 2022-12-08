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

namespace CapacitorCalculator
{
    // Main window for the capacitor calculator
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Calculate the total capacitance for a series configuration
        private void CalculateSeriesCapacitance(object sender, RoutedEventArgs e)
        {
            // Get the capacitance values from the text boxes
            double c1 = double.Parse(Capacitance1.Text);
            double c2 = double.Parse(Capacitance2.Text);

            // Calculate the total capacitance for a series configuration
            double cTotal = c1 + c2;

            // Display the total capacitance in the text box
            TotalCapacitance.Text = cTotal.ToString();
        }

        // Calculate the total capacitance for a parallel configuration
        private void CalculateParallelCapacitance(object sender, RoutedEventArgs e)
        {
            // Get the capacitance values from the text boxes
            double c1 = double.Parse(Capacitance1.Text);
            double c2 = double.Parse(Capacitance2.Text);

            // Calculate the total capacitance for a parallel configuration
            double cTotal = c1 + c2;
            cTotal = 1 / cTotal;

            // Display the total capacitance in the text box
            TotalCapacitance.Text = cTotal.ToString();
        }
    }
}
