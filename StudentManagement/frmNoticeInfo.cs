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
    public partial class frmNoticeInfo : Form
    {
        DataSet ds = new DataSet();
        public frmNoticeInfo()
        {
            InitializeComponent();
        }

        private void frmNoticeInfo_Load(object sender, EventArgs e)
        {
            FillNoticeInfo();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

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
                this.dgvNotice.DataSource = this.ds.Tables["NoticeInfo"];
            }
            catch (Exception)
            {
                MessageBox.Show("数据库查询公告信息失败！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// 添加按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmEditNoticeInfo fenInfo = new frmEditNoticeInfo();
            //表示新增
            fenInfo.NoticeID = 0;
            fenInfo.ShowDialog();
            //再次绑定dgvStuInfo
            this.FillNoticeInfo();
        }

        /// <summary>
        /// 删除按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            DeleteNotice();
        }

        /// <summary>
        /// 删除公告的方法
        /// </summary>
        private void DeleteNotice()
        {
            //选中一行
            if (this.dgvNotice.CurrentRow != null)
            {
                DialogResult dr = MessageBox.Show("确定要删除标题为" + dgvNotice.CurrentRow.Cells[1].Value + "的通知吗?", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                //是否确认删除
                if (dr == DialogResult.OK)
                {
                    DBHelper dBHelper = new DBHelper();
                    try
                    {
                        //sql语句
                        StringBuilder sb = new StringBuilder();
                        sb.AppendFormat("delete from tb_notice where NoticeID={0}", Convert.ToInt32(dgvNotice.CurrentRow.Cells[0].Value));
                        //执行工具
                        SqlCommand cmd = new SqlCommand(sb.ToString(), dBHelper.Connection);
                        //打开
                        dBHelper.OpenConnection();
                        //执行
                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("该条公告删除成功!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //重新绑定dgvNotice
                            this.FillNoticeInfo();
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
        /// 修改按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            frmEditNoticeInfo fenInfo2 = new frmEditNoticeInfo();
            //获取第一列也就是公告的编号
            fenInfo2.NoticeID = Convert.ToInt32(dgvNotice.CurrentRow.Cells[0].Value);
            fenInfo2.ShowDialog();
            //重新绑定DataGridView
            this.FillNoticeInfo();
        }

        /// <summary>
        /// 查询按钮点击事件
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
                dgvNotice.DataSource = ds;
                dgvNotice.DataMember = "SearchedNoticeInfo";
            }
            catch (Exception)
            {
                MessageBox.Show("数据库查询公告失败！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void NoticeDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void NoticeTitle_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
