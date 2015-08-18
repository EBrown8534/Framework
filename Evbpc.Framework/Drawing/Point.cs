using Evbpc.Framework.Utilities.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Evbpc.Framework.Drawing
{
    [SerializableAttribute]
    [TypeConverterAttribute(typeof(PointConverter))]
    [StructLayout(LayoutKind.Explicit)]
    public struct Point : ISerializableByteArray
    {
        [FieldOffset(0)]
        private ulong _PackedValue;
        [FieldOffset(0)]
        private int _X;
        [FieldOffset(4)]
        private int _Y;

        public Point(Size sz)
            : this()
        {
            _X = sz.Width;
            _Y = sz.Height;
        }

        public Point(int x, int y)
            : this()
        {
            _X = x;
            _Y = y;
        }

        [BrowsableAttribute(false)]
        public bool IsEmpty { get { return this == Empty; } }

        public int X { get { return _X; } set { _X = value; } }
        public int Y { get { return _Y; } set { _Y = value; } }

        public int SizeInBytes { get { return 8; } }

        public static Point Add(Point pt, Size sz) { return pt + sz; }
        public static Point Ceiling(PointF value) { return new Point((int)Math.Ceiling(value.X), (int)Math.Ceiling(value.Y)); }
        public override bool Equals(Object obj) { if (obj.GetType() == typeof(Point)) { return (Point)obj == this; } else { return false; } }
        public override int GetHashCode() { return base.GetHashCode(); }
        public void Offset(Point p) { _X += p.X; _Y += p.Y; }
        public void Offset(int dx, int dy) { _X += dx; _Y += dy; }
        public static Point Round(PointF value) { return new Point((int)Math.Round(value.X), (int)Math.Round(value.Y)); }
        public static Point Subtract(Point pt, Size sz) { return pt - sz; }
        public override string ToString() { return "(" + _X + "," + _Y + ")"; }
        public static Point Truncate(PointF value) { return new Point((int)(value.X), (int)(value.Y)); }

        public static Point operator +(Point pt, Size sz) { return new Point(pt.X + sz.Width, pt.Y + sz.Height); }
        public static bool operator ==(Point left, Point right) { return left.X == right.X && left.Y == right.Y; }
        public static explicit operator Size(Point p) { return new Size(p.X, p.Y); }
        public static implicit operator PointF(Point p) { return new PointF(p.X, p.Y); }
        public static bool operator !=(Point left, Point right) { return left.X != right.X || left.Y != right.Y; }
        public static Point operator -(Point pt, Size sz) { return new Point(pt.X - sz.Width, pt.Y - sz.Height); }

        public static readonly Point Empty = new Point(0, 0);

        public byte[] GetBytes()
        {
            byte[] bytes = new byte[SizeInBytes];

            bytes[0] = (byte)(_X & 0xFF000000 >> 24);
            bytes[1] = (byte)(_X & 0x00FF0000 >> 16);
            bytes[2] = (byte)(_X & 0x0000FF00 >> 8);
            bytes[3] = (byte)(_X & 0x000000FF >> 0);
            bytes[4] = (byte)(_Y & 0xFF000000 >> 24);
            bytes[5] = (byte)(_Y & 0x00FF0000 >> 16);
            bytes[6] = (byte)(_Y & 0x0000FF00 >> 8);
            bytes[7] = (byte)(_Y & 0x000000FF >> 0);

            return bytes;
        }

        public void FromBytes(byte[] data)
        {
            if (data.Length != SizeInBytes)
                throw new ArgumentException("The parameter `data` must be a " + SizeInBytes + " index byte-array.");

            _X = ((int)data[0] << 24 | (int)data[1] << 16 | (int)data[2] << 8 | (int)data[3] << 0);
            _Y = ((int)data[4] << 24 | (int)data[5] << 16 | (int)data[6] << 8 | (int)data[7] << 0);
        }
    }
}
