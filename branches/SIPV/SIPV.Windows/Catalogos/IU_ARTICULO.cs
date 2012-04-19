using System;
using System.Collections.Generic;
using System.Text;
using BaseCode;
using System.ComponentModel;
using System.Reflection;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace SIPV.Windows.Catalogos
{
    



    public partial class IU_ARTICULO : BaseCode.frmBaseMant_Grid_DataObj
    {
        #region Constructores

        public IU_ARTICULO(BaseCode.DB vDB, Form Parent):        
            base(vDB, Parent, new SIPV.Datos.ARTICULO(vDB))
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
            this.SqlQueryMant = "SELECT ARTICULO ,DESCRIPCION FROM ARTICULO";
            this.Enc = new string[] { "ID", "DESCRIPCION" };
            this.Anch = new int[] { 100, 300 };
            this.ConfigurarConsulta(SqlQueryMant, Enc, Anch);
        }

        private void Campos_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            TextCampoLlave.Text = ((SIPV.Datos.ARTICULO)TablaBase).Articulo;
        }
        public override void CargarObjsDeDatosDesdeObjsDeInterfaces()
        {

            ((SIPV.Datos.ARTICULO)TablaBase).Articulo = TextCampoLlave.Text;
        }
        private void IU_ARTICULO_AntesDatoEnviado(object sender, EventArgs e)
        {
            ((SIPV.Datos.ARTICULO)TablaBase).Articulo = DataGrid.DataGrid.Rows[DataGrid.DataGrid.CurrentCell.RowIndex].Cells[0].Value.ToString(); ;
        }
    }
}
