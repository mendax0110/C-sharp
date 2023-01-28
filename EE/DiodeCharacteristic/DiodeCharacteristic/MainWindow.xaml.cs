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

// simple diode characteristic calculator
namespace DiodeCharacteristic
{
    public partial class MainWindow : Window
    {
        // constructor
        public MainWindow()
        {
            InitializeComponent();
        }

        // calculate button click event handler
        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            double current = double.Parse(CurrentInput.Text);
            double forwardVoltage = 0.7 + (0.01 * Math.Log(current));
            ForwardVoltageOutput.Text = forwardVoltage.ToString();

            // Add a point to the graph
            Point point = new Point(current, forwardVoltage);
            DrawPoint(point);
        }

        // draw a point on the graph
        private void DrawPoint(Point point)
        {
            Ellipse ellipse = new Ellipse();
            ellipse.Width = 5;
            ellipse.Height = 5;
            ellipse.Fill = Brushes.Red;

            Canvas.SetLeft(ellipse, point.X * 50);
            Canvas.SetTop(ellipse, point.Y * 50);

            GraphCanvas.Children.Add(ellipse);
        }
    }
}
