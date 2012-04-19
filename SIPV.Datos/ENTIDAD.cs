using System;
using System.Collections.Generic;
using System.Text;
using BaseCode;
using System.ComponentModel;
using System.Reflection;
using System.Drawing.Design;
using System.Windows.Forms.Design;

namespace SIPV.Datos
{


    public class ComboENTIDAD : StringConverter
    {
        private static string[] mENTIDAD;
        public static bool Cargado = false;
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }
        public static string[] ENTIDAD
        {
            get { return mENTIDAD; }
            set { mENTIDAD = value; Cargado = true; }
        }
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            return new StandardValuesCollection(mENTIDAD);
        }
        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return true;
        }

    }

    public class ConsultaENTIDAD : UITypeEditor
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
                                                 "Consulta de entidades",
                                                 "SELECT ENTIDAD,DESCRIPCION FROM ENTIDAD",
                                                 vTextCampoLlave, 0, null,
                                                 new string[] { "ID", "DESCRIPCION" },
                                                 new int[] { 100, 300 });


                svc.ShowDialog(FormConsulta);
                value = vTextCampoLlave.Text;
            }
            return value;
        }
    }


    public class ENTIDAD : BaseCode.DB_BASE, IvDB
    {
        public BaseCode.DB getvDB() { return DB; }
        #region Constructores
        public ENTIDAD()
        {

        }
        public ENTIDAD(BaseCode.DB vDB)
            : base(vDB, "ENTIDAD", TipoInterAccionBD.Directa)
        {
            this.Compania = "dbo";
            this.CrearEstructura();
            this.InicializarCampos();
            if (!ComboTIPO_ENTIDAD.Cargado)
            {
                ComboTIPO_ENTIDAD.TIPO_ENTIDAD = DB.ArrayDesdeTablaCodigoDescripcion(DB, "TIPO_ENTIDAD", "TIPO_ENTIDAD", "Descripcion");
            }
        }
        #endregion

        #region Variables Locales
        private string _ENTIDAD;
        private string _DESCRIPCION;
        private string _TELEFONO;
        private string _DIRECCION;
        private string _EMAIL;
        private string _TIPO_ENTIDAD;
        private string _TIPO_ENTIDAD_DESCRIPCION;
        #endregion

        #region Propiedades Originales
        [Browsable(false)]
        public string Entidad
        {
            get { return _ENTIDAD; }
            set { _ENTIDAD = value; }
        }
        [Browsable(false)]
        public string Descripcion
        {
            get { return _DESCRIPCION; }
            set { _DESCRIPCION = value; }
        }
        [Browsable(false)]
        public string Telefono
        {
            get { return _TELEFONO; }
            set { _TELEFONO = value; }
        }
        [Browsable(false)]
        public string Direccion
        {
            get { return _DIRECCION; }
            set { _DIRECCION = value; }
        }
        [Browsable(false)]
        public string Email
        {
            get { return _EMAIL; }
            set { _EMAIL = value; }
        }
        [Browsable(false)]
        public string Tipo_entidad
        {
            get { return _TIPO_ENTIDAD; }
            set { _TIPO_ENTIDAD = value;
            _TIPO_ENTIDAD_DESCRIPCION = _TIPO_ENTIDAD.Trim() + "-" + DB.Sub_Datar_DT("TIPO_ENTIDAD ", "TIPO_ENTIDAD ", "DESCRIPCION", _TIPO_ENTIDAD);
            }
        }
        #endregion

        #region Propiedades a Mostrar
        [Browsable(true)]
        //[TypeConverter(typeof(Combo))] 
        //[Editor(typeof(Consulta), typeof(UITypeEditor))]
        [CategoryAttribute("General"), DisplayName("0-Entidad"), DescriptionAttribute("Id de entidad"), ReadOnly(false)]

        public string _mENTIDAD
        {
            get { return Entidad; }
            set { Entidad = value; }
        }
        [Browsable(true)]
        //[TypeConverter(typeof(Combo))] 
        //[Editor(typeof(Consulta), typeof(UITypeEditor))]
        [CategoryAttribute("General"), DisplayName("1-Descripcion"), DescriptionAttribute("Descripcion de la entidad"), ReadOnly(false)]

        public string _mDESCRIPCION
        {
            get { return Descripcion; }
            set { Descripcion = value; }
        }
        [Browsable(true)]
        //[TypeConverter(typeof(Combo))] 
        //[Editor(typeof(Consulta), typeof(UITypeEditor))]
        [CategoryAttribute("General"), DisplayName("2-Teléfono"), DescriptionAttribute("Teléfono de la entidad"), ReadOnly(false)]

        public string _mTELEFONO
        {
            get { return Telefono; }
            set { Telefono = value; }
        }
        [Browsable(true)]
        //[TypeConverter(typeof(Combo))] 
        //[Editor(typeof(Consulta), typeof(UITypeEditor))]
        [CategoryAttribute("General"), DisplayName("3-Direccion"), DescriptionAttribute("Dirección de la entidad"), ReadOnly(false)]

        public string _mDIRECCION
        {
            get { return Direccion; }
            set { Direccion = value; }
        }
        [Browsable(true)]
        //[TypeConverter(typeof(Combo))] 
        //[Editor(typeof(Consulta), typeof(UITypeEditor))]
        [CategoryAttribute("General"), DisplayName("4-Email"), DescriptionAttribute("Email de la entidad"), ReadOnly(false)]

        public string _mEMAIL
        {
            get { return Email; }
            set { Email = value; }
        }
        [Browsable(true)]
        [TypeConverter(typeof(ComboTIPO_ENTIDAD))]
        //[Editor(typeof(Consulta), typeof(UITypeEditor))]
        [CategoryAttribute("General"), DisplayName("5-Tipo entidad"), DescriptionAttribute("Tipo Entidad"), ReadOnly(true)]

        public string _mTIPO_ENTIDAD
        {
            get { return _TIPO_ENTIDAD_DESCRIPCION; }
            set
            {
                if (value.Length >= 2)
                {
                    Tipo_entidad = value.Substring(0, 2);
                }
                else
                {
                    Tipo_entidad = "00";
                }

            }
        }
        #endregion


        public override string Validar()
        {

            if (this.EsValorInvalido(_ENTIDAD)) { return "Falta el dato de id entidad"; }
            if (this.EsValorInvalido(_DESCRIPCION)) { return "Falta el dato de nombre de la entidad"; }
            if (this.EsValorInvalido(_TELEFONO)) { return "Falta el dato de teléfono"; }
            if (this.EsValorInvalido(_DIRECCION)) { return "Falta el dato de dirección"; }
            if (this.EsValorInvalido(_EMAIL)) { return "Falta el dato de email"; }
            if (this.EsValorInvalido(_TIPO_ENTIDAD)) { return "Falta el dato de tipo entidad"; }
            return "";
        }
        public override void InicializarCampos()
        {
            _ENTIDAD = "";
            _DESCRIPCION = "";
            _TELEFONO = "";
            _DIRECCION = "";
            _EMAIL = "";
            _TIPO_ENTIDAD = "";
            _TIPO_ENTIDAD_DESCRIPCION = "";
            Lista = null;
        }
    }
}



