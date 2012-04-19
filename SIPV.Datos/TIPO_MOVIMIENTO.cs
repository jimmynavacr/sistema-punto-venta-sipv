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


    public class ComboTIPO_MOVIMIENTO : StringConverter
    {
        private static string[] mTIPO_MOVIMIENTO;
        public static bool Cargado = false;
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }
        public static string[] TIPO_MOVIMIENTO
        {
            get { return mTIPO_MOVIMIENTO; }
            set { mTIPO_MOVIMIENTO = value; Cargado = true; }
        }
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            return new StandardValuesCollection(mTIPO_MOVIMIENTO);
        }
        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return true;
        }

    }

    public class ConsultaTIPO_MOVIMIENTO : UITypeEditor
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
                                                 "Consulta de TIPO_MOVIMIENTO",
                                                 "SELECT TIPO_MOVIMIENTO,DESCRIPCION FROM TIPO_MOVIMIENTO",
                                                 vTextCampoLlave, 0, null,
                                                 new string[] { "ID", "DESCRIPCION" },
                                                 new int[] { 100, 300 });


                svc.ShowDialog(FormConsulta);
                value = vTextCampoLlave.Text;
            }
            return value;
        }
    }


    public class TIPO_MOVIMIENTO : BaseCode.DB_BASE, IvDB
    {
        public BaseCode.DB getvDB() { return DB; }
        #region Constructores
        public TIPO_MOVIMIENTO()
        {

        }
        public TIPO_MOVIMIENTO(BaseCode.DB vDB)
            : base(vDB, "TIPO_MOVIMIENTO", TipoInterAccionBD.Directa)
        {
            this.Compania = "dbo";
            this.CrearEstructura();
            this.InicializarCampos();
        }
        #endregion

        #region Variables Locales
        private string _TIPO_MOVIMIENTO;
        private string _DESCRIPCION;
        private string _INGRESO_EGRESO;
        #endregion

        #region Propiedades Originales
        [Browsable(false)]
        public string Tipo_movimiento
        {
            get { return _TIPO_MOVIMIENTO; }
            set { _TIPO_MOVIMIENTO = value; }
        }
        [Browsable(false)]
        public string Descripcion
        {
            get { return _DESCRIPCION; }
            set { _DESCRIPCION = value; }
        }
        [Browsable(false)]
        public string Ingreso_egreso
        {
            get { return _INGRESO_EGRESO; }
            set { _INGRESO_EGRESO = value; }
        }
        #endregion

        #region Propiedades a Mostrar
        [Browsable(true)]
        //[TypeConverter(typeof(Combo))] 
        //[Editor(typeof(Consulta), typeof(UITypeEditor))]
        [CategoryAttribute("General"), DisplayName("0-Tipo_movimiento"), DescriptionAttribute("Valor de Tipo_movimiento"), ReadOnly(false)]

        public string _mTIPO_MOVIMIENTO
        {
            get { return Tipo_movimiento; }
            set { Tipo_movimiento = value; }
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
        [Browsable(true)]
        //[TypeConverter(typeof(Combo))] 
        //[Editor(typeof(Consulta), typeof(UITypeEditor))]
        [CategoryAttribute("General"), DisplayName("2-Ingreso_egreso"), DescriptionAttribute("Valor de Ingreso_egreso"), ReadOnly(false)]

        public string _mINGRESO_EGRESO
        {
            get { return Ingreso_egreso; }
            set { Ingreso_egreso = value; }
        }
        #endregion


        public override string Validar()
        {

            if (this.EsValorInvalido(_TIPO_MOVIMIENTO)) { return "Falta el dato de tipo_movimiento"; }
            if (this.EsValorInvalido(_DESCRIPCION)) { return "Falta el dato de descripcion"; }
            if (this.EsValorInvalido(_INGRESO_EGRESO)) { return "Falta el dato de ingreso_egreso"; }
            return "";
        }
        public override void InicializarCampos()
        {
            _TIPO_MOVIMIENTO = "";
            _DESCRIPCION = "";
            _INGRESO_EGRESO = "";
            Lista = null;
        }
    }
}



