using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;

namespace Evbpc.Framework.Utilities.Serialization
{
    /// <summary>
    /// Provides methods for Serialization and Deserialization of JSON/JavaScript Object Notation documents.
    /// </summary>
    public class JsonSerialization
    {
        /// <summary>
        /// Serializes an object to a JSON/JavaScript Object Notation string.
        /// </summary>
        /// <typeparam name="T">The type of the object to serialize.</typeparam>
        /// <param name="value">The object to serialize.</param>
        /// <param name="serializedJson">Filled with a string that is the JsonSerialized object.</param>
        /// <param name="throwExceptions">If true, will throw exceptions. Otherwise, returns false on failures.</param>
        /// <returns>A boolean value indicating success.</returns>
        public static bool Serialize<T>(T value, ref string serializedJson, bool throwExceptions = false)
        {
#if DEBUG
#warning When in DEBUG Mode JavaScript Serialization Exceptions will be thrown regardless of throwExceptions parameter.
            throwExceptions = true;
#endif

            try
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(value)} is expected to be a non-null {typeof(T)}.");
                }

                JavaScriptSerializer jss = new JavaScriptSerializer();
                serializedJson = jss.Serialize(value);
                return true;
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
        /// Deserializes a JSON/JavaScript Object Notation string to an object.
        /// </summary>
        /// <typeparam name="T">The type of the object to serialize.</typeparam>
        /// <param name="value">The JSON string representing the serialized object.</param>
        /// <param name="deserializedObject">Filled with the object that is the JsonSerialized string.</param>
        /// <param name="throwExceptions">If true, will throw exceptions. Otherwise, returns false on failures.</param>
        /// <returns>A boolean value indicating success.</returns>
        public static bool Deserialize<T>(string value, ref T deserializedObject, bool throwExceptions = false)
        {
#if DEBUG
#warning When in DEBUG Mode JavaScript Deserialization Exceptions will be thrown regardless of throwExceptions parameter.
            throwExceptions = true;
#endif

            try
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(value)} is expected to be a non-null string.");
                }

                JavaScriptSerializer jss = new JavaScriptSerializer();
                deserializedObject = jss.Deserialize<T>(value);
                return true;
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
