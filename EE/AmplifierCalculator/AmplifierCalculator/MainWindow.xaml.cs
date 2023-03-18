using System;
using System.Reflection.Emit;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace AmplifierCalculator
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
                // Get input values from text boxes
                double Vin = double.Parse(VinTextBox.Text);
                double R1 = double.Parse(R1TextBox.Text);
                double R2 = double.Parse(R2TextBox.Text);

                // Calculate amplifier values
                double A = -(R2 / R1);
                double B = 1 + (R2 / R1);
                double C = Vin / R1;

                // Display amplifier values
                ALabel.Content = "A: " + A.ToString();
                BLabel.Content = "B: " + B.ToString();
                CLabel.Content = "C: " + C.ToString();

                // Plot sine wave
                PlotSine(A, B, C);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }   
        }

        private void PlotSine(double A, double B, double C)
        {
            try
            {
                // Clear previous graph
                GraphCanvas.Children.Clear();

                // Set graph properties
                SolidColorBrush axisBrush = new SolidColorBrush(Colors.Black);
                SolidColorBrush sineBrush = new SolidColorBrush(Colors.Red);
                double axisThickness = 2;
                double sineThickness = 2;
                double xMin = 0;
                double xMax = 2 * Math.PI;
                double yMin = -1.5;
                double yMax = 1.5;
                double xScale = GraphCanvas.ActualWidth / (xMax - xMin);
                double yScale = GraphCanvas.ActualHeight / (yMax - yMin);

                // Draw x-axis
                Line xAxis = new Line();
                xAxis.Stroke = axisBrush;
                xAxis.StrokeThickness = axisThickness;
                xAxis.X1 = xMin * xScale;
                xAxis.Y1 = (0 - yMin) * yScale;
                xAxis.X2 = xMax * xScale;
                xAxis.Y2 = (0 - yMin) * yScale;
                GraphCanvas.Children.Add(xAxis);

                // Draw y-axis
                Line yAxis = new Line();
                yAxis.Stroke = axisBrush;
                yAxis.StrokeThickness = axisThickness;
                yAxis.X1 = (0 - xMin) * xScale;
                yAxis.Y1 = yMax * yScale;
                yAxis.X2 = (0 - xMin) * xScale;
                yAxis.Y2 = yMin * yScale;
                GraphCanvas.Children.Add(yAxis);

                // Plot sine wave
                Path sinePath = new Path();
                sinePath.Stroke = sineBrush;
                sinePath.StrokeThickness = sineThickness;
                PathGeometry sineGeometry = new PathGeometry();
                PathFigure sineFigure = new PathFigure();
                sineFigure.StartPoint = new Point(xMin * xScale, C + (A * Math.Sin(xMin)) + (B * Math.Cos(xMin)));
                for (double x = xMin; x <= xMax; x += 0.01)
                {
                    double y = C + (A * Math.Sin(x)) + (B * Math.Cos(x));
                    sineFigure.Segments.Add(new LineSegment(new Point(x * xScale, y * yScale), true));
                }
                sineGeometry.Figures.Add(sineFigure);
                sinePath.Data = sineGeometry;
                GraphCanvas.Children.Add(sinePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
