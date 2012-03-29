namespace SIPV.Datos
{
    partial class COLECTION_EDITOR
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(COLECTION_EDITOR));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.CmdCancelar = new System.Windows.Forms.ToolStripButton();
            this.CmdAceptar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.CmdNuevo = new System.Windows.Forms.ToolStripButton();
            this.CmdEliminar = new System.Windows.Forms.ToolStripButton();
            this.LVElementos = new System.Windows.Forms.ListView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.LbEstado = new System.Windows.Forms.ToolStripStatusLabel();
            this.LbTotalRegistros = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.Campos = new BaseCode.PropertyGridEx();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CmdCancelar,
            this.CmdAceptar,
            this.toolStripSeparator1,
            this.CmdNuevo,
            this.CmdEliminar});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(857, 25);
            this.toolStrip1.TabIndex = 15;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // CmdCancelar
            // 
            this.CmdCancelar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CmdCancelar.Image = ((System.Drawing.Image)(resources.GetObject("CmdCancelar.Image")));
            this.CmdCancelar.ImageTransparentColor = System.Drawing.Color.Silver;
            this.CmdCancelar.Name = "CmdCancelar";
            this.CmdCancelar.Size = new System.Drawing.Size(23, 22);
            this.CmdCancelar.Text = "Salir";
            this.CmdCancelar.Click += new System.EventHandler(this.CmdCancelar_Click);
            // 
            // CmdAceptar
            // 
            this.CmdAceptar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CmdAceptar.Image = ((System.Drawing.Image)(resources.GetObject("CmdAceptar.Image")));
            this.CmdAceptar.ImageTransparentColor = System.Drawing.Color.Silver;
            this.CmdAceptar.Name = "CmdAceptar";
            this.CmdAceptar.Size = new System.Drawing.Size(23, 22);
            this.CmdAceptar.Text = "Aceptar";
            this.CmdAceptar.Click += new System.EventHandler(this.CmdAceptar_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // CmdNuevo
            // 
            this.CmdNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CmdNuevo.Image = ((System.Drawing.Image)(resources.GetObject("CmdNuevo.Image")));
            this.CmdNuevo.ImageTransparentColor = System.Drawing.Color.Silver;
            this.CmdNuevo.Name = "CmdNuevo";
            this.CmdNuevo.Size = new System.Drawing.Size(23, 22);
            this.CmdNuevo.Text = "Nuevo";
            this.CmdNuevo.Click += new System.EventHandler(this.CmdNuevo_Click);
            // 
            // CmdEliminar
            // 
            this.CmdEliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CmdEliminar.Image = ((System.Drawing.Image)(resources.GetObject("CmdEliminar.Image")));
            this.CmdEliminar.ImageTransparentColor = System.Drawing.Color.Silver;
            this.CmdEliminar.Name = "CmdEliminar";
            this.CmdEliminar.Size = new System.Drawing.Size(23, 22);
            this.CmdEliminar.Text = "Eliminar";
            this.CmdEliminar.Click += new System.EventHandler(this.CmdEliminar_Click);
            // 
            // LVElementos
            // 
            this.LVElementos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LVElementos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LVElementos.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LVElementos.FullRowSelect = true;
            this.LVElementos.GridLines = true;
            this.LVElementos.HideSelection = false;
            this.LVElementos.Location = new System.Drawing.Point(0, 0);
            this.LVElementos.Name = "LVElementos";
            this.LVElementos.ShowItemToolTips = true;
            this.LVElementos.Size = new System.Drawing.Size(486, 461);
            this.LVElementos.TabIndex = 17;
            this.LVElementos.UseCompatibleStateImageBehavior = false;
            this.LVElementos.View = System.Windows.Forms.View.Details;
            this.LVElementos.SelectedIndexChanged += new System.EventHandler(this.LVElementos_SelectedIndexChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LbEstado,
            this.LbTotalRegistros});
            this.statusStrip1.Location = new System.Drawing.Point(0, 486);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip1.Size = new System.Drawing.Size(857, 22);
            this.statusStrip1.TabIndex = 18;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // LbEstado
            // 
            this.LbEstado.Name = "LbEstado";
            this.LbEstado.Size = new System.Drawing.Size(80, 17);
            this.LbEstado.Text = "Total registros:";
            // 
            // LbTotalRegistros
            // 
            this.LbTotalRegistros.Name = "LbTotalRegistros";
            this.LbTotalRegistros.Size = new System.Drawing.Size(13, 17);
            this.LbTotalRegistros.Text = "0";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.LVElementos);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.Campos);
            this.splitContainer1.Size = new System.Drawing.Size(857, 461);
            this.splitContainer1.SplitterDistance = 486;
            this.splitContainer1.TabIndex = 19;
            // 
            // Campos
            // 
            this.Campos.BackColor = System.Drawing.SystemColors.Control;
            this.Campos.CommandsBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(225)))), ((int)(((byte)(252)))));
            // 
            // 
            // 
            this.Campos.DocCommentDescription.AutoEllipsis = true;
            this.Campos.DocCommentDescription.Cursor = System.Windows.Forms.Cursors.Default;
            this.Campos.DocCommentDescription.Location = new System.Drawing.Point(3, 20);
            this.Campos.DocCommentDescription.Margin = new System.Windows.Forms.Padding(16, 0, 16, 0);
            this.Campos.DocCommentDescription.Name = "";
            this.Campos.DocCommentDescription.Size = new System.Drawing.Size(361, 35);
            this.Campos.DocCommentDescription.TabIndex = 1;
            this.Campos.DocCommentImage = null;
            // 
            // 
            // 
            this.Campos.DocCommentTitle.Cursor = System.Windows.Forms.Cursors.Default;
            this.Campos.DocCommentTitle.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold);
            this.Campos.DocCommentTitle.Location = new System.Drawing.Point(3, 3);
            this.Campos.DocCommentTitle.Margin = new System.Windows.Forms.Padding(16, 0, 16, 0);
            this.Campos.DocCommentTitle.Name = "";
            this.Campos.DocCommentTitle.Size = new System.Drawing.Size(361, 17);
            this.Campos.DocCommentTitle.TabIndex = 0;
            this.Campos.DocCommentTitle.UseMnemonic = false;
            this.Campos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Campos.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Campos.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(166)))), ((int)(((byte)(225)))));
            this.Campos.Location = new System.Drawing.Point(0, 0);
            this.Campos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Campos.Name = "Campos";
            this.Campos.Size = new System.Drawing.Size(367, 461);
            this.Campos.TabIndex = 13;
            // 
            // 
            // 
            this.Campos.ToolStrip.AccessibleName = "ToolBar";
            this.Campos.ToolStrip.AccessibleRole = System.Windows.Forms.AccessibleRole.ToolBar;
            this.Campos.ToolStrip.AllowMerge = false;
            this.Campos.ToolStrip.AutoSize = false;
            this.Campos.ToolStrip.BackColor = System.Drawing.SystemColors.Control;
            this.Campos.ToolStrip.CanOverflow = false;
            this.Campos.ToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.Campos.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.Campos.ToolStrip.Location = new System.Drawing.Point(0, 1);
            this.Campos.ToolStrip.Name = "";
            this.Campos.ToolStrip.Padding = new System.Windows.Forms.Padding(3, 0, 1, 0);
            this.Campos.ToolStrip.Size = new System.Drawing.Size(367, 25);
            this.Campos.ToolStrip.TabIndex = 1;
            this.Campos.ToolStrip.TabStop = true;
            this.Campos.ToolStrip.Text = "PropertyGridToolBar";
            this.Campos.ViewBackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Campos.SelectedGridItemChanged += new System.Windows.Forms.SelectedGridItemChangedEventHandler(this.Campos_SelectedGridItemChanged);
            this.Campos.Leave += new System.EventHandler(this.Campos_Leave);
            // 
            // COLECTION_EDITOR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 508);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "COLECTION_EDITOR";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "COLECTION_EDITOR";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.COLECTION_EDITOR_FormClosing);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripButton CmdCancelar;
        private System.Windows.Forms.ToolStripButton CmdAceptar;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel LbEstado;
        private System.Windows.Forms.ToolStripButton CmdNuevo;
        private System.Windows.Forms.ToolStripButton CmdEliminar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripStatusLabel LbTotalRegistros;
        public BaseCode.PropertyGridEx Campos;
        public System.Windows.Forms.ListView LVElementos;
        private System.Windows.Forms.ToolStrip toolStrip1;

        public System.Windows.Forms.ToolStrip mToolStrip1
        {
            get { return toolStrip1; }
            set { toolStrip1 = value; }
        }
    }
}