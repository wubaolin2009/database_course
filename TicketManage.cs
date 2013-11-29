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
            labelIntro.Text = "�㵱ǰѡ����Ǳ��Ϊ " + m_strLine + "����·\nƱ��Ϊ";   
            this.Text = m_data.GetUserName();
            string strPrice;
           m_data.SetCmd("Select Price from LineNumberPrice where LineNum = '" + m_strLine + "'", CommandType.Text);  //������·�ļ۸�
            try
            {
                m_data.CnOpen();
                SqlDataReader dr = m_data.ExecuteReader();
                if (!dr.Read())
                {
                    MessageBox.Show("������" + m_strLine + "�ı�ţ���·��Ϣ�����Ѿ����޸Ĺ���");    
                    m_data.CnClose();
                    return;
                }
                strPrice = dr[0].ToString();

                labelIntro.Text += (strPrice + "Ԫ");
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
                MessageBox.Show("������Ʊ��!");
                return;
            }
            if (MessageBox.Show(this, "ȷ����?", "ȷ�ϴ���", MessageBoxButtons.OKCancel) != DialogResult.OK)
                return;
            
            int iNumAffected;                  //Ӱ�쵽����·��
            m_data.SetCmd("Update LineNumberPrice Set Price = " + textBoxNewPrice.Text + "where LineNum = '" + m_strLine + "'", CommandType.Text);
            try
            {
                m_data.CnOpen();
                iNumAffected = m_data.ExecuteNonQuery();
                if (iNumAffected == 0)
                {
                    MessageBox.Show("�������ݱ�ʧ��!");
                }

                MessageBox.Show("�ɹ�!");
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
            Regex regExpresstion = new Regex(@"^(\d)*$");   //�жϼ�Ǯ�ĸ�ʽ�Ƿ���ȷ
            if (!regExpresstion.IsMatch(textBoxNewPrice.Text))
            {
                MessageBox.Show("��ʽ����!");
                buttonOk.Enabled = false;
               
            }
            else
                buttonOk.Enabled = true;

        }
    }
   
   
}