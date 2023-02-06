using System;
using System.Windows;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.Wpf;
using LineSeries = OxyPlot.Series.LineSeries;

namespace ACResistanceDiodeCircuit
{
    public partial class MainWindow : Window
    {
        private PlotModel plotModel;

        public MainWindow()
        {
            InitializeComponent();
            plotModel = new PlotModel { Title = "Circuit Resistance" };
            plotModel.Axes.Add(new OxyPlot.Axes.LinearAxis { Position = AxisPosition.Bottom, Title = "Diode Voltage Drop (Vd)" });
            plotModel.Axes.Add(new OxyPlot.Axes.LinearAxis { Position = AxisPosition.Left, Title = "Circuit Resistance (Rc)" });
        }

        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            double diodeVoltageDrop = double.Parse(DiodeVoltageDropTextBox.Text);
            double resistorValue = double.Parse(ResistorValueTextBox.Text);

            double circuitResistance = resistorValue + (1 / (2 * Math.PI * Math.Sqrt(diodeVoltageDrop)));
            CircuitResistanceTextBlock.Text = circuitResistance.ToString();

            LineSeries series = new LineSeries { MarkerType = MarkerType.Circle };
            series.Points.Add(new DataPoint(diodeVoltageDrop, circuitResistance));
            _ = new OxyPlot.PlotModel();
        }
    }
}
