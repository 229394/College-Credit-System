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
    public partial class frmEditNoticeInfo : Form
    {
        public int NoticeID = 0;
        DataSet ds = new DataSet();
        public frmEditNoticeInfo()
        {
            InitializeComponent();
        }

        private void frmEditNoticeInfo_Load(object sender, EventArgs e)
        {
            if (this.NoticeID != 0)//修改
            {
                GetNoticeInfo();
                this.button1.Text = "修改(&U)";
            }

        }

        /// <summary>
        /// 非空检验
        /// </summary>
        /// <returns></returns>
        private bool CheckInput()
        {
            bool flag = true;
            if (this.NoticeTitle.Text.Trim().Length == 0)
            {
                MessageBox.Show("公告标题不能为空!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                flag = false;
            }
            else if (this.NoticeContent.Text.Trim().Length == 0)
            {
                MessageBox.Show("公告内容不能为空!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                flag = false;
            }
            return flag;
        }

        /// <summary>
        /// 插入公告信息的方法
        /// </summary>
        private void InsertNotice()
        {
            DBHelper dBHelper = new DBHelper();
            try
            {
                StringBuilder sb = new StringBuilder();
                //增加一行
                sb.AppendLine("insert into tb_notice");
                sb.AppendFormat(" values('{0}','{1}','{2}')", NoticeTitle.Text.Trim(), NoticeContent.Text.Trim(), DateTime.Today.ToString("yyyy-MM-dd"));
                SqlCommand cmd = new SqlCommand(sb.ToString(), dBHelper.Connection);
                dBHelper.OpenConnection();
                //增加、修改、删除都是调用ExecuteNonQuery方法
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("公告信息添加成功!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("数据库添加失败!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// 保存按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (CheckInput())
            {
                if (this.NoticeID == 0)//新增
                {
                    InsertNotice();
                }
                else//修改
                {
                    UpdateNoticeInfo();
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 根据编号获取公告信息
        /// </summary>
        private void GetNoticeInfo()
        {
            DBHelper dBHelper = new DBHelper();
            try
            {
                //SQL语句
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("select NoticeTitle,NoticeContent ");
                sb.AppendLine(" from tb_notice ");
                sb.AppendFormat(" where NoticeID={0}", NoticeID);
                //工具
                SqlCommand cmd = new SqlCommand(sb.ToString(), dBHelper.Connection);
                dBHelper.OpenConnection();
                SqlDataReader reader = cmd.ExecuteReader();
                //如果可读
                if (reader.Read())
                {
                    NoticeTitle.Text = reader["NoticeTitle"].ToString();
                    NoticeContent.Text = reader["NoticeContent"].ToString();
                }
                reader.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("数据库查找失败!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                dBHelper.CloseConnection();
            }
        }

        /// <summary>
        /// 更新公告内容的方法
        /// </summary>
        private void UpdateNoticeInfo()
        {
            DBHelper dBHelper = new DBHelper();
            try
            {
                //sql语句
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("update tb_notice");
                sb.AppendFormat(" set NoticeTitle='{0}',NoticeContent='{1}',NoticeDate='{2}'", NoticeTitle.Text.Trim(), NoticeContent.Text.Trim(), DateTime.Today.ToString("yyyy-MM-dd"));
                sb.AppendFormat(" where NoticeID={0}", NoticeID);
                SqlCommand cmd = new SqlCommand(sb.ToString(), dBHelper.Connection);
                dBHelper.OpenConnection();
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("公告信息修改成功!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("数据库修改失败!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                dBHelper.CloseConnection();
            }

        }
    }
}
