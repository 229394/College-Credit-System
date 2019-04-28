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
    public partial class frmStudentScore : Form
    {
        DataSet ds = new DataSet();
        private Teacher teacher;
        public frmStudentScore()
        {
            InitializeComponent();
        }

        internal Teacher Teacher { get => teacher; set => teacher = value; }

        private void frmStudentScore_Load(object sender, EventArgs e)
        {
            FillTeachStuInfo();
            FillStuScore();
            StuScoreCount();
        }

        /// <summary>
        /// 填充所教的学生信息
        /// </summary>
        private void FillTeachStuInfo()
        {
            ds = new DataSet();
            DBHelper dBHelper = new DBHelper();
            try
            {
                //1、sql语句
                string sql = string.Format(@"select c.GradeName 所在年级,d.ClassName 所在班级,b.StuNumber 学号,
                                            b.StuName 姓名,e.CourseName 课程名称,h.NatureName 课程性质,e.CourseCredit 课程学分,f.TeacherName 任课教师
	                                        from tb_student b,tb_grade c,tb_class d,tb_course e,tb_teacher f,tb_coursetable g,tb_nature h
	                                        where b.GradeID=c.GradeID and c.GradeID=g.GradeID and b.ClassID=d.ClassID and d.ClassID=g.ClassID and e.CourseID=g.CourseID and f.TeacherID=g.TeacherID and e.NatureID=h.NatureID and g.TeacherID={0}", this.teacher.TeacherID1);
                //2、创建适配器
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dBHelper.Connection);
                //3、将数据填充到数据集里面
                adapter.Fill(ds, "StudentInfo");
                //4、绑定DataGridView
                this.dgvStuInfo.DataSource = this.ds.Tables["StudentInfo"];
            }
            catch (Exception)
            {
                MessageBox.Show("数据库查询失败！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// 填充学生成绩
        /// </summary>
        private void FillStuScore()
        {
            ds = new DataSet();
            DBHelper dBHelper = new DBHelper();
            try
            {
                //1、sql语句
                string sql = string.Format(@"select a.StuScoreID 编号,c.GradeName 所在年级,d.ClassName 所在班级,b.StuNumber 学号,
                                            b.StuName 姓名,e.CourseName 课程名称,h.NatureName 课程性质,e.CourseCredit 课程学分,a.Score 总评成绩
	                                        from tb_stuscore a,tb_student b,tb_grade c,tb_class d,tb_course e,tb_teacher f,tb_coursetable g,tb_nature h
	                                        where a.GradeID=b.GradeID and a.GradeID=c.GradeID and a.GradeID=g.GradeID and a.StudentID=b.StudentID and a.ClassID=d.ClassID and a.ClassID=g.ClassID and a.CourseID=e.CourseID and a.CourseID=g.CourseID and e.NatureID=h.NatureID and f.TeacherID=g.TeacherID and g.TeacherID={0}", this.teacher.TeacherID1);
                //2、创建适配器
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dBHelper.Connection);
                //3、将数据填充到数据集里面
                adapter.Fill(ds, "StudentScore");
                //4、绑定DataGridView
                this.dgvStuScoreInfo.DataSource = this.ds.Tables["StudentScore"];
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

        private void dgvStuInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        /// <summary>
        /// 添加按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmEditStuScore fessInfo = new frmEditStuScore();
            //获取当前行学生学号,姓名,课程名
            int a = dgvStuInfo.CurrentRow.Index;
            fessInfo.StuNum = this.dgvStuInfo.Rows[a].Cells[2].Value.ToString();
            fessInfo.StuName = this.dgvStuInfo.Rows[a].Cells[3].Value.ToString();
            fessInfo.CouName = this.dgvStuInfo.Rows[a].Cells[4].Value.ToString();
            fessInfo.ShowDialog();
            //再次绑定dgvStuScoreInfo
            this.FillStuScore();
            this.StuScoreCount();
        }

        /// <summary>
        /// 修改按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            frmUpdateStuScore fess2Info = new frmUpdateStuScore();
            fess2Info.StuScoreID = Convert.ToInt32(this.dgvStuScoreInfo.CurrentRow.Cells[0].Value);
            fess2Info.ShowDialog();
            //再次绑定dgvStuScoreInfo
            this.FillStuScore();
            this.StuScoreCount();
        }

        /// <summary>
        /// 删除按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            DeleteStuScore();
        }
        /// <summary>
        /// 删除学生成绩的方法
        /// </summary>
        private void DeleteStuScore()
        {
            //选中一行
            if (this.dgvStuScoreInfo.CurrentRow != null)
            {
                DialogResult dr = MessageBox.Show("确定要删除此条成绩记录吗?", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                //是否确认删除
                if (dr == DialogResult.OK)
                {
                    DBHelper dBHelper = new DBHelper();
                    try
                    {
                        //sql语句
                        StringBuilder sb = new StringBuilder();
                        sb.AppendFormat("delete from tb_stuscore where StuScoreID={0}", Convert.ToInt32(dgvStuScoreInfo.CurrentRow.Cells[0].Value));
                        //执行工具
                        SqlCommand cmd = new SqlCommand(sb.ToString(), dBHelper.Connection);
                        //打开
                        dBHelper.OpenConnection();
                        //执行
                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("该成绩记录删除成功!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //重新绑定dgv
                            this.FillStuScore();
                            this.StuScoreCount(); 

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


        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dgvStuScoreInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        /// <summary>
        /// 学生成绩信息统计
        /// </summary>
        private void StuScoreCount()
        {
            int max=0, min=100, avg, sum = 0,count=0;
            int i = dgvStuScoreInfo.ColumnCount - 1;
            for (int j = 0; j < dgvStuScoreInfo.RowCount; j++)
            { 
                int score = (int)dgvStuScoreInfo.Rows[j].Cells[i].Value;
                sum = sum + score;
                if (score > max)
                {
                    max = score;
                }
                if(score < min)
                {
                    min = score;
                }
                if(score < 60)
                {
                    count++;
                }
            }
            avg = sum / (dgvStuScoreInfo.RowCount);
            AveScore.Value = avg;
            MaxScore.Value = max;
            MinScore.Value = min;
            FailStudent.Value = count;
        }


        private void MaxScore_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
