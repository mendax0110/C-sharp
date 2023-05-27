using System;
using System.Windows;
using System.Windows.Controls;

namespace Integral
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private double UnbestimmtesIntegral(double x)
        {
            // Unbestimmtes Integral berechnen
            return Math.Pow(x, 3) / 3; // Beispiel: x^3 / 3
        }

        private double BestimmtesIntegral(double a, double b)
        {
            // Bestimmtes Integral berechnen
            return (Math.Pow(b, 4) / 4) - (Math.Pow(a, 4) / 4); // Beispiel: (b^4 / 4) - (a^4 / 4)
        }

        private void ArtenVonIntegralenComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ArtenVonIntegralenComboBox.SelectedItem != null)
            {
                string ausgewählteArt = ArtenVonIntegralenComboBox.SelectedItem.ToString();

                switch (ausgewählteArt)
                {
                    case "Unbestimmtes Integral":
                        GrenzwerteTextBox.IsEnabled = true;
                        ErgebnisseTextBox.IsEnabled = false;
                        break;
                    case "Bestimmtes Integral":
                        GrenzwerteTextBox.IsEnabled = true;
                        ErgebnisseTextBox.IsEnabled = true;
                        break;
                    default:
                        GrenzwerteTextBox.IsEnabled = false;
                        ErgebnisseTextBox.IsEnabled = false;
                        break;
                }
            }
        }

        private void BerechnenTextBox_Click(object sender, RoutedEventArgs e)
        {
            if (ArtenVonIntegralenComboBox.SelectedItem == null)
            {
                MessageBox.Show("Bitte wähle eine Art des Integrals aus.");
                return;
            }

            double ergebnis = 0;

            switch (ArtenVonIntegralenComboBox.SelectedItem.ToString())
            {
                case "Unbestimmtes Integral":
                    if (double.TryParse(GrenzwerteTextBox.Text, out double x))
                    {
                        ergebnis = UnbestimmtesIntegral(x);
                        ErgebnisseTextBox.IsEnabled = false; // Deaktiviere die Ergebnisse-TextBox
                    }
                    else
                    {
                        MessageBox.Show("Ungültiger Wert für x.");
                        return;
                    }
                    break;
                case "Bestimmtes Integral":
                    if (double.TryParse(GrenzwerteTextBox.Text, out double a) && double.TryParse(ErgebnisseTextBox.Text, out double b))
                    {
                        ergebnis = BestimmtesIntegral(a, b);
                        ErgebnisseTextBox.IsEnabled = true; // Aktiviere die Ergebnisse-TextBox
                    }
                    else
                    {
                        MessageBox.Show("Ungültige Werte für a und/oder b.");
                        return;
                    }
                    break;
            }

            ErgebnisseTextBox.Text = ergebnis.ToString();
        }
 
        private void GrenzwerteTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Hier kannst du Code einfügen, der ausgeführt wird, wenn sich der Text in der Grenzwerte-TextBox ändert
        }

        private void ErgebnisseTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Hier kannst du Code einfügen, der ausgeführt wird, wenn sich der Text in der Ergebnisse-TextBox ändert
        }
    }
}
