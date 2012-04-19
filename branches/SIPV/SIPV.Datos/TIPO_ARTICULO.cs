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


    public class ComboTIPO_ARTICULO : StringConverter
    {
        private static string[] mTIPO_ARTICULO;
        public static bool Cargado = false;
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }
        public static string[] TIPO_ARTICULO
        {
            get { return mTIPO_ARTICULO; }
            set { mTIPO_ARTICULO = value; Cargado = true; }
        }
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            return new StandardValuesCollection(mTIPO_ARTICULO);
        }
        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return true;
        }

    }

    public class ConsultaTIPO_ARTICULO : UITypeEditor
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
                                                 "Consulta de TIPO_ARTICULO",
                                                 "SELECT TIPO_ARTICULO,DESCRIPCION FROM TIPO_ARTICULO",
                                                 vTextCampoLlave, 0, null,
                                                 new string[] { "ID", "DESCRIPCION" },
                                                 new int[] { 100, 300 });


                svc.ShowDialog(FormConsulta);
                value = vTextCampoLlave.Text;
            }
            return value;
        }
    }


    public class TIPO_ARTICULO : BaseCode.DB_BASE, IvDB
    {
        public BaseCode.DB getvDB() { return DB; }
        #region Constructores
        public TIPO_ARTICULO()
        {

        }
        public TIPO_ARTICULO(BaseCode.DB vDB)
            : base(vDB, "TIPO_ARTICULO", TipoInterAccionBD.Directa)
        {
            this.Compania = "dbo";
            this.CrearEstructura();
            this.InicializarCampos();
        }
        #endregion

        #region Variables Locales
        private string _TIPO_ARTICULO;
        private string _DESCRIPCION;
        #endregion

        #region Propiedades Originales
        [Browsable(false)]
        public string Tipo_articulo
        {
            get { return _TIPO_ARTICULO; }
            set { _TIPO_ARTICULO = value; }
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
        [CategoryAttribute("General"), DisplayName("0-Tipo_articulo"), DescriptionAttribute("Valor de Tipo_articulo"), ReadOnly(false)]

        public string _mTIPO_ARTICULO
        {
            get { return Tipo_articulo; }
            set { Tipo_articulo = value; }
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

            if (this.EsValorInvalido(_TIPO_ARTICULO)) { return "Falta el dato de tipo_articulo"; }
            if (this.EsValorInvalido(_DESCRIPCION)) { return "Falta el dato de descripcion"; }
            return "";
        }
        public override void InicializarCampos()
        {
            _TIPO_ARTICULO = "";
            _DESCRIPCION = "";
            Lista = null;
        }
    }
}



