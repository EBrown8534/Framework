using Evbpc.Framework.Utilities.Serialization;
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
    public struct Point : ISerializableByteArray
    {
        [FieldOffset(0)]
        private readonly ulong _packedValue;
        [FieldOffset(0)]
        private readonly int _x;
        [FieldOffset(4)]
        private readonly int _y;

        /// <summary>
        /// Constructs a new instance of <see cref="Point"/> from the specified <see cref="Size"/>.
        /// </summary>
        /// <param name="sz">The <see cref="Size"/> to construct the <see cref="Point"/> from.</param>
        /// <remarks>
        /// The <see cref="Size.Width"/> will become the <see cref="X"/> and the <see cref="Size.Height"/> will become the <see cref="Y"/>.
        /// </remarks>
        public Point(Size sz)
            : this()
        {
            _x = sz.Width;
            _y = sz.Height;
        }

        /// <summary>
        /// Constructs a new instance of <see cref="Point"/> from the specified <see cref="X"/> and <see cref="Y"/>.
        /// </summary>
        /// <param name="x">The value that should represent the <see cref="X"/>.</param>
        /// <param name="y">The value that should represent the <see cref="Y"/>.</param>
        public Point(int x, int y)
            : this()
        {
            _x = x;
            _y = y;
        }

        /// <summary>
        /// Returns a value that indicates if the current <see cref="Point"/> is empty or a default instance (both are equivalent).
        /// </summary>
        [Browsable(false)]
        public bool IsEmpty => this == Empty;

        /// <summary>
        /// Represents the horizontal position of the <see cref="Point"/>.
        /// </summary>
        public int X => _x;

        /// <summary>
        /// Represents the vertical position of the <see cref="Point"/>.
        /// </summary>
        public int Y => _y;

        /// <summary>
        /// Represents how large the <see cref="Point"/> when serialized to a byte-array.
        /// </summary>
        public int SizeInBytes => 8;

        /// <summary>
        /// Offsets a <see cref="Point"/> by the specified <see cref="Size"/>.
        /// </summary>
        /// <param name="pt">The <see cref="Point"/> that should be offset.</param>
        /// <param name="sz">The <see cref="Size"/> to offset by.</param>
        /// <returns>A new <see cref="Point"/> that has been offset.</returns>
        public static Point Add(Point pt, Size sz) => pt + sz;

        /// <summary>
        /// Constructs a new <see cref="Point"/> from the specified <see cref="PointF"/> by rounding all float values up to the nearest whole number.
        /// </summary>
        /// <param name="value">The <see cref="PointF"/> to be rounded up.</param>
        /// <returns>The <see cref="Point"/> representing the rounded <see cref="PointF"/>.</returns>
        public static Point Ceiling(PointF value) => new Point((int)Math.Ceiling(value.X), (int)Math.Ceiling(value.Y));

        /// <summary>
        /// Determines if the current <see cref="Point"/> is equal to the specified <code>object</code>.
        /// </summary>
        /// <param name="obj">The <code>object</code> to compare to the current <see cref="Point"/>.</param>
        /// <returns>A boolean value indicating equality.</returns>
        public override bool Equals(object obj) => obj is Point && (Point)obj == this;

        /// <summary>
        /// Gets a hash code for the current <see cref="Point"/>.
        /// </summary>
        /// <returns>An integer representing the current <see cref="Point"/>.</returns>
        public override int GetHashCode()
        {
            int hash = 17;

            unchecked
            {
                hash = hash * 23 + _x.GetHashCode();
                hash = hash * 23 + _y.GetHashCode();
            }

            return hash;
        }

        /// <summary>
        /// Offsets the current <see cref="Point"/> by the specified <see cref="Point"/>.
        /// </summary>
        /// <param name="p">The <see cref="Point"/> to offest this <see cref="Point"/> by.</param>
        /// <returns>The new <see cref="Point"/>.</returns>
        public Point Offset(Point p) => new Point(_x + p.X, _y + p.Y);

        /// <summary>
        /// Offsets the current <see cref="Point"/> by the specified <see cref="X"/> and <see cref="Y"/> values.
        /// </summary>
        /// <param name="dx">The value representing how far to offset the <see cref="X"/> of the current <see cref="Point"/>.</param>
        /// <param name="dy">The value representing how far to offset the <see cref="Y"/> of the current <see cref="Point"/>.</param>
        /// <returns>The new <see cref="Point"/>.</returns>
        public Point Offset(int dx, int dy) => new Point(_x + dx, _y + dy);

        /// <summary>
        /// Constructs a new <see cref="Point"/> from the specified <see cref="PointF"/> by rounding all values to the nearest whole number.
        /// </summary>
        /// <param name="value">The <see cref="PointF"/> to be rounded.</param>
        /// <returns>The <see cref="Point"/> representing the rounded <see cref="PointF"/>.</returns>
        public static Point Round(PointF value) => new Point((int)Math.Round(value.X), (int)Math.Round(value.Y));

        /// <summary>
        /// Subtracts a <see cref="Point"/> by a <see cref="Size"/>.
        /// </summary>
        /// <param name="pt">The <see cref="Point"/> to be subtracted from.</param>
        /// <param name="sz">The <see cref="Size"/> to subtract.</param>
        /// <returns>A <see cref="Point"/> representing the difference.</returns>
        public static Point Subtract(Point pt, Size sz) => pt - sz;

        /// <summary>
        /// Gets a string representation of a <see cref="Point"/>.
        /// </summary>
        /// <returns>A string that represents the <see cref="X"/> and <see cref="Y"/> coordinates of the <see cref="Point"/>.</returns>
        public override string ToString() => $"({_x},{_y})";

        /// <summary>
        /// Constructs a new <see cref="Point"/> from the specified <see cref="PointF"/> by rounding all values down to the nearest whole number.
        /// </summary>
        /// <param name="value">The <see cref="PointF"/> to be rounded down.</param>
        /// <returns>The <see cref="Point"/> representing the rounded <see cref="PointF"/>.</returns>
        public static Point Truncate(PointF value) => new Point((int)(value.X), (int)(value.Y));

        /// <summary>
        /// Offsets a <see cref="Point"/> object by the specified <see cref="Size"/>.
        /// </summary>
        /// <param name="pt">The <see cref="Point"/> that should be offset.</param>
        /// <param name="sz">The <see cref="Size"/> to offset by.</param>
        /// <returns>A new <see cref="Point"/> that has been offset.</returns>
        public static Point operator +(Point pt, Size sz) => new Point(pt.X + sz.Width, pt.Y + sz.Height);

        /// <summary>
        /// Determines if two <see cref="Point"/> objects are equal.
        /// </summary>
        /// <param name="left">The <see cref="Point"/> to check.</param>
        /// <param name="right">The <see cref="Point"/> to compare to.</param>
        /// <returns>True if the <see cref="Point"/> objects have the same value, false otherwise.</returns>
        public static bool operator ==(Point left, Point right) => left.X == right.X && left.Y == right.Y;

        /// <summary>
        /// Converts a <see cref="Point"/> to a <see cref="Size"/>.
        /// </summary>
        /// <param name="p">The <see cref="Point"/> to convert.</param>
        public static explicit operator Size(Point p) => new Size(p.X, p.Y);

        /// <summary>
        /// Converts a <see cref="Point"/> to a <see cref="PointF"/>.
        /// </summary>
        /// <param name="p">The <see cref="Point"/> to convert.</param>
        public static implicit operator PointF(Point p) => new PointF(p.X, p.Y);

        /// <summary>
        /// Determines if two <see cref="Point"/> objects are not equal.
        /// </summary>
        /// <param name="left">The <see cref="Point"/> to check.</param>
        /// <param name="right">The <see cref="Point"/> to compare to.</param>
        /// <returns>True if the <see cref="Point"/> objects do not have the same value, false otherwise.</returns>
        public static bool operator !=(Point left, Point right) => left.X != right.X || left.Y != right.Y;

        /// <summary>
        /// Subtracts a <see cref="Point"/> by a <see cref="Size"/>.
        /// </summary>
        /// <param name="pt">The <see cref="Point"/> to be subtracted from.</param>
        /// <param name="sz">The <see cref="Size"/> to subtract.</param>
        /// <returns>A <see cref="Point"/> representing the difference.</returns>
        public static Point operator -(Point pt, Size sz) => new Point(pt.X - sz.Width, pt.Y - sz.Height);

        /// <summary>
        /// Represents a <see cref="Point"/> with default values.
        /// </summary>
        public static readonly Point Empty = new Point(0, 0);

        /// <summary>
        /// Converts the current <see cref="Point"/> to a byte array.
        /// </summary>
        /// <returns>The byte array representing this <see cref="Point"/>.</returns>
        public byte[] GetBytes()
        {
            byte[] bytes = new byte[SizeInBytes];

            bytes[0] = (byte)((_x & 0xFF000000) >> 24);
            bytes[1] = (byte)((_x & 0x00FF0000) >> 16);
            bytes[2] = (byte)((_x & 0x0000FF00) >> 8);
            bytes[3] = (byte)((_x & 0x000000FF) >> 0);
            bytes[4] = (byte)((_y & 0xFF000000) >> 24);
            bytes[5] = (byte)((_y & 0x00FF0000) >> 16);
            bytes[6] = (byte)((_y & 0x0000FF00) >> 8);
            bytes[7] = (byte)((_y & 0x000000FF) >> 0);

            return bytes;
        }

        /// <summary>
        /// Constructs this <see cref="Point"/> from a byte array.
        /// </summary>
        /// <param name="data">The byte array to construct the <see cref="Point"/> from.</param>
        public void FromBytes(byte[] data)
        {
            if (data.Length != SizeInBytes)
            {
                throw new ArgumentException($"The parameter {nameof(data)} must be a {SizeInBytes} index byte-array.");
            }

            this = new Point((data[0] << 24 | data[1] << 16 | data[2] << 8 | data[3] << 0),
                             (data[4] << 24 | data[5] << 16 | data[6] << 8 | data[7] << 0));
        }
    }
}
