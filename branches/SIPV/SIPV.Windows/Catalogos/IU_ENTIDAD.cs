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
    public enum TipoEntidad
    {
        Indefinido=0,
        Cliente = 1,
        Proveedor=2,        
        Empleado=3
    }



    public partial class IU_ENTIDAD : BaseCode.frmBaseMant_Grid_DataObj
    {
        #region Constructores
        private string mTipoEntidad = "";
        public IU_ENTIDAD(BaseCode.DB vDB, Form Parent, TipoEntidad TipoEntidad)
            :
            base(vDB, Parent, new SIPV.Datos.ENTIDAD(vDB))
        {
            InitializeComponent();
            Campos.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.Campos_PropertyValueChanged);
            mTipoEntidad = ((int)TipoEntidad).ToString();
            TextCampoLlave = TbCodigo;
            Cargar_Forma(Parent);
            
            ((SIPV.Datos.ENTIDAD)TablaBase).Tipo_entidad = mTipoEntidad;

            this.Text = "Entidades [" + ((SIPV.Datos.ENTIDAD)TablaBase)._mTIPO_ENTIDAD + "]";
        }

        #endregion

        public override void Cargar_Combos() { }
        public override void EnlazarPropiedades() { }

        public override void ConfigurarConsulta()
        {
            this.SqlQueryMant = "SELECT ENTIDAD ,DESCRIPCION FROM ENTIDAD WHERE TIPO_ENTIDAD='" + mTipoEntidad  + "'";
            this.Enc = new string[] { "ID", "DESCRIPCION" };
            this.Anch = new int[] { 100, 300 };
            this.ConfigurarConsulta(SqlQueryMant, Enc, Anch);
        }

        private void Campos_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            TextCampoLlave.Text = ((SIPV.Datos.ENTIDAD)TablaBase).Entidad;
        }
        public override void CargarObjsDeDatosDesdeObjsDeInterfaces()
        {

            ((SIPV.Datos.ENTIDAD)TablaBase).Entidad = TextCampoLlave.Text;
        }
        private void IU_ENTIDAD_AntesDatoEnviado(object sender, EventArgs e)
        {
            ((SIPV.Datos.ENTIDAD)TablaBase).Entidad = DataGrid.DataGrid.Rows[DataGrid.DataGrid.CurrentCell.RowIndex].Cells[0].Value.ToString(); ;
        }

        private void IU_ENTIDAD_DespuesCancelar(object sender, EventArgs e)
        {
            if (mTipoEntidad != "")
            {
                ((SIPV.Datos.ENTIDAD)TablaBase).Tipo_entidad = mTipoEntidad;
            }
        }
    }
}
