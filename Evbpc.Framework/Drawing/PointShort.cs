using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Evbpc.Framework.Drawing
{
    [SerializableAttribute]
    [TypeConverterAttribute(typeof(PointConverter))]
    public struct PointShort
    {
        private short _X;
        private short _Y;

        public PointShort(Size sz) { _X = (short)(sz.Width); _Y = (short)(sz.Height); }
        public PointShort(short x, short y) { _X = x; _Y = y; }

        [BrowsableAttribute(false)]
        public bool IsEmpty { get { return this == Empty; } }

        public short X { get { return _X; } set { _X = value; } }
        public short Y { get { return _Y; } set { _Y = value; } }

        public static PointShort Add(PointShort pt, Size sz) { return pt + sz; }
        public static PointShort Add(PointShort pt, SizeByte sz) { return pt + sz; }
        public static PointShort Add(PointShort pt, SizeShort sz) { return pt + sz; }
        public static PointShort Ceiling(PointF value) { return new PointShort((short)Math.Ceiling(value.X), (short)Math.Ceiling(value.Y)); }
        public override bool Equals(Object obj) { if (obj.GetType() == typeof(PointShort)) { return (PointShort)obj == this; } else { return false; } }
        public override int GetHashCode() { return base.GetHashCode(); }
        public void Offset(PointShort p) { _X += p.X; _Y += p.Y; }
        public void Offset(short dx, short dy) { _X += dx; _Y += dy; }
        public static PointShort Round(PointF value) { return new PointShort((short)Math.Round(value.X), (short)Math.Round(value.Y)); }
        public static PointShort Subtract(PointShort pt, Size sz) { return pt - sz; }
        public static PointShort Subtract(PointShort pt, SizeByte sz) { return pt - sz; }
        public static PointShort Subtract(PointShort pt, SizeShort sz) { return pt - sz; }
        public override string ToString() { return "(" + _X + "," + _Y + ")"; }
        public static PointShort Truncate(PointF value) { return new PointShort((short)(value.X), (short)(value.Y)); }

        public static PointShort operator +(PointShort pt, Size sz) { return new PointShort((short)(pt.X + sz.Width), (short)(pt.Y + sz.Height)); }
        public static PointShort operator +(PointShort pt, SizeByte sz) { return new PointShort((short)(pt.X + sz.Width), (short)(pt.Y + sz.Height)); }
        public static PointShort operator +(PointShort pt, SizeShort sz) { return new PointShort((short)(pt.X + sz.Width), (short)(pt.Y + sz.Height)); }
        public static bool operator ==(PointShort left, PointShort right) { return left.X == right.X && left.Y == right.Y; }
        public static explicit operator Size(PointShort p) { return new Size(p.X, p.Y); }
        public static explicit operator SizeShort(PointShort p) { return new SizeShort(p.X, p.Y); }
        public static implicit operator PointF(PointShort p) { return new PointF(p.X, p.Y); }
        public static bool operator !=(PointShort left, PointShort right) { return left.X != right.X || left.Y != right.Y; }
        public static PointShort operator -(PointShort pt, Size sz) { return new PointShort((short)(pt.X - sz.Width), (short)(pt.Y - sz.Height)); }
        public static PointShort operator -(PointShort pt, SizeByte sz) { return new PointShort((short)(pt.X - sz.Width), (short)(pt.Y - sz.Height)); }
        public static PointShort operator -(PointShort pt, SizeShort sz) { return new PointShort((short)(pt.X - sz.Width), (short)(pt.Y - sz.Height)); }

        public static readonly PointShort Empty = new PointShort(0, 0);
    }
}
