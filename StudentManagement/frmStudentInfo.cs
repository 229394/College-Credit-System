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
    public partial class frmStudentInfo : Form
    {
        DataSet ds = new DataSet();
     
        public frmStudentInfo()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 加载主窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmStudentInfo_Load(object sender, EventArgs e)
        {
            FillStudentInfo();
            GetAllAcademy();
            GetAllClass();
        }

        /// <summary>
        /// 填充学生信息
        /// </summary>
        private void FillStudentInfo()
        {
            ds = new DataSet();
            DBHelper dBHelper = new DBHelper();
            try
            {
                //1、sql语句
                string sql = string.Format(@"select a.StudentID 学生编号,a.StuNumber 学号,a.StuName 姓名,
	                                        a.StuSex 性别,a.StuBirthday 出生年月,b.GradeName 年级,c.AcademyName 学院,d.ClassName 班级
	                                        from tb_student a,tb_grade b,tb_academy c,tb_class d 
	                                        where a.GradeID = b.GradeID and a.AcademyID=c.AcademyID and c.AcademyID=d.AcademyID and a.ClassID=d.ClassID order by b.GradeID");
                //2、创建适配器
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dBHelper.Connection);
                //3、将数据填充到数据集里面
                adapter.Fill(ds, "StudentInfo");
                //4、绑定DataGridView
                this.dgvStudent.DataSource = this.ds.Tables["StudentInfo"];
            }
            catch (Exception)
            {
                MessageBox.Show("数据库查询失败！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 查询点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            SearchStuInfo();
        }
        
        /// <summary>
        /// 查询学生信息的方法
        /// </summary>
        private void SearchStuInfo()
        {
            DBHelper dbHelper = new DBHelper();
            try
            {
                //动态SQL语句
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("select a.StudentID 学生编号,a.StuNumber 学号,a.StuName 姓名,a.StuSex 性别,a.StuBirthday 出生年月,b.GradeName 年级,c.AcademyName 学院,d.ClassName 班级 from tb_student a, tb_grade b, tb_academy c, tb_class d where a.GradeID = b.GradeID and a.AcademyID = c.AcademyID and a.ClassID = d.ClassID ");
                if (this.txtStuNum.Text.Trim()!="")
                {
                    sb.AppendFormat(" and a.StuNumber like '%{0}%'",this.txtStuNum.Text);
                }
                if (Convert.ToInt32(this.StuAcademy.SelectedValue)!=0)
                {
                    sb.AppendFormat(" and a.AcademyID={0}", Convert.ToInt32(StuAcademy.SelectedValue));
                }
                if (Convert.ToInt32(this.StuClass.SelectedValue)!=0)
                {
                    sb.AppendFormat(" and a.ClassID={0}", Convert.ToInt32(StuClass.SelectedValue));
                }
                sb.AppendFormat(" order by a.GradeID ");
                SqlCommand cmd = new SqlCommand(sb.ToString(), dbHelper.Connection);
                dbHelper.OpenConnection();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                ds = new DataSet();
                sda.Fill(ds, "SearchedStuInfo");
                dgvStudent.DataSource = ds;
                dgvStudent.DataMember = "SearchedStuInfo";
            }
            catch (Exception)
            {
                MessageBox.Show("数据库查询失败！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        /// <summary>
        /// 从数据库得到所有学院
        /// </summary>
        private void GetAllAcademy()
        {
            DBHelper dBHelper = new DBHelper();
            ds = new DataSet();
            try
            {
                string sql = string.Format(@"select * from tb_academy order by AcademyID");
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dBHelper.Connection);
                adapter.Fill(ds, "AllAcademy");
                //绑定数据
                DataRow dr = ds.Tables["AllAcademy"].NewRow();
                dr[0] = "0";
                dr[1] = "请选择学院";
                ds.Tables["AllAcademy"].Rows.InsertAt(dr, 0);
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

        ///<summary>
        /// 从数据库得到所有班级
        /// </summary>
        private void GetAllClass()
        {
            DBHelper dBHelper = new DBHelper();
            ds = new DataSet();
            try
            {       
                string sql = string.Format("select * from tb_class");
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dBHelper.Connection);
                adapter.Fill(ds, "AllClass");
                DataRow dr = ds.Tables["AllClass"].NewRow();
                dr[0] = "0";
                dr[1] = "请选择班级";
                ds.Tables["AllClass"].Rows.InsertAt(dr, 0);
                //绑定数据
                this.StuClass.DataSource = ds.Tables["AllClass"];
                this.StuClass.ValueMember = "ClassID";
                //显示班级名称
                this.StuClass.DisplayMember = "ClassName";
                this.StuClass.SelectedValue = "0";
            }
            catch (Exception)
            {
                MessageBox.Show("数据库查询班级异常!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        /// <summary>
        /// 添加学生信息事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmEditStuInfo fesInfo = new frmEditStuInfo();
            //表示新增
            fesInfo.StudentID = 0;
            fesInfo.ShowDialog();
            //再次绑定dgvStuInfo
            this.FillStudentInfo();
        }

        /// <summary>
        /// 修改点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            frmEditStuInfo fesInfo2 = new frmEditStuInfo();
            //获取第一列也就是学生的编号
            fesInfo2.StudentID = Convert.ToInt32(dgvStudent.CurrentRow.Cells[0].Value);
            fesInfo2.ShowDialog();
            //重新绑定DataGridView
            this.FillStudentInfo();

        }

        /// <summary>
        /// 删除点击按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            DeleteStudent();
        }

        /// <summary>
        /// 删除学生的方法
        /// </summary>
        private void DeleteStudent()
        {
            //选中一行
            if (this.dgvStudent.CurrentRow != null)
            {
                DialogResult dr = MessageBox.Show("确定要删除学号为" + dgvStudent.CurrentRow.Cells[1].Value + "的学生吗?", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                //是否确认删除
                if (dr == DialogResult.OK)
                {
                    DBHelper dBHelper = new DBHelper();
                    try
                    {
                        //sql语句
                        StringBuilder sb = new StringBuilder();
                        sb.AppendFormat("delete from tb_student where StudentID={0}", Convert.ToInt32(dgvStudent.CurrentRow.Cells[0].Value));
                        //执行工具
                        SqlCommand cmd = new SqlCommand(sb.ToString(), dBHelper.Connection);
                        //打开
                        dBHelper.OpenConnection();
                        //执行
                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("该学生删除成功!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //重新绑定dgvStudent
                            this.FillStudentInfo();
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

        private void txtStuNum_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 联动事件,学院与班级实现联动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StuAcademy_SelectedIndexChanged(object sender, EventArgs e)
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
    }
}
