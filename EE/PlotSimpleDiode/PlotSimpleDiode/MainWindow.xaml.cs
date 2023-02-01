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
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;

namespace DiodeCurvePlotter
{
    public partial class MainWindow : Window
    {
        private PlotModel plotModel;

        public MainWindow()
        {
            InitializeComponent();

            // Create the plot model
            plotModel = new PlotModel { Title = "Diode Curve" };
            plotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, Title = "Voltage (V)" });
            plotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Title = "Current (A)" });

            // Create the diode curve
            var diodeCurve = new LineSeries
            {
                MarkerType = MarkerType.Circle,
                MarkerSize = 4,
                MarkerStroke = OxyColors.White
            };

            // Calculate the diode curve points
            for (double voltage = 0; voltage <= 0.7; voltage += 0.01)
            {
                var current = CalculateDiodeCurrent(voltage);
                diodeCurve.Points.Add(new DataPoint(voltage, current));
            }

            plotModel.Series.Add(diodeCurve);
            DataContext = plotModel;
        }

        // Calculate the diode current for a given voltage
        private double CalculateDiodeCurrent(double voltage)
        {
            // Insert your own diode current equation here
            return Math.Max(0, (voltage - 0.7) / 1000);
        }
    }
}
