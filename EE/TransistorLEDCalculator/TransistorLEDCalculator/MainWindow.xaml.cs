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

namespace TransistorLEDCalculator
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

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Get input values
                double supplyVoltage = double.Parse(txtSupplyVoltage.Text);
                double ledVoltage = double.Parse(txtLedVoltage.Text);
                double ledCurrent = double.Parse(txtLedCurrent.Text);
                double hfe = double.Parse(txtHfe.Text);

                // Calculate values
                double resistorValue = (supplyVoltage - ledVoltage) / (ledCurrent / 1000.0);
                double baseCurrent = ledCurrent / (hfe * 10);

                // Display results
                MessageBox.Show("Resistor value: " + resistorValue.ToString("0.00") + " ohms" + Environment.NewLine +
                    "Base current: " + baseCurrent.ToString("0.000") + " milliamps", "Calculation Results");

                // Draw graph
                graphCanvas.Children.Clear();

                double xMax = 1.1 * ledVoltage;
                double yMax = 1.1 * ledCurrent;

                // Draw X and Y axis
                Line xAxis = new Line();
                xAxis.Stroke = Brushes.Black;
                xAxis.StrokeThickness = 1;
                xAxis.X1 = 0;
                xAxis.Y1 = graphCanvas.Height;
                xAxis.X2 = graphCanvas.Width;
                xAxis.Y2 = graphCanvas.Height;
                graphCanvas.Children.Add(xAxis);

                Line yAxis = new Line();
                yAxis.Stroke = Brushes.Black;
                yAxis.StrokeThickness = 1;
                yAxis.X1 = 0;
                yAxis.Y1 = 0;
                yAxis.X2 = 0;
                yAxis.Y2 = graphCanvas.Height;
                graphCanvas.Children.Add(yAxis);

                // Draw LED characteristic curve
                Polyline ledCurve = new Polyline();
                ledCurve.Stroke = Brushes.Red;
                ledCurve.StrokeThickness = 2;
                for (double x = 0; x <= ledVoltage; x += 0.01)
                {
                    double y = ledCurrent * Math.Exp((x - ledVoltage) / 0.025);
                    ledCurve.Points.Add(new Point(x / xMax * graphCanvas.Width, (yMax - y) / yMax * graphCanvas.Height));
                }
                graphCanvas.Children.Add(ledCurve);

                // Draw transistor characteristic curve
                Polyline transistorCurve = new Polyline();
                transistorCurve.Stroke = Brushes.Blue;
                transistorCurve.StrokeThickness = 2;
                for (double x = 0; x <= baseCurrent * hfe; x += 0.01)
                {
                    double y = x * Math.Exp((supplyVoltage - ledVoltage) / (0.025 * baseCurrent));
                    transistorCurve.Points.Add(new Point((ledVoltage + x) / xMax * graphCanvas.Width, (yMax - y) / yMax * graphCanvas.Height));
                }
                graphCanvas.Children.Add(transistorCurve);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }   
        }
    }
}