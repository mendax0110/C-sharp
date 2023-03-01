using System;
using System.ComponentModel;
using System.Windows;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;

namespace NpnPnpAmp
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private PlotModel _plotModel;

        private string _transistorType;
        public string TransistorType
        {
            get { return _transistorType; }
            set { _transistorType = value; OnPropertyChanged("TransistorType"); }
        }

        private double _inputVoltage;
        public double InputVoltage
        {
            get { return _inputVoltage; }
            set { _inputVoltage = value; OnPropertyChanged("InputVoltage"); }
        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            PlotModel = new PlotModel();
            InputVoltage = 10.0; // increase the input voltage value
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private PlotModel CreatePlotModel()
        {
            var plotModel = new PlotModel();
            plotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, Title = "Input Voltage (V)" });
            plotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Title = "Output Voltage (V)" });

            double voltageMax = 5.0; // maximum output voltage
            double gain = 100.0; // amplifier gain
            double cutoff = 0.7; // cutoff voltage of the transistor

            if (TransistorType == "NPN")
            {
                for (double x = 0.0; x <= InputVoltage; x += 0.01)
                {
                    double y = Math.Max(Math.Min((x - cutoff) * gain, voltageMax), 0.0);
                    plotModel.Series.Add(new LineSeries { Title = "NPN", MarkerType = MarkerType.None, LineStyle = LineStyle.Solid, StrokeThickness = 1, Color = OxyColors.Blue, Points = { new DataPoint(x, y) } });
                }
            }
            else if (TransistorType == "PNP")
            {
                for (double x = 0.0; x <= InputVoltage; x += 0.01)
                {
                    double y = Math.Max(Math.Min((cutoff - x) * gain, voltageMax), 0.0);
                    plotModel.Series.Add(new LineSeries { Title = "PNP", MarkerType = MarkerType.None, LineStyle = LineStyle.Solid, StrokeThickness = 1, Color = OxyColors.Red, Points = { new DataPoint(x, y) } });
                }
            }

            return plotModel;
        }


        private void OnGenerateButtonClicked(object sender, RoutedEventArgs e)
        {
            PlotModel = CreatePlotModel();
            OnPropertyChanged("PlotModel");
        }



        public PlotModel PlotModel
        {
            get { return _plotModel; }
            set { _plotModel = value; OnPropertyChanged("PlotModel"); }
        }
    }
}
