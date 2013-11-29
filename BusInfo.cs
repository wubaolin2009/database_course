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
    public partial class BusInfo : Form
    {
        
        protected CMyDataSet m_dataset;   //���ݿ����ݼ�������
        private string m_strLine;         //��·���
        public void SetStringLine(string str)
        {
            m_strLine = str;
        }
       
        public BusInfo()
        {
            InitializeComponent();
        }
        public void SetData(SqlConnection cn, RIGHT right, string username)
        {
            m_dataset = new CMyDataSet(cn, right, username);  //��ʼ�����ݿ�����
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            try
            {
                m_dataset.Update("Info");                    //�������ݱ�
                 
                return;
            }
            catch (System.Exception eee)
            {
                MessageBox.Show(eee.Message);               

            }

        }

        private void buttonReject_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("ȷ��ȡ���Ѿ����еĸ�����?", "ȷ������", MessageBoxButtons.OKCancel) == DialogResult.OK)
                m_dataset.GetDS().RejectChanges();          //ȡ���������޸�
        }       

        private void buttonClose_Click(object sender, EventArgs e)
        {
            if (m_dataset.GetDS().HasChanges())
            {
                if (MessageBox.Show("�޸�û�б��棬�Ƿ��˳���", "ȷ��", MessageBoxButtons.OKCancel) != DialogResult.OK)
                    return;                              //ֱ���˳�����
            }
            this.Close();
        }

                      

        private void dataGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DataGridView ds = sender as DataGridView;             //��ǰѡ�����λ���е�����ɾ��
            if (ds.CurrentRow.Cells[5].Value.ToString().Substring(0, 2) != "no")
            {
                MessageBox.Show("�������е���������ɾ����Ҫɾ�����Ƚ���ж��!");
                e.Cancel = true;
            }

        }

        private void dataGridView_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            DataGridView ds = sender as DataGridView;
            ds.CurrentRow.Cells[5].Value = "no";                //����Ĭ��ֵno
            
            
        }

        private void dataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView = sender as DataGridView;
            string str = "";
            if (dataGridView.Rows.Count < e.RowIndex)
                return;
            
            if(e.ColumnIndex == 3 || e.ColumnIndex==4)          //������ǿյ��к�tv�� �ж��û���������л���û��
            {
                str = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                if (str.Length == 0)
                    return;
                if(str.Length ==1)
                {
                    if(str.Substring(0,1)!="��")
                    {
                        MessageBox.Show("�������л�û��!");
                        dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "ERROR!";
                    }

                }
                else if(str.Length ==2)
                {
                    if(str.Substring(0,2)!="û��")
                    {
                        MessageBox.Show("�������л�û��!");
                        dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "ERROR!";
                    }
                }
                else
                {
                    MessageBox.Show("�������л�û��!");
                    dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "ERROR!";
                }

            }
            if (e.ColumnIndex == 0)                               //��ֹbusid����
            {
                str = dataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
                if (str.Length > 10)
                {
                    MessageBox.Show(@"������10���ַ�����!");
                    dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "00000";
                }

            }
            if (e.ColumnIndex == 1)                               //��ֹstyle����
            {
                str = dataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
                if (str.Length > 10)
                {
                    MessageBox.Show(@"������10���ַ�����!");
                    dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "00000";
                }

            }
      
           
          
            
            
            //if(e.ColumnIndex == )
        }

        private void dataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show(e.Exception.Message);  //��ʾ���ݿ�������Ϣ
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            FormSearchLine fTest = new FormSearchLine();        //�������Ĵ���
            fTest.SetData(m_dataset.GetCN(), m_dataset.GetRight(), m_dataset.GetUserName());
            fTest.StartPosition = FormStartPosition.CenterParent;
            fTest.SetForm(this);
            fTest.ShowDialog();
            textBoxLineNum.Text = m_strLine;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if(textBoxLineNum.Text == "")
                    m_dataset.SetCmd(CMyDataSet.WHICHCMD.SELECT, "Select * From BusInfo", CommandType.Text);   //ȫ��ѡ��
                else
                {
                    m_dataset.SetCmd(CMyDataSet.WHICHCMD.SELECT, "Select * From BusInfo where busid in (select BusID from LineNumberPrice where LineNum = '" + textBoxLineNum.Text + "')", CommandType.Text); //ѡ��bus
                }

                m_dataset.MakeReadyForAdapter(true);   //׼��������������
                m_dataset.Fill("Info");                 //������ݼ�
                DataTable dtInfo = m_dataset.GetTable("Info");  //���Info��
                DataColumn[] dcPK = { dtInfo.Columns["BusID"] };  //��������
                m_dataset.GetDS().Tables["Info"].PrimaryKey = dcPK;
                dataGridView.DataSource = m_dataset.GetTable("Info");


                dataGridView.Columns[5].ReadOnly = true;  //����������״̬�����޸�
               
            }
            catch (System.Exception eee)
            {
                MessageBox.Show(eee.Message);

            }

        }

     

       

    }
}