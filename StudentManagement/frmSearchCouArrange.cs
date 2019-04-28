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
    public partial class frmSearchCouArrange : Form
    {
        DataSet ds = new DataSet();
        private Teacher teacher;

        internal Teacher Teacher { get => teacher; set => teacher = value; }

        public frmSearchCouArrange()
        {
            InitializeComponent();
        }

        private void frmSearchCouArrange_Load(object sender, EventArgs e)
        {
            FillMyTeachCourse();
        }

        private void FillMyTeachCourse()
        {
            ds = new DataSet();
            DBHelper dBHelper = new DBHelper();
            try
            {
                //1、sql语句
                string sql = string.Format(@"select distinct a.CouTableID 编号,e.AcademyName 所属学院,f.ClassName 所教班级,g.GradeName 所教年级,
	                                        c.CourseName 所教课程,h.NatureName 课程性质,c.CourseCredit 课程学分,a.Location 上课地点,a.Period 节次
	                                        from tb_coursetable a,tb_student b,tb_course c,tb_teacher d,tb_academy e,tb_class f,tb_grade g,tb_nature h 
	                                        where a.ClassID=b.ClassID and b.ClassID=f.ClassID and a.TeacherID=d.TeacherID and c.NatureID=h.NatureID and a.CourseID=c.CourseID and b.AcademyID=e.AcademyID and a.GradeID=b.GradeID and b.GradeID=g.GradeID and a.TeacherID={0}", this.teacher.TeacherID1);
                //2、创建适配器
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dBHelper.Connection);
                //3、将数据填充到数据集里面
                adapter.Fill(ds, "TeachCourses");
                //4、绑定DataGridView
                this.dgvTeachCouInfo.DataSource = this.ds.Tables["TeachCourses"];
            }
            catch (Exception)
            {
                MessageBox.Show("数据库查询失败！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
