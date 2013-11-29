using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace da1
{
    public partial class FormSearchLine : da1.LineInfo
    {
        private Form m_form;
        private bool m_bSetup = true;
        public void SetSetupLine(bool bSetup)
        {
            m_bSetup = bSetup;
        }
        public FormSearchLine()
        {
            InitializeComponent();
        }
        public void SetForm(Form form)
        {
            m_form = form;
        }

        private void Formtest_Load(object sender, EventArgs e)
        {
            groupBox1.Enabled = false;          //设置当前窗口的默认状态
            
            radioButtonRun.Select();
            dataGridView.ReadOnly = true;
            dataGridView.AllowUserToAddRows = false;
            buttonSa.Enabled = false;
            buttonConfirm.Enabled = false;
            buttonReject.Enabled = false;
            dataGridView.CellDoubleClick += new DataGridViewCellEventHandler(this.Confirm_LineNum);  //增加事件委托

            

        }
        private void Confirm_LineNum(object sender,DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView dv = sender as DataGridView;
                if (e.RowIndex == -1)
                    return;

                else
                {
                    if (m_form is ChangeLineRun)
                    {

                        (m_form as ChangeLineRun).SetStringLine1(dv.Rows[e.RowIndex].Cells[0].Value.ToString());  //返回主键的值
                    }
                    else if (m_form is BusInfo)
                    {

                        (m_form as BusInfo).SetStringLine(dv.Rows[e.RowIndex].Cells[0].Value.ToString());     //返回主键的值到原窗口
                    }
                 
                }
                this.Close();
            }
            catch(Exception eee)
            {
                MessageBox.Show(eee.Message);
            }

        }



       
    }
}

