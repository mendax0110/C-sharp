using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.IO.Ports;
using System.IO;

namespace SerialLogicAnalyzer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                // get the COM ports with switch case statement
                switch (COMPORTS.SelectedIndex)
                {
                    case 0:
                        // connect to the selected port
                        System.IO.Ports.SerialPort port = new System.IO.Ports.SerialPort();
                        port.PortName = "COM1";
                        port.BaudRate = 9600;
                        port.Parity = Parity.None;
                        port.DataBits = 8;
                        port.StopBits = StopBits.One;
                        port.Handshake = Handshake.None;
                        port.RtsEnable = true;
                        port.DtrEnable = true;
                        port.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
                        break;
                    case 1:
                        // get the COM ports
                        System.IO.Ports.SerialPort port1 = new System.IO.Ports.SerialPort();
                        port1.PortName = "COM2";
                        port1.BaudRate = 9600;
                        port1.Parity = Parity.None;
                        port1.DataBits = 8;
                        port1.StopBits = StopBits.One;
                        port1.Handshake = Handshake.None;
                        port1.RtsEnable = true;
                        port1.DtrEnable = true;
                        port1.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
                        break;
                    case 2:
                        // get the COM ports
                        System.IO.Ports.SerialPort port2 = new System.IO.Ports.SerialPort();
                        port2.PortName = "COM2";
                        port2.BaudRate = 9600;
                        port2.Parity = Parity.None;
                        port2.DataBits = 8;
                        port2.StopBits = StopBits.One;
                        port2.Handshake = Handshake.None;
                        port2.RtsEnable = true;
                        port2.DtrEnable = true;
                        port2.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
                        break;
                    case 3:
                        // get the COM ports
                        System.IO.Ports.SerialPort port3 = new System.IO.Ports.SerialPort();
                        port3.PortName = "COM2";
                        port3.BaudRate = 9600;
                        port3.Parity = Parity.None;
                        port3.DataBits = 8;
                        port3.StopBits = StopBits.One;
                        port3.Handshake = Handshake.None;
                        port3.RtsEnable = true;
                        port3.DtrEnable = true;
                        port3.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
                        break;
                    case 4:
                        // get the COM ports
                        System.IO.Ports.SerialPort port4 = new System.IO.Ports.SerialPort();
                        port4.PortName = "COM2";
                        port4.BaudRate = 9600;
                        port4.Parity = Parity.None;
                        port4.DataBits = 8;
                        port4.StopBits = StopBits.One;
                        port4.Handshake = Handshake.None;
                        port4.RtsEnable = true;
                        port4.DtrEnable = true;
                        port4.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
                        break;
                    case 5:
                        // get the COM ports
                        System.IO.Ports.SerialPort port5 = new System.IO.Ports.SerialPort();
                        port5.PortName = "COM2";
                        port5.BaudRate = 9600;
                        port5.Parity = Parity.None;
                        port5.DataBits = 8;
                        port5.StopBits = StopBits.One;
                        port5.Handshake = Handshake.None;
                        port5.RtsEnable = true;
                        port5.DtrEnable = true;
                        port5.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
                        break;
                    default:
                        MessageBox.Show("Please select a COM port", "Error");
                        break;

                }
            }
            catch
            {
                MessageBox.Show("Error opening selected COM Port", "Error");
            }
        }

        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            // get the data from the COM port
            SerialPort sp = (SerialPort)sender;
            string indata = sp.ReadExisting();
            this.Dispatcher.Invoke(new Action(() => LOG.Text += indata));
        }

        private void Connect_Click(object sender, RoutedEventArgs e)
        {
            // check which combox item is selected
           
        }

        private void Disconnect_Click_1(object sender, RoutedEventArgs e)
        {
            // disconnect from the selected port
            if (COMPORTS != null)
            {
                // disconnect from the selected port
            }
            else
            {
                // show error message
            }

        }

        private void clear_Click(object sender, RoutedEventArgs e)
        {
            // clear the LOG textbox
            if (LOG != null)
            {
                // clear the LOG textbox
            }
            else
            {
                // show error message
            }


        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            // save the LOG textbox to a file
            if(LOG != null)
            {
                // save the LOG textbox to a file
            }
            else
            {
                // show error message
            }
        }

        private void load_Click(object sender, RoutedEventArgs e)
        {
            // load the LOG textbox from a file
            if (LOG != null)
            {
                // load the LOG textbox from a file
            }
            else
            {
                // show error message
            }

        }

        private void help_Click(object sender, RoutedEventArgs e)
        {
            // show help message
            if (LOG != null)
            {
                // show help message
            }
            else
            {
                // show error message
            }
        }

        private void LOG_TextChanged(object sender, TextChangedEventArgs e)
        {
            // show the LOG textbox
            if (LOG != null)
            {
                // show the LOG textbox
            }
            else
            {
                // show error message
            }
        }
    }
}
