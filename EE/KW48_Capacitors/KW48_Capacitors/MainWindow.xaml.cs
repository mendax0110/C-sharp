using System;
using System.Windows;
using System.Windows.Controls;

namespace CapacitorCalculator
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            // Get the area of the plates in square meters
            double plateArea = double.Parse(PlateAreaTextBox.Text);

            // Get the distance between the plates in meters
            double plateSeparation = double.Parse(PlateSeparationTextBox.Text);

            // Get the permittivity of the dielectric material
            double permittivity = double.Parse(PermittivityTextBox.Text);

            // Calculate the capacitance
            double capacitance = permittivity * plateArea / plateSeparation;

            // Display the result
            CapacitanceTextBlock.Text = $"The capacitance is {capacitance} Farads.";
        }
    }
}