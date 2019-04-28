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
   
    public partial class frmEditTeaInfo : Form
    {
        //标识符
        public int TeacherID = 0;
        DataSet ds = new DataSet();
        public frmEditTeaInfo()
        {
            InitializeComponent();
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
                if (TeacherID == 0)//新增
                {
                    InsertTeaInfo();
                }
                else//修改
                {
                    UpdateTeaInfo();
                }
            }
        }

        /// <summary>
        /// 非空检验
        /// </summary>
        /// <returns></returns>
        private bool CheckInput()
        {
            bool flag = true;
            if (txtTeaNum.Text.Trim().Length == 0)
            {
                MessageBox.Show("教师工号不能为空!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                flag = false;
            }
            else if (txtTeaName.Text.Trim().Length == 0)
            {
                MessageBox.Show("教师姓名不能为空!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                flag = false;
            }
            return flag;
        }
        
        /// <summary>
        /// 获取所有的学院
        /// </summary>
        private void GetAllAcademy()
        {
            DBHelper dBHelper = new DBHelper();
            try
            {
                string sql = string.Format(@"select * from tb_academy order by AcademyID");
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dBHelper.Connection);
                adapter.Fill(ds, "AllAcademy");
                //绑定数据
                this.TeaAcademy.DataSource = ds.Tables["AllAcademy"];
                this.TeaAcademy.ValueMember = "AcademyID";
                //显示学院名称
                this.TeaAcademy.DisplayMember = "AcademyName";
            }
            catch (Exception)
            {
                MessageBox.Show("数据库查询学院异常!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        /// <summary>
        /// 加载窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmEditTeaInfo_Load(object sender, EventArgs e)
        {
            if (TeacherID == 0)
            {
                GetAllAcademy();//获取所有的学院名称
            }
            else
            {
                //获取教师信息
                this.GetTeaInfo();
                this.button1.Text = "修改(&M)";
            }
        }

        /// <summary>
        /// 新增教师信息的方法
        /// </summary>
        private void InsertTeaInfo()
        {
            DBHelper dBHelper = new DBHelper();
            try
            {
                string sex;
                if (this.radioButton1.Checked == true)
                {
                    sex = radioButton1.Text;
                }
                else
                {
                    sex = radioButton2.Text;
                }
                //1.sql语句
                string sql = string.Format("insert into tb_teacher values('{0}','{1}','{2}','{3}',{4})", txtTeaNum.Text.Trim(), "123456", txtTeaName.Text.Trim(), sex, Convert.ToInt32(TeaAcademy.SelectedValue));
                //2.执行工具
                SqlCommand sqlCommand = new SqlCommand(sql, dBHelper.Connection);
                //3.打开连接
                dBHelper.OpenConnection();
                //4.执行
                int result = sqlCommand.ExecuteNonQuery();
                if (result == 1)
                {
                    MessageBox.Show("教师信息添加成功!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("数据库添加失败!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// 取消按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 获取教师信息
        /// </summary>
        private void GetTeaInfo()
        {
            //获取学院
            GetAllAcademy();
            DBHelper dBHelper = new DBHelper();
            try
            {
                //1.sql语句
                string sql = string.Format("select * from tb_teacher where TeacherID={0}", TeacherID);
                //2.执行工具
                SqlCommand command = new SqlCommand(sql, dBHelper.Connection);
                //3.代开连接
                dBHelper.OpenConnection();
                //4.执行
                SqlDataReader reader = command.ExecuteReader();
                //5.判断
                if (reader.Read())
                {
                    this.txtTeaNum.Text = reader["TeacherNum"].ToString();
                    this.txtTeaName.Text = reader["TeacherName"].ToString();
                    if (reader["TeacherSex"].ToString().Equals(radioButton1.Text))
                    {
                        this.radioButton1.Checked = true;
                        this.radioButton2.Checked = false;
                    }
                    else
                    {
                        this.radioButton1.Checked = false;
                        this.radioButton2.Checked = true;
                    }
                    this.TeaAcademy.SelectedValue = reader["AcademyID"].ToString();
                }
                reader.Close();

            }
            catch (Exception)
            {
                MessageBox.Show("数据库获取教师信息失败!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                dBHelper.CloseConnection();
            }
        }

        /// <summary>
        /// 更新教师信息
        /// </summary>
        private void UpdateTeaInfo()
        {
            DBHelper dBHelper = new DBHelper();
            try
            {
                StringBuilder builder = new StringBuilder();
                //动态修改数据
                builder.AppendFormat("update [tb_teacher] set [TeacherNum]='{0}'", this.txtTeaNum.Text);
                builder.AppendFormat(",[TeacherName]='{0}'", this.txtTeaName.Text);
                builder.AppendFormat(",[TeacherSex]='{0}'", this.radioButton1.Checked == true ? radioButton1.Text : radioButton2.Text);
                builder.AppendFormat(",[AcademyID]='{0}'", Convert.ToInt32(this.TeaAcademy.SelectedValue));
                builder.AppendFormat(" where [TeacherID]='{0}'", this.TeacherID);
                //执行工具
                SqlCommand command = new SqlCommand(builder.ToString(), dBHelper.Connection);
                //打开连接
                dBHelper.OpenConnection();
                //执行,result代表受影响的行数
                int result = command.ExecuteNonQuery();
                //判断,受影响行数为1,代表修改成功
                if (result == 1)
                {
                    MessageBox.Show("教师信息修改成功!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
