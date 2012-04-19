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


    public class ComboAPARTADO : StringConverter
    {
        private static string[] mAPARTADO;
        public static bool Cargado = false;
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }
        public static string[] APARTADO
        {
            get { return mAPARTADO; }
            set { mAPARTADO = value; Cargado = true; }
        }
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            return new StandardValuesCollection(mAPARTADO);
        }
        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return true;
        }

    }

    public class ConsultaAPARTADO : UITypeEditor
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
                                                 "Consulta de APARTADO",
                                                 "SELECT APARTADO,DESCRIPCION FROM APARTADO",
                                                 vTextCampoLlave, 0, null,
                                                 new string[] { "ID", "DESCRIPCION" },
                                                 new int[] { 100, 300 });


                svc.ShowDialog(FormConsulta);
                value = vTextCampoLlave.Text;
            }
            return value;
        }
    }


    public class APARTADO : BaseCode.DB_BASE, IvDB
    {
        public BaseCode.DB getvDB() { return DB; }
        #region Constructores
        public APARTADO()
        {

        }
        public APARTADO(BaseCode.DB vDB)
            : base(vDB, "APARTADO", TipoInterAccionBD.Directa)
        {
            this.Compania = "dbo";
            this.CrearEstructura();
            this.InicializarCampos();
        }
        #endregion

        #region Variables Locales
        private string _APARTADO;
        private string _EMPLEADO;
        private string _FECHA;
        private string _VENCIMIENTO;
        private string _FACTURA;
        #endregion

        #region Propiedades Originales
        [Browsable(false)]
        public string Apartado
        {
            get { return _APARTADO; }
            set { _APARTADO = value; }
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
        [Browsable(false)]
        public string Vencimiento
        {
            get { return _VENCIMIENTO; }
            set { _VENCIMIENTO = value; }
        }
        [Browsable(false)]
        public string Factura
        {
            get { return _FACTURA; }
            set { _FACTURA = value; }
        }
        #endregion

        #region Propiedades a Mostrar
        [Browsable(true)]
        //[TypeConverter(typeof(Combo))] 
        //[Editor(typeof(Consulta), typeof(UITypeEditor))]
        [CategoryAttribute("General"), DisplayName("0-Apartado"), DescriptionAttribute("Valor de Apartado"), ReadOnly(false)]

        public string _mAPARTADO
        {
            get { return Apartado; }
            set { Apartado = value; }
        }
        [Browsable(true)]
        //[TypeConverter(typeof(Combo))] 
        //[Editor(typeof(Consulta), typeof(UITypeEditor))]
        [CategoryAttribute("General"), DisplayName("1-Empleado"), DescriptionAttribute("Valor de Empleado"), ReadOnly(false)]

        public string _mEMPLEADO
        {
            get { return Empleado; }
            set { Empleado = value; }
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
        [CategoryAttribute("General"), DisplayName("3-Vencimiento"), DescriptionAttribute("Valor de Vencimiento"), ReadOnly(false)]

        public string _mVENCIMIENTO
        {
            get { return Vencimiento; }
            set { Vencimiento = value; }
        }
        [Browsable(true)]
        //[TypeConverter(typeof(Combo))] 
        //[Editor(typeof(Consulta), typeof(UITypeEditor))]
        [CategoryAttribute("General"), DisplayName("4-Factura"), DescriptionAttribute("Valor de Factura"), ReadOnly(false)]

        public string _mFACTURA
        {
            get { return Factura; }
            set { Factura = value; }
        }
        #endregion


        public override string Validar()
        {

            if (this.EsValorInvalido(_APARTADO)) { return "Falta el dato de apartado"; }
            if (this.EsValorInvalido(_EMPLEADO)) { return "Falta el dato de empleado"; }
            if (this.EsValorInvalido(_FECHA)) { return "Falta el dato de fecha"; }
            if (this.EsValorInvalido(_VENCIMIENTO)) { return "Falta el dato de vencimiento"; }
            if (this.EsValorInvalido(_FACTURA)) { return "Falta el dato de factura"; }
            return "";
        }
        public override void InicializarCampos()
        {
            _APARTADO = "";
            _EMPLEADO = "";
            _FECHA = "";
            _VENCIMIENTO = "";
            _FACTURA = "";
            Lista = null;
        }
    }
}



