using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace BipolarTransistor
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            double collectorCurrent;
            double baseCurrent;

            // Check for valid input values
            if (!double.TryParse(CollectorCurrentTextBox.Text, out collectorCurrent) ||
                !double.TryParse(BaseCurrentTextBox.Text, out baseCurrent))
            {
                MessageBox.Show("Please enter valid numeric values for collector current and base current.");
                return;
            }

            // Determine if NPN or PNP transistor is selected
            if (NPNRadioButton.IsChecked == true)
            {
                // Calculate NPN transistor input and output curves
                // (Note: this is a simplified example for demonstration purposes only)
                double currentGain = 100;
                double collectorVoltage = collectorCurrent * currentGain;
                double baseVoltage = baseCurrent / currentGain;

                CollectorVoltageTextBox.Text = collectorVoltage.ToString();
                BaseVoltageTextBox.Text = baseVoltage.ToString();
            }
            else if (PNPRadioButton.IsChecked == true)
            {
                // Calculate PNP transistor input and output curves
                // (Note: this is a simplified example for demonstration purposes only)
                double currentGain = 50;
                double collectorVoltage = collectorCurrent * currentGain;
                double baseVoltage = baseCurrent / currentGain;

                CollectorVoltageTextBox.Text = collectorVoltage.ToString();
                BaseVoltageTextBox.Text = baseVoltage.ToString();
            }
            else
            {
                MessageBox.Show("Please select NPN or PNP transistor.");
                return;
            }
        }
    }
}
