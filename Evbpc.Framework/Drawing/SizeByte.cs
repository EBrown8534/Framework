using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Evbpc.Framework.Drawing
{
    [Serializable]
    public struct SizeByte
    {
        private byte _width;
        private byte _height;

        public SizeByte(Point pt) { _width = (byte)(pt.X); _height = (byte)(pt.Y); }
        public SizeByte(byte width, byte height) { _width = width; _height = height; }

        public byte Height { get { return _height; } set { _height = value; } }

        [BrowsableAttribute(false)]
        public bool IsEmpty { get { return this == Empty; } }

        public byte Width { get { return _width; } set { _width = value; } }

        public static SizeByte Add(SizeByte sz1, SizeByte sz2) { return sz1 + sz2; }
        public static SizeByte Ceiling(SizeF value) { return new SizeByte((byte)Math.Ceiling(value.Width), (byte)Math.Ceiling(value.Height)); }
        public override bool Equals(Object obj) { if (obj.GetType() == typeof(SizeByte)) { return (SizeByte)obj == this; } else { return false; } }
        public override int GetHashCode() { return base.GetHashCode(); }
        public static SizeByte Round(SizeF value) { return new SizeByte((byte)Math.Round(value.Width), (byte)Math.Round(value.Height)); }
        public static SizeByte Subtract(SizeByte sz1, SizeByte sz2) { return sz1 - sz2; }
        public override string ToString() { return "(" + _width + "," + _height + ")"; }
        public static SizeByte Truncate(SizeF value) { return new SizeByte((byte)(value.Width), (byte)(value.Height)); }

        public static SizeByte operator +(SizeByte sz1, SizeByte sz2) { return new SizeByte((byte)(sz1.Width + sz2.Width), (byte)(sz1.Height + sz2.Height)); }
        public static bool operator ==(SizeByte sz1, SizeByte sz2) { return sz1.Width == sz2.Width && sz1.Height == sz2.Height; }
        public static explicit operator Point(SizeByte size) { return new Point(size.Width, size.Height); }
        public static explicit operator PointShort(SizeByte size) { return new PointShort(size.Width, size.Height); }
        public static implicit operator SizeF(SizeByte p) { return new SizeF(p.Width, p.Height); }
        public static implicit operator Size(SizeByte p) { return new Size(p.Width, p.Height); }
        public static implicit operator SizeShort(SizeByte p) { return new SizeShort(p.Width, p.Height); }
        public static bool operator !=(SizeByte sz1, SizeByte sz2) { return sz1.Width != sz2.Width || sz1.Height != sz2.Height; }
        public static SizeByte operator -(SizeByte sz1, SizeByte sz2) { return new SizeByte((byte)(sz1.Width - sz2.Width), (byte)(sz1.Height - sz2.Height)); }

        public static readonly SizeByte Empty = new SizeByte(0, 0);
    }
}
