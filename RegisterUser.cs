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
            switch(m_data.GetRight())                   //����Ȩ��������Ӧ�ؼ��Ŀ�����
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
            if (textBoxPwd1.Text == "" || textBoxPwd2.Text == "")      //�ж���������������Ƿ�һ��
                return;
            if (textBoxPwd1.Text != textBoxPwd2.Text)
            {
                labelPwd.Text = "������������벻һ�£�";
                buttonYes.Enabled = false;
            }
            else
            {
                labelPwd.Text = "���������������ͬ��";
                buttonYes.Enabled = true;

            }
        }

        private void textBoxPwd2_Leave(object sender, EventArgs e)   //�ж���������������Ƿ�һ��
        {
            if (textBoxPwd1.Text == "" || textBoxPwd2.Text == "")
                return;
            if (textBoxPwd1.Text != textBoxPwd2.Text)
            {
                labelPwd.Text = "������������벻һ�£�";
                buttonYes.Enabled = false;
            }
            else
            {
                labelPwd.Text = "���������������ͬ��";
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
                dr = m_data.ExecuteReader();          //�жϵ�ǰ�û����Ƿ�ע���
                if (!dr.Read())
                {
                    labelIsRegisted.Text = "�û���:" + textBoxUserName.Text+"û��ע���!";
                    buttonYes.Enabled = true;
                }
                else
                {
                    labelIsRegisted.Text = "�û���:" + textBoxUserName.Text + "�Ѿ���ע���!";
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
                this.labelAge.Text = "�����ʽ����\nӦΪ1-2λ����";
                this.buttonYes.Enabled = false;

            }
            else
            {
                if (Convert.ToUInt32(textBoxAge.Text) < 18)        //Ӧ������18������
                {
                    MessageBox.Show("����Ӧ�ô��ڵ���18��");
                    return;
                }
                this.labelAge.Text = "�����ʽ��ȷ��";
                this.buttonYes.Enabled = true;
            }

        }

        private void textBoxPhone_Leave(object sender, EventArgs e)
        {
            if (textBoxPhone.Text == "")
                return;
           
            Regex regExpresstion = new Regex(@"(^(\d{11})$)");  //�绰����Ӧ��Ϊ11λ
            if (!regExpresstion.IsMatch(textBoxPhone.Text))
            {
                this.labelPhone.Text = "��ʽ����\nӦΪ11λ��!";
                this.buttonYes.Enabled = false;

            }
            else
            {
                this.labelPhone.Text = "�绰��ʽ��ȷ��";
                this.buttonYes.Enabled = true;
            }


        }

        private void buttonYes_Click(object sender, EventArgs e)
        {
            if(textBoxPwd1.Text != textBoxPwd2.Text)
            {
                MessageBox.Show("�������벻һ��!");
                return;
            }
            if (textBoxAge.Text == "" ||
                textBoxName.Text == "" ||
                textBoxPhone.Text == "" ||
                textBoxPwd1.Text == "" ||
                textBoxPwd2.Text == "" ||
                textBoxUserName.Text == "")
            {
                MessageBox.Show("��������Ϣ��");
                return;
            }
            int iAccess = -1;
            if(radioButtonConductor.Checked)
                iAccess = 2;
       
                
            else  if (radioButtonMainTain.Checked)
                 iAccess = 1;
             else 
             iAccess = 3;
            //�������ݵ��û���
            string strInsert = "INSERT INTO UserInfo Values('" + textBoxUserName.Text + "','" + textBoxPwd1.Text + "','" + iAccess + "','"
            + textBoxName.Text + "','" + textBoxPhone.Text + "','" + textBoxAge.Text + "')";
            m_data.SetCmd(strInsert, CommandType.Text);
            try
            {
                m_data.CnOpen();
                m_data.ExecuteNonQuery();
                MessageBox.Show("�ɹ�!");
                
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