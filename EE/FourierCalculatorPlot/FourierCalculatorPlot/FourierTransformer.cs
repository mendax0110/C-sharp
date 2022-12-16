using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using System;
using System.Numerics;

namespace FourierCalculatorPlot
{
    internal class FourierTransformer
    {
        public PlotModel? Model { get; internal set; }

        internal void Plot(double[] data)
        {
            // Calculate the number of samples
            int n = data.Length;

            // Check if the number of samples is a power of 2
            if ((n & (n - 1)) != 0)
            {
                throw new ArgumentException("The number of samples must be a power of 2.");
            }

            // Initialize the complex array for the FFT
            Complex[] fftData = new Complex[n];
            for (int i = 0; i < n; i++)
            {
                fftData[i] = new Complex(data[i], 0);
            }

            // Perform the FFT
            FFT(fftData, n, 1);

            // Create the PlotModel
            Model = new PlotModel();
            Model.Title = "Fourier Transform";

            // Create the X axis
            LinearAxis xAxis = new LinearAxis();
            xAxis.Position = AxisPosition.Bottom;
            xAxis.Title = "Frequency (Hz)";
            Model.Axes.Add(xAxis);

            // Create the Y axis
            LinearAxis yAxis = new LinearAxis();
            yAxis.Title = "Amplitude";
            Model.Axes.Add(yAxis);

            // Create the line series for the FFT
            LineSeries lineSeries = new LineSeries();
            lineSeries.Title = "FFT";
            lineSeries.Color = OxyColor.FromRgb(255, 0, 0);
            for (int i = 0; i < n / 2; i++)
            {
                lineSeries.Points.Add(new DataPoint(i / (double)n, fftData[i].Magnitude));
            }
            Model.Series.Add(lineSeries);
        }

        private static void FFT(Complex[] data, int n, int sign)
        {
            // Base case
            if (n == 1)
            {
                return;
            }

            // Split the array into even and odd samples
            Complex[] even = new Complex[n / 2];
            Complex[] odd = new Complex[n / 2];
            for (int i = 0; i < n / 2; i++)
            {
                even[i] = data[2 * i];
                odd[i] = data[2 * i + 1];
            }
        }

    }
}
