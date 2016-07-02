using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Utilities.Serialization.DelimitedSerialization
{
    /// <summary>
    /// Represents a serializer that will serialize arbitrary objects to files with specific row and column separators.
    /// </summary>
    public class DelimitedSerializer
    {
        /// <summary>
        /// The string to be used to separate columns.
        /// </summary>
        public string ColumnDelimiter { get; set; }

        /// <summary>
        /// The string to be used to separate rows.
        /// </summary>
        public string RowDelimiter { get; set; }

        /// <summary>
        /// Serializes an object to a delimited file. Throws an exception if any of the property names, column names, or values contain either the <see cref="ColumnDelimiter"/> or the <see cref="RowDelimiter"/>.
        /// </summary>
        /// <typeparam name="T">The type of the object to serialize.</typeparam>
        /// <param name="items">A list of the items to serialize.</param>
        /// <returns>The serialized string.</returns>
        public string Serialize<T>(List<T> items)
        {
            if (string.IsNullOrEmpty(ColumnDelimiter))
            {
                throw new ArgumentException($"The property '{nameof(ColumnDelimiter)}' cannot be null or an empty string.");
            }

            if (string.IsNullOrEmpty(RowDelimiter))
            {
                throw new ArgumentException($"The property '{nameof(RowDelimiter)}' cannot be null or an empty string.");
            }

            var result = new ExtendedStringBuilder();

            var properties = typeof(T).GetProperties()
                .Select((PropertyInfo p) => new
                {
                    Attribute = p.GetCustomAttribute<DelimitedColumnAttribute>(),
                    Info = p
                })
                .Where(x => x.Attribute != null)
                .OrderBy(x => x.Attribute.Order)
                .ThenBy(x => x.Attribute.Name)
                .ThenBy(x => x.Info.Name)
                .ToList();

            Action<string, string, string> validateCharacters = (string name, string checkFor, string humanLocation) =>
            {
                if (name.Contains(checkFor))
                {
                    throw new ArgumentException($"The {humanLocation} string '{name}' contains an invalid character: '{checkFor}'.");
                }
            };

            result += string.Join(ColumnDelimiter, properties
               .Select(x =>
               {
                   var name = x.Attribute?.Name ?? x.Info.Name;
                   validateCharacters(name, ColumnDelimiter, "column name");
                   validateCharacters(name, RowDelimiter, "column name");

                   return name;
               }));

            foreach (var item in items)
            {
                var row = new ExtendedStringBuilder();

                foreach (var property in properties)
                {
                    var value = property.Info.GetValue(item)?.ToString();

                    validateCharacters(value, ColumnDelimiter, "property value");
                    validateCharacters(value, RowDelimiter, "property value");

                    if (row.HasBeenAppended)
                    {
                        row += ColumnDelimiter;
                    }

                    row += value;
                }

                result += RowDelimiter;
                result += row;
            }

            return result;
        }

        /// <summary>
        /// Returns an instance of the <see cref="DelimitedSerializer"/> setup for Tab-Separated Value files.
        /// </summary>
        public static DelimitedSerializer TsvSerializer => new DelimitedSerializer { ColumnDelimiter = "\t", RowDelimiter = Environment.NewLine };

        /// <summary>
        /// Returns an instance of the <see cref="DelimitedSerializer"/> setup for Comma-Separated Value files.
        /// </summary>
        public static DelimitedSerializer CsvSerializer => new DelimitedSerializer { ColumnDelimiter = ",", RowDelimiter = Environment.NewLine };

        /// <summary>
        /// Returns an instance of the <see cref="DelimitedSerializer"/> setup for Pipe-Separated Value files.
        /// </summary>
        public static DelimitedSerializer PsvSerializer => new DelimitedSerializer { ColumnDelimiter = "|", RowDelimiter = Environment.NewLine };
    }
}
