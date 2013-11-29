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

        public void SetData(SqlConnection cn,RIGHT right,string strUser)  //设置数据
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
            if (textBoxNew2.Text == "" || textBoxNew1.Text == "")  //比较俩次输入的密码是否一样
                return;
            if (textBoxNew1.Text != textBoxNew2.Text)
            {
                labelIsSame.Text = "两次输入的密码不一致！";
                buttonOk.Enabled = false;
            }
            else 
            {
                labelIsSame.Text = "两次输入的密码相 同！";
                buttonOk.Enabled = true;

            }
            
            
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
           string strGetPwd = "SELECT Password FROM UserInfo WHERE UserName = '" + m_data.GetUserName() + "' AND PassWord = '" + textBoxOld.Text + "'"; //判断当前用户是否已经注册
           if (MessageBox.Show(this, "确定吗?", "确认窗口", MessageBoxButtons.OKCancel) != DialogResult.OK)
               return;
            try
            {
                m_data.CnOpen();
                m_data.SetCmd(strGetPwd, CommandType.Text);    //看看原始密码是否正确
                SqlDataReader dr = m_data.ExecuteReader();
                if(!dr.Read())
                {
                    MessageBox.Show("密码错误!");
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


            string strUpdatePwd = "UPDATE UserInfo SET Password = '" + textBoxNew1.Text + "' WHERE UserName = '" + m_data.GetUserName() + "'"; //更改密码
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

            MessageBox.Show("修改成功!");
            this.Close();
            
        }

        private void textBoxNew2_Leave(object sender, EventArgs e)
        {
            if (textBoxNew2.Text == "" || textBoxNew1.Text == "")   //同textBoxNew1_Leave 判断俩此输入是否一致
                return;
            if (textBoxNew1.Text != textBoxNew2.Text)
            {
                labelIsSame.Text = "两次输入的密码不一致！";
                buttonOk.Enabled = false;
            }
            else
            {
                labelIsSame.Text = "两次输入的密码相 同！";
                buttonOk.Enabled = true;

            }
        }

      

       
       
    }
}