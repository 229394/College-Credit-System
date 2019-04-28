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
    public partial class frmCourseInfo : Form
    {
        DataSet ds = new DataSet();
        public frmCourseInfo()
        {
            InitializeComponent();
        }

        private void frmCourseInfo_Load(object sender, EventArgs e)
        {
            FillCourseInfo();
            GetCouAcademy();
            GetCouNature();
        }

        private void FillCourseInfo()
        {
            ds = new DataSet();
            DBHelper dBHelper = new DBHelper();
            try
            {
                //1、sql语句
                string sql = string.Format(@"select a.CourseID 课程编号,a.CourseNum 课程号,a.CourseName 课程名,
	                                        a.CourseCredit 学分,a.CourseHour 学时,b.NatureName 课程性质,c.AcademyName 开课学院
	                                        from tb_course a,tb_nature b,tb_academy c 
	                                        where a.NatureID = b.NatureID and a.AcademyID = c.AcademyID");
                //2、创建适配器
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dBHelper.Connection);
                //3、将数据填充到数据集里面
                adapter.Fill(ds, "CourseInfo");
                //4、绑定DataGridView
                this.dgvCourse.DataSource = this.ds.Tables["CourseInfo"];
            }
            catch (Exception)
            {
                MessageBox.Show("数据库查询失败！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 添加课程按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmEditCouInfo fecInfo = new frmEditCouInfo();
            //表示新增
            fecInfo.CourseID = 0;
            fecInfo.ShowDialog();
            //再次绑定dgvCourseInfo
            this.FillCourseInfo();
        }

        /// <summary>
        /// 修改按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            frmEditCouInfo fecInfo2 = new frmEditCouInfo();
            //获取第一列也就是课程的编号
            fecInfo2.CourseID = Convert.ToInt32(dgvCourse.CurrentRow.Cells[0].Value);
            fecInfo2.ShowDialog();
            //重新绑定DataGridView
            this.FillCourseInfo();
        }

        /// <summary>
        /// 删除按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            DeleteCourse();
        }

        /// <summary>
        /// 删除课程的方法
        /// </summary>
        private void DeleteCourse()
        {
            //选中一行
            if (this.dgvCourse.CurrentRow != null)
            {
                DialogResult dr = MessageBox.Show("确定要删除课程名为" + dgvCourse.CurrentRow.Cells[2].Value + "的课程吗?", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                //是否确认删除
                if (dr == DialogResult.OK)
                {
                    DBHelper dBHelper = new DBHelper();
                    try
                    {
                        //sql语句
                        StringBuilder sb = new StringBuilder();
                        sb.AppendFormat("delete from tb_course where CourseID={0}", Convert.ToInt32(dgvCourse.CurrentRow.Cells[0].Value));
                        //执行工具
                        SqlCommand cmd = new SqlCommand(sb.ToString(), dBHelper.Connection);
                        //打开
                        dBHelper.OpenConnection();
                        //执行
                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("该课程删除成功!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //重新绑定dgvCourse
                            this.FillCourseInfo();
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("数据库删除失败!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    finally
                    {
                        dBHelper.CloseConnection();
                    }
                }

            }

        }

        private void dgvCourse_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        /// <summary>
        /// 查询按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            SearchCouInfo();
        }

        /// <summary>
        /// 查询课程信息的方法
        /// </summary>
        private void SearchCouInfo()
        {
            DBHelper dbHelper = new DBHelper();
            try
            {
                //动态SQL语句
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("select a.CourseID 课程编号,a.CourseNum 课程号,a.CourseName 课程名,a.CourseCredit 学分,a.CourseHour 学时,b.NatureName 课程性质,c.AcademyName 开课学院 from tb_course a,tb_nature b,tb_academy c where a.NatureID=b.NatureID and a.AcademyID=c.AcademyID");
                if (this.CourseName.Text.Trim() != "")
                {
                    sb.AppendFormat(" and a.CourseName like '%{0}%'", this.CourseName.Text);
                }
                if (Convert.ToInt32(this.CourseAcademy.SelectedValue) != 0)
                {
                    sb.AppendFormat(" and a.AcademyID={0}", Convert.ToInt32(CourseAcademy.SelectedValue));
                }
                if (Convert.ToInt32(this.CourseNature.SelectedValue) != 0)
                {
                    sb.AppendFormat(" and a.NatureID={0}", Convert.ToInt32(CourseNature.SelectedValue));
                }
                SqlCommand cmd = new SqlCommand(sb.ToString(), dbHelper.Connection);
                dbHelper.OpenConnection();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                ds = new DataSet();
                sda.Fill(ds, "SearchedCourseInfo");
                dgvCourse.DataSource = ds;
                dgvCourse.DataMember = "SearchedCourseInfo";
            }
            catch (Exception)
            {
                MessageBox.Show("数据库查询失败！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// 获取所有的开课学院
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
    }
}
