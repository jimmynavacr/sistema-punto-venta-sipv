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


    public class ComboVENTA : StringConverter
    {
        private static string[] mVENTA;
        public static bool Cargado = false;
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }
        public static string[] VENTA
        {
            get { return mVENTA; }
            set { mVENTA = value; Cargado = true; }
        }
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            return new StandardValuesCollection(mVENTA);
        }
        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return true;
        }

    }

    public class ConsultaVENTA : UITypeEditor
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
                                                 "Consulta de VENTA",
                                                 "SELECT VENTA,DESCRIPCION FROM VENTA",
                                                 vTextCampoLlave, 0, null,
                                                 new string[] { "ID", "DESCRIPCION" },
                                                 new int[] { 100, 300 });


                svc.ShowDialog(FormConsulta);
                value = vTextCampoLlave.Text;
            }
            return value;
        }
    }


    public class VENTA : BaseCode.DB_BASE, IvDB
    {
        public BaseCode.DB getvDB() { return DB; }
        #region Constructores
        public VENTA()
        {

        }
        public VENTA(BaseCode.DB vDB)
            : base(vDB, "VENTA", TipoInterAccionBD.Directa)
        {
            this.Compania = "dbo";
            this.CrearEstructura();
            this.InicializarCampos();
        }
        #endregion

        #region Variables Locales
        private string _VENTA;
        private string _FECHA;
        private string _VENDEDOR;
        private string _CLIENTE;
        private string _FORMA_PAGO;
        #endregion

        #region Propiedades Originales
        [Browsable(false)]
        public string Venta
        {
            get { return _VENTA; }
            set { _VENTA = value; }
        }
        [Browsable(false)]
        public string Fecha
        {
            get { return _FECHA; }
            set { _FECHA = value; }
        }
        [Browsable(false)]
        public string Vendedor
        {
            get { return _VENDEDOR; }
            set { _VENDEDOR = value; }
        }
        [Browsable(false)]
        public string Cliente
        {
            get { return _CLIENTE; }
            set { _CLIENTE = value; }
        }
        [Browsable(false)]
        public string Forma_pago
        {
            get { return _FORMA_PAGO; }
            set { _FORMA_PAGO = value; }
        }
        #endregion

        #region Propiedades a Mostrar
        [Browsable(true)]
        //[TypeConverter(typeof(Combo))] 
        //[Editor(typeof(Consulta), typeof(UITypeEditor))]
        [CategoryAttribute("General"), DisplayName("0-Venta"), DescriptionAttribute("Valor de Venta"), ReadOnly(false)]

        public string _mVENTA
        {
            get { return Venta; }
            set { Venta = value; }
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
        [CategoryAttribute("General"), DisplayName("2-Vendedor"), DescriptionAttribute("Valor de Vendedor"), ReadOnly(false)]

        public string _mVENDEDOR
        {
            get { return Vendedor; }
            set { Vendedor = value; }
        }
        [Browsable(true)]
        //[TypeConverter(typeof(Combo))] 
        //[Editor(typeof(Consulta), typeof(UITypeEditor))]
        [CategoryAttribute("General"), DisplayName("3-Cliente"), DescriptionAttribute("Valor de Cliente"), ReadOnly(false)]

        public string _mCLIENTE
        {
            get { return Cliente; }
            set { Cliente = value; }
        }
        [Browsable(true)]
        //[TypeConverter(typeof(Combo))] 
        //[Editor(typeof(Consulta), typeof(UITypeEditor))]
        [CategoryAttribute("General"), DisplayName("4-Forma_pago"), DescriptionAttribute("Valor de Forma_pago"), ReadOnly(false)]

        public string _mFORMA_PAGO
        {
            get { return Forma_pago; }
            set { Forma_pago = value; }
        }
        #endregion


        public override string Validar()
        {

            if (this.EsValorInvalido(_VENTA)) { return "Falta el dato de venta"; }
            if (this.EsValorInvalido(_FECHA)) { return "Falta el dato de fecha"; }
            if (this.EsValorInvalido(_VENDEDOR)) { return "Falta el dato de vendedor"; }
            if (this.EsValorInvalido(_CLIENTE)) { return "Falta el dato de cliente"; }
            if (this.EsValorInvalido(_FORMA_PAGO)) { return "Falta el dato de forma_pago"; }
            return "";
        }
        public override void InicializarCampos()
        {
            _VENTA = "";
            _FECHA = "";
            _VENDEDOR = "";
            _CLIENTE = "";
            _FORMA_PAGO = "";
            Lista = null;
        }
    }
}



