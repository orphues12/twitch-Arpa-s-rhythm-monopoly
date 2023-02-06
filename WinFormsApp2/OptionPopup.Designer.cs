namespace RhythmMonopoly
{
    partial class OptionPopup
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
            this.Savebutton1 = new System.Windows.Forms.Button();
            this.cmbCategoryTop = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCategoryTop = new System.Windows.Forms.TextBox();
            this.txtCategoryBottom = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbCategoryBottom = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnController = new System.Windows.Forms.Button();
            this.ChkRandom = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkSuperRandom = new System.Windows.Forms.CheckBox();
            this.btnOpenINI = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Savebutton1
            // 
            this.Savebutton1.Location = new System.Drawing.Point(34, 293);
            this.Savebutton1.Name = "Savebutton1";
            this.Savebutton1.Size = new System.Drawing.Size(93, 23);
            this.Savebutton1.TabIndex = 4;
            this.Savebutton1.Text = "저장";
            this.Savebutton1.UseVisualStyleBackColor = true;
            this.Savebutton1.Click += new System.EventHandler(this.Savebutton1_Click);
            // 
            // cmbCategoryTop
            // 
            this.cmbCategoryTop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategoryTop.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbCategoryTop.FormattingEnabled = true;
            this.cmbCategoryTop.Location = new System.Drawing.Point(17, 92);
            this.cmbCategoryTop.Name = "cmbCategoryTop";
            this.cmbCategoryTop.Size = new System.Drawing.Size(151, 23);
            this.cmbCategoryTop.TabIndex = 8;
            this.cmbCategoryTop.SelectedValueChanged += new System.EventHandler(this.cmbCategoryTop_SelectedValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(17, 133);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 25);
            this.label8.TabIndex = 11;
            this.label8.Text = "하위 항목";
            // 
            // txtCategoryTop
            // 
            this.txtCategoryTop.Location = new System.Drawing.Point(201, 92);
            this.txtCategoryTop.Name = "txtCategoryTop";
            this.txtCategoryTop.Size = new System.Drawing.Size(151, 23);
            this.txtCategoryTop.TabIndex = 12;
            this.txtCategoryTop.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Enter_KeyDown1);
            // 
            // txtCategoryBottom
            // 
            this.txtCategoryBottom.Location = new System.Drawing.Point(201, 163);
            this.txtCategoryBottom.Name = "txtCategoryBottom";
            this.txtCategoryBottom.Size = new System.Drawing.Size(151, 23);
            this.txtCategoryBottom.TabIndex = 13;
            this.txtCategoryBottom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Enter_KeyDown1);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(199, 64);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(140, 25);
            this.label9.TabIndex = 14;
            this.label9.Text = "변경 상위 항목";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(201, 133);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(140, 25);
            this.label10.TabIndex = 15;
            this.label10.Text = "변경 하위 항목";
            // 
            // cmbCategoryBottom
            // 
            this.cmbCategoryBottom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategoryBottom.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbCategoryBottom.FormattingEnabled = true;
            this.cmbCategoryBottom.Location = new System.Drawing.Point(17, 163);
            this.cmbCategoryBottom.Name = "cmbCategoryBottom";
            this.cmbCategoryBottom.Size = new System.Drawing.Size(151, 23);
            this.cmbCategoryBottom.TabIndex = 17;
            this.cmbCategoryBottom.SelectedValueChanged += new System.EventHandler(this.cmbCategorybottom_SelectedValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(17, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 25);
            this.label4.TabIndex = 9;
            this.label4.Text = "상위 항목";
            // 
            // btnController
            // 
            this.btnController.Location = new System.Drawing.Point(34, 212);
            this.btnController.Name = "btnController";
            this.btnController.Size = new System.Drawing.Size(118, 23);
            this.btnController.TabIndex = 29;
            this.btnController.Text = "항목 개수 설정";
            this.btnController.UseVisualStyleBackColor = true;
            this.btnController.Click += new System.EventHandler(this.btnController_Click);
            // 
            // ChkRandom
            // 
            this.ChkRandom.AutoSize = true;
            this.ChkRandom.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ChkRandom.Location = new System.Drawing.Point(17, 31);
            this.ChkRandom.Name = "ChkRandom";
            this.ChkRandom.Size = new System.Drawing.Size(122, 19);
            this.ChkRandom.TabIndex = 31;
            this.ChkRandom.Text = "판 항목 전체 랜덤";
            this.ChkRandom.UseVisualStyleBackColor = true;
            this.ChkRandom.CheckedChanged += new System.EventHandler(this.ChkRandom_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.chkSuperRandom);
            this.groupBox1.Controls.Add(this.btnOpenINI);
            this.groupBox1.Controls.Add(this.ChkRandom);
            this.groupBox1.Controls.Add(this.btnController);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.cmbCategoryBottom);
            this.groupBox1.Controls.Add(this.Savebutton1);
            this.groupBox1.Controls.Add(this.cmbCategoryTop);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtCategoryBottom);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtCategoryTop);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(410, 337);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "설정";
            // 
            // chkSuperRandom
            // 
            this.chkSuperRandom.AutoSize = true;
            this.chkSuperRandom.Location = new System.Drawing.Point(222, 258);
            this.chkSuperRandom.Name = "chkSuperRandom";
            this.chkSuperRandom.Size = new System.Drawing.Size(15, 14);
            this.chkSuperRandom.TabIndex = 33;
            this.chkSuperRandom.UseVisualStyleBackColor = true;
            this.chkSuperRandom.CheckedChanged += new System.EventHandler(this.chkSuperRandom_CheckedChanged);
            // 
            // btnOpenINI
            // 
            this.btnOpenINI.Location = new System.Drawing.Point(34, 253);
            this.btnOpenINI.Name = "btnOpenINI";
            this.btnOpenINI.Size = new System.Drawing.Size(138, 23);
            this.btnOpenINI.TabIndex = 32;
            this.btnOpenINI.Text = "설정 INI 파일 열기";
            this.btnOpenINI.UseVisualStyleBackColor = true;
            this.btnOpenINI.Click += new System.EventHandler(this.btnOpenINI_Click);
            // 
            // label1
            // 
            this.label1.Image = global::RhythmMonopoly.Properties.Resources.SuperRandom;
            this.label1.Location = new System.Drawing.Point(253, 212);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 103);
            this.label1.TabIndex = 34;
            // 
            // OptionPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(434, 361);
            this.Controls.Add(this.groupBox1);
            this.Name = "OptionPopup";
            this.Text = "설정";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Popup_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Button Savebutton1;
        private ComboBox cmbCategoryTop;
        private Label label8;
        private TextBox txtCategoryTop;
        private TextBox txtCategoryBottom;
        private Label label9;
        private Label label10;
        private ComboBox cmbCategoryBottom;
        private Label label4;
        private Button btnController;
        private CheckBox ChkRandom;
        private GroupBox groupBox1;
        private Button btnOpenINI;
        private CheckBox chkSuperRandom;
        private Label label1;
    }
}