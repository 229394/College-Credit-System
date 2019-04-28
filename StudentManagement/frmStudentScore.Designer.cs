namespace StudentManagement
{
    partial class frmStudentScore
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvStuInfo = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvStuScoreInfo = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.FailStudent = new System.Windows.Forms.NumericUpDown();
            this.AveScore = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.MinScore = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.MaxScore = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStuInfo)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStuScoreInfo)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FailStudent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AveScore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinScore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxScore)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripButton4});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1075, 55);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = global::StudentManagement.Properties.Resources.add;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Padding = new System.Windows.Forms.Padding(0, 0, 50, 0);
            this.toolStripButton1.Size = new System.Drawing.Size(100, 52);
            this.toolStripButton1.Text = "添加";
            this.toolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = global::StudentManagement.Properties.Resources.update;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Padding = new System.Windows.Forms.Padding(0, 0, 50, 0);
            this.toolStripButton2.Size = new System.Drawing.Size(100, 52);
            this.toolStripButton2.Text = "修改";
            this.toolStripButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Image = global::StudentManagement.Properties.Resources.delete;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Padding = new System.Windows.Forms.Padding(0, 0, 50, 0);
            this.toolStripButton3.Size = new System.Drawing.Size(100, 52);
            this.toolStripButton3.Text = "删除";
            this.toolStripButton3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.Image = global::StudentManagement.Properties.Resources.exit;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Padding = new System.Windows.Forms.Padding(0, 0, 50, 0);
            this.toolStripButton4.Size = new System.Drawing.Size(100, 52);
            this.toolStripButton4.Text = "退出";
            this.toolStripButton4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvStuInfo);
            this.groupBox1.Location = new System.Drawing.Point(13, 68);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(766, 280);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "所教学生信息";
            // 
            // dgvStuInfo
            // 
            this.dgvStuInfo.AllowUserToAddRows = false;
            this.dgvStuInfo.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.dgvStuInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStuInfo.Location = new System.Drawing.Point(7, 27);
            this.dgvStuInfo.Name = "dgvStuInfo";
            this.dgvStuInfo.RowHeadersVisible = false;
            this.dgvStuInfo.RowTemplate.Height = 30;
            this.dgvStuInfo.Size = new System.Drawing.Size(753, 247);
            this.dgvStuInfo.TabIndex = 0;
            this.dgvStuInfo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStuInfo_CellContentClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvStuScoreInfo);
            this.groupBox2.Location = new System.Drawing.Point(13, 354);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(766, 306);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "学生成绩信息";
            // 
            // dgvStuScoreInfo
            // 
            this.dgvStuScoreInfo.AllowUserToAddRows = false;
            this.dgvStuScoreInfo.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.dgvStuScoreInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStuScoreInfo.Location = new System.Drawing.Point(7, 21);
            this.dgvStuScoreInfo.Name = "dgvStuScoreInfo";
            this.dgvStuScoreInfo.RowHeadersVisible = false;
            this.dgvStuScoreInfo.RowTemplate.Height = 30;
            this.dgvStuScoreInfo.Size = new System.Drawing.Size(753, 279);
            this.dgvStuScoreInfo.TabIndex = 0;
            this.dgvStuScoreInfo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStuScoreInfo_CellContentClick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.FailStudent);
            this.groupBox3.Controls.Add(this.AveScore);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.MinScore);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.MaxScore);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(785, 68);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(278, 592);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "成绩数据统计";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 394);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 18);
            this.label5.TabIndex = 11;
            this.label5.Text = "不及格人数:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // FailStudent
            // 
            this.FailStudent.Location = new System.Drawing.Point(120, 394);
            this.FailStudent.Name = "FailStudent";
            this.FailStudent.ReadOnly = true;
            this.FailStudent.Size = new System.Drawing.Size(120, 28);
            this.FailStudent.TabIndex = 10;
            // 
            // AveScore
            // 
            this.AveScore.Location = new System.Drawing.Point(120, 296);
            this.AveScore.Name = "AveScore";
            this.AveScore.ReadOnly = true;
            this.AveScore.Size = new System.Drawing.Size(120, 28);
            this.AveScore.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 298);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 18);
            this.label4.TabIndex = 8;
            this.label4.Text = "平均分:";
            // 
            // MinScore
            // 
            this.MinScore.Location = new System.Drawing.Point(120, 197);
            this.MinScore.Name = "MinScore";
            this.MinScore.ReadOnly = true;
            this.MinScore.Size = new System.Drawing.Size(120, 28);
            this.MinScore.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 199);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 18);
            this.label3.TabIndex = 6;
            this.label3.Text = "最低分:";
            // 
            // MaxScore
            // 
            this.MaxScore.Location = new System.Drawing.Point(120, 110);
            this.MaxScore.Name = "MaxScore";
            this.MaxScore.ReadOnly = true;
            this.MaxScore.Size = new System.Drawing.Size(120, 28);
            this.MaxScore.TabIndex = 5;
            this.MaxScore.ValueChanged += new System.EventHandler(this.MaxScore_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "最高分:";
            // 
            // frmStudentScore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSeaGreen;
            this.ClientSize = new System.Drawing.Size(1075, 672);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmStudentScore";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "学生成绩管理";
            this.Load += new System.EventHandler(this.frmStudentScore_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStuInfo)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStuScoreInfo)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FailStudent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AveScore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinScore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxScore)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvStuInfo;
        private System.Windows.Forms.DataGridView dgvStuScoreInfo;
        private System.Windows.Forms.NumericUpDown MinScore;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown MaxScore;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown AveScore;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown FailStudent;
    }
}