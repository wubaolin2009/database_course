using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace da1
{
    public partial class DriverInfo : Form
    {
        protected CMyDataSet m_dataset;
        public DriverInfo()
        {
            InitializeComponent();
        }
        public void SetData(SqlConnection cn, RIGHT right, string username)
        {
            m_dataset = new CMyDataSet(cn, right, username);
        }

     

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                m_dataset.Update("Info");          //更新数据表
                 
                return;
            }
            catch (System.Exception eee)
            {
                MessageBox.Show(eee.Message);

            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (m_dataset.GetDS().HasChanges())         //退出
            {
                if (MessageBox.Show("修改没有保存，是否退出？", "确认", MessageBoxButtons.OKCancel) != DialogResult.OK)
                    return;
            }
            this.Close();
        }

        private void buttonReject_Click(object sender, EventArgs e)     //取消修改
        {
            if (MessageBox.Show("确定取消已经进行的更改吗?", "确定更改", MessageBoxButtons.OKCancel) == DialogResult.OK)
                m_dataset.GetDS().RejectChanges();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool bNeedLine = false;  //是否需要额外的信息
            if (checkBoxExtra.Checked == true)
                bNeedLine = true;
            progressBar.Value = 0;   //设置进度条的显示
            DataColumn colLineNum;
            DataColumn colStart;
            DataColumn colTerminal;
            DataTable tableNow;

            SqlConnection cn = m_dataset.GetCN();
            SqlCommand cmd = new SqlCommand("", cn);
            SqlDataReader dr;
            string strLineNum = "";
           
            int iCount = 0;  //一共有多少行


            try
            {
                cn.Open();
                m_dataset.SetCmd(CMyDataSet.WHICHCMD.SELECT, SetupCmd(), CommandType.Text);  //执行命令
                m_dataset.MakeReadyForAdapter(true);
                m_dataset.ClearAllTable();
                m_dataset.Fill("Info");
                DataTable dtInfo = m_dataset.GetTable("Info");
                DataColumn[] dcPK = { dtInfo.Columns["DriverNum"] };  //设置主键
                m_dataset.GetDS().Tables["Info"].PrimaryKey = dcPK;
                iCount = m_dataset.GetTable("Info").Rows.Count;
                progressBar.Value = 10;
                //Add New Column
                if (bNeedLine)
                {
                    colLineNum = new DataColumn("LineNum");  //加入与司机相关的其他信息
                    colLineNum.DataType = typeof(string);
                    colStart = new DataColumn("Start");
                    colLineNum.DataType = typeof(string);
                    colTerminal = new DataColumn("Terminal");
                    colLineNum.DataType = typeof(string);

                    tableNow = m_dataset.GetTable("Info");   //增加列到table中
                    tableNow.Columns.Add(colLineNum);
                    tableNow.Columns.Add(colStart);
                    tableNow.Columns.Add(colTerminal);
                    progressBar.Value = 15;

                    int iLineNow = 0; //当前处理的行数
                    double dbProgress = 0.0; //进度

                    foreach (DataRow rowUpdate in tableNow.Rows)
                    {
                        cmd.CommandText = "SELECT LineNum From LineDriver where driverNum = '" + rowUpdate[0].ToString() + "'";
                        dr = cmd.ExecuteReader();   //开始读取数据并设置进度条
                        if (dr.Read())
                        {
                            rowUpdate[6] = dr[0].ToString();
                            strLineNum = dr[0].ToString();
                        }
                        dr.Close();
                        cmd.CommandText = "SELECT Start,Terminal From LineInfo where LineNum = '" + strLineNum + "'";
                        dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            rowUpdate[7] = dr[0].ToString();
                            rowUpdate[8] = dr[1].ToString();
                        }
                        dr.Close();
                        if (iCount != 0)
                        {
                            dbProgress = Convert.ToDouble(iLineNow) / Convert.ToDouble(iCount);
                            progressBar.Value = 20 + Convert.ToInt32(dbProgress * 70);  //根据还有多少没有处理显示进度条
                        }
                        else
                            progressBar.Value = 100;
                        iLineNow++;          //下移行

                    }
                }
                progressBar.Value = 100;


                dataGridView.DataSource = m_dataset.GetTable("Info");
                dataGridView.Columns[5].ReadOnly = true;
                
                if (bNeedLine)
                {
                    dataGridView.Columns[6].ReadOnly = true;   //line信息为可读 防止关系的错乱
                    dataGridView.Columns[7].ReadOnly = true;
                    dataGridView.Columns[8].ReadOnly = true;
                }


            }
            catch (System.Exception eee)
            {
                MessageBox.Show(eee.Message);

            }
            finally
            {
                cn.Close();
            }
        }

        private string SetupCmd()  // 根据当前窗口的状态产生select语句
        {
            if (checkBoxAll.Checked)
                return "Select * From DriverInfo";               //根据用户的选择产生不同的cmd
            string strCmd = "Select * From DriverInfo WHERE ";
           if(radioButtonDriver.Checked)
           {
               if (textBoxDriver.Text == "")
               {
                   return "Select * From DriverInfo";   // 全部选择

               }
               else return strCmd + " Name = '" + textBoxDriver.Text + "'";
               
           }
           else
           {
               if(textBoxStart.Text =="" && textBoxEnd.Text == "")
                   return "Select * From DriverInfo";
               strCmd = "Select DriverInfo.* From DriverInfo Inner Join LineDriver ON LineDriver.DriverNum = DriverInfo.DriverNum Where LineDriver.LineNum IN ("
               + "Select LineNum From LineInfo WHERE ";     //看是否选择了start和end信息
               
               if (textBoxStart.Text != "")
               {
                   strCmd += (" LineInfo.Start = '" + textBoxStart.Text + "'");
                   if (textBoxEnd.Text != "")
                   {
                       strCmd += ( " AND LineInfo.Terminal = '" + textBoxEnd.Text + "')");
                       return strCmd;
                   }
                   return strCmd + ")";
               }
               else if(textBoxEnd.Text!= "")
               {
                   strCmd += ( "LineInfo.Terminal = '" + textBoxEnd.Text + "')");
               }
              
           }
            return strCmd;


        }
       

        private void radioButtonLine_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButtonLine.Checked)             //根据用户的需求决定其他控件的可选状态              
            {
                labelDriver.Enabled = false;
                labelStart.Enabled = true;
                labelEnd.Enabled = true;
                textBoxDriver.Enabled = false;
                textBoxEnd.Enabled = true;
                textBoxStart.Enabled = true;
            }
            if(radioButtonDriver.Checked)
            {
                labelDriver.Enabled = true;
                labelStart.Enabled = false;
                labelEnd.Enabled = false;
                textBoxDriver.Enabled = true;
                textBoxEnd.Enabled = false;
                textBoxStart.Enabled = false;
            }
        }

        private void checkBoxAll_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBoxAll.Checked)               //根据用户checkbox的选择改变其他控件的可选性
            {
                labelDriver.Enabled = false;
                labelStart.Enabled = false;
                labelEnd.Enabled = false;
                textBoxDriver.Enabled = false;
                textBoxEnd.Enabled = false;
                textBoxStart.Enabled = false;
                groupBox1.Enabled = false;

            }
            else
            {
                groupBox1.Enabled =true;
                radioButtonLine_CheckedChanged(sender, e);
            }

        }

        private void DriverInfo_Load(object sender, EventArgs e)
        {
            labelDriver.Enabled = false;
            textBoxDriver.Enabled = false;
        }

       

        private void dataGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DataGridView ds = sender as DataGridView;
            if (ds.CurrentRow.Cells[5].Value.ToString().Substring(0, 2) != "no")    //防止用户删除已经运行的司机
            {
                MessageBox.Show("正在运行汽车的司机不能删除，要删除请先将其卸载!");
                e.Cancel = true;
            }
        }

        private void dataGridView_UserAddedRow(object sender, DataGridViewRowEventArgs e)   //新增一行isrunning默认值no
        {
            DataGridView ds = sender as DataGridView;
            ds.CurrentRow.Cells[5].Value = "no";
        }

        private void dataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show(e.Exception.Message);           //显示错误消息
        } 

        private void dataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        { 
            Regex regExpression = new Regex(@"(^(\d{11})$)");         //电话号码的正则表达式
            Regex regExpressionID = new Regex(@"(^([a-z]\d{5})$)");   //DriverNumber 的正则表达式
            dataGridView = sender as DataGridView;
            string str = "";
            if (dataGridView.Rows.Count < e.RowIndex)
                return;

            if (e.ColumnIndex == 2)                             //性别列
            {
                str = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                if (str.Length == 0)
                    return;
                if(str.Substring(0,1)!="男" && str.Substring(0,1)!="女")
                {
                    MessageBox.Show("请输入男或女!");
                    dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "ERROR!";
                }
            }

            if(e.ColumnIndex == 4)                                 //电话号码列
            {
                str = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                if (str.Length == 0)
                    return;
                if(!regExpression.IsMatch(str)) 
                {
                    MessageBox.Show("请输入11位数字!");
                    dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "ERROR!";
                }
               
                
            }
            if (e.ColumnIndex == 0)                               //防止主键的check错误
            {
                str = dataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
                if (!regExpressionID.IsMatch(str))
                {
                    MessageBox.Show(@"请输入[a-z]\d{5}的形式!");
                    dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "z00000";
                }

            }
            if (e.ColumnIndex == 1)                               //防止name过多
            {
                str = dataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
                if (str.Length>10)
                {
                    MessageBox.Show(@"请输入10个字符以下!");
                    dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "00000";
                }

            }
            if (e.ColumnIndex == 3)                               //防止address的错误
            {
                str = dataGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
                if (str.Length>30)
                {
                    MessageBox.Show(@"输入30个字符以前!");
                    dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "00000";
                }

            }

        }

      

       
    }
}