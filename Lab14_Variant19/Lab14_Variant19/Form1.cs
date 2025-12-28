using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lab14_Variant19
{
    public partial class Form1 : Form
    {
        // Переменные для хранения данных
        private double a = 1.0;
        private double b = 1.0;
        private string selectedFormula = "z = x^4";

        public Form1()
        {
            InitializeComponent();
            InitializeMenu();
            InitializeStatusStrip();
            InitializeTimer();
            this.Text = "Лабораторная работа 14 - Вариант 19";
            this.Size = new Size(800, 600);
        }

        private void InitializeMenu()
        {
            // Главное меню
            MenuStrip mainMenu = new MenuStrip();

            // Пункт "Вычисления"
            ToolStripMenuItem calcMenu = new ToolStripMenuItem("Вычисления");

            ToolStripMenuItem calculateItem = new ToolStripMenuItem("Вычислить", null, Calculate_Click);
            ToolStripMenuItem clearItem = new ToolStripMenuItem("Очистить", null, Clear_Click);
            ToolStripSeparator separator = new ToolStripSeparator();
            ToolStripMenuItem exitItem = new ToolStripMenuItem("Выход", null, Exit_Click);

            calcMenu.DropDownItems.AddRange(new ToolStripItem[] {
                calculateItem, clearItem, separator, exitItem
            });

            // Пункт "Настройки"
            ToolStripMenuItem settingsMenu = new ToolStripMenuItem("Настройки");
            ToolStripMenuItem colorItem = new ToolStripMenuItem("Цвет фона", null, ChangeColor_Click);
            ToolStripMenuItem fontItem = new ToolStripMenuItem("Шрифт", null, ChangeFont_Click);

            settingsMenu.DropDownItems.AddRange(new ToolStripItem[] { colorItem, fontItem });

            mainMenu.Items.AddRange(new ToolStripItem[] { calcMenu, settingsMenu });

            // Поля ввода в меню (согласно заданию)
            ToolStripTextBox xTextBox = new ToolStripTextBox();
            xTextBox.Name = "txtX";
            xTextBox.Text = "1";
            xTextBox.ToolTipText = "Введите X";
            xTextBox.Width = 50;

            ToolStripTextBox yTextBox = new ToolStripTextBox();
            yTextBox.Name = "txtY";
            yTextBox.Text = "1";
            yTextBox.ToolTipText = "Введите Y";
            yTextBox.Width = 50;

            ToolStripTextBox zTextBox = new ToolStripTextBox();
            zTextBox.Name = "txtZ";
            zTextBox.Text = "0";
            zTextBox.ToolTipText = "Введите Z";
            zTextBox.Width = 50;

            ToolStripComboBox aCombo = new ToolStripComboBox();
            aCombo.Name = "cmbA";
            aCombo.Items.AddRange(new object[] { "1.0", "2.0", "3.0", "4.0", "5.0" });
            aCombo.SelectedIndex = 0;
            aCombo.ToolTipText = "Выберите A";
            aCombo.Width = 60;

            ToolStripComboBox bCombo = new ToolStripComboBox();
            bCombo.Name = "cmbB";
            bCombo.Items.AddRange(new object[] { "1.0", "2.0", "3.0", "4.0", "5.0" });
            bCombo.SelectedIndex = 0;
            bCombo.ToolTipText = "Выберите B";
            bCombo.Width = 60;

            ToolStripLabel labelX = new ToolStripLabel("X:");
            ToolStripLabel labelY = new ToolStripLabel("Y:");
            ToolStripLabel labelZ = new ToolStripLabel("Z:");
            ToolStripLabel labelA = new ToolStripLabel("A:");
            ToolStripLabel labelB = new ToolStripLabel("B:");

            ToolStripSeparator sep1 = new ToolStripSeparator();
            ToolStripSeparator sep2 = new ToolStripSeparator();
            ToolStripSeparator sep3 = new ToolStripSeparator();
            ToolStripSeparator sep4 = new ToolStripSeparator();

            mainMenu.Items.Add(sep1);
            mainMenu.Items.Add(labelX);
            mainMenu.Items.Add(xTextBox);
            mainMenu.Items.Add(sep2);
            mainMenu.Items.Add(labelY);
            mainMenu.Items.Add(yTextBox);
            mainMenu.Items.Add(sep3);
            mainMenu.Items.Add(labelZ);
            mainMenu.Items.Add(zTextBox);
            mainMenu.Items.Add(sep4);
            mainMenu.Items.Add(labelA);
            mainMenu.Items.Add(aCombo);
            mainMenu.Items.Add(labelB);
            mainMenu.Items.Add(bCombo);

            this.MainMenuStrip = mainMenu;
            this.Controls.Add(mainMenu);

            // Контекстное меню (дублирует главное - Задание 1)
            ContextMenuStrip contextMenu = new ContextMenuStrip();
            contextMenu.Items.Add("Вычислить", null, Calculate_Click);
            contextMenu.Items.Add("Очистить", null, Clear_Click);
            contextMenu.Items.Add(new ToolStripSeparator());
            contextMenu.Items.Add("Выход", null, Exit_Click);

            this.ContextMenuStrip = contextMenu;
        }

        private void InitializeStatusStrip()
        {
            StatusStrip statusStrip = new StatusStrip();

            // Панель для координат мыши
            ToolStripStatusLabel mouseCoords = new ToolStripStatusLabel();
            mouseCoords.Name = "lblMouseCoords";
            mouseCoords.Spring = true;
            mouseCoords.Text = "Мышь: (0, 0)";
            mouseCoords.TextAlign = ContentAlignment.MiddleLeft;

            // Выпадающий список формул (Задание 2)
            ToolStripDropDownButton formulaButton = new ToolStripDropDownButton("Формулы");

            ToolStripMenuItem formula1 = new ToolStripMenuItem("z = x^4", null, Formula1_Click);
            ToolStripMenuItem formula2 = new ToolStripMenuItem("f = y^3", null, Formula2_Click);
            ToolStripMenuItem formula3 = new ToolStripMenuItem("z = sqrt(x/y) + y^2", null, Formula3_Click);

            formulaButton.DropDownItems.AddRange(new ToolStripItem[] { formula1, formula2, formula3 });

            // Панель для результата формулы (Задание 2)
            ToolStripStatusLabel formulaResult = new ToolStripStatusLabel();
            formulaResult.Name = "lblFormulaResult";
            formulaResult.Text = "Результат: 0";
            formulaResult.BorderSides = ToolStripStatusLabelBorderSides.All;
            formulaResult.AutoSize = false;
            formulaResult.Width = 150;

            statusStrip.Items.AddRange(new ToolStripItem[] {
                mouseCoords, formulaButton, formulaResult
            });

            this.Controls.Add(statusStrip);
        }

        private void InitializeTimer()
        {
            Timer timer = new Timer();
            timer.Interval = 100; // 100 мс
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Обновляем координаты мыши
            Point mousePos = this.PointToClient(Cursor.Position);
            ToolStripStatusLabel mouseLabel = (this.Controls[1] as StatusStrip).Items["lblMouseCoords"] as ToolStripStatusLabel;
            mouseLabel.Text = $"Мышь: ({mousePos.X}, {mousePos.Y})";

            // Обновляем результат формулы (Задание 2)
            UpdateFormulaResult(mousePos.X, mousePos.Y);
        }

        private void UpdateFormulaResult(int x, int y)
        {
            double result = 0;
            double xVal = x;
            double yVal = y;

            try
            {
                switch (selectedFormula)
                {
                    case "z = x^4":
                        result = Math.Pow(xVal, 4);
                        break;
                    case "f = y^3":
                        result = Math.Pow(yVal, 3);
                        break;
                    case "z = sqrt(x/y) + y^2":
                        if (yVal != 0)
                        {
                            double sqrtPart = Math.Sqrt(xVal / yVal);
                            // Проверка на отрицательное значение под корнем
                            if (!double.IsNaN(sqrtPart))
                            {
                                result = sqrtPart + Math.Pow(yVal, 2);
                            }
                            else
                            {
                                result = Math.Pow(yVal, 2); // Если корень из отрицательного, берем только y^2
                            }
                        }
                        else
                        {
                            result = 0; // Деление на ноль
                        }
                        break;
                }
            }
            catch
            {
                result = 0;
            }

            ToolStripStatusLabel resultLabel = (this.Controls[1] as StatusStrip).Items["lblFormulaResult"] as ToolStripStatusLabel;
            resultLabel.Text = $"Результат: {result:F4}";
        }

        // Обработчики событий меню (Задание 1)
        private void Calculate_Click(object sender, EventArgs e)
        {
            try
            {
                // Получаем значения из меню
                MenuStrip mainMenu = this.MainMenuStrip;
                ToolStripTextBox txtX = mainMenu.Items["txtX"] as ToolStripTextBox;
                ToolStripTextBox txtY = mainMenu.Items["txtY"] as ToolStripTextBox;
                ToolStripTextBox txtZ = mainMenu.Items["txtZ"] as ToolStripTextBox;
                ToolStripComboBox cmbA = mainMenu.Items["cmbA"] as ToolStripComboBox;
                ToolStripComboBox cmbB = mainMenu.Items["cmbB"] as ToolStripComboBox;

                double x = Convert.ToDouble(txtX.Text);
                double y = Convert.ToDouble(txtY.Text);
                double z = Convert.ToDouble(txtZ.Text);
                a = Convert.ToDouble(cmbA.SelectedItem);
                b = Convert.ToDouble(cmbB.SelectedItem);

                // Вычисляем выражение из задания 1: (a*x)/b + b*(y/x) + sin(z)
                double result = 0;

                // Проверка деления на ноль
                if (b == 0)
                {
                    MessageBox.Show("Ошибка: деление на ноль (b не может быть равно 0)", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (x == 0)
                {
                    MessageBox.Show("Ошибка: деление на ноль (x не может быть равно 0)", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Вычисление по формуле из задания 1
                result = (a * x) / b + b * (y / x) + Math.Sin(z);

                // Выводим результат в заголовок окна
                this.Text = $"Лабораторная 14 - Результат: {result:F4}";
            }
            catch (FormatException)
            {
                MessageBox.Show("Ошибка: введите числовые значения для X, Y, Z", "Ошибка ввода",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            MenuStrip mainMenu = this.MainMenuStrip;
            (mainMenu.Items["txtX"] as ToolStripTextBox).Text = "1";
            (mainMenu.Items["txtY"] as ToolStripTextBox).Text = "1";
            (mainMenu.Items["txtZ"] as ToolStripTextBox).Text = "0";
            (mainMenu.Items["cmbA"] as ToolStripComboBox).SelectedIndex = 0;
            (mainMenu.Items["cmbB"] as ToolStripComboBox).SelectedIndex = 0;
            this.Text = "Лабораторная работа 14 - Вариант 19";
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ChangeColor_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.BackColor = dialog.Color;
            }
        }

        private void ChangeFont_Click(object sender, EventArgs e)
        {
            FontDialog dialog = new FontDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.Font = dialog.Font;
            }
        }

        // Обработчики выбора формул в строке состояния (Задание 2)
        private void Formula1_Click(object sender, EventArgs e)
        {
            selectedFormula = "z = x^4";
        }

        private void Formula2_Click(object sender, EventArgs e)
        {
            selectedFormula = "f = y^3";
        }

        private void Formula3_Click(object sender, EventArgs e)
        {
            selectedFormula = "z = sqrt(x/y) + y^2";
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            // Обновление координат происходит в таймере
        }
    }
}
