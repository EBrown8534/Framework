using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Evbpc.Framework.Drawing
{
    /// <summary>
    /// Allows conversion of a <see cref="Point"/> to various types.
    /// </summary>
    public class PointConverter : TypeConverter
    {
        /// <summary>
        /// Returns whether this converter can convert an object of the given type to the type of this converter, using the specified context.
        /// </summary>
        /// <param name="context">An <code>ITypeDescriptorContext</code> that provides a format context.</param>
        /// <param name="sourceType">A <code>Type</code> that represents the type you want to convert from.</param>
        /// <returns>True if this converter can perform the conversion; otherwise, false.</returns>
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string))
            {
                return true;
            }

            return base.CanConvertFrom(context, sourceType);
        }

        /// <summary>
        /// Returns whether this converter can convert the object to the specified type, using the specified context.
        /// </summary>
        /// <param name="context">An <code>ITypeDescriptorContext</code> that provides a format context.</param>
        /// <param name="destinationType">A <code>Type</code> that represents the type you want to convert to.</param>
        /// <returns>True if this converter can perform the conversion; otherwise, false.</returns>
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return base.CanConvertTo(context, destinationType);
        }

        /// <summary>
        /// Converts the given object to the type of this converter, using the specified context and culture information.
        /// </summary>
        /// <param name="context">An <code>ITypeDescriptorContext</code> that provides a format context.</param>
        /// <param name="culture">The <code>CultureInfo</code> to use as the current culture.</param>
        /// <param name="value">The <code>Object</code> to convert.</param>
        /// <returns>An <code>Object</code> that represents the converted value.</returns>
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            string valueString = value as string;

            if (valueString != null)
            {
                string[] v = valueString.Split(new char[] { ',' });
                return new Point(int.Parse(v[0]), int.Parse(v[1]));
            }

            return base.ConvertFrom(context, culture, value);
        }

        /// <summary>
        /// Converts the given value object to the specified type, using the specified context and culture information.
        /// </summary>
        /// <param name="context">An <code>ITypeDescriptorContext</code> that provides a format context.</param>
        /// <param name="culture">A <code>CultureInfo</code>. If null is passed, the current culture is assumed.</param>
        /// <param name="value">The <code>Object</code> to convert.</param>
        /// <param name="destinationType">The <code>Type</code> to convert the value parameter to.</param>
        /// <returns>An <code>Object</code> that represents the converted value.</returns>
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                Point? valuePoint = value as Point?;

                if (valuePoint != null)
                {
                    return valuePoint.Value.X + "," + valuePoint.Value.Y;
                }
            }

            return base.ConvertTo(context, culture, value, destinationType);
        }

        /// <summary>
        /// Creates an instance of the type that this <code>TypeConverter</code> is associated with, using the specified context, given a set of property values for the object.
        /// </summary>
        /// <param name="context">An <code>ITypeDescriptorContext</code> that provides a format context.</param>
        /// <param name="propertyValues">An <code>IDictionary</code> of new property values.</param>
        /// <returns>An <code>Object</code> representing the given <code>IDictionary</code>, or null if the object cannot be created. This method always returns null.</returns>
        public override object CreateInstance(ITypeDescriptorContext context, IDictionary propertyValues) => null;

        /// <summary>
        /// Returns whether changing a value on this object requires a call to <code>CreateInstance</code> to create a new value, using the specified context.
        /// </summary>
        /// <param name="context">An <code>ITypeDescriptorContext</code> that provides a format context.</param>
        /// <returns>True if changing a property on this object requires a call to <see cref="CreateInstance(ITypeDescriptorContext, IDictionary)"/> to create a new value; otherwise, false.</returns>
        public override bool GetCreateInstanceSupported(ITypeDescriptorContext context) => false;

        /// <summary>
        /// Returns a collection of properties for the type of array specified by the value parameter, using the specified context and attributes.
        /// </summary>
        /// <param name="context">An <code>ITypeDescriptorContext</code> that provides a format context.</param>
        /// <param name="value">An <code>Object</code> that specifies the type of array for which to get properties.</param>
        /// <param name="attributes">An array of type <code>Attribute</code> that is used as a filter.</param>
        /// <returns>A <code>PropertyDescriptorCollection</code> with the properties that are exposed for this data type, or null if there are no properties.</returns>
        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes) => null;

        /// <summary>
        /// Returns whether this object supports properties, using the specified context.
        /// </summary>
        /// <param name="context">An <code>ITypeDescriptorContext</code> that provides a format context.</param>
        /// <returns>True if <see cref="GetProperties(ITypeDescriptorContext, object, Attribute[])"/> should be called to find the properties of this object; otherwise, false.</returns>
        public override bool GetPropertiesSupported(ITypeDescriptorContext context) => false; 
    }
}
