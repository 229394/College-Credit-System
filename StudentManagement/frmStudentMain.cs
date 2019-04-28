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
    public partial class frmStudentMain : Form
    {
        private Student student;
        public frmStudentMain()
        {
            InitializeComponent();
        }

        internal Student Student { get => student; set => student = value; }

        /// <summary>
        /// 学生主窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmStudentMain_Load(object sender, EventArgs e)
        {

        }
        
        /// <summary>
        /// 个人信息管理图片点击事件，主要为修改密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            frmStuUpdatePwd frmStuInfo = new frmStuUpdatePwd();
            frmStuInfo.Student = this.student;
            frmStuInfo.ShowDialog();
        }

        /// <summary>
        /// 课表查询点击图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            frmSearchCouTable frmsct = new frmSearchCouTable();
            frmsct.Student = this.student;
            frmsct.ShowDialog();
        }
        
        /// <summary>
        /// 点击选课图片事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            frmElectCourse frmecou = new frmElectCourse();
            frmecou.Student = this.student;
            frmecou.ShowDialog();
        }

        /// <summary>
        /// 学生成绩管理图片点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            frmSearchScore frmss1 = new frmSearchScore();
            frmss1.Student = this.student;
            frmss1.ShowDialog();
        }
    }
}
