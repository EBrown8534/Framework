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
    [TypeConverter(typeof(SizeFConverter))]
    public struct SizeF
    {
        /// <summary>
        /// Constructs a new instance of <see cref="SizeF"/> from the specified <see cref="PointF"/>.
        /// </summary>
        /// <param name="pt">The <see cref="PointF"/> to construct the <see cref="SizeF"/> from.</param>
        /// <remarks>
        /// The <see cref="PointF.X"/> will become the <see cref="Width"/> and the <see cref="PointF.Y"/> will be the <see cref="Height"/>.
        /// </remarks>
        public SizeF(PointF pt)
        {
            Width = pt.X;
            Height = pt.Y;
        }

        /// <summary>
        /// Constructs a new instance of <see cref="SizeF"/> from the specified <see cref="Width"/> and <see cref="Height"/>.
        /// </summary>
        /// <param name="width">The value that should represent the <see cref="Width"/>.</param>
        /// <param name="height">The value that should represent the <see cref="Height"/>.</param>
        public SizeF(float width, float height)
        {
            Width = width;
            Height = height;
        }

        /// <summary>
        /// Represents the vertical distance of the <see cref="SizeF"/> object.
        /// </summary>
        public float Height { get; }

        /// <summary>
        /// Returns a value that indicates if the current <see cref="SizeF"/>  is empty or a default instance (both are equivalent).
        /// </summary>
        [Browsable(false)]
        public bool IsEmpty => this == Empty;

        /// <summary>
        /// Represents the horizontal distance of the <see cref="SizeF"/> object.
        /// </summary>
        public float Width { get; }

        /// <summary>
        /// Adds two <see cref="SizeF"/> structures together and returns the result.
        /// </summary>
        /// <param name="sz1">The first <see cref="SizeF"/> to add.</param>
        /// <param name="sz2">The second <see cref="SizeF"/> to add.</param>
        /// <returns>A new <see cref="SizeF"/> structure that is the addition of the provided structurs.</returns>
        public static SizeF Add(SizeF sz1, SizeF sz2) => sz1 + sz2;

        /// <summary>
        /// Determines if the current <see cref="SizeF"/> is equal to the specified <code>object</code>.
        /// </summary>
        /// <param name="obj">The <code>object</code> to compare to the current <see cref="SizeF"/>.</param>
        /// <returns>A boolean value indicating equality.</returns>
        public override bool Equals(object obj) => obj is SizeF && (SizeF)obj == this;

        /// <summary>
        /// Gets a hash code for the current <see cref="SizeF"/>.
        /// </summary>
        /// <returns>An integer representing the current <see cref="SizeF"/>.</returns>
        public override int GetHashCode()
        {
            int hash = 17;

            unchecked
            {
                hash = hash * 23 + Width.GetHashCode();
                hash = hash * 23 + Height.GetHashCode();
            }

            return hash;
        }

        /// <summary>
        /// Subtracts a <see cref="SizeF"/> by another <see cref="SizeF"/>.
        /// </summary>
        /// <param name="sz1">The <see cref="SizeF"/> to be subtracted from.</param>
        /// <param name="sz2">The <see cref="SizeF"/> to subtract.</param>
        /// <returns>A <see cref="SizeF"/> representing the difference.</returns>
        public static SizeF Subtract(SizeF sz1, SizeF sz2) => sz1 - sz2;

        /// <summary>
        /// Gets a string representation of the current <see cref="SizeF"/>.
        /// </summary>
        /// <returns>A string that represents the <see cref="Width"/> and <see cref="Height"/> of the <see cref="SizeF"/>.</returns>
        public override string ToString() => $"({Width},{Height})";

        /// <summary>
        /// Adds two <see cref="SizeF"/> structures together and returns the result.
        /// </summary>
        /// <param name="sz1">The first <see cref="SizeF"/> to add.</param>
        /// <param name="sz2">The second <see cref="SizeF"/> to add.</param>
        /// <returns>A new <see cref="SizeF"/> structure that is the addition of the provided structurs.</returns>
        public static SizeF operator +(SizeF sz1, SizeF sz2) => new SizeF(sz1.Width + sz2.Width, sz1.Height + sz2.Height);

        /// <summary>
        /// Determines if two <see cref="SizeF"/> structures are equal.
        /// </summary>
        /// <param name="sz1">The <see cref="SizeF"/> to check.</param>
        /// <param name="sz2">The <see cref="SizeF"/> to compare to.</param>
        /// <returns>True if the <see cref="SizeF"/> structures have the same value, false otherwise.</returns>
        public static bool operator ==(SizeF sz1, SizeF sz2) => sz1.Width == sz2.Width && sz1.Height == sz2.Height;

        /// <summary>
        /// Convers a <see cref="SizeF"/> to a <see cref="PointF"/>.
        /// </summary>
        /// <param name="size">The <see cref="SizeF"/> to convert.</param>
        public static explicit operator PointF(SizeF size) => new PointF(size.Width, size.Height);

        /// <summary>
        /// Determines if two <see cref="SizeF"/> structures are not equal.
        /// </summary>
        /// <param name="sz1">The <see cref="SizeF"/> to check.</param>
        /// <param name="sz2">The <see cref="SizeF"/> to compare to.</param>
        /// <returns>True if the <see cref="SizeF"/> structures do not have the same value, false otherwise.</returns>
        public static bool operator !=(SizeF sz1, SizeF sz2) => sz1.Width != sz2.Width || sz1.Height != sz2.Height;

        /// <summary>
        /// Subtracts a <see cref="SizeF"/> by another <see cref="SizeF"/>.
        /// </summary>
        /// <param name="sz1">The <see cref="SizeF"/> to be subtracted from.</param>
        /// <param name="sz2">The <see cref="SizeF"/> to subtract.</param>
        /// <returns>A <see cref="SizeF"/> representing the difference.</returns>
        public static SizeF operator -(SizeF sz1, SizeF sz2) => new SizeF(sz1.Width - sz2.Width, sz1.Height - sz2.Height);

        /// <summary>
        /// Represents a <see cref="SizeF"/> with default values.
        /// </summary>
        public static readonly SizeF Empty = new SizeF(0, 0);
    }
}
