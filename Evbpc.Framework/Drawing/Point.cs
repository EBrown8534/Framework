using Evbpc.Framework.Utilities.Serialization;
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
    public struct Point : ISerializableByteArray
    {
        [FieldOffset(0)]
        private readonly ulong _packedValue;
        [FieldOffset(0)]
        private readonly int _x;
        [FieldOffset(4)]
        private readonly int _y;

        public Point(Size sz)
            : this()
        {
            _x = sz.Width;
            _y = sz.Height;
        }

        public Point(int x, int y)
            : this()
        {
            _x = x;
            _y = y;
        }

        [Browsable(false)]
        public bool IsEmpty => this == Empty;

        public int X => _x;
        public int Y => _y;

        public int SizeInBytes => 8;

        public static Point Add(Point pt, Size sz) => pt + sz;

        public static Point Ceiling(PointF value) => new Point((int)Math.Ceiling(value.X), (int)Math.Ceiling(value.Y));

        public override bool Equals(Object obj)
        {
            if (obj is Point)
                return (Point)obj == this;

            return false;
        }

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

        public void Offset(Point p)
        {
            this = new Point(_x + p.X, _y + p.Y);
        }

        public void Offset(int dx, int dy)
        {
            this = new Point(_x + dx, _y + dy);
        }

        public static Point Round(PointF value) => new Point((int)Math.Round(value.X), (int)Math.Round(value.Y));

        public static Point Subtract(Point pt, Size sz) => pt - sz;

        public override string ToString() => $"({_x},{_y})";

        public static Point Truncate(PointF value) => new Point((int)(value.X), (int)(value.Y));

        public static Point operator +(Point pt, Size sz) => new Point(pt.X + sz.Width, pt.Y + sz.Height);

        public static bool operator ==(Point left, Point right) => left.X == right.X && left.Y == right.Y;

        public static explicit operator Size(Point p) => new Size(p.X, p.Y);

        public static implicit operator PointF(Point p) => new PointF(p.X, p.Y);

        public static bool operator !=(Point left, Point right) => left.X != right.X || left.Y != right.Y;

        public static Point operator -(Point pt, Size sz) => new Point(pt.X - sz.Width, pt.Y - sz.Height);

        public static readonly Point Empty = new Point(0, 0);

        public byte[] GetBytes()
        {
            byte[] bytes = new byte[SizeInBytes];

            bytes[0] = (byte)((_x & 0xFF000000) >> 24);
            bytes[1] = (byte)((_x & 0x00FF0000) >> 16);
            bytes[2] = (byte)((_x & 0x0000FF00) >> 8);
            bytes[3] = (byte)((_x & 0x000000FF) >> 0);
            bytes[4] = (byte)((_y & 0xFF000000) >> 24);
            bytes[5] = (byte)((_y & 0x00FF0000) >> 16);
            bytes[6] = (byte)((_y & 0x0000FF00) >> 8);
            bytes[7] = (byte)((_y & 0x000000FF) >> 0);

            return bytes;
        }

        public void FromBytes(byte[] data)
        {
            if (data.Length != SizeInBytes)
                throw new ArgumentException($"The parameter \"data\" must be a {SizeInBytes} index byte-array.");

            this = new Point(
                ((int)data[0] << 24 | (int)data[1] << 16 | (int)data[2] << 8 | (int)data[3] << 0),
                ((int)data[4] << 24 | (int)data[5] << 16 | (int)data[6] << 8 | (int)data[7] << 0));
        }
    }
}
