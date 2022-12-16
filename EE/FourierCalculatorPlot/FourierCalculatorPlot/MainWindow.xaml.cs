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
using System.Numerics;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;

namespace FourierCalculatorPlot
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // get user input
            double amplitude = Convert.ToDouble(amplitudeInput.Text);
            double frequency = Convert.ToDouble(frequencyInput.Text);
            double phase = Convert.ToDouble(phaseInput.Text);
            double time = Convert.ToDouble(timeInput.Text);

            // calculate
            double result = amplitude * Math.Sin(2 * Math.PI * frequency * time + phase);

            // display result
            resultLabel.Content = result.ToString();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // get user input
            double amplitude = Convert.ToDouble(amplitudeInput.Text);
            double frequency = Convert.ToDouble(frequencyInput.Text);
            double phase = Convert.ToDouble(phaseInput.Text);
            double time = Convert.ToDouble(timeInput.Text);

            // calculate waveform data
            int numSamples = 1024;
            double[] data = new double[numSamples];
            for (int i = 0; i < numSamples; i++)
            {
                double t = i / (double)numSamples;
                data[i] = amplitude * Math.Sin(2 * Math.PI * frequency * t + phase);
            }

            // calculate and plot Fourier transform
            FourierCalculatorPlot.FourierTransformer fourierTransformer = new FourierCalculatorPlot.FourierTransformer();
            fourierTransformer.Plot(data);
            plotView.Model = fourierTransformer.Model;
        }

        private void timeInput_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
