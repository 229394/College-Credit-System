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
    public partial class frmSearchCouTable : Form
    {
        private Student student;
        DataSet ds = new DataSet();

        internal Student Student { get => student; set => student = value; }

        public frmSearchCouTable()
        {
            InitializeComponent();
        }

        private void frmSearchCouTable_Load(object sender, EventArgs e)
        {
            FillMyCourseTable();
        }

        private void dgvStuCouTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        /// <summary>
        /// 填充我的课表信息
        /// </summary>
        private void FillMyCourseTable()
        {
            ds = new DataSet();
            DBHelper dBHelper = new DBHelper();
            try
            {
                //1、sql语句
                string sql = string.Format(@"select e.AcademyName 所在学院,f.ClassName 所在班级,g.GradeName 所在年级,
	                                        c.CourseName 课程名称,a.Location 上课地点,a.Period 节次,d.TeacherName 任课教师
	                                        from tb_coursetable a,tb_student b,tb_course c,tb_teacher d,tb_academy e,tb_class f,tb_grade g,tb_electcourse h
	                                        where a.ClassID=b.ClassID and b.ClassID=f.ClassID and a.TeacherID=d.TeacherID and a.CourseID=c.CourseID and b.AcademyID=e.AcademyID and a.GradeID=b.GradeID and b.GradeID=g.GradeID and b.StudentID=h.StudentID and c.CourseID=h.CourseID and b.StudentID={0}",this.student.StudentID1);
                //2、创建适配器
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dBHelper.Connection);
                //3、将数据填充到数据集里面
                adapter.Fill(ds, "CourseTable");
                //4、绑定DataGridView
                this.dgvMyCouTable.DataSource = this.ds.Tables["CourseTable"];
            }
            catch (Exception)
            {
                MessageBox.Show("数据库查询失败！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}
