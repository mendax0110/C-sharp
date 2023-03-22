using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SerialLogicAnalyzer
{
    public partial class MainWindow : Window
    {
        SerialPort port;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                // Check which COM port is selected
                ComboBox comboBox = (ComboBox)sender;
                ComboBoxItem selectedItem = (ComboBoxItem)comboBox.SelectedItem;
                string portName = selectedItem.Content.ToString();

                // Disconnect from any previously open port
                if (port != null && port.IsOpen)
                {
                    port.DataReceived -= new SerialDataReceivedEventHandler(port_DataReceived);
                    port.Close();
                }

                // Connect to the selected port
                port = new SerialPort(portName, 9600, Parity.None, 8, StopBits.One);
                port.Handshake = Handshake.None;
                port.RtsEnable = true;
                port.DtrEnable = true;
                port.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
                port.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening selected COM Port: " + ex.Message, "Error");
            }
        }

        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            // Get the data from the COM port
            SerialPort sp = (SerialPort)sender;
            string indata = sp.ReadExisting();

            // Update the LOG textbox on the UI thread
            Dispatcher.Invoke(new Action(() => LOG.Text += indata));
        }

        private void Connect_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Connect to the selected port if not already connected
                if (port != null && !port.IsOpen)
                {
                    port.Open();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting selected COM Port: " + ex.Message, "Error");
            }
        }

        private void Disconnect_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Disconnect from the selected port
                if (port != null && port.IsOpen)
                {
                    port.DataReceived -= new SerialDataReceivedEventHandler(port_DataReceived);
                    port.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error disconnecting selected COM Port: " + ex.Message, "Error");
            }
        }

        private void clear_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Clear the LOG textbox
                LOG.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Logging output: " + ex.Message, "Error");
            }
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            // Save the LOG textbox to a file
            if (LOG.Text.Length > 0)
            {
                Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
                dlg.FileName = "SerialLog";
                dlg.DefaultExt = ".txt";
                dlg.Filter = "Text documents (.txt)|*.txt";

                Nullable<bool> result = dlg.ShowDialog();
                if (result == true)
                {
                    string filename = dlg.FileName;
                    using (StreamWriter writer = new StreamWriter(filename))
                    {
                        writer.Write(LOG.Text);
                    }
                }
            }
            else
            {
                MessageBox.Show("LOG is empty, nothing to save", "Error");
            }
        }

        private void load_Click(object sender, RoutedEventArgs e)
        {
            // Load a LOG file into the LOG textbox
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = "SerialLog";
            dlg.DefaultExt = ".txt";
            dlg.Filter = "Text documents (.txt)|*.txt";

            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                string filename = dlg.FileName;
                using (StreamReader reader = new StreamReader(filename))
                {
                    LOG.Text = reader.ReadToEnd();
                }
            }
        }
    }
}
