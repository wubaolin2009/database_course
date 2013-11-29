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
        private string m_strLine1 = "";   //��һ��������·���
        private string m_strBus1 = "";    //��һ�������������
        private string m_strLine2 = "";  //��2��������·���
        private bool m_bSetup = true;    //�Ƿ�Ҫ��װ��������·
        private bool m_bSetup2 = true;   //�Ƿ�Ҫ��װ˾������·
        private string m_strDriver = ""; //dirver���
        private CMyData m_data;
        public void SetSetupLine(bool bSetup)  //����Ҫ��װ����ж��
        {
            m_bSetup = bSetup;
        }
        public void SetSetupLine2(bool bSetup) //����Ҫ��װ����ж��
        {
            m_bSetup2 = bSetup;
        }
        public void SetStringLine2(string str)   //��Ĵ��ڵ������õ�ǰ���ڵ���Ϣ
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
        public void SetData(SqlConnection cn, RIGHT right, string name)  //��ʼ������
        {
            m_data = new CMyData(cn, right, name);
        }
      
        public ChangeLineRun()
        {
            InitializeComponent();
        }

            private void ButtonSearchLine_Click(object sender, EventArgs e)
        {
            FormSearchLine fTest = new FormSearchLine();  //�򿪲�����·�Ĵ���
            fTest.SetData(m_data.GetCN(), m_data.GetRight(), m_data.GetUserName());
            fTest.StartPosition = FormStartPosition.CenterParent;
            fTest.SetForm(this);
            fTest.ShowDialog();
            textBoxLine1.Text = m_strLine1;
            
        }

        private void buttonSearchBus_Click(object sender, EventArgs e)
        {
            FormSearchBus fSb = new FormSearchBus();   //�򿪲���bus�Ĵ���
            fSb.SetData(m_data.GetCN(), m_data.GetRight(), m_data.GetUserName());
            fSb.SetForm(this);
            fSb.StartPosition = FormStartPosition.CenterParent;
            if (textBoxLine1.Text != "")
                fSb.SetLineNum(textBoxLine1.Text);
            fSb.ShowDialog();
            textBoxBus.Text = m_strBus1;
            if (m_bSetup)                  //������Ҫ��װ��·����ж��������radiobutton�Ŀ�ѡ���
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
            FormSearchLine2 fTest = new FormSearchLine2();   //�򿪲���line�Ĵ���
            fTest.SetData(m_data.GetCN(), m_data.GetRight(), m_data.GetUserName());
            fTest.SetForm(this);
            fTest.StartPosition = FormStartPosition.CenterParent;
            fTest.ShowDialog();
            textBoxLine2.Text = m_strLine2;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FormSearchDriver fSd = new FormSearchDriver();   //�򿪲���˾���Ĵ���
            fSd.SetData(m_data.GetCN(), m_data.GetRight(), m_data.GetUserName());
            fSd.SetForm(this);
            fSd.StartPosition = FormStartPosition.CenterParent;
            if (textBoxLine2.Text != "")
                fSd.SetLineNum(textBoxLine2.Text);
            fSd.ShowDialog();
            textBoxDriver.Text = m_strDriver;              //������Ҫ��װ��·����ж��������radiobutton�Ŀ�ѡ���
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
                MessageBox.Show("��·��������Ų���Ϊ��!");
                return;
            }
            try
            {
                m_data.SetCmd("businsert_again", CommandType.StoredProcedure);  //����bus��line
                m_data.RemoveParametres();          //ɾ����ǰ�Ĳ���
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
                        MessageBox.Show("�ɹ�!");
                        break;
                    case -1:
                        MessageBox.Show("��·������!");
                        break;
                    case -2:
                        MessageBox.Show("�����ǿ���!");
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
                MessageBox.Show("��·��˾����Ų���Ϊ��!");
                return;
            }
            try
            {
                m_data.SetCmd("driver_line_link", CommandType.StoredProcedure);  //����Driver��line
                m_data.RemoveParametres();
                m_data.AddParametres("@drivernum", SqlDbType.Char,6 ,ParameterDirection.Input);
                m_data.AddParametres("@linenum", SqlDbType.Char, 5, ParameterDirection.Input);
              
                m_data.SetParamValue("@drivernum", textBoxDriver.Text);
                m_data.SetParamValue("@linenum", textBoxLine2.Text);
             
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

        }

        private void buttonUnset1_Click(object sender, EventArgs e)
        {
            
            if (textBoxLine1.Text == "" || textBoxBus.Text == "")
            {
                MessageBox.Show("��·��������Ų���Ϊ��!");
                return;
            }
            if (MessageBox.Show(this, "ȷ����?", "ȷ�ϴ���", MessageBoxButtons.OKCancel) != DialogResult.OK)
                return;
            
            try
            {
                m_data.SetCmd("delete_link_bus", CommandType.StoredProcedure);  //����bus��line
                m_data.RemoveParametres();          //ɾ����ǰ�Ĳ���
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
                        MessageBox.Show("Ŀǰ����·�ϵ���������2������ֹɾ��");
                        break;
                    case 0:
                        MessageBox.Show("�ɹ�");
                        break;
                    case 2:
                        MessageBox.Show("��·��������ƥ��!");
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
                MessageBox.Show("��·��˾����Ų���Ϊ��!");
                return;
            }
            if (MessageBox.Show(this, "ȷ����?", "ȷ�ϴ���", MessageBoxButtons.OKCancel) != DialogResult.OK)
                return;
            try
            {
                m_data.SetCmd("delete_link_driver", CommandType.StoredProcedure);  //����bus��line
                m_data.RemoveParametres();          //ɾ����ǰ�Ĳ���
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
                        MessageBox.Show("Ŀǰ����·�ϵ�˾������2�ˣ���ֹɾ��");
                        break;
                    case 0:
                        MessageBox.Show("�ɹ�");
                        break;
                    case 2:
                        MessageBox.Show("��ǰ��·��˾����ƥ��!");
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
            tabPage1.Text = "��·-����";
            tabPage2.Text = "��·-˾��";
        }
              
    }
}