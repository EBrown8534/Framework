using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static Evbpc.Framework.Utilities.Extensions.StringExtensions;

namespace Evbpc.Framework.Utilities.Serialization.DelimitedSerialization
{
    /// <summary>
    /// Represents a serializer that will serialize arbitrary objects to files with specific row and column separators.
    /// </summary>
    public class DelimitedSerializer
    {
        private string _columnDelimiter;
        private string _rowDelimiter;

        /// <summary>
        /// The string to be used to separate columns.
        /// </summary>
        public string ColumnDelimiter
        {
            get
            {
                return _columnDelimiter;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException($"The value for {nameof(ColumnDelimiter)} cannot be null or an empty string.");
                }

                _columnDelimiter = value;
            }
        }

        /// <summary>
        /// The string to be used to separate rows.
        /// </summary>
        public string RowDelimiter
        {
            get
            {
                return _rowDelimiter;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException($"The value for {nameof(RowDelimiter)} cannot be null or an empty string.");
                }

                _rowDelimiter = value;
            }
        }

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
        /// Used for readonly default instances.
        /// </summary>
        private DelimitedSerializer()
        {

        }

        /// <summary>
        /// Constructs a new instance of the <see cref="DelimitedSerializer"/> from the specified values.
        /// </summary>
        /// <param name="columnDelimiter">The <see cref="ColumnDelimiter"/>.</param>
        /// <param name="rowDelimiter">The <see cref="RowDelimiter"/>.</param>
        public DelimitedSerializer(string columnDelimiter, string rowDelimiter)
        {
            ColumnDelimiter = columnDelimiter;
            RowDelimiter = rowDelimiter;
        }

        private class Property
        {
            public DelimitedColumnAttribute Attribute { get; set; }
            public PropertyInfo Info { get; set; }

            public bool CanSerialize => !Info.PropertyType.IsArray && (Info.PropertyType == typeof(string) || Info.PropertyType.GetInterface(typeof(IEnumerable<>).FullName) == null);
        }

        private IEnumerable<Property> _getProperties(object item) =>
            item.GetType().GetProperties()
                .Where(p => p.GetCustomAttribute<DelimitedIgnoreAttribute>() == null)
                .Select(p => new Property
                {
                    Attribute = p.GetCustomAttribute<DelimitedColumnAttribute>() ?? new DelimitedColumnAttribute { Name = p.Name.InsertOnCharacter(CharacterType.UpperLetter, " ") },
                    Info = p
                })
                .OrderBy(p => p.Attribute.Order)
                .ThenBy(p => p.Attribute.Name)
                .ToList();

        private void _validateCharacters(string name, string checkFor, string humanLocation)
        {
            if (name.Contains(checkFor))
            {
                throw new ArgumentException($"The {humanLocation} string '{name}' contains an invalid character: '{checkFor}'.");
            }
        }

        private ExtendedStringBuilder _buildHeader(object item, IEnumerable<Property> properties, bool root = true)
        {
            var columnLine = new ExtendedStringBuilder();

            foreach (var property in properties)
            {
                if (!property.CanSerialize)
                {
                    continue;
                }

                var name = string.Empty;

                if (property.Attribute.Traverse)
                {
                    var itemValue = property.Info.GetValue(item);
                    name = _buildHeader(itemValue, _getProperties(itemValue), false);
                }
                else
                {
                    name = property.Attribute?.Name ?? property.Info.Name;
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

                    _validateCharacters(name, ColumnDelimiter, "column name");
                    _validateCharacters(name, RowDelimiter, "column name");

                    if (QuoteValues)
                    {
                        name = "\"" + name + "\"";
                    }
                }

                if (columnLine.HasBeenAppended)
                {
                    columnLine += ColumnDelimiter;
                }

                columnLine += name;
            }

            if (root && IncludeTrailingDelimiter)
            {
                columnLine += ColumnDelimiter;
            }

            return columnLine;
        }

        private ExtendedStringBuilder _buildRow(object item, IEnumerable<Property> properties, bool root = true)
        {
            var row = new ExtendedStringBuilder();

            foreach (var property in properties)
            {
                if (!property.CanSerialize)
                {
                    continue;
                }

                var value = string.Empty;

                if (property.Attribute.Traverse)
                {
                    var itemValue = property.Info.GetValue(item);
                    value = _buildRow(itemValue, _getProperties(itemValue), false);
                }
                else
                {
                    value = string.Format($"{{0:{property.Attribute.Format}}}", property.Info.GetValue(item));

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

                        _validateCharacters(value, ColumnDelimiter, "property value");
                        _validateCharacters(value, RowDelimiter, "property value");
                    }

                    if (QuoteValues)
                    {
                        value = "\"" + value + "\"";
                    }
                }

                if (row.HasBeenAppended)
                {
                    row += ColumnDelimiter;
                }

                row += value;
            }

            if (root && IncludeTrailingDelimiter)
            {
                row += ColumnDelimiter;
            }

            return row;
        }

        /// <summary>
        /// Serializes an object to a delimited file. Throws an exception if any of the property names, column names, or values contain either the <see cref="ColumnDelimiter"/> or the <see cref="RowDelimiter"/>.
        /// </summary>
        /// <typeparam name="T">The type of the object to serialize.</typeparam>
        /// <param name="items">A list of the items to serialize.</param>
        /// <returns>The serialized string.</returns>
        public string Serialize<T>(IEnumerable<T> items)
        {
            var result = new ExtendedStringBuilder();
            var properties = _getProperties(items.First());

            if (IncludeHeader)
            {
                result += _buildHeader(items.First(), properties);
            }

            foreach (var item in items)
            {
                if (result.HasBeenAppended)
                {
                    result += RowDelimiter;
                }

                result += _buildRow(item, properties);
            }

            if (IncludeEmptyRow)
            {
                result += RowDelimiter;
                result += "";
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
            IncludeEmptyRow = false,
            QuoteValues = true,
            InvalidColumnReplace = null,
            InvalidRowReplace = null,
            DoubleQuoteEscape = "\"\""
        };
    }
}
