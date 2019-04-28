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
    public partial class frmTeacherInfo : Form
    {
        DataSet ds = new DataSet();
        public frmTeacherInfo()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 主窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmTeacherInfo_Load(object sender, EventArgs e)
        {
            FillTeacherInfo();
            GetAllAcademy();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 添加按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmEditTeaInfo fetInfo = new frmEditTeaInfo();
            //表示新增
            fetInfo.TeacherID = 0;
            fetInfo.ShowDialog();
            //再次绑定dgvTeaInfo
            this.FillTeacherInfo();
        }

        /// <summary>
        /// 修改按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            frmEditTeaInfo fetInfo2 = new frmEditTeaInfo();
            //获取第一列也就是教师的编号
            fetInfo2.TeacherID = Convert.ToInt32(dgvTeacher.CurrentRow.Cells[0].Value);
            fetInfo2.ShowDialog();
            //重新绑定DataGridView
            this.FillTeacherInfo();
        }

        /// <summary>
        /// 删除按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            DeleteTeacher();
        }

        /// <summary>
        /// 获取所有的学院的方法
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
                this.TeaAcademy.DataSource = ds.Tables["AllAcademy"];
                this.TeaAcademy.ValueMember = "AcademyID";
                //显示学院名称
                this.TeaAcademy.DisplayMember = "AcademyName";
                //初始指向0
                this.TeaAcademy.SelectedValue = "0";
            }
            catch (Exception)
            {
                MessageBox.Show("数据库查询学院异常!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        /// <summary>
        /// 删除教师的方法
        /// </summary>
        private void DeleteTeacher()
        {
            //选中一行
            if (this.dgvTeacher.CurrentRow != null)
            {
                DialogResult dr = MessageBox.Show("确定要删除工号为" + dgvTeacher.CurrentRow.Cells[1].Value + "的教师吗?", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                //是否确认删除
                if (dr == DialogResult.OK)
                {
                    DBHelper dBHelper = new DBHelper();
                    try
                    {
                        //sql语句
                        StringBuilder sb = new StringBuilder();
                        sb.AppendFormat("delete from tb_teacher where TeacherID={0}", Convert.ToInt32(dgvTeacher.CurrentRow.Cells[0].Value));
                        //执行工具
                        SqlCommand cmd = new SqlCommand(sb.ToString(), dBHelper.Connection);
                        //打开
                        dBHelper.OpenConnection();
                        //执行
                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("该教师删除成功!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //重新绑定dgvTeacher
                            this.FillTeacherInfo();
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
        /// 填充学生信息
        /// </summary>
        private void FillTeacherInfo()
        {
            ds = new DataSet();
            DBHelper dBHelper = new DBHelper();
            try
            {
                //1、sql语句
                string sql = string.Format(@"select a.TeacherID 教师编号,a.TeacherNum 工号,a.TeacherName 姓名,
	                                        a.TeacherSex 性别,b.AcademyName 所属学院
	                                        from tb_teacher a,tb_academy b
	                                        where a.AcademyID=b.AcademyID");
                //2、创建适配器
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dBHelper.Connection);
                //3、将数据填充到数据集里面
                adapter.Fill(ds, "TeacherInfo");
                //4、绑定DataGridView
                this.dgvTeacher.DataSource = this.ds.Tables["TeacherInfo"];
            }
            catch (Exception)
            {
                MessageBox.Show("数据库查询失败！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void TeaAcademy_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SearchTeaInfo();
        }

        /// <summary>
        /// 查询教师信息的方法
        /// </summary>
        private void SearchTeaInfo()
        {
            DBHelper dbHelper = new DBHelper();
            try
            {
                //动态SQL语句
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat(@"select a.TeacherID 教师编号,a.TeacherNum 工号,a.TeacherName 姓名,a.TeacherSex 性别, b.AcademyName 所属学院 from tb_teacher a, tb_academy b where a.AcademyID = b.AcademyID ");
                if (this.txtTeaNum.Text.Trim() != "")
                {
                    sb.AppendFormat(" and a.TeacherNum like '%{0}%'", this.txtTeaNum.Text);
                }
                if (this.txtTeaName.Text.Trim() != "")
                {
                    sb.AppendFormat(" and a.TeacherName like '%{0}%'", this.txtTeaName.Text);
                }
                if (Convert.ToInt32(this.TeaAcademy.SelectedValue) != 0)
                {
                    sb.AppendFormat(" and a.AcademyID={0}", Convert.ToInt32(TeaAcademy.SelectedValue));
                }
                SqlCommand cmd = new SqlCommand(sb.ToString(), dbHelper.Connection);
                dbHelper.OpenConnection();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                ds = new DataSet();
                sda.Fill(ds, "SearchedTeaInfo");
                dgvTeacher.DataSource = ds;
                dgvTeacher.DataMember = "SearchedTeaInfo";
            }
            catch (Exception)
            {
                MessageBox.Show("数据库查询失败！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
    }
}
