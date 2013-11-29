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
    public partial class toSell : Form
    {


        private CMyData m_data;
        private string m_strLine;           //��·��Ϣ
        private string m_strDate;             //��Ʊ����
        private int m_iMoneyPerTic;           //ÿ��Ʊ�ļ۸�

        public void SetData(SqlConnection cn, RIGHT right, string strUser,string strline,string strdate)
        {
            m_data = new CMyData(cn, right, strUser);
            m_strLine = strline;
            m_strDate = strdate;
        }
       
     
        public toSell()
        {
            InitializeComponent();
        }

        
        private void toSell_Load(object sender, EventArgs e)
        {
             labelLinNum.Text =m_strLine;
            labelDate.Text = m_strDate;
            int iTicCount = 0; //��Ʊ��

            /*�ӳ�Ʊ�ж�ȡ�����Ϣ������* ListBox */
            m_data.SetCmd("SELECT LineInfo.Start,LineInfo.Terminal,LineNumberPrice.Price "
                + "FROM LineInfo INNER JOIN LineNumberPrice ON  LineInfo.LineNum = LineNumberPrice.LineNum"
                + " WHERE LineInfo.LineNum = '" + m_strLine + " '", CommandType.Text);
            try
            {
                m_data.CnOpen();
                SqlDataReader sr = m_data.ExecuteReader();
                if (sr.Read())
                {
                    labelStart.Text = sr["Start"].ToString();   //д�뵱ǰ��Ʊ�������Ϣ
                    labelEnd.Text =  sr["Terminal"].ToString();
                    m_iMoneyPerTic = Convert.ToInt32(sr["Price"]);

                }
                else
                {
                    MessageBox.Show("����,��ǰ���ݿ��в����� ���Ϊ " + m_strLine + "����·");
                    sr.Close();
                    m_data.CnClose();
                    return;
                }

                sr.Close();

                /*����listBox*/
                m_data.SetCmd("SELECT SeatNum FROM TicketInfo WHERE LineNum = '"
                                           + m_strLine + "' AND Date >=  '" + m_strDate + "'AND Date <='" + m_strDate + " 23:59:59'AND IsSold = 'no' ORDER BY SeatNum", CommandType.Text);

                SqlDataReader srTic = m_data.ExecuteReader();
                while (srTic.Read())
                {
                    string strNum = srTic["SeatNum"].ToString();
                    checkedListBox1.Items.Add(strNum);
                    iTicCount++;
                }
                //��ȡÿ��Ʊ�ļ۸�
                labelcount.Text = iTicCount.ToString() + "��";
                labelMoney.Text = "ÿ��:" + m_iMoneyPerTic.ToString() + " Ԫ";
                srTic.Close();
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
 

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            int iLength = checkedListBox1.CheckedItems.Count;
            if (iLength > 5)
            {
                MessageBox.Show("һ�������ֻ��������Ʊ!");
                return;
            }
            if (iLength == 0)
            {
                MessageBox.Show("û��ѡ���κ�һ����Ʊ��");
                return;
            }
            if (MessageBox.Show("һ������" + iLength.ToString() + "Ʊ��һ��Ҫ  " + (iLength * m_iMoneyPerTic).ToString() + "Ԫ��", "��Ʊȷ��", MessageBoxButtons.YesNo)
                != DialogResult.Yes)
                return;

            m_data.SetCmd("buy_ticket", CommandType.StoredProcedure);  //���ô洢������Ʊ
            m_data.RemoveParametres();

            m_data.AddParametres("@date", SqlDbType.DateTime, 10, ParameterDirection.Input);
            m_data.AddParametres("@ticketnumber", SqlDbType.Char, 10, ParameterDirection.Input);
            m_data.AddParametres("@linenum", SqlDbType.Char, 10, ParameterDirection.Input);
            m_data.AddParametres("@num", SqlDbType.Int, 10, ParameterDirection.Input);

            m_data.SetParamValue("@date", m_strDate);
            m_data.SetParamValue("@linenum", m_strLine);
            m_data.SetParamValue("@num", iLength);



            /*���ô洢����*/
            int i = 0;//for�м���
            try
            {
                m_data.CnOpen();
                for (; i < checkedListBox1.Items.Count; i++)
                {
                    if (checkedListBox1.GetItemChecked(i))
                    {

                        m_data.SetParamValue("@ticketnumber", checkedListBox1.Items[i].ToString());
                         m_data.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception eee)
            {
                MessageBox.Show(eee.Message);
            }
            finally
            {
                m_data.CnClose();

                /*ɾ��ѡ�е���*/
                i = 0;  //����
                for (; i < checkedListBox1.CheckedIndices.Count; )
                {
                    checkedListBox1.Items.RemoveAt(checkedListBox1.CheckedIndices[0]);
                }
               labelcount.Text = checkedListBox1.Items.Count.ToString() + "��";
            }


        }

        private void labelStart_Click(object sender, EventArgs e)
        {

        }

        private void labelLinNum_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
       
             
    }



   
}