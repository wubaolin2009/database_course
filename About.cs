using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace da1
{
    public partial class About : Form
    {
        private string m_strUser;                //用户名称
        public void SetUser(string user)         //设置用户名称
        {
            m_strUser = user;
        }
        public About()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void About_Load(object sender, EventArgs e)
        {
            this.Text = m_strUser;         //窗口标题为用户名称
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}