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

namespace SiliconDiodePlotter
{
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
                double reverseBiasVoltage = double.Parse(ReverseBiasVoltageTextBox.Text);
                double saturationCurrent = double.Parse(SaturationCurrentTextBox.Text);
                double idealityFactor = double.Parse(IdealityFactorTextBox.Text);

                // Calculate current based on reverse bias voltage
                double current = saturationCurrent * (Math.Exp(reverseBiasVoltage / (idealityFactor * Constants.Boltzmann)) - 1);

                // Plot the result
                // TODO: Implement plot

                ResultTextBlock.Text = $"Current: {current}";
            }
            catch (Exception ex)
            {
                ResultTextBlock.Text = "Error: " + ex.Message;
            }
        }
    }

    internal static class Constants
    {
        public const double Boltzmann = 1.380649e-23;
    }
}

