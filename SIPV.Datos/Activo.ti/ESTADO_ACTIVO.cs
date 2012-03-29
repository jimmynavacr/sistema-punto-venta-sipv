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


    public class ComboESTADO_ACTIVO : StringConverter
    {
        private static string[] mESTADO_ACTIVO;
        public static bool Cargado = false;
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }
        public static string[] ESTADO_ACTIVO
        {
            get { return mESTADO_ACTIVO; }
            set { mESTADO_ACTIVO = value; Cargado = true; }
        }
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            return new StandardValuesCollection(mESTADO_ACTIVO);
        }
        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return true;
        }

    }


    public class ESTADO_ACTIVO : BaseCode.DB_BASE
    {
        #region Constructores
        public ESTADO_ACTIVO()
        {

        }
        public ESTADO_ACTIVO(BaseCode.DB vDB)
            : base(vDB, "ESTADO_ACTIVO", TipoInterAccionBD.Directa)
        {
            this.Compania = "dbo";
            this.CrearEstructura();
            this.InicializarCampos();
        }
        #endregion

        #region Variables Locales
        private string _ESTADO_ACTIVO;
        private string _DESCRIPCION;
        #endregion

        #region Propiedades Originales
        [Browsable(false)]
        public string Estado_activo
        {
            get { return _ESTADO_ACTIVO; }
            set { _ESTADO_ACTIVO = value; }
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
        [CategoryAttribute("General"), DisplayName("0-Id"), DescriptionAttribute("Id del estado de activo"), ReadOnly(false)]

        public string _mESTADO_ACTIVO
        {
            get { return Estado_activo; }
            set { Estado_activo = value; }
        }
        [Browsable(true)]
        //[TypeConverter(typeof(Combo))] 
        //[Editor(typeof(Consulta), typeof(UITypeEditor))]
        [CategoryAttribute("General"), DisplayName("1-Descripción"), DescriptionAttribute("Descrición del estado de activo"), ReadOnly(false)]

        public string _mDESCRIPCION
        {
            get { return Descripcion; }
            set { Descripcion = value; }
        }
        #endregion


        public override string Validar()
        {

            if (this.EsValorInvalido(_ESTADO_ACTIVO)) { return "Falta el dato de id estado activo"; }
            if (this.EsValorInvalido(_DESCRIPCION)) { return "Falta el dato de descripción"; }
            return "";
        }
        public override void InicializarCampos()
        {
            _ESTADO_ACTIVO = "";
            _DESCRIPCION = "";
            Lista = null;
        }
    }
}
