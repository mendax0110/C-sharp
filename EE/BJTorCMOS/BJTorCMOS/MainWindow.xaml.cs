using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace BJTorCMOS
{
    public partial class MainWindow : Window
    {
        private const double ScaleX = 50;
        private const double ScaleY = -100;
        private const double OriginX = 200;
        private const double OriginY = 200;

        private double Vt;
        private double Beta;

        public MainWindow()
        {
            InitializeComponent();
            Vt = 0.026;
            Beta = 100;
        }

        private void PlotCurve(double[] x, double[] y, Brush color)
        {
            for (int i = 0; i < x.Length - 1; i++)
            {
                Line line = new Line
                {
                    X1 = OriginX + x[i] * ScaleX,
                    Y1 = OriginY + y[i] * ScaleY,
                    X2 = OriginX + x[i + 1] * ScaleX,
                    Y2 = OriginY + y[i + 1] * ScaleY,
                    StrokeThickness = 2,
                    Stroke = color
                };
                canvas.Children.Add(line);
            }
        }

        private void PlotTransistorCharacteristic(double V1, double V2, double IcSat, double IbSat)
        {
            canvas.Children.Clear();

            double[] Vbe = new double[101];
            double[] Ic = new double[101];

            for (int i = 0; i <= 100; i++)
            {
                double VbeValue = V1 + (V2 - V1) * i / 100.0;
                double IcValue = 0;

                if (BJT.IsChecked == true)
                {
                    if (VbeValue < 0)
                    {
                        IcValue = 0;
                    }
                    else if (VbeValue < Vt * Math.Log(IcSat / IbSat + 1))
                    {
                        IcValue = IcSat * (Math.Exp(VbeValue / (Beta * Vt)) - 1);
                    }
                    else
                    {
                        IcValue = IcSat * (Math.Exp(VbeValue / (Beta * Vt)) - Math.Exp(Vt * (IcSat / (Beta * IbSat))));
                    }
                }
                else
                {
                    if (VbeValue <= Vt * Math.Log(IcSat / IbSat))
                    {
                        IcValue = IbSat * Math.Exp(VbeValue / Vt);
                    }
                    else
                    {
                        IcValue = IcSat * (1 - Math.Exp(-(VbeValue - Vt * Math.Log(IcSat / IbSat)) / (Beta * Vt)));
                    }
                }

                Vbe[i] = VbeValue;
                Ic[i] = IcValue;
            }

            PlotCurve(Vbe, Ic, Brushes.Red);
        }

        private void Voltage_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                double voltage = 0;
                if (!string.IsNullOrEmpty(Voltage.Text) && double.TryParse(Voltage.Text, out voltage))
                {
                    double IcSat = double.Parse(IcSaturation?.Text ?? "0");
                    double IbSat = IcSat / Beta;
                    double V1 = -5;
                    double V2 = 5;

                    PlotTransistorCharacteristic(V1, V2, IcSat, IbSat);
                }
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void Current_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                double current = 0;
                if (!string.IsNullOrEmpty(Current.Text) && double.TryParse(Current.Text, out current))
                {
                    double IcSat = double.Parse(IcSaturation.Text);
                    double IbSat = IcSat / Beta;
                    double V1 = -0.7;
                    double V2 = 1.5;
                    PlotTransistorCharacteristic(V1, V2, IcSat, IbSat);
                }
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void BJT_Checked(object sender, RoutedEventArgs e)
        {
            Beta = 100;
        }

        private void MOSFET_Checked(object sender, RoutedEventArgs e)
        {
            Beta = 0;
        }
    }
}