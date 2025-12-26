using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LR12_App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBoxD.Text = "1";
            textBoxB.Text = "3";
            this.Text = "ЛР №12 — Вариант 19: переместите мышь";
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            double x = e.X;
            double y = e.Y;

            textBoxX.Text = x.ToString("F0");
            textBoxY.Text = y.ToString("F0");

            if (double.TryParse(textBoxD.Text, out double d) &&
                double.TryParse(textBoxB.Text, out double b))
            {
                double F = -d * x + x * x + b / 3.0 - Math.Cos(x * x + y);
                this.Text = $"F = {F:F4}  (x={x:F0}, y={y:F0})";
            }
            else
            {
                this.Text = "Ошибка: неверный формат d или b";
            }
        }
    }
}
