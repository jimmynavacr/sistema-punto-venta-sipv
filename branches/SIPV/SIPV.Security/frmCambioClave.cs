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
    public partial class frmCambioClave : Form
    {
        private DB mvarDB;
        private static int HTCAPTION = 2;
        private static int WM_NCLBUTTONDOWN = 0xA1;
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private extern static int SendMessage(System.IntPtr hWnd, int wMsg,
        int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private extern static int ReleaseCapture();
        

        public frmCambioClave(DB vDB)
        {
            InitializeComponent();
            mvarDB = vDB;
        }
        private void frmCambioClave_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);

        }
        private void frmCambioClave_Load(object sender, EventArgs e)
        {
            this.TbUsuarioActual.Text = mvarDB.Usuario;
            mvarDB.Conectar();  
        }



        private void CmdCancelar_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void CmdSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void cmdIngresar_Click(object sender, EventArgs e)
        {
            TbNuevaClave.Text = TbNuevaClave.Text.ToUpper();
            TbConfirmarNuevaClave.Text = TbConfirmarNuevaClave.Text.ToUpper();
            if (TbConfirmarNuevaClave.Text.Equals(TbNuevaClave.Text))
            {
                String result = mvarDB.Ejecutar("SP_PASSWORD '" + TbClaveActual.Text + "','" + TbNuevaClave.Text + "','" + TbUsuarioActual.Text + "'");
                if (result.Equals(""))
                {
                    MessageBox.Show(null, "Se ha cambiado el password", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CmdSalir_Click(sender, e);
                }
                else
                {
                    MessageBox.Show(null, result, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(null, "La confirmación y la clave no coinciden", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TbConfirmarNuevaClave_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void TbNuevaClave_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void TbClaveActual_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void TbUsuarioActual_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}