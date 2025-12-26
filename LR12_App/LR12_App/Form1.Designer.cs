namespace LR12_App
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
            this.labelD = new System.Windows.Forms.Label();
            this.labelB = new System.Windows.Forms.Label();
            this.textBoxD = new System.Windows.Forms.TextBox();
            this.textBoxB = new System.Windows.Forms.TextBox();
            this.labelX = new System.Windows.Forms.Label();
            this.labelY = new System.Windows.Forms.Label();
            this.textBoxX = new System.Windows.Forms.TextBox();
            this.textBoxY = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labelD
            // 
            this.labelD.AutoSize = true;
            this.labelD.Location = new System.Drawing.Point(15, 13);
            this.labelD.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelD.Name = "labelD";
            this.labelD.Size = new System.Drawing.Size(16, 13);
            this.labelD.TabIndex = 0;
            this.labelD.Text = "d:";
            // 
            // labelB
            // 
            this.labelB.AutoSize = true;
            this.labelB.Location = new System.Drawing.Point(15, 39);
            this.labelB.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelB.Name = "labelB";
            this.labelB.Size = new System.Drawing.Size(16, 13);
            this.labelB.TabIndex = 1;
            this.labelB.Text = "b:";
            // 
            // textBoxD
            // 
            this.textBoxD.Location = new System.Drawing.Point(45, 11);
            this.textBoxD.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxD.Name = "textBoxD";
            this.textBoxD.Size = new System.Drawing.Size(76, 20);
            this.textBoxD.TabIndex = 2;
            // 
            // textBoxB
            // 
            this.textBoxB.Location = new System.Drawing.Point(45, 37);
            this.textBoxB.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxB.Name = "textBoxB";
            this.textBoxB.Size = new System.Drawing.Size(76, 20);
            this.textBoxB.TabIndex = 3;
            // 
            // labelX
            // 
            this.labelX.AutoSize = true;
            this.labelX.Location = new System.Drawing.Point(15, 65);
            this.labelX.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(15, 13);
            this.labelX.TabIndex = 4;
            this.labelX.Text = "x:";
            // 
            // labelY
            // 
            this.labelY.AutoSize = true;
            this.labelY.Location = new System.Drawing.Point(15, 91);
            this.labelY.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelY.Name = "labelY";
            this.labelY.Size = new System.Drawing.Size(15, 13);
            this.labelY.TabIndex = 5;
            this.labelY.Text = "y:";
            // 
            // textBoxX
            // 
            this.textBoxX.Location = new System.Drawing.Point(45, 63);
            this.textBoxX.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxX.Name = "textBoxX";
            this.textBoxX.ReadOnly = true;
            this.textBoxX.Size = new System.Drawing.Size(76, 20);
            this.textBoxX.TabIndex = 6;
            // 
            // textBoxY
            // 
            this.textBoxY.Location = new System.Drawing.Point(45, 89);
            this.textBoxY.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxY.Name = "textBoxY";
            this.textBoxY.ReadOnly = true;
            this.textBoxY.Size = new System.Drawing.Size(76, 20);
            this.textBoxY.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(225, 130);
            this.Controls.Add(this.textBoxY);
            this.Controls.Add(this.textBoxX);
            this.Controls.Add(this.labelY);
            this.Controls.Add(this.labelX);
            this.Controls.Add(this.textBoxB);
            this.Controls.Add(this.textBoxD);
            this.Controls.Add(this.labelB);
            this.Controls.Add(this.labelD);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "LR12";
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelD;
        private System.Windows.Forms.Label labelB;
        private System.Windows.Forms.TextBox textBoxD;
        private System.Windows.Forms.TextBox textBoxB;
        private System.Windows.Forms.Label labelX;
        private System.Windows.Forms.Label labelY;
        private System.Windows.Forms.TextBox textBoxX;
        private System.Windows.Forms.TextBox textBoxY;
    }
}