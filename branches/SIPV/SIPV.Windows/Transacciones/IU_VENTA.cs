﻿using System;
using System.Collections.Generic;
using System.Text;
using BaseCode;
using System.ComponentModel;
using System.Reflection;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace SIPV.Windows.Transacciones
{
    



    public partial class IU_VENTA : BaseCode.frmBaseMant_Grid_DataObj
    {
        #region Constructores

        public IU_VENTA(BaseCode.DB vDB, Form Parent)
            :
            base(vDB, Parent, new SIPV.Datos.VENTA(vDB))
        {
            InitializeComponent();
            Campos.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.Campos_PropertyValueChanged);
            TextCampoLlave = TbCodigo;
            Cargar_Forma(Parent);
            this.VistaDatos = "VisVENTA";
            this.CampoLlave = "FACTURA";
            this.CampoDescriptor = "NOMBRE_CLIENTE";
        }

        #endregion

        public override void Cargar_Combos() { }
        public override void EnlazarPropiedades() { }

        public override void ConfigurarConsulta()
        {
            this.SqlQueryMant = "SELECT FACTURA ,FECHA,NOMBRE_VENDEDOR,NOMBRE_CLIENTE FROM VisVENTA";
            this.Enc = new string[] { "ID", "DESCRIPCION" };
            this.Anch = new int[] { 100, 300 };
            this.ConfigurarConsulta(SqlQueryMant, Enc, Anch);
        }

        private void Campos_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            TextCampoLlave.Text = ((SIPV.Datos.VENTA)TablaBase).Venta;
        }
        public override void CargarObjsDeDatosDesdeObjsDeInterfaces()
        {

            ((SIPV.Datos.VENTA)TablaBase).Venta = TextCampoLlave.Text;
        }
        private void IU_VENTA_AntesDatoEnviado(object sender, EventArgs e)
        {
            ((SIPV.Datos.VENTA)TablaBase).Venta = DataGrid.DataGrid.Rows[DataGrid.DataGrid.CurrentCell.RowIndex].Cells[0].Value.ToString(); ;
        }
    }
}
