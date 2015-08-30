using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Evbpc.Framework.Drawing
{
    [Serializable]
    [TypeConverter(typeof(PointConverter))]
    [StructLayout(LayoutKind.Explicit)]
    public struct PointShort
    {
        [FieldOffset(0)]
        private readonly uint _packedValue;
        [FieldOffset(0)]
        private readonly short _x;
        [FieldOffset(2)]
        private readonly short _y;

        public PointShort(Size sz)
            : this()
        {
            _x = (short)(sz.Width);
            _y = (short)(sz.Height);
        }

        public PointShort(short x, short y)
            : this()
        {
            _x = x;
            _y = y;
        }

        public PointShort(uint packedValue)
            : this()
        {
            _packedValue = packedValue;
        }

        [Browsable(false)]
        public bool IsEmpty { get { return this == Empty; } }

        public short X { get { return _x; } }
        public short Y { get { return _y; } }

        public static PointShort Add(PointShort pt, Size sz)
        {
            return pt + sz;
        }

        public static PointShort Add(PointShort pt, SizeByte sz)
        {
            return pt + sz;
        }

        public static PointShort Add(PointShort pt, SizeShort sz)
        {
            return pt + sz;
        }

        public static PointShort Ceiling(PointF value)
        {
            return new PointShort((short)Math.Ceiling(value.X), (short)Math.Ceiling(value.Y));
        }

        public override bool Equals(Object obj)
        {
            if (obj is PointShort)
                return (PointShort)obj == this;

            return false;
        }

        public override int GetHashCode()
        {
            return (int)_packedValue;
        }

        public void Offset(PointShort p)
        {
            this = new PointShort((short)(_x + p.X), (short)(_y + p.Y));
        }

        public void Offset(short dx, short dy)
        {
            this = new PointShort((short)(_x + dx), (short)(_y + dy));
        }

        public static PointShort Round(PointF value)
        {
            return new PointShort((short)Math.Round(value.X), (short)Math.Round(value.Y));
        }

        public static PointShort Subtract(PointShort pt, Size sz)
        {
            return pt - sz;
        }

        public static PointShort Subtract(PointShort pt, SizeByte sz)
        {
            return pt - sz;
        }

        public static PointShort Subtract(PointShort pt, SizeShort sz)
        {
            return pt - sz;
        }

        public override string ToString()
        {
            return $"({_x},{_y})";
        }

        public static PointShort Truncate(PointF value)
        {
            return new PointShort((short)(value.X), (short)(value.Y));
        }

        public uint GetPackedValue()
        {
            return _packedValue;
        }

        public static PointShort operator +(PointShort pt, Size sz)
        {
            return new PointShort((short)(pt.X + sz.Width), (short)(pt.Y + sz.Height));
        }

        public static PointShort operator +(PointShort pt, SizeByte sz)
        {
            return new PointShort((short)(pt.X + sz.Width), (short)(pt.Y + sz.Height));
        }

        public static PointShort operator +(PointShort pt, SizeShort sz)
        {
            return new PointShort((short)(pt.X + sz.Width), (short)(pt.Y + sz.Height));
        }

        public static bool operator ==(PointShort left, PointShort right)
        {
            return left.X == right.X && left.Y == right.Y;
        }

        public static explicit operator Size(PointShort p)
        {
            return new Size(p.X, p.Y);
        }

        public static explicit operator SizeShort(PointShort p)
        {
            return new SizeShort(p.X, p.Y);
        }

        public static implicit operator PointF(PointShort p)
        {
            return new PointF(p.X, p.Y);
        }

        public static bool operator !=(PointShort left, PointShort right)
        {
            return left.X != right.X || left.Y != right.Y;
        }

        public static PointShort operator -(PointShort pt, Size sz)
        {
            return new PointShort((short)(pt.X - sz.Width), (short)(pt.Y - sz.Height));
        }

        public static PointShort operator -(PointShort pt, SizeByte sz)
        {
            return new PointShort((short)(pt.X - sz.Width), (short)(pt.Y - sz.Height));
        }

        public static PointShort operator -(PointShort pt, SizeShort sz)
        {
            return new PointShort((short)(pt.X - sz.Width), (short)(pt.Y - sz.Height));
        }

        public static readonly PointShort Empty = new PointShort(0, 0);
    }
}
