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


    public class ComboFORMA_PAGO : StringConverter
    {
        private static string[] mFORMA_PAGO;
        public static bool Cargado = false;
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }
        public static string[] FORMA_PAGO
        {
            get { return mFORMA_PAGO; }
            set { mFORMA_PAGO = value; Cargado = true; }
        }
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            return new StandardValuesCollection(mFORMA_PAGO);
        }
        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return true;
        }

    }

    public class ConsultaFORMA_PAGO : UITypeEditor
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
                                                 "Consulta de FORMA_PAGO",
                                                 "SELECT FORMA_PAGO,DESCRIPCION FROM FORMA_PAGO",
                                                 vTextCampoLlave, 0, null,
                                                 new string[] { "ID", "DESCRIPCION" },
                                                 new int[] { 100, 300 });


                svc.ShowDialog(FormConsulta);
                value = vTextCampoLlave.Text;
            }
            return value;
        }
    }


    public class FORMA_PAGO : BaseCode.DB_BASE, IvDB
    {
        public BaseCode.DB getvDB() { return DB; }
        #region Constructores
        public FORMA_PAGO()
        {

        }
        public FORMA_PAGO(BaseCode.DB vDB)
            : base(vDB, "FORMA_PAGO", TipoInterAccionBD.Directa)
        {
            this.Compania = "dbo";
            this.CrearEstructura();
            this.InicializarCampos();
        }
        #endregion

        #region Variables Locales
        private string _FORMA_PAGO;
        private string _DESCRIPCION;
        #endregion

        #region Propiedades Originales
        [Browsable(false)]
        public string Forma_pago
        {
            get { return _FORMA_PAGO; }
            set { _FORMA_PAGO = value; }
        }
        [Browsable(false)]
        public string Descripcion
        {
            get { return _DESCRIPCION; }
            set { _DESCRIPCION = value; }
        }
        #endregion

        #region Propiedades a Mostrar
        [Browsable(true)]
        //[TypeConverter(typeof(Combo))] 
        //[Editor(typeof(Consulta), typeof(UITypeEditor))]
        [CategoryAttribute("General"), DisplayName("0-Forma_pago"), DescriptionAttribute("Valor de Forma_pago"), ReadOnly(false)]

        public string _mFORMA_PAGO
        {
            get { return Forma_pago; }
            set { Forma_pago = value; }
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
        #endregion


        public override string Validar()
        {

            if (this.EsValorInvalido(_FORMA_PAGO)) { return "Falta el dato de forma_pago"; }
            if (this.EsValorInvalido(_DESCRIPCION)) { return "Falta el dato de descripcion"; }
            return "";
        }
        public override void InicializarCampos()
        {
            _FORMA_PAGO = "";
            _DESCRIPCION = "";
            Lista = null;
        }
    }
}



