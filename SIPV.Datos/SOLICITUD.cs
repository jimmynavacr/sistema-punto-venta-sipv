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


    public class ComboSOLICITUD : StringConverter
    {
        private static string[] mSOLICITUD;
        public static bool Cargado = false;
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }
        public static string[] SOLICITUD
        {
            get { return mSOLICITUD; }
            set { mSOLICITUD = value; Cargado = true; }
        }
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            return new StandardValuesCollection(mSOLICITUD);
        }
        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return true;
        }

    }

    public class ConsultaSOLICITUD : UITypeEditor
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
                                                 "Consulta de SOLICITUD",
                                                 "SELECT SOLICITUD,DESCRIPCION FROM SOLICITUD",
                                                 vTextCampoLlave, 0, null,
                                                 new string[] { "ID", "DESCRIPCION" },
                                                 new int[] { 100, 300 });


                svc.ShowDialog(FormConsulta);
                value = vTextCampoLlave.Text;
            }
            return value;
        }
    }


    public class SOLICITUD : BaseCode.DB_BASE, IvDB
    {
        public BaseCode.DB getvDB() { return DB; }
        #region Constructores
        public SOLICITUD()
        {

        }
        public SOLICITUD(BaseCode.DB vDB)
            : base(vDB, "SOLICITUD", TipoInterAccionBD.Directa)
        {
            this.Compania = "dbo";
            this.CrearEstructura();
            this.InicializarCampos();
        }
        #endregion

        #region Variables Locales
        private string _SOLICITUD;
        private string _FECHA;
        private string _CLIENTE;
        private string _DETALLE;
        private string _OBSERVACIONES;
        private string _RESULTADO;
        #endregion

        #region Propiedades Originales
        [Browsable(false)]
        public string Solicitud
        {
            get { return _SOLICITUD; }
            set { _SOLICITUD = value; }
        }
        [Browsable(false)]
        public string Fecha
        {
            get { return _FECHA; }
            set { _FECHA = value; }
        }
        [Browsable(false)]
        public string Cliente
        {
            get { return _CLIENTE; }
            set { _CLIENTE = value; }
        }
        [Browsable(false)]
        public string Detalle
        {
            get { return _DETALLE; }
            set { _DETALLE = value; }
        }
        [Browsable(false)]
        public string Observaciones
        {
            get { return _OBSERVACIONES; }
            set { _OBSERVACIONES = value; }
        }
        [Browsable(false)]
        public string Resultado
        {
            get { return _RESULTADO; }
            set { _RESULTADO = value; }
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
        [CategoryAttribute("General"), DisplayName("1-Fecha"), DescriptionAttribute("Valor de Fecha"), ReadOnly(false)]

        public string _mFECHA
        {
            get { return Fecha; }
            set { Fecha = value; }
        }
        [Browsable(true)]
        //[TypeConverter(typeof(Combo))] 
        //[Editor(typeof(Consulta), typeof(UITypeEditor))]
        [CategoryAttribute("General"), DisplayName("2-Cliente"), DescriptionAttribute("Valor de Cliente"), ReadOnly(false)]

        public string _mCLIENTE
        {
            get { return Cliente; }
            set { Cliente = value; }
        }
        [Browsable(true)]
        //[TypeConverter(typeof(Combo))] 
        //[Editor(typeof(Consulta), typeof(UITypeEditor))]
        [CategoryAttribute("General"), DisplayName("3-Detalle"), DescriptionAttribute("Valor de Detalle"), ReadOnly(false)]

        public string _mDETALLE
        {
            get { return Detalle; }
            set { Detalle = value; }
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
        [Browsable(true)]
        //[TypeConverter(typeof(Combo))] 
        //[Editor(typeof(Consulta), typeof(UITypeEditor))]
        [CategoryAttribute("General"), DisplayName("5-Resultado"), DescriptionAttribute("Valor de Resultado"), ReadOnly(false)]

        public string _mRESULTADO
        {
            get { return Resultado; }
            set { Resultado = value; }
        }
        #endregion


        public override string Validar()
        {

            if (this.EsValorInvalido(_SOLICITUD)) { return "Falta el dato de solicitud"; }
            if (this.EsValorInvalido(_FECHA)) { return "Falta el dato de fecha"; }
            if (this.EsValorInvalido(_CLIENTE)) { return "Falta el dato de cliente"; }
            if (this.EsValorInvalido(_DETALLE)) { return "Falta el dato de detalle"; }
            if (this.EsValorInvalido(_OBSERVACIONES)) { return "Falta el dato de observaciones"; }
            if (this.EsValorInvalido(_RESULTADO)) { return "Falta el dato de resultado"; }
            return "";
        }
        public override void InicializarCampos()
        {
            _SOLICITUD = "";
            _FECHA = "";
            _CLIENTE = "";
            _DETALLE = "";
            _OBSERVACIONES = "";
            _RESULTADO = "";
            Lista = null;
        }
    }
}



