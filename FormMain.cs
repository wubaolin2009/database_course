using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.InteropServices;

namespace da1
{
   
    public partial class FormMain : Form
    {
       
       

        private SqlConnection m_cn;  //���ݿ�����
        private RIGHT m_right;
        private string m_userName;
  
        public FormMain()
        {
            InitializeComponent();
        }

        public void SetUserName(string username)
        {
            m_userName = username;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.skinEngine.SkinFile = UserStyle.GetFileName();
            
            

           string cnstr = "DATABASE = CoachMS;"
                       + "SERVER = localhost;"
                        + "Integrated Security=True";
           // string cnstr = @"Data Source=localhost;AttachDbFilename=c:\1.mdf;Integrated Security= True;User Instance=false";

            m_cn = new SqlConnection(cnstr);     //��ʼ�����ݿ�����
            this.Hide();
            m_right = RIGHT.INVAILID;
            Land LandForm = new Land();
            LandForm.SetData(m_cn,this);
            LandForm.ShowDialog();
            if (m_right == RIGHT.INVAILID)
                this.Close();
           // SkinStart("c:\\onion.urf", 0, "", 1, 0, 0); 
            this.Text = "��ǰ�û���" + m_userName;
            if (m_right != RIGHT.ADMIN && m_right != RIGHT.MAINTAIN)������������//����Ȩ�������û�
            {
                menuItemBusM.Enabled = false;
                menuItemLineM.Enabled = false;
                menuItemDriverM.Enabled = false;
                buttonMangerLine.Enabled = false;
                buttonChangeLineStatus.Enabled = false;
                buttonBusInfo.Enabled = false;
                buttonDriverInfo.Enabled = false;

            }
                     
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SellTicket formSellTicket = new SellTicket();       //��Ʊ����
            formSellTicket.SetData(m_cn, m_right, m_userName);
            formSellTicket.StartPosition = FormStartPosition.CenterParent;
          
            
            formSellTicket.ShowDialog();
        }

        public void SetRight(da1.RIGHT right)
        {
            this.m_right = right;                              //����Ȩ��
        }

       
        private void �۲�ƱToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button2_Click(sender, e);                          //��button������һ���򿪲˵�
        }

     

        private void menuItem3_Click(object sender, EventArgs e)
        {
            SetupLine stLine = new SetupLine();              //��װ��·����
            stLine.StartPosition = FormStartPosition.CenterParent;
            stLine.SetData(m_cn, m_right, m_userName);
            stLine.ShowDialog();
        }

         

      

        private void menuItem5_Click(object sender, EventArgs e)
        {
            button2_Click(sender, e);                     //��Ʊ����
        } 

        private void menuItem16_Click(object sender, EventArgs e)
        {
            About formAbout = new About();                //about�Ի���
            formAbout.StartPosition = FormStartPosition.CenterParent;
            formAbout.SetUser(m_userName);
            formAbout.ShowDialog();
        }

        private void menuItem12_Click(object sender, EventArgs e)
        {
            ChangePassword formChangePwd = new ChangePassword();   //�ı����봰��
            formChangePwd.SetData(m_cn, m_right, m_userName);
            formChangePwd.StartPosition = FormStartPosition.CenterParent;
           

            formChangePwd.ShowDialog();
        }

        private void menuItem13_Click(object sender, EventArgs e)
        {
            UserInfo formUserInfo = new UserInfo();              //�û���Ϣ����
            formUserInfo.StartPosition = FormStartPosition.CenterParent;
            formUserInfo.SetData(m_cn,m_right,m_userName);
            formUserInfo.ShowDialog();
        }

        private void menuItem14_Click(object sender, EventArgs e)
        {
            RegisterUser formRegisterUser = new RegisterUser();    //ע���û�����
            formRegisterUser.StartPosition = FormStartPosition.CenterParent;
            formRegisterUser.SetData(m_cn,m_right,m_userName);
            formRegisterUser.ShowDialog();
        }

     

      

        private void menuItemLogOut_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "ȷ����?", "ȷ�ϴ���", MessageBoxButtons.OKCancel) == DialogResult.OK)  //ע��
                Form1_Load(sender, e);
        }

          
        private void menuItemDiamondBlue_Click(object sender, EventArgs e)
        {
            da1.UserStyle.SetFileName(UserStyle.STYLE.DIAMOND_BLUE);             //ͨ����ȡ�����ļ������ı�����
            skinEngine.SkinFile = UserStyle.GetFileName();
        }

        private void menuItemDiamondGreen_Click(object sender, EventArgs e)
        {
            da1.UserStyle.SetFileName(UserStyle.STYLE.DIAMOND_GREEN);
            skinEngine.SkinFile = UserStyle.GetFileName();
        }

        private void menuItemSprotsCyan_Click(object sender, EventArgs e)
        {
            da1.UserStyle.SetFileName(UserStyle.STYLE.SPORTS_CYAN);
            skinEngine.SkinFile = UserStyle.GetFileName();
        }

        private void menuItemSporsGreen_Click(object sender, EventArgs e)
        {
            da1.UserStyle.SetFileName(UserStyle.STYLE.SPORTS_GREEN);
            skinEngine.SkinFile = UserStyle.GetFileName();
        }

        private void menuItemSportsOrange_Click(object sender, EventArgs e)
        {
            da1.UserStyle.SetFileName(UserStyle.STYLE.SPORTS_ORANGE);
            skinEngine.SkinFile = UserStyle.GetFileName();
        }

        private void menuItemSportsBlack_Click(object sender, EventArgs e)
        {
            da1.UserStyle.SetFileName(UserStyle.STYLE.SPORTS_BLACK);
            skinEngine.SkinFile = UserStyle.GetFileName();
        }

       
      
        private void menuItemMacOS_Click(object sender, EventArgs e)
        {
            da1.UserStyle.SetFileName(UserStyle.STYLE.MACOS);
            skinEngine.SkinFile = UserStyle.GetFileName();
        }

        private void menuItemMSN_Click(object sender, EventArgs e)
        {
            da1.UserStyle.SetFileName(UserStyle.STYLE.MSN);
            skinEngine.SkinFile = UserStyle.GetFileName();
        }

        private void menuItemMidSummer_Click(object sender, EventArgs e)
        {
            da1.UserStyle.SetFileName(UserStyle.STYLE.MIDSUMMER);
            skinEngine.SkinFile = UserStyle.GetFileName();
        }

        private void menuItemVista_Click(object sender, EventArgs e)
        {
            da1.UserStyle.SetFileName(UserStyle.STYLE.VISTA);
            skinEngine.SkinFile = UserStyle.GetFileName();

        }

        private void menuItemSportBlue_Click(object sender, EventArgs e)
        {
            da1.UserStyle.SetFileName(UserStyle.STYLE.SPORTS_BLUE);
            skinEngine.SkinFile = UserStyle.GetFileName();

        }

        private void menuItemCalm_Click(object sender, EventArgs e)
        {
            da1.UserStyle.SetFileName(UserStyle.STYLE.CALMNESS);
            skinEngine.SkinFile = UserStyle.GetFileName();
        }

        private void menuItem13_Click_1(object sender, EventArgs e)
        {
            LineInfo lineinfo = new LineInfo();                                  //��·��Ϣ����
            lineinfo.SetData(m_cn, m_right, m_userName);
            lineinfo.StartPosition = FormStartPosition.CenterParent;
            lineinfo.ShowDialog();
        }

        private void menuItemDriverInfo_Click(object sender, EventArgs e)
        {
            DriverInfo driver = new DriverInfo();                            //˾����Ϣ����
            driver.SetData(m_cn, m_right, m_userName);
            driver.StartPosition = FormStartPosition.CenterParent;
            driver.ShowDialog();
        }

        private void menuItem10_Click(object sender, EventArgs e)
        {
            BusInfo businfo = new BusInfo();                            //������Ϣ����
            businfo.SetData(m_cn, m_right, m_userName);
            businfo.StartPosition = FormStartPosition.CenterParent;
            businfo.ShowDialog();
        }

        private void menuItem2_Click(object sender, EventArgs e)
        {
            LineUnSet lineunset = new LineUnSet();                        //ж����·����
            lineunset.SetData(m_cn, m_right, m_userName);
            lineunset.StartPosition = FormStartPosition.CenterParent;
            lineunset.ShowDialog();
        }

        private void menuItem17_Click(object sender, EventArgs e)
        {
            ChangeLineRun formChange = new ChangeLineRun();               //�ı���·����״̬�Ĵ���
            formChange.StartPosition = FormStartPosition.CenterParent;
            formChange.SetData(m_cn, m_right, m_userName);
            formChange.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            menuItem14_Click(sender, e);                //ע���û�
        }

        private void button3_Click(object sender, EventArgs e)
        {
            menuItem13_Click(sender, e);          //�û���ѯ
        }

        private void buttonMangerLine_Click(object sender, EventArgs e)
        {
            menuItem13_Click_1(sender, e);           //��·����
        }

        private void buttonChangeLineStatus_Click(object sender, EventArgs e)
        {
            menuItem17_Click(sender, e);         //��·״̬����
        }

        private void button6_Click(object sender, EventArgs e)
        {
            menuItemDriverInfo_Click(sender, e);  //˾����Ϣ
        }

        private void buttonBusInfo_Click(object sender, EventArgs e)
        {
            menuItem10_Click(sender, e);   //������Ϣ
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

         

     
    }
      
    public class CMyDataBase                                        //ÿ��������ͬ�����Ĺ�ͬ���ݵķ�װ����
    {
        protected SqlConnection m_cn;              //���ݿ�����
      
        protected SqlCommand m_cmd;
        protected RIGHT m_right;                //Ȩ��
        protected string m_userName;            //�û��� 
        protected CMyDataBase(SqlConnection cn ,RIGHT right,string username)  
        {
            m_cn = cn;
            m_right = right;
            m_userName = username;
            m_cmd = new SqlCommand("", m_cn);
        }
       

        public SqlConnection GetCN()   //������ݿ����Ӷ���
        {
            return m_cn;

        }
        public RIGHT GetRight()
        {
            return m_right;          //���Ȩ��

        }
        public string GetUserName()
        {
            return m_userName;
        }
        public void CnOpen()         //������
        {
            try
            {
                m_cn.Open();
            }
            catch (System.Exception eee)
            {
                MessageBox.Show(eee.Message);
            }
        }
        public void CnClose()
        {
            m_cn.Close();
        }


      

    }

    public class CMyData:CMyDataBase
    {
         public SqlCommand SetCmd(string cmd,CommandType cmdType)         //��������
        {
           
            m_cmd.CommandText = cmd;
            m_cmd.CommandType = cmdType;
            return m_cmd;
        }
        public void RemoveParametres()                    //�Ƴ�����
        {
            m_cmd.Parameters.Clear();
        }
        public void AddParametres(string name,SqlDbType type,int len,ParameterDirection pDirection) //���Ӳ���
        {
            SqlParameter sp_new = new SqlParameter(name, type, len);
            sp_new.Direction = pDirection;
            m_cmd.Parameters.Add(sp_new);
        }

        public void SetParamValue(string name,object value)  //���ò�����ֵ
        {
            m_cmd.Parameters[name].Value = value;
        }

        public void SetParamValue(int index, object value)  //���ò�����ֵ
        {
            m_cmd.Parameters[index].Value = value;
        }
        public CMyData(SqlConnection cn ,RIGHT right,string username):base(cn,right,username){}
   
        //���������Լ���ô�Խ������
        public int ExecuteNonQuery()
        {
            
            return m_cmd.ExecuteNonQuery();
                     
        }
        public SqlDataReader ExecuteReader()             //����datareader
        {
            return m_cmd.ExecuteReader();
        }
       
        public object GetParamValue(string strParamName)       //���ĳһ������ֵ
        {
            if (m_cmd.Parameters.Contains(strParamName))
                return m_cmd.Parameters[strParamName].Value;
            else
                throw new Exception("����" + strParamName + "������!");
        }

    }


#region CMyDataSet
    public class CMyDataSet:CMyDataBase                //ADO.NET �����ݴ�������װ
    {
        public enum WHICHCMD {SELECT,DELETE,INSERT,UPDATE};   //��ͬ����������
        protected DataSet m_ds;                                     //���ݼ�
        protected SqlDataAdapter m_da;                          //����������
        protected SqlCommand cmd_update;                       //��������������
        protected SqlCommand cmd_insert;
        protected SqlCommand cmd_delete;
        protected SqlCommandBuilder m_sCB;                              


        public void ClearAllTable()          //ɾ�����б�
        {
            m_ds.Tables.Clear();
        }
        public CMyDataSet(SqlConnection cn, RIGHT right, string username) : base(cn, right, username)
        { 
            m_ds = new DataSet();
            m_da = new SqlDataAdapter("",m_cn);
            cmd_update = new SqlCommand("",m_cn);
            cmd_insert = new SqlCommand("",m_cn);
            cmd_delete = new SqlCommand ("",m_cn);
         

        }
        public void MakeReadyForAdapter(bool bNeedBuilder)   //��ʼ�����������ĸ����� trueΪ�Զ�����UpdataDeleteInsert����
        {
           
            if(m_cmd.CommandText == "")
                throw  new Exception("select����û�г�ʼ��!");
            m_da.SelectCommand = m_cmd;
            if(cmd_delete.CommandText != "")
                m_da.DeleteCommand = cmd_delete;
            if(cmd_insert.CommandText != "")
                m_da.DeleteCommand = cmd_insert;
            if(cmd_update.CommandText != "")
                m_da.DeleteCommand = cmd_update;  
            if(cmd_update.CommandText == "" && cmd_insert.CommandText == "" && cmd_delete.CommandText == "" && bNeedBuilder)
                m_sCB = new SqlCommandBuilder(m_da);
        }
        public void SetCmd(WHICHCMD cmd,string strCmd,CommandType type)  //��������Ϊtype �������������cmd���͵�cmd��
        {
            switch(cmd)
            {
                case WHICHCMD.DELETE:
                {
                    cmd_delete.CommandText = strCmd;
                    cmd_delete.CommandType = type;
                    break;
                    
                }
                case WHICHCMD.UPDATE:
                {
                    cmd_update.CommandText = strCmd;
                    cmd_update.CommandType = type;
                    break;

                }
                case WHICHCMD.SELECT:
                {
                    m_cmd.CommandText = strCmd;
                    m_cmd.CommandType = type;
                    break;

                }
                case WHICHCMD.INSERT:
                {
                    cmd_insert.CommandText = strCmd;
                    cmd_insert.CommandType = type;
                    break;
                }

            }
        }
        public void AddParams(WHICHCMD cmd,string name,SqlDbType type,int len,string strSourceColumn)  //�ƶ�Ϊĳ���������Ӳ���
        {
            SqlParameter sp = new SqlParameter(name,type,len);
            sp.SourceColumn = strSourceColumn;
            sp.SourceVersion =DataRowVersion.Current;

             switch(cmd)
            {
                case WHICHCMD.DELETE:
                {
                    cmd_delete.Parameters.Add(sp);
                    break;
                    
                }
                case WHICHCMD.UPDATE:
                {
                   cmd_update.Parameters.Add(sp);
                    break;

                }
                case WHICHCMD.SELECT:
                {
                   m_cmd.Parameters.Add(sp);
                    break;

                }
                case WHICHCMD.INSERT:
                {
                   cmd_insert.Parameters.Add(sp);
                    break;
               }

            }

        }


        public void ClearParams(WHICHCMD cmd)                //ɾ����������ĳһ��������в���
        { 
                switch(cmd)
            {
                case WHICHCMD.DELETE:
                {
                    cmd_delete.Parameters.Clear();
                    break;
                    
                }
                case WHICHCMD.UPDATE:
                {
                   cmd_update.Parameters.Clear();
                    break;

                }
                case WHICHCMD.SELECT:
                {
                   m_cmd.Parameters.Clear();
                    break;

                }
                case WHICHCMD.INSERT:
                {
                   cmd_insert.Parameters.Clear();
                    break;
               }

            }

        }

        public void Update(string strTableName)         //��������Դ
        {
            if (m_ds.HasChanges())
            {

                if (MessageBox.Show("�Ƿ񱣴��������޸ģ�", "ȷ��", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    m_da.Update(m_ds.Tables[strTableName]);
                    MessageBox.Show("�ɹ�");
                }
            }
        }

        public DataTable GetTable(string name)
        {
            return m_ds.Tables[name];
        }

        public void Fill(string strTableName)                    //fill��ĳ�ű���
        {
            if (m_ds.Tables.Contains(strTableName))
                m_ds.Tables[strTableName].Clear();
           
            if (m_da.SelectCommand.CommandText == "")
                throw new Exception("CommandTextû�г�ʼ��!");
            m_da.Fill(m_ds,strTableName);
          
        }

        public DataSet GetDS()                //���datasetΪ����������
        {
            return m_ds;
        }


    }
#endregion

    public class UserStyle                  //ȫ�ֱ���������ǵ�ǰ���ڵ���������
    {
        public enum STYLE          //��������
        {
            VISTA,DIAMOND_BLUE, DIAMOND_GREEN, MACOS, SPORTS_CYAN, SPORTS_GREEN, SPORTS_ORANGE, SPORTS_BLACK, SPORTS_BLUE, MIDSUMMER, MSN, CALMNESS
        };
       private static string m_strFileName = Application.StartupPath + @"\theme\DiamondBlue.ssk";
       public static void SetFileName(STYLE style)  //���õ�ǰ�����ļ�Ϊstyle ��Ӧ��
        {
            switch(style)
            {
                case STYLE.VISTA:
                    m_strFileName = Application.StartupPath + @"\theme\vista2_color1.ssk";
                    break;
                case STYLE.DIAMOND_BLUE:
                    m_strFileName = Application.StartupPath + @"\theme\DiamondBlue.ssk";
                    break;
                case STYLE.DIAMOND_GREEN:
                    m_strFileName = Application.StartupPath + @"\theme\DiamondGreen.ssk";
                    break;
                case STYLE.MACOS:
                    m_strFileName = Application.StartupPath + @"\theme\MacOs.ssk";
                    break;
                case STYLE.SPORTS_CYAN:
                    m_strFileName = Application.StartupPath + @"\theme\sportscyan.ssk";
                    break;
                case STYLE.SPORTS_GREEN:
                    m_strFileName = Application.StartupPath + @"\theme\sportsgreen.ssk";
                    break;
                case STYLE.SPORTS_ORANGE:
                    m_strFileName = Application.StartupPath + @"\theme\sportsorange.ssk";
                    break;
                case STYLE.SPORTS_BLACK:
                    m_strFileName = Application.StartupPath + @"\theme\sportsblack.ssk";
                    break;
                case STYLE.SPORTS_BLUE:
                    m_strFileName = Application.StartupPath + @"\theme\sportsblue.ssk";
                    break;
                case STYLE.MIDSUMMER:
                    m_strFileName = Application.StartupPath + @"\theme\midsummer.ssk";
                    break;
                case STYLE.MSN:
                    m_strFileName = Application.StartupPath + @"\theme\msn.ssk";
                    break;
                case STYLE.CALMNESS:
                    m_strFileName = Application.StartupPath + @"\theme\calmness.ssk";
                    break;
         
           }

        }

        public static string GetFileName()   //��ȡ��ǰ�������ļ���
        {
            return m_strFileName;
        }
    }
}