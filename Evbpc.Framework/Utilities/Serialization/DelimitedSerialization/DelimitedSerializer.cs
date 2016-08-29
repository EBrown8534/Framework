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
        /// If not null, then sequences in values and names which are identical to the <see cref="ColumnDelimiter"/> will be replaced with this value.
        /// </summary>
        public string InvalidColumnReplace { get; set; }

        /// <summary>
        /// If not null, then sequences in values and names which are identical to the <see cref="RowDelimiter"/> will be replaced with this value.
        /// </summary>
        public string InvalidRowReplace { get; set; }

        /// <summary>
        /// If true, a trailing <see cref="ColumnDelimiter"/> will be included on each line. (Some legacy systems require this.)
        /// </summary>
        public bool IncludeTrailingDelimiter { get; set; }

        /// <summary>
        /// If true, an empty row will be included at the end of the response. (Some legacy systems require this.)
        /// </summary>
        public bool IncludeEmptyRow { get; set; }

        /// <summary>
        /// If true, then all values and columns will be quoted in double-quotes.
        /// </summary>
        public bool QuoteValues { get; set; }

        /// <summary>
        /// If not null, then double quotes appearing inside a value will be escaped with this value.
        /// </summary>
        public string DoubleQuoteEscape { get; set; }

        /// <summary>
        /// If true, then a header row will be output.
        /// </summary>
        public bool IncludeHeader { get; set; }

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
                .Select(p => new
                {
                    Attribute = p.GetCustomAttribute<DelimitedColumnAttribute>(),
                    Info = p
                })
                .Where(x => x.Attribute != null)
                .OrderBy(x => x.Attribute.Order)
                .ThenBy(x => x.Attribute.Name)
                .ThenBy(x => x.Info.Name)
                .ToList();

            if (properties.Count == 0)
            {
                properties = typeof(T).GetProperties()
                    .Where(x => x.GetCustomAttribute<DelimitedIgnoreAttribute>() == null)
                    .Select(p => new
                    {
                        Attribute = new DelimitedColumnAttribute { Name = p.Name },
                        Info = p
                    })
                    .Where(x => x.Attribute != null)
                    .OrderBy(x => x.Attribute.Order)
                    .ThenBy(x => x.Attribute.Name)
                    .ThenBy(x => x.Info.Name)
                    .ToList();
            }

            Action<string, string, string> validateCharacters = (string name, string checkFor, string humanLocation) =>
            {
                if (name.Contains(checkFor))
                {
                    throw new ArgumentException($"The {humanLocation} string '{name}' contains an invalid character: '{checkFor}'.");
                }
            };

            var columnLine = new ExtendedStringBuilder();

            foreach (var property in properties)
            {
                if (property.Info.PropertyType.IsArray || (property.Info.PropertyType != typeof(string) && property.Info.PropertyType.GetInterface(typeof(IEnumerable<>).FullName) != null))
                {
                    continue;
                }

                var name = property.Attribute?.Name ?? property.Info.Name;

                if (InvalidColumnReplace != null)
                {
                    name = name.Replace(ColumnDelimiter, InvalidColumnReplace);
                }
                if (InvalidRowReplace != null)
                {
                    name = name.Replace(RowDelimiter, InvalidRowReplace);
                }
                if (DoubleQuoteEscape != null)
                {
                    name = name.Replace("\"", DoubleQuoteEscape);
                }

                validateCharacters(name, ColumnDelimiter, "column name");
                validateCharacters(name, RowDelimiter, "column name");

                if (columnLine.HasBeenAppended)
                {
                    columnLine += ColumnDelimiter;
                }

                if (QuoteValues)
                {
                    columnLine += "\"";
                }
                columnLine += name;
                if (QuoteValues)
                {
                    columnLine += "\"";
                }
            }

            if (IncludeTrailingDelimiter)
            {
                columnLine += ColumnDelimiter;
            }

            if (IncludeHeader)
            {
                result += columnLine;
            }

            foreach (var item in items)
            {
                var row = new ExtendedStringBuilder();

                foreach (var property in properties)
                {
                    if (property.Info.PropertyType.IsArray || (property.Info.PropertyType != typeof(string) && property.Info.PropertyType.GetInterface(typeof(IEnumerable<>).FullName) != null))
                    {
                        continue;
                    }

                    var value = property.Info.GetValue(item)?.ToString();

                    if (property.Info.PropertyType == typeof(DateTime) || property.Info.PropertyType == typeof(DateTime?))
                    {
                        value = ((DateTime?)property.Info.GetValue(item))?.ToString("u");
                    }

                    if (value != null)
                    {
                        if (InvalidColumnReplace != null)
                        {
                            value = value.Replace(ColumnDelimiter, InvalidColumnReplace);
                        }
                        if (InvalidRowReplace != null)
                        {
                            value = value.Replace(RowDelimiter, InvalidRowReplace);
                        }
                        if (DoubleQuoteEscape != null)
                        {
                            value = value.Replace("\"", DoubleQuoteEscape);
                        }

                        validateCharacters(value, ColumnDelimiter, "property value");
                        validateCharacters(value, RowDelimiter, "property value");
                    }

                    if (row.HasBeenAppended)
                    {
                        row += ColumnDelimiter;
                    }

                    if (QuoteValues)
                    {
                        row += "\"";
                    }
                    row += value;
                    if (QuoteValues)
                    {
                        row += "\"";
                    }
                }

                if (IncludeTrailingDelimiter)
                {
                    row += ColumnDelimiter;
                }

                if (result.HasBeenAppended)
                {
                    result += RowDelimiter;
                }

                result += row;
            }

            return result;
        }

        /// <summary>
        /// Returns an instance of the <see cref="DelimitedSerializer"/> setup for Tab-Separated Value files.
        /// </summary>
        public static DelimitedSerializer TsvSerializer => new DelimitedSerializer
        {
            ColumnDelimiter = "\t",
            RowDelimiter = "\r\n",
            InvalidColumnReplace = "\\t",
            IncludeHeader = true
        };

        /// <summary>
        /// Returns an instance of the <see cref="DelimitedSerializer"/> setup for Comma-Separated Value files.
        /// </summary>
        public static DelimitedSerializer CsvSerializer => new DelimitedSerializer
        {
            ColumnDelimiter = ",",
            RowDelimiter = "\r\n",
            InvalidColumnReplace = "\\u002C",
            IncludeHeader = true
        };

        /// <summary>
        /// Returns an instance of the <see cref="DelimitedSerializer"/> setup for Pipe-Separated Value files.
        /// </summary>
        public static DelimitedSerializer PsvSerializer => new DelimitedSerializer
        {
            ColumnDelimiter = "|",
            RowDelimiter = "\r\n",
            InvalidColumnReplace = "\\u007C",
            IncludeHeader = true
        };

        /// <summary>
        /// Returns an instance of the <see cref="DelimitedSerializer"/> from the RFC 4180 specification. See: https://tools.ietf.org/html/rfc4180
        /// </summary>
        public static DelimitedSerializer Rfc4180Serializer => new DelimitedSerializer
        {
            ColumnDelimiter = ",",
            RowDelimiter = "\r\n",
            IncludeHeader = true,
            IncludeTrailingDelimiter = true,
            QuoteValues = true,
            DoubleQuoteEscape = "\"\""
        };
    }
}
