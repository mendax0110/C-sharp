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
using System.Windows.Shapes;

namespace Coils
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Point> currentCurvePoints;

        public MainWindow()
        {
            InitializeComponent();
            currentCurvePoints = new List<Point>();
        }

        // Tau = L / R
        private double CalculateTau(double L, double R)
        {
            return L / R;
        }

        // i = U/R * (1 - e^(t/Tau))
        private double CalculateCurrent(double U, double R, double t, double Tau)
        {
            return U / R * (1 - Math.Exp(-t / Tau));
        }

        private void CalculateCurrentCurve_Click(object sender, RoutedEventArgs e)
        {
            // Error handling for input validation
            if (!double.TryParse(L.Text, out double LValue) || LValue <= 0)
            {
                MessageBox.Show("Please enter a valid positive value for L.", "Error");
                return;
            }

            if (!double.TryParse(R.Text, out double RValue) || RValue <= 0)
            {
                MessageBox.Show("Please enter a valid positive value for R.", "Error");
                return;
            }

            if (!double.TryParse(U.Text, out double UValue) || UValue <= 0)
            {
                MessageBox.Show("Please enter a valid positive value for U.","Error");
                return;
            }

            currentCurvePoints.Clear();

            double Tau = CalculateTau(LValue, RValue);

            for (double t = 0; t <= 10; t += 0.1)
            {
                double current = CalculateCurrent(UValue, RValue, t, Tau);
                currentCurvePoints.Add(new Point(t, current));
            }

            DrawCurrentCurveCalc(DrawCurrentCurve.ActualWidth, DrawCurrentCurve.ActualHeight);

            // Clear previous items in the ListBox
            OutputTauAndCurrent.Items.Clear();

            // Add Tau value
            OutputTauAndCurrent.Items.Add($"Tau = {Tau}");

            // Add Current values
            OutputTauAndCurrent.Items.Add("Current values:");
            foreach (var point in currentCurvePoints)
            {
                OutputTauAndCurrent.Items.Add($"t = {point.X}, I = {point.Y}");
            }
        }

        private void DrawCurrentCurveCalc(double canvasWidth, double canvasHeight)
        {
            OutputTauAndCurrent.Items.Clear();
            DrawCurrentCurve.Children.Clear();

            double maxX = currentCurvePoints.Max(p => p.X);
            double maxY = Math.Max(currentCurvePoints.Max(p => p.Y), Math.Abs(currentCurvePoints.Min(p => p.Y)));

            double xScale = canvasWidth / (2 * maxX);
            double yScale = canvasHeight / (2 * maxY);

            // Draw X-axis
            double xAxisY = canvasHeight / 2;
            DrawLine(0, xAxisY, canvasWidth, xAxisY, Brushes.Black);
            DrawText(canvasWidth, xAxisY + 10, "t (s)", Brushes.Black);

            // Draw Y-axis
            double yAxisX = canvasWidth / 2;
            DrawLine(yAxisX, 0, yAxisX, canvasHeight, Brushes.Black);
            DrawText(yAxisX - 30, 0, "I (mA)", Brushes.Black);

            // Draw current curve
            for (int i = 0; i < currentCurvePoints.Count - 1; i++)
            {
                double x1 = (currentCurvePoints[i].X * xScale) + yAxisX;
                double y1 = (-currentCurvePoints[i].Y * yScale) + xAxisY;
                double x2 = (currentCurvePoints[i + 1].X * xScale) + yAxisX;
                double y2 = (-currentCurvePoints[i + 1].Y * yScale) + xAxisY;

                DrawLine(x1, y1, x2, y2, Brushes.Red);
            }
        }

        private void DrawLine(double x1, double y1, double x2, double y2, Brush color)
        {
            Line line = new Line
            {
                X1 = x1,
                Y1 = y1,
                X2 = x2,
                Y2 = y2,
                Stroke = color,
                StrokeThickness = 1
            };

            DrawCurrentCurve.Children.Add(line);
        }

        private void DrawText(double x, double y, string text, Brush color)
        {
            TextBlock textBlock = new TextBlock
            {
                Text = text,
                Foreground = color,
                FontSize = 12,
                RenderTransform = new TranslateTransform(x, y)
            };

            DrawCurrentCurve.Children.Add(textBlock);
        }

        private void L_TextChanged(object sender, TextChangedEventArgs e)
        {
            // No need to clear the current curve here
        }

        private void R_TextChanged(object sender, TextChangedEventArgs e)
        {
            // No need to clear the current curve here
        }

        private void U_TextChanged(object sender, TextChangedEventArgs e)
        {
            // No need to clear the current curve here
        }

        private void OutputTauAndCurrent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
