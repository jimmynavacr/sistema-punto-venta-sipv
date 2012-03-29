using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BaseCode;
namespace SIPV.Security
{

    public partial class frmPrivilegiosMnu : System.Windows.Forms.Form
    {
        private ImnuSecurity frmMenu;
        private DB vDB;
        private string mSistema = "";

        public frmPrivilegiosMnu()
        {
            InitializeComponent();
        }

        public frmPrivilegiosMnu(ImnuSecurity frmMnu, DB vDB)
            : this()
        {
            this.frmMenu = frmMnu;
            this.vDB = vDB;
            mSistema = System.Configuration.ConfigurationManager.AppSettings["Sistema"].ToString(); ;
        }

        //Metodos de carga de datos
        private void CargarGrupos()
        {
            DataTable mDataTable = null;
            int i = 0;
            mDataTable = vDB.ConsultarDataTable("SELECT RTRIM(name) GRUPO FROM sysusers WHERE issqlrole='1' AND uid>0 AND uid<1000");
            if (mDataTable != null)
            {
                for (i = 0; i < mDataTable.Rows.Count; i++)
                {
                    CbGrupos.Items.Add(mDataTable.Rows[i]["GRUPO"].ToString().ToUpper());
                }
                mDataTable.Dispose();
                mDataTable = null;
                GC.Collect();
            }
            if (CbGrupos.Items.Count > 0)
            {
                CbGrupos.SelectedIndex = 0;
            }
        }
        //Cargar elementos de los menus
        private void CargarMiembroSubMnu(System.Windows.Forms.ToolStripMenuItem Mnu, System.Windows.Forms.TreeNode Padre)
        {
            int i = 0;
            for (i = 0; i < Mnu.DropDownItems.Count; i++)
            {
                if (Mnu.DropDownItems[i].GetType().Name.Equals("ToolStripMenuItem"))
                {
                    System.Windows.Forms.TreeNode mNode = null;
                    mNode = new System.Windows.Forms.TreeNode(Mnu.DropDownItems[i].Text, 2, 2);
                    mNode.Tag = Mnu.DropDownItems[i].Name;
                    //mNode.Tag = Mnu.DropDownItems[i].Text ;
                    Padre.Nodes.Add(mNode);
                    CargarMiembroSubMnu((ToolStripMenuItem)Mnu.DropDownItems[i], mNode);
                }
            }
        }

        private void CargarMiembroMnu(System.Windows.Forms.MenuStrip Mnu)
        {
            int i = 0;
            for (i = 0; i < Mnu.Items.Count; i++)
            {
                System.Windows.Forms.TreeNode mNode = null;
                mNode = new System.Windows.Forms.TreeNode(Mnu.Items[i].Text, 0, 0);
                mNode.Tag = Mnu.Items[i].Name;
                //mNode.Tag = Mnu.Items[i].Text;
                TvOpciones.Nodes.Add(mNode);

                CargarMiembroSubMnu((ToolStripMenuItem)Mnu.Items[i], mNode);
            }
        }

        private void CargarOpciones()
        {
            TvOpciones.Nodes.Clear();
            CargarMiembroMnu(frmMenu.mnuPrincipal());
        }
        //Chequear privilegios actuales
        private void ChequearMenu(string Menu, string Campo, System.Windows.Forms.TreeNodeCollection mNode)
        {
            int i = 0;
            for (i = 0; i < mNode.Count; i++)
            {
                if (Campo.Equals("mnu_nombre"))
                {
                    if (mNode[i].Text.ToString().ToUpper().Trim().Equals(Menu.ToUpper().Trim()))
                    {
                        mNode[i].Checked = true;
                        break;
                    }
                }
                else
                {
                    if (mNode[i].Tag.ToString().ToUpper().Equals(Menu.ToUpper().Trim()))
                    {
                        mNode[i].Checked = true;
                        break;
                    }
                }
                ChequearMenu(Menu, Campo, mNode[i].Nodes);
            }
        }

        private void MarcarPrivilegiosUsuario(string mGrupo)
        {
            DataTable mDataTable = null;
            int i = 0;
            mDataTable = vDB.ConsultarDataTable("SELECT * FROM MENU_GRUPO WHERE mnu_grupo='" + mGrupo + "' AND mnu_sistema='"+mSistema +"'");
            if (mDataTable != null)
            {
                for (i = 0; i < mDataTable.Rows.Count; i++)
                {
                    //ChequearMenu(mDataTable.Rows[i]["mnu_nombre"].ToString().ToUpper(), TvOpciones.Nodes);
                    ChequearMenu(mDataTable.Rows[i]["mnu_nombre"].ToString().ToUpper(), "mnu_nombre", TvOpciones.Nodes);
                }
                mDataTable.Dispose();
                mDataTable = null;
                GC.Collect();
            }
        }
        //Salvar nuevos privilegios
        private int OptionsCount = 0;
        private bool SalvarOpcionesMenu(System.Windows.Forms.TreeNodeCollection mNode, string mGrupo)
        {
            int i = 0;
            for (i = 0; i < mNode.Count; i++)
            {
                string Ident = Utility.Completa("",  ((mNode[i].Level + 1) * 3)," ");
                OptionsCount++;
                if (mNode[i].Checked)
                {
                    string Result = vDB.Ejecutar("INSERT INTO MENU_GRUPO  (mnu_nombre,mnu_grupo,mnu_sistema,mnu_menu,MNU_INDICE) VALUES ('" + Ident + mNode[i].Text + "','" + mGrupo + "','" + mSistema + "','" + mNode[i].Tag + "'," + OptionsCount.ToString() + ")");
                    if (!Result.Equals(""))
                    {
                        System.Windows.Forms.MessageBox.Show(frmMenu.mOwner(), Result, "Error");
                    }
                }
                if (!(SalvarOpcionesMenu(mNode[i].Nodes, mGrupo)))
                {
                    return false;
                }
            }
            return true;
        }
        private void DesChequearMenu(System.Windows.Forms.TreeNodeCollection mNode)
        {
            int i = 0;
            for (i = 0; i < mNode.Count; i++)
            {
                mNode[i].Checked = false;
                DesChequearMenu(mNode[i].Nodes);
            }
        }


        private void SalvarPrivilegios(string mGrupo)
        {
            this.Cursor = Cursors.WaitCursor;
            string Result = vDB.Ejecutar("DELETE FROM MENU_GRUPO WHERE MNU_GRUPO='" + mGrupo + "' AND MNU_SISTEMA='" + mSistema + "'");
            if (Result.Equals(""))
            {
                OptionsCount = 0;
                if (SalvarOpcionesMenu(TvOpciones.Nodes, mGrupo))
                {
                    MessageBox.Show("Se han salvado los privilegios del grupo " + mGrupo, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Surgieron errores al actualizar el grupo " + mGrupo, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show(frmMenu.mOwner(), Result, "Error");
            }
            this.Cursor = Cursors.Arrow;
        }

        //Eventos
        private void TvOpciones_AfterCheck(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            if (e.Node.Checked)
            {
                if (e.Node.Parent != null)
                {
                    e.Node.Parent.Checked = true;
                }
            }
        }
        private void CbGrupos_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            DesChequearMenu(TvOpciones.Nodes);
            MarcarPrivilegiosUsuario(CbGrupos.Text);
        }
        private void CmdCancelar_Click(object sender, System.EventArgs e)
        {
            
        }

        private void frmOPSS05_Load(object sender, System.EventArgs e)
        {
            CargarOpciones();
            CargarGrupos();
        }

        private void CmdAceptar_Click(object sender, System.EventArgs e)
        {
         
        }

        private void CmdSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CmdGuardar_Click(object sender, EventArgs e)
        {
            SalvarPrivilegios(CbGrupos.Text);
        }

        private void TvOpciones_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void CmdReport_Click(object sender, EventArgs e)
        {
            string[] vParametros = new string[1];
            BaseCode.Utility.VerReporte("SELECT * FROM MENU_GRUPO ",
                "MENU_GRUPO", "Reporte de privilegios",
                new DsReportes(), new rptPrivilegiosMnu(),
                vDB, this.MdiParent , vParametros,null,null,null,true);
        }


        public static void MostrarReporte(string SQL, BaseCode.DB mDB, Form mSource)
        {
          
        }
        private void marcarHerenciaNodo(System.Windows.Forms.TreeNode mNode, bool Checked)
        {
            mNode.Checked = Checked;
            mNode.ExpandAll();
            for (int i = 0; i < mNode.Nodes.Count; i++)
            {
                marcarHerenciaNodo(mNode.Nodes[i], Checked);
            }
        }
        private void CmdMarcarJerarquia_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.TreeNode mNode = TvOpciones.SelectedNode;
            if (mNode != null)
            {
                marcarHerenciaNodo(mNode, true);
            }

        }

        private void CmdDesMarcarJerarquia_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.TreeNode mNode = TvOpciones.SelectedNode;
            if (mNode != null)
            {
                marcarHerenciaNodo(mNode, false);
            }
        }
  
    }
}