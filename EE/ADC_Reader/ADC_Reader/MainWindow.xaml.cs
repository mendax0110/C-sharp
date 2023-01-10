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
using System.IO.Ports;

namespace ADC_Reader
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SerialPort serialPort;
        string receivedData;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public MainWindow()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            InitializeComponent();
            serialPort = new SerialPort();
            serialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
        }

        // Connection Button
        private void ConnectButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                serialPort.PortName = PortTextBox.Text;
                serialPort.BaudRate = 9600;
                serialPort.Open();
                ConnectButton.IsEnabled = false;
                DisconnectButton.IsEnabled = true;
                MessageBox.Show("Successfully connected to " + PortTextBox.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        // Disconnection Button
        private void DisconnectButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                serialPort.Close();
                ConnectButton.IsEnabled = true;
                DisconnectButton.IsEnabled = false;
                MessageBox.Show("Successfully disconnected from " + PortTextBox.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        // Handler to Receive Data
        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            receivedData = sp.ReadLine();
            Dispatcher.Invoke(() =>
            {
                VoltageTextBox.Text = receivedData;
            });
        }

        // Request Button 
        private void RequestButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                serialPort.WriteLine("REQ");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        // Menue to select the Measurment Item
        private void MeasurementMenuItem_Click(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = (MenuItem)sender;
            string command = menuItem.Tag.ToString();
            try
            {
                serialPort.WriteLine(command);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}