using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;

namespace LTSpiceAnalyzer
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private List<DataPoint> dataPoints;

        public List<DataPoint> DataPoints
        {
            get { return dataPoints; }
            set
            {
                dataPoints = value;
                OnPropertyChanged("DataPoints");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            DataPoints = new List<DataPoint>();
        }

        private void LoadDataButton_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".txt";
            dlg.Filter = "LTspice files (*.cir;*.net;*.sp)|*.cir;*.net;*.sp|All files (*.*)|*.*";

            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                string filename = dlg.FileName;
                LoadDataFromFile(filename);
            }
        }

        private void LoadDataFromFile(string filename)
        {
            string[] lines = File.ReadAllLines(filename);
            DataPoints.Clear();

            foreach (string line in lines)
            {
                string[] fields = line.Split('\t');
                double x, y;

                if (fields.Length == 2 && double.TryParse(fields[0], out x) && double.TryParse(fields[1], out y))
                {
                    DataPoints.Add(new DataPoint(x, y));
                }
            }

            PlotModel plotModel = new PlotModel();
            plotModel.Title = "LTspice Data";
            plotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, Title = "Time (s)" });
            plotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Title = "Voltage (V)" });
            plotModel.Series.Add(new LineSeries { ItemsSource = DataPoints });

            PlotView.Model = plotModel;
        }

        private void ClearDataButton_Click(object sender, RoutedEventArgs e)
        {
            DataPoints.Clear();
            PlotView.Model = null;
        }
    }
}
