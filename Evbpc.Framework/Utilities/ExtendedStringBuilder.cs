﻿using System;
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
        private readonly StringBuilder _stringBuilder;

        public int Length
        {
            get { return _stringBuilder.Length; }
            set { _stringBuilder.Length = value; }
        }

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

        public static implicit operator string(ExtendedStringBuilder sb) => sb.ToString();

        public override string ToString() => _stringBuilder.ToString();

        public string ToString(int startIndex, int length) => _stringBuilder.ToString(startIndex, length);
    }
}
