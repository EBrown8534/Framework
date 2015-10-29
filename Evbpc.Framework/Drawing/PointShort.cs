using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Evbpc.Framework.Drawing
{
    /// <summary>
    /// Represents a position in 2D space.
    /// </summary>
    [Serializable]
    [TypeConverter(typeof(PointConverter))]
    [StructLayout(LayoutKind.Explicit)]
    public struct PointShort
    {
        [FieldOffset(0)]
        private readonly uint _packedValue;
        [FieldOffset(0)]
        private readonly short _x;
        [FieldOffset(2)]
        private readonly short _y;

        /// <summary>
        /// Constructs a new instance of <see cref="PointShort"/> from the specified <see cref="Size"/>.
        /// </summary>
        /// <param name="sz">The <see cref="Size"/> to construct the <see cref="PointShort"/> from.</param>
        /// <remarks>
        /// The <see cref="Size.Width"/> will become the <see cref="X"/> and the <see cref="Size.Height"/> will become the <see cref="Y"/>.
        /// </remarks>
        public PointShort(Size sz)
            : this()
        {
            _x = (short)(sz.Width);
            _y = (short)(sz.Height);
        }

        /// <summary>
        /// Constructs a new instance of <see cref="PointShort"/> from the specified <see cref="X"/> and <see cref="Y"/>.
        /// </summary>
        /// <param name="x">The value that should represent the <see cref="X"/>.</param>
        /// <param name="y">The value that should represent the <see cref="Y"/>.</param>
        public PointShort(short x, short y)
            : this()
        {
            _x = x;
            _y = y;
        }

        /// <summary>
        /// Constructs a new instance of <see cref="PointShort"/> from the specified <code>uint</code>.
        /// </summary>
        /// <param name="packedValue">The <code>uint</code> representing the current <see cref="PointShort"/>.</param>
        public PointShort(uint packedValue)
            : this()
        {
            _packedValue = packedValue;
        }

        /// <summary>
        /// Returns a value that indicates if the current <see cref="PointShort"/> is empty or a default instance (both are equivalent).
        /// </summary>
        [Browsable(false)]
        public bool IsEmpty => this == Empty;

        /// <summary>
        /// Represents the horizontal position of the <see cref="PointShort"/>.
        /// </summary>
        public short X => _x;

        /// <summary>
        /// Represents the vertical position of the <see cref="PointShort"/>.
        /// </summary>
        public short Y => _y;

        /// <summary>
        /// Offsets a <see cref="PointShort"/> by the specified <see cref="Size"/>.
        /// </summary>
        /// <param name="pt">The <see cref="PointShort"/> that should be offset.</param>
        /// <param name="sz">The <see cref="Size"/> to offset by.</param>
        /// <returns>A new <see cref="PointShort"/> that has been offset.</returns>
        public static PointShort Add(PointShort pt, Size sz) => pt + sz;

        /// <summary>
        /// Offsets a <see cref="PointShort"/> by the specified <see cref="SizeByte"/>.
        /// </summary>
        /// <param name="pt">The <see cref="PointShort"/> that should be offset.</param>
        /// <param name="sz">The <see cref="SizeByte"/> to offset by.</param>
        /// <returns>A new <see cref="PointShort"/> that has been offset.</returns>
        public static PointShort Add(PointShort pt, SizeByte sz) => pt + sz;

        /// <summary>
        /// Offsets a <see cref="PointShort"/> by the specified <see cref="SizeShort"/>.
        /// </summary>
        /// <param name="pt">The <see cref="PointShort"/> that should be offset.</param>
        /// <param name="sz">The <see cref="SizeShort"/> to offset by.</param>
        /// <returns>A new <see cref="PointShort"/> that has been offset.</returns>
        public static PointShort Add(PointShort pt, SizeShort sz) => pt + sz;

        /// <summary>
        /// Constructs a new <see cref="PointShort"/> from the specified <see cref="PointF"/> by rounding all float values up to the nearest whole number.
        /// </summary>
        /// <param name="value">The <see cref="PointF"/> to be rounded up.</param>
        /// <returns>The <see cref="PointShort"/> representing the rounded <see cref="PointF"/>.</returns>
        public static PointShort Ceiling(PointF value) => new PointShort((short)Math.Ceiling(value.X), (short)Math.Ceiling(value.Y));

        /// <summary>
        /// Determines if the current <see cref="PointShort"/> is equal to the specified <code>object</code>.
        /// </summary>
        /// <param name="obj">The <code>object</code> to compare to the current <see cref="PointShort"/>.</param>
        /// <returns>A boolean value indicating equality.</returns>
        public override bool Equals(object obj) => obj is PointShort && (PointShort)obj == this;

        /// <summary>
        /// Gets a hash code for the current <see cref="PointShort"/>.
        /// </summary>
        /// <returns>An integer representing the current <see cref="PointShort"/>.</returns>
        public override int GetHashCode() => (int)_packedValue;

        /// <summary>
        /// Offsets the current <see cref="PointShort"/> by the specified <see cref="PointShort"/>.
        /// </summary>
        /// <param name="p">The <see cref="PointShort"/> to offest this <see cref="PointShort"/> by.</param>
        /// <returns>The new <see cref="PointShort"/>.</returns>
        public PointShort Offset(PointShort p) => new PointShort((short)(_x + p.X), (short)(_y + p.Y));

        /// <summary>
        /// Offsets the current <see cref="PointShort"/> by the specified <see cref="X"/> and <see cref="Y"/> values.
        /// </summary>
        /// <param name="dx">The value representing how far to offset the <see cref="X"/> of the current <see cref="PointShort"/>.</param>
        /// <param name="dy">The value representing how far to offset the <see cref="Y"/> of the current <see cref="PointShort"/>.</param>
        /// <returns>The new <see cref="PointShort"/>.</returns>
        public PointShort Offset(short dx, short dy) => new PointShort((short)(_x + dx), (short)(_y + dy));

        /// <summary>
        /// Constructs a new <see cref="PointShort"/> from the specified <see cref="PointF"/> by rounding all values to the nearest whole number.
        /// </summary>
        /// <param name="value">The <see cref="PointF"/> to be rounded.</param>
        /// <returns>The <see cref="PointShort"/> representing the rounded <see cref="PointF"/>.</returns>
        public static PointShort Round(PointF value) => new PointShort((short)Math.Round(value.X), (short)Math.Round(value.Y));

        /// <summary>
        /// Subtracts a <see cref="PointShort"/> by a <see cref="Size"/>.
        /// </summary>
        /// <param name="pt">The <see cref="PointShort"/> to be subtracted from.</param>
        /// <param name="sz">The <see cref="Size"/> to subtract.</param>
        /// <returns>A <see cref="PointShort"/> representing the difference.</returns>
        public static PointShort Subtract(PointShort pt, Size sz) => pt - sz;

        /// <summary>
        /// Subtracts a <see cref="PointShort"/> by a <see cref="SizeByte"/>.
        /// </summary>
        /// <param name="pt">The <see cref="PointShort"/> to be subtracted from.</param>
        /// <param name="sz">The <see cref="SizeByte"/> to subtract.</param>
        /// <returns>A <see cref="PointShort"/> representing the difference.</returns>
        public static PointShort Subtract(PointShort pt, SizeByte sz) => pt - sz;

        /// <summary>
        /// Subtracts a <see cref="PointShort"/> by a <see cref="SizeShort"/>.
        /// </summary>
        /// <param name="pt">The <see cref="PointShort"/> to be subtracted from.</param>
        /// <param name="sz">The <see cref="SizeShort"/> to subtract.</param>
        /// <returns>A <see cref="PointShort"/> representing the difference.</returns>
        public static PointShort Subtract(PointShort pt, SizeShort sz) => pt - sz;

        /// <summary>
        /// Gets a string representation of a <see cref="PointShort"/>.
        /// </summary>
        /// <returns>A string that represents the <see cref="X"/> and <see cref="Y"/> coordinates of the <see cref="PointShort"/>.</returns>
        public override string ToString() => $"({_x},{_y})";

        /// <summary>
        /// Constructs a new <see cref="PointShort"/> from the specified <see cref="PointF"/> by rounding all values down to the nearest whole number.
        /// </summary>
        /// <param name="value">The <see cref="PointF"/> to be rounded down.</param>
        /// <returns>The <see cref="PointShort"/> representing the rounded <see cref="PointF"/>.</returns>
        public static PointShort Truncate(PointF value) => new PointShort((short)(value.X), (short)(value.Y));

        /// <summary>
        /// Gets a <code>uint</code> that represents the current <see cref="PointShort"/>.
        /// </summary>
        /// <returns>A <code>uint</code> which can reconstruct the current <see cref="PointShort"/>.</returns>
        public uint GetPackedValue() => _packedValue;

        /// <summary>
        /// Offsets a <see cref="PointShort"/> object by the specified <see cref="Size"/>.
        /// </summary>
        /// <param name="pt">The <see cref="PointShort"/> that should be offset.</param>
        /// <param name="sz">The <see cref="Size"/> to offset by.</param>
        /// <returns>A new <see cref="PointShort"/> that has been offset.</returns>
        public static PointShort operator +(PointShort pt, Size sz) => new PointShort((short)(pt.X + sz.Width), (short)(pt.Y + sz.Height));

        /// <summary>
        /// Offsets a <see cref="PointShort"/> object by the specified <see cref="SizeByte"/>.
        /// </summary>
        /// <param name="pt">The <see cref="PointShort"/> that should be offset.</param>
        /// <param name="sz">The <see cref="SizeByte"/> to offset by.</param>
        /// <returns>A new <see cref="PointShort"/> that has been offset.</returns>
        public static PointShort operator +(PointShort pt, SizeByte sz) => new PointShort((short)(pt.X + sz.Width), (short)(pt.Y + sz.Height));

        /// <summary>
        /// Offsets a <see cref="PointShort"/> object by the specified <see cref="SizeShort"/>.
        /// </summary>
        /// <param name="pt">The <see cref="PointShort"/> that should be offset.</param>
        /// <param name="sz">The <see cref="SizeShort"/> to offset by.</param>
        /// <returns>A new <see cref="PointShort"/> that has been offset.</returns>
        public static PointShort operator +(PointShort pt, SizeShort sz) => new PointShort((short)(pt.X + sz.Width), (short)(pt.Y + sz.Height));

        /// <summary>
        /// Determines if two <see cref="PointShort"/> objects are equal.
        /// </summary>
        /// <param name="left">The <see cref="PointShort"/> to check.</param>
        /// <param name="right">The <see cref="PointShort"/> to compare to.</param>
        /// <returns>True if the <see cref="PointShort"/> objects have the same value, false otherwise.</returns>
        public static bool operator ==(PointShort left, PointShort right) => left.X == right.X && left.Y == right.Y;

        /// <summary>
        /// Converts a <see cref="PointShort"/> to a <see cref="Size"/>.
        /// </summary>
        /// <param name="p">The <see cref="PointShort"/> to convert.</param>
        public static explicit operator Size(PointShort p) => new Size(p.X, p.Y);

        /// <summary>
        /// Converts a <see cref="PointShort"/> to a <see cref="SizeShort"/>.
        /// </summary>
        /// <param name="p">The <see cref="PointShort"/> to convert.</param>
        public static explicit operator SizeShort(PointShort p) => new SizeShort(p.X, p.Y);

        /// <summary>
        /// Converts a <see cref="PointShort"/> to a <see cref="PointF"/>.
        /// </summary>
        /// <param name="p">The <see cref="PointShort"/> to convert.</param>
        public static implicit operator PointF(PointShort p) => new PointF(p.X, p.Y);

        /// <summary>
        /// Determines if two <see cref="PointShort"/> objects are not equal.
        /// </summary>
        /// <param name="left">The <see cref="PointShort"/> to check.</param>
        /// <param name="right">The <see cref="PointShort"/> to compare to.</param>
        /// <returns>True if the <see cref="PointShort"/> objects do not have the same value, false otherwise.</returns>
        public static bool operator !=(PointShort left, PointShort right) => left.X != right.X || left.Y != right.Y;

        /// <summary>
        /// Subtracts a <see cref="PointShort"/> by a <see cref="Size"/>.
        /// </summary>
        /// <param name="pt">The <see cref="PointShort"/> to be subtracted from.</param>
        /// <param name="sz">The <see cref="Size"/> to subtract.</param>
        /// <returns>A <see cref="PointShort"/> representing the difference.</returns>
        public static PointShort operator -(PointShort pt, Size sz) => new PointShort((short)(pt.X - sz.Width), (short)(pt.Y - sz.Height));

        /// <summary>
        /// Subtracts a <see cref="PointShort"/> by a <see cref="SizeByte"/>.
        /// </summary>
        /// <param name="pt">The <see cref="PointShort"/> to be subtracted from.</param>
        /// <param name="sz">The <see cref="SizeByte"/> to subtract.</param>
        /// <returns>A <see cref="PointShort"/> representing the difference.</returns>
        public static PointShort operator -(PointShort pt, SizeByte sz) => new PointShort((short)(pt.X - sz.Width), (short)(pt.Y - sz.Height));

        /// <summary>
        /// Subtracts a <see cref="PointShort"/> by a <see cref="SizeShort"/>.
        /// </summary>
        /// <param name="pt">The <see cref="PointShort"/> to be subtracted from.</param>
        /// <param name="sz">The <see cref="SizeShort"/> to subtract.</param>
        /// <returns>A <see cref="PointShort"/> representing the difference.</returns>
        public static PointShort operator -(PointShort pt, SizeShort sz) => new PointShort((short)(pt.X - sz.Width), (short)(pt.Y - sz.Height));

        /// <summary>
        /// Represents a <see cref="PointShort"/> with default values.
        /// </summary>
        public static readonly PointShort Empty = new PointShort(0, 0);
    }
}
