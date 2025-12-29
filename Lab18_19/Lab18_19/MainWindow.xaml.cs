using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab18_19
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int N = int.Parse(txtN.Text);
                int K = int.Parse(txtK.Text);

                double[] x = txtX.Text.Split(',').Select(s => double.Parse(s.Trim())).ToArray();
                double[] y = txtY.Text.Split(',').Select(s => double.Parse(s.Trim())).ToArray();

                if (x.Length != N || y.Length != K)
                {
                    MessageBox.Show("Количество элементов в x и y должно соответствовать N и K.");
                    return;
                }

                double Z = 0.0;
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < K; j++)
                    {
                        Z += (x[i] + Math.Cos(y[j])) / ((i + 2) * (j + 2)); // (i+1)(j+1) но индексация с 0 → +2
                    }
                }

                txtResult.Text = Z.ToString("F4");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка ввода: {ex.Message}");
            }
        }
    }

}
