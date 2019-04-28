using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagement
{
    public partial class frmAdminMain : Form
    {
        private Admin admin;
        public frmAdminMain()
        {
            InitializeComponent();
        }

        internal Admin Admin { get => admin; set => admin = value; }

        private void frmAdminMain_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 退出事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("确定要退出吗?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                Application.Exit();
            }

        }

        /// <summary>
        /// 修改密码点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 修改密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangeAdminPwd fcap = new frmChangeAdminPwd();
            fcap.Admin = this.admin;
            fcap.Show();

        }

        /// <summary>
        /// 关于我们按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 小组介绍ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAboutUs fas = new frmAboutUs();
            fas.ShowDialog();
        }

        /// <summary>
        /// 点击学生图片事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            frmStudentInfo fsInfo = new frmStudentInfo();
            fsInfo.ShowDialog();
        }

        /// <summary>
        /// 点击教师图片事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            frmTeacherInfo ftInfo = new frmTeacherInfo();
            ftInfo.ShowDialog();
        }

        /// <summary>
        /// 点击课程图片事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            frmCourseInfo fcInfo = new frmCourseInfo();
            fcInfo.ShowDialog();
        }

        /// <summary>
        /// 点击公告图片事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            frmNoticeInfo fnInfo = new frmNoticeInfo();
            fnInfo.ShowDialog();
        }

        private void 修改密码ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmChangeAdminPwd fcap = new frmChangeAdminPwd();
            fcap.Admin = this.admin;
            fcap.Show();
        }

        private void 退出ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("确定要退出吗?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void 小组介绍ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAboutUs fas = new frmAboutUs();
            fas.ShowDialog();
        }
    }
}
