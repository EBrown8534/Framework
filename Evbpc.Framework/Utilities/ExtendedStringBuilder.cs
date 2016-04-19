using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Utilities
{
    /// <summary>
    /// This wraps the .NET <code>StringBuilder</code> in a slightly more easy-to-use format.
    /// </summary>
    public class ExtendedStringBuilder
    {
        private StringBuilder _stringBuilder;

        public string CurrentString => _stringBuilder.ToString();

        public int Length => _stringBuilder.Length;

        public ExtendedStringBuilder()
        {
            _stringBuilder = new StringBuilder();
        }

        public ExtendedStringBuilder(int capacity)
        {
            _stringBuilder = new StringBuilder(capacity);
        }

        public ExtendedStringBuilder Append(string s)
        {
            _stringBuilder.Append(s);

            return this;
        }

        public ExtendedStringBuilder Append(char c)
        {
            _stringBuilder.Append(c);

            return this;
        }

        public ExtendedStringBuilder Append(object o)
        {
            _stringBuilder.Append(o);

            return this;
        }

        public static ExtendedStringBuilder operator +(ExtendedStringBuilder sb, string s) => sb.Append(s);

        public static ExtendedStringBuilder operator +(ExtendedStringBuilder sb, char c) => sb.Append(c);

        public static ExtendedStringBuilder operator +(ExtendedStringBuilder sb, object o) => sb.Append(o);

        public static implicit operator string(ExtendedStringBuilder sb) => sb.CurrentString;

        public override string ToString() => CurrentString;
    }
}
