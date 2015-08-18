using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Evbpc.Framework.Drawing
{
    [SerializableAttribute]
    [TypeConverterAttribute(typeof(RectangleConverter))]
    public struct Rectangle
    {
        private Point _Location;
        private Size _Size;

        public Rectangle(Point location, Size size) { _Location = location; _Size = size; }
        public Rectangle(int x, int y, int width, int height) { _Location = new Point(x, y); _Size = new Size(width, height); }

        [BrowsableAttribute(false)]
        public int Bottom { get { return _Location.Y + _Size.Height; } }

        public int Height { get { return _Size.Height; } set { _Size.Height = value; } }

        [BrowsableAttribute(false)]
        public bool IsEmpty { get { return this == Empty; } }

        [BrowsableAttribute(false)]
        public int Left { get { return _Location.X; } }

        [BrowsableAttribute(false)]
        public Point Location { get { return _Location; } set { _Location = value; } }

        [BrowsableAttribute(false)]
        public int Right { get { return _Location.X + _Size.Width; } }

        [BrowsableAttribute(false)]
        public Size Size { get { return _Size; } set { _Size = value; } }

        [BrowsableAttribute(false)]
        public int Top { get { return _Location.Y; } }

        public int Width { get { return _Size.Width; } set { _Size.Width = value; } }
        public int X { get { return _Location.X; } set { _Location.X = value; } }
        public int Y { get { return _Location.Y; } set { _Location.Y = value; } }

        public static Rectangle Ceiling(RectangleF value) { return new Rectangle(Point.Ceiling(value.Location), Size.Ceiling(value.Size)); }
        public bool Contains(Point pt) { return Contains(pt.X, pt.Y); }
        public bool Contains(Rectangle rect) { return Contains(rect.Top, rect.Left) && Contains(rect.Top, rect.Right) && Contains(rect.Bottom, rect.Left) && Contains(rect.Bottom, rect.Right); }
        public bool Contains(int x, int y) { return _Location.X <= x && _Location.X + _Size.Width >= x && _Location.Y <= y && _Location.Y + _Size.Height >= y; }
        public override bool Equals(Object obj) { if (obj.GetType() == typeof(Rectangle)) { return (Rectangle)obj == this; } else { return false; } }
        public static Rectangle FromLTRB(int left, int top, int right, int bottom) { return new Rectangle(new Point(top, left), new Size(bottom - top, right - left)); }
        public override int GetHashCode() { return base.GetHashCode(); }
        public void Inflate(Size size) { _Size += size; }
        public void Inflate(int width, int height) { _Size += new Size(width, height); }
        public static Rectangle Inflate(Rectangle rect, int x, int y) { Rectangle nr = new Rectangle(rect.Location, rect.Size); nr.Inflate(x, y); return nr; }
        public void Intersect(Rectangle rect) { this = Intersect(this, rect); }
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
                        if (aConBBL) { return new Rectangle(b.Location, b.Size); }
                        else { return new Rectangle(b.Location, new Size(b.Width, a.Bottom - b.Top)); }
                    }
                    else
                    {
                        if (aConBBL) { return new Rectangle(b.Location, new Size(a.Right - b.Left, b.Height)); }
                        else { return new Rectangle(b.Location, new Size(a.Right - b.Left, a.Bottom - b.Top)); }
                    }
                }
                else
                {
                    if (aConBTR)
                    {
                        if (aConBBR) { return new Rectangle(b.Location, new Size(b.Right - a.Left, b.Height)); }
                        else { return new Rectangle(b.Location, new Size(b.Right - a.Left, a.Bottom - b.Top)); }
                    }
                    else
                    {
                        if (aConBBL)
                        {
                            if (aConBBR) { return new Rectangle(a.Location, new Size(b.Width, b.Bottom - a.Top)); }
                            else { return new Rectangle(new Point(b.Left, a.Top), new Size(a.Right - b.Left, b.Bottom - a.Top)); }
                        }
                        else
                        {
                            if (aConBBR) { return new Rectangle(a.Location, new Size(b.Right - a.Left, b.Bottom - a.Top)); }
                            else
                            {
                                if (bConATL) { return new Rectangle(a.Location, a.Size); }
                                else { return Empty; }
                            }
                        }
                    }
                }
            }
            else { return Empty; }
        }
        public bool IntersectsWith(Rectangle rect) { return Contains(rect.Top, rect.Left) || Contains(rect.Top, rect.Right) || Contains(rect.Bottom, rect.Left) || Contains(rect.Bottom, rect.Right); }
        public void Offset(Point pos) { _Location = new Point(_Location.X + pos.X, _Location.Y + pos.Y); }
        public void Offset(int x, int y) { _Location = new Point(_Location.X + x, _Location.Y + y); }
        public static Rectangle Round(RectangleF value) { return new Rectangle(Point.Round(value.Location), Size.Round(value.Size)); }
        public override string ToString() { return "(" + _Location.X + "," + _Location.Y + "," + _Size.Width + "," + _Size.Height + ")"; }
        public static Rectangle Truncate(RectangleF value) { return new Rectangle(Point.Truncate(value.Location), Size.Truncate(value.Size)); }
        public static Rectangle Union(Rectangle a, Rectangle b) { return new Rectangle(Math.Min(a.X, b.X), Math.Min(a.Y, b.Y), Math.Max(a.X + a.Width, b.X + b.Width), Math.Max(a.Y + a.Height, b.Y + b.Height)); }

        public static bool operator ==(Rectangle left, Rectangle right) { return left.Location == right.Location && left.Size == right.Size; }
        public static bool operator !=(Rectangle left, Rectangle right) { return left.Location != right.Location || left.Size != right.Size; }

        public static readonly Rectangle Empty = new Rectangle(0, 0, 0, 0);
    }
}
