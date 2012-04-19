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


    public class ComboVENTA_DETALLE : StringConverter
    {
        private static string[] mVENTA_DETALLE;
        public static bool Cargado = false;
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }
        public static string[] VENTA_DETALLE
        {
            get { return mVENTA_DETALLE; }
            set { mVENTA_DETALLE = value; Cargado = true; }
        }
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            return new StandardValuesCollection(mVENTA_DETALLE);
        }
        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return true;
        }

    }

    public class ConsultaVENTA_DETALLE : UITypeEditor
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
                                                 "Consulta de VENTA_DETALLE",
                                                 "SELECT VENTA_DETALLE,DESCRIPCION FROM VENTA_DETALLE",
                                                 vTextCampoLlave, 0, null,
                                                 new string[] { "ID", "DESCRIPCION" },
                                                 new int[] { 100, 300 });


                svc.ShowDialog(FormConsulta);
                value = vTextCampoLlave.Text;
            }
            return value;
        }
    }


    public class VENTA_DETALLE : BaseCode.DB_BASE, IvDB
    {
        public BaseCode.DB getvDB() { return DB; }
        #region Constructores
        public VENTA_DETALLE()
        {

        }
        public VENTA_DETALLE(BaseCode.DB vDB)
            : base(vDB, "VENTA_DETALLE", TipoInterAccionBD.Directa)
        {
            this.Compania = "dbo";
            this.CrearEstructura();
            this.InicializarCampos();
        }
        #endregion

        #region Variables Locales
        private string _FACTURA;
        private string _LINEA;
        private string _ARTICULO;
        private string _PRECIO;
        private string _GRAVADO;
        private string _CANTIDAD;
        private string _MOVIMIENTO;
        #endregion

        #region Propiedades Originales
        [Browsable(false)]
        public string Factura
        {
            get { return _FACTURA; }
            set { _FACTURA = value; }
        }
        [Browsable(false)]
        public string Linea
        {
            get { return _LINEA; }
            set { _LINEA = value; }
        }
        [Browsable(false)]
        public string Articulo
        {
            get { return _ARTICULO; }
            set { _ARTICULO = value; }
        }
        [Browsable(false)]
        public string Precio
        {
            get { return _PRECIO; }
            set { _PRECIO = value; }
        }
        [Browsable(false)]
        public string Gravado
        {
            get { return _GRAVADO; }
            set { _GRAVADO = value; }
        }
        [Browsable(false)]
        public string Cantidad
        {
            get { return _CANTIDAD; }
            set { _CANTIDAD = value; }
        }
        [Browsable(false)]
        public string Movimiento
        {
            get { return _MOVIMIENTO; }
            set { _MOVIMIENTO = value; }
        }
        #endregion

        #region Propiedades a Mostrar
        [Browsable(true)]
        //[TypeConverter(typeof(Combo))] 
        //[Editor(typeof(Consulta), typeof(UITypeEditor))]
        [CategoryAttribute("General"), DisplayName("0-Factura"), DescriptionAttribute("Valor de Factura"), ReadOnly(false)]

        public string _mFACTURA
        {
            get { return Factura; }
            set { Factura = value; }
        }
        [Browsable(true)]
        //[TypeConverter(typeof(Combo))] 
        //[Editor(typeof(Consulta), typeof(UITypeEditor))]
        [CategoryAttribute("General"), DisplayName("1-Linea"), DescriptionAttribute("Valor de Linea"), ReadOnly(false)]

        public string _mLINEA
        {
            get { return Linea; }
            set { Linea = value; }
        }
        [Browsable(true)]
        //[TypeConverter(typeof(Combo))] 
        //[Editor(typeof(Consulta), typeof(UITypeEditor))]
        [CategoryAttribute("General"), DisplayName("2-Articulo"), DescriptionAttribute("Valor de Articulo"), ReadOnly(false)]

        public string _mARTICULO
        {
            get { return Articulo; }
            set { Articulo = value; }
        }
        [Browsable(true)]
        //[TypeConverter(typeof(Combo))] 
        //[Editor(typeof(Consulta), typeof(UITypeEditor))]
        [CategoryAttribute("General"), DisplayName("3-Precio"), DescriptionAttribute("Valor de Precio"), ReadOnly(false)]

        public string _mPRECIO
        {
            get { return Precio; }
            set { Precio = value; }
        }
        [Browsable(true)]
        //[TypeConverter(typeof(Combo))] 
        //[Editor(typeof(Consulta), typeof(UITypeEditor))]
        [CategoryAttribute("General"), DisplayName("4-Gravado"), DescriptionAttribute("Valor de Gravado"), ReadOnly(false)]

        public string _mGRAVADO
        {
            get { return Gravado; }
            set { Gravado = value; }
        }
        [Browsable(true)]
        //[TypeConverter(typeof(Combo))] 
        //[Editor(typeof(Consulta), typeof(UITypeEditor))]
        [CategoryAttribute("General"), DisplayName("5-Cantidad"), DescriptionAttribute("Valor de Cantidad"), ReadOnly(false)]

        public string _mCANTIDAD
        {
            get { return Cantidad; }
            set { Cantidad = value; }
        }
        [Browsable(true)]
        //[TypeConverter(typeof(Combo))] 
        //[Editor(typeof(Consulta), typeof(UITypeEditor))]
        [CategoryAttribute("General"), DisplayName("6-Movimiento"), DescriptionAttribute("Valor de Movimiento"), ReadOnly(false)]

        public string _mMOVIMIENTO
        {
            get { return Movimiento; }
            set { Movimiento = value; }
        }
        #endregion


        public override string Validar()
        {

            if (this.EsValorInvalido(_FACTURA)) { return "Falta el dato de factura"; }
            if (this.EsValorInvalido(_LINEA)) { return "Falta el dato de linea"; }
            if (this.EsValorInvalido(_ARTICULO)) { return "Falta el dato de articulo"; }
            if (this.EsValorInvalido(_PRECIO)) { return "Falta el dato de precio"; }
            if (this.EsValorInvalido(_GRAVADO)) { return "Falta el dato de gravado"; }
            if (this.EsValorInvalido(_CANTIDAD)) { return "Falta el dato de cantidad"; }
            if (this.EsValorInvalido(_MOVIMIENTO)) { return "Falta el dato de movimiento"; }
            return "";
        }
        public override void InicializarCampos()
        {
            _FACTURA = "";
            _LINEA = "";
            _ARTICULO = "";
            _PRECIO = "";
            _GRAVADO = "";
            _CANTIDAD = "";
            _MOVIMIENTO = "";
            Lista = null;
        }
    }
}



