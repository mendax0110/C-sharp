using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ATMEGA2560Serial
{
    public partial class MainWindow : Window
    {
        SerialPort serialPort;

        public MainWindow()
        {
            InitializeComponent();
            PopulateSerialPorts();
        }

        private void PopulateSerialPorts()
        {
            string[] ports = SerialPort.GetPortNames();
            ports_combobox.ItemsSource = ports;
        }

        private void ports_combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (serialPort != null && serialPort.IsOpen)
            {
                serialPort.Close();
            }

            if (ports_combobox.SelectedItem != null)
            {
                string portName = ports_combobox.SelectedItem.ToString();
                serialPort = new SerialPort(portName, 9600);
            }
        }

        private void connectSerial_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (serialPort != null && !serialPort.IsOpen)
                {
                    serialPort.Open();
                    serialPort.DataReceived += new SerialDataReceivedEventHandler(serialPort_DataReceived);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void disconnectSerial_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (serialPort != null && serialPort.IsOpen)
                {
                    serialPort.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void saveDataSerial_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (serialPort != null && serialPort.IsOpen)
                {
                    string fileName = "SerialData_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";
                    using (StreamWriter sw = new StreamWriter(fileName))
                    {
                        sw.Write(serialPort.ReadExisting());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string data = serialPort.ReadExisting();
            this.Dispatcher.Invoke(() =>
            {
                // Display the incoming data in a text box
                serialData.Text += data;
            });
        }
    }
}
