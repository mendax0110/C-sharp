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
using LiveCharts;
using LiveCharts.Wpf;
using FusionSimulator.Simulations;

namespace FusionSimulator
{
    public partial class MainWindow : Window
    {
        public SeriesCollection SeriesCollection { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            SeriesCollection = new SeriesCollection();
        }

        private void SimulateButton_Click(object sender, RoutedEventArgs e)
        {
            // Get the user input values
            string fuelType = fuelComboBox.Text;
            double fuelAmount = 0;
            double temperature = 0;
            double pressure = 0;
            try
            {
                fuelAmount = double.Parse(fuelAmountTextBox.Text);
                temperature = double.Parse(temperatureTextBox.Text);
                pressure = double.Parse(pressureTextBox.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid input values");
                return;
            }

            // Create a FusionSimulation object and call its Simulate method
            FusionSimulation simulation = new FusionSimulation(fuelType, fuelAmount, temperature, pressure);
            List<double> results = simulation.Simulate();
            if (results == null || results.Count == 0)
            {
                MessageBox.Show("Simulation did not return any results");
                return;
            }

            // Update the SeriesCollection with the simulation results
            SeriesCollection.Clear();
            SeriesCollection.Add(new LineSeries
            {
                Title = "Energy Output (J)",
                Values = new ChartValues<double>(results)
            });
        }
    }
}
