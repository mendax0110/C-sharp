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

namespace UnitCircleSineWave
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            pointerLine.RenderTransform = null;
        }

        private void UnitCircleCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            // Get the current position of the mouse
            Point mousePos = e.GetPosition(unitCircleCanvas);

            // Calculate the angle of the mouse position relative to the center of the unit circle
            double angle = Math.Atan2(mousePos.Y - unitCircleCanvas.Height / 2, mousePos.X - unitCircleCanvas.Width / 2);

            // Get the existing RotateTransform object or create a new one if it doesn't exist
            RotateTransform? rotateTransform = pointerLine.RenderTransform as RotateTransform;
            if (rotateTransform == null)
            {
                rotateTransform = new RotateTransform();
                pointerLine.RenderTransform = rotateTransform;
            }

            // Modify the Angle property of the RotateTransform object
            rotateTransform.Angle = angle * 180 / Math.PI;

            // Clear the previous sine wave points
            sineWavePoints.Clear();

            // Generate the new sine wave points
            for (int i = 0; i < unitCircleCanvas.Width; i++)
            {
                // Calculate the angle of the current point
                double pointAngle = i * 2 * Math.PI / unitCircleCanvas.Width;

                // Calculate the y coordinate of the current point
                double y = Math.Sin(pointAngle - angle) * unitCircleCanvas.Height / 2;

                // Add the point to the list
                sineWavePoints.Add(new Point(i, y + unitCircleCanvas.Height / 2));
            }

            // Redraw the sine wave
            sineWavePolyline.Points = sineWavePoints;
        }

        private PointCollection sineWavePoints = new PointCollection();
    }
}