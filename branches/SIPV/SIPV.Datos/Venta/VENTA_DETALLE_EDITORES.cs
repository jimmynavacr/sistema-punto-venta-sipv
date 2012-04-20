
using System;
using System.Collections.Generic;
using System.Text;
using BaseCode;
using System.ComponentModel;
using System.Reflection;
using System.Drawing.Design;
using System.Windows.Forms.Design;
using System.Collections;
using System.Runtime.InteropServices;

namespace SIPV.Datos
{

    #region Colecciones
    public class VENTA_DETALLECollection : CollectionBase, ICustomTypeDescriptor
    {
        #region Implementacion de Coleccion
        public void Add(VENTA_DETALLE emp)
        {
            this.List.Add(emp);
        }

        public void Remove(VENTA_DETALLE emp)
        {
            this.List.Remove(emp);
        }

        public VENTA_DETALLE this[int index]
        {
            get
            {
                return (VENTA_DETALLE)this.List[index];
            }
        }

        #endregion

        #region ICustomTypeDescriptor impl

        public String GetClassName()
        {
            return TypeDescriptor.GetClassName(this, true);
        }

        public AttributeCollection GetAttributes()
        {
            return TypeDescriptor.GetAttributes(this, true);
        }

        public String GetComponentName()
        {
            return TypeDescriptor.GetComponentName(this, true);
        }

        public TypeConverter GetConverter()
        {
            return TypeDescriptor.GetConverter(this, true);
        }

        public EventDescriptor GetDefaultEvent()
        {
            return TypeDescriptor.GetDefaultEvent(this, true);
        }

        public PropertyDescriptor GetDefaultProperty()
        {
            return TypeDescriptor.GetDefaultProperty(this, true);
        }

        public object GetEditor(Type editorBaseType)
        {
            return TypeDescriptor.GetEditor(this, editorBaseType, true);
        }

        public EventDescriptorCollection GetEvents(Attribute[] attributes)
        {
            return TypeDescriptor.GetEvents(this, attributes, true);
        }

        public EventDescriptorCollection GetEvents()
        {
            return TypeDescriptor.GetEvents(this, true);
        }

        public object GetPropertyOwner(PropertyDescriptor pd)
        {
            return this;
        }
        public PropertyDescriptorCollection GetProperties(Attribute[] attributes)
        {
            return GetProperties();
        }


        public PropertyDescriptorCollection GetProperties()
        {
            PropertyDescriptorCollection pds = new PropertyDescriptorCollection(null);
            for (int i = 0; i < this.List.Count; i++)
            {
                VENTA_DETALLECollectionPropertyDescriptor pd = new VENTA_DETALLECollectionPropertyDescriptor(this, i);
                pds.Add(pd);
            }
            return pds;
        }

        #endregion
    }


    public class VENTA_DETALLECollectionPropertyDescriptor : PropertyDescriptor
    {
        private  VENTA_DETALLECollection collection = null;
        private int index = -1;

        public VENTA_DETALLECollectionPropertyDescriptor( VENTA_DETALLECollection coll, int idx) :
            base("#" + idx.ToString(), null)
        {
            this.collection = coll;
            this.index = idx;
        }

        public override AttributeCollection Attributes
        {
            get
            {
                return new AttributeCollection(null);
            }
        }

        public override bool CanResetValue(object component)
        {
            return true;
        }

        public override Type ComponentType
        {
            get
            {
                return this.collection.GetType();
            }
        }

        public override string DisplayName
        {
            get
            {
                 VENTA_DETALLE emp = this.collection[index];
                 return emp._DETALLE_ARTICULO._mDESCRIPCION ;
            }
        }

        public override string Description
        {
            get
            {
                 VENTA_DETALLE emp = this.collection[index];
                StringBuilder sb = new StringBuilder();
                sb.Append("(" + emp._DETALLE_ARTICULO.Descripcion + ")");
                return sb.ToString();
            }
        }

        public override object GetValue(object component)
        {
            return this.collection[index];
        }

        public override bool IsReadOnly
        {
            get { return false; }
        }

        public override string Name
        {
            get { return "#" + index.ToString(); }
        }

        public override Type PropertyType
        {
            get { return this.collection[index].GetType(); }
        }

        public override void ResetValue(object component)
        {
        }

        public override bool ShouldSerializeValue(object component)
        {
            return true;
        }

        public override void SetValue(object component, object value)
        {
            // this.collection[index] = value;
        }
    }

    #endregion
    #region Editores
    public class EditorVENTA_DETALLE : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            IWindowsFormsEditorService svc = (IWindowsFormsEditorService)
                provider.GetService(typeof(IWindowsFormsEditorService));
            if (svc != null)
            {
                COLECTION_EDITOR FormConsulta;
                if (value == null) { return null; }
                Type mTipo = value.GetType();
                VENTA Origen = (VENTA)context.Instance;
                mTipo = typeof(VENTA_DETALLE);
                object[] mParams = new object[2];
                mParams[0] = Origen.getvDB();
                mParams[1] = Origen.Venta;
                FormConsulta = new COLECTION_EDITOR(context, mTipo, "Editor de:" + context.PropertyDescriptor.Description, value, Origen.getvDB(), mParams, null, new string[] { "_mFACTURA"});
                svc.ShowDialog(FormConsulta);

                DB_BASE[] mResult = FormConsulta.Lista;
                VENTA_DETALLECollection mValor = new VENTA_DETALLECollection();
                for (int i = 0; i < mResult.Length; i++)
                {
                    mValor.Add((VENTA_DETALLE)mResult[i]);
                }
                value = mValor;
            }
            return value;
        }
        public override bool GetPaintValueSupported(ITypeDescriptorContext context)
        {
            return false;
        }
    }
    
    public class ConvertidoVENTA_DETALLE : ExpandableObjectConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return false;
        }
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return true;
        }
        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, Object value, Type destinationType)
        {
            if (destinationType == typeof(String) && value is VENTA_DETALLE)
            {
                VENTA_DETALLE cX;
                if (value != null)
                {
                    cX = (VENTA_DETALLE)value;
                    return cX._DETALLE_ARTICULO.Descripcion;
                }
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, Object value)
        {
            return base.ConvertFrom(context, culture, value);
        }
    }   
    public class ConvertidoColeccionVENTA_DETALLE : ExpandableObjectConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return false;
        }
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return true;
        }
        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, Object value, Type destinationType)
        {
            return "Artículos facturados";
            //return base.ConvertTo(context, culture, value, destinationType);
        }
        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, Object value)
        {
            return base.ConvertFrom(context, culture, value);
        }
    }

    
    #endregion
}
