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


    public class ComboINVENTARIO_FISICO_DETALLE : StringConverter
    {
        private static string[] mINVENTARIO_FISICO_DETALLE;
        public static bool Cargado = false;
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }
        public static string[] INVENTARIO_FISICO_DETALLE
        {
            get { return mINVENTARIO_FISICO_DETALLE; }
            set { mINVENTARIO_FISICO_DETALLE = value; Cargado = true; }
        }
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            return new StandardValuesCollection(mINVENTARIO_FISICO_DETALLE);
        }
        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return true;
        }

    }

    public class ConsultaINVENTARIO_FISICO_DETALLE : UITypeEditor
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
                                                 "Consulta de INVENTARIO_FISICO_DETALLE",
                                                 "SELECT INVENTARIO_FISICO_DETALLE,DESCRIPCION FROM INVENTARIO_FISICO_DETALLE",
                                                 vTextCampoLlave, 0, null,
                                                 new string[] { "ID", "DESCRIPCION" },
                                                 new int[] { 100, 300 });


                svc.ShowDialog(FormConsulta);
                value = vTextCampoLlave.Text;
            }
            return value;
        }
    }


    public class INVENTARIO_FISICO_DETALLE : BaseCode.DB_BASE, IvDB
    {
        public BaseCode.DB getvDB() { return DB; }
        #region Constructores
        public INVENTARIO_FISICO_DETALLE()
        {

        }
        public INVENTARIO_FISICO_DETALLE(BaseCode.DB vDB)
            : base(vDB, "INVENTARIO_FISICO_DETALLE", TipoInterAccionBD.Directa)
        {
            this.Compania = "dbo";
            this.CrearEstructura();
            this.InicializarCampos();
        }
        #endregion

        #region Variables Locales
        private string _ID_INVENTARIO;
        private string _ARTICULO;
        private string _SALDO_FISICO;
        private string _SALDO_RGISTRADO;
        #endregion

        #region Propiedades Originales
        [Browsable(false)]
        public string Id_inventario
        {
            get { return _ID_INVENTARIO; }
            set { _ID_INVENTARIO = value; }
        }
        [Browsable(false)]
        public string Articulo
        {
            get { return _ARTICULO; }
            set { _ARTICULO = value; }
        }
        [Browsable(false)]
        public string Saldo_fisico
        {
            get { return _SALDO_FISICO; }
            set { _SALDO_FISICO = value; }
        }
        [Browsable(false)]
        public string Saldo_rgistrado
        {
            get { return _SALDO_RGISTRADO; }
            set { _SALDO_RGISTRADO = value; }
        }
        #endregion

        #region Propiedades a Mostrar
        [Browsable(true)]
        //[TypeConverter(typeof(Combo))] 
        //[Editor(typeof(Consulta), typeof(UITypeEditor))]
        [CategoryAttribute("General"), DisplayName("0-Id_inventario"), DescriptionAttribute("Valor de Id_inventario"), ReadOnly(false)]

        public string _mID_INVENTARIO
        {
            get { return Id_inventario; }
            set { Id_inventario = value; }
        }
        [Browsable(true)]
        //[TypeConverter(typeof(Combo))] 
        //[Editor(typeof(Consulta), typeof(UITypeEditor))]
        [CategoryAttribute("General"), DisplayName("1-Articulo"), DescriptionAttribute("Valor de Articulo"), ReadOnly(false)]

        public string _mARTICULO
        {
            get { return Articulo; }
            set { Articulo = value; }
        }
        [Browsable(true)]
        //[TypeConverter(typeof(Combo))] 
        //[Editor(typeof(Consulta), typeof(UITypeEditor))]
        [CategoryAttribute("General"), DisplayName("2-Saldo_fisico"), DescriptionAttribute("Valor de Saldo_fisico"), ReadOnly(false)]

        public string _mSALDO_FISICO
        {
            get { return Saldo_fisico; }
            set { Saldo_fisico = value; }
        }
        [Browsable(true)]
        //[TypeConverter(typeof(Combo))] 
        //[Editor(typeof(Consulta), typeof(UITypeEditor))]
        [CategoryAttribute("General"), DisplayName("3-Saldo_rgistrado"), DescriptionAttribute("Valor de Saldo_rgistrado"), ReadOnly(false)]

        public string _mSALDO_RGISTRADO
        {
            get { return Saldo_rgistrado; }
            set { Saldo_rgistrado = value; }
        }
        #endregion


        public override string Validar()
        {

            if (this.EsValorInvalido(_ID_INVENTARIO)) { return "Falta el dato de id_inventario"; }
            if (this.EsValorInvalido(_ARTICULO)) { return "Falta el dato de articulo"; }
            if (this.EsValorInvalido(_SALDO_FISICO)) { return "Falta el dato de saldo_fisico"; }
            if (this.EsValorInvalido(_SALDO_RGISTRADO)) { return "Falta el dato de saldo_rgistrado"; }
            return "";
        }
        public override void InicializarCampos()
        {
            _ID_INVENTARIO = "";
            _ARTICULO = "";
            _SALDO_FISICO = "";
            _SALDO_RGISTRADO = "";
            Lista = null;
        }
    }
}



