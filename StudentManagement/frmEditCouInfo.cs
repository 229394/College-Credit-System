using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace StudentManagement
{
    public partial class frmEditCouInfo : Form
    {
        public int CourseID = 0;
        DataSet ds = new DataSet();
        public frmEditCouInfo()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 保存按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (CheckInput())
            {
                if (CourseID == 0)//新增
                {
                    InsertCouInfo();
                }
                else//修改
                {
                    UpdateCouInfo();
                }
            }

        }

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmEditCouInfo_Load(object sender, EventArgs e)
        {
            if (CourseID == 0)//添加
            {
                this.GetCouAcademy();//获取开课学院
                this.GetCouNature();//获取课程性质
            }
            else//修改
            {
                //获取课程信息
                this.GetCouInfo();
                this.button1.Text = "修改(&M)";
            }
        }

        /// <summary>
        /// 非空检验
        /// </summary>
        /// <returns></returns>
        private bool CheckInput()
        {
            bool flag = true;
            if (CourseNum.Text.Trim().Length == 0)
            {
                MessageBox.Show("课程号不能为空!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                flag = false;
            }
            else if (CourseName.Text.Trim().Length == 0)
            {
                MessageBox.Show("课程名不能为空!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                flag = false;
            }
            return flag;
        }

        /// <summary>
        /// 插入课程信息的方法
        /// </summary>
        private void InsertCouInfo()
        {
            DBHelper dBHelper = new DBHelper();
            try
            {
                //1.sql语句
                string sql = string.Format("insert into tb_course values('{0}','{1}',{2},{3},{4},{5})", CourseNum.Text.Trim(), CourseName.Text.Trim(),Convert.ToInt32(CourseCredit.Value.ToString()),Convert.ToInt32(CourseHour.Value.ToString()),Convert.ToInt32(CourseNature.SelectedValue), Convert.ToInt32(CourseAcademy.SelectedValue));
                //2.执行工具
                SqlCommand sqlCommand = new SqlCommand(sql, dBHelper.Connection);
                //3.打开连接
                dBHelper.OpenConnection();
                //4.执行
                int result = sqlCommand.ExecuteNonQuery();
                if (result == 1)
                {
                    MessageBox.Show("课程信息添加成功!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("数据库添加失败!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// 获取所有的学院
        /// </summary>
        private void GetCouAcademy()
        {
            DBHelper dBHelper = new DBHelper();
            try
            {
                string sql = string.Format(@"select * from tb_academy order by AcademyID");
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dBHelper.Connection);
                adapter.Fill(ds, "AllAcademy");
                DataRow dr = ds.Tables["AllAcademy"].NewRow();
                dr[0] = "0";
                dr[1] = "请选择学院";
                ds.Tables["AllAcademy"].Rows.InsertAt(dr, 0);
                //绑定数据
                this.CourseAcademy.DataSource = ds.Tables["AllAcademy"];
                this.CourseAcademy.ValueMember = "AcademyID";
                //显示学院名称
                this.CourseAcademy.DisplayMember = "AcademyName";
                this.CourseAcademy.SelectedValue = "0";
            }
            catch (Exception)
            {
                MessageBox.Show("数据库查询学院异常!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }

        /// <summary>
        /// 获取所有的课程性质
        /// </summary>
        private void GetCouNature()
        {
            DBHelper dBHelper = new DBHelper();
            try
            {
                string sql = string.Format(@"select * from tb_nature order by NatureID");
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dBHelper.Connection);
                adapter.Fill(ds, "AllNature");
                DataRow dr = ds.Tables["AllNature"].NewRow();
                dr[0] = "0";
                dr[1] = "请选择课程性质";
                ds.Tables["AllNature"].Rows.InsertAt(dr, 0);
                //绑定数据
                this.CourseNature.DataSource = ds.Tables["AllNature"];
                this.CourseNature.ValueMember = "NatureID";
                //显示课程性质名称
                this.CourseNature.DisplayMember = "NatureName";
                this.CourseNature.SelectedValue = "0";
            }
            catch (Exception)
            {
                MessageBox.Show("数据库查询课程性质异常!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        /// <summary>
        /// 修改之前获取对应的课程信息
        /// </summary>
        private void GetCouInfo()
        {
            //获取学院
            GetCouAcademy();
            //获取课程性质
            GetCouNature();
            DBHelper dBHelper = new DBHelper();
            try
            {
                //1.sql语句
                string sql = string.Format("select * from tb_course where CourseID={0}", CourseID);
                //2.执行工具
                SqlCommand command = new SqlCommand(sql, dBHelper.Connection);
                //3.代开连接
                dBHelper.OpenConnection();
                //4.执行
                SqlDataReader reader = command.ExecuteReader();
                //5.判断
                if (reader.Read())
                {
                    this.CourseNum.Text = reader["CourseNum"].ToString();
                    this.CourseName.Text = reader["CourseName"].ToString();
                    this.CourseCredit.Value = Convert.ToInt32(reader["CourseCredit"].ToString());
                    this.CourseHour.Value = Convert.ToInt32(reader["CourseHour"].ToString());
                    this.CourseAcademy.SelectedValue = reader["AcademyID"].ToString();
                    this.CourseNature.SelectedValue = reader["NatureID"].ToString();
                }
                reader.Close();

            }
            catch (Exception)
            {
                MessageBox.Show("数据库获取课程信息失败!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                dBHelper.CloseConnection();
            }

        }   
        /// <summary>
        ///修改课程信息的方法 
        /// </summary>
        private void UpdateCouInfo()
        {
            DBHelper dBHelper = new DBHelper();
            try
            {
                StringBuilder builder = new StringBuilder();
                //动态修改数据
                builder.AppendFormat("update [tb_course] set [CourseNum]='{0}'", this.CourseNum.Text);
                builder.AppendFormat(",[CourseName]='{0}'", this.CourseName.Text);
                builder.AppendFormat(",[CourseCredit]='{0}'", this.CourseCredit.Value);
                builder.AppendFormat(",[CourseHour]='{0}'", this.CourseHour.Value);
                builder.AppendFormat(",[AcademyID]='{0}'", Convert.ToInt32(this.CourseAcademy.SelectedValue));
                builder.AppendFormat(",[NatureID]='{0}'", Convert.ToInt32(this.CourseNature.SelectedValue));
                builder.AppendFormat(" where [CourseID]='{0}'", this.CourseID);
                //执行工具
                SqlCommand command = new SqlCommand(builder.ToString(), dBHelper.Connection);
                //打开连接
                dBHelper.OpenConnection();
                //执行，result代表受影响的行数
                int result = command.ExecuteNonQuery();
                //判断,受影响行数为1,代表修改成功
                if (result == 1)
                {
                    MessageBox.Show("课程信息修改成功!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
