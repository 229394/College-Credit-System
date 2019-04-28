using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagement
{
    public partial class frmStuUpdatePwd : Form
    {
        private Student student;
     
        public frmStuUpdatePwd()
        {
            InitializeComponent();
        }

        internal Student Student { get => student; set => student = value; }

        /// <summary>
        /// 点击修改按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (CheckInput())//非空检验
            {
                int result = UpdatePwd();
                if (result > 0)
                {
                    MessageBox.Show("更新密码成功！");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("更新密码失败！");
                }
            }
        }

        public bool CheckInput()
        {
            if (txtPwd.Text.Trim() == "")
            {
                MessageBox.Show("原密码不能为空!");
                return false;
            }
            if (txtPwd.Text.Trim() != student.StuPwd1)
            {
                MessageBox.Show("原密码输入错误!");
                return false;
            }
            if (txtNewPwd.Text.Trim() == "")
            {
                MessageBox.Show("请输入新密码!");
                return false;
            }
            if (txtConfirmNewPwd.Text.Trim() == "")
            {
                MessageBox.Show("请再次输入新密码!");
                return false;
            }
            if (txtNewPwd.Text.Trim() != txtConfirmNewPwd.Text.Trim())
            {
                MessageBox.Show("两次新密码输入不一致!");
                return false;
            }
            return true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 修改密码的方法
        /// </summary>
        /// <returns></returns>
        public int UpdatePwd()
        {
            int result = 0;
            DBHelper dBHelper = new DBHelper();
            //sql语句
            string sql = string.Format(@"update [tb_student] set StuPwd='{0}' where StudentID={1}", txtNewPwd.Text.Trim(), student.StudentID1);

            try
            {
                //创建cmd
                SqlCommand cmd = new SqlCommand(sql, dBHelper.Connection);
                //打开连接
                dBHelper.OpenConnection();
                //执行
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                dBHelper.CloseConnection();
            }
            return result;
        }
    }
}
