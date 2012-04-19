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


    public class ComboCOMPRA : StringConverter
    {
        private static string[] mCOMPRA;
        public static bool Cargado = false;
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }
        public static string[] COMPRA
        {
            get { return mCOMPRA; }
            set { mCOMPRA = value; Cargado = true; }
        }
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            return new StandardValuesCollection(mCOMPRA);
        }
        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return true;
        }

    }

    public class ConsultaCOMPRA : UITypeEditor
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
                                                 "Consulta de COMPRA",
                                                 "SELECT COMPRA,DESCRIPCION FROM COMPRA",
                                                 vTextCampoLlave, 0, null,
                                                 new string[] { "ID", "DESCRIPCION" },
                                                 new int[] { 100, 300 });


                svc.ShowDialog(FormConsulta);
                value = vTextCampoLlave.Text;
            }
            return value;
        }
    }


    public class COMPRA : BaseCode.DB_BASE, IvDB
    {
        public BaseCode.DB getvDB() { return DB; }
        #region Constructores
        public COMPRA()
        {

        }
        public COMPRA(BaseCode.DB vDB)
            : base(vDB, "COMPRA", TipoInterAccionBD.Directa)
        {
            this.Compania = "dbo";
            this.CrearEstructura();
            this.InicializarCampos();
        }
        #endregion

        #region Variables Locales
        private string _COMPRA;
        private string _PROVEEDOR;
        private string _EMPLEADO;
        private string _FECHA;
        #endregion

        #region Propiedades Originales
        [Browsable(false)]
        public string Compra
        {
            get { return _COMPRA; }
            set { _COMPRA = value; }
        }
        [Browsable(false)]
        public string Proveedor
        {
            get { return _PROVEEDOR; }
            set { _PROVEEDOR = value; }
        }
        [Browsable(false)]
        public string Empleado
        {
            get { return _EMPLEADO; }
            set { _EMPLEADO = value; }
        }
        [Browsable(false)]
        public string Fecha
        {
            get { return _FECHA; }
            set { _FECHA = value; }
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
        [CategoryAttribute("General"), DisplayName("1-Proveedor"), DescriptionAttribute("Valor de Proveedor"), ReadOnly(false)]

        public string _mPROVEEDOR
        {
            get { return Proveedor; }
            set { Proveedor = value; }
        }
        [Browsable(true)]
        //[TypeConverter(typeof(Combo))] 
        //[Editor(typeof(Consulta), typeof(UITypeEditor))]
        [CategoryAttribute("General"), DisplayName("2-Empleado"), DescriptionAttribute("Valor de Empleado"), ReadOnly(false)]

        public string _mEMPLEADO
        {
            get { return Empleado; }
            set { Empleado = value; }
        }
        [Browsable(true)]
        //[TypeConverter(typeof(Combo))] 
        //[Editor(typeof(Consulta), typeof(UITypeEditor))]
        [CategoryAttribute("General"), DisplayName("3-Fecha"), DescriptionAttribute("Valor de Fecha"), ReadOnly(false)]

        public string _mFECHA
        {
            get { return Fecha; }
            set { Fecha = value; }
        }
        #endregion


        public override string Validar()
        {

            if (this.EsValorInvalido(_COMPRA)) { return "Falta el dato de compra"; }
            if (this.EsValorInvalido(_PROVEEDOR)) { return "Falta el dato de proveedor"; }
            if (this.EsValorInvalido(_EMPLEADO)) { return "Falta el dato de empleado"; }
            if (this.EsValorInvalido(_FECHA)) { return "Falta el dato de fecha"; }
            return "";
        }
        public override void InicializarCampos()
        {
            _COMPRA = "";
            _PROVEEDOR = "";
            _EMPLEADO = "";
            _FECHA = "";
            Lista = null;
        }
    }
}



