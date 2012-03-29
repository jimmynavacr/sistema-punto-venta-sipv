using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BaseCode;
using System.Reflection;
using System.Windows.Forms.Design;


namespace SIPV.Datos
{
    public partial class COLECTION_EDITOR : Form
    {
        private BindingFlags flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly | BindingFlags.Static;

        private List<DB_BASE> mLista;
        public DB_BASE[] _mLista;
        public DB mDB;
        private object[] Params;
        private string[] PropiedadesAInactivar;
        private string[] PropiedadesAActivar;
        private DB_BASE Elemento;
        private ITypeDescriptorContext Contexto;
        private Type t;

        public COLECTION_EDITOR()
        {
            InitializeComponent();
        }
        public COLECTION_EDITOR(ITypeDescriptorContext Contexto, Type t, string Text, object mLista, DB mDB, object[] Params, string[] PropiedadesAInactivar, string[] PropiedadesAActivar)
            : this()
        {
            this.Text = Text;
            if (mLista.GetType().Equals(typeof(DB_BASE[])))
            {
                this._mLista = (DB_BASE[])mLista;
            }
            else //Coleccion
            {
                this._mLista = Utility.ConvertirDeColeccionAListaTabla(mLista);
            }
            if (this._mLista != null)
            {
                this.mLista = new List<DB_BASE>();
                for (int i = 0; i < _mLista.Length; i++)
                {
                    this.mLista.Add ( _mLista[i]);
                }
            }
            this.t = t;
            this.mDB = mDB;
            this.Params = Params;
            this.Contexto = Contexto;
            this.PropiedadesAInactivar = PropiedadesAInactivar;
            this.PropiedadesAActivar = PropiedadesAActivar;
            Elemento = CrearInstancia();
            InactivarPropiedades(Elemento);
            ConfigurarListView();
            CargarListView();
        }
        private void InactivarPropiedades(DB_BASE mValor)
        {
            if (PropiedadesAInactivar != null && mValor != null)
            {
                for (int i = 0; i < PropiedadesAInactivar.Length; i++)
                {
                    Utility.Disable_Property(mValor, PropiedadesAInactivar[i], true);
                }
            }
        }
        private void ActivarPropiedades(DB_BASE mValor)
        {
            if (PropiedadesAActivar != null && mValor != null)
            {
                for (int i = 0; i < PropiedadesAActivar.Length; i++)
                {
                    Utility.Disable_Property(mValor, PropiedadesAActivar[i], false);
                }
            }
        }
        private DB_BASE CrearInstancia()
        {
            DB_BASE mValor;            
            mValor = (DB_BASE)Activator.CreateInstance(t, Params);
            InactivarPropiedades(mValor);
            return mValor; 
        }

        private void ConfigurarListView()
        {

            Type t = Elemento.GetType();
            PropertyInfo[] pr = t.GetProperties(flags);
            PropertyDescriptorCollection props = null;
            AttributeCollection attribs = null;
            BrowsableAttribute bra = null;
            ReadOnlyAttribute roa = null;


            DisplayNameAttribute dna = null;
            props = TypeDescriptor.GetProperties(t);

            LVElementos.Columns.Clear();
            int i = 0;
            foreach (PropertyInfo m in pr)
            {
                string propertyName = m.Name;
                attribs = props[m.Name].Attributes;
                dna = (DisplayNameAttribute)attribs[DisplayNameAttribute.Default.GetType()];
                bra = (BrowsableAttribute)attribs[BrowsableAttribute.Default.GetType()];
                roa = (ReadOnlyAttribute)attribs[ReadOnlyAttribute.Default.GetType()];
                DefaultValueAttribute dva = null;
                dva = (DefaultValueAttribute)attribs[typeof(DefaultValueAttribute)];
                if (bra.Browsable && ((!roa.IsReadOnly)||( m.PropertyType.BaseType.Equals(typeof(BaseCode.DB_BASE )) ) ))
                {
                    if (!dna.DisplayName.Equals(""))
                    {
                        propertyName = dna.DisplayName;
                    }

                    LVElementos.Columns.Add(propertyName);
                    if (dva != null)
                    {
                        if (dva.Value.Equals("0"))
                        {
                            LVElementos.Columns[i].TextAlign = HorizontalAlignment.Right;
                        }
                    }
                    i++;
                }
            }
        }
        
        private bool EsCampoDeBD(Object propertyValue, String propertyName)
        {
            return ((propertyName.IndexOf("_") > 0 || (Char.IsLower(propertyName, propertyName.Length - 1))));
        }
        private void AutoTamanoColumnas()
        {
            for (int i = 0; i < LVElementos.Columns.Count; i++)
            {
                if (LVElementos.Items.Count > 0)
                {
                    if (LVElementos.Items[0].Text.Length <=LVElementos.Columns[i].Text.Length )
                    {
                        LVElementos.Columns[i].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                    }
                    else
                    {
                        LVElementos.Columns[i].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                    }
                }
                else
                {
                    LVElementos.Columns[i].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                }
            }
        }

        public void CargarListView()
        {
            LVElementos.Items.Clear();
            if (mLista == null) { return; }
            for (int i = 0; i < mLista.Count; i++)
            {
                Type t = mLista[i].GetType();
                PropertyInfo[] pr = t.GetProperties(flags);
                PropertyDescriptorCollection props = null;
                AttributeCollection attribs = null;
                BrowsableAttribute  bra = null;
                ReadOnlyAttribute roa = null;
                
                ListViewItem mItem = new ListViewItem();

                int col = 0;
                foreach (PropertyInfo m in pr)
                {
                    object propertyValue = m.GetValue(mLista[i], null);
                    string propertyName = m.Name;
                    props = TypeDescriptor.GetProperties(mLista[i]);
                    
                    attribs = props[m.Name].Attributes;
                    bra = (BrowsableAttribute)attribs[BrowsableAttribute.Default.GetType()];
                    roa = (ReadOnlyAttribute)attribs[ReadOnlyAttribute.Default.GetType()];
                    DefaultValueAttribute dva = null;  
                    dva = (DefaultValueAttribute)attribs[typeof(DefaultValueAttribute)];
                    string Valor="";

                    if (bra.Browsable && ((!roa.IsReadOnly) || (m.PropertyType.BaseType.Equals(typeof(BaseCode.DB_BASE)))))
                    {
                        
                        if (propertyValue == null)
                        {
                            Valor = "";

                        }
                        else
                        {
                            if (propertyValue.GetType().BaseType.Equals(typeof(BaseCode.DB_BASE)))
                            {
                               /*
                                PropertyInfo[] pr2 = propertyValue.GetType().GetProperties(flags);
                                PropertyDescriptorCollection props2 = TypeDescriptor.GetProperties(propertyValue);
                                foreach (PropertyInfo m2 in pr2)
                                {
                                    object mValor = m2.GetValue(propertyValue, null);
                                    

                                    if (!mValor.ToString().Equals("") )
                                    {
                                        AttributeCollection attribs2 = props2[m2.Name].Attributes;
                                        BrowsableAttribute bra2 = (BrowsableAttribute)attribs2[BrowsableAttribute.Default.GetType()];
                                        if (bra2.Browsable)
                                        {
                                            DisplayNameAttribute dna = (DisplayNameAttribute)attribs2[DisplayNameAttribute.Default.GetType()];
                                            Valor = Valor + dna.DisplayName + ":" + mValor.ToString() + ";";
                                        }
                                    }
                                    
                                }
                                */
                                Valor = props[m.Name].Converter.ConvertTo(propertyValue, typeof(String)).ToString();
                            }
                            else
                            {

                                Valor = propertyValue.ToString();
                            }
                        }
                        if (propertyValue != null)
                        {
                            if (propertyValue.GetType().Equals(typeof(double )))
                            {
                                if(Valor.Equals("") ) 
                                {
                                    Valor = "0";
                                }
                                try
                                {
                                    Decimal nValor = Decimal.Parse(Valor);
                                    Valor = nValor.ToString("###,##0.00#");
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e.ToString()); 
                                }
                                finally
                                {
                                    Valor = Utility.Completa(Valor, 10, "", Utility.Lado.Izquierdo);
                                }
                            }
                        }

                        if (col == 0)
                        {
                            mItem.Text = Valor;
                        }
                        else
                        {
                            mItem.SubItems.Add(Valor);
                        }
                        col++;
                    }
                }
                
                LVElementos.Items.Add(mItem);
            }
            AutoTamanoColumnas();
            LbTotalRegistros.Text = LVElementos.Items.Count.ToString();   
        }

        [Browsable(false)]
        public List<DB_BASE> List
        {
            get { return mLista; }
            set { mLista = value; }
        }
        [Browsable(false)]
        public DB_BASE[] Lista
        {
            get
            {                

                 return _mLista;
            }

        }


        private void CmdCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CmdAceptar_Click(object sender, EventArgs e)
        {
            _mLista = new DB_BASE[mLista.Count];
            for (int i = 0; i < mLista.Count; i++)
            {
                _mLista[i] = mLista[i];
            }
            this.Close();
        }

        public DB_BASE Nuevo()
        {
            DB_BASE nNuevo = CrearInstancia();
            ActivarPropiedades(nNuevo);
            mLista.Add(nNuevo);
            return nNuevo;
        }

        public void CmdNuevo_Click(object sender, EventArgs e)
        {

            Nuevo();
            ConfigurarListView();
            CargarListView();
            LVElementos.Items[LVElementos.Items.Count - 1].Selected = true;  
        }

        private void CmdEliminar_Click(object sender, EventArgs e)
        {
            if (LVElementos.SelectedItems.Count > 0)
            {
                for (int i = 0; i < LVElementos.SelectedItems.Count; i++)
                {
                    mLista.Remove(mLista[LVElementos.SelectedItems[i].Index]);
                }
                CargarListView();
            }
            Campos.SelectedObject = null; 
        }

        private void Campos_SelectedGridItemChanged(object sender, SelectedGridItemChangedEventArgs e)
        {
            
        }

        private void LVElementos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LVElementos.SelectedItems.Count > 0)
            {
                Campos.SelectedObject = mLista[LVElementos.SelectedItems[0].Index];
            }
            else { Campos.SelectedObject = null; }
        }

        private void Campos_Leave(object sender, EventArgs e)
        {
            CargarListView();
        }

        private void COLECTION_EDITOR_FormClosing(object sender, FormClosingEventArgs e)
        {
            InactivarPropiedades(Elemento);
        }

    }
}
