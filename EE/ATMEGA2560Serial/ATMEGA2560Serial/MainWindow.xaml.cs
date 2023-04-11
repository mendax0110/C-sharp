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
        // Create a new SerialPort object
        SerialPort serialPort;

        // Constructor and initialize the serial ports combobox
        public MainWindow()
        {
            InitializeComponent();
            PopulateSerialPorts();
        }

        // Populate the serial ports combobox
        private void PopulateSerialPorts()
        {
            string[] ports = SerialPort.GetPortNames();
            ports_combobox.ItemsSource = ports;
        }

        // When the user selects a port, create a new SerialPort object
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

        // Connect to the serial port, and open the port
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

        // Disconnect from the serial port, and close the port
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

        // Send data to the serial port, and display it in the text box
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

        // Display the incoming data in a text box, and scroll to the bottom
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