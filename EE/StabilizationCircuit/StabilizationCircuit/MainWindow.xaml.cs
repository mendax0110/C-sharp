using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using OxyPlot;
using OxyPlot.Series;

namespace StabilizationCircuit
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private double _r1;
        private double _vcc;
        private List<DataPoint> _stabilizationData;

        public event PropertyChangedEventHandler PropertyChanged;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        public double R1
        {
            get => _r1;
            set
            {
                _r1 = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(R1)));
                UpdateStabilizationCurve();
            }
        }

        public double Vcc
        {
            get => _vcc;
            set
            {
                _vcc = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Vcc)));
                UpdateStabilizationCurve();
            }
        }

        public List<DataPoint> StabilizationData
        {
            get => _stabilizationData;
            set
            {
                _stabilizationData = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(StabilizationData)));
            }
        }

        private void UpdateStabilizationCurve()
        {
            // Get the values of R1 and Vcc from the text boxes
            var R1 = double.Parse(R1TextBox.Text);
            var Vcc = double.Parse(VccTextBox.Text);

            // Calculate the stabilization curve
            var stabilizationData = new List<DataPoint>();
            var vbe = 0.7; // Base-emitter voltage of the transistor
            var beta = 100; // DC current gain of the transistor

            for (double vce = 0; vce <= Vcc; vce += 0.1)
            {
                var ic = (Vcc - vce) / R1;
                var vceSaturation = Vcc - ic * R1;
                var vceClamped = Math.Max(vce, vceSaturation);
                var icSaturation = (Vcc - vbe) / (beta * R1);
                var icClamped = Math.Max(ic, icSaturation);
                stabilizationData.Add(new DataPoint(vceClamped, icClamped * 1000));
            }

            // Update the plot
            StabilizationData = stabilizationData;
        }

        private void R1TextBox_TextChanged(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(R1TextBox.Text, out double value))
            {
                R1 = value;
            }
        }

        private void VccTextBox_TextChanged(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(VccTextBox.Text, out double value))
            {
                Vcc = value;
            }
        }

        private void UpdateStabilizationCurveButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateStabilizationCurve();
        }
    }
}
