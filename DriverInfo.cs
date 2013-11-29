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
    public partial class DriverInfo : Form
    {
        protected CMyDataSet m_dataset;
        public DriverInfo()
        {
            InitializeComponent();
        }
        public void SetData(SqlConnection cn, RIGHT right, string username)
        {
            m_dataset = new CMyDataSet(cn, right, username);
        }

     

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                m_dataset.Update("Info");          //�������ݱ�
                 
                return;
            }
            catch (System.Exception eee)
            {
                MessageBox.Show(eee.Message);

            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (m_dataset.GetDS().HasChanges())         //�˳�
            {
                if (MessageBox.Show("�޸�û�б��棬�Ƿ��˳���", "ȷ��", MessageBoxButtons.OKCancel) != DialogResult.OK)
                    return;
            }
            this.Close();
        }

        private void buttonReject_Click(object sender, EventArgs e)     //ȡ���޸�
        {
            if (MessageBox.Show("ȷ��ȡ���Ѿ����еĸ�����?", "ȷ������", MessageBoxButtons.OKCancel) == DialogResult.OK)
                m_dataset.GetDS().RejectChanges();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool bNeedLine = false;  //�Ƿ���Ҫ�������Ϣ
            if (checkBoxExtra.Checked == true)
                bNeedLine = true;
            progressBar.Value = 0;   //���ý���������ʾ
            DataColumn colLineNum;
            DataColumn colStart;
            DataColumn colTerminal;
            DataTable tableNow;

            SqlConnection cn = m_dataset.GetCN();
            SqlCommand cmd = new SqlCommand("", cn);
            SqlDataReader dr;
            string strLineNum = "";
           
            int iCount = 0;  //һ���ж�����


            try
            {
                cn.Open();
                m_dataset.SetCmd(CMyDataSet.WHICHCMD.SELECT, SetupCmd(), CommandType.Text);  //ִ������
                m_dataset.MakeReadyForAdapter(true);
                m_dataset.ClearAllTable();
                m_dataset.Fill("Info");
                DataTable dtInfo = m_dataset.GetTable("Info");
                DataColumn[] dcPK = { dtInfo.Columns["DriverNum"] };  //��������
                m_dataset.GetDS().Tables["Info"].PrimaryKey = dcPK;
                iCount = m_dataset.GetTable("Info").Rows.Count;
                progressBar.Value = 10;
                //Add New Column
                if (bNeedLine)
                {
                    colLineNum = new DataColumn("LineNum");  //������˾����ص�������Ϣ
                    colLineNum.DataType = typeof(string);
                    colStart = new DataColumn("Start");
                    colLineNum.DataType = typeof(string);
                    colTerminal = new DataColumn("Terminal");
                    colLineNum.DataType = typeof(string);

                    tableNow = m_dataset.GetTable("Info");   //�����е�table��
                    tableNow.Columns.Add(colLineNum);
                    tableNow.Columns.Add(colStart);
                    tableNow.Columns.Add(colTerminal);
                    progressBar.Value = 15;

                    int iLineNow = 0; //��ǰ���������
                    double dbProgress = 0.0; //����

                    foreach (DataRow rowUpdate in tableNow.Rows)
                    {
                        cmd.CommandText = "SELECT LineNum From LineDriver where driverNum = '" + rowUpdate[0].ToString() + "'";
                        dr = cmd.ExecuteReader();   //��ʼ��ȡ���ݲ����ý�����
                        if (dr.Read())
                        {
                            rowUpdate[6] = dr[0].ToString();
                            strLineNum = dr[0].ToString();
                        }
                        dr.Close();
                        cmd.CommandText = "SELECT Start,Terminal From LineInfo where LineNum = '" + strLineNum + "'";
                        dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            rowUpdate[7] = dr[0].ToString();
                            rowUpdate[8] = dr[1].ToString();
                        }
                        dr.Close();
                        if (iCount != 0)
                        {
                            dbProgress = Convert.ToDouble(iLineNow) / Convert.ToDouble(iCount);
                            progressBar.Value = 20 + Convert.ToInt32(dbProgress * 70);  //���ݻ��ж���û�д�����ʾ������
                        }
                        else
                            progressBar.Value = 100;
                        iLineNow++;          //������

                    }
                }
                progressBar.Value = 100;


                dataGridView.DataSource = m_dataset.GetTable("Info");
                dataGridView.Columns[5].ReadOnly = true;
                
                if (bNeedLine)
                {
                    dataGridView.Columns[6].ReadOnly = true;   //line��ϢΪ�ɶ� ��ֹ��ϵ�Ĵ���
                    dataGridView.Columns[7].ReadOnly = true;
                    dataGridView.Columns[8].ReadOnly = true;
                }


            }
            catch (System.Exception eee)
            {
                MessageBox.Show(eee.Message);

            }
            finally
            {
                cn.Close();
            }
        }

        private string SetupCmd()  // ���ݵ�ǰ���ڵ�״̬����select���
        {
            if (checkBoxAll.Checked)
                return "Select * From DriverInfo";               //�����û���ѡ�������ͬ��cmd
            string strCmd = "Select * From DriverInfo WHERE ";
           if(radioButtonDriver.Checked)
           {
               if (textBoxDriver.Text == "")
               {
                   return "Select * From DriverInfo";   // ȫ��ѡ��

               }
               else return strCmd + " Name = '" + textBoxDriver.Text + "'";
               
           }
           else
           {
               if(textBoxStart.Text =="" && textBoxEnd.Text == "")
                   return "Select * From DriverInfo";
               strCmd = "Select DriverInfo.* From DriverInfo Inner Join LineDriver ON LineDriver.DriverNum = DriverInfo.DriverNum Where LineDriver.LineNum IN ("
               + "Select LineNum From LineInfo WHERE ";     //���Ƿ�ѡ����start��end��Ϣ
               
               if (textBoxStart.Text != "")
               {
                   strCmd += (" LineInfo.Start = '" + textBoxStart.Text + "'");
                   if (textBoxEnd.Text != "")
                   {
                       strCmd += ( " AND LineInfo.Terminal = '" + textBoxEnd.Text + "')");
                       return strCmd;
                   }
                   return strCmd + ")";
               }
               else if(textBoxEnd.Text!= "")
               {
                   strCmd += ( "LineInfo.Terminal = '" + textBoxEnd.Text + "')");
               }
              
           }
            return strCmd;


        }
       

        private void radioButtonLine_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButtonLine.Checked)             //�����û���������������ؼ��Ŀ�ѡ״̬              
            {
                labelDriver.Enabled = false;
                labelStart.Enabled = true;
                labelEnd.Enabled = true;
                textBoxDriver.Enabled = false;
                textBoxEnd.Enabled = true;
                textBoxStart.Enabled = true;
            }
            if(radioButtonDriver.Checked)
            {
                labelDriver.Enabled = true;
                labelStart.Enabled = false;
                labelEnd.Enabled = false;
                textBoxDriver.Enabled = true;
                textBoxEnd.Enabled = false;
                textBoxStart.Enabled = false;
            }
        }

        private void checkBoxAll_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBoxAll.Checked)               //�����û�checkbox��ѡ��ı������ؼ��Ŀ�ѡ��
            {
                labelDriver.Enabled = false;
                labelStart.Enabled = false;
                labelEnd.Enabled = false;
                textBoxDriver.Enabled = false;
                textBoxEnd.Enabled = false;
                textBoxStart.Enabled = false;
                groupBox1.Enabled = false;

            }
            else
            {
                groupBox1.Enabled =true;
                radioButtonLine_CheckedChanged(sender, e);
            }

        }

        private void DriverInfo_Load(object sender, EventArgs e)
        {
            labelDriver.Enabled = false;
            textBoxDriver.Enabled = false;
        }

       

        private void dataGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DataGridView ds = sender as DataGridView;
            if (ds.CurrentRow.Cells[5].Value.ToString().Substring(0, 2) != "no")    //��ֹ�û�ɾ���Ѿ����е�˾��
            {
                MessageBox.Show("��������������˾������ɾ����Ҫɾ�����Ƚ���ж��!");
                e.Cancel = true;
            }
        }

        private void dataGridView_UserAddedRow(object sender, DataGridViewRowEventArgs e)   //����һ��isrunningĬ��ֵno
        {
            DataGridView ds = sender as DataGridView;
            ds.CurrentRow.Cells[5].Value = "no";
        }

        private void dataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show(e.Exception.Message);           //��ʾ������Ϣ
        } 

        private void dataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        { 
            Regex regExpression = new Regex(@"(^(\d{11})$)");         //�绰�����������ʽ
            Regex regExpressionID = new Regex(@"(^([a-z]\d{5})$)");   //DriverNumber ��������ʽ
            dataGridView = sender as DataGridView;
            string str = "";
            if (dataGridView.Rows.Count < e.RowIndex)
                return;

            if (e.ColumnIndex == 2)                             //�Ա���
            {
                str = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                if (str.Length == 0)
                    return;
                if(str.Substring(0,1)!="��" && str.Substring(0,1)!="Ů")
                {
                    MessageBox.Show("�������л�Ů!");
                    dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "ERROR!";
                }
            }

            if(e.ColumnIndex == 4)                                 //�绰������
            {
                str = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                if (str.Length == 0)
                    return;
                if(!regExpression.IsMatch(str)) 
                {
                    MessageBox.Show("������11λ����!");
                    dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "ERROR!";
                }
               
                
            }
            if (e.ColumnIndex == 0)                               //��ֹ������check����
            {
                str = dataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
                if (!regExpressionID.IsMatch(str))
                {
                    MessageBox.Show(@"������[a-z]\d{5}����ʽ!");
                    dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "z00000";
                }

            }
            if (e.ColumnIndex == 1)                               //��ֹname����
            {
                str = dataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
                if (str.Length>10)
                {
                    MessageBox.Show(@"������10���ַ�����!");
                    dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "00000";
                }

            }
            if (e.ColumnIndex == 3)                               //��ֹaddress�Ĵ���
            {
                str = dataGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
                if (str.Length>30)
                {
                    MessageBox.Show(@"����30���ַ���ǰ!");
                    dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "00000";
                }

            }

        }

      

       
    }
}