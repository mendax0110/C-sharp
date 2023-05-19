using System;
using System.Security.Cryptography;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace MOSFET_Curves
{
    public partial class MainWindow : Window
    {
        private const int canvasWidth = 400;    // Canvas width in pixels
        private const int canvasHeight = 300;   // Canvas height in pixel
        private const double xScale = 30;   // Scale factor for x-axis
        private const double yScale = 30;   // Scale factor for y-axis

        private Polyline vdsCurve;  // Polyline for Vds curve
        private Polyline idCurve;   // Polyline for Id curve

        // Constructor
        public MainWindow()
        {
            InitializeComponent();

            // Draw x-axis
            vdsCurve = new Polyline();
            vdsCurve.Stroke = Brushes.Blue;
            GraphCanvas.Children.Add(vdsCurve);

            // Draw y-axis
            idCurve = new Polyline();
            idCurve.Stroke = Brushes.Red;
            GraphCanvas.Children.Add(idCurve);

            UpdateGraph();
        }

        // update graph handler
        private void UpdateGraph()
        {
            try
            {
                // Check if the canvas has been initialized
                if (vdsCurve != null && idCurve != null)
                {
                    vdsCurve.Points.Clear();
                    idCurve.Points.Clear();

                    double vgs = VgsSlider.Value;
                    double vdsMax = VdsSlider.Value;

                    // Calculate points
                    for (double vds = 0; vds <= vdsMax; vds += 0.1)
                    {
                        double id = CalculateId(vgs, vds);
                        vdsCurve.Points.Add(new Point(vds * xScale, canvasHeight - id * yScale));
                        idCurve.Points.Add(new Point(vds * xScale, canvasHeight - vds * yScale));
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        // Calculate Id
        private double CalculateId(double vgs, double vds)
        {
            double vth = 2;
            double k = 0.5;
            double lambda = 0.1;
            double id = 0;

            // Calculate Id
            try
            {
                if (vgs < vth)
                {
                    id = 0;
                }
                else if (vds < vgs - vth)
                {
                    id = k * (vgs - vth - vds / 2) * vds;
                }
                else
                {
                    id = k / 2 * (vgs - vth) * (vgs - vth) * (1 + lambda * vds);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

            return id;
        }

        // handler for slider vgs
        private void VgsSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            UpdateGraph();
        }

        // handler for slider vds
        private void VdsSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            UpdateGraph();
        }
    }
}