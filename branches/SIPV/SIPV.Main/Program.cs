
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BaseCode;
using System.Configuration;
namespace SIPV.Main
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            DB vDB = new DB();
            vDB.Servidor = System.Configuration.ConfigurationManager.AppSettings["Server"].ToString() ;//  "SQLDELTA1";
            vDB.BaseDatos = System.Configuration.ConfigurationManager.AppSettings["DataBase"].ToString();
            vDB.Compania = "";
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            mnuSIPV mvarOperaciones = new mnuSIPV(vDB);
            SIPV.Security.frmLogeo mvarLogeo = new SIPV.Security.frmLogeo(null, vDB, false);
            Application.Run(mvarLogeo);
            //SIPV.Security.frmCambioClave mvarCC = new SIPV.Security.frmCambioClave(vDB);
            //Application.Run(mvarCC);
            if (!vDB.Compania.Equals(""))
            {
                Application.Run(mvarOperaciones);
            }
        }
    }
}