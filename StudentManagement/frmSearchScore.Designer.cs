namespace StudentManagement
{
    partial class frmSearchScore
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("90分及以上");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("80分及以上");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("70分及以上");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("60分及以上");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("60分以下");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("所有成绩", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSearchScore));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.AllMyScoreInfo = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AllMyScoreInfo)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LightGreen;
            this.groupBox1.Controls.Add(this.AllMyScoreInfo);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.Location = new System.Drawing.Point(254, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(921, 626);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "我的成绩";
            // 
            // AllMyScoreInfo
            // 
            this.AllMyScoreInfo.AllowUserToAddRows = false;
            this.AllMyScoreInfo.BackgroundColor = System.Drawing.Color.MediumAquamarine;
            this.AllMyScoreInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AllMyScoreInfo.Location = new System.Drawing.Point(6, 27);
            this.AllMyScoreInfo.Name = "AllMyScoreInfo";
            this.AllMyScoreInfo.RowHeadersVisible = false;
            this.AllMyScoreInfo.RowTemplate.Height = 30;
            this.AllMyScoreInfo.Size = new System.Drawing.Size(909, 599);
            this.AllMyScoreInfo.TabIndex = 0;
            this.AllMyScoreInfo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox2.Controls.Add(this.treeView1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(254, 626);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "成绩分类";
            // 
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.Color.YellowGreen;
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.imageList1;
            this.treeView1.Location = new System.Drawing.Point(0, 28);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "节点1";
            treeNode1.Text = "90分及以上";
            treeNode2.Name = "节点4";
            treeNode2.Text = "80分及以上";
            treeNode3.Name = "节点5";
            treeNode3.Text = "70分及以上";
            treeNode4.Name = "节点6";
            treeNode4.Text = "60分及以上";
            treeNode5.Name = "节点7";
            treeNode5.Text = "60分以下";
            treeNode6.Name = "节点0";
            treeNode6.Text = "所有成绩";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode6});
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.Size = new System.Drawing.Size(248, 598);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "treeicon.jpg");
            // 
            // frmSearchScore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGreen;
            this.ClientSize = new System.Drawing.Size(1175, 626);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSearchScore";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "成绩查询管理";
            this.Load += new System.EventHandler(this.frmSearchScore_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AllMyScoreInfo)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView AllMyScoreInfo;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ImageList imageList1;
    }
}