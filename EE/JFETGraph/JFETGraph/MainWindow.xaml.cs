using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using LiveCharts;
using LiveCharts.Helpers;
using LiveCharts.Wpf;

namespace JFETGraph
{
    public partial class MainWindow : Window
    {
        private List<double> transferVgsList = new List<double>();
        private List<double> transferIdList = new List<double>();
        private List<double> drainVdsList = new List<double>();
        private List<double> drainIdList = new List<double>();

        public MainWindow()
        {
            // init the content of the window
            InitializeComponent();
            DataContext = this;

            LoadDataFromFile("");

            TransferChart.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Transfer Characteristics",
                    Values = transferIdList.AsChartValues(),
                }
            };

            DrainChart.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Drain Characteristics",
                    Values = drainIdList.AsChartValues(),
                }
            };
        }

        // load the data from the file
        private void LoadDataFromFile(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                bool transferDataStarted = false;
                bool drainDataStarted = false;
     
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.StartsWith("vgs"))
                    {
                        transferDataStarted = true;
                        drainDataStarted = false;
                        continue;
                    }
                    else if (line.StartsWith("vds"))
                    {
                        transferDataStarted = false;
                        drainDataStarted = true;
                        continue;
                    }
                    else if (line.StartsWith(".endc"))
                    {
                        transferDataStarted = false;
                        drainDataStarted = false;
                        continue;
                    }

                    if (transferDataStarted)
                    {
                        string[] parts = line.Split('\t');
                        if (parts.Length == 2)
                        {
                            double vgs = double.Parse(parts[0]);
                            double id = double.Parse(parts[1]);
                            transferVgsList.Add(vgs);
                            transferIdList.Add(id);
                        }
                    }
                    else if (drainDataStarted)
                    {
                        string[] parts = line.Split('\t');
                        if (parts.Length == 2)
                        {
                            double vds = double.Parse(parts[0]);
                            double id = double.Parse(parts[1]);
                            drainVdsList.Add(vds);
                            drainIdList.Add(id);
                        }
                    }
                }
            }
        }
    }
}
