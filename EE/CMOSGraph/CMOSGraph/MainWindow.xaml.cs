using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace CMOSGraph
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Draw the graph
            DrawGraph();
        }

        private void DrawGraph()
        {
            // Create a canvas to draw on
            Canvas canvas = new Canvas();
            canvas.Width = 400;
            canvas.Height = 300;
            canvas.Margin = new Thickness(20);

            // Add the canvas to the window
            mainGrid.Children.Add(canvas);

            // Create a list to hold the data points
            List<Point> points = new List<Point>();

            // Calculate the data points for the NMOS transistor
            for (double x = 0; x <= 15; x += 0.1)
            {
                double y = 15 * Math.Pow((1 - Math.Exp(-x / 5)), 2);
                points.Add(new Point(x * 20, (15 - y) * 20));
            }

            // Draw the line for the NMOS transistor
            Polyline polylineNMOS = new Polyline();
            polylineNMOS.Points = new PointCollection(points);
            polylineNMOS.Stroke = Brushes.Blue;
            polylineNMOS.StrokeThickness = 2;
            canvas.Children.Add(polylineNMOS);

            // Clear the list of data points
            points.Clear();

            // Calculate the data points for the PMOS transistor
            for (double x = 0; x <= 15; x += 0.1)
            {
                double y = 15 * Math.Pow((1 - Math.Exp((x - 15) / 5)), 2);
                points.Add(new Point(x * 20, (15 - y) * 20));
            }

            // Draw the line for the PMOS transistor
            Polyline polylinePMOS = new Polyline();
            polylinePMOS.Points = new PointCollection(points);
            polylinePMOS.Stroke = Brushes.Red;
            polylinePMOS.StrokeThickness = 2;
            canvas.Children.Add(polylinePMOS);

            // Draw the axes
            Line xAxis = new Line();
            xAxis.X1 = 0;
            xAxis.Y1 = 300;
            xAxis.X2 = 400;
            xAxis.Y2 = 300;
            xAxis.Stroke = Brushes.Black;
            xAxis.StrokeThickness = 2;
            canvas.Children.Add(xAxis);

            Line yAxis = new Line();
            yAxis.X1 = 0;
            yAxis.Y1 = 0;
            yAxis.X2 = 0;
            yAxis.Y2 = 300;
            yAxis.Stroke = Brushes.Black;
            yAxis.StrokeThickness = 2;
            canvas.Children.Add(yAxis);

            // Label the axes
            for (int i = 0; i <= 15; i++)
            {
                TextBlock labelX = new TextBlock();
                labelX.Text = i.ToString();
                labelX.Margin = new Thickness(i * 20 - 5, 305, 0, 0);
                canvas.Children.Add(labelX);

                TextBlock labelY = new TextBlock();
                labelY.Text = (15 - i).ToString();
                labelY.Margin = new Thickness(-25, i * 20 - 5, 0, 0);
                canvas.Children.Add(labelY);
            }
        }
    }
}
