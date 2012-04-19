using System;
using System.Collections.Generic;
using System.Text;
using BaseCode;
using System.ComponentModel;
using System.Reflection;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace SIPV.Windows.Procesos
{
    



    public partial class IU_INVENTARIO_FISICO : BaseCode.frmBaseMant_Grid_DataObj
    {
        #region Constructores

        public IU_INVENTARIO_FISICO(BaseCode.DB vDB, Form Parent)
            :
            base(vDB, Parent, new SIPV.Datos.INVENTARIO_FISICO(vDB))
        {
            InitializeComponent();
            Campos.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.Campos_PropertyValueChanged);
            TextCampoLlave = TbCodigo;
            Cargar_Forma(Parent);
        }

        #endregion

        public override void Cargar_Combos() { }
        public override void EnlazarPropiedades() { }

        public override void ConfigurarConsulta()
        {
            this.SqlQueryMant = "SELECT ID_INVENTARIO ,RESPONSABLE FROM INVENTARIO_FISICO";
            this.Enc = new string[] { "ID", "DESCRIPCION" };
            this.Anch = new int[] { 100, 300 };
            this.ConfigurarConsulta(SqlQueryMant, Enc, Anch);
        }

        private void Campos_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            TextCampoLlave.Text = ((SIPV.Datos.INVENTARIO_FISICO)TablaBase).Id_inventario;
        }
        public override void CargarObjsDeDatosDesdeObjsDeInterfaces()
        {

            ((SIPV.Datos.INVENTARIO_FISICO)TablaBase).Id_inventario = TextCampoLlave.Text;
        }
        private void IU_INVENTARIO_FISICO_AntesDatoEnviado(object sender, EventArgs e)
        {
            ((SIPV.Datos.INVENTARIO_FISICO)TablaBase).Id_inventario = DataGrid.DataGrid.Rows[DataGrid.DataGrid.CurrentCell.RowIndex].Cells[0].Value.ToString(); ;
        }
    }
}
