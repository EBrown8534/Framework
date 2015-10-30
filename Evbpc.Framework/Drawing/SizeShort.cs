using Evbpc.Framework.Utilities.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Evbpc.Framework.Drawing
{
    /// <summary>
    /// Represents a size value consisting of two <code>short</code> values.
    /// </summary>
    [Serializable]
    public struct SizeShort : ISerializableByteArray
    {
        /// <summary>
        /// Represents the distance from top-to-bottom of the <see cref="SizeShort"/>.
        /// </summary>
        public short Height { get; }

        /// <summary>
        /// Returns a value indicating if the current <see cref="SizeShort"/> is empty or not.
        /// </summary>
        [Browsable(false)]
        public bool IsEmpty => this == Empty;

        /// <summary>
        /// Represents the distance from left-to-right of the <see cref="SizeShort"/>.
        /// </summary>
        public short Width { get; }

        /// <summary>
        /// Creates a new instance of <see cref="SizeShort"/> from a specified <see cref="Point"/>.
        /// </summary>
        /// <param name="pt">The <see cref="Point"/> that should be used to create the <see cref="SizeShort"/>.</param>
        public SizeShort(Point pt)
        {
            Width = (short)(pt.X);
            Height = (short)(pt.Y);
        }

        /// <summary>
        /// Creates a new instance of <see cref="SizeShort"/> from a specified <see cref="PointShort"/>.
        /// </summary>
        /// <param name="pt">The <see cref="PointShort"/> that should be used to create the <see cref="SizeShort"/>.</param>
        public SizeShort(PointShort pt)
        {
            Width = (pt.X);
            Height = (pt.Y);
        }

        /// <summary>
        /// Creates a new instance of <see cref="SizeShort"/> from the specified values.
        /// </summary>
        /// <param name="height">The <see cref="Height"/> of the <see cref="SizeShort"/>.</param>
        /// <param name="width">The <see cref="Width"/> of the <see cref="SizeShort"/>.</param>
        public SizeShort(short width, short height)
        {
            Width = width;
            Height = height;
        }

        /// <summary>
        /// Adds two <see cref="SizeShort"/> values together and returns the result.
        /// </summary>
        /// <param name="sz1">The first <see cref="SizeShort"/> to add.</param>
        /// <param name="sz2">The second <see cref="SizeShort"/> to add.</param>
        /// <returns>The sum of the two <see cref="SizeShort"/> structures.</returns>
        public static SizeShort Add(SizeShort sz1, SizeShort sz2) => sz1 + sz2;

        /// <summary>
        /// Rounds a <see cref="SizeF"/> value up to the nearest <see cref="SizeShort"/> value.
        /// </summary>
        /// <param name="value">The <see cref="SizeF"/> value to round.</param>
        /// <returns>The <see cref="SizeShort"/> representing the rounded value.</returns>
        public static SizeShort Ceiling(SizeF value) => new SizeShort((short)Math.Ceiling(value.Width), (short)Math.Ceiling(value.Height));

        /// <summary>
        /// Determines if the current <see cref="SizeShort"/> is equal to the specified object.
        /// </summary>
        /// <param name="obj">The object to compare the <see cref="SizeShort"/> to.</param>
        /// <returns>True if the object is equal to the current <see cref="SizeShort"/>.</returns>
        public override bool Equals(object obj) => obj is SizeShort && (SizeShort)obj == this;

        /// <summary>
        /// Computes the hash code of the current <see cref="SizeShort"/>.
        /// </summary>
        /// <returns>The hash code of the current <see cref="SizeShort"/>.</returns>
        public override int GetHashCode() => Width << 16 | (ushort)Height;

        /// <summary>
        /// Rounds a <see cref="SizeF"/> value to the nearest <see cref="SizeShort"/> value.
        /// </summary>
        /// <param name="value">The <see cref="SizeF"/> value to round.</param>
        /// <returns>The <see cref="SizeShort"/> representing the rounded value.</returns>
        public static SizeShort Round(SizeF value) => new SizeShort((short)Math.Round(value.Width), (short)Math.Round(value.Height));

        /// <summary>
        /// Subtracs two <see cref="SizeShort"/> values and returns the result.
        /// </summary>
        /// <param name="sz1">The intial <see cref="SizeShort"/>.</param>
        /// <param name="sz2">The <see cref="SizeShort"/> to subtract.</param>
        /// <returns>The difference between the two <see cref="SizeShort"/> structures.</returns>
        public static SizeShort Subtract(SizeShort sz1, SizeShort sz2) => sz1 - sz2;

        /// <summary>
        /// Returns a string representing the current <see cref="SizeShort"/> object.
        /// </summary>
        /// <returns>The string representation of the <see cref="SizeShort"/> object.</returns>
        public override string ToString() => $"({Width},{Height})";

        /// <summary>
        /// Rounds a <see cref="SizeF"/> value down to the nearest <see cref="SizeShort"/> value.
        /// </summary>
        /// <param name="value">The <see cref="SizeF"/> value to round.</param>
        /// <returns>The <see cref="SizeShort"/> representing the rounded value.</returns>
        public static SizeShort Truncate(SizeF value) => new SizeShort((short)(value.Width), (short)(value.Height));

        /// <summary>
        /// Adds two <see cref="SizeShort"/> structures together.
        /// </summary>
        /// <param name="sz1">The first <see cref="SizeShort"/> to add.</param>
        /// <param name="sz2">The second <see cref="SizeShort"/> to add.</param>
        /// <returns>The sum of the two <see cref="SizeShort"/> structures.</returns>
        public static SizeShort operator +(SizeShort sz1, SizeShort sz2) => new SizeShort((short)(sz1.Width + sz2.Width), (short)(sz1.Height + sz2.Height));

        /// <summary>
        /// Determines if two <see cref="SizeShort"/> structures are equal.
        /// </summary>
        /// <param name="sz1">The first <see cref="SizeShort"/> to check.</param>
        /// <param name="sz2">The second <see cref="SizeShort"/> to check.</param>
        /// <returns>True if the <see cref="SizeShort"/> structures are equal.</returns>
        public static bool operator ==(SizeShort sz1, SizeShort sz2) => sz1.Width == sz2.Width && sz1.Height == sz2.Height;

        /// <summary>
        /// Converts a <see cref="SizeShort"/> value to a <see cref="Point"/> value.
        /// </summary>
        /// <param name="size">The <see cref="SizeShort"/> to convert.</param>
        public static explicit operator Point(SizeShort size) => new Point(size.Width, size.Height);

        /// <summary>
        /// Converts a <see cref="SizeShort"/> value to a <see cref="PointShort"/> value.
        /// </summary>
        /// <param name="size">The <see cref="SizeShort"/> to convert.</param>
        public static explicit operator PointShort(SizeShort size) => new PointShort(size.Width, size.Height);

        /// <summary>
        /// Converts a <see cref="SizeShort"/> value to a <see cref="SizeF"/> value.
        /// </summary>
        /// <param name="size">The <see cref="SizeShort"/> to convert.</param>
        public static implicit operator SizeF(SizeShort size) => new SizeF(size.Width, size.Height);

        /// <summary>
        /// Converts a <see cref="SizeShort"/> value to a <see cref="Size"/> value.
        /// </summary>
        /// <param name="size">The <see cref="SizeShort"/> to convert.</param>
        public static implicit operator Size(SizeShort size) => new Size(size.Width, size.Height);

        /// <summary>
        /// Determines if two <see cref="SizeShort"/> structures are not equal.
        /// </summary>
        /// <param name="sz1">The first <see cref="SizeShort"/> to check.</param>
        /// <param name="sz2">The second <see cref="SizeShort"/> to check.</param>
        /// <returns>True if the <see cref="SizeShort"/> structures are not equal.</returns>
        public static bool operator !=(SizeShort sz1, SizeShort sz2) => sz1.Width != sz2.Width || sz1.Height != sz2.Height;

        /// <summary>
        /// Subtracs two <see cref="SizeShort"/> values and returns the result.
        /// </summary>
        /// <param name="sz1">The intial <see cref="SizeShort"/>.</param>
        /// <param name="sz2">The <see cref="SizeShort"/> to subtract.</param>
        /// <returns>The difference between the two <see cref="SizeShort"/> structures.</returns>
        public static SizeShort operator -(SizeShort sz1, SizeShort sz2) => new SizeShort((short)(sz1.Width - sz2.Width), (short)(sz1.Height - sz2.Height));

        /// <summary>
        /// Returns an empty instance of a <see cref="SizeShort"/>.
        /// </summary>
        public static readonly SizeShort Empty = new SizeShort(0, 0);

        #region Serialization/Deserialization
        /// <summary>
        /// Inherited from <see cref="ISerializableByteArray"/>. Gets the byte-array for the current <see cref="SizeShort"/> object.
        /// </summary>
        /// <returns>A byte-array representing the current <see cref="SizeShort"/>.</returns>
        public byte[] GetBytes()
        {
            byte[] result = new byte[4];

            result[0] = (byte)((Width & 0xFF00) >> 8);
            result[1] = (byte)((Width & 0x00FF) >> 0);
            result[2] = (byte)((Height & 0xFF00) >> 8);
            result[3] = (byte)((Height & 0x00FF) >> 0);

            return result;
        }

        /// <summary>
        /// Inherited from <see cref="ISerializableByteArray"/>. Sets the current <see cref="SizeShort"/> object from the byte array.
        /// </summary>
        public void FromBytes(byte[] data)
        {
            if (data.Length != SizeInBytes)
            {
                throw new ArgumentException($"Parameter {nameof(data)} must be exactly {SizeInBytes} bytes.");
            }

            this = new SizeShort((short)(((uint)data[0]) << 8 | ((uint)data[1])),
                                 (short)(((uint)data[2]) << 8 | ((uint)data[3])));
        }

        /// <summary>
        /// Inherited from <see cref="ISerializableByteArray"/>. Returns how many bytes will be used in serializing the <see cref="SizeShort"/>.
        /// </summary>
        public int SizeInBytes => 4;
        #endregion
    }
}
