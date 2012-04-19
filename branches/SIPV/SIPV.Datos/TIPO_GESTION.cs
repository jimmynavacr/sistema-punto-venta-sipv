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


    public class ComboTIPO_GESTION : StringConverter
    {
        private static string[] mTIPO_GESTION;
        public static bool Cargado = false;
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }
        public static string[] TIPO_GESTION
        {
            get { return mTIPO_GESTION; }
            set { mTIPO_GESTION = value; Cargado = true; }
        }
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            return new StandardValuesCollection(mTIPO_GESTION);
        }
        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return true;
        }

    }

    public class ConsultaTIPO_GESTION : UITypeEditor
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
                                                 "Consulta de TIPO_GESTION",
                                                 "SELECT TIPO_GESTION,DESCRIPCION FROM TIPO_GESTION",
                                                 vTextCampoLlave, 0, null,
                                                 new string[] { "ID", "DESCRIPCION" },
                                                 new int[] { 100, 300 });


                svc.ShowDialog(FormConsulta);
                value = vTextCampoLlave.Text;
            }
            return value;
        }
    }


    public class TIPO_GESTION : BaseCode.DB_BASE, IvDB
    {
        public BaseCode.DB getvDB() { return DB; }
        #region Constructores
        public TIPO_GESTION()
        {

        }
        public TIPO_GESTION(BaseCode.DB vDB)
            : base(vDB, "TIPO_GESTION", TipoInterAccionBD.Directa)
        {
            this.Compania = "dbo";
            this.CrearEstructura();
            this.InicializarCampos();
        }
        #endregion

        #region Variables Locales
        private string _TIPO_GESTION;
        private string _DESCRIPCION;
        #endregion

        #region Propiedades Originales
        [Browsable(false)]
        public string Tipo_gestion
        {
            get { return _TIPO_GESTION; }
            set { _TIPO_GESTION = value; }
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
        [CategoryAttribute("General"), DisplayName("0-Tipo_gestion"), DescriptionAttribute("Valor de Tipo_gestion"), ReadOnly(false)]

        public string _mTIPO_GESTION
        {
            get { return Tipo_gestion; }
            set { Tipo_gestion = value; }
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

            if (this.EsValorInvalido(_TIPO_GESTION)) { return "Falta el dato de tipo_gestion"; }
            if (this.EsValorInvalido(_DESCRIPCION)) { return "Falta el dato de descripcion"; }
            return "";
        }
        public override void InicializarCampos()
        {
            _TIPO_GESTION = "";
            _DESCRIPCION = "";
            Lista = null;
        }
    }
}



