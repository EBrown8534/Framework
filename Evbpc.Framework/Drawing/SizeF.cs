using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Evbpc.Framework.Drawing
{
    [Serializable]
    [TypeConverter(typeof(SizeFConverter))]
    public struct SizeF
    {
        public SizeF(PointF pt)
        {
            Width = pt.X;
            Height = pt.Y;
        }

        public SizeF(SizeF size)
        {
            Width = size.Width;
            Height = size.Height;
        }

        public SizeF(float width, float height)
        {
            Width = width;
            Height = height;
        }

        public float Height { get; }

        [Browsable(false)]
        public bool IsEmpty => this == Empty;

        public float Width { get; }

        public static SizeF Add(SizeF sz1, SizeF sz2) => sz1 + sz2;

        public override bool Equals(Object obj) => obj is SizeF && (SizeF)obj == this;

        public override int GetHashCode() => base.GetHashCode();

        public static SizeF Subtract(SizeF sz1, SizeF sz2) => sz1 - sz2;

        public PointF ToPointF() => new PointF(Width, Height);

        public Size ToSize() => new Size((int)Width, (int)Height);

        public override string ToString() => $"({Width},{Height})";

        public static SizeF operator +(SizeF sz1, SizeF sz2) => new SizeF(sz1.Width + sz2.Width, sz1.Height + sz2.Height);

        public static bool operator ==(SizeF sz1, SizeF sz2) => sz1.Width == sz2.Width && sz1.Height == sz2.Height;

        public static explicit operator PointF(SizeF size) => new PointF(size.Width, size.Height);

        public static bool operator !=(SizeF sz1, SizeF sz2) => sz1.Width != sz2.Width || sz1.Height != sz2.Height;

        public static SizeF operator -(SizeF sz1, SizeF sz2) => new SizeF(sz1.Width - sz2.Width, sz1.Height - sz2.Height);

        public static readonly SizeF Empty = new SizeF(0, 0);
    }
}
