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
        private readonly StringBuilder _stringBuilder;

        /// <summary>
        /// Represents whether or not the base <see cref="ExtendedStringBuilder"/> has been appended to.
        /// </summary>
        public bool HasBeenAppended { get; private set; } = false;

        /// <summary>
        /// Gets or sets the length of the <see cref="ExtendedStringBuilder"/> buffer.
        /// </summary>
        public int Length
        {
            get { return _stringBuilder.Length; }
            set { _stringBuilder.Length = value; }
        }

        /// <summary>
        /// Gets or sets the capacity of the <see cref="ExtendedStringBuilder"/>.
        /// </summary>
        public int Capacity
        {
            get { return _stringBuilder.Capacity; }
            set { _stringBuilder.Capacity = value; }
        }

        /// <summary>
        /// Gets the maximum capacity of the <see cref="ExtendedStringBuilder"/>.
        /// </summary>
        public int MaxCapacity => _stringBuilder.MaxCapacity;

        /// <summary>
        /// Creates a new, empty instance of the <see cref="ExtendedStringBuilder"/>.
        /// </summary>
        public ExtendedStringBuilder()
        {
            _stringBuilder = new StringBuilder();
        }

        /// <summary>
        /// Creates a new instance of the <see cref="ExtendedStringBuilder"/> with the provided capacity.
        /// </summary>
        /// <param name="capacity">The initial buffer size.</param>
        public ExtendedStringBuilder(int capacity)
        {
            _stringBuilder = new StringBuilder(capacity);
        }

        /// <summary>
        /// Creates a new instance of the <see cref="ExtendedStringBuilder"/> with the provided <code>StringBuilder</code> as a base.
        /// </summary>
        /// <param name="baseBuilder">The <code>StringBuilder</code> containing the base string to intialize to.</param>
        public ExtendedStringBuilder(StringBuilder baseBuilder)
            : this(baseBuilder.Length)
        {
            Append(baseBuilder);
            HasBeenAppended = false;
        }

        /// <summary>
        /// Creates a new instance of the <see cref="ExtendedStringBuilder"/> with the provided <code>string</code> as a base.
        /// </summary>
        /// <param name="baseString">The initial string in the buffer.</param>
        public ExtendedStringBuilder(string baseString)
            : this(baseString.Length)
        {
            Append(baseString);
            HasBeenAppended = false;
        }

        /// <summary>
        /// Creates a new instance of the <see cref="ExtendedStringBuilder"/> with the provided <see cref="ExtendedStringBuilder"/> as a base.
        /// </summary>
        /// <param name="baseBuilder">The <see cref="ExtendedStringBuilder"/> containing the base string to intialize to.</param>
        public ExtendedStringBuilder(ExtendedStringBuilder baseBuilder)
            : this(baseBuilder.Length)
        {
            Append(baseBuilder);
            HasBeenAppended = false;
        }

        /// <summary>
        /// Appends a <code>string</code> to the current <see cref="ExtendedStringBuilder"/>.
        /// </summary>
        /// <param name="s">The <code>string</code> to append.</param>
        /// <returns>The current <see cref="ExtendedStringBuilder"/> object.</returns>
        public ExtendedStringBuilder Append(string s)
        {
            _stringBuilder.Append(s);
            HasBeenAppended = true;

            return this;
        }

        /// <summary>
        /// Appends a <code>char</code> to the current <see cref="ExtendedStringBuilder"/>.
        /// </summary>
        /// <param name="c">The <code>char</code> to append.</param>
        /// <returns>The current <see cref="ExtendedStringBuilder"/> object.</returns>
        public ExtendedStringBuilder Append(char c)
        {
            _stringBuilder.Append(c);
            HasBeenAppended = true;

            return this;
        }

        /// <summary>
        /// Appends an <code>object</code> to the current <see cref="ExtendedStringBuilder"/>.
        /// </summary>
        /// <param name="o">The <code>object</code> to append.</param>
        /// <returns>The current <see cref="ExtendedStringBuilder"/> object.</returns>
        public ExtendedStringBuilder Append(object o)
        {
            _stringBuilder.Append(o);
            HasBeenAppended = true;

            return this;
        }

        /// <summary>
        /// Appends an <see cref="ExtendedStringBuilder"/> to the current <see cref="ExtendedStringBuilder"/>.
        /// </summary>
        /// <param name="e">The <see cref="ExtendedStringBuilder"/> to append.</param>
        /// <returns>The current <see cref="ExtendedStringBuilder"/> object.</returns>
        public ExtendedStringBuilder Append(ExtendedStringBuilder e)
        {
            _stringBuilder.Append(e);
            HasBeenAppended = true;

            return this;
        }

        /// <summary>
        /// Appends a <code>StringBuilder</code> to the current <see cref="ExtendedStringBuilder"/>.
        /// </summary>
        /// <param name="s">The <code>StringBuilder</code> to append.</param>
        /// <returns>The current <see cref="ExtendedStringBuilder"/> object.</returns>
        public ExtendedStringBuilder Append(StringBuilder s)
        {
            _stringBuilder.Append(s.ToString());
            HasBeenAppended = true;

            return this;
        }

        /// <summary>
        /// Appends a <code>string</code> to the current <see cref="ExtendedStringBuilder"/>.
        /// </summary>
        /// <param name="s">The <code>string</code> to append.</param>
        /// <returns>The current <see cref="ExtendedStringBuilder"/> object.</returns>
        public static ExtendedStringBuilder operator +(ExtendedStringBuilder sb, string s) => sb.Append(s);

        /// <summary>
        /// Appends a <code>char</code> to the current <see cref="ExtendedStringBuilder"/>.
        /// </summary>
        /// <param name="c">The <code>char</code> to append.</param>
        /// <returns>The current <see cref="ExtendedStringBuilder"/> object.</returns>
        public static ExtendedStringBuilder operator +(ExtendedStringBuilder sb, char c) => sb.Append(c);

        /// <summary>
        /// Appends an <code>object</code> to the current <see cref="ExtendedStringBuilder"/>.
        /// </summary>
        /// <param name="o">The <code>object</code> to append.</param>
        /// <returns>The current <see cref="ExtendedStringBuilder"/> object.</returns>
        public static ExtendedStringBuilder operator +(ExtendedStringBuilder sb, object o) => sb.Append(o);

        /// <summary>
        /// Appends an <see cref="ExtendedStringBuilder"/> to the current <see cref="ExtendedStringBuilder"/>.
        /// </summary>
        /// <param name="e">The <see cref="ExtendedStringBuilder"/> to append.</param>
        /// <returns>The current <see cref="ExtendedStringBuilder"/> object.</returns>
        public static ExtendedStringBuilder operator +(ExtendedStringBuilder sb, ExtendedStringBuilder e) => sb.Append(e);

        /// <summary>
        /// Appends a <code>StringBuilder</code> to the current <see cref="ExtendedStringBuilder"/>.
        /// </summary>
        /// <param name="s">The <code>StringBuilder</code> to append.</param>
        /// <returns>The current <see cref="ExtendedStringBuilder"/> object.</returns>
        public static ExtendedStringBuilder operator +(ExtendedStringBuilder sb, StringBuilder s) => sb.Append(s);

        /// <summary>
        /// Implicitly converts the current <see cref="ExtendedStringBuilder"/> to a <code>string</code>.
        /// </summary>
        /// <param name="sb">The <see cref="ExtendedStringBuilder"/> to convert.</param>
        public static implicit operator string (ExtendedStringBuilder sb) => sb.ToString();

        /// <summary>
        /// Explicitly converts the current <see cref="ExtendedStringBuilder"/> to a <code>StringBuilder</code>.
        /// </summary>
        /// <param name="esb">The <see cref="ExtendedStringBuilder"/> to convert.</param>
        public static explicit operator StringBuilder(ExtendedStringBuilder esb) => new StringBuilder(esb);

        /// <summary>
        /// Returns the current <see cref="ExtendedStringBuilder"/> as a <code>string</code>.
        /// </summary>
        /// <returns>A <code>string</code> representing the current <see cref="ExtendedStringBuilder"/>.</returns>
        public override string ToString() => _stringBuilder.ToString();

        /// <summary>
        /// Returns a substring of the current <see cref="ExtendedStringBuilder"/>.
        /// </summary>
        /// <param name="startIndex">The starting position of the substring.</param>
        /// <param name="length">The length of the substring.</param>
        /// <returns>The substring from the current <see cref="ExtendedStringBuilder"/> instance.</returns>
        public string ToString(int startIndex, int length) => _stringBuilder.ToString(startIndex, length);
    }
}
