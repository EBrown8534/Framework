using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Evbpc.Framework.Drawing
{
    /// <summary>
    /// Represents a <see cref="PointF"/> and <see cref="SizeF"/> in 2D space.
    /// </summary>
    [Serializable]
    public struct RectangleF
    {
        /// <summary>
        /// Constructs a new instance of <see cref="RectangleF"/> from the specified <see cref="PointF"/> and <see cref="SizeF"/>.
        /// </summary>
        /// <param name="location">The <see cref="Location"/> of the <see cref="RectangleF"/>.</param>
        /// <param name="size">The <see cref="Size"/> of the <see cref="RectangleF"/>.</param>
        public RectangleF(PointF location, SizeF size)
        {
            Location = location;
            Size = size;
        }

        /// <summary>
        /// Constructs a new instance of <see cref="RectangleF"/> from the specified <see cref="X"/>, <see cref="Y"/>, <see cref="Width"/> and <see cref="Height"/>.
        /// </summary>
        /// <param name="x">A value representing the <see cref="X"/> of the <see cref="RectangleF"/>.</param>
        /// <param name="y">A value representing the <see cref="Y"/> of the <see cref="RectangleF"/>.</param>
        /// <param name="width">A value representing the <see cref="Width"/> of the <see cref="RectangleF"/>.</param>
        /// <param name="height">A value representing the <see cref="Height"/> of the <see cref="RectangleF"/>.</param>
        public RectangleF(float x, float y, float width, float height)
        {
            Location = new PointF(x, y);
            Size = new SizeF(width, height);
        }

        /// <summary>
        /// A value representing the vertical position at the furthest bottom edge of the <see cref="RectangleF"/>.
        /// </summary>
        [Browsable(false)]
        public float Bottom => Location.Y + Size.Height;

        /// <summary>
        /// Represents the distance between the <see cref="Top"/> and <see cref="Bottom"/> of the <see cref="RectangleF"/>.
        /// </summary>
        public float Height => Size.Height;

        /// <summary>
        /// Returns a value that indicates if the current <see cref="RectangleF"/> is empty or a default instance (both are equivalent).
        /// </summary>
        [Browsable(false)]
        public bool IsEmpty => this == Empty;

        /// <summary>
        /// A value representing the horizontal position at the furthest left edge of the <see cref="RectangleF"/>.
        /// </summary>
        [Browsable(false)]
        public float Left => Location.X;

        /// <summary>
        /// Represents the position of the top-left <see cref="PointF"/> of the <see cref="RectangleF"/>.
        /// </summary>
        [Browsable(false)]
        public PointF Location { get; }

        /// <summary>
        /// A value representing the horizontal position at the furthest right edge of the <see cref="RectangleF"/>.
        /// </summary>
        [Browsable(false)]
        public float Right => Location.X + Size.Width;

        /// <summary>
        /// Represents the distance between each set of edges of the <see cref="RectangleF"/>.
        /// </summary>
        [Browsable(false)]
        public SizeF Size { get; }

        /// <summary>
        /// A value representing the vertical position at the furthest top edge of the <see cref="RectangleF"/>.
        /// </summary>
        [Browsable(false)]
        public float Top => Location.Y;

        /// <summary>
        /// Represents the distance between the <see cref="Left"/> and <see cref="Right"/> edges of the <see cref="RectangleF"/>.
        /// </summary>
        public float Width => Size.Width;

        /// <summary>
        /// Represents the <see cref="PointF.X"/> component of the <see cref="Location"/>.
        /// </summary>
        public float X => Location.X;

        /// <summary>
        /// Represents the <see cref="PointF.Y"/> component of the <see cref="Location"/>.
        /// </summary>
        public float Y => Location.Y;

        /// <summary>
        /// Determines if a <see cref="PointF"/> is contained within the current <see cref="RectangleF"/>.
        /// </summary>
        /// <param name="pt">The <see cref="PointF"/> to test.</param>
        /// <returns>True if pt is contained within this <see cref="RectangleF"/>.</returns>
        public bool Contains(PointF pt) => Contains(pt.X, pt.Y);

        /// <summary>
        /// Determines if a <see cref="RectangleF"/> is entirely contained within this <see cref="RectangleF"/>.
        /// </summary>
        /// <param name="rect">The <see cref="RectangleF"/> to test.</param>
        /// <returns>True if rect is entirely contained within this <see cref="RectangleF"/>.</returns>
        public bool Contains(RectangleF rect) => Contains(rect.Top, rect.Left) && Contains(rect.Top, rect.Right) && Contains(rect.Bottom, rect.Left) && Contains(rect.Bottom, rect.Right);

        /// <summary>
        /// Determines if the position represented by x and y is contained within the current <see cref="RectangleF"/>.
        /// </summary>
        /// <param name="x">The x value of the position to test.</param>
        /// <param name="y">The y value of the position to test.</param>
        /// <returns>True if the position represented by the x and y values is contained within this <see cref="RectangleF"/>.</returns>
        /// <remarks>
        /// This method is entirely inclusive. If the position represented by the x and y values is on the edge of, or entirely within the current <see cref="RectangleF"/>, then this method will return true.
        /// </remarks>
        public bool Contains(float x, float y) => Location.X <= x && Location.X + Size.Width >= x && Location.Y <= y && Location.Y + Size.Height >= y;

        /// <summary>
        /// Determines if the current <see cref="RectangleF"/> is equal to the specified <code>object</code>.
        /// </summary>
        /// <param name="obj">The <code>object</code> to compare to the current <see cref="RectangleF"/>.</param>
        /// <returns>A boolean value indicating equality.</returns>
        public override bool Equals(Object obj) => obj is RectangleF && (RectangleF)obj == this;

        /// <summary>
        /// Constructs a new instance of <see cref="RectangleF"/> from the specified <see cref="Left"/>, <see cref="Top"/>, <see cref="Right"/>, and <see cref="Bottom"/> values.
        /// </summary>
        /// <param name="left">The <see cref="Left"/> position of the <see cref="RectangleF"/>.</param>
        /// <param name="top">The <see cref="Top"/> location of the <see cref="RectangleF"/>.</param>
        /// <param name="right">The <see cref="Right"/> location of the <see cref="RectangleF"/>.</param>
        /// <param name="bottom">The <see cref="Bottom"/> location of the <see cref="RectangleF"/>.</param>
        /// <returns>A new <see cref="RectangleF"/> from the specified values.</returns>
        public static RectangleF FromLTRB(float left, float top, float right, float bottom) => new RectangleF(new PointF(top, left), new SizeF(bottom - top, right - left));

        /// <summary>
        /// Gets a hash code for the current <see cref="RectangleF"/>.
        /// </summary>
        /// <returns>An integer representing the current <see cref="RectangleF"/>.</returns>
        public override int GetHashCode() => base.GetHashCode();

        /// <summary>
        /// Increases the <see cref="Size"/> of the <see cref="RectangleF"/> by the specified <see cref="Drawing.SizeF"/>.
        /// </summary>
        /// <param name="size">The <see cref="Drawing.SizeF"/> to increase the <see cref="RectangleF"/> by.</param>
        /// <returns>A new <see cref="RectangleF"/> with the increased <see cref="Size"/>.</returns>
        public RectangleF Inflate(SizeF size) => new RectangleF(Location, Size + size);

        /// <summary>
        /// Increases the <see cref="Size"/> of the <see cref="RectangleF"/> by the specified values.
        /// </summary>
        /// <param name="width">The <see cref="SizeF.Width"/> to increase the <see cref="RectangleF"/> by.</param>
        /// <param name="height">The <see cref="SizeF.Height"/> to increase the <see cref="RectangleF"/> by.</param>
        /// <returns>A new <see cref="RectangleF"/> with the increased <see cref="Size"/>.</returns>
        public RectangleF Inflate(float width, float height) => new RectangleF(Location, Size + new SizeF(width, height));

        /// <summary>
        /// Increases the <see cref="Size"/> of the <see cref="Rectangle"/> by the specified values.
        /// </summary>
        /// <param name="rect">The <see cref="RectangleF"/> to modify.</param>
        /// <param name="width">The <see cref="SizeF.Width"/> to increase the <see cref="RectangleF"/> by.</param>
        /// <param name="height">The <see cref="SizeF.Height"/> to increase the <see cref="RectangleF"/> by.</param>
        /// <returns>A new <see cref="RectangleF"/> with the increased <see cref="Size"/>.</returns>
        public static RectangleF Inflate(RectangleF rect, float width, float height) => rect.Inflate(width, height);

        /// <summary>
        /// Creates a new <see cref="RectangleF"/> which is the area that overlaps this and the provided <see cref="RectangleF"/> objects.
        /// </summary>
        /// <param name="rect">The <see cref="RectangleF"/> to intersect this <see cref="RectangleF"/>.</param>
        /// <returns>A new <see cref="RectangleF"/> representing the overlap covered by the two <see cref="RectangleF"/> objects.</returns>
        public RectangleF Intersect(RectangleF rect) => Intersect(this, rect);

        /// <summary>
        /// Creates a new <see cref="RectangleF"/> which is the area that overlaps the provided <see cref="RectangleF"/> objects.
        /// </summary>
        /// <param name="a">The first <see cref="RectangleF"/> to intersect.</param>
        /// <param name="b">The second <see cref="RectangleF"/> to intersect.</param>
        /// <returns>A new <see cref="RectangleF"/> representing the overlap covered by the two <see cref="RectangleF"/> objects.</returns>
        public static RectangleF Intersect(RectangleF a, RectangleF b)
        {
            if (!a.IntersectsWith(b))
            {
                return Empty;
            }

                bool aConBTL = a.Contains(b.Top, b.Left);
                bool aConBTR = a.Contains(b.Top, b.Right);
                bool aConBBL = a.Contains(b.Bottom, b.Left);
                bool aConBBR = a.Contains(b.Bottom, b.Right);
                bool bConATL = b.Contains(a.Top, a.Left);

            if (aConBTL)
            {
                if (aConBTR)
                {
                    if (aConBBL)
                    {
                        return new RectangleF(b.Location, b.Size);
                    }
                    else
                    {
                        return new RectangleF(b.Location, new SizeF(b.Width, a.Bottom - b.Top));
                    }
                }
                else
                {
                    if (aConBBL)
                    {
                        return new RectangleF(b.Location, new SizeF(a.Right - b.Left, b.Height));
                    }
                    else
                    {
                        return new RectangleF(b.Location, new SizeF(a.Right - b.Left, a.Bottom - b.Top));
                    }
                }
            }

            if (aConBTR)
            {
                if (aConBBR)
                {
                    return new RectangleF(b.Location, new SizeF(b.Right - a.Left, b.Height));
                }
                else
                {
                    return new RectangleF(b.Location, new SizeF(b.Right - a.Left, a.Bottom - b.Top));
                }
            }

            if (aConBBL)
            {
                if (aConBBR)
                {
                    return new RectangleF(a.Location, new SizeF(b.Width, b.Bottom - a.Top));
                }
                else
                {
                    return new RectangleF(new PointF(b.Left, a.Top), new SizeF(a.Right - b.Left, b.Bottom - a.Top));
                }
            }

            if (aConBBR)
            {
                return new RectangleF(a.Location, new SizeF(b.Right - a.Left, b.Bottom - a.Top));
            }
            else
            {
                if (bConATL)
                {
                    return new RectangleF(a.Location, a.Size);
                }
            }

            return Empty;
        }

        /// <summary>
        /// Determines if any corner of the provided <see cref="RectangleF"/> overlaps this <see cref="RectangleF"/>.
        /// </summary>
        /// <param name="rect">The <see cref="RectangleF"/> to test.</param>
        /// <returns>True if the <see cref="RectangleF"/> intersects this one, false otherwise.</returns>
        public bool IntersectsWith(RectangleF rect) => Contains(rect.Top, rect.Left) || Contains(rect.Top, rect.Right) || Contains(rect.Bottom, rect.Left) || Contains(rect.Bottom, rect.Right);

        /// <summary>
        /// Moves this <see cref="RectangleF"/> by the specified <see cref="PointF"/>.
        /// </summary>
        /// <param name="pos">The <see cref="PointF"/> containing the values to move by.</param>
        /// <returns>A new <see cref="RectangleF"/> moved by the <see cref="PointF"/> values.</returns>
        public RectangleF Offset(PointF pos) => new RectangleF(new PointF(Location.X + pos.X, Location.Y + pos.Y), Size);

        /// <summary>
        /// Moves this <see cref="RectangleF"/> by the specified values.
        /// </summary>
        /// <param name="x">The <see cref="PointF.X"/> to increase or decrease this <see cref="X"/> by.</param>
        /// <param name="y">The <see cref="PointF.Y"/> to increase or decrease this <see cref="Y"/> by.</param>
        /// <returns>A new <see cref="RectangleF"/> moved by the values.</returns>
        public RectangleF Offset(float x, float y) => new RectangleF(new PointF(Location.X + x, Location.Y + y), Size);

        /// <summary>
        /// Gets a string representation of a <see cref="RectangleF"/>.
        /// </summary>
        /// <returns>A string that represents the <see cref="X"/>, <see cref="Y"/> coordinates, <see cref="Width"/> and <see cref="Height"/> values of the <see cref="RectangleF"/>.</returns>
        public override string ToString() => $"({Location.X},{Location.Y},{Size.Width},{Size.Height})";

        /// <summary>
        /// Gets a <see cref="RectangleF"/> structure that contains the union of two <see cref="RectangleF"/> structures.
        /// </summary>
        /// <param name="a">The first <see cref="RectangleF"/> to union.</param>
        /// <param name="b">The second <see cref="RectangleF"/> to union.</param>
        /// <returns>A <see cref="RectangleF"/> structure that bounds the union of the two <see cref="RectangleF"/> structures.</returns>
        public static RectangleF Union(RectangleF a, RectangleF b) => new RectangleF(Math.Min(a.X, b.X), Math.Min(a.Y, b.Y), Math.Max(a.X + a.Width, b.X + b.Width), Math.Max(a.Y + a.Height, b.Y + b.Height));

        /// <summary>
        /// Determines if two <see cref="RectangleF"/> structures are equivalent.
        /// </summary>
        /// <param name="left">The first <see cref="RectangleF"/> to test.</param>
        /// <param name="right">The second <see cref="RectangleF"/> to test.</param>
        /// <returns>True if the <see cref="RectangleF"/> structures are equal, otherwise false.</returns>
        public static bool operator ==(RectangleF left, RectangleF right) => left.Location == right.Location && left.Size == right.Size;

        /// <summary>
        /// Converts a <see cref="Rectangle"/> to a <see cref="RectangleF"/>.
        /// </summary>
        /// <param name="r">The <see cref="Rectangle"/> to convert.</param>
        public static implicit operator RectangleF(Rectangle r) => new RectangleF(r.Location, r.Size);

        /// <summary>
        /// Determines if two <see cref="RectangleF"/> structures are not equivalent.
        /// </summary>
        /// <param name="left">The first <see cref="RectangleF"/> to test.</param>
        /// <param name="right">The second <see cref="RectangleF"/> to test.</param>
        /// <returns>True if the <see cref="RectangleF"/> structures are not equal, otherwise false.</returns>
        public static bool operator !=(RectangleF left, RectangleF right) => left.Location != right.Location || left.Size != right.Size;

        /// <summary>
        /// Represents a <see cref="RectangleF"/> with default values.
        /// </summary>
        public static readonly RectangleF Empty = new RectangleF(0, 0, 0, 0);
    }
}
