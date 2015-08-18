using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Evbpc.Framework.Drawing
{
    public class RectangleConverter : TypeConverter
    {
        // TODO: Actual right-proper implementation of this bad-boy.
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType) { return true; }
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType) { return true; }
        public override Object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, Object value) { return value; }
        public override Object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, Object value, Type destinationType) { return value; }
        public override Object CreateInstance(ITypeDescriptorContext context, IDictionary propertyValues) { return new Object(); }
        public override bool GetCreateInstanceSupported(ITypeDescriptorContext context) { return true; }
        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, Object value, Attribute[] attributes) { return new PropertyDescriptorCollection(null); }
        public override bool GetPropertiesSupported(ITypeDescriptorContext context) { return true; }
    }
}
