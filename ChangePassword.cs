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
    public partial class ChangePassword : Form
    {
        private CMyData m_data;

        public void SetData(SqlConnection cn,RIGHT right,string strUser)  //��������
        {
            m_data = new CMyData(cn, right, strUser);
        }
        public ChangePassword()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBoxNew1_Leave(object sender, EventArgs e)
        {
            if (textBoxNew2.Text == "" || textBoxNew1.Text == "")  //�Ƚ���������������Ƿ�һ��
                return;
            if (textBoxNew1.Text != textBoxNew2.Text)
            {
                labelIsSame.Text = "������������벻һ�£�";
                buttonOk.Enabled = false;
            }
            else 
            {
                labelIsSame.Text = "��������������� ͬ��";
                buttonOk.Enabled = true;

            }
            
            
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
           string strGetPwd = "SELECT Password FROM UserInfo WHERE UserName = '" + m_data.GetUserName() + "' AND PassWord = '" + textBoxOld.Text + "'"; //�жϵ�ǰ�û��Ƿ��Ѿ�ע��
           if (MessageBox.Show(this, "ȷ����?", "ȷ�ϴ���", MessageBoxButtons.OKCancel) != DialogResult.OK)
               return;
            try
            {
                m_data.CnOpen();
                m_data.SetCmd(strGetPwd, CommandType.Text);    //����ԭʼ�����Ƿ���ȷ
                SqlDataReader dr = m_data.ExecuteReader();
                if(!dr.Read())
                {
                    MessageBox.Show("�������!");
                    dr.Close();
                    return;
                }
              
                dr.Close();
            }
            catch (System.Exception eee)
            {
                MessageBox.Show(eee.Message);
            	
            }
            finally
            {
                m_data.CnClose();
            }


            string strUpdatePwd = "UPDATE UserInfo SET Password = '" + textBoxNew1.Text + "' WHERE UserName = '" + m_data.GetUserName() + "'"; //��������
            m_data.SetCmd(strUpdatePwd, CommandType.Text);

            try
            {
                m_data.CnOpen();
                m_data.ExecuteNonQuery();
              
           
           
            }
            catch (System.Exception eee)
            {
                MessageBox.Show(eee.Message);

            }
            finally
            {
                m_data.CnClose();
            }

            MessageBox.Show("�޸ĳɹ�!");
            this.Close();
            
        }

        private void textBoxNew2_Leave(object sender, EventArgs e)
        {
            if (textBoxNew2.Text == "" || textBoxNew1.Text == "")   //ͬtextBoxNew1_Leave �ж����������Ƿ�һ��
                return;
            if (textBoxNew1.Text != textBoxNew2.Text)
            {
                labelIsSame.Text = "������������벻һ�£�";
                buttonOk.Enabled = false;
            }
            else
            {
                labelIsSame.Text = "��������������� ͬ��";
                buttonOk.Enabled = true;

            }
        }

      

       
       
    }
}