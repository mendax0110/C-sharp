using System;
using System.Windows;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;

namespace TransCircSine
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Get the selected transistor type from the radio buttons
            string transistorType = "";
            if (NPN.IsChecked == true)
            {
                transistorType = "NPN";
            }
            else if (PNP.IsChecked == true)
            {
                transistorType = "PNP";
            }
            else
            {
                MessageBox.Show("Please select a transistor type.");
                return;
            }

            // Generate the input and output sine waves
            int numPoints = 1000;
            double frequency = 1000;
            double amplitude = 1;
            double phaseShift = Math.PI / 2;
            double inputDCOffset = 0.5;
            double outputDCOffset = 0.5;
            double inputMin = inputDCOffset - amplitude;
            double inputMax = inputDCOffset + amplitude;
            double outputMin = outputDCOffset - amplitude;
            double outputMax = outputDCOffset + amplitude;
            double[] inputWaveform = new double[numPoints];
            double[] outputWaveform = new double[numPoints];
            for (int i = 0; i < numPoints; i++)
            {
                double t = i / (double)numPoints;
                double input = inputDCOffset + amplitude * Math.Sin(2 * Math.PI * frequency * t + phaseShift);
                inputWaveform[i] = input;
                double output = 0;
                if (transistorType == "NPN")
                {
                    if (input < 0.7)
                    {
                        output = 0;
                    }
                    else
                    {
                        output = input - 0.7;
                    }
                }
                else if (transistorType == "PNP")
                {
                    if (input > 0.3)
                    {
                        output = 0;
                    }
                    else
                    {
                        output = 0.3 - input;
                    }
                }
                outputWaveform[i] = output;
            }

            // Create the plot model
            var model = new PlotModel { Title = "Transistor Circuit Sine Wave" };

            // Create the input and output axes
            var inputAxis = new LinearAxis
            {
                Position = AxisPosition.Bottom,
                Minimum = inputMin,
                Maximum = inputMax,
                Title = "Input"
            };
            model.Axes.Add(inputAxis);
            var outputAxis = new LinearAxis
            {
                Position = AxisPosition.Left,
                Minimum = outputMin,
                Maximum = outputMax,
                Title = "Output"
            };
            model.Axes.Add(outputAxis);

            // Create the input and output series
            var inputSeries = new LineSeries
            {
                Title = "Input",
                MarkerType = MarkerType.Circle,
                MarkerSize = 2,
                MarkerStroke = OxyColors.Black
            };

            //for (int i = 0; i < numPoints; i++)
            //{
            //    inputSeries.Points.Add(new DataPoint(inputWaveform[i], 0));
            //}
            //model.Series.Add(inputSeries);

            var outputSeries = new LineSeries
            {
                Title = "Output",
                MarkerType = MarkerType.Circle,
                MarkerSize = 2,
                MarkerStroke = OxyColors.Black
            };

            for (int i = 0; i < numPoints; i++)
            {
                inputSeries.Points.Add(new DataPoint(inputWaveform[i], 0));
                outputSeries.Points.Add(new DataPoint(inputWaveform[i], outputWaveform[i]));
            }
            model.Series.Add(inputSeries);
            model.Series.Add(outputSeries);


            // Display the plot
            this.plotView.Model = model;
        }
    }
}
