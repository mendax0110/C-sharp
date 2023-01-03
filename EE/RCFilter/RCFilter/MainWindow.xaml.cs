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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("CalculateButton_Click called");

            // Parse input values
            double resistance = double.Parse(ResistanceTextBox.Text);
            double capacitance = double.Parse(CapacitanceTextBox.Text);
            double frequency = double.Parse(FrequencyTextBox.Text);
            double amplitude = double.Parse(AmplitudeTextBox.Text);
            double phase = double.Parse(PhaseTextBox.Text);

            // Calculate sine wave
            double[] sineWave = CalculateSineWave(resistance, capacitance, frequency, amplitude, phase);

            // Display sine wave
            DisplaySineWave(sineWave);
        }

        private double[] CalculateSineWave(double resistance, double capacitance, double frequency, double amplitude, double phase)
        {
            // Calculate RC time constant
            double timeConstant = resistance * capacitance;

            // Calculate angular frequency
            double angularFrequency = 2 * Math.PI * frequency;

            // Calculate number of samples
            int numSamples = (int)(timeConstant * frequency);

            // Initialize array to hold sine wave samples
            double[] sineWave = new double[numSamples];

            // Calculate sine wave samples
            for (int i = 0; i < numSamples; i++)
            {
                double t = i / frequency;
                sineWave[i] = amplitude * Math.Sin(angularFrequency * t + phase);
            }

            return sineWave;
        }

        private void DisplaySineWave(double[] sineWave)
        {
            // Clear previous display
            SineWaveCanvas.Children.Clear();

            // Calculate scale factor for display
            double maxValue = sineWave.Max();
            double minValue = sineWave.Min();
            double scaleFactor = SineWaveCanvas.Height / (maxValue - minValue);

            Console.WriteLine($"Scale factor: {scaleFactor}");

            // Draw sine wave
            Point previousPoint = new Point(0, SineWaveCanvas.Height - (sineWave[0] - minValue) * scaleFactor);
            Console.WriteLine($"Sample 0: ({previousPoint.X}, {previousPoint.Y})");
            for (int i = 1; i < sineWave.Length; i++)
            {
                Point currentPoint = new Point(i, SineWaveCanvas.Height - (sineWave[i] - minValue) * scaleFactor);
                Console.WriteLine($"Sample {i}: ({currentPoint.X}, {currentPoint.Y})");
                Line line = new Line();
                line.Stroke = Brushes.Black;
                line.X1 = previousPoint.X;
                line.Y1 = previousPoint.Y;
                line.X2 = currentPoint.X;
                line.Y2 = currentPoint.Y;
                SineWaveCanvas.Children.Add(line);
                previousPoint = currentPoint;
            }
        }
    }
}

