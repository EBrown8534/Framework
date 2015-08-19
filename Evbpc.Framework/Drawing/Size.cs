using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Evbpc.Framework.Drawing
{
    [SerializableAttribute]
    [TypeConverterAttribute(typeof(SizeConverter))]
    public struct Size
    {
        private int _width;
        private int _height;

        public Size(Point pt) { _width = pt.X; _height = pt.Y; }
        public Size(int width, int height) { _width = width; _height = height; }

        public int Height { get { return _height; } set { _height = value; } }

        [BrowsableAttribute(false)]
        public bool IsEmpty { get { return this == Empty; } }

        public int Width { get { return _width; } set { _width = value; } }

        public static Size Add(Size sz1, Size sz2) { return sz1 + sz2; }
        public static Size Ceiling(SizeF value) { return new Size((int)Math.Ceiling(value.Width), (int)Math.Ceiling(value.Height)); }
        public override bool Equals(Object obj) { if (obj.GetType() == typeof(Size)) { return (Size)obj == this; } else { return false; } }
        public override int GetHashCode() { return base.GetHashCode(); }
        public static Size Round(SizeF value) { return new Size((int)Math.Round(value.Width), (int)Math.Round(value.Height)); }
        public static Size Subtract(Size sz1, Size sz2) { return sz1 - sz2; }
        public override string ToString() { return "(" + _width + "," + _height + ")"; }
        public static Size Truncate(SizeF value) { return new Size((int)(value.Width), (int)(value.Height)); }

        public static Size operator +(Size sz1, Size sz2) { return new Size(sz1.Width + sz2.Width, sz1.Height + sz2.Height); }
        public static bool operator ==(Size sz1, Size sz2) { return sz1.Width == sz2.Width && sz1.Height == sz2.Height; }
        public static explicit operator Point(Size size) { return new Point(size.Width, size.Height); }
        public static implicit operator SizeF(Size p) { return new SizeF(p.Width, p.Height); }
        public static bool operator !=(Size sz1, Size sz2) { return sz1.Width != sz2.Width || sz1.Height != sz2.Height; }
        public static Size operator -(Size sz1, Size sz2) { return new Size(sz1.Width - sz2.Width, sz1.Height - sz2.Height); }

        public static readonly Size Empty = new Size(0, 0);
    }
}
