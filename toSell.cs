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
        private string m_strLine;           //线路信息
        private string m_strDate;             //车票日期
        private int m_iMoneyPerTic;           //每张票的价格

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
            int iTicCount = 0; //车票数

            /*从车票中读取相关信息并更新* ListBox */
            m_data.SetCmd("SELECT LineInfo.Start,LineInfo.Terminal,LineNumberPrice.Price "
                + "FROM LineInfo INNER JOIN LineNumberPrice ON  LineInfo.LineNum = LineNumberPrice.LineNum"
                + " WHERE LineInfo.LineNum = '" + m_strLine + " '", CommandType.Text);
            try
            {
                m_data.CnOpen();
                SqlDataReader sr = m_data.ExecuteReader();
                if (sr.Read())
                {
                    labelStart.Text = sr["Start"].ToString();   //写入当前车票的相关信息
                    labelEnd.Text =  sr["Terminal"].ToString();
                    m_iMoneyPerTic = Convert.ToInt32(sr["Price"]);

                }
                else
                {
                    MessageBox.Show("错误,当前数据库中不存在 编号为 " + m_strLine + "的线路");
                    sr.Close();
                    m_data.CnClose();
                    return;
                }

                sr.Close();

                /*更新listBox*/
                m_data.SetCmd("SELECT SeatNum FROM TicketInfo WHERE LineNum = '"
                                           + m_strLine + "' AND Date >=  '" + m_strDate + "'AND Date <='" + m_strDate + " 23:59:59'AND IsSold = 'no' ORDER BY SeatNum", CommandType.Text);

                SqlDataReader srTic = m_data.ExecuteReader();
                while (srTic.Read())
                {
                    string strNum = srTic["SeatNum"].ToString();
                    checkedListBox1.Items.Add(strNum);
                    iTicCount++;
                }
                //读取每张票的价格
                labelcount.Text = iTicCount.ToString() + "张";
                labelMoney.Text = "每张:" + m_iMoneyPerTic.ToString() + " 元";
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
                MessageBox.Show("一个人最多只能买五张票!");
                return;
            }
            if (iLength == 0)
            {
                MessageBox.Show("没有选择任何一个车票！");
                return;
            }
            if (MessageBox.Show("一共买了" + iLength.ToString() + "票，一共要  " + (iLength * m_iMoneyPerTic).ToString() + "元！", "售票确认", MessageBoxButtons.YesNo)
                != DialogResult.Yes)
                return;

            m_data.SetCmd("buy_ticket", CommandType.StoredProcedure);  //调用存储过程买票
            m_data.RemoveParametres();

            m_data.AddParametres("@date", SqlDbType.DateTime, 10, ParameterDirection.Input);
            m_data.AddParametres("@ticketnumber", SqlDbType.Char, 10, ParameterDirection.Input);
            m_data.AddParametres("@linenum", SqlDbType.Char, 10, ParameterDirection.Input);
            m_data.AddParametres("@num", SqlDbType.Int, 10, ParameterDirection.Input);

            m_data.SetParamValue("@date", m_strDate);
            m_data.SetParamValue("@linenum", m_strLine);
            m_data.SetParamValue("@num", iLength);



            /*调用存储过程*/
            int i = 0;//for中计数
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

                /*删除选中的项*/
                i = 0;  //计数
                for (; i < checkedListBox1.CheckedIndices.Count; )
                {
                    checkedListBox1.Items.RemoveAt(checkedListBox1.CheckedIndices[0]);
                }
               labelcount.Text = checkedListBox1.Items.Count.ToString() + "张";
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