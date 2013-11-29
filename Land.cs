using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.InteropServices;

namespace da1
{
    public enum RIGHT {INVAILID,ADMIN,CONDUCTOR,MAINTAIN,GUEST};    //Ȩ��
     
    public partial class Land : Form  //��½����
    {
        private CMyData m_data;

        public void SetData(SqlConnection cn,FormMain formmain)
        {
            m_data = new CMyData(cn, RIGHT.INVAILID, "");
            m_iTryTime = 5;
            m_formParent = formmain;
        }
         
        private int m_iTryTime;            //�Ѿ����ԵĴ���
        private FormMain m_formParent;      //������
        public Land()
        {
            InitializeComponent();
        }
              

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            if (textBoxUser.Text == "" || textBoxPwd.Text == "")
            {
                MessageBox.Show("�������û��������룡");
                return;
            }
            string strSelect = "SELECT * FROM UserInfo WHERE UserName = '" + textBoxUser.Text + "' AND PassWord = '" + textBoxPwd.Text + "'";//�ж��û����Ƿ���ȷ
            m_data.SetCmd(strSelect, CommandType.Text);
            RIGHT right = RIGHT.INVAILID;
           
            try
            {
                m_data.CnOpen();
                SqlDataReader sdr = m_data.ExecuteReader();
                string strName;
                if(sdr.Read())
                {
                    strName = sdr["UserName"].ToString();
                    switch(sdr.GetInt32(2))                //��ȡ��ǰȨ��
                    {
                        case 0:
                            right = RIGHT.ADMIN;
                            break;
                        case 1:
                            right = RIGHT.MAINTAIN;
                            break;
                        case 2:
                            right = RIGHT.CONDUCTOR;
                            break;
                        case 3:
                            right = RIGHT.GUEST;
                            break;
                    }
                    m_formParent.SetUserName(strName);
                }
                else
                {
                    MessageBox.Show("�û������������!�㻹��" + 
                        (--m_iTryTime).ToString() + "�γ��Ի���!");
                    

                }
                sdr.Close();
            }
            catch (System.Exception eee)
            {
            
                MessageBox.Show(eee.Message);

            	
            }
            finally
            {
                if (m_iTryTime == 0)
                {
                    this.Close();
                    m_data.CnClose();
                }
                m_formParent.SetRight(right);   //��Ȩ�޷��ص�������
                m_data.CnClose();              
                
            }
            if (right != RIGHT.INVAILID)
                this.Close();
           

            
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
           // this.DialogResult = ADMIN;
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegisterUser formRegisterUser = new RegisterUser();    //ע���û�����
            formRegisterUser.StartPosition = FormStartPosition.CenterParent;
            formRegisterUser.SetData(m_data.GetCN(),m_data.GetRight(),m_data.GetUserName());
            this.Hide();
            formRegisterUser.ShowDialog();
            this.Show();
        }
        
    }
}