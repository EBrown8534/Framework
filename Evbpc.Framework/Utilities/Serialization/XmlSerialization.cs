using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Evbpc.Framework.Utilities.Serialization
{
    /// <summary>
    /// Provides methods for Serialization and Deserialization of XML/Extensible Markup Language documents.
    /// </summary>
    public static class XmlSerialization
    {
        /// <summary>
        /// Serializes an object to an XML/Extensible Markup Language string.
        /// </summary>
        /// <typeparam name="T">The type of the object to serialize.</typeparam>
        /// <param name="value">The object to serialize.</param>
        /// <param name="serializedXml">Filled with a string that is the object serialized as XML.</param>
        /// <param name="throwExceptions">If true, will throw exceptions. Otherwise, returns false on failures.</param>
        /// <returns>A boolean value indicating success.</returns>
        public static bool Serialize<T>(T value, ref string serializedXml, bool throwExceptions = false)
        {
            try
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(value)} is expected to be a non-null {typeof(T)}.");
                }

                XmlSerializer xmlserializer = new XmlSerializer(typeof(T));

                using (StringWriter stringWriter = new StringWriter())
                using (XmlWriter writer = XmlWriter.Create(stringWriter))
                {
                    xmlserializer.Serialize(writer, value);

                    serializedXml = stringWriter.ToString();

                    return true;
                }
            }
            catch
            {
                if (throwExceptions)
                {
                    throw;
                }

                return false;
            }
        }

        /// <summary>
        /// Deserializes an XML/Extensible Markup Language string to an object.
        /// </summary>
        /// <typeparam name="T">The type of the object to deserialize.</typeparam>
        /// <param name="value">The XML string representing the serialized object.</param>
        /// <param name="deserializedObject">Filled with the object that is the XML string deserialized to an object.</param>
        /// <param name="throwExceptions">If true, will throw exceptions. Otherwise, returns false on failures.</param>
        /// <returns>A boolean value indicating success.</returns>
        public static bool Deserialize<T>(string value, ref T deserializedObject, bool throwExceptions = false)
        {
            try
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(value)} is expected to be a non-null string.");
                }

                XmlSerializer xmlserializer = new XmlSerializer(typeof(T));

                using (StringReader stringReader = new StringReader(value))
                using (XmlReader reader = XmlReader.Create(stringReader))
                {
                    if (!xmlserializer.CanDeserialize(reader))
                    {
                        throw new ArgumentException($"The provided value cannot be deserialized to the type {typeof(T)}.");
                    }

                    deserializedObject = (T)(xmlserializer.Deserialize(reader));

                    return true;
                }
            }
            catch
            {
                if (throwExceptions)
                {
                    throw;
                }

                return false;
            }
        }
    }
}
