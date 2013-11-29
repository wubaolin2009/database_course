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
    public partial class LineInfo : Form               //��·��Ϣ
    {
        private CMyDataSet m_dataset;
        public LineInfo()
        {
            InitializeComponent();
        }

        public void SetData(SqlConnection cn, RIGHT right, string username)
        {
            m_dataset = new CMyDataSet(cn, right, username);
        }

        protected void buttonSa_Click(object sender, EventArgs e)
        {
            try
            {
                m_dataset.SetCmd(CMyDataSet.WHICHCMD.SELECT, "Select * From LineInfo", CommandType.Text);
                m_dataset.MakeReadyForAdapter(true);         //����·��Ϣд��datagridview��
                m_dataset.Fill("Info");
                DataTable dtInfo = m_dataset.GetTable("Info");
                DataColumn[] dcPK = { dtInfo.Columns["LineNum"] };
                m_dataset.GetDS().Tables["Info"].PrimaryKey = dcPK;
                dataGridView.DataSource = m_dataset.GetTable("Info");
                dataGridView.Columns[4].ReadOnly = true;
               // dataGridView.Columns[1].ReadOnly = true;

            }
            catch (System.Exception eee)
            {
                MessageBox.Show(eee.Message);

            }
        }

        protected void buttonSc_Click(object sender, EventArgs e)
        {
            
            if(textBoxHour.Text == "" || textBoxMinute.Text == "")
            {
                MessageBox.Show("������ʱ��!");
                return;
            }
            
            string str_cmd = "SELECT * FROM LineInfo  WHERE ";  //�����û���ѡ�����ѡ��ͬ��select���
            int iAnd = 0;
            if (textBoxStart.Text != "")
            {
                str_cmd += (" Start = '" + textBoxStart.Text + "'");
                iAnd = 1;
            }
            if (textBoxEnd.Text != "")
            {
               if(iAnd == 1)
               {
                   str_cmd += " AND ";
               }
               str_cmd += ("  Terminal = '" + textBoxEnd.Text + "'");
               if(iAnd == 0)
                   iAnd = 1;
            }


            if(radioButtonRun.Checked)
            {
                if (iAnd == 1)
                    str_cmd += " AND ";
                else iAnd = 1;
                str_cmd += "IsRunning = 'yes' ";

            }
            if(radioButtonRunNot.Checked)
            {
                if (iAnd == 1)
                    str_cmd += " AND ";
                else iAnd = 1;
                str_cmd += "IsRunning = 'no' ";
            }

            
            if (textBoxHour.Text.Length == 1)
            {
                textBoxHour.Text = ("0" + textBoxHour.Text);
            }
            if(textBoxMinute.Text.Length == 1)
            {
                textBoxMinute.Text = ("0" + textBoxMinute.Text);
            }

            if(radioButtonTimeBefore.Checked)
            {
                str_cmd += (" AND TimeStart  <= '" +textBoxHour.Text + ":" + textBoxMinute.Text + "'");
            }
            else
                str_cmd += ( " AND TimeStart >=  '" +textBoxHour.Text + ":" + textBoxMinute.Text + "'");


             try
            {
                m_dataset.SetCmd(CMyDataSet.WHICHCMD.SELECT, str_cmd, CommandType.Text);
                m_dataset.MakeReadyForAdapter(true);                    //д�����ݼ�
                m_dataset.Fill("Info");
                DataTable dtInfo = m_dataset.GetTable("Info");
                DataColumn[] dcPK = { dtInfo.Columns["LineNum"] };
                m_dataset.GetDS().Tables["Info"].PrimaryKey = dcPK;         //��������
               dataGridView.DataSource = m_dataset.GetTable("Info");
               
                dataGridView.Columns[4].ReadOnly = true;
                dataGridView.Columns[5].ReadOnly = true;
               // dataGridView.Columns[1].ReadOnly = true;

            }
            catch (System.Exception eee)
            {
                MessageBox.Show(eee.Message);

            }




        }

        protected void LineInfo_Load(object sender, EventArgs e)
        {
            textBoxStart.Select();
            radioButtonRun.Select();
            radioButtonTimeBefore.Select();
        }

        protected void buttonClose_Click(object sender, EventArgs e)
        {
            if (m_dataset.GetDS().HasChanges())             //�˳�
            {
                if (MessageBox.Show("�޸�û�б��棬�Ƿ��˳���", "ȷ��", MessageBoxButtons.OKCancel) != DialogResult.OK)
                    return;
            }
            this.Close();
        }

        protected void buttonReject_Click(object sender, EventArgs e)   //ȡ������
        {
            if (MessageBox.Show("ȷ��ȡ���Ѿ����еĸ�����?", "ȷ������", MessageBoxButtons.OKCancel) == DialogResult.OK)
                m_dataset.GetDS().RejectChanges();
        }

        protected void buttonConfirm_Click(object sender, EventArgs e)
        {
            //if (MessageBox.Show("ȷ��������", "ȷ��", MessageBoxButtons.OKCancel) != DialogResult.OK)
                //return;
            try
            {
                m_dataset.Update("Info");              

                return;
            }
            catch (System.Exception eee)
            {
                MessageBox.Show(eee.Message);

            }
        }

       
        protected void dataGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DataGridView ds = sender as DataGridView;
            try
            {
                if (ds.CurrentRow.Cells[4].Value.ToString().Substring(0, 2) != "no")  //�ж�Ҫɾ������·
                {
                    MessageBox.Show("����������������·����ɾ����Ҫɾ�����Ƚ���ж��!");    
                    e.Cancel = true;
                }
            }
            catch(Exception eee)
            {
                MessageBox.Show(eee.Message);
            }
        
        }

        protected void dataGridView_UserAddedRow(object sender, DataGridViewRowEventArgs e) //�����ӵ���·isrunningΪno
        {
             DataGridView ds = sender as DataGridView;
            try
            {
                ds.CurrentRow.Cells[5].Value = "no";
                ds.CurrentRow.Cells[4].Value = "no";
            }
            catch (System.Exception eee)
            {
                MessageBox.Show(eee.Message);
            	
            }
            
        }

        protected void dataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show(e.Exception.Message);
        }

        protected void dataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)   //�жϸ������Ƿ�����Լ������
        {
           Regex regExpression = new Regex(@"^(([0-1][0-9]:[0-5][0-9])\s*)$");
              Regex regExpression2 = new Regex(@"^(([2][0-3]:[0-5][0-9])\s*)$");

            Regex regExpressionID = new Regex(@"^([a-z][0-9][0-9][0-9][0-9])$");
            if (dataGridView.Rows.Count < e.RowIndex)
                return;
            try
            {

                dataGridView = sender as DataGridView;
                string str = "";
                    
                if (e.ColumnIndex == 3)           //ʱ��Լ�� xx:xx
                {
                    
                    str = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    if (str.Length == 0)
                        return;
                    if (!regExpression.IsMatch(str))
                    {
                        if (!regExpression2.IsMatch(str))
                        {
                            MessageBox.Show("������xx:xx����ʽ!");
                            dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "ERROR!";
                        }

                    }
                }
                else if (e.ColumnIndex == 0)           //������ŵ�Լ��
                {
                    str = dataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
                    if(!regExpressionID.IsMatch(str))
                    {
                        MessageBox.Show(@"������[a-z]\d{4}����ʽ!");
                        dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "z0000";
                    }

                }
                else if (e.ColumnIndex == 1 || e.ColumnIndex == 2)                               //��ֹname����
                {
                    str = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    if (str.Length > 10)
                    {
                        MessageBox.Show(@"������10���ַ�����!");
                        dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "00000";
                    }

                }
            }
            catch(Exception eee)
            {
                MessageBox.Show(eee.Message);
            }


        }

     

       
    }
}