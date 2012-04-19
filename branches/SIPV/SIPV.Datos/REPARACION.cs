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


    public class ComboREPARACION : StringConverter
    {
        private static string[] mREPARACION;
        public static bool Cargado = false;
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }
        public static string[] REPARACION
        {
            get { return mREPARACION; }
            set { mREPARACION = value; Cargado = true; }
        }
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            return new StandardValuesCollection(mREPARACION);
        }
        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return true;
        }

    }

    public class ConsultaREPARACION : UITypeEditor
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
                                                 "Consulta de REPARACION",
                                                 "SELECT REPARACION,DESCRIPCION FROM REPARACION",
                                                 vTextCampoLlave, 0, null,
                                                 new string[] { "ID", "DESCRIPCION" },
                                                 new int[] { 100, 300 });


                svc.ShowDialog(FormConsulta);
                value = vTextCampoLlave.Text;
            }
            return value;
        }
    }


    public class REPARACION : BaseCode.DB_BASE, IvDB
    {
        public BaseCode.DB getvDB() { return DB; }
        #region Constructores
        public REPARACION()
        {

        }
        public REPARACION(BaseCode.DB vDB)
            : base(vDB, "REPARACION", TipoInterAccionBD.Directa)
        {
            this.Compania = "dbo";
            this.CrearEstructura();
            this.InicializarCampos();
        }
        #endregion

        #region Variables Locales
        private string _REPARACION;
        private string _FECHA;
        private string _CLIENTE;
        private string _EMPLEADO;
        #endregion

        #region Propiedades Originales
        [Browsable(false)]
        public string Reparacion
        {
            get { return _REPARACION; }
            set { _REPARACION = value; }
        }
        [Browsable(false)]
        public string Fecha
        {
            get { return _FECHA; }
            set { _FECHA = value; }
        }
        [Browsable(false)]
        public string Cliente
        {
            get { return _CLIENTE; }
            set { _CLIENTE = value; }
        }
        [Browsable(false)]
        public string Empleado
        {
            get { return _EMPLEADO; }
            set { _EMPLEADO = value; }
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
        [CategoryAttribute("General"), DisplayName("1-Fecha"), DescriptionAttribute("Valor de Fecha"), ReadOnly(false)]

        public string _mFECHA
        {
            get { return Fecha; }
            set { Fecha = value; }
        }
        [Browsable(true)]
        //[TypeConverter(typeof(Combo))] 
        //[Editor(typeof(Consulta), typeof(UITypeEditor))]
        [CategoryAttribute("General"), DisplayName("2-Cliente"), DescriptionAttribute("Valor de Cliente"), ReadOnly(false)]

        public string _mCLIENTE
        {
            get { return Cliente; }
            set { Cliente = value; }
        }
        [Browsable(true)]
        //[TypeConverter(typeof(Combo))] 
        //[Editor(typeof(Consulta), typeof(UITypeEditor))]
        [CategoryAttribute("General"), DisplayName("3-Empleado"), DescriptionAttribute("Valor de Empleado"), ReadOnly(false)]

        public string _mEMPLEADO
        {
            get { return Empleado; }
            set { Empleado = value; }
        }
        #endregion


        public override string Validar()
        {

            if (this.EsValorInvalido(_REPARACION)) { return "Falta el dato de reparacion"; }
            if (this.EsValorInvalido(_FECHA)) { return "Falta el dato de fecha"; }
            if (this.EsValorInvalido(_CLIENTE)) { return "Falta el dato de cliente"; }
            if (this.EsValorInvalido(_EMPLEADO)) { return "Falta el dato de empleado"; }
            return "";
        }
        public override void InicializarCampos()
        {
            _REPARACION = "";
            _FECHA = "";
            _CLIENTE = "";
            _EMPLEADO = "";
            Lista = null;
        }
    }
}



