using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SignalGenerator
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DrawSignal.Click += DrawSignal_Click;
        }

        private void DrawSignal_Click(object sender, RoutedEventArgs e)
        {
            // Clear any existing signal from the canvas
            canvas.Children.Clear();

            // Determine the type of signal to draw based on user input
            string signalType = signalSelector.SelectedItem.ToString();

            // Parse the user input for frequency and amplitude
            double frequency, amplitude;
            bool isValidFrequency = double.TryParse(frequencyInput.Text, out frequency);
            bool isValidAmplitude = double.TryParse(amplitudeInput.Text, out amplitude);

            if (!isValidFrequency || !isValidAmplitude)
            {
                MessageBox.Show("Invalid input. Frequency and amplitude must be valid numbers.");
                return;
            }

            // Define variables for drawing the signal
            int width = (int)canvas.ActualWidth;
            int height = (int)canvas.ActualHeight;
            Polyline polyline = new Polyline();
            polyline.StrokeThickness = 2;
            polyline.Stroke = Brushes.Black;
            
            try
            {
                // Draw the selected signal
                switch (signalType)
                {
                    case "Sawtooth":
                        for (int i = 0; i <= width; i++)
                        {
                            double x = (double)i / width;
                            double y = 2 * amplitude * (x - Math.Floor(x + 0.5)) / frequency;
                            polyline.Points.Add(new Point(i, height / 2 - y));
                        }
                        break;

                    case "Rectangle":
                        for (int i = 0; i <= width; i++)
                        {
                            double x = (double)i / width;
                            double y = amplitude * Math.Sign(Math.Sin(2 * Math.PI * frequency * x));
                            polyline.Points.Add(new Point(i, height / 2 - y));
                        }
                        break;

                    case "Sine":
                        for (int i = 0; i <= width; i++)
                        {
                            double x = (double)i / width;
                            double y = amplitude * Math.Sin(2 * Math.PI * frequency * x);
                            polyline.Points.Add(new Point(i, height / 2 - y));
                        }
                        break;

                    default:
                        break;
                }

                // Add the polyline to the canvas
                canvas.Children.Add(polyline);
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message + "Error");
            }
           
        }
    }
}
