using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Evbpc.Framework.Drawing
{
    [SerializableAttribute]
    public struct RectangleF
    {
        private PointF _location;
        private SizeF _size;

        public RectangleF(PointF location, SizeF size) { _location = location; _size = size; }
        public RectangleF(float x, float y, float width, float height) { _location = new PointF(x, y); _size = new SizeF(width, height); }

        [BrowsableAttribute(false)]
        public float Bottom { get { return _location.Y + _size.Height; } }

        public float Height { get { return _size.Height; } set { _size.Height = value; } }

        [BrowsableAttribute(false)]
        public bool IsEmpty { get { return this == Empty; } }

        [BrowsableAttribute(false)]
        public float Left { get { return _location.X; } }

        [BrowsableAttribute(false)]
        public PointF Location { get { return _location; } set { _location = value; } }

        [BrowsableAttribute(false)]
        public float Right { get { return _location.X + _size.Width; } }

        [BrowsableAttribute(false)]
        public SizeF Size { get { return _size; } set { _size = value; } }

        [BrowsableAttribute(false)]
        public float Top { get { return _location.Y; } }

        public float Width { get { return _size.Width; } set { _size.Width = value; } }
        public float X { get { return _location.X; } set { _location.X = value; } }
        public float Y { get { return _location.Y; } set { _location.Y = value; } }

        /// <summary>
        /// Determines if a <see cref="PointF"/> is contained within the current <see cref="RectangleF"/>.
        /// </summary>
        /// <param name="pt">The <see cref="PointF"/> to test.</param>
        /// <returns>True if pt is contained within this <see cref="RectangleF"/>.</returns>
        public bool Contains(PointF pt) { return Contains(pt.X, pt.Y); }
        /// <summary>
        /// Determines if a <see cref="RectangleF"/> is entirely contained within this <see cref="RectangleF"/>.
        /// </summary>
        /// <param name="rect">The <see cref="RectangleF"/> to test.</param>
        /// <returns>True if rect is entirely contained within this <see cref="RectangleF"/>.</returns>
        public bool Contains(RectangleF rect) { return Contains(rect.Top, rect.Left) && Contains(rect.Top, rect.Right) && Contains(rect.Bottom, rect.Left) && Contains(rect.Bottom, rect.Right); }
        /// <summary>
        /// Determines if the position represented by x and y is contained within the current <see cref="RectangleF"/>.
        /// </summary>
        /// <param name="x">The x value of the position to test.</param>
        /// <param name="y">The y value of the position to test.</param>
        /// <returns>True if the position represented by the x and y values is contained within this <see cref="RectangleF"/>.</returns>
        /// <remarks>
        /// This method is entirely inclusive. If the position represented by the x and y values is on the edge of, or entirely within the current <see cref="RectangleF"/>, then this method will return true.
        /// </remarks>
        public bool Contains(float x, float y) { return _location.X <= x && _location.X + _size.Width >= x && _location.Y <= y && _location.Y + _size.Height >= y; }
        public override bool Equals(Object obj) { if (obj.GetType() == typeof(RectangleF)) { return (RectangleF)obj == this; } else { return false; } }
        public static RectangleF FromLTRB(float left, float top, float right, float bottom) { return new RectangleF(new PointF(top, left), new SizeF(bottom - top, right - left)); }
        public override int GetHashCode() { return base.GetHashCode(); }
        public void Inflate(SizeF size) { _size += size; }
        public void Inflate(float x, float y) { _size += new SizeF(x, y); }
        public static RectangleF Inflate(RectangleF rect, float x, float y) { RectangleF nr = new RectangleF(rect.Location, rect.Size); nr.Inflate(x, y); return nr; }
        public void Intersect(RectangleF rect) { this = Intersect(this, rect); }
        public static RectangleF Intersect(RectangleF a, RectangleF b)
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
                        if (aConBBL) { return new RectangleF(b.Location, b.Size); }
                        else { return new RectangleF(b.Location, new SizeF(b.Width, a.Bottom - b.Top)); }
                    }
                    else
                    {
                        if (aConBBL) { return new RectangleF(b.Location, new SizeF(a.Right - b.Left, b.Height)); }
                        else { return new RectangleF(b.Location, new SizeF(a.Right - b.Left, a.Bottom - b.Top)); }
                    }
                }
                else
                {
                    if (aConBTR)
                    {
                        if (aConBBR) { return new RectangleF(b.Location, new SizeF(b.Right - a.Left, b.Height)); }
                        else { return new RectangleF(b.Location, new SizeF(b.Right - a.Left, a.Bottom - b.Top)); }
                    }
                    else
                    {
                        if (aConBBL)
                        {
                            if (aConBBR) { return new RectangleF(a.Location, new SizeF(b.Width, b.Bottom - a.Top)); }
                            else { return new RectangleF(new PointF(b.Left, a.Top), new SizeF(a.Right - b.Left, b.Bottom - a.Top)); }
                        }
                        else
                        {
                            if (aConBBR) { return new RectangleF(a.Location, new SizeF(b.Right - a.Left, b.Bottom - a.Top)); }
                            else
                            {
                                if (bConATL) { return new RectangleF(a.Location, a.Size); }
                                else { return Empty; }
                            }
                        }
                    }
                }
            }
            else { return Empty; }
        }
        public bool IntersectsWith(RectangleF rect) { return Contains(rect.Top, rect.Left) || Contains(rect.Top, rect.Right) || Contains(rect.Bottom, rect.Left) || Contains(rect.Bottom, rect.Right); }
        public void Offset(PointF pos) { _location = new PointF(_location.X + pos.X, _location.Y + pos.Y); }
        public void Offset(float x, float y) { _location = new PointF(_location.X + x, _location.Y + y); }
        public override string ToString() { return "(" + _location.X + "," + _location.Y + "," + _size.Width + "," + _size.Height + ")"; }
        public static RectangleF Union(RectangleF a, RectangleF b) { return new RectangleF(Math.Min(a.X, b.X), Math.Min(a.Y, b.Y), Math.Max(a.X + a.Width, b.X + b.Width), Math.Max(a.Y + a.Height, b.Y + b.Height)); }

        public static bool operator ==(RectangleF left, RectangleF right) { return left.Location == right.Location && left.Size == right.Size; }
        public static implicit operator RectangleF(Rectangle r) { return new RectangleF(r.Location, r.Size); }
        public static bool operator !=(RectangleF left, RectangleF right) { return left.Location != right.Location || left.Size != right.Size; }

        public static readonly RectangleF Empty = new RectangleF(0, 0, 0, 0);
    }
}
