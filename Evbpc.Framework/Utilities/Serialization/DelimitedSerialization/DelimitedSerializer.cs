using System;
using System.Collections.Generic;
using System.Linq;
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
                .Where(x => Attribute.IsDefined(x, typeof(DelimitedColumnAttribute)))
                .OrderBy(x => ((DelimitedColumnAttribute)x.GetCustomAttributes(typeof(DelimitedColumnAttribute), true)[0]).Order)
                .ThenBy(x => ((DelimitedColumnAttribute)x.GetCustomAttributes(typeof(DelimitedColumnAttribute), true)[0]).Name)
                .ThenBy(x => x.Name);
            
            foreach (var property in properties)
            {
                var attribute = (DelimitedColumnAttribute)property.GetCustomAttributes(typeof(DelimitedColumnAttribute), true)[0];

                var name = attribute.Name ?? property.Name;

                if (name.Contains(ColumnDelimiter))
                {
                    throw new ArgumentException($"The column name string '{name}' contains an invalid character: '{ColumnDelimiter}'.");
                }
                if (name.Contains(RowDelimiter))
                {
                    throw new ArgumentException($"The column name string '{name}' contains an invalid character: '{RowDelimiter}'.");
                }

                if (result.Length > 0)
                {
                    result += ColumnDelimiter;
                }

                result += name;
            }

            foreach (var item in items)
            {
                var row = new ExtendedStringBuilder();

                foreach (var property in properties)
                {
                    var value = property.GetValue(item).ToString();

                    if (value.Contains(ColumnDelimiter))
                    {
                        throw new ArgumentException($"The property value string '{value}' contains an invalid character: '{ColumnDelimiter}'.");
                    }
                    if (value.Contains(RowDelimiter))
                    {
                        throw new ArgumentException($"The property value string '{value}' contains an invalid character: '{RowDelimiter}'.");
                    }

                    if (row.Length > 0)
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
        public static readonly DelimitedSerializer TsvSerializer = new DelimitedSerializer { ColumnDelimiter = "\t", RowDelimiter = Environment.NewLine };

        /// <summary>
        /// Returns an instance of the <see cref="DelimitedSerializer"/> setup for Comma-Separated Value files.
        /// </summary>
        public static readonly DelimitedSerializer CsvSerializer = new DelimitedSerializer { ColumnDelimiter = ",", RowDelimiter = Environment.NewLine };
        
        /// <summary>
        /// Returns an instance of the <see cref="DelimitedSerializer"/> setup for Pipe-Separated Value files.
        /// </summary>
        public static readonly DelimitedSerializer PsvSerializer = new DelimitedSerializer { ColumnDelimiter = "|", RowDelimiter = Environment.NewLine };
    }
}
