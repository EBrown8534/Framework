using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Evbpc.Framework.Drawing
{
    /// <summary>
    /// Represents a position in 2D space that has fractional components.
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Explicit)]
    public struct PointF
    {
        [FieldOffset(0)]
        private ulong _packedValue;
        [FieldOffset(0)]
        private float _x;
        [FieldOffset(4)]
        private float _y;

        /// <summary>
        /// Constructs a new instance of <see cref="PointF"/> from the specified <see cref="SizeF"/>.
        /// </summary>
        /// <param name="sz">The <see cref="SizeF"/> to construct the <see cref="PointF"/> from.</param>
        /// <remarks>
        /// The <see cref="SizeF.Width"/> will become the <see cref="X"/> and the <see cref="SizeF.Height"/> will become the <see cref="Y"/>.
        /// </remarks>
        public PointF(SizeF sz)
            : this()
        {
            _x = sz.Width;
            _y = sz.Height;
        }

        /// <summary>
        /// Constructs a new instance of <see cref="PointF"/> from the specified <see cref="X"/> and <see cref="Y"/>.
        /// </summary>
        /// <param name="x">The value that should represent the <see cref="X"/>.</param>
        /// <param name="y">The value that should represent the <see cref="Y"/>.</param>
        public PointF(float x, float y)
            : this()
        {
            _x = x;
            _y = y;
        }

        /// <summary>
        /// Returns a value that indicates if the current <see cref="PointF"/> is empty or a default instance (both are equivalent).
        /// </summary>
        [Browsable(false)]
        public bool IsEmpty => this == Empty;

        /// <summary>
        /// Represents the horizontal position of the <see cref="PointF"/>.
        /// </summary>
        public float X => _x;

        /// <summary>
        /// Represents the vertical position of the <see cref="PointF"/>.
        /// </summary>
        public float Y => _y;

        /// <summary>
        /// Offsets a <see cref="PointF"/> by the specified <see cref="Size"/>.
        /// </summary>
        /// <param name="pt">The <see cref="PointF"/> that should be offset.</param>
        /// <param name="sz">The <see cref="Size"/> to offset by.</param>
        /// <returns>A new <see cref="PointF"/> that has been offset.</returns>
        public static PointF Add(PointF pt, Size sz) => pt + sz;

        /// <summary>
        /// Offsets a <see cref="PointF"/> by the specified <see cref="SizeF"/>.
        /// </summary>
        /// <param name="pt">The <see cref="PointF"/> that should be offset.</param>
        /// <param name="sz">The <see cref="SizeF"/> to offset by.</param>
        /// <returns>A new <see cref="PointF"/> that has been offset.</returns>
        public static PointF Add(PointF pt, SizeF sz) => pt + sz;

        /// <summary>
        /// Determines if the current <see cref="PointF"/> is equal to the specified <code>object</code>.
        /// </summary>
        /// <param name="obj">The <code>object</code> to compare to the current <see cref="PointF"/>.</param>
        /// <returns>A boolean value indicating equality.</returns>
        public override bool Equals(object obj) => obj is PointF && (PointF)obj == this;

        /// <summary>
        /// Gets a hash code for the current <see cref="PointF"/>.
        /// </summary>
        /// <returns>An integer representing the current <see cref="PointF"/>.</returns>
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
        /// Subtracts a <see cref="PointF"/> by a <see cref="Size"/>.
        /// </summary>
        /// <param name="pt">The <see cref="PointF"/> to be subtracted from.</param>
        /// <param name="sz">The <see cref="Size"/> to subtract.</param>
        /// <returns>A <see cref="PointF"/> representing the difference.</returns>
        public static PointF Subtract(PointF pt, Size sz)=>pt - sz;

        /// <summary>
        /// Subtracts a <see cref="PointF"/> by a <see cref="SizeF"/>.
        /// </summary>
        /// <param name="pt">The <see cref="PointF"/> to be subtracted from.</param>
        /// <param name="sz">The <see cref="SizeF"/> to subtract.</param>
        /// <returns>A <see cref="PointF"/> representing the difference.</returns>
        public static PointF Subtract(PointF pt, SizeF sz) => pt - sz;

        /// <summary>
        /// Gets a string representation of a <see cref="PointF"/>.
        /// </summary>
        /// <returns>A string that represents the <see cref="X"/> and <see cref="Y"/> coordinates of the <see cref="PointF"/>.</returns>
        public override string ToString() => $"({_x},{_y})";

        /// <summary>
        /// Offsets a <see cref="PointF"/> object by the specified <see cref="Size"/>.
        /// </summary>
        /// <param name="pt">The <see cref="PointF"/> that should be offset.</param>
        /// <param name="sz">The <see cref="Size"/> to offset by.</param>
        /// <returns>A new <see cref="PointF"/> that has been offset.</returns>
        public static PointF operator +(PointF pt, Size sz) => new PointF(pt.X + sz.Width, pt.Y + sz.Height);

        /// <summary>
        /// Offsets a <see cref="PointF"/> object by the specified <see cref="SizeF"/>.
        /// </summary>
        /// <param name="pt">The <see cref="PointF"/> that should be offset.</param>
        /// <param name="sz">The <see cref="SizeF"/> to offset by.</param>
        /// <returns>A new <see cref="PointF"/> that has been offset.</returns>
        public static PointF operator +(PointF pt, SizeF sz) => new PointF(pt.X + sz.Width, pt.Y + sz.Height);

        /// <summary>
        /// Determines if two <see cref="PointF"/> objects are equal.
        /// </summary>
        /// <param name="left">The <see cref="PointF"/> to check.</param>
        /// <param name="right">The <see cref="PointF"/> to compare to.</param>
        /// <returns>True if the <see cref="PointF"/> objects have the same value, false otherwise.</returns>
        public static bool operator ==(PointF left, PointF right) => left.X == right.X && left.Y == right.Y;

        /// <summary>
        /// Determines if two <see cref="PointF"/> objects are not equal.
        /// </summary>
        /// <param name="left">The <see cref="PointF"/> to check.</param>
        /// <param name="right">The <see cref="PointF"/> to compare to.</param>
        /// <returns>True if the <see cref="PointF"/> objects do not have the same value, false otherwise.</returns>
        public static bool operator !=(PointF left, PointF right) => left.X != right.X || left.Y != right.Y;

        /// <summary>
        /// Subtracts a <see cref="PointF"/> by a <see cref="Size"/>.
        /// </summary>
        /// <param name="pt">The <see cref="PointF"/> to be subtracted from.</param>
        /// <param name="sz">The <see cref="Size"/> to subtract.</param>
        /// <returns>A <see cref="PointF"/> representing the difference.</returns>
        public static PointF operator -(PointF pt, Size sz) => new PointF(pt.X - sz.Width, pt.Y - sz.Height);

        /// <summary>
        /// Subtracts a <see cref="PointF"/> by a <see cref="SizeF"/>.
        /// </summary>
        /// <param name="pt">The <see cref="PointF"/> to be subtracted from.</param>
        /// <param name="sz">The <see cref="SizeF"/> to subtract.</param>
        /// <returns>A <see cref="PointF"/> representing the difference.</returns>
        public static PointF operator -(PointF pt, SizeF sz) => new PointF(pt.X - sz.Width, pt.Y - sz.Height);

        /// <summary>
        /// Represents a <see cref="PointF"/> with default values.
        /// </summary>
        public static readonly PointF Empty = new PointF(0, 0);
    }
}
