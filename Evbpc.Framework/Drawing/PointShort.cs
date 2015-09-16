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
        public bool IsEmpty => this == Empty;

        public short X => _x;
        public short Y => _y;

        public static PointShort Add(PointShort pt, Size sz) => pt + sz;

        public static PointShort Add(PointShort pt, SizeByte sz) => pt + sz;

        public static PointShort Add(PointShort pt, SizeShort sz) => pt + sz;

        public static PointShort Ceiling(PointF value) => new PointShort((short)Math.Ceiling(value.X), (short)Math.Ceiling(value.Y));

        public override bool Equals(Object obj) => obj is PointShort && (PointShort)obj == this;

        public override int GetHashCode() => (int)_packedValue;

        public PointShort Offset(PointShort p) => new PointShort((short)(_x + p.X), (short)(_y + p.Y));

        public PointShort Offset(short dx, short dy) => new PointShort((short)(_x + dx), (short)(_y + dy));

        public static PointShort Round(PointF value) => new PointShort((short)Math.Round(value.X), (short)Math.Round(value.Y));

        public static PointShort Subtract(PointShort pt, Size sz) => pt - sz;

        public static PointShort Subtract(PointShort pt, SizeByte sz) => pt - sz;

        public static PointShort Subtract(PointShort pt, SizeShort sz) => pt - sz;

        public override string ToString() => $"({_x},{_y})";

        public static PointShort Truncate(PointF value) => new PointShort((short)(value.X), (short)(value.Y));

        public uint GetPackedValue() => _packedValue;

        public static PointShort operator +(PointShort pt, Size sz) => new PointShort((short)(pt.X + sz.Width), (short)(pt.Y + sz.Height));

        public static PointShort operator +(PointShort pt, SizeByte sz) => new PointShort((short)(pt.X + sz.Width), (short)(pt.Y + sz.Height));

        public static PointShort operator +(PointShort pt, SizeShort sz) => new PointShort((short)(pt.X + sz.Width), (short)(pt.Y + sz.Height));

        public static bool operator ==(PointShort left, PointShort right) => left.X == right.X && left.Y == right.Y;

        public static explicit operator Size(PointShort p) => new Size(p.X, p.Y);

        public static explicit operator SizeShort(PointShort p) => new SizeShort(p.X, p.Y);

        public static implicit operator PointF(PointShort p) => new PointF(p.X, p.Y);

        public static bool operator !=(PointShort left, PointShort right) => left.X != right.X || left.Y != right.Y;

        public static PointShort operator -(PointShort pt, Size sz) => new PointShort((short)(pt.X - sz.Width), (short)(pt.Y - sz.Height));

        public static PointShort operator -(PointShort pt, SizeByte sz) => new PointShort((short)(pt.X - sz.Width), (short)(pt.Y - sz.Height));

        public static PointShort operator -(PointShort pt, SizeShort sz) => new PointShort((short)(pt.X - sz.Width), (short)(pt.Y - sz.Height));

        public static readonly PointShort Empty = new PointShort(0, 0);
    }
}
