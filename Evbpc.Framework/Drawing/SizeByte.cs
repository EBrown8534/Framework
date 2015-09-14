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
        public SizeByte(Point pt)
        {
            Width = (byte)(pt.X);
            Height = (byte)(pt.Y);
        }

        public SizeByte(byte width, byte height)
        {
            Width = width;
            Height = height;
        }

        public byte Height { get; }

        [Browsable(false)]
        public bool IsEmpty => this == Empty;

        public byte Width { get; }

        public static SizeByte Add(SizeByte sz1, SizeByte sz2) => sz1 + sz2;

        public static SizeByte Ceiling(SizeF value) => new SizeByte((byte)Math.Ceiling(value.Width), (byte)Math.Ceiling(value.Height));

        public override bool Equals(Object obj) => obj is SizeByte && (SizeByte)obj == this;

        public override int GetHashCode() => base.GetHashCode();

        public static SizeByte Round(SizeF value) => new SizeByte((byte)Math.Round(value.Width), (byte)Math.Round(value.Height));

        public static SizeByte Subtract(SizeByte sz1, SizeByte sz2) => sz1 - sz2;

        public override string ToString() => $"({Width},{Height})";

        public static SizeByte Truncate(SizeF value) => new SizeByte((byte)(value.Width), (byte)(value.Height));

        public static SizeByte operator +(SizeByte sz1, SizeByte sz2) => new SizeByte((byte)(sz1.Width + sz2.Width), (byte)(sz1.Height + sz2.Height));

        public static bool operator ==(SizeByte sz1, SizeByte sz2) => sz1.Width == sz2.Width && sz1.Height == sz2.Height;

        public static explicit operator Point(SizeByte size) => new Point(size.Width, size.Height);

        public static explicit operator PointShort(SizeByte size) => new PointShort(size.Width, size.Height);

        public static implicit operator SizeF(SizeByte p) => new SizeF(p.Width, p.Height);

        public static implicit operator Size(SizeByte p) => new Size(p.Width, p.Height);

        public static implicit operator SizeShort(SizeByte p) => new SizeShort(p.Width, p.Height);

        public static bool operator !=(SizeByte sz1, SizeByte sz2) => sz1.Width != sz2.Width || sz1.Height != sz2.Height;

        public static SizeByte operator -(SizeByte sz1, SizeByte sz2) => new SizeByte((byte)(sz1.Width - sz2.Width), (byte)(sz1.Height - sz2.Height));

        public static readonly SizeByte Empty = new SizeByte(0, 0);
    }
}
