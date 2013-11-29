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
    public partial class SetupLine : Form
    {
        private CMyData m_data;

        public void SetData(SqlConnection cn, RIGHT right, string strUser)
        {
            m_data = new CMyData(cn, right, strUser);
        }
      
      
        public SetupLine()
        {
            InitializeComponent();
        }

      

        private void AddTicket_Load(object sender, EventArgs e)
        {
            this.Text = "��ǰ�û�Ϊ:" + m_data.GetUserName();
            string strLine = "SELECT LineNum FROM LineInfo WHERE IsRunning = 'no'";
            string strBus = "SELECT BusID FROM  BusInfo WHERE IsRunning = 'no'";
            string strDriver = "SELECT DriverNum FROM DriverInfo WHERE IsRunning = 'no'";
            labelBus.Text = "";
            labelDriver.Text = "";
            labelLine.Text = "";
           
            try
            {
                m_data.CnOpen();
                
                SqlDataReader drLine =m_data.SetCmd(strLine,CommandType.Text).ExecuteReader();
                comboBoxDriver.Items.Clear();
                comboBoxLine.Items.Clear();
                comboBoxBus.Items.Clear();


                while (drLine.Read())
                {
                    comboBoxLine.Items.Add(drLine[0].ToString());          //����·��Ϣд��combobox��
                }
                drLine.Close();
                SqlDataReader drDriver = m_data.SetCmd(strDriver, CommandType.Text).ExecuteReader();
                while (drDriver.Read())                                   //��˾����Ϣд��combobox��
                {
                    comboBoxDriver.Items.Add(drDriver[0].ToString());
                }
                drDriver.Close();
                SqlDataReader drBus = m_data.SetCmd(strBus, CommandType.Text).ExecuteReader();
                while (drBus.Read())
                {
                    comboBoxBus.Items.Add(drBus[0].ToString());          //��������Ϣд��combobox��
                }

                drBus.Close();

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

        private void buttonAddLine_Click(object sender, EventArgs e)
        {
            LineInfo lineinfo = new LineInfo();
            lineinfo.SetData(m_data.GetCN(), m_data.GetRight(), m_data.GetUserName());
            lineinfo.StartPosition = FormStartPosition.CenterParent;
            lineinfo.ShowDialog();
           
            AddTicket_Load(sender,e);                         //�������е�listbox
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (comboBoxBus.Text == "" || comboBoxDriver.Text == "" || comboBoxLine.Text == "" || textBoxPrice.Text == "")
            {
                MessageBox.Show("4����������Ϊ�գ�");
                return;
            }
            if (MessageBox.Show(this, "ȷ����?", "ȷ�ϴ���", MessageBoxButtons.OKCancel) != DialogResult.OK)
                return;
            try
            {
                m_data.CnOpen();
                m_data.SetCmd("line_create", CommandType.StoredProcedure);    //���ô洢���̲����Ӳ���
                m_data.AddParametres("@linenum", SqlDbType.Char, 10, ParameterDirection.Input);
                m_data.AddParametres("@busid", SqlDbType.Char, 10, ParameterDirection.Input);
                m_data.AddParametres("@price", SqlDbType.Money, 10, ParameterDirection.Input);
                m_data.AddParametres("@drivernum", SqlDbType.Char, 10, ParameterDirection.Input);

                m_data.SetParamValue("@linenum", comboBoxLine.Text);
                m_data.SetParamValue("@busid", comboBoxBus.Text);
                m_data.SetParamValue("@price", textBoxPrice.Text);
                m_data.SetParamValue("@drivernum", comboBoxDriver.Text);

                m_data.ExecuteNonQuery();
                MessageBox.Show("�ɹ���");
            }
            catch (Exception eee)
            {
                MessageBox.Show(eee.Message);
            }
            finally
            {
                m_data.CnClose();

            }
            this.Close();
            



        }

        private void comboBoxLine_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            string strToUpdate = "SELECT Start,Terminal,TimeStart FROM LineInfo WHERE LineNum = '" + comboBoxLine.Text + "'"; //���ݵ�ǰ��ѡ��ʾ��Ӧ����·��Ϣ
            m_data.SetCmd(strToUpdate, CommandType.Text);
            SqlDataReader dr;
            try
            {
                m_data.CnOpen();
                dr = m_data.ExecuteReader();
                if (dr.Read())
                    labelLine.Text = "��ʼվ��:" + dr["Start"].ToString()
                                                 + "\n\n�� �� վ:" + dr["Terminal"].ToString()
                                                 + "\n\n����ʱ��:" + dr["TimeStart"].ToString();
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

        private void comboBoxBus_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strToUpdate = "SELECT Style,SeatNum,AirConditioner,TV FROM BusInfo WHERE BusID = '" + comboBoxBus.Text + "'";//���ݵ�ǰ��ѡ��ʾ��Ӧ��������Ϣ
            m_data.SetCmd(strToUpdate, CommandType.Text);
            SqlDataReader dr;
            try
            {
                m_data.CnOpen();
                dr = m_data.ExecuteReader();
                if (dr.Read())
                    labelBus.Text = "�����ͺ�:" + dr["Style"].ToString()
                                                 + "\n\n�� λ ��:" + dr["SeatNum"].ToString()
                                                 + "\n\n��    ��:" + dr["AirConditioner"].ToString()
                                                 + "\n\n��    ��:" + dr["TV"].ToString();
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

        private void comboBoxDriver_SelectedIndexChanged(object sender, EventArgs e)
        {

            string strToUpdate = "SELECT Name,Sex,Address,PhoneNum FROM DriverInfo WHERE DriverNum = '" + comboBoxDriver.Text + "'"; //���ݵ�ǰ��ѡ��ʾ��Ӧ��˾����Ϣ
            m_data.SetCmd(strToUpdate, CommandType.Text);
            SqlDataReader dr;
            try
            {
                m_data.CnOpen();
                dr = m_data.ExecuteReader();
                if (dr.Read())
                    labelDriver.Text = "��    ��:" + dr["Name"].ToString()
                                                 + "\n\n��    ��:" + dr["Sex"].ToString()
                                                 + "\n\n��ϵ��ַ:" + dr["Address"].ToString()
                                                 + "\n\n�绰����:" + dr["PhoneNum"].ToString();
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

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonAddBus_Click(object sender, EventArgs e)
        {
            BusInfo businfo = new BusInfo();
            businfo.SetData(m_data.GetCN(), m_data.GetRight(), m_data.GetUserName());
            businfo.StartPosition = FormStartPosition.CenterParent;
            businfo.ShowDialog();
            
            AddTicket_Load(sender, e);        //��������combox������
        }

        private void buttonAddDriver_Click(object sender, EventArgs e)
        {
            DriverInfo driverinfo = new DriverInfo();
            driverinfo.SetData(m_data.GetCN(), m_data.GetRight(), m_data.GetUserName());
            driverinfo.StartPosition = FormStartPosition.CenterParent;
            driverinfo.ShowDialog();
            
            AddTicket_Load(sender, e); //��������combox������
        }

      
    }

     
}