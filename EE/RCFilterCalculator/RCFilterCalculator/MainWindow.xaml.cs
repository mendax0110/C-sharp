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
namespace RCFilterCalculator
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void calculateButton_Click(object sender, RoutedEventArgs e)
        {
            // Get the values entered by the user
            double resistance = double.Parse(resistanceTextBox.Text);
            double capacitance = double.Parse(capacitanceTextBox.Text);

            // Perform the calculations
            double timeConstant = resistance * capacitance;
            double cutoffFrequency = 1 / (2 * Math.PI * timeConstant);

            // Display the results to the user
            MessageBox.Show($"Time constant: {timeConstant:F2} seconds\nCutoff frequency: {cutoffFrequency:F2} Hz");
        }
    }
}
