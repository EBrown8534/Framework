using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Evbpc.Framework.Drawing
{
    /// <summary>
    /// Represents a <see cref="Point"/> and <see cref="Drawing.Size"/> in 2D space.
    /// </summary>
    [Serializable]
    [TypeConverter(typeof(RectangleConverter))]
    public struct Rectangle
    {
        /// <summary>
        /// Constructs a new instance of <see cref="Rectangle"/> from the specified <see cref="Point"/> and <see cref="Drawing.Size"/>.
        /// </summary>
        /// <param name="location">The <see cref="Location"/> of the <see cref="Rectangle"/>.</param>
        /// <param name="size">The <see cref="Size"/> of the <see cref="Rectangle"/>.</param>
        public Rectangle(Point location, Size size)
        {
            Location = location;
            Size = size;
        }

        /// <summary>
        /// Constructs a new instance of <see cref="Rectangle"/> from the specified <see cref="X"/>, <see cref="Y"/>, <see cref="Width"/> and <see cref="Height"/>.
        /// </summary>
        /// <param name="x">A value representing the <see cref="X"/> of the <see cref="Rectangle"/>.</param>
        /// <param name="y">A value representing the <see cref="Y"/> of the <see cref="Rectangle"/>.</param>
        /// <param name="width">A value representing the <see cref="Width"/> of the <see cref="Rectangle"/>.</param>
        /// <param name="height">A value representing the <see cref="Height"/> of the <see cref="Rectangle"/>.</param>
        public Rectangle(int x, int y, int width, int height)
        {
            Location = new Point(x, y);
            Size = new Size(width, height);
        }

        /// <summary>
        /// A value representing the vertical position at the furthest bottom edge of the <see cref="Rectangle"/>.
        /// </summary>
        [Browsable(false)]
        public int Bottom => Location.Y + Size.Height;

        /// <summary>
        /// Represents the distance between the <see cref="Top"/> and <see cref="Bottom"/> of the <see cref="Rectangle"/>.
        /// </summary>
        public int Height => Size.Height;

        /// <summary>
        /// Returns a value that indicates if the current <see cref="Rectangle"/> is empty or a default instance (both are equivalent).
        /// </summary>
        [Browsable(false)]
        public bool IsEmpty => this == Empty;

        /// <summary>
        /// A value representing the horizontal position at the furthest left edge of the <see cref="Rectangle"/>.
        /// </summary>
        [Browsable(false)]
        public int Left => Location.X;

        /// <summary>
        /// Represents the position of the top-left <see cref="Point"/> of the <see cref="Rectangle"/>.
        /// </summary>
        [Browsable(false)]
        public Point Location { get; }

        /// <summary>
        /// A value representing the horizontal position at the furthest right edge of the <see cref="Rectangle"/>.
        /// </summary>
        [Browsable(false)]
        public int Right => Location.X + Size.Width;

        /// <summary>
        /// Represents the distance between each set of edges of the <see cref="Rectangle"/>.
        /// </summary>
        [Browsable(false)]
        public Size Size { get; }

        /// <summary>
        /// A value representing the vertical position at the furthest top edge of the <see cref="Rectangle"/>.
        /// </summary>
        [Browsable(false)]
        public int Top => Location.Y;

        /// <summary>
        /// Represents the distance between the <see cref="Left"/> and <see cref="Right"/> edges of the <see cref="Rectangle"/>.
        /// </summary>
        public int Width => Size.Width;

        /// <summary>
        /// Represents the <see cref="Point.X"/> component of the <see cref="Location"/>.
        /// </summary>
        public int X => Location.X;

        /// <summary>
        /// Represents the <see cref="Point.Y"/> component of the <see cref="Location"/>.
        /// </summary>
        public int Y => Location.Y;

        /// <summary>
        /// Constructs a new <see cref="Rectangle"/> from the specified <see cref="RectangleF"/> by rounding all float values up to the nearest whole number.
        /// </summary>
        /// <param name="value">The <see cref="RectangleF"/> to be rounded up.</param>
        /// <returns>The <see cref="Rectangle"/> representing the rounded <see cref="RectangleF"/>.</returns>
        public static Rectangle Ceiling(RectangleF value) => new Rectangle(Point.Ceiling(value.Location), Size.Ceiling(value.Size));

        /// <summary>
        /// Determines if the current <see cref="Rectangle"/> contains the specified <see cref="Point"/>.
        /// </summary>
        /// <param name="pt">The <see cref="Point"/> to check for containment.</param>
        /// <returns>True if this <see cref="Rectangle"/> contains the <see cref="Point"/>, false otherwise.</returns>
        public bool Contains(Point pt) => Contains(pt.X, pt.Y);

        /// <summary>
        /// Determines if the current <see cref="Rectangle"/> contains the entre specified <see cref="Rectangle"/>.
        /// </summary>
        /// <param name="rect">The <see cref="Rectangle"/> to test.</param>
        /// <returns>True if the specified <see cref="Rectangle"/> is entirely contained by the current <see cref="Rectangle"/>.</returns>
        public bool Contains(Rectangle rect) => Contains(rect.Top, rect.Left) && Contains(rect.Top, rect.Right) && Contains(rect.Bottom, rect.Left) && Contains(rect.Bottom, rect.Right);

        /// <summary>
        /// Determines if the current <see cref="Rectangle"/> contains <see cref="Point"/> represented by the specified values.
        /// </summary>
        /// <param name="x">The <see cref="Point.X"/> value to test.</param>
        /// <param name="y">The <see cref="Point.Y"/> value to test.</param>
        /// <returns></returns>
        public bool Contains(int x, int y) => Location.X <= x && Location.X + Size.Width >= x && Location.Y <= y && Location.Y + Size.Height >= y;

        /// <summary>
        /// Determines if the current <see cref="Rectangle"/> is equal to the specified <code>object</code>.
        /// </summary>
        /// <param name="obj">The <code>object</code> to compare to the current <see cref="Rectangle"/>.</param>
        /// <returns>A boolean value indicating equality.</returns>
        public override bool Equals(object obj) => obj is Rectangle && (Rectangle)obj == this;

        /// <summary>
        /// Constructs a new instance of <see cref="Rectangle"/> from the specified <see cref="Left"/>, <see cref="Top"/>, <see cref="Right"/>, and <see cref="Bottom"/> values.
        /// </summary>
        /// <param name="left">The <see cref="Left"/> position of the <see cref="Rectangle"/>.</param>
        /// <param name="top">The <see cref="Top"/> location of the <see cref="Rectangle"/>.</param>
        /// <param name="right">The <see cref="Right"/> location of the <see cref="Rectangle"/>.</param>
        /// <param name="bottom">The <see cref="Bottom"/> location of the <see cref="Rectangle"/>.</param>
        /// <returns>A new <see cref="Rectangle"/> from the specified values.</returns>
        public static Rectangle FromLTRB(int left, int top, int right, int bottom) => new Rectangle(new Point(top, left), new Size(bottom - top, right - left));

        /// <summary>
        /// Gets a hash code for the current <see cref="Rectangle"/>.
        /// </summary>
        /// <returns>An integer representing the current <see cref="Rectangle"/>.</returns>
        public override int GetHashCode() => base.GetHashCode();

        /// <summary>
        /// Increases the <see cref="Size"/> of the <see cref="Rectangle"/> by the specified <see cref="Drawing.Size"/>.
        /// </summary>
        /// <param name="size">The <see cref="Drawing.Size"/> to increase the <see cref="Rectangle"/> by.</param>
        /// <returns>A new <see cref="Rectangle"/> with the increased <see cref="Size"/>.</returns>
        public Rectangle Inflate(Size size) => new Rectangle(Location, Size + size);

        /// <summary>
        /// Increases the <see cref="Size"/> of the <see cref="Rectangle"/> by the specified values.
        /// </summary>
        /// <param name="width">The <see cref="Size.Width"/> to increase the <see cref="Rectangle"/> by.</param>
        /// <param name="height">The <see cref="Size.Height"/> to increase the <see cref="Rectangle"/> by.</param>
        /// <returns>A new <see cref="Rectangle"/> with the increased <see cref="Size"/>.</returns>
        public Rectangle Inflate(int width, int height) => new Rectangle(Location, Size + new Size(width, height));

        /// <summary>
        /// Increases the <see cref="Size"/> of the <see cref="Rectangle"/> by the specified values.
        /// </summary>
        /// <param name="rect">The <see cref="Rectangle"/> to modify.</param>
        /// <param name="width">The <see cref="Size.Width"/> to increase the <see cref="Rectangle"/> by.</param>
        /// <param name="height">The <see cref="Size.Height"/> to increase the <see cref="Rectangle"/> by.</param>
        /// <returns>A new <see cref="Rectangle"/> with the increased <see cref="Size"/>.</returns>
        public static Rectangle Inflate(Rectangle rect, int width, int height) => rect.Inflate(width, height);

        /// <summary>
        /// Creates a new <see cref="Rectangle"/> which is the area that overlaps this and the provided <see cref="Rectangle"/> objects.
        /// </summary>
        /// <param name="rect">The <see cref="Rectangle"/> to intersect this <see cref="Rectangle"/>.</param>
        /// <returns>A new <see cref="Rectangle"/> representing the overlap covered by the two <see cref="Rectangle"/> objects.</returns>
        public Rectangle Intersect(Rectangle rect) => Intersect(this, rect);

        /// <summary>
        /// Creates a new <see cref="Rectangle"/> which is the area that overlaps the provided <see cref="Rectangle"/> objects.
        /// </summary>
        /// <param name="a">The first <see cref="Rectangle"/> to intersect.</param>
        /// <param name="b">The second <see cref="Rectangle"/> to intersect.</param>
        /// <returns>A new <see cref="Rectangle"/> representing the overlap covered by the two <see cref="Rectangle"/> objects.</returns>
        public static Rectangle Intersect(Rectangle a, Rectangle b)
        {
            if (a.IntersectsWith(b))
            {
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
                            return new Rectangle(b.Location, b.Size);
                        }
                        else
                        {
                            return new Rectangle(b.Location, new Size(b.Width, a.Bottom - b.Top));
                        }
                    }
                    else
                    {
                        if (aConBBL)
                        {
                            return new Rectangle(b.Location, new Size(a.Right - b.Left, b.Height));
                        }
                        else
                        {
                            return new Rectangle(b.Location, new Size(a.Right - b.Left, a.Bottom - b.Top));
                        }
                    }
                }
                else
                {
                    if (aConBTR)
                    {
                        if (aConBBR)
                        {
                            return new Rectangle(b.Location, new Size(b.Right - a.Left, b.Height));
                        }
                        else
                        {
                            return new Rectangle(b.Location, new Size(b.Right - a.Left, a.Bottom - b.Top));
                        }
                    }
                    else
                    {
                        if (aConBBL)
                        {
                            if (aConBBR)
                            {
                                return new Rectangle(a.Location, new Size(b.Width, b.Bottom - a.Top));
                            }
                            else
                            {
                                return new Rectangle(new Point(b.Left, a.Top), new Size(a.Right - b.Left, b.Bottom - a.Top));
                            }
                        }
                        else
                        {
                            if (aConBBR)
                            {
                                return new Rectangle(a.Location, new Size(b.Right - a.Left, b.Bottom - a.Top));
                            }
                            else
                            {
                                if (bConATL)
                                {
                                    return new Rectangle(a.Location, a.Size);
                                }
                                else
                                {
                                    return Empty;
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                return Empty;
            }
        }

        /// <summary>
        /// Determines if any corner of the provided <see cref="Rectangle"/> overlaps this <see cref="Rectangle"/>.
        /// </summary>
        /// <param name="rect">The <see cref="Rectangle"/> to test.</param>
        /// <returns>True if the <see cref="Rectangle"/> intersects this one, false otherwise.</returns>
        public bool IntersectsWith(Rectangle rect) => Contains(rect.Top, rect.Left) || Contains(rect.Top, rect.Right) || Contains(rect.Bottom, rect.Left) || Contains(rect.Bottom, rect.Right);

        /// <summary>
        /// Moves this <see cref="Rectangle"/> by the specified <see cref="Point"/>.
        /// </summary>
        /// <param name="pos">The <see cref="Point"/> containing the values to move by.</param>
        /// <returns>A new <see cref="Rectangle"/> moved by the <see cref="Point"/> values.</returns>
        public Rectangle Offset(Point pos)=>new Rectangle(new Point(Location.X + pos.X, Location.Y + pos.Y), Size);

        /// <summary>
        /// Moves this <see cref="Rectangle"/> by the specified values.
        /// </summary>
        /// <param name="x">The <see cref="Point.X"/> to increase or decrease this <see cref="X"/> by.</param>
        /// <param name="y">The <see cref="Point.Y"/> to increase or decrease this <see cref="Y"/> by.</param>
        /// <returns>A new <see cref="Rectangle"/> moved by the values.</returns>
        public Rectangle Offset(int x, int y)=>new Rectangle(new Point(Location.X + x, Location.Y + y), Size);

        /// <summary>
        /// Constructs a new <see cref="Rectangle"/> from the specified <see cref="RectangleF"/> by rounding all float values to the nearest whole number.
        /// </summary>
        /// <param name="value">The <see cref="RectangleF"/> to be rounded.</param>
        /// <returns>The <see cref="Rectangle"/> representing the rounded <see cref="RectangleF"/>.</returns>
        public static Rectangle Round(RectangleF value) => new Rectangle(Point.Round(value.Location), Size.Round(value.Size));

        /// <summary>
        /// Gets a string representation of a <see cref="Rectangle"/>.
        /// </summary>
        /// <returns>A string that represents the <see cref="X"/>, <see cref="Y"/> coordinates, <see cref="Width"/> and <see cref="Height"/> values of the <see cref="Rectangle"/>.</returns>
        public override string ToString() => $"({Location.X},{Location.Y},{Size.Width},{Size.Height})";

        /// <summary>
        /// Constructs a new <see cref="Rectangle"/> from the specified <see cref="RectangleF"/> by rounding all float values down to the nearest whole number.
        /// </summary>
        /// <param name="value">The <see cref="RectangleF"/> to be rounded down.</param>
        /// <returns>The <see cref="Rectangle"/> representing the rounded <see cref="RectangleF"/>.</returns>
        public static Rectangle Truncate(RectangleF value) => new Rectangle(Point.Truncate(value.Location), Size.Truncate(value.Size));

        /// <summary>
        /// Gets a <see cref="Rectangle"/> structure that contains the union of two <see cref="Rectangle"/> structures.
        /// </summary>
        /// <param name="a">The first <see cref="Rectangle"/> to union.</param>
        /// <param name="b">The second <see cref="Rectangle"/> to union.</param>
        /// <returns>A <see cref="Rectangle"/> structure that bounds the union of the two <see cref="Rectangle"/> structures.</returns>
        public static Rectangle Union(Rectangle a, Rectangle b) => new Rectangle(Math.Min(a.X, b.X), Math.Min(a.Y, b.Y), Math.Max(a.X + a.Width, b.X + b.Width), Math.Max(a.Y + a.Height, b.Y + b.Height));

        /// <summary>
        /// Determines if two <see cref="Rectangle"/> structures are equivalent.
        /// </summary>
        /// <param name="left">The first <see cref="Rectangle"/> to test.</param>
        /// <param name="right">The second <see cref="Rectangle"/> to test.</param>
        /// <returns>True if the <see cref="Rectangle"/> structures are equal, otherwise false.</returns>
        public static bool operator ==(Rectangle left, Rectangle right) => left.Location == right.Location && left.Size == right.Size;

        /// <summary>
        /// Determines if two <see cref="Rectangle"/> structures are not equivalent.
        /// </summary>
        /// <param name="left">The first <see cref="Rectangle"/> to test.</param>
        /// <param name="right">The second <see cref="Rectangle"/> to test.</param>
        /// <returns>True if the <see cref="Rectangle"/> structures are not equal, otherwise false.</returns>
        public static bool operator !=(Rectangle left, Rectangle right) => left.Location != right.Location || left.Size != right.Size;

        /// <summary>
        /// Represents a <see cref="Rectangle"/> with default values.
        /// </summary>
        public static readonly Rectangle Empty = new Rectangle(0, 0, 0, 0);
    }
}
