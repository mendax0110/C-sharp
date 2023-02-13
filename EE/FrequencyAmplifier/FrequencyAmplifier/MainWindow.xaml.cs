using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace FrequencyAmplifier
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AmplifyFrequencyButton_Click(object sender, RoutedEventArgs e)
        {
            // Get the input frequency from the user
            double inputFrequency = double.Parse(InputFrequencyTextBox.Text);

            // Amplify the frequency
            double amplifiedFrequency = inputFrequency * 10;

            // Plot the amplified frequency on the graph
            PlotFrequency(amplifiedFrequency);

            // Show the amplified frequency
            AmplifiedFrequencyTextBlock.Text = amplifiedFrequency.ToString();
        }

        private void PlotFrequency(double frequency)
        {
            // Clear the existing graph
            GraphCanvas.Children.Clear();

            // Calculate the x and y coordinates for the point
            double x = GraphCanvas.ActualWidth / 2;
            double y = GraphCanvas.ActualHeight / 2 - frequency;

            // Create a circle to represent the point
            Ellipse point = new Ellipse
            {
                Width = 10,
                Height = 10,
                Fill = Brushes.Red
            };

            // Set the position of the point
            Canvas.SetLeft(point, x);
            Canvas.SetTop(point, y);

            // Add the point to the graph
            GraphCanvas.Children.Add(point);
        }
    }
}
