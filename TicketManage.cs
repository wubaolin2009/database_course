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
    public partial class TicketPrice : Form
    {
        private CMyData m_data;

        private string m_strLine;
        public void SetData(SqlConnection cn,RIGHT right,string userName,string strLine)
        {
            m_data = new CMyData(cn,right,userName);
            m_strLine = strLine;
        }
        public TicketPrice()
        {
            InitializeComponent();
        }

        private void TicketPrice_Load(object sender, EventArgs e)
        {
            labelIntro.Text = "你当前选择的是编号为 " + m_strLine + "的线路\n票价为";   
            this.Text = m_data.GetUserName();
            string strPrice;
           m_data.SetCmd("Select Price from LineNumberPrice where LineNum = '" + m_strLine + "'", CommandType.Text);  //查找线路的价格
            try
            {
                m_data.CnOpen();
                SqlDataReader dr = m_data.ExecuteReader();
                if (!dr.Read())
                {
                    MessageBox.Show("不存在" + m_strLine + "的编号，线路信息可能已经被修改过！");    
                    m_data.CnClose();
                    return;
                }
                strPrice = dr[0].ToString();

                labelIntro.Text += (strPrice + "元");
                dr.Close();

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

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if(textBoxNewPrice.Text == "")
            {
                MessageBox.Show("请输入票价!");
                return;
            }
            if (MessageBox.Show(this, "确定吗?", "确认窗口", MessageBoxButtons.OKCancel) != DialogResult.OK)
                return;
            
            int iNumAffected;                  //影响到的线路数
            m_data.SetCmd("Update LineNumberPrice Set Price = " + textBoxNewPrice.Text + "where LineNum = '" + m_strLine + "'", CommandType.Text);
            try
            {
                m_data.CnOpen();
                iNumAffected = m_data.ExecuteNonQuery();
                if (iNumAffected == 0)
                {
                    MessageBox.Show("更新数据表失败!");
                }

                MessageBox.Show("成功!");
                this.Close();

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

        
        private void textBoxNewPrice_Leave(object sender, EventArgs e)
        {
            if (textBoxNewPrice.Text == "")
                return;
            Regex regExpresstion = new Regex(@"^(\d)*$");   //判断价钱的格式是否正确
            if (!regExpresstion.IsMatch(textBoxNewPrice.Text))
            {
                MessageBox.Show("格式错误!");
                buttonOk.Enabled = false;
               
            }
            else
                buttonOk.Enabled = true;

        }
    }
   
   
}