﻿using System;
using System.Collections.Generic;
using System.Text;
using BaseCode;
using System.ComponentModel;
using System.Reflection;
using System.Drawing.Design;
using System.Windows.Forms.Design;

namespace SIPV.Datos
{


    public class ComboTIPO_ENTIDAD : StringConverter
    {
        private static string[] mTIPO_ENTIDAD;
        public static bool Cargado = false;
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }
        public static string[] TIPO_ENTIDAD
        {
            get { return mTIPO_ENTIDAD; }
            set { mTIPO_ENTIDAD = value; Cargado = true; }
        }
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            return new StandardValuesCollection(mTIPO_ENTIDAD);
        }
        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return true;
        }

    }

    public class ConsultaTIPO_ENTIDAD : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            System.Windows.Forms.TextBox vTextCampoLlave = new System.Windows.Forms.TextBox();

            IWindowsFormsEditorService svc = (IWindowsFormsEditorService)
                provider.GetService(typeof(IWindowsFormsEditorService));
            if (svc != null)
            {
                frmConsulta FormConsulta = default(frmConsulta);
                if (value == null)
                {
                    value = "0";
                }
                vTextCampoLlave.Text = value.ToString();

                FormConsulta = new frmConsulta(((IvDB)context.Instance).getvDB(),
                                                 null,
                                                 "Consulta de tipo entidad",
                                                 "SELECT TIPO_ENTIDAD,DESCRIPCION FROM TIPO_ENTIDAD",
                                                 vTextCampoLlave, 0, null,
                                                 new string[] { "ID", "DESCRIPCION" },
                                                 new int[] { 100, 300 });


                svc.ShowDialog(FormConsulta);
                value = vTextCampoLlave.Text;
            }
            return value;
        }
    }


    public class TIPO_ENTIDAD : BaseCode.DB_BASE, IvDB
    {
        public BaseCode.DB getvDB() { return DB; }
        #region Constructores
        public TIPO_ENTIDAD()
        {

        }
        public TIPO_ENTIDAD(BaseCode.DB vDB)
            : base(vDB, "TIPO_ENTIDAD", TipoInterAccionBD.Directa)
        {
            this.Compania = "dbo";
            this.CrearEstructura();
            this.InicializarCampos();
        }
        #endregion

        #region Variables Locales
        private string _TIPO_ENTIDAD;
        private string _DESCRIPCION;
        #endregion

        #region Propiedades Originales
        [Browsable(false)]
        public string Tipo_entidad
        {
            get { return _TIPO_ENTIDAD; }
            set { _TIPO_ENTIDAD = value; }
        }
        [Browsable(false)]
        public string Descripcion
        {
            get { return _DESCRIPCION; }
            set { _DESCRIPCION = value; }
        }
        #endregion

        #region Propiedades a Mostrar
        [Browsable(true)]
        //[TypeConverter(typeof(Combo))] 
        //[Editor(typeof(Consulta), typeof(UITypeEditor))]
        [CategoryAttribute("General"), DisplayName("0-Tipo entidad"), DescriptionAttribute("Id del tipo de entidad"), ReadOnly(false)]

        public string _mTIPO_ENTIDAD
        {
            get { return Tipo_entidad; }
            set { Tipo_entidad = value; }
        }
        [Browsable(true)]
        //[TypeConverter(typeof(Combo))] 
        //[Editor(typeof(Consulta), typeof(UITypeEditor))]
        [CategoryAttribute("General"), DisplayName("1-Descripción"), DescriptionAttribute("Descripción del tipo de entidad"), ReadOnly(false)]

        public string _mDESCRIPCION
        {
            get { return Descripcion; }
            set { Descripcion = value; }
        }
        #endregion


        public override string Validar()
        {

            if (this.EsValorInvalido(_TIPO_ENTIDAD)) { return "Falta el dato de id de tipo de entidad"; }
            if (this.EsValorInvalido(_DESCRIPCION)) { return "Falta el dato de descripción"; }
            return "";
        }
        public override void InicializarCampos()
        {
            _TIPO_ENTIDAD = "";
            _DESCRIPCION = "";
            Lista = null;
        }
    }
}



