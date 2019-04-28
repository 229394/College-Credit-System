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
    public partial class Login : Form
    {
        Admin admin = new Admin();
        Teacher teacher = new Teacher();
        Student student = new Student();

        public Login()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 退出事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 登录按钮事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (CheckInput())
            {
                if (Login1())
                {
                    if (radioButton1.Checked == true)//管理员
                    {
                        admin.AdminNumber1 = txtName.Text.Trim();
                        admin.AdminPwd1 = txtPwd.Text.Trim();
                        frmAdminMain frmadminMain = new frmAdminMain();
                        frmadminMain.Admin = admin;
                        frmadminMain.Show();
                        this.Hide();
                    }else if (radioButton2.Checked == true)//教师
                    {
                        teacher.TeacherNum1 = txtName.Text.Trim();
                        teacher.TeacherPwd1 = txtPwd.Text.Trim();
                        frmTeacherMain frmteacherMain = new frmTeacherMain();
                        frmteacherMain.Teacher = teacher;
                        frmteacherMain.Show();
                        this.Hide();

                    }
                    else//学生
                    {
                        student.StuNumber1 = txtName.Text.Trim();
                        student.StuPwd1 = txtPwd.Text.Trim();
                        frmStudentMain frmstudentMain = new frmStudentMain();
                        frmstudentMain.Student = student;
                        frmstudentMain.Show();
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("用户名或密码错误！");
                }

            }
        }

        /// <summary>
        /// 非空检验
        /// </summary>
        /// <returns></returns>
        private bool CheckInput()
        {
            if (txtName.Text.Trim() == "")
            {
                MessageBox.Show("请输入用户名!");
                return false;
            }
            else if (txtPwd.Text.Trim() == "")
            {
                MessageBox.Show("请输入密码!");
                return false;
            }
            else if(radioButton1.Checked==false && radioButton2.Checked==false && radioButton3.Checked == false)
            {
                MessageBox.Show("请选择登录权限!");
                return false;
            }
            return true;
        }

        /// <summary>
        /// 登陆的方法
        /// </summary>
        /// <returns></returns>
        public bool Login1()
        {
            bool flag = false;
            string name = txtName.Text.Trim();
            string pwd = txtPwd.Text.Trim();
            DBHelper dBHelper = new DBHelper();
            try
            {
                //管理员登录模式
                if (this.radioButton1.Checked == true)
                {
                    //1.sql语句
                    string sql = string.Format("select * from [tb_admin] where AdminNumber='{0}' and AdminPwd='{1}'", name, pwd);
                    //2.command工具
                    SqlCommand cmd = new SqlCommand(sql, dBHelper.Connection);
                    //3.打开连接
                    dBHelper.OpenConnection();
                    //4.执行
                    SqlDataReader reader = cmd.ExecuteReader();
                    //5.判断
                    if (reader.Read())
                    {
                        admin.AdminID1 = Convert.ToInt32(reader[0]);
                        admin.AdminNumber1 = reader[1].ToString();
                        admin.AdminPwd1 = reader[2].ToString();
                        flag = true;
                    }
                }
                else if(this.radioButton2.Checked==true)//教师登录
                {
                    //1.sql语句
                    string sql = string.Format("select * from [tb_teacher] where TeacherNum='{0}' and TeacherPwd='{1}'", name, pwd);
                    //2.command工具
                    SqlCommand cmd = new SqlCommand(sql, dBHelper.Connection);
                    //3.打开连接
                    dBHelper.OpenConnection();
                    //4.执行
                    SqlDataReader reader = cmd.ExecuteReader();
                    //5.判断
                    if (reader.Read())
                    {
                        teacher.TeacherID1 = Convert.ToInt32(reader[0]);
                        teacher.TeacherNum1 = reader[1].ToString();
                        teacher.TeacherPwd1 = reader[2].ToString();
                        flag = true;
                    }

                }
                else//学生登录
                {
                    //1.sql语句
                    string sql = string.Format("select * from [tb_student] where StuNumber='{0}' and StuPwd='{1}'", name, pwd);
                    //2.command工具
                    SqlCommand cmd = new SqlCommand(sql, dBHelper.Connection);
                    //3.打开连接
                    dBHelper.OpenConnection();
                    //4.执行
                    SqlDataReader reader = cmd.ExecuteReader();
                    //5.判断
                    if (reader.Read())
                    {
                        student.StudentID1 = Convert.ToInt32(reader[0]);
                        student.StuNumber1 = reader[1].ToString();
                        student.StuPwd1 = reader[2].ToString();
                        flag = true;
                    }

                }    
            }
            catch (Exception e)
            {
                MessageBox.Show("发生异常：", e.Message);
            }
            finally
            {
                //关闭数据库
                dBHelper.CloseConnection();
            }
            return flag;
        }

    }
}
