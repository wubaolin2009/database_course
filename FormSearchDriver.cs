using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace da1
{
    public partial class FormSearchDriver : da1.DriverInfo
    {
        public FormSearchDriver()
        {
            InitializeComponent();
        }
        private ChangeLineRun m_form;
        private string m_strLineNum      ="";  //Ҫ���ҵ���·���
        public void SetLineNum(string str)     //����Ҫ���ҵ���·������Ϊ""�򲻲��ң�Ϊ�˷���ж��˾��
        {
            m_strLineNum = str;
            
        }
        public void SetForm(ChangeLineRun form)
        {
            m_form = form;
        }

        private void FormSearchDriver_Load(object sender, EventArgs e)
        {
            buttonOk.Enabled = false;                  //���ò����޸�datagridview
            buttonReject.Enabled = false;
            dataGridView.ReadOnly = true;
            dataGridView.AllowUserToAddRows = false;
            dataGridView.CellDoubleClick += new DataGridViewCellEventHandler(this.Confirm_LineNum);  //�����¼�ί��

            if (m_strLineNum != "")           //���Һ�LineNum��ص�˾����Ϣ��Ϊ�˷���ж��˾��
             {
                 try
                 {
                     m_dataset.CnOpen();
                     m_dataset.SetCmd(CMyDataSet.WHICHCMD.SELECT, "select DriverInfo.* from DriverInfo INNER JOIN LineDriver ON LineDriver.DriverNum = DriverInfo.DriverNum where LineDriver.LineNum = '" + m_strLineNum + "'", CommandType.Text);  //ִ������
                     m_dataset.MakeReadyForAdapter(true);
                     m_dataset.Fill("Info");
                     DataTable dtInfo = m_dataset.GetTable("Info");
                     if (dtInfo.Rows.Count == 0)
                     {
                         MessageBox.Show("û�а�����·Ϊ" + m_strLineNum + "���������!");
                     }
                     else
                     {
                         MessageBox.Show("������·Ϊ" + m_strLineNum + "����������"+dtInfo.Rows.Count.ToString());

                     }
                     dataGridView.DataSource = dtInfo;
                 }
                 catch (System.Exception eee)
                 {
                     MessageBox.Show(eee.Message);
                 }
                 finally
                 {
                     m_dataset.CnClose();
                 }

            }
        }

        private void Confirm_LineNum(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView dv = sender as DataGridView;
                if (e.RowIndex == -1)
                    return;

                else
                {
                    if (dv.Rows[e.RowIndex].Cells[5].Value.ToString().Substring(0, 2) == "no")
                    {
                        m_form.SetSetupLine2(true);    //д�����ô˴��ڵĴ��� ���д����û�����ͼ�ǰ�װ
                    }
                    else                               //�û���ͼ��ж��
                         m_form.SetSetupLine2(false);
                    m_form.SetStringDriver(dv.Rows[e.RowIndex].Cells[0].Value.ToString());
                }
                this.Close();
            }
            catch (Exception eee)
            {
                MessageBox.Show(eee.Message);
            }

        }
    }
}

