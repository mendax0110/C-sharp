using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FusionSimulator.Simulations
{
    public class FusionSimulation
    {
        private readonly string _fuelType;
        private readonly double _fuelAmount;
        private readonly double _plasmaDensity;
        private readonly double _ionSpecies;
        private readonly double _temperature;
        private readonly double _pressure;
        private readonly double _plasmaLosses;

        public FusionSimulation(string fuelType, double fuelAmount, double plasmaDensity, double ionSpecies, double temperature, double pressure, double plasmaLosses)
        {
            _fuelType = fuelType;
            _fuelAmount = fuelAmount;
            _plasmaDensity = plasmaDensity;
            _ionSpecies = ionSpecies;
            _temperature = temperature;
            _pressure = pressure;
            _plasmaLosses = plasmaLosses;
        }

        public List<double> Simulate()
        {
            // Perform the fusion simulation and return the results
            List<double> results = new List<double>();

            // Check that the input values are valid
            if (_fuelAmount <= 0 || _plasmaDensity <= 0 || _ionSpecies <= 0 || _temperature <= 0 || _pressure <= 0 || _plasmaLosses < 0)
            {
                return results;  // Return an empty list if any of the input values is invalid
            }

            for (int i = 0; i < 10; i++)  // Simulate for 10 time steps
            {
                double energy;
                if (_fuelType == "deuterium-tritium")
                {
                    // Use the deuterium-tritium fusion reaction to calculate the energy produced at each time step
                    double fusionPower = _fuelAmount * _plasmaDensity * _ionSpecies * _temperature * Math.Pow(10, -20) * Math.Exp(-1.44 / _temperature);  // fusion power in watts
                    energy = fusionPower * 3600;  // energy in joules
                }
                else if (_fuelType == "deuterium-deuterium")
                {
                    // Use the deuterium-deuterium fusion reaction to calculate the energy produced at each time step
                    double fusionPower = _fuelAmount * _plasmaDensity * _ionSpecies * _temperature * Math.Pow(10, -20) * Math.Exp(-1.44 / _temperature);  // fusion power in watts
                    energy = fusionPower * 3600;  // energy in joules
                }
                else
                {
                    // Other fuel types are not supported, so return 0 energy
                    energy = 0;
                }

                // random offset in joules
                double randomOffset = new Random().NextDouble() * 1000;
                energy += randomOffset;

                results.Add(energy);  // Add the energy produced at each time step to the results list
            }

            return results;
        }
    }
}
