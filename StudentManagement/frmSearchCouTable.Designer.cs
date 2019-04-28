namespace StudentManagement
{
    partial class frmSearchCouTable
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvMyCouTable = new System.Windows.Forms.DataGridView();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMyCouTable)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvMyCouTable);
            this.groupBox2.Location = new System.Drawing.Point(13, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(927, 611);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "我的课表信息";
            // 
            // dgvMyCouTable
            // 
            this.dgvMyCouTable.AllowUserToAddRows = false;
            this.dgvMyCouTable.BackgroundColor = System.Drawing.Color.DarkTurquoise;
            this.dgvMyCouTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMyCouTable.Location = new System.Drawing.Point(6, 27);
            this.dgvMyCouTable.Name = "dgvMyCouTable";
            this.dgvMyCouTable.RowHeadersVisible = false;
            this.dgvMyCouTable.RowTemplate.Height = 30;
            this.dgvMyCouTable.Size = new System.Drawing.Size(915, 578);
            this.dgvMyCouTable.TabIndex = 0;
            this.dgvMyCouTable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStuCouTable_CellContentClick);
            // 
            // frmSearchCouTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(952, 625);
            this.Controls.Add(this.groupBox2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSearchCouTable";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "课表查询管理";
            this.Load += new System.EventHandler(this.frmSearchCouTable_Load);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMyCouTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvMyCouTable;
    }
}