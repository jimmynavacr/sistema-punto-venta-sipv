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


    public class ComboMOVIMIENTO_ARTICULO : StringConverter
    {
        private static string[] mMOVIMIENTO_ARTICULO;
        public static bool Cargado = false;
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }
        public static string[] MOVIMIENTO_ARTICULO
        {
            get { return mMOVIMIENTO_ARTICULO; }
            set { mMOVIMIENTO_ARTICULO = value; Cargado = true; }
        }
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            return new StandardValuesCollection(mMOVIMIENTO_ARTICULO);
        }
        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return true;
        }

    }

    public class ConsultaMOVIMIENTO_ARTICULO : UITypeEditor
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
                                                 "Consulta de MOVIMIENTO_ARTICULO",
                                                 "SELECT MOVIMIENTO_ARTICULO,DESCRIPCION FROM MOVIMIENTO_ARTICULO",
                                                 vTextCampoLlave, 0, null,
                                                 new string[] { "ID", "DESCRIPCION" },
                                                 new int[] { 100, 300 });


                svc.ShowDialog(FormConsulta);
                value = vTextCampoLlave.Text;
            }
            return value;
        }
    }


    public class MOVIMIENTO_ARTICULO : BaseCode.DB_BASE, IvDB
    {
        public BaseCode.DB getvDB() { return DB; }
        #region Constructores
        public MOVIMIENTO_ARTICULO()
        {

        }
        public MOVIMIENTO_ARTICULO(BaseCode.DB vDB)
            : base(vDB, "MOVIMIENTO_ARTICULO", TipoInterAccionBD.Directa)
        {
            this.Compania = "dbo";
            this.CrearEstructura();
            this.InicializarCampos();
        }
        #endregion

        #region Variables Locales
        private string _MOVIMIENTO;
        private string _TIPO_MOVIMIENTO;
        private string _FECHA;
        private string _ARTICULO;
        private string _CANTIDAD;
        #endregion

        #region Propiedades Originales
        [Browsable(false)]
        public string Movimiento
        {
            get { return _MOVIMIENTO; }
            set { _MOVIMIENTO = value; }
        }
        [Browsable(false)]
        public string Tipo_movimiento
        {
            get { return _TIPO_MOVIMIENTO; }
            set { _TIPO_MOVIMIENTO = value; }
        }
        [Browsable(false)]
        public string Fecha
        {
            get { return _FECHA; }
            set { _FECHA = value; }
        }
        [Browsable(false)]
        public string Articulo
        {
            get { return _ARTICULO; }
            set { _ARTICULO = value; }
        }
        [Browsable(false)]
        public string Cantidad
        {
            get { return _CANTIDAD; }
            set { _CANTIDAD = value; }
        }
        #endregion

        #region Propiedades a Mostrar
        [Browsable(true)]
        //[TypeConverter(typeof(Combo))] 
        //[Editor(typeof(Consulta), typeof(UITypeEditor))]
        [CategoryAttribute("General"), DisplayName("0-Movimiento"), DescriptionAttribute("Valor de Movimiento"), ReadOnly(false)]

        public string _mMOVIMIENTO
        {
            get { return Movimiento; }
            set { Movimiento = value; }
        }
        [Browsable(true)]
        //[TypeConverter(typeof(Combo))] 
        //[Editor(typeof(Consulta), typeof(UITypeEditor))]
        [CategoryAttribute("General"), DisplayName("1-Tipo_movimiento"), DescriptionAttribute("Valor de Tipo_movimiento"), ReadOnly(false)]

        public string _mTIPO_MOVIMIENTO
        {
            get { return Tipo_movimiento; }
            set { Tipo_movimiento = value; }
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
        [CategoryAttribute("General"), DisplayName("3-Articulo"), DescriptionAttribute("Valor de Articulo"), ReadOnly(false)]

        public string _mARTICULO
        {
            get { return Articulo; }
            set { Articulo = value; }
        }
        [Browsable(true)]
        //[TypeConverter(typeof(Combo))] 
        //[Editor(typeof(Consulta), typeof(UITypeEditor))]
        [CategoryAttribute("General"), DisplayName("4-Cantidad"), DescriptionAttribute("Valor de Cantidad"), ReadOnly(false)]

        public string _mCANTIDAD
        {
            get { return Cantidad; }
            set { Cantidad = value; }
        }
        #endregion


        public override string Validar()
        {

            if (this.EsValorInvalido(_MOVIMIENTO)) { return "Falta el dato de movimiento"; }
            if (this.EsValorInvalido(_TIPO_MOVIMIENTO)) { return "Falta el dato de tipo_movimiento"; }
            if (this.EsValorInvalido(_FECHA)) { return "Falta el dato de fecha"; }
            if (this.EsValorInvalido(_ARTICULO)) { return "Falta el dato de articulo"; }
            if (this.EsValorInvalido(_CANTIDAD)) { return "Falta el dato de cantidad"; }
            return "";
        }
        public override void InicializarCampos()
        {
            _MOVIMIENTO = "";
            _TIPO_MOVIMIENTO = "";
            _FECHA = "";
            _ARTICULO = "";
            _CANTIDAD = "";
            Lista = null;
        }
    }
}



