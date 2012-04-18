using System.Net;
using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using BaseCode;
using System.Configuration;
namespace SIPV.Security
{
	/// <summary>
	/// Descripción breve de logeo.
	/// </summary>
	public class frmLogeo : System.Windows.Forms.Form
    {
		
        
        
        
        private System.Windows.Forms.Form mSource;
        private DB vDB;
        private Label label1;
        private Label label2;
        private ImageList imageList2;
        private Button button1;
        private Label label4;
        private IContainer components;
        private System.Windows.Forms.Button CmdIngresar;
        private System.Windows.Forms.Button simpleButton1;
        private System.Windows.Forms.TextBox  TbUsuario;
        private System.Windows.Forms.TextBox  TbClave;
        private bool mMostrarPuerto = true;


        private static int HTCAPTION = 2;
        private static int WM_NCLBUTTONDOWN = 0xA1;
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private extern static int SendMessage(System.IntPtr hWnd, int wMsg,
        int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private extern static int ReleaseCapture();
        

		public frmLogeo(System.Windows.Forms.Form  Source,DB vDB,bool MostrarPuerto)
		{
          InitializeComponent();
          mSource        = Source;
		  //TbUsuario.Text = vDB.Usuario;
          //TbClave.Text   = vDB.Clave;
          mMostrarPuerto = MostrarPuerto;
		  this.vDB       = vDB;
		}
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Código generado por el Diseñador de Windows Forms
		/// <summary>
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido del método con el editor de código.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogeo));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.CmdIngresar = new System.Windows.Forms.Button();
            this.simpleButton1 = new System.Windows.Forms.Button();
            this.TbUsuario = new System.Windows.Forms.TextBox();
            this.TbClave = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label1.Location = new System.Drawing.Point(43, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Nombre &usuario:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label2.Location = new System.Drawing.Point(43, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "&Clave acceso:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "Salir.ico");
            this.imageList2.Images.SetKeyName(1, "Aceptar.ico");
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(105, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 19);
            this.label4.TabIndex = 15;
            this.label4.Text = "Copyrigth 2010";
            // 
            // CmdIngresar
            // 
            this.CmdIngresar.Location = new System.Drawing.Point(46, 107);
            this.CmdIngresar.Name = "CmdIngresar";
            this.CmdIngresar.Size = new System.Drawing.Size(116, 28);
            this.CmdIngresar.TabIndex = 2;
            this.CmdIngresar.Text = "Iniciar Sesión";
            this.CmdIngresar.Click += new System.EventHandler(this.cmdIngresar_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(168, 107);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(116, 28);
            this.simpleButton1.TabIndex = 3;
            this.simpleButton1.Text = "Salir";
            this.simpleButton1.Click += new System.EventHandler(this.CmdSalir_Click);
            // 
            // TbUsuario
            // 
            this.TbUsuario.Location = new System.Drawing.Point(168, 28);
            this.TbUsuario.Name = "TbUsuario";
            this.TbUsuario.Size = new System.Drawing.Size(116, 20);
            this.TbUsuario.TabIndex = 0;
            this.TbUsuario.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TbUsuario_KeyDown);
            // 
            // TbClave
            // 
            this.TbClave.Location = new System.Drawing.Point(168, 64);
            this.TbClave.Name = "TbClave";
            this.TbClave.PasswordChar = '*';
            this.TbClave.Size = new System.Drawing.Size(116, 20);
            this.TbClave.TabIndex = 1;
            this.TbClave.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TbClaveKeyDownEvent);
            // 
            // frmLogeo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(452, 279);
            this.ControlBox = false;
            this.Controls.Add(this.TbClave);
            this.Controls.Add(this.TbUsuario);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.CmdIngresar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmLogeo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema de Gestión Tecnológica y Administrativa ";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmLogeo_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion


		private void cmdIngresar_Click(object sender, System.EventArgs e)
		{			
			vDB.Usuario = TbUsuario.Text ;
			vDB.Clave = TbClave.Text ;
            vDB.Compania = "";

            vDB.EstablecerLineaConexion();
            String Result=vDB.Abrir();
			if (Result.Equals(""))
			{
                vDB.RegistrarIntentoConexion("");
                vDB.Generar_VisColumnasXML();
                vDB.Compania = "dbo" ;
				if (mSource!=null) 
				{
                    mSource.Show();
				}
                vDB.Cerrar ();
				this.Dispose ();
			}
			else 
			{
				
                MessageBox.Show(this ,Result, "Error" ,MessageBoxButtons.OK ,  MessageBoxIcon.Error  ); 
			}
		}

		private void TbUsuario_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e){			
			if (e.KeyCode ==System.Windows.Forms.Keys.Enter) 
			{
				 TbClave.Focus();
			}
		}



		private void CmdSalir_Click(object sender, System.EventArgs e)
		{
			if (mSource!=null)
			{
			  mSource.Dispose();
			}			
			vDB.Compania ="";
			Application.Exit ();
		}

          
        private void TbClaveKeyDownEvent(object sender, KeyEventArgs e)
		{
            if (e.KeyCode == Keys.Enter) 
			{				
				cmdIngresar_Click( sender, null ); 
			}
		}

        private void frmLogeo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
        }

        private void CkGuardarUsuario_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void TbClave_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void TbUsuario_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }





	}
}
