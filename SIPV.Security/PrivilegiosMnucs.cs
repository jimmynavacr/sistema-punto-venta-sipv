using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using BaseCode;
using System.Windows.Forms; 
namespace SIPV.Security
{
    public class PrivilegiosMnu
    {
        private DB vDB;
        private ImnuSecurity frmMenu;
        private string mSistema = "";
        public PrivilegiosMnu(ImnuSecurity frmMnu,DB vDB)
        {
            this.frmMenu = frmMnu;
            this.vDB = vDB;
            mSistema = System.Configuration.ConfigurationManager.AppSettings["Sistema"].ToString(); ;
        }
        private void OcultarMiembrosSubMnu(System.Windows.Forms.ToolStripMenuItem Mnu)
        {
            int i = 0;
            for (i = 0; i <= Mnu.DropDownItems.Count - 1; i++)
            {
                Mnu.DropDownItems[i].Visible = false;
                if (Mnu.DropDownItems[i].GetType().Equals(typeof(ToolStripMenuItem)))
                {
                    OcultarMiembrosSubMnu((ToolStripMenuItem)Mnu.DropDownItems[i]);
                }
            }
        }
        private void OcultarMiembrosMnu(System.Windows.Forms.MenuStrip Mnu)
        {
            int i = 0;
            for (i = 0; i <= Mnu.Items.Count - 1; i++)
            {
                Mnu.Items[i].Visible = false;
                Mnu.Items[i].Tag = "A";
                OcultarMiembrosSubMnu((ToolStripMenuItem)Mnu.Items[i]);
            }
        }
        private void MostrarMiembroSubMnu(System.Windows.Forms.ToolStripMenuItem Mnu, string Menu)
        {
            int i = 0;
            for (i = 0; i <= Mnu.DropDownItems.Count - 1; i++)
            {
                if (Mnu.DropDownItems[i].Text.ToUpper().Equals(Menu))
                {
                    Mnu.DropDownItems[i].Visible = true;
                    break; 
                }
                MostrarMiembroSubMnu((ToolStripMenuItem)Mnu.DropDownItems[i], Menu);
            }
        }
        private void MostrarMiembroMnu(System.Windows.Forms.MenuStrip Mnu, string Menu)
        {
            int i = 0;
            for (i = 0; i <= Mnu.Items.Count - 1; i++)
            {
                if (Mnu.Items[i].Text.ToUpper().Equals(Menu))
                {
                    Mnu.Items[i].Visible = true;
                    Mnu.Items[i].Tag = "A";
                    break; 
                }
                MostrarMiembroSubMnu((ToolStripMenuItem)Mnu.Items[i], Menu);
            }
        }
        public void OcultarTodo()
        {
            OcultarMiembrosMnu(frmMenu.mnuPrincipal());
        }
        private void MostrarMenu(string Menu)
        {
            MostrarMiembroMnu(frmMenu.mnuPrincipal(), Menu);
        }
        public  void ChequearOpcionesMenu()
        {
            DataTable mDataTable = default(DataTable);
            int i = 0;
            mDataTable = vDB.ConsultarDataTable("SELECT * FROM MENU_GRUPO WHERE MNU_GRUPO='" + vDB.Grupo + "' AND SISTEMA='" + mSistema + "'");
            if ((mDataTable != null))
            {
                for (i = 0; i <= mDataTable.Rows.Count - 1; i++)
                {
                    MostrarMenu(mDataTable.Rows[i]["MNU_MENU"].ToString().ToUpper());
                }
                mDataTable.Dispose();
                mDataTable = null;
                GC.Collect();
            }

        }
    }
}

