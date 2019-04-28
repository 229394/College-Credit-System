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
    public partial class frmUpdateStuScore : Form
    {
        public int StuScoreID ;
        DataSet ds = new DataSet();
        public frmUpdateStuScore()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 页面加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmUpdateStuScore_Load(object sender, EventArgs e)
        {
            GetStuScoreInfo();
        }

        /// <summary>
        /// 获取学生成绩信息
        /// </summary>
        private void GetStuScoreInfo()
        {
            DBHelper dBHelper = new DBHelper();
            try
            {
                //1.sql语句
                string sql = string.Format("select * from tb_stuscore a,tb_student b,tb_course c where a.StudentID=b.StudentID and a.CourseID=c.CourseID and a.StuScoreID={0}",this.StuScoreID);
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
                    this.StuScore.Value = Convert.ToInt32(reader["Score"].ToString());
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

        /// <summary>
        /// 修改按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            UpdateStuScore();
        }

        /// <summary>
        /// 修改学生成绩信息
        /// </summary>
        private void UpdateStuScore()
        {
            DBHelper dBHelper = new DBHelper();
            try
            {
                StringBuilder builder = new StringBuilder();
                //动态修改数据
                builder.AppendFormat("update [tb_stuscore] set [Score]={0}", Convert.ToInt32(this.StuScore.Value));
                builder.AppendFormat(" where [StuScoreID]='{0}'", this.StuScoreID);
                //执行工具
                SqlCommand command = new SqlCommand(builder.ToString(), dBHelper.Connection);
                //打开连接
                dBHelper.OpenConnection();
                //执行，result代表受影响的行数
                int result = command.ExecuteNonQuery();
                //判断,受影响行数为1,代表修改成功
                if (result > 0)
                {
                    MessageBox.Show("学生成绩修改成功!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("数据库修改失败!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                dBHelper.CloseConnection();
            }
        }

    }


   
}
