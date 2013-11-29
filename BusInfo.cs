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
    public partial class BusInfo : Form
    {
        
        protected CMyDataSet m_dataset;   //数据库数据及操作类
        private string m_strLine;         //线路编号
        public void SetStringLine(string str)
        {
            m_strLine = str;
        }
       
        public BusInfo()
        {
            InitializeComponent();
        }
        public void SetData(SqlConnection cn, RIGHT right, string username)
        {
            m_dataset = new CMyDataSet(cn, right, username);  //初始化数据库数据
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            try
            {
                m_dataset.Update("Info");                    //更新数据表
                 
                return;
            }
            catch (System.Exception eee)
            {
                MessageBox.Show(eee.Message);               

            }

        }

        private void buttonReject_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定取消已经进行的更改吗?", "确定更改", MessageBoxButtons.OKCancel) == DialogResult.OK)
                m_dataset.GetDS().RejectChanges();          //取消已作的修改
        }       

        private void buttonClose_Click(object sender, EventArgs e)
        {
            if (m_dataset.GetDS().HasChanges())
            {
                if (MessageBox.Show("修改没有保存，是否退出？", "确认", MessageBoxButtons.OKCancel) != DialogResult.OK)
                    return;                              //直接退出窗口
            }
            this.Close();
        }

                      

        private void dataGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DataGridView ds = sender as DataGridView;             //当前选择的行位运行的则不能删除
            if (ds.CurrentRow.Cells[5].Value.ToString().Substring(0, 2) != "no")
            {
                MessageBox.Show("正在运行的汽车不能删除，要删除请先将其卸载!");
                e.Cancel = true;
            }

        }

        private void dataGridView_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            DataGridView ds = sender as DataGridView;
            ds.CurrentRow.Cells[5].Value = "no";                //增加默认值no
            
            
        }

        private void dataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView = sender as DataGridView;
            string str = "";
            if (dataGridView.Rows.Count < e.RowIndex)
                return;
            
            if(e.ColumnIndex == 3 || e.ColumnIndex==4)          //输入的是空调列和tv列 判断用户输入的是有还是没有
            {
                str = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                if (str.Length == 0)
                    return;
                if(str.Length ==1)
                {
                    if(str.Substring(0,1)!="有")
                    {
                        MessageBox.Show("请输入有或没有!");
                        dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "ERROR!";
                    }

                }
                else if(str.Length ==2)
                {
                    if(str.Substring(0,2)!="没有")
                    {
                        MessageBox.Show("请输入有或没有!");
                        dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "ERROR!";
                    }
                }
                else
                {
                    MessageBox.Show("请输入有或没有!");
                    dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "ERROR!";
                }

            }
            if (e.ColumnIndex == 0)                               //防止busid过多
            {
                str = dataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
                if (str.Length > 10)
                {
                    MessageBox.Show(@"请输入10个字符以下!");
                    dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "00000";
                }

            }
            if (e.ColumnIndex == 1)                               //防止style过多
            {
                str = dataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
                if (str.Length > 10)
                {
                    MessageBox.Show(@"请输入10个字符以下!");
                    dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "00000";
                }

            }
      
           
          
            
            
            //if(e.ColumnIndex == )
        }

        private void dataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show(e.Exception.Message);  //显示数据库出错的信息
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            FormSearchLine fTest = new FormSearchLine();        //打开搜索的窗口
            fTest.SetData(m_dataset.GetCN(), m_dataset.GetRight(), m_dataset.GetUserName());
            fTest.StartPosition = FormStartPosition.CenterParent;
            fTest.SetForm(this);
            fTest.ShowDialog();
            textBoxLineNum.Text = m_strLine;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if(textBoxLineNum.Text == "")
                    m_dataset.SetCmd(CMyDataSet.WHICHCMD.SELECT, "Select * From BusInfo", CommandType.Text);   //全都选择
                else
                {
                    m_dataset.SetCmd(CMyDataSet.WHICHCMD.SELECT, "Select * From BusInfo where busid in (select BusID from LineNumberPrice where LineNum = '" + textBoxLineNum.Text + "')", CommandType.Text); //选择bus
                }

                m_dataset.MakeReadyForAdapter(true);   //准备好数据适配器
                m_dataset.Fill("Info");                 //填充数据集
                DataTable dtInfo = m_dataset.GetTable("Info");  //获得Info表
                DataColumn[] dcPK = { dtInfo.Columns["BusID"] };  //设置主键
                m_dataset.GetDS().Tables["Info"].PrimaryKey = dcPK;
                dataGridView.DataSource = m_dataset.GetTable("Info");


                dataGridView.Columns[5].ReadOnly = true;  //第五列运行状态不能修改
               
            }
            catch (System.Exception eee)
            {
                MessageBox.Show(eee.Message);

            }

        }

     

       

    }
}