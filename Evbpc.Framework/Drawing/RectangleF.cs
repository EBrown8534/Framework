using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Evbpc.Framework.Drawing
{
    [Serializable]
    public struct RectangleF
    {
        public RectangleF(PointF location, SizeF size)
        {
            Location = location;
            Size = size;
        }

        public RectangleF(float x, float y, float width, float height)
        {
            Location = new PointF(x, y);
            Size = new SizeF(width, height);
        }

        [Browsable(false)]
        public float Bottom => Location.Y + Size.Height;

        public float Height => Size.Height;

        [Browsable(false)]
        public bool IsEmpty => this == Empty;

        [Browsable(false)]
        public float Left => Location.X;

        [Browsable(false)]
        public PointF Location { get; }

        [Browsable(false)]
        public float Right => Location.X + Size.Width;

        [Browsable(false)]
        public SizeF Size { get; }

        [Browsable(false)]
        public float Top => Location.Y;

        public float Width => Size.Width;
        public float X => Location.X;
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

        public override bool Equals(Object obj) => obj is RectangleF && (RectangleF)obj == this;

        public static RectangleF FromLTRB(float left, float top, float right, float bottom) => new RectangleF(new PointF(top, left), new SizeF(bottom - top, right - left));

        public override int GetHashCode() => base.GetHashCode();

        public RectangleF Inflate(SizeF size) => new RectangleF(Location, Size + size);

        public RectangleF Inflate(float x, float y) => new RectangleF(Location, Size + new SizeF(x, y));

        public static RectangleF Inflate(RectangleF rect, float x, float y) => rect.Inflate(x, y);

        public RectangleF Intersect(RectangleF rect) => Intersect(this, rect);

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
                else
                {
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
                    else
                    {
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
                        else
                        {
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

        public bool IntersectsWith(RectangleF rect) => Contains(rect.Top, rect.Left) || Contains(rect.Top, rect.Right) || Contains(rect.Bottom, rect.Left) || Contains(rect.Bottom, rect.Right);

        public void Offset(PointF pos)
        {
            this = new RectangleF(new PointF(Location.X + pos.X, Location.Y + pos.Y), Size);
        }

        public void Offset(float x, float y)
        {
            this = new RectangleF(new PointF(Location.X + x, Location.Y + y), Size);
        }

        public override string ToString() => $"({Location.X},{Location.Y},{Size.Width},{Size.Height})";

        public static RectangleF Union(RectangleF a, RectangleF b) => new RectangleF(Math.Min(a.X, b.X), Math.Min(a.Y, b.Y), Math.Max(a.X + a.Width, b.X + b.Width), Math.Max(a.Y + a.Height, b.Y + b.Height));

        public static bool operator ==(RectangleF left, RectangleF right) => left.Location == right.Location && left.Size == right.Size;

        public static implicit operator RectangleF(Rectangle r) => new RectangleF(r.Location, r.Size);

        public static bool operator !=(RectangleF left, RectangleF right) => left.Location != right.Location || left.Size != right.Size;

        public static readonly RectangleF Empty = new RectangleF(0, 0, 0, 0);
    }
}
