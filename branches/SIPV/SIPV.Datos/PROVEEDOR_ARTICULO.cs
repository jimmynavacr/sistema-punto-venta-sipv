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


    public class ComboPROVEEDOR_ARTICULO : StringConverter
    {
        private static string[] mPROVEEDOR_ARTICULO;
        public static bool Cargado = false;
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }
        public static string[] PROVEEDOR_ARTICULO
        {
            get { return mPROVEEDOR_ARTICULO; }
            set { mPROVEEDOR_ARTICULO = value; Cargado = true; }
        }
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            return new StandardValuesCollection(mPROVEEDOR_ARTICULO);
        }
        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return true;
        }

    }

    public class ConsultaPROVEEDOR_ARTICULO : UITypeEditor
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
                                                 "Consulta de PROVEEDOR_ARTICULO",
                                                 "SELECT PROVEEDOR_ARTICULO,DESCRIPCION FROM PROVEEDOR_ARTICULO",
                                                 vTextCampoLlave, 0, null,
                                                 new string[] { "ID", "DESCRIPCION" },
                                                 new int[] { 100, 300 });


                svc.ShowDialog(FormConsulta);
                value = vTextCampoLlave.Text;
            }
            return value;
        }
    }


    public class PROVEEDOR_ARTICULO : BaseCode.DB_BASE, IvDB
    {
        public BaseCode.DB getvDB() { return DB; }
        #region Constructores
        public PROVEEDOR_ARTICULO()
        {

        }
        public PROVEEDOR_ARTICULO(BaseCode.DB vDB)
            : base(vDB, "PROVEEDOR_ARTICULO", TipoInterAccionBD.Directa)
        {
            this.Compania = "dbo";
            this.CrearEstructura();
            this.InicializarCampos();
        }
        #endregion

        #region Variables Locales
        private string _PROVEEDOR;
        private string _ARTICULO;
        #endregion

        #region Propiedades Originales
        [Browsable(false)]
        public string Proveedor
        {
            get { return _PROVEEDOR; }
            set { _PROVEEDOR = value; }
        }
        [Browsable(false)]
        public string Articulo
        {
            get { return _ARTICULO; }
            set { _ARTICULO = value; }
        }
        #endregion

        #region Propiedades a Mostrar
        [Browsable(true)]
        //[TypeConverter(typeof(Combo))] 
        //[Editor(typeof(Consulta), typeof(UITypeEditor))]
        [CategoryAttribute("General"), DisplayName("0-Proveedor"), DescriptionAttribute("Valor de Proveedor"), ReadOnly(false)]

        public string _mPROVEEDOR
        {
            get { return Proveedor; }
            set { Proveedor = value; }
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
        #endregion


        public override string Validar()
        {

            if (this.EsValorInvalido(_PROVEEDOR)) { return "Falta el dato de proveedor"; }
            if (this.EsValorInvalido(_ARTICULO)) { return "Falta el dato de articulo"; }
            return "";
        }
        public override void InicializarCampos()
        {
            _PROVEEDOR = "";
            _ARTICULO = "";
            Lista = null;
        }
    }
}



