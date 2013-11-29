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
    public partial class SellTicket : Form
    {
        private CMyData m_data;
        private CMyDataSet m_ds;
  
        public SellTicket()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void SetData(SqlConnection cn,RIGHT right,string name)
        {
            m_data = new CMyData(cn,right,name);
            m_ds = new CMyDataSet(cn, right, name);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if (m_data.GetRight() != RIGHT.ADMIN && m_data.GetRight() != RIGHT.CONDUCTOR)
                buttonManger.Enabled = false;
            DateTime dt = System.DateTime.Now; 
            TimeSpan tSpan = new TimeSpan(1,0,0,0);
            for(int fi = 0;fi<7;fi++)   //д������
            {
                int iY = dt.Year;
                int iM = dt.Month;
                int iD = dt.Day;
                string strDate;
             
                strDate = iY.ToString() + "-" + iM.ToString() + "-" + iD.ToString();
                dataCB.Items.Add(strDate);
                dt += tSpan;
            }
            dataCB.SelectedIndex = 0; 
            /*��ʼ�� ComboBox */
            m_data.SetCmd("SELECT DISTINCT Start FROM LineInfo where IsRunning = 'yes'", CommandType.Text); //�����е���·�г���
            try
            {

                m_data.CnOpen();
                SqlDataReader sr = m_data.ExecuteReader();
                while (sr.Read())
                {
                    cbFrom.Items.Add(sr[0].ToString());   //����item�� combobox
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (   cbFrom.Text == ""  ||  cbTo.Text == "" )
            {
                MessageBox.Show(this, "���������վ���յ�վ!");  //������� 
                return;
            }
            this.listBoxTicket.Items.Clear();
            /* ��� listBox   */
            //��ȡ��ǰѡ��ĳ�Ʊ����
            DateTime dt = System.DateTime.Now;
            TimeSpan tSpan = new TimeSpan(dataCB.SelectedIndex, 0, 0, 0);
            dt += tSpan;

            
            string cstr = "select  LineInfo.LineNum,LineInfo.TimeStart "
           + "from  LineInfo "
           + " WHERE  LineInfo.Start ='"
           + cbFrom.Text + "'AND LineInfo.Terminal ='"   // ѡ����Ӧ����·
           + cbTo.Text + "'";
            DataTable dt1;
            DataTable dt2;
            DataColumn dcTemp;

            try
            {
                m_ds.ClearAllTable();
                m_ds.CnOpen();
                m_ds.SetCmd(CMyDataSet.WHICHCMD.SELECT, cstr, CommandType.Text);
                m_ds.MakeReadyForAdapter(false);  //׼������������
                m_ds.Fill("Info");
                string cstr2 = "select * from TicketInfo where Date >= '" + dataCB.SelectedItem.ToString() + "'AND Date<= '" + dataCB.SelectedItem.ToString() + " 23:59:59' AND IsSold = 'no'";
                m_ds.SetCmd(CMyDataSet.WHICHCMD.SELECT, cstr2, CommandType.Text);
                m_ds.MakeReadyForAdapter(false);
                m_ds.Fill("ticket");          //����·�ͳ�Ʊ��Ϣ�����������ж�����Ʊ

                //SqlDataAdapter sqlad1 = new SqlDataAdapter(cstr2, m_cn);
                //sqlad.Fill(ds, "Info");
                //sqlad1.Fill(ds, "ticket");

                //����count
                dt1 = m_ds.GetDS().Tables["Info"];
                 dt2 = m_ds.GetDS().Tables["ticket"];
                dcTemp = new DataColumn("count");
                dcTemp.DataType = typeof(Int32);
                if(!dt1.Columns.Contains("count"))
                    dt1.Columns.Add(dcTemp);
                foreach (DataRow fordr in dt1.Rows)        
                {
                    int count = 0;  //count 
                    foreach (DataRow fordr2 in m_ds.GetDS().Tables["ticket"].Rows)
                    {
                        if (fordr2["LineNum"].ToString().Substring(0, 5) == fordr["LineNum"].ToString().Substring(0, 5))    //����listbox
                            count++;
                    }
                    fordr[2] = count;
                }


                int countTicket = 0;

                foreach (DataRow forr in dt1.Rows)
                {
                    if (forr[2].ToString() != "0")
                    {
                        listBoxTicket.Items.Add(forr["LineNum"].ToString() + "          " + forr["TimeStart"].ToString() + "              " + forr["count"].ToString());
                        countTicket++;
                    }

                }

                labelcount.Text = countTicket.ToString() + "��";
                if (countTicket == 0)   //û����Ϣ
                    MessageBox.Show("û��Ʊ��");
            }
            catch (Exception eee)
            {
                MessageBox.Show(eee.Message);
            }
            finally
            {
                m_ds.CnClose();
            }
          }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            RIGHT rightNow = m_data.GetRight();
            if (listBoxTicket.SelectedItems.Count == 0)        
                return;
            if (rightNow == RIGHT.GUEST || rightNow == RIGHT.INVAILID || rightNow == RIGHT.MAINTAIN)  //�жϵ�ǰ�û��Ƿ������Ʊ
            {
                MessageBox.Show("��û����Ӧ��Ȩ��!");
                return;
            }
            toSell sellform = new toSell();
            string temp =listBoxTicket.SelectedItem.ToString();
            sellform.SetData(m_data.GetCN(), m_data.GetRight(), m_data.GetUserName(),listBoxTicket.Text.Substring(0,5),dataCB.Text);
            sellform.StartPosition = FormStartPosition.CenterParent;
            
            sellform.ShowDialog();
            Reset();
           
        }

        public void Reset()         //����ϴεĲ�ѯ��¼
        {
            this.labelcount.Text = "0��";
            this.listBoxTicket.Items.Clear();
        }

        private void cbFrom_TextUpdate(object sender, EventArgs e)
        {
           
            if (cbFrom.Text == "" || cbFrom.Text.Length <2)
                return;
            UpdateComboTo(this.cbFrom.Text); //����combobox
        }

        private void UpdateComboTo(string strFrom)
        {
            cbTo.Items.Clear();
            m_data.SetCmd("SELECT DISTINCT Terminal FROM LineInfo WHERE Start = '" + cbFrom.Text + "'", CommandType.Text); //����д����·������յ㵽combobox
            try
            {
                m_data.CnOpen();
                SqlDataReader dr = m_data.ExecuteReader();
                while (dr.Read())
                {
                    string strItem = dr[0].ToString();
                    cbTo.Items.Add(strItem);

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

        private void cbFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            UpdateComboTo(cbFrom.SelectedItem.ToString());
        }

        private void buttonManger_Click(object sender, EventArgs e)
        {
              if(listBoxTicket.SelectedItems.Count == 0)         
              {
                  MessageBox.Show("����ѡ��һ����·!");
                  return;
              }
            TicketPrice ticForm = new TicketPrice();  //����Ʊ����
          
            ticForm.SetData(m_data.GetCN(), m_data.GetRight(), m_data.GetUserName(),listBoxTicket.SelectedItem.ToString().Substring(0,5));
            ticForm.ShowDialog();
        }
    }

    
}