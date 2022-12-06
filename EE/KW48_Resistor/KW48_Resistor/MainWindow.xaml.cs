using System;
using System.Windows;

namespace ResistanceCalculator
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void calculateButton_Click(object sender, RoutedEventArgs e)
        {
            // Parse the input values
            double voltage = double.Parse(voltageTextBox.Text);
            double current = double.Parse(currentTextBox.Text);

            // Calculate the resistance
            double resistance = voltage / current;

            // Display the result
            resultLabel.Content = $"The resistance is: {resistance:F2} ohms";
        }
    }
}
