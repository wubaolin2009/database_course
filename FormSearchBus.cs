using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace da1
{
    public partial class FormSearchBus : da1.BusInfo
    {
        public FormSearchBus()
        {
            InitializeComponent();
        }
        private ChangeLineRun m_form;    //打开这个窗口的原窗口
        private string m_strLineNum = "";  //要查找的线路编号
        public void SetLineNum(string str)     //设置要查找的线路编号如果为""则不查找，为了方便卸载汽车
        {
            m_strLineNum = str;

        }
        public void SetForm(ChangeLineRun form)
        {
            m_form = form;
        }


        private void FormSearchBus_Load(object sender, EventArgs e)
        {
            dataGridView.ReadOnly = true;         //不能修改数据
            dataGridView.AllowUserToAddRows = false;
            buttonOk.Enabled = false;
            buttonReject.Enabled = false;
            dataGridView.CellDoubleClick += new DataGridViewCellEventHandler(this.Confirm_LineNum);  //增加委托(事件处理)
            // base.BusInfo_Load(sender,e);
            if (m_strLineNum != "")           //查找和LineNum相关的司机信息，为了方便卸载司机
            {
                try
                {
                    m_dataset.CnOpen();
                    m_dataset.SetCmd(CMyDataSet.WHICHCMD.SELECT, "select BusInfo.* from BusInfo INNER JOIN LineNumberPrice ON LineNumberPrice.BusID = BusInfo.BusID where LineNumberPrice.LineNum = '" + m_strLineNum + "'", CommandType.Text);  //执行命令
                    m_dataset.MakeReadyForAdapter(true);
                    m_dataset.Fill("Info");
                    DataTable dtInfo = m_dataset.GetTable("Info");
                    if (dtInfo.Rows.Count == 0)
                    {
                        MessageBox.Show("没有绑定在线路为" + m_strLineNum + "的司机结果!");
                    }
                    else
                    {
                        MessageBox.Show("绑定在线路为" + m_strLineNum + "的汽车共有" + dtInfo.Rows.Count.ToString());

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
                    if (dv.Rows[e.RowIndex].Cells[5].Value.ToString().Substring(0, 2) == "no")  //不运行代表要运行
                    {
                        m_form.SetSetupLine(true);        //结果写到以前的窗口
                    }
                    else        //运行代表要卸载
                        m_form.SetSetupLine(false);
                    m_form.SetStringBus1(dv.Rows[e.RowIndex].Cells[0].Value.ToString());
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

