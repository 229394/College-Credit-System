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
    public partial class frmSearchNoticeInfo : Form
    {
        DataSet ds = new DataSet();
        public frmSearchNoticeInfo()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 页面加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmSearchNoticeInfo_Load(object sender, EventArgs e)
        {
            FillNoticeInfo();
        }

        /// <summary>
        /// 填充公告信息的方法
        /// </summary>
        private void FillNoticeInfo()
        {
            ds = new DataSet();
            DBHelper dBHelper = new DBHelper();
            try
            {
                //1、sql语句
                string sql = string.Format(@"select NoticeID 公告编号,NoticeTitle 公告标题,
                                            NoticeContent 具体内容,NoticeDate 发布日期
	                                        from tb_notice order by NoticeDate desc");//日期由近到远
                //2、创建适配器
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dBHelper.Connection);
                //3、将数据填充到数据集里面
                adapter.Fill(ds, "NoticeInfo");
                //4、绑定DataGridView
                this.dgvNoticeInfo.DataSource = this.ds.Tables["NoticeInfo"];
            }
            catch (Exception)
            {
                MessageBox.Show("数据库查询公告信息失败！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// 查询公告按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            SearchNotice();
        }
        /// <summary>
        /// 查询公告的方法
        /// </summary>
        private void SearchNotice()
        {
            DBHelper dbHelper = new DBHelper();
            try
            {
                //动态SQL语句
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat(@"select NoticeID 公告编号,NoticeTitle 公告标题,NoticeContent 具体内容, NoticeDate 发布日期 from tb_notice");
                sb.AppendFormat(" where NoticeDate='{0}'", this.NoticeDate.Value.ToString("yyyy-MM-dd"));
                if (this.NoticeTitle.Text.Trim() != "")
                {
                    sb.AppendFormat(" and NoticeTitle like '%{0}%'", this.NoticeTitle.Text);
                }
                sb.AppendFormat(" order by NoticeDate desc");
                SqlCommand cmd = new SqlCommand(sb.ToString(), dbHelper.Connection);
                dbHelper.OpenConnection();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                ds = new DataSet();
                sda.Fill(ds, "SearchedNoticeInfo");
                dgvNoticeInfo.DataSource = ds;
                dgvNoticeInfo.DataMember = "SearchedNoticeInfo";
            }
            catch (Exception)
            {
                MessageBox.Show("数据库查询公告失败！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
