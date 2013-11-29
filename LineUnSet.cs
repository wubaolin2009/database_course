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
    public partial class LineUnSet : Form
    {
       
        public LineUnSet()
        {
            InitializeComponent();
        }
        public void SetData(SqlConnection cn, RIGHT right, string name)
        {
            m_data = new CMyData(cn, right, name);
        }
        CMyData m_data;

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string strCmd = "Select LineNum,TimeStart,Start,Terminal from LineInfo where IsRunning = 'yes' And Isunload = 'no'";����//������·
            if(textBoxStart.Text != "")
            {
                 strCmd += " AND Start = '" + textBoxStart.Text + "' ";
            }
            if(textBoxEnd.Text != "")
            {
                strCmd += " AND Terminal = '" + textBoxEnd.Text + "' ";
            }
            listBox.Items.Clear();
            m_data.SetCmd(strCmd, CommandType.Text);                        //����·��Ϣ��ʾ����
            
            SqlDataReader dr;
            int iCount = 0; //����
            try
            {
                m_data.CnOpen();
                dr = m_data.ExecuteReader();
                while (dr.Read())
                {
                    listBox.Items.Add(dr[0].ToString() + "   " + "����ʱ��:" + dr[1].ToString()+ "  ������:" + dr[2].ToString() + "  Ŀ�ĵ�:"+ dr[3].ToString());
                    iCount++;

                }
                dr.Close();
                MessageBox.Show("�ҵ�" + iCount.ToString() + "�����");  //д��ListBox��

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

        private void buttonUnset_Click(object sender, EventArgs e)
        {
            if(listBox.SelectedItems.Count == 0)
            {
                MessageBox.Show("��ѡ��һ����·");
                return;
            }
            if (MessageBox.Show(this, "ȷ����?", "ȷ�ϴ���", MessageBoxButtons.OKCancel) != DialogResult.OK)
                return;
            //ж����·
            m_data.SetCmd("Unload", CommandType.StoredProcedure);  //���д洢����ж����·
            m_data.AddParametres("@linenum", SqlDbType.NChar, 10,ParameterDirection.Input);
            m_data.SetParamValue("@linenum", listBox.SelectedItems[0].ToString().Substring(0,5));
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
                this.Close();
            }
           

        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

     
    }

   
}