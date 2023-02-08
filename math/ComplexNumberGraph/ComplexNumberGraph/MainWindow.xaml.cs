using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace ComplexNumberGraph
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DrawGraph();
        }

        private void DrawGraph()
        {
            const int size = 300;
            const int center = size / 2;

            var canvas = new Canvas
            {
                Width = size,
                Height = size,
                Background = Brushes.White
            };

            var xAxis = new Line
            {
                X1 = 0,
                Y1 = center,
                X2 = size,
                Y2 = center,
                Stroke = Brushes.Black,
                StrokeThickness = 1
            };

            var yAxis = new Line
            {
                X1 = center,
                Y1 = 0,
                X2 = center,
                Y2 = size,
                Stroke = Brushes.Black,
                StrokeThickness = 1
            };

            canvas.Children.Add(xAxis);
            canvas.Children.Add(yAxis);

            // User input
            var realInput = new TextBox
            {
                Width = 50,
                Height = 25,
                Margin = new Thickness(10)
            };

            var imaginaryInput = new TextBox
            {
                Width = 50,
                Height = 25,
                Margin = new Thickness(10)
            };

            var submitButton = new Button
            {
                Content = "Submit",
                Width = 60,
                Height = 25,
                Margin = new Thickness(10)
            };

            submitButton.Click += (sender, args) =>
            {
                var real = double.Parse(realInput.Text);
                var imaginary = double.Parse(imaginaryInput.Text);

                // Draw phasor
                var phasor = new Line
                {
                    X1 = center,
                    Y1 = center,
                    X2 = center + real,
                    Y2 = center - imaginary,
                    Stroke = Brushes.Red,
                    StrokeThickness = 2
                };

                canvas.Children.Add(phasor);
            };

            var inputContainer = new StackPanel
            {
                Orientation = Orientation.Horizontal,
                Margin = new Thickness(10, size - 5, 10, 10)
            };

            inputContainer.Children.Add(realInput);
            inputContainer.Children.Add(imaginaryInput);
            inputContainer.Children.Add(submitButton);

            canvas.Children.Add(inputContainer);

            Content = canvas;
        }
    }

    // Complex number structure
    public struct Complex
    {
        public double Real { get; set; }
        public double Imaginary { get; set; }

        public Complex(double real, double imaginary)
        {
            Real = real;
            Imaginary = imaginary;
        }
    }
}
