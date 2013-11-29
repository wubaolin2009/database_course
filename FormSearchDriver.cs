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
        private string m_strLineNum      ="";  //要查找的线路编号
        public void SetLineNum(string str)     //设置要查找的线路编号如果为""则不查找，为了方便卸载司机
        {
            m_strLineNum = str;
            
        }
        public void SetForm(ChangeLineRun form)
        {
            m_form = form;
        }

        private void FormSearchDriver_Load(object sender, EventArgs e)
        {
            buttonOk.Enabled = false;                  //设置不能修改datagridview
            buttonReject.Enabled = false;
            dataGridView.ReadOnly = true;
            dataGridView.AllowUserToAddRows = false;
            dataGridView.CellDoubleClick += new DataGridViewCellEventHandler(this.Confirm_LineNum);  //增加事件委托

            if (m_strLineNum != "")           //查找和LineNum相关的司机信息，为了方便卸载司机
             {
                 try
                 {
                     m_dataset.CnOpen();
                     m_dataset.SetCmd(CMyDataSet.WHICHCMD.SELECT, "select DriverInfo.* from DriverInfo INNER JOIN LineDriver ON LineDriver.DriverNum = DriverInfo.DriverNum where LineDriver.LineNum = '" + m_strLineNum + "'", CommandType.Text);  //执行命令
                     m_dataset.MakeReadyForAdapter(true);
                     m_dataset.Fill("Info");
                     DataTable dtInfo = m_dataset.GetTable("Info");
                     if (dtInfo.Rows.Count == 0)
                     {
                         MessageBox.Show("没有绑定在线路为" + m_strLineNum + "的汽车结果!");
                     }
                     else
                     {
                         MessageBox.Show("绑定在线路为" + m_strLineNum + "的汽车共有"+dtInfo.Rows.Count.ToString());

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
                        m_form.SetSetupLine2(true);    //写到调用此窗口的窗口 运行代表用户的意图是安装
                    }
                    else                               //用户意图是卸载
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

