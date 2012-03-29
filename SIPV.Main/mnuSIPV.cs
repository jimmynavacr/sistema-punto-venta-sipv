using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BaseCode;
using System.Reflection;
using System.Security.Permissions;
using Microsoft.Win32;
using SIPV.Security; 
namespace SIPV.Main
{
    public partial class mnuSIPV : Form, SIPV.Security.ImnuSecurity
    {
        private BaseCode.DB vDB;

        public mnuSIPV()
        {
            
        }

        public mnuSIPV(BaseCode.DB vDB)
        {
            InitializeComponent();
            this.vDB = vDB;
        }

        private void mnuMuelle_Load(object sender, EventArgs e)
        {

            if (!vDB.Grupo.Equals("PRG"))
            {
                SIPV.Security.PrivilegiosMnu PrivilegiosMnu = new SIPV.Security.PrivilegiosMnu(this, vDB);
                PrivilegiosMnu.OcultarTodo();
                PrivilegiosMnu.ChequearOpcionesMenu();
            }
            LbUsuario.Text = vDB.Usuario;
            LbGrupo.Text = vDB.Grupo;
            LbCompania.Text = vDB.Compania;
            string _path =Application.StartupPath + "\\Background.png";
            try
            {
                Utility.Change_BackgroundImage(Application.StartupPath + "\\Background.png", this);
                
            }
            catch { }
            
            CargarToolBars();
            outlookBar1.SelectedButton = outlookBar1.Buttons[0];
            outlookBar1.Refresh();
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        public IWin32Window mOwner()
        {
            return this;
        }
        #region Persistencia Estado Barra LAteral
   
        //A=Auto-Hide
        //H=Oculto
        //V=Visible
        private void EscribirEstadoBarra(string Estado)
        {
            RegistryKey registryAccess = Registry.CurrentUser;
            RegistryKey registrySoftware = registryAccess.OpenSubKey("Software", true);
            if (registrySoftware != null)
            {
                RegistryKey registrySIPV = registrySoftware.OpenSubKey("SIPV", true);
                if (registrySIPV == null)
                {
                    registrySoftware.CreateSubKey("SIPV");
                    registrySIPV = registryAccess.OpenSubKey("SIPV", true);
                }
                registrySIPV.SetValue("Estado", Estado, RegistryValueKind.String);
            }
        }
        private string GetEstadoBarraLateral()
        {
            string Valor = "V";
            try
            {
                RegistryKey registryAccess = Registry.CurrentUser;
                if (registryAccess != null)
                {
                    RegistryKey registrySoftware = registryAccess.OpenSubKey("Software", true);
                    if (registrySoftware != null)
                    {
                        RegistryKey registrySIPV = registrySoftware.OpenSubKey("SIPV", true);
                        if (registrySIPV == null)
                        {
                            EscribirEstadoBarra(Valor);
                            registrySoftware.CreateSubKey("SIPV");
                            registrySIPV = registrySoftware.OpenSubKey("SIPV", true);
                        }
                        Valor = registrySIPV.GetValue("Estado").ToString();
                    }
                }
            }
            catch { }
            return Valor;
        }

        #endregion

 
        #region Gestion MDI
        private void TreeView_DoubleClick(object sender, EventArgs e)
        {
            if (((TreeView)sender).SelectedNode != null)
            {
                if (((TreeView)sender).SelectedNode.GetType().Equals(typeof(BaseCode.NodeEvent)))
                {
                    BaseCode.NodeEvent mNode = (BaseCode.NodeEvent)((TreeView)sender).SelectedNode;
                    if (mNode != null)
                    {
                        if (!mNode.Ejecutar(sender, e))
                        {
                             
                        }
                    }
                }
            }
        }
        private void CargarToolBars()
        {

            Utility.PoblarTreeViewBasdoEnMenu(this, mnuMantenimientos, TvMantenimientos, false, null, vDB.Grupo, -1);
            Utility.PoblarTreeViewBasdoEnMenu(this, mnuTransacciones, TvTransacciones, false, null, vDB.Grupo, -1);
            Utility.PoblarTreeViewBasdoEnMenu(this, mnuProcesos, TvProcesos, false, null, vDB.Grupo, -1);
            Utility.PoblarTreeViewBasdoEnMenu(this, mnuConsultas, TvConsultas, false, null, vDB.Grupo, -1);
            Utility.PoblarTreeViewBasdoEnMenu(this, mnuReportes, TvReportes, false, null, vDB.Grupo, -1);
            Utility.PoblarTreeViewBasdoEnMenu(this, mnuUtilitarios, TvUtilitarios, false, null, vDB.Grupo, -1);
            Utility.PoblarTreeViewBasdoEnMenu(this, mnuAyuda, TvAyuda, false, null, vDB.Grupo, -1);
            Ocultar_ToolBars();
            TvMantenimientos.Visible = true;
        }

        public System.Windows.Forms.MenuStrip mnuPrincipal()
        {
            return mnuPrincipal_;
        }


        


        private void Ocultar_ToolBars()
        {
            TvMantenimientos.Visible = false;
            TvTransacciones.Visible = false; 
            TvProcesos.Visible = false;
            TvConsultas.Visible = false;
            TvReportes.Visible = false;            
            TvUtilitarios.Visible = false;
            TvAyuda.Visible = false;            
        }
        private void outlookBar1_Click(object sender, BaseCode.OutlookBar.ButtonClickEventArgs e)
        {
            int idx = outlookBar1.Buttons.IndexOf(e.SelectedButton);
            Ocultar_ToolBars();
            switch (idx)
            {
                case 0: // Mantenimientos
                    TvMantenimientos.Visible = true;
                    break;
                case 1: // Transacciones
                    TvTransacciones.Visible = true;
                    break;
                case 2: // Transacciones
                    TvProcesos.Visible = true;
                    break;
                case 3: // Reportes
                    TvReportes.Visible = true;
                    break;
                case 4: // Ayuda
                    TvConsultas.Visible = true;
                    break;
                case 5: // Utilitarios
                    TvUtilitarios.Visible = true;
                    break;
                case 6: // Ayuda
                    TvAyuda.Visible = true;
                    break;
                default:

                    break;

            }
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            panel1.Visible = !panel1.Visible;

    
        }
        bool allowResize = false;
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (allowResize)
            {
                //this.panel1.Width = pictureBox1.Left + e.X;
                try
                {
                    panel1.Width = pictureBox1.Left + e.X;
                }
                catch { }
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            allowResize = true;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            allowResize = false;
        }

        #endregion

        #region Lanzadores de Procesos
        public void MostrarForma(Form mForma)
        {
            mForma.MdiParent = this;
            if (mForma.ControlBox)
            {
                mForma.WindowState = FormWindowState.Maximized;
            }
            mForma.Show();
        }

        public virtual void MostrarConsulta(string SqlConsulta, string titulo)
        {
            frmConsulta FormConsulta = default(frmConsulta);
            FormConsulta = new frmConsulta(vDB, this, titulo, SqlConsulta, null, 0, null, null, null);
            FormConsulta.MdiParent = this;
            FormConsulta.Show();
        }
        #endregion


        
        #region Opciones Menu
        
            #region Ayuda
            private void mnuAcerca_Click(object sender, EventArgs e)
            {
                (new SIPV.Windows.frmAcerca()).Show ();
            }

            private void mnuTemasAyuda_Click(object sender, EventArgs e)
            {
                try
                {
                    string kdna = System.AppDomain.CurrentDomain.BaseDirectory + "/Ayuda.chm";
                    Help.ShowHelp(this, kdna);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error de tipo: " + ex.Message);
                }
            }

            #endregion
            
            #region Utilitarios
            private void mnuCambioClave_Click(object sender, EventArgs e)
            {
                MostrarForma(new SIPV.Security.frmCambioClave(vDB));
            }

            private void gestiónAuditoríaToolStripMenuItem_Click(object sender, EventArgs e)
            {
                
            }


            #endregion
           
            #region Catalogos 

            private void mnuPrivilegios_Click(object sender, EventArgs e)
            {
                //MostrarForma(new SIPV.Security.frmPrivilegiosMnu(this, vDB));
            }
            private void mnuIU_ESTADO_POLIZA_Click(object sender, EventArgs e)
            {
                //MostrarForma(new SIPV.Windows.Catalogos.IU_ESTADO_POLIZA(vDB, this));
            }

            #endregion        
            
            #region Transacciones
            
            
            
            #endregion

            #region Consultas

            #endregion

            #region Procesos


            
            #endregion

            #region Reportes

            private void mnuDiccionarioDatos_Click(object sender, EventArgs e)
            {
                Utility.VerReporte("", "VisDiccionarioDatos", "Diccionario de Datos", new SIPV.Windows.Reportes.DsReportes(), new SIPV.Windows.Reportes.RPT_Diccionario_Datos(), vDB, this, null);
            }

            #endregion




        #endregion

   

    }
}