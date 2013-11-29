using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace da1
{
    public partial class UserInfo : Form
    {

        private CMyDataSet m_dataset;
        public UserInfo()
        {
            InitializeComponent();
        }
        public void SetData(SqlConnection cn, RIGHT right, string username)
        {
            m_dataset = new CMyDataSet(cn, right, username);
        }

        private void UserInfo_Load(object sender, EventArgs e)
        {
            try
            {
                switch(m_dataset.GetRight())
                {
                    case RIGHT.ADMIN:          //不同的用户看到的东西和修改的东西不同
                        m_dataset.SetCmd(CMyDataSet.WHICHCMD.SELECT, "Select UserName,Access,Name,PhoneNum,Age From UserInfo WHERE Access in ('1','2','3')", CommandType.Text);
                        break;
                    case RIGHT.CONDUCTOR:
                        m_dataset.SetCmd(CMyDataSet.WHICHCMD.SELECT, "Select UserName,Access,Name,PhoneNum,Age From UserInfo WHERE UserName = '" +m_dataset.GetUserName() + "'" , CommandType.Text);
                        break;
                    case RIGHT.MAINTAIN:
                        m_dataset.SetCmd(CMyDataSet.WHICHCMD.SELECT, "Select UserName,Access,Name,PhoneNum,Age From UserInfo WHERE UserName = '" + m_dataset.GetUserName() + "' OR (Access in ('2','3') )", CommandType.Text);
                        break;
                    case RIGHT.GUEST:
                        m_dataset.SetCmd(CMyDataSet.WHICHCMD.SELECT, "Select UserName,Access,Name,PhoneNum,Age From UserInfo WHERE UserName = '" + m_dataset.GetUserName() + "'", CommandType.Text);
                        break;
                }
               // m_dataset.SetCmd(CMyDataSet.WHICHCMD.SELECT, "Select UserName,Access,Name,PhoneNum,Age From UserInfo", CommandType.Text);
                m_dataset.MakeReadyForAdapter(true);
                m_dataset.Fill("Info");
               
                dataGridView.DataSource = m_dataset.GetTable("Info");
                dataGridView.Columns[0].ReadOnly = true;
                dataGridView.Columns[1].ReadOnly = true;


            }
            catch (System.Exception eee)
            {
                MessageBox.Show(eee.Message);

            }



        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if (MessageBox.Show("确定更改吗？", "确认", MessageBoxButtons.OKCancel) != DialogResult.OK)
                //return;
            try
            {
                m_dataset.Update("Info");

                return;
            }
            catch (System.Exception eee)
            {
                MessageBox.Show(eee.Message);

            }

        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            if (m_dataset.GetDS().HasChanges())
            {
                if (MessageBox.Show("修改没有保存，是否退出？", "确认", MessageBoxButtons.OKCancel) != DialogResult.OK)
                    return;
            }
            this.Close();
        }

        private void buttonCancle_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("确定取消已经进行的更改吗?","确定更改",MessageBoxButtons.OKCancel) == DialogResult.OK)
                m_dataset.GetDS().RejectChanges();
        }

        private void dataGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DataGridView ds = sender as DataGridView;
            try
            {
                if (Convert.ToUInt32(ds.CurrentRow.Cells[1].Value) == 0)
                {
                    MessageBox.Show("不能删除管理员！");
                    e.Cancel = true;
                }
            }
            catch (System.Exception eee)
            {
                MessageBox.Show(eee.Message);
            	
            }
            
        }

        private void dataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView = sender as DataGridView;
            string str = "";
            if (dataGridView.Rows.Count < e.RowIndex)
                return;
            str = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
           
            if (e.ColumnIndex == 2)                               //防止NAME过多
            {
                str = dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
                if (str.Length > 10)
                {
                    MessageBox.Show(@"请输入10个字符以下!");
                    dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "00000";
                }

            }
            if (e.ColumnIndex == 3)                               //防止PHONENUM过多
            {
                str = dataGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
                if (str.Length > 11)
                {
                    MessageBox.Show(@"请输入11个字符以下!");
                    dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "00000";
                }

            }
        }

        private void dataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show(e.Exception.Message);
        }
    }
}