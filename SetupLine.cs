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
            this.Text = "当前用户为:" + m_data.GetUserName();
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
                    comboBoxLine.Items.Add(drLine[0].ToString());          //将线路信息写入combobox中
                }
                drLine.Close();
                SqlDataReader drDriver = m_data.SetCmd(strDriver, CommandType.Text).ExecuteReader();
                while (drDriver.Read())                                   //将司机信息写入combobox中
                {
                    comboBoxDriver.Items.Add(drDriver[0].ToString());
                }
                drDriver.Close();
                SqlDataReader drBus = m_data.SetCmd(strBus, CommandType.Text).ExecuteReader();
                while (drBus.Read())
                {
                    comboBoxBus.Items.Add(drBus[0].ToString());          //将汽车信息写入combobox中
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
           
            AddTicket_Load(sender,e);                         //重置所有的listbox
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (comboBoxBus.Text == "" || comboBoxDriver.Text == "" || comboBoxLine.Text == "" || textBoxPrice.Text == "")
            {
                MessageBox.Show("4个下拉框不能为空！");
                return;
            }
            if (MessageBox.Show(this, "确定吗?", "确认窗口", MessageBoxButtons.OKCancel) != DialogResult.OK)
                return;
            try
            {
                m_data.CnOpen();
                m_data.SetCmd("line_create", CommandType.StoredProcedure);    //调用存储过程并增加参数
                m_data.AddParametres("@linenum", SqlDbType.Char, 10, ParameterDirection.Input);
                m_data.AddParametres("@busid", SqlDbType.Char, 10, ParameterDirection.Input);
                m_data.AddParametres("@price", SqlDbType.Money, 10, ParameterDirection.Input);
                m_data.AddParametres("@drivernum", SqlDbType.Char, 10, ParameterDirection.Input);

                m_data.SetParamValue("@linenum", comboBoxLine.Text);
                m_data.SetParamValue("@busid", comboBoxBus.Text);
                m_data.SetParamValue("@price", textBoxPrice.Text);
                m_data.SetParamValue("@drivernum", comboBoxDriver.Text);

                m_data.ExecuteNonQuery();
                MessageBox.Show("成功！");
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
            
            string strToUpdate = "SELECT Start,Terminal,TimeStart FROM LineInfo WHERE LineNum = '" + comboBoxLine.Text + "'"; //根据当前所选显示相应的线路信息
            m_data.SetCmd(strToUpdate, CommandType.Text);
            SqlDataReader dr;
            try
            {
                m_data.CnOpen();
                dr = m_data.ExecuteReader();
                if (dr.Read())
                    labelLine.Text = "起始站点:" + dr["Start"].ToString()
                                                 + "\n\n终 点 站:" + dr["Terminal"].ToString()
                                                 + "\n\n出发时间:" + dr["TimeStart"].ToString();
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
            string strToUpdate = "SELECT Style,SeatNum,AirConditioner,TV FROM BusInfo WHERE BusID = '" + comboBoxBus.Text + "'";//根据当前所选显示相应的汽车信息
            m_data.SetCmd(strToUpdate, CommandType.Text);
            SqlDataReader dr;
            try
            {
                m_data.CnOpen();
                dr = m_data.ExecuteReader();
                if (dr.Read())
                    labelBus.Text = "车辆型号:" + dr["Style"].ToString()
                                                 + "\n\n座 位 数:" + dr["SeatNum"].ToString()
                                                 + "\n\n空    调:" + dr["AirConditioner"].ToString()
                                                 + "\n\n电    视:" + dr["TV"].ToString();
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

            string strToUpdate = "SELECT Name,Sex,Address,PhoneNum FROM DriverInfo WHERE DriverNum = '" + comboBoxDriver.Text + "'"; //根据当前所选显示相应的司机信息
            m_data.SetCmd(strToUpdate, CommandType.Text);
            SqlDataReader dr;
            try
            {
                m_data.CnOpen();
                dr = m_data.ExecuteReader();
                if (dr.Read())
                    labelDriver.Text = "姓    名:" + dr["Name"].ToString()
                                                 + "\n\n性    别:" + dr["Sex"].ToString()
                                                 + "\n\n联系地址:" + dr["Address"].ToString()
                                                 + "\n\n电话号码:" + dr["PhoneNum"].ToString();
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
            
            AddTicket_Load(sender, e);        //重置所有combox的数据
        }

        private void buttonAddDriver_Click(object sender, EventArgs e)
        {
            DriverInfo driverinfo = new DriverInfo();
            driverinfo.SetData(m_data.GetCN(), m_data.GetRight(), m_data.GetUserName());
            driverinfo.StartPosition = FormStartPosition.CenterParent;
            driverinfo.ShowDialog();
            
            AddTicket_Load(sender, e); //重置所有combox的数据
        }

      
    }

     
}