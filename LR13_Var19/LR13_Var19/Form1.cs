using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LR13_Var19
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBoxA.Text = "1";
            textBoxB.Text = "2";
            this.Text = "ЛР №13 — Вариант 19: переместите мышь";
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            double x = e.X;
            double y = e.Y;

            textBoxX.Text = x.ToString("F0");
            textBoxY.Text = y.ToString("F0");

            // Проверка и парсинг a, b
            if (!double.TryParse(textBoxA.Text, out double a) ||
                !double.TryParse(textBoxB.Text, out double b))
            {
                this.Text = "ERROR: некорректный ввод a или b";
                return;
            }

            double F;
            try
            {
                if (x >= 3 && x <= 5 && y >= 2 && y <= 3)
                {
                    double denominator = 3 * x - 2 * y;
                    if (Math.Abs(denominator) < 1e-9)
                        throw new DivideByZeroException();
                    F = (a + b) / denominator;
                }
                else
                {
                    F = a * x + b * y;
                }

                this.Text = $"F = {F:F4}  (x={x:F0}, y={y:F0})";
            }
            catch (Exception)
            {
                this.Text = "ERROR: деление на ноль или другая ошибка";
            }
        }
    }
}