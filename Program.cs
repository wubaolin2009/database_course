using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace da1
{
    static class Program
    {
       
      
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            FormMain frmMain = new FormMain();
            frmMain.StartPosition = FormStartPosition.CenterScreen;
            Application.Run(frmMain);
       
        }
    }
}