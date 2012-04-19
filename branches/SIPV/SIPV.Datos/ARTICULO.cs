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
        }
        #endregion

        #region Variables Locales
        private string _ARTICULO;
        private string _DESCRIPCION;
        private string _TIPO_ARTICULO;
        private string _PRECIO;
        private string _GRAVADO;
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
            set { _TIPO_ARTICULO = value; }
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
        [CategoryAttribute("General"), DisplayName("0-Articulo"), DescriptionAttribute("Valor de Articulo"), ReadOnly(false)]

        public string _mARTICULO
        {
            get { return Articulo; }
            set { Articulo = value; }
        }
        [Browsable(true)]
        //[TypeConverter(typeof(Combo))] 
        //[Editor(typeof(Consulta), typeof(UITypeEditor))]
        [CategoryAttribute("General"), DisplayName("1-Descripcion"), DescriptionAttribute("Valor de Descripcion"), ReadOnly(false)]

        public string _mDESCRIPCION
        {
            get { return Descripcion; }
            set { Descripcion = value; }
        }
        [Browsable(true)]
        //[TypeConverter(typeof(Combo))] 
        //[Editor(typeof(Consulta), typeof(UITypeEditor))]
        [CategoryAttribute("General"), DisplayName("2-Tipo_articulo"), DescriptionAttribute("Valor de Tipo_articulo"), ReadOnly(false)]

        public string _mTIPO_ARTICULO
        {
            get { return Tipo_articulo; }
            set { Tipo_articulo = value; }
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
        #endregion


        public override string Validar()
        {

            if (this.EsValorInvalido(_ARTICULO)) { return "Falta el dato de articulo"; }
            if (this.EsValorInvalido(_DESCRIPCION)) { return "Falta el dato de descripcion"; }
            if (this.EsValorInvalido(_TIPO_ARTICULO)) { return "Falta el dato de tipo_articulo"; }
            if (this.EsValorInvalido(_PRECIO)) { return "Falta el dato de precio"; }
            if (this.EsValorInvalido(_GRAVADO)) { return "Falta el dato de gravado"; }
            return "";
        }
        public override void InicializarCampos()
        {
            _ARTICULO = "";
            _DESCRIPCION = "";
            _TIPO_ARTICULO = "";
            _PRECIO = "";
            _GRAVADO = "";
            Lista = null;
        }
    }
}



