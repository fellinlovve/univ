using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Input;

namespace Lab19
{
    public partial class MainWindow : Window
    {
        private Random rand = new Random();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(txtCount.Text, out int n) || n <= 0)
            {
                MessageBox.Show("Введите корректное положительное число фигур.");
                return;
            }

            MainCanvas.Children.Clear();
            for (int i = 0; i < n; i++)
            {
                var shape = GenerateRandomShape();
                AttachEventHandlers(shape);
                MainCanvas.Children.Add(shape);
            }
        }

        private Shape GenerateRandomShape()
        {
            double left = rand.Next(0, (int)MainCanvas.ActualWidth - 100);
            double top = rand.Next(0, (int)MainCanvas.ActualHeight - 100);
            double width = rand.Next(30, 100);
            double height = rand.Next(30, 100);

            Shape shape;
            if (rand.Next(2) == 0)
            {
                shape = new Ellipse();
            }
            else
            {
                shape = new Rectangle { RadiusX = rand.NextDouble() > 0.5 ? 10 : 0, RadiusY = rand.NextDouble() > 0.5 ? 10 : 0 };
            }

            // Применяем случайный стиль из заданных
            string[] styles = { "BasicShapeStyle", "RandomStyle" };
            string chosenStyle = styles[rand.Next(styles.Length)];
            shape.Style = (Style)Resources[chosenStyle];

            // Устанавливаем случайный цвет, если стиль RandomStyle
            if (chosenStyle == "RandomStyle")
            {
                shape.Fill = new SolidColorBrush(Color.FromRgb((byte)rand.Next(256), (byte)rand.Next(256), (byte)rand.Next(256)));
                shape.Stroke = new SolidColorBrush(Color.FromRgb((byte)rand.Next(256), (byte)rand.Next(256), (byte)rand.Next(256)));
            }

            Canvas.SetLeft(shape, left);
            Canvas.SetTop(shape, top);
            shape.Width = width;
            shape.Height = height;

            return shape;
        }

        private void AttachEventHandlers(Shape shape)
        {
            shape.MouseEnter += (s, e) =>
            {
                shape.Style = (Style)Resources["HoverStyle"];
            };

            shape.MouseLeave += (s, e) =>
            {
                shape.Style = shape.Tag as Style ?? (Style)Resources["BasicShapeStyle"];
            };

            shape.MouseLeftButtonDown += (s, e) =>
            {
                shape.Style = (Style)Resources["ClickedStyle"];
                shape.Tag = shape.Style; // Сохраняем текущий стиль для восстановления
            };
        }
    }
}