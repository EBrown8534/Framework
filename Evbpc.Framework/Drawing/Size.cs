using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Evbpc.Framework.Drawing
{
    /// <summary>
    /// Represents a relative extent of an object.
    /// </summary>
    [Serializable]
    [TypeConverter(typeof(SizeConverter))]
    public struct Size
    {
        /// <summary>
        /// Constructs a new instance of <see cref="Size"/> from the specified <see cref="Point"/>.
        /// </summary>
        /// <param name="pt">The <see cref="Point"/> to construct the <see cref="Size"/> from.</param>
        /// <remarks>
        /// The <see cref="Point.X"/> will become the <see cref="Width"/> and the <see cref="Point.Y"/> will be the <see cref="Height"/>.
        /// </remarks>
        public Size(Point pt)
        {
            Width = pt.X;
            Height = pt.Y;
        }

        /// <summary>
        /// Constructs a new instance of <see cref="Size"/> from the specified <see cref="Width"/> and <see cref="Height"/>.
        /// </summary>
        /// <param name="width">The value that should represent the <see cref="Width"/>.</param>
        /// <param name="height">The value that should represent the <see cref="Height"/>.</param>
        public Size(int width, int height)
        {
            Width = width;
            Height = height;
        }

        /// <summary>
        /// Represents the vertical distance of the <see cref="Size"/> object.
        /// </summary>
        public int Height { get; }

        /// <summary>
        /// Returns a value that indicates if the current <see cref="Size"/>  is empty or a default instance (both are equivalent).
        /// </summary>
        [Browsable(false)]
        public bool IsEmpty => this == Empty;

        /// <summary>
        /// Represents the horizontal distance of the <see cref="Size"/> object.
        /// </summary>
        public int Width { get; }

        /// <summary>
        /// Adds two <see cref="Size"/> structures together and returns the result.
        /// </summary>
        /// <param name="sz1">The first <see cref="Size"/> to add.</param>
        /// <param name="sz2">The second <see cref="Size"/> to add.</param>
        /// <returns>A new <see cref="Size"/> structure that is the addition of the provided structurs.</returns>
        public static Size Add(Size sz1, Size sz2) => sz1 + sz2;

        /// <summary>
        /// Constructs a new <see cref="Size"/> structure from the specified <see cref="SizeF"/> by rounding values up to the nearest whole number.
        /// </summary>
        /// <param name="value">The <see cref="Size"/> to be rounded up.</param>
        /// <returns>The <see cref="Size"/> representing the rounded <see cref="SizeF"/>.</returns>
        public static Size Ceiling(SizeF value) => new Size((int)Math.Ceiling(value.Width), (int)Math.Ceiling(value.Height));

        /// <summary>
        /// Determines if the current <see cref="Size"/> is equal to the specified <code>object</code>.
        /// </summary>
        /// <param name="obj">The <code>object</code> to compare to the current <see cref="Size"/>.</param>
        /// <returns>A boolean value indicating equality.</returns>
        public override bool Equals(object obj) => obj is Size && (Size)obj == this;

        /// <summary>
        /// Gets a hash code for the current <see cref="Size"/>.
        /// </summary>
        /// <returns>An integer representing the current <see cref="Size"/>.</returns>
        public override int GetHashCode() => base.GetHashCode();

        /// <summary>
        /// Constructs a new <see cref="Size"/> from the specified <see cref="SizeF"/> by rounding all values to the nearest whole number.
        /// </summary>
        /// <param name="value">The <see cref="SizeF"/> to be rounded.</param>
        /// <returns>The <see cref="Size"/> representing the rounded <see cref="SizeF"/>.</returns>
        public static Size Round(SizeF value) => new Size((int)Math.Round(value.Width), (int)Math.Round(value.Height));

        /// <summary>
        /// Subtracts a <see cref="Size"/> by another <see cref="Size"/>.
        /// </summary>
        /// <param name="sz1">The <see cref="Size"/> to be subtracted from.</param>
        /// <param name="sz2">The <see cref="Size"/> to subtract.</param>
        /// <returns>A <see cref="Size"/> representing the difference.</returns>
        public static Size Subtract(Size sz1, Size sz2) => sz1 - sz2;

        /// <summary>
        /// Gets a string representation of the current <see cref="Size"/>.
        /// </summary>
        /// <returns>A string that represents the <see cref="Width"/> and <see cref="Height"/> of the <see cref="Size"/>.</returns>
        public override string ToString() => $"({Width},{Height})";

        /// <summary>
        /// Constructs a new <see cref="Size"/> from the specified <see cref="SizeF"/> by rounding all values down to the nearest whole number.
        /// </summary>
        /// <param name="value">The <see cref="SizeF"/> to be rounded down.</param>
        /// <returns>The <see cref="Size"/> representing the rounded <see cref="SizeF"/>.</returns>
        public static Size Truncate(SizeF value) => new Size((int)(value.Width), (int)(value.Height));

        /// <summary>
        /// Adds two <see cref="Size"/> structures together and returns the result.
        /// </summary>
        /// <param name="sz1">The first <see cref="Size"/> to add.</param>
        /// <param name="sz2">The second <see cref="Size"/> to add.</param>
        /// <returns>A new <see cref="Size"/> structure that is the addition of the provided structurs.</returns>
        public static Size operator +(Size sz1, Size sz2) => new Size(sz1.Width + sz2.Width, sz1.Height + sz2.Height);

        /// <summary>
        /// Determines if two <see cref="Size"/> structures are equal.
        /// </summary>
        /// <param name="sz1">The <see cref="Size"/> to check.</param>
        /// <param name="sz2">The <see cref="Size"/> to compare to.</param>
        /// <returns>True if the <see cref="Size"/> structures have the same value, false otherwise.</returns>
        public static bool operator ==(Size sz1, Size sz2) => sz1.Width == sz2.Width && sz1.Height == sz2.Height;
        
        /// <summary>
        /// Convers a <see cref="Size"/> to a <see cref="Point"/>.
        /// </summary>
        /// <param name="size">The <see cref="Size"/> to convert.</param>
        public static explicit operator Point(Size size) => new Point(size.Width, size.Height);

        /// <summary>
        /// Convers a <see cref="Size"/> to a <see cref="SizeF"/>.
        /// </summary>
        /// <param name="p">The <see cref="Size"/> to convert.</param>
        public static implicit operator SizeF(Size p) => new SizeF(p.Width, p.Height);

        /// <summary>
        /// Determines if two <see cref="Size"/> structures are not equal.
        /// </summary>
        /// <param name="sz1">The <see cref="Size"/> to check.</param>
        /// <param name="sz2">The <see cref="Size"/> to compare to.</param>
        /// <returns>True if the <see cref="Size"/> structures do not have the same value, false otherwise.</returns>
        public static bool operator !=(Size sz1, Size sz2) => sz1.Width != sz2.Width || sz1.Height != sz2.Height;

        /// <summary>
        /// Subtracts a <see cref="Size"/> by another <see cref="Size"/>.
        /// </summary>
        /// <param name="sz1">The <see cref="Size"/> to be subtracted from.</param>
        /// <param name="sz2">The <see cref="Size"/> to subtract.</param>
        /// <returns>A <see cref="Size"/> representing the difference.</returns>
        public static Size operator -(Size sz1, Size sz2) => new Size(sz1.Width - sz2.Width, sz1.Height - sz2.Height);

        /// <summary>
        /// Represents a <see cref="Size"/> with default values.
        /// </summary>
        public static readonly Size Empty = new Size(0, 0);
    }
}
