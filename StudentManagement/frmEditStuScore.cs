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
    public partial class frmEditStuScore : Form
    {
        public string StuNum;
        public string CouName;
        public string StuName;
        DataSet ds = new DataSet();
        public frmEditStuScore()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 界面加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmEditStuScore_Load(object sender, EventArgs e)
        {
            GetStuInfo();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 保存按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            InsertStuScore();
        }

        /// <summary>
        /// 插入学生成绩的方法
        /// </summary>
        private void InsertStuScore()
        {
            DBHelper dBHelper = new DBHelper();
            try
            {
                //1.sql语句(最难的SQL语句)
                string sql = string.Format("insert into tb_stuscore(GradeID,ClassID,StudentID,CourseID,Score) select a.GradeID,a.ClassID,a.StudentID,b.CourseID,{0} from tb_student a,tb_course b,tb_coursetable c where a.ClassID=c.ClassID and a.GradeID=c.GradeID and c.CourseID=b.CourseID and a.StuNumber='{1}' and b.CourseName='{2}'", Convert.ToInt32(StudentScore.Value), this.StuNum, this.CouName);
                SqlCommand sqlCommand = new SqlCommand(sql, dBHelper.Connection);
                if (CheckStuScoreExist())
                {
                    MessageBox.Show("该学生此门课程成绩已添加!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    //3.打开连接
                    dBHelper.OpenConnection();
                    //4.执行
                    int result = sqlCommand.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("学生成绩添加成功!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("数据库添加失败!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// 检查学生成绩是否已经存在
        /// </summary>
        /// <returns></returns>
        private bool CheckStuScoreExist()
        {
            bool exist = false;
            DBHelper dBHelper = new DBHelper();
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("select * from tb_stuscore a,tb_student b,tb_course c where a.StudentID=b.StudentID and a.CourseID=c.CourseID and b.StuNumber='{0}' and c.CourseName='{1}'",StudentNum.Text,CourseName.Text);
                SqlCommand cmd = new SqlCommand(sb.ToString(), dBHelper.Connection);
                dBHelper.OpenConnection();
                SqlDataReader reader = cmd.ExecuteReader();
                //如果可读,即代表数据库里面存在该课程名称
                if (reader.Read())
                {
                    exist = true;

                }
                reader.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("数据库查找异常!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                dBHelper.CloseConnection();
            }
            return exist;
        }


        /// <summary>
        /// 添加时获取学生的基本信息
        /// </summary>
        private void GetStuInfo()
        {
            DBHelper dBHelper = new DBHelper();
            try
            {
                //1.sql语句
                string sql = string.Format("select * from tb_student a,tb_course b,tb_coursetable c,tb_grade d,tb_class e where a.GradeID=d.GradeID and a.ClassID=e.ClassID and b.CourseID=c.CourseID and c.ClassID=e.ClassID and c.GradeID=d.GradeID and a.StuNumber='{0}' and a.StuName='{1}' and b.CourseName='{2}'",StuNum,StuName,CouName);
                //2.执行工具
                SqlCommand command = new SqlCommand(sql, dBHelper.Connection);
                //3.打开连接
                dBHelper.OpenConnection();
                //4.执行
                SqlDataReader reader = command.ExecuteReader();
                //5.判断
                if (reader.Read())
                {
                    this.StudentNum.Text = reader["StuNumber"].ToString();
                    this.StudentName.Text = reader["StuName"].ToString();
                    this.CourseName.Text = reader["CourseName"].ToString();
                }
                reader.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("数据库获取学生信息失败!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                dBHelper.CloseConnection();
            }
        }
    }
}
