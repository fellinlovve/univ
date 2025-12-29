using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace GdiPlusLab17_Variant19
{
    public partial class Form1 : Form
    {
        // Графические пути для проверки попадания мыши
        private GraphicsPath circle1Path;
        private GraphicsPath circle2Path;
        private GraphicsPath topAreaPath;
        private GraphicsPath bottomAreaPath;

        // Цвета для закрашенных областей
        private Color circle1Color = Color.LightBlue;
        private Color circle2Color = Color.LightGreen;
        private Color topAreaColor = Color.Red;
        private Color bottomAreaColor = Color.Blue;

        // Пользовательский цвет
        private Color userSelectedColor = Color.Yellow;

        // Анимация
        private bool isAnimating = false;
        private float fontSize = 10f;
        private float fontSizeDirection = 0.3f;
        private int hue = 0;

        // Перетаскивание меток
        private bool isDragging = false;
        private Label draggingLabel;
        private Point dragOffset;

        public Form1()
        {
            InitializeComponent();
            SetupPaths();
        }

        private void SetupPaths()
        {
            // Круг 1: центр (0,0), радиус 2 -> координаты на панели: (200, 200), радиус 100
            circle1Path = new GraphicsPath();
            circle1Path.AddEllipse(100, 100, 200, 200); // x=100, y=100, ширина=200, высота=200

            // Круг 2: центр (2,0), радиус 2 -> координаты на панели: (300, 200), радиус 100
            circle2Path = new GraphicsPath();
            circle2Path.AddEllipse(200, 100, 200, 200); // x=200, y=100, ширина=200, высота=200

            // Верхняя область: прямоугольник от x=0 до x=4, y=2 до y=3 -> координаты на панели: x=0 до x=400, y=100 до y=150
            topAreaPath = new GraphicsPath();
            topAreaPath.AddRectangle(new Rectangle(0, 100, 400, 50));

            // Нижняя область: прямоугольник от x=0 до x=2, y=-2 до y=0 -> координаты на панели: x=0 до x=200, y=200 до y=300
            bottomAreaPath = new GraphicsPath();
            bottomAreaPath.AddRectangle(new Rectangle(0, 200, 200, 100));
        }

        private void drawingPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // Оси координат
            Pen axisPen = new Pen(Color.Gray, 2);
            g.DrawLine(axisPen, 0, 200, 800, 200); // ось X
            g.DrawLine(axisPen, 200, 0, 200, 450); // ось Y

            // Рисуем круги
            g.DrawPath(Pens.Black, circle1Path);
            g.DrawPath(Pens.Black, circle2Path);

            // Закрашиваем области
            g.FillPath(new SolidBrush(circle1Color), circle1Path);
            g.FillPath(new SolidBrush(circle2Color), circle2Path);
            g.FillPath(new SolidBrush(topAreaColor), topAreaPath);
            g.FillPath(new SolidBrush(bottomAreaColor), bottomAreaPath);

            // Рисуем линии границ (по условию: горизонтальные линии y=2, y=3 и вертикальные x=2, x=4)
            Pen borderPen = new Pen(Color.Gray, 1);
            g.DrawLine(borderPen, 0, 100, 800, 100); // y=2 (на панели y=100)
            g.DrawLine(borderPen, 0, 150, 800, 150); // y=3 (на панели y=150)
            g.DrawLine(borderPen, 200, 0, 200, 450); // x=2 (на панели x=200)
            g.DrawLine(borderPen, 400, 0, 400, 450); // x=4 (на панели x=400)

            // Подписи осей (не требуется по заданию, но добавим для наглядности)
            using (Font font = new Font("Arial", 8))
            {
                g.DrawString("0", font, Brushes.Black, 190, 205);
                g.DrawString("2", font, Brushes.Black, 190, 105);
                g.DrawString("3", font, Brushes.Black, 190, 55);
                g.DrawString("-2", font, Brushes.Black, 180, 255);
                g.DrawString("2", font, Brushes.Black, 205, 205);
                g.DrawString("4", font, Brushes.Black, 405, 205);
            }
        }

        private void drawingPanel_MouseMove(object sender, MouseEventArgs e)
        {
            Point pt = e.Location;

            // Цвета по умолчанию
            Color defaultCircle1 = Color.LightBlue;
            Color defaultCircle2 = Color.LightGreen;
            Color defaultTop = Color.Red;
            Color defaultBottom = Color.Blue;

            // Изменяем цвет при наведении
            circle1Color = circle1Path.IsVisible(pt) ? Color.Cyan : defaultCircle1;
            circle2Color = circle2Path.IsVisible(pt) ? Color.Lime : defaultCircle2;
            topAreaColor = topAreaPath.IsVisible(pt) ? Color.Magenta : defaultTop;
            bottomAreaColor = bottomAreaPath.IsVisible(pt) ? Color.Cyan : defaultBottom;

            drawingPanel.Invalidate();
        }

        private void btnSelectColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                userSelectedColor = colorDialog1.Color;
                // Применяем выбранный цвет к одной из областей (например, к нижней)
                bottomAreaColor = userSelectedColor;
                drawingPanel.Invalidate();
            }
        }

        private void btnStartStopAnimation_Click(object sender, EventArgs e)
        {
            isAnimating = !isAnimating;
            btnStartStopAnimation.Text = isAnimating ? "Остановить анимацию" : "Запуск анимации";
            if (isAnimating)
                animationTimer.Start();
            else
                animationTimer.Stop();
        }

        private void animationTimer_Tick(object sender, EventArgs e)
        {
            // Анимация размера шрифта подписей
            fontSize += fontSizeDirection;
            if (fontSize >= 16 || fontSize <= 8)
                fontSizeDirection = -fontSizeDirection;

            lblCircle1.Font = new Font("Arial", fontSize);
            lblCircle2.Font = new Font("Arial", fontSize);
            lblTopArea.Font = new Font("Arial", fontSize);
            lblBottomArea.Font = new Font("Arial", fontSize);

            // Анимация цвета верхней области через HSV
            hue = (hue + 2) % 360;
            topAreaColor = ColorFromHsv(hue, 1.0f, 1.0f);
            drawingPanel.Invalidate();
        }

        // Преобразование HSV → RGB
        public static Color ColorFromHsv(float h, float s, float v)
        {
            int hi = (int)Math.Floor(h / 60) % 6;
            float f = h / 60 - (float)Math.Floor(h / 60);
            float p = v * (1 - s);
            float q = v * (1 - f * s);
            float t = v * (1 - (1 - f) * s);
            switch (hi)
            {
                case 0:
                    return Color.FromArgb((int)(v * 255), (int)(t * 255), (int)(p * 255));
                case 1:
                    return Color.FromArgb((int)(q * 255), (int)(v * 255), (int)(p * 255));
                case 2:
                    return Color.FromArgb((int)(p * 255), (int)(v * 255), (int)(t * 255));
                case 3:
                    return Color.FromArgb((int)(p * 255), (int)(q * 255), (int)(v * 255));
                case 4:
                    return Color.FromArgb((int)(t * 255), (int)(p * 255), (int)(v * 255));
                default:
                    return Color.FromArgb((int)(v * 255), (int)(p * 255), (int)(q * 255));
            }
        }

        // Перетаскивание меток
        private void label_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                draggingLabel = (Label)sender;
                dragOffset = new Point(e.X, e.Y);
                isDragging = true;
            }
        }

        private void label_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging && draggingLabel != null)
            {
                Point newLocation = drawingPanel.PointToClient(Cursor.Position);
                newLocation.Offset(-dragOffset.X, -dragOffset.Y);
                draggingLabel.Location = newLocation;
            }
        }

        private void label_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
            draggingLabel = null;
        }
    }
}