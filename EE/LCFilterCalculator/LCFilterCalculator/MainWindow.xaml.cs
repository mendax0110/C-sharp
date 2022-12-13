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

namespace LCFilterCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Get the values of the inductance and capacitance from the input fields
                double inductance = double.Parse(InductanceInput.Text);
                double capacitance = double.Parse(CapacitanceInput.Text);

                // Calculate the cutoff frequency of the filter
                double cutoffFrequency = 1 / (2 * Math.PI * Math.Sqrt(inductance * capacitance));

                // Display the result in the output field
                CutoffFrequencyOutput.Text = cutoffFrequency.ToString("F2");
            }
            catch (Exception ex)
            {
                // Display an error message if something went wrong
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
