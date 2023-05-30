using System;
using System.Windows;
using System.Windows.Controls;

namespace DifferentialEquations
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private double DifferentialEquationsSolver(string equation)
        {
            // Parse the equation
            string[] equationParts = equation.Split('=');
            string derivative = equationParts[0].Trim();
            string expression = equationParts[1].Trim();

            double x = 0;
            double y = 0; 
            double dydx = x + y; 
            double solution = y + dydx; 

            return solution;
        }

        private void ButtonToSolve_Click(object sender, RoutedEventArgs e)
        {
            string equation = EQToSolve.Text;

            try
            {
                double solution = DifferentialEquationsSolver(equation);
                SolvedEQ.Text = $"Solution: {solution}";
            }
            catch (Exception ex)
            {
                SolvedEQ.Text = $"Error: {ex.Message}";
            }
        }

        private void SolvedEQ_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Clear the solved equation text when the input equation changes
            SolvedEQ.Clear();
        }

        private void EQToSolve_TextChanged(object sender, TextChangedEventArgs e)
        {
            string equation = EQToSolve.Text;

            try
            {
                double solution = DifferentialEquationsSolver(equation);
                SolvedEQ.Text = $"Solution: {solution}";

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

        }
    }
}
