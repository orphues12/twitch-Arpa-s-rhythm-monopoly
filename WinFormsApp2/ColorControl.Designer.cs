namespace RhythmMonopoly
{
    partial class ColorControl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblCurrentColor = new System.Windows.Forms.Label();
            this.lblChangeColor = new System.Windows.Forms.Label();
            this.SpinR = new System.Windows.Forms.NumericUpDown();
            this.SpinG = new System.Windows.Forms.NumericUpDown();
            this.SpinB = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.SpinR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinB)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(50, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "R:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(50, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "G:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(50, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "B:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(99, 126);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "저장";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(135, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 18);
            this.label4.TabIndex = 7;
            this.label4.Text = "현재 색:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(135, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 18);
            this.label5.TabIndex = 8;
            this.label5.Text = "변경 색:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblCurrentColor
            // 
            this.lblCurrentColor.BackColor = System.Drawing.Color.Black;
            this.lblCurrentColor.Location = new System.Drawing.Point(194, 30);
            this.lblCurrentColor.Name = "lblCurrentColor";
            this.lblCurrentColor.Size = new System.Drawing.Size(50, 30);
            this.lblCurrentColor.TabIndex = 9;
            // 
            // lblChangeColor
            // 
            this.lblChangeColor.BackColor = System.Drawing.Color.Black;
            this.lblChangeColor.Location = new System.Drawing.Point(194, 70);
            this.lblChangeColor.Name = "lblChangeColor";
            this.lblChangeColor.Size = new System.Drawing.Size(50, 30);
            this.lblChangeColor.TabIndex = 10;
            // 
            // SpinR
            // 
            this.SpinR.Location = new System.Drawing.Point(75, 25);
            this.SpinR.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.SpinR.Name = "SpinR";
            this.SpinR.Size = new System.Drawing.Size(54, 23);
            this.SpinR.TabIndex = 11;
            this.SpinR.ValueChanged += new System.EventHandler(this._ValueChanged);
            this.SpinR.Leave += new System.EventHandler(this._Leave);
            // 
            // SpinG
            // 
            this.SpinG.Location = new System.Drawing.Point(75, 54);
            this.SpinG.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.SpinG.Name = "SpinG";
            this.SpinG.Size = new System.Drawing.Size(54, 23);
            this.SpinG.TabIndex = 12;
            this.SpinG.ValueChanged += new System.EventHandler(this._ValueChanged);
            this.SpinG.Leave += new System.EventHandler(this._Leave);
            // 
            // SpinB
            // 
            this.SpinB.Location = new System.Drawing.Point(75, 85);
            this.SpinB.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.SpinB.Name = "SpinB";
            this.SpinB.Size = new System.Drawing.Size(54, 23);
            this.SpinB.TabIndex = 13;
            this.SpinB.ValueChanged += new System.EventHandler(this._ValueChanged);
            this.SpinB.Leave += new System.EventHandler(this._Leave);
            // 
            // ColorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 161);
            this.Controls.Add(this.SpinB);
            this.Controls.Add(this.SpinG);
            this.Controls.Add(this.SpinR);
            this.Controls.Add(this.lblChangeColor);
            this.Controls.Add(this.lblCurrentColor);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ColorControl";
            this.Text = "판 색 설정";
            this.Click += new System.EventHandler(this.ColorControl_Click);
            ((System.ComponentModel.ISupportInitialize)(this.SpinR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinB)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Label label1;
        private Label label2;
        private Label label3;
        private Button button1;
        private Label label4;
        private Label label5;
        private Label lblCurrentColor;
        private Label lblChangeColor;
        private NumericUpDown SpinR;
        private NumericUpDown SpinG;
        private NumericUpDown SpinB;
    }
}