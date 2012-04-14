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
    



    public partial class IU_TIPO_ENTIDAD : BaseCode.frmBaseMant_Grid_DataObj
    {
        #region Constructores

        public IU_TIPO_ENTIDAD(BaseCode.DB vDB, Form Parent)
            :
            base(vDB, Parent, new SIPV.Datos.TIPO_ENTIDAD(vDB))
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
            this.SqlQueryMant = "SELECT TIPO_ENTIDAD ,DESCRIPCION FROM TIPO_ENTIDAD";
            this.Enc = new string[] { "ID", "DESCRIPCION" };
            this.Anch = new int[] { 100, 300 };
            this.ConfigurarConsulta(SqlQueryMant, Enc, Anch);
        }

        private void Campos_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            TextCampoLlave.Text = ((SIPV.Datos.TIPO_ENTIDAD)TablaBase).Tipo_entidad;
        }
        public override void CargarObjsDeDatosDesdeObjsDeInterfaces()
        {

            ((SIPV.Datos.TIPO_ENTIDAD)TablaBase).Tipo_entidad = TextCampoLlave.Text;
        }
        private void IU_TIPO_ENTIDAD_AntesDatoEnviado(object sender, EventArgs e)
        {
            ((SIPV.Datos.TIPO_ENTIDAD)TablaBase).Tipo_entidad = DataGrid.DataGrid.Rows[DataGrid.DataGrid.CurrentCell.RowIndex].Cells[0].Value.ToString(); ;
        }
    }
}
