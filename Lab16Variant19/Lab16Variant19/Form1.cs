using System;
using System.Windows.Forms;

namespace Lab16Variant19
{
    public partial class Form1 : Form
    {
        private DataInterface data;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (openFileDlg.ShowDialog() == DialogResult.OK)
            {
                var storage = new DataStorage();
                if (storage.InitData(openFileDlg.FileName))
                {
                    data = storage;
                    ShowData();
                }
                else
                {
                    MessageBox.Show("Ошибка при загрузке файла.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ShowData()
        {
            dgvRaw.DataSource = null;
            dgvSummary.DataSource = null;
            lblMinDiscount.Text = "";

            dgvRaw.DataSource = data.GetRawData();
            dgvSummary.DataSource = data.GetSummaryData();

            var minDiscountItem = data.GetMinDiscountItem();
            if (minDiscountItem != null)
            {
                lblMinDiscount.Text = $"Товар с минимальной скидкой: {minDiscountItem.Name} ({minDiscountItem.DiscountPercent}%)";
            }
        }
    }
}