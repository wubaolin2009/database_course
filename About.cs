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
        private string m_strUser;                //�û�����
        public void SetUser(string user)         //�����û�����
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
            this.Text = m_strUser;         //���ڱ���Ϊ�û�����
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}