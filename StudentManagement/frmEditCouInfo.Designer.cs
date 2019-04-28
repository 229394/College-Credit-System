namespace StudentManagement
{
    partial class frmEditCouInfo
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
            this.CourseAcademy = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.CourseNature = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.CourseHour = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.CourseCredit = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.CourseName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CourseNum = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CourseHour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CourseCredit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CourseAcademy);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.CourseNature);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.CourseHour);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.CourseCredit);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.CourseName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.CourseNum);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(21, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(550, 297);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "课程基本信息";
            // 
            // CourseAcademy
            // 
            this.CourseAcademy.FormattingEnabled = true;
            this.CourseAcademy.Location = new System.Drawing.Point(319, 191);
            this.CourseAcademy.Name = "CourseAcademy";
            this.CourseAcademy.Size = new System.Drawing.Size(207, 26);
            this.CourseAcademy.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(382, 160);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 18);
            this.label6.TabIndex = 10;
            this.label6.Text = "开课学院";
            // 
            // CourseNature
            // 
            this.CourseNature.FormattingEnabled = true;
            this.CourseNature.Location = new System.Drawing.Point(319, 91);
            this.CourseNature.Name = "CourseNature";
            this.CourseNature.Size = new System.Drawing.Size(207, 26);
            this.CourseNature.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(382, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 18);
            this.label5.TabIndex = 8;
            this.label5.Text = "课程性质";
            // 
            // CourseHour
            // 
            this.CourseHour.Increment = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.CourseHour.Location = new System.Drawing.Point(119, 217);
            this.CourseHour.Name = "CourseHour";
            this.CourseHour.Size = new System.Drawing.Size(159, 28);
            this.CourseHour.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 219);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 18);
            this.label4.TabIndex = 6;
            this.label4.Text = "课程学时";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // CourseCredit
            // 
            this.CourseCredit.Location = new System.Drawing.Point(119, 160);
            this.CourseCredit.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.CourseCredit.Name = "CourseCredit";
            this.CourseCredit.Size = new System.Drawing.Size(159, 28);
            this.CourseCredit.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "课程学分";
            // 
            // CourseName
            // 
            this.CourseName.Location = new System.Drawing.Point(119, 107);
            this.CourseName.Name = "CourseName";
            this.CourseName.Size = new System.Drawing.Size(159, 28);
            this.CourseName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "课程名";
            // 
            // CourseNum
            // 
            this.CourseNum.Location = new System.Drawing.Point(118, 48);
            this.CourseNum.Name = "CourseNum";
            this.CourseNum.Size = new System.Drawing.Size(160, 28);
            this.CourseNum.TabIndex = 1;
            this.CourseNum.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "课程号";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(124, 348);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 36);
            this.button1.TabIndex = 1;
            this.button1.Text = "保存(&S)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(325, 348);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(89, 36);
            this.button2.TabIndex = 2;
            this.button2.Text = "取消(&C)";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::StudentManagement.Properties.Resources.cancel;
            this.pictureBox2.Location = new System.Drawing.Point(269, 333);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(50, 50);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::StudentManagement.Properties.Resources.save;
            this.pictureBox1.Location = new System.Drawing.Point(65, 334);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // frmEditCouInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkTurquoise;
            this.ClientSize = new System.Drawing.Size(596, 396);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEditCouInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "编辑课程信息";
            this.Load += new System.EventHandler(this.frmEditCouInfo_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CourseHour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CourseCredit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox CourseNum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox CourseName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown CourseCredit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown CourseHour;
        private System.Windows.Forms.ComboBox CourseAcademy;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox CourseNature;
        private System.Windows.Forms.Label label5;
    }
}