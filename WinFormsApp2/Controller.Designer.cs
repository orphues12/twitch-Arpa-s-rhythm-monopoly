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
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SpinBot = new System.Windows.Forms.NumericUpDown();
            this.SpinTop = new System.Windows.Forms.NumericUpDown();
            this.ConsoSpin = new System.Windows.Forms.NumericUpDown();
            this.SpinAlpha = new System.Windows.Forms.NumericUpDown();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SpinBot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConsoSpin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinAlpha)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.SpinBot);
            this.groupBox1.Controls.Add(this.SpinTop);
            this.groupBox1.Controls.Add(this.ConsoSpin);
            this.groupBox1.Controls.Add(this.SpinAlpha);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(260, 287);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
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
            this.SpinBot.Location = new System.Drawing.Point(139, 205);
            this.SpinBot.Name = "SpinBot";
            this.SpinBot.Size = new System.Drawing.Size(100, 23);
            this.SpinBot.TabIndex = 3;
            // 
            // SpinTop
            // 
            this.SpinTop.Location = new System.Drawing.Point(139, 150);
            this.SpinTop.Name = "SpinTop";
            this.SpinTop.Size = new System.Drawing.Size(100, 23);
            this.SpinTop.TabIndex = 2;
            // 
            // ConsoSpin
            // 
            this.ConsoSpin.Location = new System.Drawing.Point(139, 95);
            this.ConsoSpin.Name = "ConsoSpin";
            this.ConsoSpin.Size = new System.Drawing.Size(100, 23);
            this.ConsoSpin.TabIndex = 1;
            // 
            // SpinAlpha
            // 
            this.SpinAlpha.Location = new System.Drawing.Point(139, 40);
            this.SpinAlpha.Name = "SpinAlpha";
            this.SpinAlpha.Size = new System.Drawing.Size(100, 23);
            this.SpinAlpha.TabIndex = 0;
            // 
            // Controller
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 311);
            this.Controls.Add(this.groupBox1);
            this.Name = "Controller";
            this.Text = "Controller";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SpinBot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConsoSpin)).EndInit();
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
        private NumericUpDown ConsoSpin;
        private NumericUpDown SpinAlpha;
    }
}