using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace RingspuleCalc
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            if (ValidiereInput())
            {
                int windungen = int.Parse(txtWindungen.Text);
                double stromstaerke = double.Parse(txtStromstaerke.Text);
                double laenge = double.Parse(txtLaenge.Text);
                double radius = double.Parse(txtRadius.Text);

                double magnetischeFeldstaerke = BerechneMagnetischeFeldstaerke(windungen, stromstaerke, laenge);
                double magnetischeFlussdichte = BerechneMagnetischeFlussdichte(magnetischeFeldstaerke);
                double querschnittsflaeche = BerechneQuerschnittsflaeche(radius);

                ZeichneAnimation(magnetischeFeldstaerke, magnetischeFlussdichte, querschnittsflaeche);

                output.Items.Clear();
                output.Items.Add($"Magnetische Feldstärke (H): {magnetischeFeldstaerke} A/m");
                output.Items.Add($"Magnetische Flussdichte (B): {magnetischeFlussdichte} T");
                output.Items.Add($"Querschnittsfläche (A): {querschnittsflaeche} m²");
            }
        }

        private bool ValidiereInput()
        {
            int windungen;
            double stromstaerke, laenge, radius;

            if (!int.TryParse(txtWindungen.Text, out windungen))
            {
                ShowError("Ungültige Eingabe für Anzahl der Windungen.");
                return false;
            }

            if (!double.TryParse(txtStromstaerke.Text, out stromstaerke))
            {
                ShowError("Ungültige Eingabe für Stromstärke.");
                return false;
            }

            if (!double.TryParse(txtLaenge.Text, out laenge))
            {
                ShowError("Ungültige Eingabe für Länge der Ringspule.");
                return false;
            }

            if (!double.TryParse(txtRadius.Text, out radius))
            {
                ShowError("Ungültige Eingabe für Radius der Ringspule.");
                return false;
            }

            if (windungen <= 0 || stromstaerke <= 0 || laenge <= 0 || radius <= 0)
            {
                ShowError("Die Eingaben müssen positive Werte sein.");
                return false;
            }

            return true;
        }

        private void ShowError(string message)
        {
            MessageBox.Show(message, "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void ZeichneAnimation(double magnetischeFeldstaerke, double magnetischeFlussdichte, double querschnittsflaeche)
        {
            animations.Children.Clear();

            // Zeichne magnetisches Feld
            ZeichneFeldlinien(magnetischeFeldstaerke);

            // Zeichne Ringspule
            ZeichneSpule();

            // Zeichne magnetische Flussdichte
            ZeichneFlussdichte(magnetischeFlussdichte, querschnittsflaeche);
        }

        private void ZeichneFeldlinien(double magnetischeFeldstaerke)
        {
            const int lineCount = 10; // Anzahl der Feldlinien
            const double fieldLineSpacing = 20; // Abstand zwischen den Feldlinien

            // Berechne die Schrittgröße basierend auf der magnetischen Feldstärke
            double stepSize = magnetischeFeldstaerke > 0 ? fieldLineSpacing / magnetischeFeldstaerke : 0;

            for (int i = 0; i < lineCount; i++)
            {
                double y = i * stepSize;
                Line line = new Line
                {
                    X1 = 0,
                    Y1 = y,
                    X2 = animations.ActualWidth,
                    Y2 = y,
                    Stroke = Brushes.Green,
                    StrokeThickness = 1
                };
                animations.Children.Add(line);
            }
        }

        private void ZeichneSpule()
        {
            double coilRadius = animations.ActualHeight * 0.4;
            int coilTurns = int.Parse(txtWindungen.Text);

            // Berechne den Winkel zwischen den Windungen der Ringspule
            double angleBetweenTurns = 2 * Math.PI / coilTurns;

            for (int i = 0; i < coilTurns; i++)
            {
                double angle = i * angleBetweenTurns;

                // Berechne die Koordinaten des Mittelpunkts der aktuellen Windung
                double centerX = animations.ActualWidth / 2;
                double centerY = animations.ActualHeight / 2;

                // Berechne die x- und y-Koordinaten des aktuellen Windungspunkts
                double x = centerX + coilRadius * Math.Cos(angle);
                double y = centerY + coilRadius * Math.Sin(angle);

                Ellipse turn = new Ellipse
                {
                    Width = 10,
                    Height = 10,
                    Fill = Brushes.Black,
                    Margin = new Thickness(x - 5, y - 5, 0, 0)
                };
                animations.Children.Add(turn);
            }
        }

        private void ZeichneFlussdichte(double magnetischeFlussdichte, double querschnittsflaeche)
        {
            double rectangleWidth = animations.ActualWidth * 0.6;
            double rectangleHeight = animations.ActualHeight * 0.2;

            Rectangle rectangle = new Rectangle
            {
                Width = rectangleWidth,
                Height = rectangleHeight,
                Fill = Brushes.Black,
                Margin = new Thickness((animations.ActualWidth - rectangleWidth) / 2, (animations.ActualHeight - rectangleHeight) / 2, 0, 0)
            };
            animations.Children.Add(rectangle);

            // Zeichne die Textbeschriftung für die magnetische Flussdichte
            TextBlock textBlock = new TextBlock
            {
                Text = $"{magnetischeFlussdichte} T",
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Foreground = Brushes.White,
                FontWeight = FontWeights.Bold
            };
            Canvas.SetLeft(textBlock, (animations.ActualWidth - textBlock.ActualWidth) / 2);
            Canvas.SetTop(textBlock, (animations.ActualHeight - textBlock.ActualHeight) / 2);
            animations.Children.Add(textBlock);
        }

        private double BerechneMagnetischeFeldstaerke(int windungen, double stromstaerke, double laenge)
        {
            return (windungen * stromstaerke) / laenge;
        }

        private double BerechneMagnetischeFlussdichte(double magnetischeFeldstaerke)
        {
            double magnetischeFeldkonstante = 4 * Math.PI * 1e-7; // T*m/A
            return magnetischeFeldkonstante * magnetischeFeldstaerke;
        }

        private double BerechneQuerschnittsflaeche(double radius)
        {
            return Math.PI * Math.Pow(radius, 2);
        }
    }
}
