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


    public class ComboABONO_APARTADO : StringConverter
    {
        private static string[] mABONO_APARTADO;
        public static bool Cargado = false;
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }
        public static string[] ABONO_APARTADO
        {
            get { return mABONO_APARTADO; }
            set { mABONO_APARTADO = value; Cargado = true; }
        }
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            return new StandardValuesCollection(mABONO_APARTADO);
        }
        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return true;
        }

    }

    public class ConsultaABONO_APARTADO : UITypeEditor
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
                                                 "Consulta de ABONO_APARTADO",
                                                 "SELECT ABONO_APARTADO,DESCRIPCION FROM ABONO_APARTADO",
                                                 vTextCampoLlave, 0, null,
                                                 new string[] { "ID", "DESCRIPCION" },
                                                 new int[] { 100, 300 });


                svc.ShowDialog(FormConsulta);
                value = vTextCampoLlave.Text;
            }
            return value;
        }
    }


    public class ABONO_APARTADO : BaseCode.DB_BASE, IvDB
    {
        public BaseCode.DB getvDB() { return DB; }
        #region Constructores
        public ABONO_APARTADO()
        {

        }
        public ABONO_APARTADO(BaseCode.DB vDB)
            : base(vDB, "ABONO_APARTADO", TipoInterAccionBD.Directa)
        {
            this.Compania = "dbo";
            this.CrearEstructura();
            this.InicializarCampos();
        }
        #endregion

        #region Variables Locales
        private string _APARTADO;
        private string _FECHA;
        private string _MONTO;
        #endregion

        #region Propiedades Originales
        [Browsable(false)]
        public string Apartado
        {
            get { return _APARTADO; }
            set { _APARTADO = value; }
        }
        [Browsable(false)]
        public string Fecha
        {
            get { return _FECHA; }
            set { _FECHA = value; }
        }
        [Browsable(false)]
        public string Monto
        {
            get { return _MONTO; }
            set { _MONTO = value; }
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
        [CategoryAttribute("General"), DisplayName("1-Fecha"), DescriptionAttribute("Valor de Fecha"), ReadOnly(false)]

        public string _mFECHA
        {
            get { return Fecha; }
            set { Fecha = value; }
        }
        [Browsable(true)]
        //[TypeConverter(typeof(Combo))] 
        //[Editor(typeof(Consulta), typeof(UITypeEditor))]
        [CategoryAttribute("General"), DisplayName("2-Monto"), DescriptionAttribute("Valor de Monto"), ReadOnly(false)]

        public string _mMONTO
        {
            get { return Monto; }
            set { Monto = value; }
        }
        #endregion


        public override string Validar()
        {

            if (this.EsValorInvalido(_APARTADO)) { return "Falta el dato de apartado"; }
            if (this.EsValorInvalido(_FECHA)) { return "Falta el dato de fecha"; }
            if (this.EsValorInvalido(_MONTO)) { return "Falta el dato de monto"; }
            return "";
        }
        public override void InicializarCampos()
        {
            _APARTADO = "";
            _FECHA = "";
            _MONTO = "";
            Lista = null;
        }
    }
}



