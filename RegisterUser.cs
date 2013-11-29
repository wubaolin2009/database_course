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
    public partial class RegisterUser : Form
    {
        private CMyData m_data;

        public void SetData(SqlConnection cn, RIGHT right, string strUser)
        {
            m_data = new CMyData(cn, right, strUser);
        }
       
        public RegisterUser()
        {
            InitializeComponent();
        }

        private void RegisterUser_Load(object sender, EventArgs e)
        {
            radioButtonGuest.Checked = true;
            switch(m_data.GetRight())                   //根据权限设置相应控件的可用性
            {
                case RIGHT.ADMIN:
                    break;
                case RIGHT.CONDUCTOR:
                    radioButtonConductor.Enabled = false;
                    radioButtonMainTain.Enabled = false;
                    break;
                case RIGHT.GUEST:
                    radioButtonConductor.Enabled = false;
                    radioButtonMainTain.Enabled = false;
                    break;
                    
                case RIGHT.MAINTAIN:
                    radioButtonMainTain.Enabled = false;
                    break;
                case RIGHT.INVAILID:
                    radioButtonConductor.Enabled = false;
                    radioButtonMainTain.Enabled = false;
                    break;                   
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBoxPwd1_Leave(object sender, EventArgs e)
        {
            if (textBoxPwd1.Text == "" || textBoxPwd2.Text == "")      //判断俩此输入的密码是否一致
                return;
            if (textBoxPwd1.Text != textBoxPwd2.Text)
            {
                labelPwd.Text = "两次输入的密码不一致！";
                buttonYes.Enabled = false;
            }
            else
            {
                labelPwd.Text = "两次输入的密码相同！";
                buttonYes.Enabled = true;

            }
        }

        private void textBoxPwd2_Leave(object sender, EventArgs e)   //判断俩此输入的密码是否一致
        {
            if (textBoxPwd1.Text == "" || textBoxPwd2.Text == "")
                return;
            if (textBoxPwd1.Text != textBoxPwd2.Text)
            {
                labelPwd.Text = "两次输入的密码不一致！";
                buttonYes.Enabled = false;
            }
            else
            {
                labelPwd.Text = "两次输入的密码相同！";
                buttonYes.Enabled = true;

            }
        }

        private void textBoxUserName_Leave(object sender, EventArgs e)
        {
            if (textBoxUserName.Text == "")
                return;
            m_data.SetCmd("SELECT * FROM UserInfo WHERE UserName = '" + textBoxUserName.Text + "'",CommandType.Text);
            SqlDataReader dr;
            try
            {
                m_data.CnOpen();
                dr = m_data.ExecuteReader();          //判断当前用户名是否被注册过
                if (!dr.Read())
                {
                    labelIsRegisted.Text = "用户名:" + textBoxUserName.Text+"没有注册过!";
                    buttonYes.Enabled = true;
                }
                else
                {
                    labelIsRegisted.Text = "用户名:" + textBoxUserName.Text + "已经被注册过!";
                    buttonYes.Enabled = false;
                    textBoxUserName.Select();
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


        }

        private void textBoxAge_Leave(object sender, EventArgs e)
        {
            if (textBoxAge.Text == "")
                return;
           
            Regex regExpresstion = new Regex(@"\D");
            if (regExpresstion.IsMatch(textBoxAge.Text))
            {
                this.labelAge.Text = "年龄格式错误\n应为1-2位数字";
                this.buttonYes.Enabled = false;

            }
            else
            {
                if (Convert.ToUInt32(textBoxAge.Text) < 18)        //应该输入18岁以上
                {
                    MessageBox.Show("年龄应该大于等于18！");
                    return;
                }
                this.labelAge.Text = "年龄格式正确！";
                this.buttonYes.Enabled = true;
            }

        }

        private void textBoxPhone_Leave(object sender, EventArgs e)
        {
            if (textBoxPhone.Text == "")
                return;
           
            Regex regExpresstion = new Regex(@"(^(\d{11})$)");  //电话号码应该为11位
            if (!regExpresstion.IsMatch(textBoxPhone.Text))
            {
                this.labelPhone.Text = "格式错误\n应为11位数!";
                this.buttonYes.Enabled = false;

            }
            else
            {
                this.labelPhone.Text = "电话格式正确！";
                this.buttonYes.Enabled = true;
            }


        }

        private void buttonYes_Click(object sender, EventArgs e)
        {
            if(textBoxPwd1.Text != textBoxPwd2.Text)
            {
                MessageBox.Show("两次密码不一样!");
                return;
            }
            if (textBoxAge.Text == "" ||
                textBoxName.Text == "" ||
                textBoxPhone.Text == "" ||
                textBoxPwd1.Text == "" ||
                textBoxPwd2.Text == "" ||
                textBoxUserName.Text == "")
            {
                MessageBox.Show("请填满信息！");
                return;
            }
            int iAccess = -1;
            if(radioButtonConductor.Checked)
                iAccess = 2;
       
                
            else  if (radioButtonMainTain.Checked)
                 iAccess = 1;
             else 
             iAccess = 3;
            //插入数据到用户表
            string strInsert = "INSERT INTO UserInfo Values('" + textBoxUserName.Text + "','" + textBoxPwd1.Text + "','" + iAccess + "','"
            + textBoxName.Text + "','" + textBoxPhone.Text + "','" + textBoxAge.Text + "')";
            m_data.SetCmd(strInsert, CommandType.Text);
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
            }
            this.Close();

           


        }
    }
}