namespace SIPV.Security
{


    public partial class frmPrivilegiosMnu : System.Windows.Forms.Form
    {

        //Form overrides dispose to clean up the component list.
        [System.Diagnostics.DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && components != null)
                {
                    components.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        //Required by the Windows Form Designer
        private System.ComponentModel.IContainer components=null;

        //NOTE: The following procedure is required by the Windows Form Designer
        //It can be modified using the Windows Form Designer.  
        //Do not modify it using the code editor.
        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Node2");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Node3");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Node0", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Node1");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrivilegiosMnu));
            this.Label1 = new System.Windows.Forms.Label();
            this.TvOpciones = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.CmdSalir = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.CmdGuardar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.CbGrupos = new System.Windows.Forms.ToolStripComboBox();
            this.CmdReport = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.CmdMarcarJerarquia = new System.Windows.Forms.ToolStripButton();
            this.CmdDesMarcarJerarquia = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.LbEstado = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(209, 9);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(41, 13);
            this.Label1.TabIndex = 10;
            this.Label1.Text = "Grupos";
            // 
            // TvOpciones
            // 
            this.TvOpciones.CheckBoxes = true;
            this.TvOpciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TvOpciones.FullRowSelect = true;
            this.TvOpciones.HideSelection = false;
            this.TvOpciones.ImageIndex = 0;
            this.TvOpciones.ImageList = this.imageList1;
            this.TvOpciones.Location = new System.Drawing.Point(0, 25);
            this.TvOpciones.Name = "TvOpciones";
            treeNode1.Name = "Node2";
            treeNode1.Text = "Node2";
            treeNode2.Name = "Node3";
            treeNode2.Text = "Node3";
            treeNode3.Name = "Node0";
            treeNode3.Text = "Node0";
            treeNode4.Name = "Node1";
            treeNode4.Text = "Node1";
            this.TvOpciones.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode4});
            this.TvOpciones.SelectedImageIndex = 1;
            this.TvOpciones.ShowNodeToolTips = true;
            this.TvOpciones.Size = new System.Drawing.Size(634, 432);
            this.TvOpciones.TabIndex = 12;
            this.TvOpciones.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.TvOpciones_AfterCheck);
            this.TvOpciones.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TvOpciones_AfterSelect);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Form.bmp");
            this.imageList1.Images.SetKeyName(1, "mnuPrincipal.bmp");
            this.imageList1.Images.SetKeyName(2, "mnuSecundario.bmp");
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CmdSalir,
            this.toolStripSeparator3,
            this.CmdGuardar,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.CbGrupos,
            this.CmdReport,
            this.toolStripSeparator2,
            this.CmdMarcarJerarquia,
            this.CmdDesMarcarJerarquia,
            this.toolStripSeparator4});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(634, 25);
            this.toolStrip1.TabIndex = 16;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // CmdSalir
            // 
            this.CmdSalir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CmdSalir.Image = ((System.Drawing.Image)(resources.GetObject("CmdSalir.Image")));
            this.CmdSalir.ImageTransparentColor = System.Drawing.Color.Silver;
            this.CmdSalir.Name = "CmdSalir";
            this.CmdSalir.Size = new System.Drawing.Size(23, 22);
            this.CmdSalir.Text = "toolStripButton1";
            this.CmdSalir.Click += new System.EventHandler(this.CmdSalir_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // CmdGuardar
            // 
            this.CmdGuardar.Image = ((System.Drawing.Image)(resources.GetObject("CmdGuardar.Image")));
            this.CmdGuardar.ImageTransparentColor = System.Drawing.Color.Silver;
            this.CmdGuardar.Name = "CmdGuardar";
            this.CmdGuardar.Size = new System.Drawing.Size(59, 22);
            this.CmdGuardar.Text = "Aplicar";
            this.CmdGuardar.Click += new System.EventHandler(this.CmdGuardar_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(36, 22);
            this.toolStripLabel1.Text = "Grupo";
            // 
            // CbGrupos
            // 
            this.CbGrupos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbGrupos.Name = "CbGrupos";
            this.CbGrupos.Size = new System.Drawing.Size(121, 25);
            this.CbGrupos.SelectedIndexChanged += new System.EventHandler(this.CbGrupos_SelectedIndexChanged);
            // 
            // CmdReport
            // 
            this.CmdReport.Image = ((System.Drawing.Image)(resources.GetObject("CmdReport.Image")));
            this.CmdReport.ImageTransparentColor = System.Drawing.Color.Silver;
            this.CmdReport.Name = "CmdReport";
            this.CmdReport.Size = new System.Drawing.Size(66, 22);
            this.CmdReport.Text = "Reporte";
            this.CmdReport.Click += new System.EventHandler(this.CmdReport_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // CmdMarcarJerarquia
            // 
            this.CmdMarcarJerarquia.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CmdMarcarJerarquia.Image = ((System.Drawing.Image)(resources.GetObject("CmdMarcarJerarquia.Image")));
            this.CmdMarcarJerarquia.ImageTransparentColor = System.Drawing.Color.Silver;
            this.CmdMarcarJerarquia.Name = "CmdMarcarJerarquia";
            this.CmdMarcarJerarquia.Size = new System.Drawing.Size(23, 22);
            this.CmdMarcarJerarquia.Text = "Marcar jerarquía";
            this.CmdMarcarJerarquia.Click += new System.EventHandler(this.CmdMarcarJerarquia_Click);
            // 
            // CmdDesMarcarJerarquia
            // 
            this.CmdDesMarcarJerarquia.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CmdDesMarcarJerarquia.Image = ((System.Drawing.Image)(resources.GetObject("CmdDesMarcarJerarquia.Image")));
            this.CmdDesMarcarJerarquia.ImageTransparentColor = System.Drawing.Color.Silver;
            this.CmdDesMarcarJerarquia.Name = "CmdDesMarcarJerarquia";
            this.CmdDesMarcarJerarquia.Size = new System.Drawing.Size(23, 22);
            this.CmdDesMarcarJerarquia.Text = "Desmarcar jerarquía";
            this.CmdDesMarcarJerarquia.Click += new System.EventHandler(this.CmdDesMarcarJerarquia_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LbEstado});
            this.statusStrip1.Location = new System.Drawing.Point(0, 457);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip1.Size = new System.Drawing.Size(634, 22);
            this.statusStrip1.TabIndex = 17;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // LbEstado
            // 
            this.LbEstado.Name = "LbEstado";
            this.LbEstado.Size = new System.Drawing.Size(0, 17);
            // 
            // frmPrivilegiosMnu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 479);
            this.Controls.Add(this.TvOpciones);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.Label1);
            this.Name = "frmPrivilegiosMnu";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimiento de privilegios por grupo";
            this.Load += new System.EventHandler(this.frmOPSS05_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TreeView TvOpciones;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox CbGrupos;
        private System.Windows.Forms.ToolStripButton CmdGuardar;
        private System.Windows.Forms.ToolStripButton CmdSalir;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel LbEstado;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripButton CmdReport;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton CmdMarcarJerarquia;
        private System.Windows.Forms.ToolStripButton CmdDesMarcarJerarquia;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    }

}