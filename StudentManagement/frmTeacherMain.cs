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
    public partial class frmTeacherMain : Form
    {
        private Teacher teacher;
        public frmTeacherMain()
        {
            InitializeComponent();
        }

        internal Teacher Teacher { get => teacher; set => teacher = value; }

        private void frmTeacherMain_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 教师个人信息管理图片点击事件,主要为修改密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            frmTeaUpdatePwd frmtup = new frmTeaUpdatePwd();
            frmtup.Teacher = this.teacher;
            frmtup.ShowDialog();
        }

        /// <summary>
        /// 教务公告查询图片点击按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            frmSearchNoticeInfo frmsnInfo = new frmSearchNoticeInfo();
            frmsnInfo.ShowDialog();
        }

        /// <summary>
        /// 教师授课查询图片点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            frmSearchCouArrange frmsca = new frmSearchCouArrange();
            frmsca.Teacher = this.teacher;
            frmsca.ShowDialog();
        }

        /// <summary>
        /// 学生成绩管理图片点击按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            frmStudentScore frmss = new frmStudentScore();
            frmss.Teacher = this.teacher;
            frmss.ShowDialog();
        }
    }
}
