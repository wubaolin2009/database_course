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
    public partial class ChangeLineRun : Form
    {
        private string m_strLine1 = "";   //第一个窗口线路编号
        private string m_strBus1 = "";    //第一个窗口汽车编号
        private string m_strLine2 = "";  //第2个窗口线路编号
        private bool m_bSetup = true;    //是否要安装汽车到线路
        private bool m_bSetup2 = true;   //是否要安装司机到线路
        private string m_strDriver = ""; //dirver编号
        private CMyData m_data;
        public void SetSetupLine(bool bSetup)  //返回要安装还是卸载
        {
            m_bSetup = bSetup;
        }
        public void SetSetupLine2(bool bSetup) //返回要安装还是卸载
        {
            m_bSetup2 = bSetup;
        }
        public void SetStringLine2(string str)   //别的窗口调用设置当前窗口的信息
        {
            m_strLine2 = str;
        }

        public void SetStringLine1(string str)
        {
            m_strLine1 = str;
        }
        public void SetStringBus1(string str)
        {
            m_strBus1 = str;
        }
        public void SetStringDriver(string str)
        {
            m_strDriver = str;
        }
        public void SetData(SqlConnection cn, RIGHT right, string name)  //初始化数据
        {
            m_data = new CMyData(cn, right, name);
        }
      
        public ChangeLineRun()
        {
            InitializeComponent();
        }

            private void ButtonSearchLine_Click(object sender, EventArgs e)
        {
            FormSearchLine fTest = new FormSearchLine();  //打开查找线路的窗口
            fTest.SetData(m_data.GetCN(), m_data.GetRight(), m_data.GetUserName());
            fTest.StartPosition = FormStartPosition.CenterParent;
            fTest.SetForm(this);
            fTest.ShowDialog();
            textBoxLine1.Text = m_strLine1;
            
        }

        private void buttonSearchBus_Click(object sender, EventArgs e)
        {
            FormSearchBus fSb = new FormSearchBus();   //打开查找bus的窗口
            fSb.SetData(m_data.GetCN(), m_data.GetRight(), m_data.GetUserName());
            fSb.SetForm(this);
            fSb.StartPosition = FormStartPosition.CenterParent;
            if (textBoxLine1.Text != "")
                fSb.SetLineNum(textBoxLine1.Text);
            fSb.ShowDialog();
            textBoxBus.Text = m_strBus1;
            if (m_bSetup)                  //根据是要安装线路还是卸载来决定radiobutton的可选情况
            {
                buttonSetup1.Enabled = true;
                buttonUnset1.Enabled = false;
            }
            else
            {
                buttonSetup1.Enabled = false;
                buttonUnset1.Enabled = true;

            }

        }

        private void buttonSearchLine2_Click(object sender, EventArgs e)
        {
            FormSearchLine2 fTest = new FormSearchLine2();   //打开查找line的窗口
            fTest.SetData(m_data.GetCN(), m_data.GetRight(), m_data.GetUserName());
            fTest.SetForm(this);
            fTest.StartPosition = FormStartPosition.CenterParent;
            fTest.ShowDialog();
            textBoxLine2.Text = m_strLine2;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FormSearchDriver fSd = new FormSearchDriver();   //打开查找司机的窗口
            fSd.SetData(m_data.GetCN(), m_data.GetRight(), m_data.GetUserName());
            fSd.SetForm(this);
            fSd.StartPosition = FormStartPosition.CenterParent;
            if (textBoxLine2.Text != "")
                fSd.SetLineNum(textBoxLine2.Text);
            fSd.ShowDialog();
            textBoxDriver.Text = m_strDriver;              //根据是要安装线路还是卸载来决定radiobutton的可选情况
            if (m_bSetup2)
            {
                buttonSetup2.Enabled = true;
                buttonUnSet2.Enabled = false;
            }
            else
            {
                buttonSetup2.Enabled = false;
                buttonUnSet2.Enabled = true;

            }
        }

        private void buttonSetup1_Click(object sender, EventArgs e)
        {
            if(textBoxLine1.Text == "" || textBoxBus.Text == "")
            {
                MessageBox.Show("线路和汽车编号不能为空!");
                return;
            }
            try
            {
                m_data.SetCmd("businsert_again", CommandType.StoredProcedure);  //连接bus和line
                m_data.RemoveParametres();          //删除以前的参数
                m_data.AddParametres("@busid", SqlDbType.Char, 10, ParameterDirection.Input);
                m_data.AddParametres("@linenum", SqlDbType.Char, 5, ParameterDirection.Input);
                m_data.AddParametres("@count", SqlDbType.Int, 10, ParameterDirection.Output);
                m_data.SetParamValue("@busid", textBoxBus.Text);
                m_data.SetParamValue("@linenum", textBoxLine1.Text);
                m_data.CnOpen();
                m_data.ExecuteNonQuery();
                switch(Convert.ToInt32(m_data.GetParamValue("@count") ))
                {
                    case 1:
                        MessageBox.Show("成功!");
                        break;
                    case -1:
                        MessageBox.Show("线路不存在!");
                        break;
                    case -2:
                        MessageBox.Show("汽车非空闲!");
                        break;

                }
               

            }
            
            catch (System.Exception eee)
            {
                MessageBox.Show(eee.Message);
                      	
            }
            finally
            {
                m_data.CnClose();
            }





        }

        private void buttonSetup2_Click(object sender, EventArgs e)
        {
            if (textBoxLine2.Text == "" || textBoxDriver.Text == "")
            {
                MessageBox.Show("线路和司机编号不能为空!");
                return;
            }
            try
            {
                m_data.SetCmd("driver_line_link", CommandType.StoredProcedure);  //连接Driver和line
                m_data.RemoveParametres();
                m_data.AddParametres("@drivernum", SqlDbType.Char,6 ,ParameterDirection.Input);
                m_data.AddParametres("@linenum", SqlDbType.Char, 5, ParameterDirection.Input);
              
                m_data.SetParamValue("@drivernum", textBoxDriver.Text);
                m_data.SetParamValue("@linenum", textBoxLine2.Text);
             
                m_data.CnOpen();
                m_data.ExecuteNonQuery();
                MessageBox.Show("成功!");

            }

            catch (System.Exception eee)
            {
                MessageBox.Show(eee.Message);

            }
            finally
            {
                m_data.CnClose();
            }

        }

        private void buttonUnset1_Click(object sender, EventArgs e)
        {
            
            if (textBoxLine1.Text == "" || textBoxBus.Text == "")
            {
                MessageBox.Show("线路和汽车编号不能为空!");
                return;
            }
            if (MessageBox.Show(this, "确定吗?", "确认窗口", MessageBoxButtons.OKCancel) != DialogResult.OK)
                return;
            
            try
            {
                m_data.SetCmd("delete_link_bus", CommandType.StoredProcedure);  //连接bus和line
                m_data.RemoveParametres();          //删除以前的参数
                m_data.AddParametres("@busid", SqlDbType.Char, 10, ParameterDirection.Input);
                m_data.AddParametres("@linenum", SqlDbType.Char, 5, ParameterDirection.Input);
                m_data.AddParametres("@return", SqlDbType.Int, 10, ParameterDirection.Output);
                m_data.SetParamValue("@busid", textBoxBus.Text);
                m_data.SetParamValue("@linenum", textBoxLine1.Text);
                m_data.CnOpen();
                m_data.ExecuteNonQuery();
                switch (Convert.ToInt32(m_data.GetParamValue("@return")))
                {
                    case 1:
                        MessageBox.Show("目前该线路上的汽车少于2辆，禁止删除");
                        break;
                    case 0:
                        MessageBox.Show("成功");
                        break;
                    case 2:
                        MessageBox.Show("线路和汽车不匹配!");
                        break;            

                }


            }

            catch (System.Exception eee)
            {
                MessageBox.Show(eee.Message);

            }
            finally
            {
                m_data.CnClose();
            }
        }

        private void buttonUnSet2_Click(object sender, EventArgs e)
        {
            if (textBoxLine2.Text == "" || textBoxDriver.Text == "")
            {
                MessageBox.Show("线路和司机编号不能为空!");
                return;
            }
            if (MessageBox.Show(this, "确定吗?", "确认窗口", MessageBoxButtons.OKCancel) != DialogResult.OK)
                return;
            try
            {
                m_data.SetCmd("delete_link_driver", CommandType.StoredProcedure);  //连接bus和line
                m_data.RemoveParametres();          //删除以前的参数
                m_data.AddParametres("@drivernum", SqlDbType.Char, 6, ParameterDirection.Input);
                m_data.AddParametres("@linenum", SqlDbType.Char, 5, ParameterDirection.Input);
                m_data.AddParametres("@return", SqlDbType.Int, 10, ParameterDirection.Output);
                m_data.SetParamValue("@drivernum", textBoxDriver.Text);
                m_data.SetParamValue("@linenum", textBoxLine2.Text);
                m_data.SetParamValue("@return", "0");
                m_data.CnOpen();
                m_data.ExecuteNonQuery();
                switch (Convert.ToInt32(m_data.GetParamValue("@return")))
                {
                    case 1:
                        MessageBox.Show("目前该线路上的司机少于2人，禁止删除");
                        break;
                    case 0:
                        MessageBox.Show("成功");
                        break;
                    case 2:
                        MessageBox.Show("当前线路与司机不匹配!");
                        break;
                }

            }
            catch (Exception eee)
            {
                MessageBox.Show(eee.Message);
            }
            finally
            {
                m_data.CnClose();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ChangeLineRun_Load(object sender, EventArgs e)
        {
            tabPage1.Text = "线路-汽车";
            tabPage2.Text = "线路-司机";
        }
              
    }
}