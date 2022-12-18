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

namespace WpfSerialExample
{
    public partial class MainWindow : Window
    {
        private SerialPort serialPort;  // serial port object

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            if (serialPort == null)
            {
                // create a new serial port object
                serialPort = new SerialPort("COM1", 9600, Parity.None, 8, StopBits.One);

                // set the serial port to read line by line
                serialPort.NewLine = "\n";

                // attach a data received event handler
                serialPort.DataReceived += new SerialDataReceivedEventHandler(SerialPort_DataReceived);

                // open the serial port
                serialPort.Open();

                // change the button text to "Stop"
                button1.Content = "Stop";
            }
            else
            {
                // close the serial port
                serialPort.Close();

                // dispose of the serial port object
                serialPort.Dispose();
                serialPort = null;

                // change the button text to "Start"
                button1.Content = "Start";
            }
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            // read a line of data from the serial port
            string data = serialPort.ReadLine();

            // update the TextBox with the received data
            Dispatcher.Invoke(() => textBox1.Text += data + "\n");
        }
    }
}

