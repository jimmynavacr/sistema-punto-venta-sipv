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


    public class ComboINVENTARIO_FISICO : StringConverter
    {
        private static string[] mINVENTARIO_FISICO;
        public static bool Cargado = false;
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }
        public static string[] INVENTARIO_FISICO
        {
            get { return mINVENTARIO_FISICO; }
            set { mINVENTARIO_FISICO = value; Cargado = true; }
        }
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            return new StandardValuesCollection(mINVENTARIO_FISICO);
        }
        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return true;
        }

    }

    public class ConsultaINVENTARIO_FISICO : UITypeEditor
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
                                                 "Consulta de INVENTARIO_FISICO",
                                                 "SELECT INVENTARIO_FISICO,DESCRIPCION FROM INVENTARIO_FISICO",
                                                 vTextCampoLlave, 0, null,
                                                 new string[] { "ID", "DESCRIPCION" },
                                                 new int[] { 100, 300 });


                svc.ShowDialog(FormConsulta);
                value = vTextCampoLlave.Text;
            }
            return value;
        }
    }


    public class INVENTARIO_FISICO : BaseCode.DB_BASE, IvDB
    {
        public BaseCode.DB getvDB() { return DB; }
        #region Constructores
        public INVENTARIO_FISICO()
        {

        }
        public INVENTARIO_FISICO(BaseCode.DB vDB)
            : base(vDB, "INVENTARIO_FISICO", TipoInterAccionBD.Directa)
        {
            this.Compania = "dbo";
            this.CrearEstructura();
            this.InicializarCampos();
        }
        #endregion

        #region Variables Locales
        private string _ID_INVENTARIO;
        private string _FECHA;
        private string _RESPONSABLE;
        #endregion

        #region Propiedades Originales
        [Browsable(false)]
        public string Id_inventario
        {
            get { return _ID_INVENTARIO; }
            set { _ID_INVENTARIO = value; }
        }
        [Browsable(false)]
        public string Fecha
        {
            get { return _FECHA; }
            set { _FECHA = value; }
        }
        [Browsable(false)]
        public string Responsable
        {
            get { return _RESPONSABLE; }
            set { _RESPONSABLE = value; }
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
        [CategoryAttribute("General"), DisplayName("1-Fecha"), DescriptionAttribute("Valor de Fecha"), ReadOnly(false)]

        public string _mFECHA
        {
            get { return Fecha; }
            set { Fecha = value; }
        }
        [Browsable(true)]
        //[TypeConverter(typeof(Combo))] 
        //[Editor(typeof(Consulta), typeof(UITypeEditor))]
        [CategoryAttribute("General"), DisplayName("2-Responsable"), DescriptionAttribute("Valor de Responsable"), ReadOnly(false)]

        public string _mRESPONSABLE
        {
            get { return Responsable; }
            set { Responsable = value; }
        }
        #endregion


        public override string Validar()
        {

            if (this.EsValorInvalido(_ID_INVENTARIO)) { return "Falta el dato de id_inventario"; }
            if (this.EsValorInvalido(_FECHA)) { return "Falta el dato de fecha"; }
            if (this.EsValorInvalido(_RESPONSABLE)) { return "Falta el dato de responsable"; }
            return "";
        }
        public override void InicializarCampos()
        {
            _ID_INVENTARIO = "";
            _FECHA = "";
            _RESPONSABLE = "";
            Lista = null;
        }
    }
}



