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


    public class ComboARTICULO : StringConverter
    {
        private static string[] mARTICULO;
        public static bool Cargado = false;
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }
        public static string[] ARTICULO
        {
            get { return mARTICULO; }
            set { mARTICULO = value; Cargado = true; }
        }
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            return new StandardValuesCollection(mARTICULO);
        }
        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return true;
        }

    }

    public class ConsultaARTICULO : UITypeEditor
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
                                                 "Consulta de ARTICULO",
                                                 "SELECT ARTICULO,DESCRIPCION FROM ARTICULO",
                                                 vTextCampoLlave, 0, null,
                                                 new string[] { "ID", "DESCRIPCION" },
                                                 new int[] { 100, 300 });


                svc.ShowDialog(FormConsulta);
                value = vTextCampoLlave.Text;
            }
            return value;
        }
    }

    public class ConvertidoARTICULO: ExpandableObjectConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return false;
        }
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return true;
        }
        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, Object value, Type destinationType)
        {
            if (destinationType == typeof(String) && value is ARTICULO)
            {
                ARTICULO cX;
                if (value != null)
                {
                    cX = (ARTICULO)value;
                    return cX._mARTICULO + "/" + cX.Descripcion;
                }
            }
            return base.ConvertTo(context, culture, value, null);
        }
        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, Object value)
        {
            return base.ConvertFrom(context, culture, value);
        }
    }

    [TypeConverter(typeof(ConvertidoARTICULO))]
    public class ARTICULO : BaseCode.DB_BASE, IvDB
    {
        public BaseCode.DB getvDB() { return DB; }
        #region Constructores
        public ARTICULO()
        {

        }
        public ARTICULO(BaseCode.DB vDB)
            : base(vDB, "ARTICULO", TipoInterAccionBD.Directa)
        {
            this.Compania = "dbo";
            this.CrearEstructura();
            this.InicializarCampos();
            if (!ComboTIPO_ARTICULO.Cargado)
            {
                ComboTIPO_ARTICULO.TIPO_ARTICULO = DB.ArrayDesdeTablaCodigoDescripcion(DB, "TIPO_ARTICULO", "TIPO_ARTICULO", "Descripcion");
            }
        }
        #endregion

        #region Variables Locales
        private string _ARTICULO;
        private string _DESCRIPCION;
        private string _TIPO_ARTICULO;
        private string _PRECIO;
        private string _GRAVADO;
        private string _TIPO_ARTICULO_DESCRIPCION;
        #endregion

        #region Propiedades Originales
        [Browsable(false)]
        public string Articulo
        {
            get { return _ARTICULO; }
            set { _ARTICULO = value; }
        }
        [Browsable(false)]
        public string Descripcion
        {
            get { return _DESCRIPCION; }
            set { _DESCRIPCION = value; }
        }
        [Browsable(false)]
        public string Tipo_articulo
        {
            get { return _TIPO_ARTICULO; }
            set { _TIPO_ARTICULO = value;
            _TIPO_ARTICULO_DESCRIPCION = _TIPO_ARTICULO.Trim() + "-" + DB.Sub_Datar_DT("TIPO_ARTICULO ", "TIPO_ARTICULO ", "DESCRIPCION", _TIPO_ARTICULO);
            }
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
        #endregion

        #region Propiedades a Mostrar
        [Browsable(true)]
        //[TypeConverter(typeof(Combo))] 
        //[Editor(typeof(Consulta), typeof(UITypeEditor))]
        [CategoryAttribute("General"), DisplayName("0-Artículo"), DescriptionAttribute("Id de artículo"), ReadOnly(false)]

        public string _mARTICULO
        {
            get { return Articulo; }
            set { Articulo = value; }
        }
        [Browsable(true)]
        //[TypeConverter(typeof(Combo))] 
        //[Editor(typeof(Consulta), typeof(UITypeEditor))]
        [CategoryAttribute("General"), DisplayName("1-Descripción"), DescriptionAttribute("Descripión del artículo"), ReadOnly(false)]

        public string _mDESCRIPCION
        {
            get { return Descripcion; }
            set { Descripcion = value; }
        }
        [Browsable(true)]
        [TypeConverter(typeof(ComboTIPO_ARTICULO))] 
        //[Editor(typeof(Consulta), typeof(UITypeEditor))]
        [CategoryAttribute("General"), DisplayName("2-Tipo Artículo"), DescriptionAttribute("Tipo de artículo"), ReadOnly(false)]

        public string _mTIPO_ARTICULO
        {
            get { return _TIPO_ARTICULO_DESCRIPCION; }
            set
            {

                if (value.Length >= 2)
                {
                    Tipo_articulo = value.Substring(0, 2);
                }
                else
                {
                    Tipo_articulo = "00";
                }
            }
        }
        [Browsable(true)]
        //[TypeConverter(typeof(ComboTIPO_ARTICULO))] 
        //[Editor(typeof(Consulta), typeof(UITypeEditor))]
        [CategoryAttribute("General"), DisplayName("3-Precio"), DescriptionAttribute("Precio del artículo"), ReadOnly(false)]

        public double  _mPRECIO
        {
            get {
                double result = 0;
                try
                {
                    result = double.Parse(Precio);
                }
                catch { }
                return result;
            
            }
            set { Precio = value.ToString() ; }
        }
        [Browsable(true)]
        //[TypeConverter(typeof(ComboTIPO_ARTICULO))] 
        //[Editor(typeof(Consulta), typeof(UITypeEditor))]
        [CategoryAttribute("General"), DisplayName("4-Gravado"), DescriptionAttribute("Valor de Gravado"), ReadOnly(false)]

        public bool  _mGRAVADO
        {
            get { return Gravado.Equals("S") ; }
            set { Gravado = value?"S":"N"; }
        }
        #endregion


        public override string Validar()
        {

            if (this.EsValorInvalido(_ARTICULO)) { return "Falta el dato de artículo"; }
            if (this.EsValorInvalido(_DESCRIPCION)) { return "Falta el dato de descripción"; }
            if (this.EsValorInvalido(_TIPO_ARTICULO)) { return "Falta el dato de tipo artículo"; }
            if (this.EsValorInvalido(_PRECIO)) { return "Falta el dato de precio"; }
            if (this.EsValorInvalido(_GRAVADO)) { return "Falta el dato de gravado"; }
            return "";
        }
        public override void InicializarCampos()
        {
            _ARTICULO = "";
            _DESCRIPCION = "";
            _TIPO_ARTICULO = "00";
            _PRECIO = "0";
            _GRAVADO = "N";
            Lista = null;
        }
    }
}



