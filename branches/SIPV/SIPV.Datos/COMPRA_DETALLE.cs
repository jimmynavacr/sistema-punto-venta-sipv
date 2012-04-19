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


    public class ComboCOMPRA_DETALLE : StringConverter
    {
        private static string[] mCOMPRA_DETALLE;
        public static bool Cargado = false;
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }
        public static string[] COMPRA_DETALLE
        {
            get { return mCOMPRA_DETALLE; }
            set { mCOMPRA_DETALLE = value; Cargado = true; }
        }
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            return new StandardValuesCollection(mCOMPRA_DETALLE);
        }
        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return true;
        }

    }

    public class ConsultaCOMPRA_DETALLE : UITypeEditor
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
                                                 "Consulta de COMPRA_DETALLE",
                                                 "SELECT COMPRA_DETALLE,DESCRIPCION FROM COMPRA_DETALLE",
                                                 vTextCampoLlave, 0, null,
                                                 new string[] { "ID", "DESCRIPCION" },
                                                 new int[] { 100, 300 });


                svc.ShowDialog(FormConsulta);
                value = vTextCampoLlave.Text;
            }
            return value;
        }
    }


    public class COMPRA_DETALLE : BaseCode.DB_BASE, IvDB
    {
        public BaseCode.DB getvDB() { return DB; }
        #region Constructores
        public COMPRA_DETALLE()
        {

        }
        public COMPRA_DETALLE(BaseCode.DB vDB)
            : base(vDB, "COMPRA_DETALLE", TipoInterAccionBD.Directa)
        {
            this.Compania = "dbo";
            this.CrearEstructura();
            this.InicializarCampos();
        }
        #endregion

        #region Variables Locales
        private string _COMPRA;
        private string _LINEA;
        private string _ARTICULO;
        private string _GRAVADO;
        private string _PRECIO;
        private string _CANTIDAD;
        private string _MOVIMIENTO;
        #endregion

        #region Propiedades Originales
        [Browsable(false)]
        public string Compra
        {
            get { return _COMPRA; }
            set { _COMPRA = value; }
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
        public string Gravado
        {
            get { return _GRAVADO; }
            set { _GRAVADO = value; }
        }
        [Browsable(false)]
        public string Precio
        {
            get { return _PRECIO; }
            set { _PRECIO = value; }
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
        [CategoryAttribute("General"), DisplayName("0-Compra"), DescriptionAttribute("Valor de Compra"), ReadOnly(false)]

        public string _mCOMPRA
        {
            get { return Compra; }
            set { Compra = value; }
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
        [CategoryAttribute("General"), DisplayName("3-Gravado"), DescriptionAttribute("Valor de Gravado"), ReadOnly(false)]

        public string _mGRAVADO
        {
            get { return Gravado; }
            set { Gravado = value; }
        }
        [Browsable(true)]
        //[TypeConverter(typeof(Combo))] 
        //[Editor(typeof(Consulta), typeof(UITypeEditor))]
        [CategoryAttribute("General"), DisplayName("4-Precio"), DescriptionAttribute("Valor de Precio"), ReadOnly(false)]

        public string _mPRECIO
        {
            get { return Precio; }
            set { Precio = value; }
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

            if (this.EsValorInvalido(_COMPRA)) { return "Falta el dato de compra"; }
            if (this.EsValorInvalido(_LINEA)) { return "Falta el dato de linea"; }
            if (this.EsValorInvalido(_ARTICULO)) { return "Falta el dato de articulo"; }
            if (this.EsValorInvalido(_GRAVADO)) { return "Falta el dato de gravado"; }
            if (this.EsValorInvalido(_PRECIO)) { return "Falta el dato de precio"; }
            if (this.EsValorInvalido(_CANTIDAD)) { return "Falta el dato de cantidad"; }
            if (this.EsValorInvalido(_MOVIMIENTO)) { return "Falta el dato de movimiento"; }
            return "";
        }
        public override void InicializarCampos()
        {
            _COMPRA = "";
            _LINEA = "";
            _ARTICULO = "";
            _GRAVADO = "";
            _PRECIO = "";
            _CANTIDAD = "";
            _MOVIMIENTO = "";
            Lista = null;
        }
    }
}



