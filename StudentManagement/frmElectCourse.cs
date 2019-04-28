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
    public partial class frmElectCourse : Form
    {
        DataSet ds = new DataSet();
        private Student student;

        internal Student Student { get => student; set => student = value; }

        public frmElectCourse()
        {
            InitializeComponent();
        }

        private void frmElectCourse_Load(object sender, EventArgs e)
        {
            FillCourseInfo();
            MyElectdCouInfo();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvAllCouInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        /// <summary>
        /// 填充所有选课信息
        /// </summary>
        private void FillCourseInfo()
        {
            ds = new DataSet();
            DBHelper dBHelper = new DBHelper();
            try
            {
                //1、sql语句
                string sql = string.Format(@"select a.CourseID 课程编号,a.CourseName 课程名,
	                                        a.CourseCredit 学分,a.CourseHour 学时,b.NatureName 课程性质,c.AcademyName 开课学院
	                                        from tb_course a,tb_nature b,tb_academy c 
	                                        where a.NatureID = b.NatureID and a.AcademyID = c.AcademyID");
                //2、创建适配器
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dBHelper.Connection);
                //3、将数据填充到数据集里面
                adapter.Fill(ds, "CourseInfo");
                //4、绑定DataGridView
                this.dgvAllCouInfo.DataSource = this.ds.Tables["CourseInfo"];
            }
            catch (Exception)
            {
                MessageBox.Show("数据库查询失败！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// 填充学生本人选课情况表
        /// </summary>
        private void MyElectdCouInfo()
        {
            ds = new DataSet();
            DBHelper dBHelper = new DBHelper();
            try
            {
                //1、sql语句,仅仅查询对应当前登录学生的选课情况
                string sql = string.Format(@"select a.ElectID 选课编号,b.StuNumber 学生学号,c.CourseName 课程名称,
	                                        c.CourseCredit 学分,c.CourseHour 学时,d.NatureName 课程性质,e.AcademyName 开课学院
	                                        from tb_electcourse a,tb_student b,tb_course c,tb_nature d,tb_academy e 
	                                        where a.StudentID=b.StudentID and a.CourseID=c.CourseID and c.NatureID = d.NatureID and c.AcademyID = e.AcademyID and a.StudentID='{0}'",student.StudentID1);
                //2、创建适配器
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dBHelper.Connection);
                //3、将数据填充到数据集里面
                adapter.Fill(ds, "MyElectCouInfo");
                //4、绑定DataGridView
                this.dgvElectedCouInfo.DataSource = this.ds.Tables["MyElectCouInfo"];
            }
            catch (Exception)
            {
                MessageBox.Show("数据库查询失败!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvElectedCouInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        /// <summary>
        /// 删除所选课程按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            DeleteElectedCourse();
        }

        /// <summary>
        /// 删除选课的方法
        /// </summary>
        private void DeleteElectedCourse()
        {
            //选中一行
            if (this.dgvElectedCouInfo.CurrentRow != null)
            {
                DialogResult dr = MessageBox.Show("确定要放弃选择"+ dgvElectedCouInfo.CurrentRow.Cells[2].Value + "课程吗?", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                //是否确认删除
                if (dr == DialogResult.OK)
                {
                    DBHelper dBHelper = new DBHelper();
                    try
                    {
                        //sql语句
                        StringBuilder sb = new StringBuilder();
                        sb.AppendFormat("delete from tb_electcourse where ElectID={0}", Convert.ToInt32(dgvElectedCouInfo.CurrentRow.Cells[0].Value));
                        //执行工具
                        SqlCommand cmd = new SqlCommand(sb.ToString(), dBHelper.Connection);
                        //打开
                        dBHelper.OpenConnection();
                        //执行
                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("该选课记录删除成功!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //重新绑定dgv
                            this.MyElectdCouInfo();
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

        /// <summary>
        /// 选课添加按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            AddElectedCourse();
        }

        /// <summary>
        /// 添加选课记录方法
        /// </summary>
        private void AddElectedCourse()
        {
            //选中一行
            if (this.dgvAllCouInfo.CurrentRow != null)
            {
                DialogResult dr = MessageBox.Show("确定要选择" + dgvAllCouInfo.CurrentRow.Cells[1].Value + "课程吗?", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                //是否确认添加
                if (dr == DialogResult.OK)
                {
                    DBHelper dBHelper = new DBHelper();
                    try
                    {
                        //sql语句
                        StringBuilder sb = new StringBuilder();
                        sb.AppendFormat("insert into tb_electcourse values({0},{1})",this.student.StudentID1, Convert.ToInt32(this.dgvAllCouInfo.CurrentRow.Cells[0].Value));
                        //执行工具
                        SqlCommand cmd = new SqlCommand(sb.ToString(), dBHelper.Connection);
                        if (CheckCourseNameExist())
                        {
                            MessageBox.Show("已经选择过该课程!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            //打开
                            dBHelper.OpenConnection();
                            //执行
                            int result = cmd.ExecuteNonQuery();
                            if (result > 0)
                            {
                                MessageBox.Show("该课程选择成功!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //重新绑定dgv
                                this.MyElectdCouInfo();
                            }
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("数据库添加失败!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    finally
                    {
                        dBHelper.CloseConnection();
                    }
                }
            }
        }

        /// <summary>
        /// 检查是否选择相同课程的方法
        /// </summary>
        /// <returns></returns>
        private bool CheckCourseNameExist()
        {
            bool exist = false;
            DBHelper dBHelper = new DBHelper();
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("select * from tb_electcourse where CourseID={0}",Convert.ToInt32(this.dgvAllCouInfo.CurrentRow.Cells[0].Value));
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

    }
}
