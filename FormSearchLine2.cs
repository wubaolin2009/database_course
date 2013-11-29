using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace da1
{
    public partial class FormSearchLine2 : da1.LineInfo
    {
        public FormSearchLine2()
        {
            InitializeComponent();
        }
        private ChangeLineRun m_form;
        private bool m_bSetup = true;
        public void SetSetupLine(bool bSetup)
        {
            m_bSetup = bSetup;
        }

        public void SetForm(ChangeLineRun form)
        {
            m_form = form;
        }

        private void FormSearchLine2_Load(object sender, EventArgs e)
        {
            groupBox1.Enabled = false;   //���ô��ڳ�ʼ��Ӧ�е�״̬

            radioButtonRun.Select();
            dataGridView.ReadOnly = true;
            dataGridView.AllowUserToAddRows = false;
            buttonSa.Enabled = false;
            buttonConfirm.Enabled = false;
            buttonReject.Enabled = false;
            dataGridView.CellDoubleClick += new DataGridViewCellEventHandler(this.Confirm_LineNum); //˫��datagridview���¼�
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
                    m_form.SetStringLine2(dv.Rows[e.RowIndex].Cells[0].Value.ToString());  //����������ֵ

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

