using Evbpc.Framework.Utilities.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Evbpc.Framework.Drawing
{
    /// <summary>
    /// Represents a size value consisting of two <code>byte</code> values.
    /// </summary>
    [Serializable]
    public struct SizeByte : ISerializableByteArray
    {
        /// <summary>
        /// Represents the distance from top-to-bottom of the <see cref="SizeByte"/>.
        /// </summary>
        public byte Height { get; }

        /// <summary>
        /// Returns a value indicating if the current <see cref="SizeByte"/> is empty or not.
        /// </summary>
        [Browsable(false)]
        public bool IsEmpty => this == Empty;

        /// <summary>
        /// Represents the distance from left-to-right of the <see cref="SizeByte"/>.
        /// </summary>
        public byte Width { get; }

        /// <summary>
        /// Creates a new instance of <see cref="SizeByte"/> from a specified <see cref="Point"/>.
        /// </summary>
        /// <param name="pt">The <see cref="Point"/> that should be used to create the <see cref="SizeByte"/>.</param>
        public SizeByte(Point pt)
        {
            Width = (byte)(pt.X);
            Height = (byte)(pt.Y);
        }

        /// <summary>
        /// Creates a new instance of <see cref="SizeByte"/> from the specified values.
        /// </summary>
        /// <param name="height">The <see cref="Height"/> of the <see cref="SizeByte"/>.</param>
        /// <param name="width">The <see cref="Width"/> of the <see cref="SizeByte"/>.</param>
        public SizeByte(byte width, byte height)
        {
            Width = width;
            Height = height;
        }

        /// <summary>
        /// Adds two <see cref="SizeByte"/> values together and returns the result.
        /// </summary>
        /// <param name="sz1">The first <see cref="SizeByte"/> to add.</param>
        /// <param name="sz2">The second <see cref="SizeByte"/> to add.</param>
        /// <returns>The sum of the two <see cref="SizeByte"/> structures.</returns>
        public static SizeByte Add(SizeByte sz1, SizeByte sz2) => sz1 + sz2;

        /// <summary>
        /// Rounds a <see cref="SizeF"/> value up to the nearest <see cref="SizeByte"/> value.
        /// </summary>
        /// <param name="value">The <see cref="SizeF"/> value to round.</param>
        /// <returns>The <see cref="SizeByte"/> representing the rounded value.</returns>
        public static SizeByte Ceiling(SizeF value) => new SizeByte((byte)Math.Ceiling(value.Width), (byte)Math.Ceiling(value.Height));

        /// <summary>
        /// Determines if the current <see cref="SizeByte"/> is equal to the specified object.
        /// </summary>
        /// <param name="obj">The object to compare the <see cref="SizeByte"/> to.</param>
        /// <returns>True if the object is equal to the current <see cref="SizeByte"/>.</returns>
        public override bool Equals(object obj) => obj is SizeByte && (SizeByte)obj == this;

        /// <summary>
        /// Computes the hash code of the current <see cref="SizeShort"/>.
        /// </summary>
        /// <returns>The hash code of the current <see cref="SizeShort"/>.</returns>
        public override int GetHashCode() => Width << 8 | Height;

        /// <summary>
        /// Rounds a <see cref="SizeF"/> value to the nearest <see cref="SizeByte"/> value.
        /// </summary>
        /// <param name="value">The <see cref="SizeF"/> value to round.</param>
        /// <returns>The <see cref="SizeByte"/> representing the rounded value.</returns>
        public static SizeByte Round(SizeF value) => new SizeByte((byte)Math.Round(value.Width), (byte)Math.Round(value.Height));

        /// <summary>
        /// Subtracs two <see cref="SizeByte"/> values and returns the result.
        /// </summary>
        /// <param name="sz1">The intial <see cref="SizeByte"/>.</param>
        /// <param name="sz2">The <see cref="SizeByte"/> to subtract.</param>
        /// <returns>The difference between the two <see cref="SizeByte"/> structures.</returns>
        public static SizeByte Subtract(SizeByte sz1, SizeByte sz2) => sz1 - sz2;

        /// <summary>
        /// Returns a string representing the current <see cref="SizeByte"/> object.
        /// </summary>
        /// <returns>The string representation of the <see cref="SizeByte"/> object.</returns>
        public override string ToString() => $"({Width},{Height})";

        /// <summary>
        /// Rounds a <see cref="SizeF"/> value down to the nearest <see cref="SizeByte"/> value.
        /// </summary>
        /// <param name="value">The <see cref="SizeF"/> value to round.</param>
        /// <returns>The <see cref="SizeByte"/> representing the rounded value.</returns>
        public static SizeByte Truncate(SizeF value) => new SizeByte((byte)(value.Width), (byte)(value.Height));

        /// <summary>
        /// Adds two <see cref="SizeByte"/> structures together.
        /// </summary>
        /// <param name="sz1">The first <see cref="SizeByte"/> to add.</param>
        /// <param name="sz2">The second <see cref="SizeByte"/> to add.</param>
        /// <returns>The sum of the two <see cref="SizeByte"/> structures.</returns>
        public static SizeByte operator +(SizeByte sz1, SizeByte sz2) => new SizeByte((byte)(sz1.Width + sz2.Width), (byte)(sz1.Height + sz2.Height));

        /// <summary>
        /// Determines if two <see cref="SizeByte"/> structures are equal.
        /// </summary>
        /// <param name="sz1">The first <see cref="SizeByte"/> to check.</param>
        /// <param name="sz2">The second <see cref="SizeByte"/> to check.</param>
        /// <returns>True if the <see cref="SizeByte"/> structures are equal.</returns>
        public static bool operator ==(SizeByte sz1, SizeByte sz2) => sz1.Width == sz2.Width && sz1.Height == sz2.Height;

        /// <summary>
        /// Converts a <see cref="SizeByte"/> value to a <see cref="Point"/> value.
        /// </summary>
        /// <param name="size">The <see cref="SizeByte"/> to convert.</param>
        public static explicit operator Point(SizeByte size) => new Point(size.Width, size.Height);

        /// <summary>
        /// Converts a <see cref="SizeByte"/> value to a <see cref="PointShort"/> value.
        /// </summary>
        /// <param name="size">The <see cref="SizeByte"/> to convert.</param>
        public static explicit operator PointShort(SizeByte size) => new PointShort(size.Width, size.Height);

        /// <summary>
        /// Converts a <see cref="SizeByte"/> value to a <see cref="SizeF"/> value.
        /// </summary>
        /// <param name="size">The <see cref="SizeByte"/> to convert.</param>
        public static implicit operator SizeF(SizeByte size) => new SizeF(size.Width, size.Height);

        /// <summary>
        /// Converts a <see cref="SizeByte"/> value to a <see cref="Size"/> value.
        /// </summary>
        /// <param name="size">The <see cref="SizeByte"/> to convert.</param>
        public static implicit operator Size(SizeByte size) => new Size(size.Width, size.Height);

        /// <summary>
        /// Converts a <see cref="SizeByte"/> value to a <see cref="SizeShort"/> value.
        /// </summary>
        /// <param name="size">The <see cref="SizeByte"/> to convert.</param>
        public static implicit operator SizeShort(SizeByte size) => new SizeShort(size.Width, size.Height);

        /// <summary>
        /// Determines if two <see cref="SizeByte"/> structures are not equal.
        /// </summary>
        /// <param name="sz1">The first <see cref="SizeByte"/> to check.</param>
        /// <param name="sz2">The second <see cref="SizeByte"/> to check.</param>
        /// <returns>True if the <see cref="SizeByte"/> structures are not equal.</returns>
        public static bool operator !=(SizeByte sz1, SizeByte sz2) => sz1.Width != sz2.Width || sz1.Height != sz2.Height;

        /// <summary>
        /// Subtracs two <see cref="SizeByte"/> values and returns the result.
        /// </summary>
        /// <param name="sz1">The intial <see cref="SizeByte"/>.</param>
        /// <param name="sz2">The <see cref="SizeByte"/> to subtract.</param>
        /// <returns>The difference between the two <see cref="SizeByte"/> structures.</returns>
        public static SizeByte operator -(SizeByte sz1, SizeByte sz2) => new SizeByte((byte)(sz1.Width - sz2.Width), (byte)(sz1.Height - sz2.Height));

        /// <summary>
        /// Returns an empty instance of a <see cref="SizeByte"/>.
        /// </summary>
        public static readonly SizeByte Empty = new SizeByte(0, 0);

        #region Serialization/Deserialization
        /// <summary>
        /// Inherited from <see cref="ISerializableByteArray"/>. Gets the byte-array for the current <see cref="SizeByte"/> structure.
        /// </summary>
        /// <returns>A byte-array representing the current <see cref="SizeByte"/>.</returns>
        public byte[] GetBytes()
        {
            return new byte[] { Width, Height };
        }

        /// <summary>
        /// Inherited from <see cref="ISerializableByteArray"/>. Sets the current <see cref="SizeByte"/> structure from the byte array.
        /// </summary>
        public void FromBytes(byte[] data)
        {
            if (data.Length != SizeInBytes)
            {
                throw new ArgumentException($"Parameter {nameof(data)} must be exactly {SizeInBytes} bytes.");
            }

            this = new SizeByte(data[0], data[1]);
        }

        /// <summary>
        /// Inherited from <see cref="ISerializableByteArray"/>. Returns how many bytes will be used in serializing the <see cref="SizeShort"/>.
        /// </summary>
        public int SizeInBytes => 2;
        #endregion
    }
}
