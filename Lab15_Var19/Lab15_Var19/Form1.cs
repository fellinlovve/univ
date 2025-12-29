using System;
using System.IO;
using System.Windows.Forms;

namespace Lab15_Var19
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            try
            {
                double a = double.Parse(txtA.Text);
                double t = double.Parse(txtT.Text);
                int n = (int)nudN.Value;

                if (n <= 0)
                {
                    MessageBox.Show("Количество слагаемых должно быть ≥ 1.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                double result = CalculateExpression(a, t, n);
                txtResult.Text = result.ToString("F6");
            }
            catch (FormatException)
            {
                MessageBox.Show("Пожалуйста, введите корректные числа для a и t.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Исключение", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private double CalculateExpression(double a, double t, int n)
        {
            double sum = 0.0;
            for (int i = 1; i <= n; i++)
            {
                double coeff = (2 * i) * (2 * i - 1) / (double)i;
                double angle = a * Math.Pow(t, i); // a * t^i

                double trigValue;
                if (i % 2 == 1)
                    trigValue = Math.Sin(angle);
                else
                    trigValue = Math.Cos(angle);

                // Чередуем знаки: -, +, -, +, ...
                if (i % 2 == 0)
                    trigValue = -trigValue;

                sum += coeff * trigValue;
            }
            return sum;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string[] lines = File.ReadAllLines(openFileDialog1.FileName);
                    if (lines.Length >= 3)
                    {
                        txtA.Text = lines[0].Trim();
                        txtT.Text = lines[1].Trim();
                        nudN.Value = Math.Max(1, Math.Min(100, int.Parse(lines[2].Trim())));
                    }
                    else
                    {
                        MessageBox.Show("Файл должен содержать минимум 3 строки:\na\nt\nn", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при загрузке: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtResult.Text))
            {
                MessageBox.Show("Сначала выполните вычисление.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            saveFileDialog1.FileName = "result.txt";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string content = $"Результат вычисления выражения:\n{txtResult.Text}\n\n" +
                                     $"Параметры:\n  a = {txtA.Text}\n  t = {txtT.Text}\n  Кол-во слагаемых = {nudN.Value}";
                    File.WriteAllText(saveFileDialog1.FileName, content);
                    MessageBox.Show("Результат успешно сохранён.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка сохранения: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                this.BackColor = colorDialog1.Color;
            }
        }
    }
}