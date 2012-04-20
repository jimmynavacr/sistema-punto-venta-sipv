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


    public class ComboVENTA : StringConverter
    {
        private static string[] mVENTA;
        public static bool Cargado = false;
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }
        public static string[] VENTA
        {
            get { return mVENTA; }
            set { mVENTA = value; Cargado = true; }
        }
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            return new StandardValuesCollection(mVENTA);
        }
        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return true;
        }

    }

    public class ConsultaVENTA : UITypeEditor
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
                                                 "Consulta de VENTA",
                                                 "SELECT VENTA,DESCRIPCION FROM VENTA",
                                                 vTextCampoLlave, 0, null,
                                                 new string[] { "ID", "DESCRIPCION" },
                                                 new int[] { 100, 300 });


                svc.ShowDialog(FormConsulta);
                value = vTextCampoLlave.Text;
            }
            return value;
        }
    }


    public class VENTA : BaseCode.DB_BASE, IvDB
    {
        public BaseCode.DB getvDB() { return DB; }
        #region Constructores
        public VENTA()
        {

        }
        public VENTA(BaseCode.DB vDB)
            : base(vDB, "VENTA", TipoInterAccionBD.Directa)
        {
            this.Compania = "dbo";
            this.CrearEstructura();
            this.InicializarCampos();

            this.DatosCargadosDesdeBD += new DatosCargadosDesdeBDEventHandler(this.VENTA_DatosCargadosDesdeBD);
            this.DatosLimpiados += new DatosLimpiadosEventHandler(this.VENTA_DatosLimpiados);
            this.AntesOperacion += new OperacionEventHandler(this.VENTA_AntesOperacion);
            _ARTICULOS= new VENTA_DETALLE(DB, this.Venta );


            if (!ComboFORMA_PAGO.Cargado)
            {
                ComboFORMA_PAGO.FORMA_PAGO = DB.ArrayDesdeTablaCodigoDescripcion(DB, "FORMA_PAGO", "FORMA_PAGO", "Descripcion");
            }
        }
        #endregion

        #region Variables Locales
        private string _VENTA;
        private string _FECHA;
        private string _VENDEDOR;
        private string _VENDEDOR_DESCRIPCION;
        private string _CLIENTE;
        private string _CLIENTE_DESCRIPCION;
        private string _FORMA_PAGO;
        private string _FORMA_PAGO_DESCRIPCION;
        #endregion

        #region Propiedades Originales
        [Browsable(false)]
        public string Venta
        {
            get { return _VENTA; }
            set { _VENTA = value; }
        }
        [Browsable(false)]
        public string Fecha
        {
            get { return _FECHA; }
            set { _FECHA = value; }
        }
        [Browsable(false)]
        public string Vendedor
        {
            get { return _VENDEDOR; }
            set { _VENDEDOR = value;
            _VENDEDOR_DESCRIPCION = DB.Sub_Datar_DT("ENTIDAD ", "ENTIDAD ", "DESCRIPCION", _VENDEDOR);
            }
        }
        [Browsable(false)]
        public string Cliente
        {
            get { return _CLIENTE; }
            set { _CLIENTE = value;
            _CLIENTE_DESCRIPCION = DB.Sub_Datar_DT("ENTIDAD ", "ENTIDAD ", "DESCRIPCION", _CLIENTE);
            }
        }
        [Browsable(false)]
        public string Forma_pago
        {
            get { return _FORMA_PAGO; }
            set { _FORMA_PAGO = value;
            _FORMA_PAGO_DESCRIPCION = _FORMA_PAGO.Trim() + "-" + DB.Sub_Datar_DT("FORMA_PAGO ", "FORMA_PAGO ", "DESCRIPCION", _FORMA_PAGO);
            }
        }
        #endregion

        #region Propiedades a Mostrar
        [Browsable(true)]
        //[TypeConverter(typeof(Combo))] 
        //[Editor(typeof(Consulta), typeof(UITypeEditor))]
        [CategoryAttribute("General"), DisplayName("0-Factura"), DescriptionAttribute("Número de factura"), ReadOnly(false)]

        public string _mVENTA
        {
            get { return Venta; }
            set { Venta = value; }
        }
        [Browsable(true)]
        //[TypeConverter(typeof(Combo))] 
        //[Editor(typeof(Consulta), typeof(UITypeEditor))]
        [CategoryAttribute("General"), DisplayName("1-Fecha"), DescriptionAttribute("Fecha de la venta"), ReadOnly(false)]

        public DateTime _mFECHA
        {
            get { return DateTime.Parse( Fecha); }
            set { Fecha = value.ToString("dd/MM/yyyy") ; }
        }
        [Browsable(true)]
        //[TypeConverter(typeof(Combo))] 
        [Editor(typeof(ConsultaEMPLEADO), typeof(UITypeEditor))]
        [CategoryAttribute("General"), DisplayName("2-Id vendedor"), DescriptionAttribute("Id del vendedor"), ReadOnly(false)]

        public string _mVENDEDOR
        {
            get { return Vendedor; }
            set { Vendedor = value; }
        }

        [Browsable(true)]
        //[TypeConverter(typeof(Combo))] 
        //[Editor(typeof(Consulta), typeof(UITypeEditor))]
        [CategoryAttribute("General"), DisplayName("3-Nombre vendedor"), DescriptionAttribute("Nombre vendedor"), ReadOnly(true)]

        public string _mVENDEDOR_DESCRIPCION
        {
            get { return _VENDEDOR_DESCRIPCION; }
        }

        [Browsable(true)]
        //[TypeConverter(typeof(Combo))] 
        [Editor(typeof(ConsultaCLIENTE), typeof(UITypeEditor))]
        [CategoryAttribute("General"), DisplayName("4-Id cliente"), DescriptionAttribute("Id del cliente"), ReadOnly(false)]

        public string _mCLIENTE
        {
            get { return Cliente; }
            set { Cliente = value; }
        }

        [Browsable(true)]
        //[TypeConverter(typeof(Combo))] 
        //[Editor(typeof(Consulta), typeof(UITypeEditor))]
        [CategoryAttribute("General"), DisplayName("5-Nombre cliente"), DescriptionAttribute("Nombre del cliente"), ReadOnly(true)]

        public string _mCLIENTE_DESCRIPCION
        {
            get { return _CLIENTE_DESCRIPCION; }
        }

        [Browsable(true)]
        [TypeConverter(typeof(ComboFORMA_PAGO))] 
        //[Editor(typeof(Consulta), typeof(UITypeEditor))]
        [CategoryAttribute("General"), DisplayName("6-Forma pago"), DescriptionAttribute("Forma de pago a utilizar"), ReadOnly(false)]

        public string _mFORMA_PAGO
        {
            get { return _FORMA_PAGO_DESCRIPCION; }
            set
            {
                if (value.Length >= 2)
                {
                    Forma_pago = value.Substring(0, 2);
                }
                else
                {
                    Forma_pago = "00";
                }
            }
        }
        private VENTA_DETALLE _ARTICULOS;

        [Editor(typeof(EditorVENTA_DETALLE), typeof(UITypeEditor))]
        [TypeConverter(typeof(ConvertidoColeccionVENTA_DETALLE))]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [CategoryAttribute("General")]
        [DisplayName("7-Artículos")]
        [DescriptionAttribute("Artículos Facturados")]
        [ReadOnly(false)]
        [ParenthesizePropertyName(false)]
        public VENTA_DETALLECollection _mARTICULOS
        {
            get
            {
                if (_ARTICULOS != null)
                {
                    VENTA_DETALLECollection mValor = new VENTA_DETALLECollection();
                    for (int i = 0; i < _ARTICULOS.Lista.Length; i++)
                    {
                        mValor.Add((VENTA_DETALLE)_ARTICULOS.Lista[i]);
                    }
                    return mValor;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (value != null)
                {
                    VENTA_DETALLE[] mValor = new VENTA_DETALLE[value.Count];
                    for (int i = 0; i < value.Count; i++)
                    {
                        mValor[i] = value[i];
                    }
                    _ARTICULOS.Lista = mValor;
                }
            }
        }
        #endregion


        private void VENTA_DatosLimpiados(System.Object sender, System.EventArgs e)
        {
            _ARTICULOS = null;
            _ARTICULOS = new VENTA_DETALLE(DB, this.Venta);
        }
        private void VENTA_AntesOperacion(TipoOperacion mOperacion)
        {
            _ARTICULOS.Factura  = this.Venta;
        }

        private void VENTA_DatosCargadosDesdeBD(System.Object sender, System.EventArgs e)
        {
            string result = "";
            if (_ARTICULOS.Lista != null)
            {
                _ARTICULOS.Factura = this.Venta;
                result += this._ARTICULOS.SeleccionarConjunto();
                for (int i = 0; i < _ARTICULOS.Lista.Length; i++)
                {
                    _ARTICULOS.Lista[i].ValorCampoSubLLaveOriginal = new string[] { ((VENTA_DETALLE)_ARTICULOS.Lista[i]).Factura  };
                    ((VENTA_DETALLE)_ARTICULOS.Lista[i]).Factura = ((VENTA_DETALLE)_ARTICULOS.Lista[i]).Factura;
                    //((VENTA_DETALLE)_ARTICULOS.Lista[i])._DETALLE_ARTICULO.SeleccionarFila();
                }
            }
            InactivarCamposLlave(true);
            DB.Cerrar();
            if (!result.Equals(""))
            {
                throw new Exception(result);
            }

        }

        public override void InactivarCamposLlave(bool ReadOnly)
        {
            Utility.Hide_Property(this, "_mVENTA", true);
            Utility.Disable_Property(this, "_mVENTA", ReadOnly);

        }



        public override string Validar()
        {

            if (this.EsValorInvalido(_VENTA)) { return "Falta el dato de factura"; }
            if (this.EsValorInvalido(_FECHA)) { return "Falta el dato de fecha"; }
            if (this.EsValorInvalido(_VENDEDOR)) { return "Falta el dato de vendedor"; }
            if (this.EsValorInvalido(_CLIENTE)) { return "Falta el dato de cliente"; }
            if (this.EsValorInvalido(_FORMA_PAGO)) { return "Falta el dato de forma pago"; }
            return "";
        }
        public override void InicializarCampos()
        {
            _VENTA = "";
            _FECHA = DateTime.Today.ToString("dd/MM/yyyy")   ;
            _VENDEDOR = "";
            _CLIENTE = "";
            _FORMA_PAGO = "0";
            _VENDEDOR_DESCRIPCION = "";
            _CLIENTE_DESCRIPCION = "";
            _FORMA_PAGO_DESCRIPCION = "";
            Lista = null;
        }
    }
}



