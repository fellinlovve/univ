namespace Lab16Variant19
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        private void InitializeComponent()
        {
            this.dgvRaw = new System.Windows.Forms.DataGridView();
            this.dgvSummary = new System.Windows.Forms.DataGridView();
            this.btnLoad = new System.Windows.Forms.Button();
            this.openFileDlg = new System.Windows.Forms.OpenFileDialog();
            this.lblMinDiscount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRaw)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSummary)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvRaw
            // 
            this.dgvRaw.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRaw.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRaw.Location = new System.Drawing.Point(12, 12);
            this.dgvRaw.Name = "dgvRaw";
            this.dgvRaw.ReadOnly = true;
            this.dgvRaw.Size = new System.Drawing.Size(560, 150);
            this.dgvRaw.TabIndex = 0;
            // 
            // dgvSummary
            // 
            this.dgvSummary.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSummary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSummary.Location = new System.Drawing.Point(12, 180);
            this.dgvSummary.Name = "dgvSummary";
            this.dgvSummary.ReadOnly = true;
            this.dgvSummary.Size = new System.Drawing.Size(560, 150);
            this.dgvSummary.TabIndex = 1;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(12, 350);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(120, 23);
            this.btnLoad.TabIndex = 2;
            this.btnLoad.Text = "Загрузить данные";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // openFileDlg
            // 
            this.openFileDlg.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            // 
            // lblMinDiscount
            // 
            this.lblMinDiscount.AutoSize = true;
            this.lblMinDiscount.Location = new System.Drawing.Point(12, 385);
            this.lblMinDiscount.Name = "lblMinDiscount";
            this.lblMinDiscount.Size = new System.Drawing.Size(0, 13);
            this.lblMinDiscount.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 411);
            this.Controls.Add(this.lblMinDiscount);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.dgvSummary);
            this.Controls.Add(this.dgvRaw);
            this.Name = "Form1";
            this.Text = "Лабораторная работа №16 (Вариант 19)";
            ((System.ComponentModel.ISupportInitialize)(this.dgvRaw)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSummary)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRaw;
        private System.Windows.Forms.DataGridView dgvSummary;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.OpenFileDialog openFileDlg;
        private System.Windows.Forms.Label lblMinDiscount;
    }
}