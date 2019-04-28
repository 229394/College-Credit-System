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
    public partial class frmEditStuInfo : Form
    {
        public int StudentID = 0;
        DataSet ds = new DataSet();
        public frmEditStuInfo()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void frmEditStuInfo_Load(object sender, EventArgs e)
        {
            if (StudentID == 0)//添加
            {
                this.GetStuGrade();
                this.GetStuAcademy();
                this.GetStuClass();
            }
            else//修改
            {
                //获取学生信息
                this.GetStuInfo();
                this.button1.Text = "修改(&M)";
            }
        }
            private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 与班级进行捆绑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (StuAcademy.SelectedIndex > -1)
            {
                DataRowView drv = (DataRowView)StuAcademy.SelectedItem;
                int id = Convert.ToInt32(drv.Row["AcademyID"].ToString());
                DBHelper dBHelper = new DBHelper();
                try
                {
                    SqlCommand cmd = new SqlCommand("select * from tb_class where AcademyID='" + id + "'", dBHelper.Connection);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    DataRow dr = dt.NewRow();
                    dr[0] = "0";
                    dr[1] = "请选择班级";
                    dt.Rows.InsertAt(dr, 0);
                    StuClass.DataSource = dt;
                    StuClass.DisplayMember = "ClassName";
                    StuClass.ValueMember = "ClassID";
                    //初始指向0
                    StuClass.SelectedValue = "0";
                }
                catch (Exception)
                {
                    MessageBox.Show("数据库联动查询失败!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }

        /// <summary>
        /// 保存按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (CheckInput())//非空检验
            {
                if (StudentID == 0)//新增
                {
                    InsertStuInfo();
                }
                else//修改
                {
                    UpdateStuInfo();
                }
            }

        }

        /// <summary>
        /// 获取所有的年级
        /// </summary>
        private void GetStuGrade()
        {
            DBHelper dBHelper = new DBHelper();
            try
            {
                string sql = string.Format(@"select * from tb_grade order by GradeID");
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dBHelper.Connection);
                adapter.Fill(ds, "AllGrade");
                //绑定数据
                this.StuGrade.DataSource = ds.Tables["AllGrade"];
                this.StuGrade.ValueMember = "GradeID";
                //显示年级名
                this.StuGrade.DisplayMember = "GradeName";
            }
            catch (Exception)
            {
                MessageBox.Show("数据库查询年级异常!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }

        /// <summary>
        /// 获取所有的学院
        /// </summary>
        private void GetStuAcademy()
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
                this.StuAcademy.DataSource = ds.Tables["AllAcademy"];
                this.StuAcademy.ValueMember = "AcademyID";
                //显示学院名称
                this.StuAcademy.DisplayMember = "AcademyName";
                this.StuAcademy.SelectedValue = "0";
            }
            catch (Exception)
            {
                MessageBox.Show("数据库查询学院异常!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }

        /// <summary>
        /// 获取所有的班级
        /// </summary>
        private void GetStuClass()
        {
            DBHelper dBHelper = new DBHelper();
            try
            {
                string sql = string.Format(@"select * from tb_class order by ClassID");
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dBHelper.Connection);
                adapter.Fill(ds, "AllClass");
                DataRow dr = ds.Tables["AllClass"].NewRow();
                dr[0] = "0";
                dr[1] = "请选择班级";
                ds.Tables["AllClass"].Rows.InsertAt(dr, 0);
                //绑定数据
                this.StuClass.DataSource = ds.Tables["AllClass"];
                this.StuClass.ValueMember = "ClassID";
                //显示班级名
                this.StuClass.DisplayMember = "ClassName";
                //初始指向0
                this.StuClass.SelectedValue = "0";
            }
            catch (Exception)
            {
                MessageBox.Show("数据库查询班级异常!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }

        /// <summary>
        /// 非空检验
        /// </summary>
        /// <returns></returns>
        private bool CheckInput()
        {
            bool flag = true;
            if (txtStuNum.Text.Trim().Length == 0)
            {
                MessageBox.Show("学生学号不能为空!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                flag = false;
            }
            else if (txtStuName.Text.Trim().Length == 0)
            {
                MessageBox.Show("学生姓名不能为空!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                flag = false;
            }
            return flag;
        }

        /// <summary>
        /// 新增学生的方法
        /// </summary>
        private void InsertStuInfo()
        {
            DBHelper dBHelper = new DBHelper();
            try
            {
                string sex;
                if(this.radioButton1.Checked == true)
                {
                    sex = radioButton1.Text;
                }
                else
                {
                    sex = radioButton2.Text;
                }
                //1.sql语句
                string sql = string.Format("insert into tb_student values('{0}','{1}','{2}','{3}','{4}',{5},{6},{7})", txtStuNum.Text.Trim(),"123456",txtStuName.Text.Trim(),sex,StuBirthday.Value.ToString("yyyy-MM-dd"),Convert.ToInt32(StuAcademy.SelectedValue),Convert.ToInt32(StuClass.SelectedValue),Convert.ToInt32(StuGrade.SelectedValue));
                //2.执行工具
                SqlCommand sqlCommand = new SqlCommand(sql, dBHelper.Connection);
                //3.打开连接
                dBHelper.OpenConnection();
                //4.执行
                int result = sqlCommand.ExecuteNonQuery();
                if (result == 1)
                {
                    MessageBox.Show("学生信息添加成功!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("数据库添加失败!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 修改之前先获取学生的信息
        /// </summary>
        private void GetStuInfo()
        {
            //获取年级
            GetStuGrade();
            //获取学院
            GetStuAcademy();
            //获取班级
            GetStuClass();
            DBHelper dBHelper = new DBHelper();
            try
            {
                //1.sql语句
                string sql = string.Format("select * from tb_student where StudentID={0}", StudentID);
                //2.执行工具
                SqlCommand command = new SqlCommand(sql, dBHelper.Connection);
                //3.打开连接
                dBHelper.OpenConnection();
                //4.执行
                SqlDataReader reader = command.ExecuteReader();
                //5.判断
                if (reader.Read())
                {
                    this.txtStuNum.Text = reader["StuNumber"].ToString();
                    this.txtStuName.Text = reader["StuName"].ToString();
                    if (reader["StuSex"].ToString().Equals(radioButton1.Text))
                    {
                        this.radioButton1.Checked = true;
                        this.radioButton2.Checked = false;
                    }
                    else
                    {
                        this.radioButton1.Checked = false;
                        this.radioButton2.Checked = true;
                    }
                    this.StuAcademy.SelectedValue = reader["AcademyID"].ToString();
                    this.StuGrade.SelectedValue = reader["GradeID"].ToString();
                    this.StuClass.SelectedValue = reader["ClassID"].ToString();

                    this.StuBirthday.Value =(DateTime)reader["StuBirthday"];//强制转换
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
        /// 更新学生信息的方法
        /// </summary>
        private void UpdateStuInfo()
        {
            DBHelper dBHelper = new DBHelper();
            try
            {
                //string sql = string.Format(@"update tb_commodity
                //                               set CommodityName='{0}',SortID={1},CommodityPrice={2},IsDiscount='{3}',ReducedPrice={4}
                //                               where CommodityID={5}");
                StringBuilder builder = new StringBuilder();
                //动态修改数据
                builder.AppendFormat("update [tb_student] set [StuNumber]='{0}'", this.txtStuNum.Text);
                builder.AppendFormat(",[StuName]='{0}'", this.txtStuName.Text);
                builder.AppendFormat(",[StuSex]='{0}'", this.radioButton1.Checked == true ? radioButton1.Text : radioButton2.Text);
                builder.AppendFormat(",[StuBirthday]='{0}'", this.StuBirthday.Value.ToString("yyyy-MM-dd"));
                builder.AppendFormat(",[GradeID]='{0}'", Convert.ToInt32(this.StuGrade.SelectedValue));
                builder.AppendFormat(",[AcademyID]='{0}'", Convert.ToInt32(this.StuAcademy.SelectedValue));
                builder.AppendFormat(",[ClassID]='{0}'", Convert.ToInt32(this.StuClass.SelectedValue));
                builder.AppendFormat(" where [StudentID]='{0}'", this.StudentID);
                //执行工具
                SqlCommand command = new SqlCommand(builder.ToString(), dBHelper.Connection);
                //打开连接
                dBHelper.OpenConnection();
                //执行，result代表受影响的行数
                int result = command.ExecuteNonQuery();
                //判断,受影响行数为1,代表修改成功
                if (result > 0)
                {
                    MessageBox.Show("学生信息修改成功!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void StuClass_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
