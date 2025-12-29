namespace GdiPlusLab17_Variant19
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.drawingPanel = new System.Windows.Forms.Panel();
            this.btnSelectColor = new System.Windows.Forms.Button();
            this.btnStartStopAnimation = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.animationTimer = new System.Windows.Forms.Timer(this.components);
            this.lblCircle1 = new System.Windows.Forms.Label();
            this.lblCircle2 = new System.Windows.Forms.Label();
            this.lblTopArea = new System.Windows.Forms.Label();
            this.lblBottomArea = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // drawingPanel
            this.drawingPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.drawingPanel.Location = new System.Drawing.Point(0, 0);
            this.drawingPanel.Name = "drawingPanel";
            this.drawingPanel.Size = new System.Drawing.Size(800, 450);
            this.drawingPanel.TabIndex = 0;
            this.drawingPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.drawingPanel_Paint);
            this.drawingPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.drawingPanel_MouseMove);

            // btnSelectColor
            this.btnSelectColor.Location = new System.Drawing.Point(12, 12);
            this.btnSelectColor.Name = "btnSelectColor";
            this.btnSelectColor.Size = new System.Drawing.Size(120, 23);
            this.btnSelectColor.TabIndex = 1;
            this.btnSelectColor.Text = "Выбрать цвет";
            this.btnSelectColor.UseVisualStyleBackColor = true;
            this.btnSelectColor.Click += new System.EventHandler(this.btnSelectColor_Click);

            // btnStartStopAnimation
            this.btnStartStopAnimation.Location = new System.Drawing.Point(138, 12);
            this.btnStartStopAnimation.Name = "btnStartStopAnimation";
            this.btnStartStopAnimation.Size = new System.Drawing.Size(120, 23);
            this.btnStartStopAnimation.TabIndex = 2;
            this.btnStartStopAnimation.Text = "Запуск анимации";
            this.btnStartStopAnimation.UseVisualStyleBackColor = true;
            this.btnStartStopAnimation.Click += new System.EventHandler(this.btnStartStopAnimation_Click);

            // animationTimer
            this.animationTimer.Interval = 100;
            this.animationTimer.Tick += new System.EventHandler(this.animationTimer_Tick);

            // lblCircle1
            this.lblCircle1.AutoSize = true;
            this.lblCircle1.BackColor = System.Drawing.Color.Transparent;
            this.lblCircle1.Location = new System.Drawing.Point(100, 200);
            this.lblCircle1.Name = "lblCircle1";
            this.lblCircle1.Size = new System.Drawing.Size(52, 15);
            this.lblCircle1.Text = "Круг 1";
            this.lblCircle1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label_MouseDown);
            this.lblCircle1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label_MouseMove);
            this.lblCircle1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.label_MouseUp);

            // lblCircle2
            this.lblCircle2.AutoSize = true;
            this.lblCircle2.BackColor = System.Drawing.Color.Transparent;
            this.lblCircle2.Location = new System.Drawing.Point(300, 200);
            this.lblCircle2.Name = "lblCircle2";
            this.lblCircle2.Size = new System.Drawing.Size(52, 15);
            this.lblCircle2.Text = "Круг 2";
            this.lblCircle2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label_MouseDown);
            this.lblCircle2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label_MouseMove);
            this.lblCircle2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.label_MouseUp);

            // lblTopArea
            this.lblTopArea.AutoSize = true;
            this.lblTopArea.BackColor = System.Drawing.Color.Transparent;
            this.lblTopArea.Location = new System.Drawing.Point(200, 100);
            this.lblTopArea.Name = "lblTopArea";
            this.lblTopArea.Size = new System.Drawing.Size(64, 15);
            this.lblTopArea.Text = "Верхняя";
            this.lblTopArea.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label_MouseDown);
            this.lblTopArea.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label_MouseMove);
            this.lblTopArea.MouseUp += new System.Windows.Forms.MouseEventHandler(this.label_MouseUp);

            // lblBottomArea
            this.lblBottomArea.AutoSize = true;
            this.lblBottomArea.BackColor = System.Drawing.Color.Transparent;
            this.lblBottomArea.Location = new System.Drawing.Point(200, 300);
            this.lblBottomArea.Name = "lblBottomArea";
            this.lblBottomArea.Size = new System.Drawing.Size(65, 15);
            this.lblBottomArea.Text = "Нижняя";
            this.lblBottomArea.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label_MouseDown);
            this.lblBottomArea.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label_MouseMove);
            this.lblBottomArea.MouseUp += new System.Windows.Forms.MouseEventHandler(this.label_MouseUp);

            // Form1
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblBottomArea);
            this.Controls.Add(this.lblTopArea);
            this.Controls.Add(this.lblCircle2);
            this.Controls.Add(this.lblCircle1);
            this.Controls.Add(this.btnStartStopAnimation);
            this.Controls.Add(this.btnSelectColor);
            this.Controls.Add(this.drawingPanel);
            this.Name = "Form1";
            this.Text = "Лабораторная работа 17 — Вариант 19";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel drawingPanel;
        private System.Windows.Forms.Button btnSelectColor;
        private System.Windows.Forms.Button btnStartStopAnimation;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Timer animationTimer;
        private System.Windows.Forms.Label lblCircle1;
        private System.Windows.Forms.Label lblCircle2;
        private System.Windows.Forms.Label lblTopArea;
        private System.Windows.Forms.Label lblBottomArea;
    }
}