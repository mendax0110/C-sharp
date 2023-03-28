using System;
using System.Data;
using System.Linq.Expressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace DifferentialEqCalc
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private Func<double, double> CreateFunction(string equationText)
        {
            DataTable table = new DataTable();
            DataColumn xColumn = new DataColumn("x");
            table.Columns.Add(xColumn);
            table.Columns.Add("y", typeof(double), equationText);

            return (double x) =>
            {
                table.Rows.Clear();
                table.Rows.Add(x, DBNull.Value);
                return (double)table.Rows[0]["y"];
            };
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            // Parse the input equation and create a corresponding function
            string equationText = EquationTextBox.Text;
            Func<double, double> equation = CreateFunction(equationText);

            // Draw the graph
            DrawGraph(equation);
        }

        private void DrawGraph(Func<double, double> equation)
        {
            try
            {
                // Clear the existing graph
                GraphCanvas.Children.Clear();

                // Draw the x and y axes
                DrawAxis(0, GraphCanvas.ActualHeight / 2, GraphCanvas.ActualWidth, GraphCanvas.ActualHeight / 2, Brushes.Black);
                DrawAxis(GraphCanvas.ActualWidth / 2, 0, GraphCanvas.ActualWidth / 2, GraphCanvas.ActualHeight, Brushes.Black);

                // Evaluate the function at each x value and draw a line between the points
                double xMin = -10;
                double xMax = 10;
                double deltaX = 0.1;

                for (double x = xMin; x <= xMax; x += deltaX)
                {
                    double y = equation(x);

                    // Convert from (x,y) coordinates to (canvasX, canvasY) coordinates
                    double canvasX = (x - xMin) * GraphCanvas.ActualWidth / (xMax - xMin);
                    double canvasY = GraphCanvas.ActualHeight / 2 - y * GraphCanvas.ActualHeight / (xMax - xMin);

                    // Draw a dot at the current (canvasX, canvasY) point
                    Ellipse dot = new Ellipse();
                    dot.Width = 4;
                    dot.Height = 4;
                    dot.Fill = Brushes.Black;
                    dot.Margin = new Thickness(canvasX - dot.Width / 2, canvasY - dot.Height / 2, 0, 0);
                    GraphCanvas.Children.Add(dot);
                }

                // Draw a line connecting the dots
                for (int i = 0; i < GraphCanvas.Children.Count - 1; i++)
                {
                    UIElement element1 = GraphCanvas.Children[i];
                    UIElement element2 = GraphCanvas.Children[i + 1];

                    Line line = new Line();
                    line.X1 = Canvas.GetLeft(element1) + element1.RenderSize.Width / 2;
                    line.Y1 = Canvas.GetTop(element1) + element1.RenderSize.Height / 2;
                    line.X2 = Canvas.GetLeft(element2) + element2.RenderSize.Width / 2;
                    line.Y2 = Canvas.GetTop(element2) + element2.RenderSize.Height / 2;
                    line.Stroke = Brushes.Red;
                    line.StrokeThickness = 2;
                    GraphCanvas.Children.Add(line);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex + "Error");
            }
        }

        private void DrawAxis(double startX, double startY, double endX, double endY, Brush color)
        {
            Line axis = new Line();
            axis.Stroke = color;
            axis.X1 = startX;
            axis.Y1 = startY;
            axis.X2 = endX;
            axis.Y2 = endY;
            GraphCanvas.Children.Add(axis);
        }
    }
}
