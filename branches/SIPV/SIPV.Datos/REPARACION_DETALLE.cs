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


    public class ComboREPARACION_DETALLE : StringConverter
    {
        private static string[] mREPARACION_DETALLE;
        public static bool Cargado = false;
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }
        public static string[] REPARACION_DETALLE
        {
            get { return mREPARACION_DETALLE; }
            set { mREPARACION_DETALLE = value; Cargado = true; }
        }
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            return new StandardValuesCollection(mREPARACION_DETALLE);
        }
        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return true;
        }

    }

    public class ConsultaREPARACION_DETALLE : UITypeEditor
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
                                                 "Consulta de REPARACION_DETALLE",
                                                 "SELECT REPARACION_DETALLE,DESCRIPCION FROM REPARACION_DETALLE",
                                                 vTextCampoLlave, 0, null,
                                                 new string[] { "ID", "DESCRIPCION" },
                                                 new int[] { 100, 300 });


                svc.ShowDialog(FormConsulta);
                value = vTextCampoLlave.Text;
            }
            return value;
        }
    }


    public class REPARACION_DETALLE : BaseCode.DB_BASE, IvDB
    {
        public BaseCode.DB getvDB() { return DB; }
        #region Constructores
        public REPARACION_DETALLE()
        {

        }
        public REPARACION_DETALLE(BaseCode.DB vDB)
            : base(vDB, "REPARACION_DETALLE", TipoInterAccionBD.Directa)
        {
            this.Compania = "dbo";
            this.CrearEstructura();
            this.InicializarCampos();
        }
        #endregion

        #region Variables Locales
        private string _REPARACION;
        private string _LINEA;
        private string _ARTICULO;
        private string _DETALLE;
        private string _MOVIMIENTO_ENTRADA;
        private string _MOVIMIENTO_SALIDA;
        #endregion

        #region Propiedades Originales
        [Browsable(false)]
        public string Reparacion
        {
            get { return _REPARACION; }
            set { _REPARACION = value; }
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
        public string Detalle
        {
            get { return _DETALLE; }
            set { _DETALLE = value; }
        }
        [Browsable(false)]
        public string Movimiento_entrada
        {
            get { return _MOVIMIENTO_ENTRADA; }
            set { _MOVIMIENTO_ENTRADA = value; }
        }
        [Browsable(false)]
        public string Movimiento_salida
        {
            get { return _MOVIMIENTO_SALIDA; }
            set { _MOVIMIENTO_SALIDA = value; }
        }
        #endregion

        #region Propiedades a Mostrar
        [Browsable(true)]
        //[TypeConverter(typeof(Combo))] 
        //[Editor(typeof(Consulta), typeof(UITypeEditor))]
        [CategoryAttribute("General"), DisplayName("0-Reparacion"), DescriptionAttribute("Valor de Reparacion"), ReadOnly(false)]

        public string _mREPARACION
        {
            get { return Reparacion; }
            set { Reparacion = value; }
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
        [CategoryAttribute("General"), DisplayName("3-Detalle"), DescriptionAttribute("Valor de Detalle"), ReadOnly(false)]

        public string _mDETALLE
        {
            get { return Detalle; }
            set { Detalle = value; }
        }
        [Browsable(true)]
        //[TypeConverter(typeof(Combo))] 
        //[Editor(typeof(Consulta), typeof(UITypeEditor))]
        [CategoryAttribute("General"), DisplayName("4-Movimiento_entrada"), DescriptionAttribute("Valor de Movimiento_entrada"), ReadOnly(false)]

        public string _mMOVIMIENTO_ENTRADA
        {
            get { return Movimiento_entrada; }
            set { Movimiento_entrada = value; }
        }
        [Browsable(true)]
        //[TypeConverter(typeof(Combo))] 
        //[Editor(typeof(Consulta), typeof(UITypeEditor))]
        [CategoryAttribute("General"), DisplayName("5-Movimiento_salida"), DescriptionAttribute("Valor de Movimiento_salida"), ReadOnly(false)]

        public string _mMOVIMIENTO_SALIDA
        {
            get { return Movimiento_salida; }
            set { Movimiento_salida = value; }
        }
        #endregion


        public override string Validar()
        {

            if (this.EsValorInvalido(_REPARACION)) { return "Falta el dato de reparacion"; }
            if (this.EsValorInvalido(_LINEA)) { return "Falta el dato de linea"; }
            if (this.EsValorInvalido(_ARTICULO)) { return "Falta el dato de articulo"; }
            if (this.EsValorInvalido(_DETALLE)) { return "Falta el dato de detalle"; }
            if (this.EsValorInvalido(_MOVIMIENTO_ENTRADA)) { return "Falta el dato de movimiento_entrada"; }
            if (this.EsValorInvalido(_MOVIMIENTO_SALIDA)) { return "Falta el dato de movimiento_salida"; }
            return "";
        }
        public override void InicializarCampos()
        {
            _REPARACION = "";
            _LINEA = "";
            _ARTICULO = "";
            _DETALLE = "";
            _MOVIMIENTO_ENTRADA = "";
            _MOVIMIENTO_SALIDA = "";
            Lista = null;
        }
    }
}



