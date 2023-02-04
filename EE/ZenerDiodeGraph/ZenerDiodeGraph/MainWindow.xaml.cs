using System;
using System.Windows;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;

namespace ZenerDiodeGraphWPF
{
    public partial class MainWindow : Window
    {
        public PlotModel ZenerDiodeModel { get; set; }

        public MainWindow()
        {
            // init the components, oxy 
            InitializeComponent();
            DataContext = this;
            ZenerDiodeModel = new PlotModel
            {
                Title = "Zener Diode Graph"
            };
            ZenerDiodeModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Title = "Current (A)" });
            ZenerDiodeModel.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, Title = "Voltage (V)" });
        }

        // handler to for the calulate button
        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            double voltage = double.Parse(InputTextBox.Text);
            double current = CalculateZenerDiodeCurrent(voltage);
            ResultLabel.Content = $"Current: {current:0.##} A";
            ZenerDiodeModel.Series.Clear();
            LineSeries zenerDiodeSeries = new LineSeries
            {
                Title = "Zener Diode",
                MarkerType = MarkerType.None
            };
            zenerDiodeSeries.Points.Add(new DataPoint(voltage, current));
            ZenerDiodeModel.Series.Add(zenerDiodeSeries);
            ZenerDiodeModel.InvalidatePlot(true);
        }

        // calculation of the current
        private double CalculateZenerDiodeCurrent(double voltage)
        {
            const double reverseBreakdownVoltage = 6.2;
            const double reverseBreakdownCurrent = 5E-3;
            const double thermalVoltage = 25E-3;
            const double diodeIdealityFactor = 1.5;

            if (voltage <= reverseBreakdownVoltage)
            {
                return 0;
            }

            double saturationCurrent = reverseBreakdownCurrent * Math.Exp(reverseBreakdownVoltage / (diodeIdealityFactor * thermalVoltage) - voltage / (diodeIdealityFactor * thermalVoltage));
            return saturationCurrent;
        }
    }
}
