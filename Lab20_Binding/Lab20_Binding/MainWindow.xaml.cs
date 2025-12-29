using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data; 

namespace Lab20_Binding
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Динамическая привязка: шрифт TextBlock к выбранному значению нового ComboBox
            var fontCombo = new ComboBox
            {
                Margin = new Thickness(5),
                SelectedIndex = 0
            };
            fontCombo.Items.Add("Arial");
            fontCombo.Items.Add("Times New Roman");
            fontCombo.Items.Add("Courier New");

            var sampleText = new TextBlock
            {
                Text = "Этот текст меняет шрифт динамически",
                Margin = new Thickness(5)
            };

            // --- ДИНАМИЧЕСКАЯ ПРИВЯЗКА ---
            var binding = new Binding("SelectedItem.Content")
            {
                Source = fontCombo,
                Mode = BindingMode.OneWay
            };
            sampleText.SetBinding(TextBlock.FontFamilyProperty, binding);

            // Добавляем элементы в Grid
            var grid = (Grid)Content;
            grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

            Grid.SetRow(fontCombo, 9);
            Grid.SetRow(sampleText, 10);

            grid.Children.Add(fontCombo);
            grid.Children.Add(sampleText);
        }
    }
}