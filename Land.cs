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
    public enum RIGHT {INVAILID,ADMIN,CONDUCTOR,MAINTAIN,GUEST};    //权限
     
    public partial class Land : Form  //登陆窗口
    {
        private CMyData m_data;

        public void SetData(SqlConnection cn,FormMain formmain)
        {
            m_data = new CMyData(cn, RIGHT.INVAILID, "");
            m_iTryTime = 5;
            m_formParent = formmain;
        }
         
        private int m_iTryTime;            //已经尝试的次数
        private FormMain m_formParent;      //父窗口
        public Land()
        {
            InitializeComponent();
        }
              

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            if (textBoxUser.Text == "" || textBoxPwd.Text == "")
            {
                MessageBox.Show("请输入用户名和密码！");
                return;
            }
            string strSelect = "SELECT * FROM UserInfo WHERE UserName = '" + textBoxUser.Text + "' AND PassWord = '" + textBoxPwd.Text + "'";//判断用户名是否正确
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
                    switch(sdr.GetInt32(2))                //获取当前权限
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
                    MessageBox.Show("用户名或密码错误!你还有" + 
                        (--m_iTryTime).ToString() + "次尝试机会!");
                    

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
                m_formParent.SetRight(right);   //将权限返回到父窗口
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
            RegisterUser formRegisterUser = new RegisterUser();    //注册用户窗口
            formRegisterUser.StartPosition = FormStartPosition.CenterParent;
            formRegisterUser.SetData(m_data.GetCN(),m_data.GetRight(),m_data.GetUserName());
            this.Hide();
            formRegisterUser.ShowDialog();
            this.Show();
        }
        
    }
}