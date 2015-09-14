using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Evbpc.Framework.Drawing
{
    [Serializable]
    [TypeConverter(typeof(SizeConverter))]
    public struct Size
    {
        public Size(Point pt)
        {
            Width = pt.X;
            Height = pt.Y;
        }

        public Size(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public int Height { get; }

        [Browsable(false)]
        public bool IsEmpty => this == Empty;

        public int Width { get; }

        public static Size Add(Size sz1, Size sz2) => sz1 + sz2;

        public static Size Ceiling(SizeF value) => new Size((int)Math.Ceiling(value.Width), (int)Math.Ceiling(value.Height));

        public override bool Equals(Object obj) => obj is Size && (Size)obj == this;

        public override int GetHashCode() => base.GetHashCode();

        public static Size Round(SizeF value) => new Size((int)Math.Round(value.Width), (int)Math.Round(value.Height));

        public static Size Subtract(Size sz1, Size sz2) => sz1 - sz2;

        public override string ToString() => $"({Width},{Height})";

        public static Size Truncate(SizeF value) => new Size((int)(value.Width), (int)(value.Height));

        public static Size operator +(Size sz1, Size sz2) => new Size(sz1.Width + sz2.Width, sz1.Height + sz2.Height);

        public static bool operator ==(Size sz1, Size sz2) => sz1.Width == sz2.Width && sz1.Height == sz2.Height;

        public static explicit operator Point(Size size) => new Point(size.Width, size.Height);

        public static implicit operator SizeF(Size p) => new SizeF(p.Width, p.Height);

        public static bool operator !=(Size sz1, Size sz2) => sz1.Width != sz2.Width || sz1.Height != sz2.Height;

        public static Size operator -(Size sz1, Size sz2) => new Size(sz1.Width - sz2.Width, sz1.Height - sz2.Height);

        public static readonly Size Empty = new Size(0, 0);
    }
}
