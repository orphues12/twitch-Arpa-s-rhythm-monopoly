namespace RhythmMonopoly
{
    partial class Controller
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SpinGolden = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SpinBot = new System.Windows.Forms.NumericUpDown();
            this.SpinTop = new System.Windows.Forms.NumericUpDown();
            this.SpinConso = new System.Windows.Forms.NumericUpDown();
            this.SpinAlpha = new System.Windows.Forms.NumericUpDown();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SpinGolden)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinBot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinConso)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinAlpha)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.SpinGolden);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.SpinBot);
            this.groupBox1.Controls.Add(this.SpinTop);
            this.groupBox1.Controls.Add(this.SpinConso);
            this.groupBox1.Controls.Add(this.SpinAlpha);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(260, 357);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 266);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "황금 열쇠";
            // 
            // SpinGolden
            // 
            this.SpinGolden.Location = new System.Drawing.Point(195, 266);
            this.SpinGolden.Maximum = new decimal(new int[] {
            19,
            0,
            0,
            0});
            this.SpinGolden.Name = "SpinGolden";
            this.SpinGolden.Size = new System.Drawing.Size(40, 23);
            this.SpinGolden.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(95, 320);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "저장";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 207);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "상위 + 하위항목";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "상위항목만";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "자음";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "알파벳";
            // 
            // SpinBot
            // 
            this.SpinBot.Location = new System.Drawing.Point(195, 206);
            this.SpinBot.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.SpinBot.Name = "SpinBot";
            this.SpinBot.Size = new System.Drawing.Size(40, 23);
            this.SpinBot.TabIndex = 3;
            // 
            // SpinTop
            // 
            this.SpinTop.Location = new System.Drawing.Point(195, 150);
            this.SpinTop.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.SpinTop.Name = "SpinTop";
            this.SpinTop.Size = new System.Drawing.Size(40, 23);
            this.SpinTop.TabIndex = 2;
            // 
            // SpinConso
            // 
            this.SpinConso.Location = new System.Drawing.Point(195, 95);
            this.SpinConso.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.SpinConso.Name = "SpinConso";
            this.SpinConso.Size = new System.Drawing.Size(40, 23);
            this.SpinConso.TabIndex = 1;
            // 
            // SpinAlpha
            // 
            this.SpinAlpha.Location = new System.Drawing.Point(195, 40);
            this.SpinAlpha.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.SpinAlpha.Name = "SpinAlpha";
            this.SpinAlpha.Size = new System.Drawing.Size(40, 23);
            this.SpinAlpha.TabIndex = 0;
            // 
            // Controller
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 381);
            this.Controls.Add(this.groupBox1);
            this.Name = "Controller";
            this.Text = "항목 개수 설정";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Controller_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SpinGolden)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinBot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinConso)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinAlpha)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBox1;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private NumericUpDown SpinBot;
        private NumericUpDown SpinTop;
        private NumericUpDown SpinConso;
        private NumericUpDown SpinAlpha;
        private Button button1;
        private Label label5;
        private NumericUpDown SpinGolden;
    }
}