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


    public class ComboGESTION_SOLICITUD : StringConverter
    {
        private static string[] mGESTION_SOLICITUD;
        public static bool Cargado = false;
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }
        public static string[] GESTION_SOLICITUD
        {
            get { return mGESTION_SOLICITUD; }
            set { mGESTION_SOLICITUD = value; Cargado = true; }
        }
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            return new StandardValuesCollection(mGESTION_SOLICITUD);
        }
        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return true;
        }

    }

    public class ConsultaGESTION_SOLICITUD : UITypeEditor
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
                                                 "Consulta de GESTION_SOLICITUD",
                                                 "SELECT GESTION_SOLICITUD,DESCRIPCION FROM GESTION_SOLICITUD",
                                                 vTextCampoLlave, 0, null,
                                                 new string[] { "ID", "DESCRIPCION" },
                                                 new int[] { 100, 300 });


                svc.ShowDialog(FormConsulta);
                value = vTextCampoLlave.Text;
            }
            return value;
        }
    }


    public class GESTION_SOLICITUD : BaseCode.DB_BASE, IvDB
    {
        public BaseCode.DB getvDB() { return DB; }
        #region Constructores
        public GESTION_SOLICITUD()
        {

        }
        public GESTION_SOLICITUD(BaseCode.DB vDB)
            : base(vDB, "GESTION_SOLICITUD", TipoInterAccionBD.Directa)
        {
            this.Compania = "dbo";
            this.CrearEstructura();
            this.InicializarCampos();
        }
        #endregion

        #region Variables Locales
        private string _SOLICITUD;
        private string _EMPLEADO;
        private string _FECHA;
        private string _TIPO_GESTION;
        private string _OBSERVACIONES;
        #endregion

        #region Propiedades Originales
        [Browsable(false)]
        public string Solicitud
        {
            get { return _SOLICITUD; }
            set { _SOLICITUD = value; }
        }
        [Browsable(false)]
        public string Empleado
        {
            get { return _EMPLEADO; }
            set { _EMPLEADO = value; }
        }
        [Browsable(false)]
        public string Fecha
        {
            get { return _FECHA; }
            set { _FECHA = value; }
        }
        [Browsable(false)]
        public string Tipo_gestion
        {
            get { return _TIPO_GESTION; }
            set { _TIPO_GESTION = value; }
        }
        [Browsable(false)]
        public string Observaciones
        {
            get { return _OBSERVACIONES; }
            set { _OBSERVACIONES = value; }
        }
        #endregion

        #region Propiedades a Mostrar
        [Browsable(true)]
        //[TypeConverter(typeof(Combo))] 
        //[Editor(typeof(Consulta), typeof(UITypeEditor))]
        [CategoryAttribute("General"), DisplayName("0-Solicitud"), DescriptionAttribute("Valor de Solicitud"), ReadOnly(false)]

        public string _mSOLICITUD
        {
            get { return Solicitud; }
            set { Solicitud = value; }
        }
        [Browsable(true)]
        //[TypeConverter(typeof(Combo))] 
        //[Editor(typeof(Consulta), typeof(UITypeEditor))]
        [CategoryAttribute("General"), DisplayName("1-Empleado"), DescriptionAttribute("Valor de Empleado"), ReadOnly(false)]

        public string _mEMPLEADO
        {
            get { return Empleado; }
            set { Empleado = value; }
        }
        [Browsable(true)]
        //[TypeConverter(typeof(Combo))] 
        //[Editor(typeof(Consulta), typeof(UITypeEditor))]
        [CategoryAttribute("General"), DisplayName("2-Fecha"), DescriptionAttribute("Valor de Fecha"), ReadOnly(false)]

        public string _mFECHA
        {
            get { return Fecha; }
            set { Fecha = value; }
        }
        [Browsable(true)]
        //[TypeConverter(typeof(Combo))] 
        //[Editor(typeof(Consulta), typeof(UITypeEditor))]
        [CategoryAttribute("General"), DisplayName("3-Tipo_gestion"), DescriptionAttribute("Valor de Tipo_gestion"), ReadOnly(false)]

        public string _mTIPO_GESTION
        {
            get { return Tipo_gestion; }
            set { Tipo_gestion = value; }
        }
        [Browsable(true)]
        //[TypeConverter(typeof(Combo))] 
        //[Editor(typeof(Consulta), typeof(UITypeEditor))]
        [CategoryAttribute("General"), DisplayName("4-Observaciones"), DescriptionAttribute("Valor de Observaciones"), ReadOnly(false)]

        public string _mOBSERVACIONES
        {
            get { return Observaciones; }
            set { Observaciones = value; }
        }
        #endregion


        public override string Validar()
        {

            if (this.EsValorInvalido(_SOLICITUD)) { return "Falta el dato de solicitud"; }
            if (this.EsValorInvalido(_EMPLEADO)) { return "Falta el dato de empleado"; }
            if (this.EsValorInvalido(_FECHA)) { return "Falta el dato de fecha"; }
            if (this.EsValorInvalido(_TIPO_GESTION)) { return "Falta el dato de tipo_gestion"; }
            if (this.EsValorInvalido(_OBSERVACIONES)) { return "Falta el dato de observaciones"; }
            return "";
        }
        public override void InicializarCampos()
        {
            _SOLICITUD = "";
            _EMPLEADO = "";
            _FECHA = "";
            _TIPO_GESTION = "";
            _OBSERVACIONES = "";
            Lista = null;
        }
    }
}



