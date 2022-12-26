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

// Fusion Reactor Simulator
namespace FusionSimulator
{
    public partial class MainWindow : Window
    {
        public SeriesCollection SeriesCollection { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            SeriesCollection = new SeriesCollection();
            DataContext = this;  // Set the DataContext to the MainWindow instance
        }

        private void SimulateButton_Click(object sender, RoutedEventArgs e)
        {
            // Create a FusionSimulation object and call its Simulate method
            SeriesCollection.Clear();

            string fuelType = fuelComboBox.Text;
            double fuelAmount;
            if (!double.TryParse(fuelAmountTextBox.Text, out fuelAmount) || fuelAmount <= 0)
            {
                MessageBox.Show("Invalid fuel amount");
                return;
            }
            double plasmaDensity;
            if (!double.TryParse(plasmaDensityTextBox.Text, out plasmaDensity) || plasmaDensity <= 0)
            {
                MessageBox.Show("Invalid plasma density");
                return;
            }
            double ionSpecies;
            if (!double.TryParse(ionSpeciesTextBox.Text, out ionSpecies) || ionSpecies <= 0)
            {
                MessageBox.Show("Invalid ion species");
                return;
            }
            double temperature;
            if (!double.TryParse(temperatureTextBox.Text, out temperature) || temperature <= 0)
            {
                MessageBox.Show("Invalid temperature");
                return;
            }
            double pressure;
            if (!double.TryParse(pressureTextBox.Text, out pressure) || pressure <= 0)
            {
                MessageBox.Show("Invalid pressure");
                return;
            }
            double plasmaLosses;
            if (!double.TryParse(plasmaLossesTextBox.Text, out plasmaLosses) || plasmaLosses < 0)
            {
                MessageBox.Show("Invalid plasma losses");
                return;
            }

            FusionSimulation simulation = new FusionSimulation(fuelType, fuelAmount, plasmaDensity, ionSpecies, temperature, pressure, plasmaLosses);
            List<double> results = simulation.Simulate();
            if (results == null || results.Count == 0)
            {
                MessageBox.Show("Simulation did not return any results");
                return;
            }

            // Add the simulation results to the SeriesCollection
            SeriesCollection.Add(new LineSeries
            {
                Title = "Energy Output (J)",
                Values = new ChartValues<double>(results)
            });
        }
    }
}
