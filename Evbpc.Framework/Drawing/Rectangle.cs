using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Evbpc.Framework.Drawing
{
    [Serializable]
    [TypeConverter(typeof(RectangleConverter))]
    public struct Rectangle
    {
        public Rectangle(Point location, Size size)
        {
            Location = location;
            Size = size;
        }

        public Rectangle(int x, int y, int width, int height)
        {
            Location = new Point(x, y);
            Size = new Size(width, height);
        }

        [Browsable(false)]
        public int Bottom => Location.Y + Size.Height;

        public int Height => Size.Height;

        [Browsable(false)]
        public bool IsEmpty => this == Empty;

        [Browsable(false)]
        public int Left => Location.X;

        [Browsable(false)]
        public Point Location { get; }

        [Browsable(false)]
        public int Right => Location.X + Size.Width;

        [Browsable(false)]
        public Size Size { get; }

        [Browsable(false)]
        public int Top => Location.Y;

        public int Width => Size.Width;
        public int X => Location.X;
        public int Y => Location.Y;

        public static Rectangle Ceiling(RectangleF value) => new Rectangle(Point.Ceiling(value.Location), Size.Ceiling(value.Size));

        public bool Contains(Point pt) => Contains(pt.X, pt.Y);

        public bool Contains(Rectangle rect) => Contains(rect.Top, rect.Left) && Contains(rect.Top, rect.Right) && Contains(rect.Bottom, rect.Left) && Contains(rect.Bottom, rect.Right);

        public bool Contains(int x, int y) => Location.X <= x && Location.X + Size.Width >= x && Location.Y <= y && Location.Y + Size.Height >= y;

        public override bool Equals(Object obj) => obj is Rectangle && (Rectangle)obj == this;

        public static Rectangle FromLTRB(int left, int top, int right, int bottom) => new Rectangle(new Point(top, left), new Size(bottom - top, right - left));

        public override int GetHashCode() => base.GetHashCode();

        public Rectangle Inflate(Size size) => new Rectangle(Location, Size + size);

        public Rectangle Inflate(int width, int height) => new Rectangle(Location, Size + new Size(width, height));

        public static Rectangle Inflate(Rectangle rect, int x, int y) => rect.Inflate(x, y);

        public Rectangle Intersect(Rectangle rect) => Intersect(this, rect);

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

        public bool IntersectsWith(Rectangle rect) => Contains(rect.Top, rect.Left) || Contains(rect.Top, rect.Right) || Contains(rect.Bottom, rect.Left) || Contains(rect.Bottom, rect.Right);

        public Rectangle Offset(Point pos)=>new Rectangle(new Point(Location.X + pos.X, Location.Y + pos.Y), Size);

        public Rectangle Offset(int x, int y)=>new Rectangle(new Point(Location.X + x, Location.Y + y), Size);

        public static Rectangle Round(RectangleF value) => new Rectangle(Point.Round(value.Location), Size.Round(value.Size));

        public override string ToString() => $"({Location.X},{Location.Y},{Size.Width},{Size.Height})";

        public static Rectangle Truncate(RectangleF value) => new Rectangle(Point.Truncate(value.Location), Size.Truncate(value.Size));

        public static Rectangle Union(Rectangle a, Rectangle b) => new Rectangle(Math.Min(a.X, b.X), Math.Min(a.Y, b.Y), Math.Max(a.X + a.Width, b.X + b.Width), Math.Max(a.Y + a.Height, b.Y + b.Height));

        public static bool operator ==(Rectangle left, Rectangle right) => left.Location == right.Location && left.Size == right.Size;

        public static bool operator !=(Rectangle left, Rectangle right) => left.Location != right.Location || left.Size != right.Size;

        public static readonly Rectangle Empty = new Rectangle(0, 0, 0, 0);
    }
}
