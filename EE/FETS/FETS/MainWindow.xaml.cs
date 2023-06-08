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

namespace FETS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string[] TransistorNames = new string[4];
        string[] TransistorTypes = new string[4];
        double[] TransistorVoltages = new double[4];

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Determines the type of the transistor based on its name.
        /// </summary>
        /// <param name="transistorName">The name of the transistor.</param>
        /// <returns>The type of the transistor (FET or BJT).</returns>
        public string FETorBJT(string transistorName)
        {
            char secondChar = transistorName.Length > 1 ? transistorName[1] : ' ';
            secondChar = char.ToUpper(secondChar);

            if (secondChar == 'S')
            {
                return "FET";
            }
            else if (secondChar == 'C')
            {
                return "BJT";
            }
            else
            {
                return "Unknown Transistor Type";
            }
        }

        /// <summary>
        /// Adds a new transistor to the collection.
        /// </summary>
        /// <param name="transistorName">The name of the transistor.</param>
        /// <param name="transistorVoltage">The voltage of the transistor.</param>
        public void AddTransistor(string transistorName, string transistorVoltage)
        {
            string transistorType = FETorBJT(transistorName);

            // Überprüfen, ob der Name bereits vorhanden ist
            if (Array.IndexOf(TransistorNames, transistorName) != -1)
            {
                MessageBox.Show("Transistor mit diesem Namen existiert bereits.", "Fehler");
                return;
            }

            // Überprüfen, ob die Arrays voll sind
            if (Array.TrueForAll(TransistorNames, name => !string.IsNullOrEmpty(name)))
            {
                MessageBox.Show("Alle Speicherplätze sind belegt.", "Fehler");
                return;
            }

            // Speichern des Transistornamens, -typs und der Spannung in den Arrays
            for (int i = 0; i < TransistorNames.Length; i++)
            {
                if (string.IsNullOrEmpty(TransistorNames[i]))
                {
                    TransistorNames[i] = transistorName;
                    TransistorTypes[i] = transistorType;

                    double voltage;
                    if (double.TryParse(transistorVoltage, out voltage))
                    {
                        TransistorVoltages[i] = voltage;
                    }
                    else
                    {
                        MessageBox.Show("Ungültiger Spannungswert.", "Fehler");
                        return;
                    }

                    break;
                }
            }

            ListBoxOutput.Items.Add($"Name: {transistorName} - Type: {transistorType} - Spannung: {transistorVoltage} Volt");
        }


        /// <summary>
        /// Replaces the selected transistor with a new one.
        /// </summary>
        /// <param name="transistorName">The name of the new transistor.</param>
        /// <param name="transistorVoltage">The voltage of the new transistor.</param>
        public void ReplaceTransistor(string transistorName, string transistorVoltage)
        {
            int selectedIndex = ListBoxOutput.SelectedIndex;

            if (selectedIndex != -1)
            {
                string oldTransistorName = TransistorNames[selectedIndex];
                string transistorType = FETorBJT(transistorName);
                string transistorVoltageOld = TransistorVoltages[selectedIndex].ToString();

                // Überprüfen, ob der Name bereits vorhanden ist
                if (Array.IndexOf(TransistorNames, transistorName) != -1 && oldTransistorName != transistorName)
                {
                    MessageBox.Show("Transistor mit diesem Namen existiert bereits.", "Fehler");
                    return;
                }

                // Aktualisieren der Daten des ausgewählten Transistors
                TransistorNames[selectedIndex] = transistorName;
                TransistorTypes[selectedIndex] = transistorType;

                double voltage;
                if (double.TryParse(transistorVoltage, out voltage))
                {
                    TransistorVoltages[selectedIndex] = voltage;
                }
                else
                {
                    MessageBox.Show("Ungültiger Spannungswert.", "Fehler");
                    return;
                }

                // Aktualisieren der ListBox-Anzeige
                ListBoxOutput.Items[selectedIndex] = $"Name: {transistorName} - Type: {transistorType} - Spannung: {transistorVoltage} Volt";
            }
        }

        /// <summary>
        /// Checks if the arrays are fully occupied.
        /// </summary>
        public void CheckArrayFullorNot()
        {
            if (TransistorNames.Length != TransistorTypes.Length || TransistorNames.Length != TransistorVoltages.Length)
            {
                MessageBox.Show("Die Speicherbelegung ist in den Arrays nicht gleich.", "Fehler");
                return;
            }

            if (TransistorNames[3] != null && TransistorTypes[3] != null && TransistorVoltages[3] != 0)
            {
                MessageBox.Show("Alle Speicherplätze sind belegt.", "Fehler");
                return;
            }
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            CheckArrayFullorNot();

            string transistorName = TransistorName.Text;
            string transistorVoltage = TransistorVoltage.Text;

            AddTransistor(transistorName, transistorVoltage);
        }

        private void ButtonReplace_Click(object sender, RoutedEventArgs e)
        {
            string transistorName = TransistorName.Text;
            string transistorVoltage = TransistorVoltage.Text;
            ReplaceTransistor(transistorName, transistorVoltage);
        }

        private void TransistorName_TextChanged(object sender, TextChangedEventArgs e)
        {
            TransistorNames = new string[4];
            TransistorTypes = new string[4];
            TransistorVoltages = new double[4];
        }

        private void ListBoxOutput_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TransistorVoltage_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}