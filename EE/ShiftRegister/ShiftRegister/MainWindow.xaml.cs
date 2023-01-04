using System;
using ShiftRegister;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftRegister
{
    public partial class MainWindow : Window
    {
        private SN74HC595N _shiftRegister;

        public MainWindow()
        {
            InitializeComponent();
            _shiftRegister = new SN74HC595N(8);
            UpdateRegisterDisplay();
        }

        private void ShiftLeftButton_Click(object sender, RoutedEventArgs e)
        {
            bool inputBit = GetInputBit();
            _shiftRegister.ShiftLeft(inputBit);
            UpdateRegisterDisplay();
        }

        private void ShiftRightButton_Click(object sender, RoutedEventArgs e)
        {
            bool inputBit = GetInputBit();
            _shiftRegister.ShiftRight(inputBit);
            UpdateRegisterDisplay();
        }

        private bool GetInputBit()
        {
            return inputTextBox.Text == "1";
        }

        private void UpdateRegisterDisplay()
        {
            registerListBox.Items.Clear();
            foreach (bool bit in _shiftRegister.GetRegister())
            {
                registerListBox.Items.Add(bit ? "1" : "0");
            }
        }
    }
}
