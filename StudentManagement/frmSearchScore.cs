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
    public partial class frmSearchScore : Form
    {
        DataSet ds = new DataSet();
        private Student student;

        internal Student Student { get => student; set => student = value; }

        public frmSearchScore()
        {
            InitializeComponent();
        }

        private void frmSearchScore_Load(object sender, EventArgs e)
        {
            FillScoreInfo();
        }
        /// <summary>
        /// 填充成绩信息的方法
        /// </summary>
        private void FillScoreInfo()
        {
            ds = new DataSet();
            DBHelper dBHelper = new DBHelper();
            try
            {
                //1、sql语句
                string sql = string.Format(@"select a.StuScoreID 编号,b.GradeName 所在年级,c.ClassName 所在班级,
	                                        d.StuNumber 学号,e.CourseName 课程名称,f.NatureName 课程性质,e.CourseCredit 课程学分,a.Score 总评成绩
	                                        from tb_stuscore a,tb_grade b,tb_class c,tb_student d,tb_course e,tb_nature f,tb_electcourse g 
	                                        where a.GradeID=b.GradeID and a.ClassID=c.ClassID and a.StudentID=d.StudentID and a.CourseID=e.CourseID and e.NatureID=f.NatureID and d.StudentID=g.StudentID and e.CourseID=g.CourseID and a.StudentID={0}",this.student.StudentID1);
                //2、创建适配器
                SqlDataAdapter adapter = new SqlDataAdapter(sql,dBHelper.Connection);
                //3、将数据填充到数据集里面
                adapter.Fill(ds, "AllMyScoreInfo");
                //4、绑定DataGridView
                this.AllMyScoreInfo.DataSource = this.ds.Tables["AllMyScoreInfo"];
            }
            catch (Exception)
            {
                MessageBox.Show("数据库查询失败！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        /// <summary>
        /// 树形结构点击事件，此处方法可能要改进,用的循环暴力求解
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (this.treeView1.SelectedNode.Parent == null)//根节点
            {
                this.AllMyScoreInfo.DataSource = ds.Tables[0];
            }
            else
            {
        
                if (e.Node.Text == "90分及以上")
                {
                    for (int i = 90; i <= 100; i++)
                        this.Filter(i);
                }
                else if (e.Node.Text == "80分及以上")
                {
                    for (int i = 80; i < 90; i++)
                        this.Filter(i);
                }
                else if (e.Node.Text == "70分及以上")
                {
                    for (int i = 70; i < 80; i++)
                        this.Filter(i);
                }
                else if (e.Node.Text == "60分及以上")
                {
                    for (int i = 60; i < 70; i++)
                        this.Filter(i);
                }
                else
                {
                    for(int i = 0; i < 60; i++)
                    this.Filter(i);
                }
            }

        }

        /// <summary>
        /// 数据过滤方法
        /// </summary>
        /// <param name="Score"></param>
        private void Filter(int Score)
        {
            DataView dv = new DataView(ds.Tables[0]); 
            if (Score>=90)
            {
                dv.RowFilter = "总评成绩>='90'";
            }
            else if (Score>=80 && Score<90)
            {
                dv.RowFilter = "总评成绩>='80' and 总评成绩<'90'";
            }
            else if (Score >=70 && Score<80)
            {
                dv.RowFilter = "总评成绩>='70' and 总评成绩<'80'";
            }
            else if(Score>=60 && Score < 70)
            {
                dv.RowFilter = "总评成绩>='60' and 总评成绩<'70'";
            }
            else
            {
                dv.RowFilter = "总评成绩<'60'";
            }
            //重新绑定datagridview
            this.AllMyScoreInfo.DataSource = dv;
        }
    }
}
