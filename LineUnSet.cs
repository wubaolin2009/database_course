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
    public partial class LineUnSet : Form
    {
       
        public LineUnSet()
        {
            InitializeComponent();
        }
        public void SetData(SqlConnection cn, RIGHT right, string name)
        {
            m_data = new CMyData(cn, right, name);
        }
        CMyData m_data;

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string strCmd = "Select LineNum,TimeStart,Start,Terminal from LineInfo where IsRunning = 'yes' And Isunload = 'no'";　　//查找线路
            if(textBoxStart.Text != "")
            {
                 strCmd += " AND Start = '" + textBoxStart.Text + "' ";
            }
            if(textBoxEnd.Text != "")
            {
                strCmd += " AND Terminal = '" + textBoxEnd.Text + "' ";
            }
            listBox.Items.Clear();
            m_data.SetCmd(strCmd, CommandType.Text);                        //将线路信息显示出来
            
            SqlDataReader dr;
            int iCount = 0; //计数
            try
            {
                m_data.CnOpen();
                dr = m_data.ExecuteReader();
                while (dr.Read())
                {
                    listBox.Items.Add(dr[0].ToString() + "   " + "出发时间:" + dr[1].ToString()+ "  出发地:" + dr[2].ToString() + "  目的地:"+ dr[3].ToString());
                    iCount++;

                }
                dr.Close();
                MessageBox.Show("找到" + iCount.ToString() + "个结果");  //写到ListBox中

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

        private void buttonUnset_Click(object sender, EventArgs e)
        {
            if(listBox.SelectedItems.Count == 0)
            {
                MessageBox.Show("先选择一条线路");
                return;
            }
            if (MessageBox.Show(this, "确定吗?", "确认窗口", MessageBoxButtons.OKCancel) != DialogResult.OK)
                return;
            //卸载线路
            m_data.SetCmd("Unload", CommandType.StoredProcedure);  //运行存储过程卸载线路
            m_data.AddParametres("@linenum", SqlDbType.NChar, 10,ParameterDirection.Input);
            m_data.SetParamValue("@linenum", listBox.SelectedItems[0].ToString().Substring(0,5));
            try
            {
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
                this.Close();
            }
           

        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

     
    }

   
}