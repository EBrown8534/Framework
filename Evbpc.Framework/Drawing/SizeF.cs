using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Evbpc.Framework.Drawing
{
    [SerializableAttribute]
    [TypeConverterAttribute(typeof(SizeFConverter))]
    public struct SizeF
    {
        private float _width;
        private float _height;

        public SizeF(PointF pt) { _width = pt.X; _height = pt.Y; }
        public SizeF(SizeF size) { _width = size.Width; _height = size.Height; }
        public SizeF(float width, float height) { _width = width; _height = height; }

        public float Height { get { return _height; } set { _height = value; } }

        [BrowsableAttribute(false)]
        public bool IsEmpty { get { return this == Empty; } }

        public float Width { get { return _width; } set { _width = value; } }

        public static SizeF Add(SizeF sz1, SizeF sz2) { return sz1 + sz2; }
        public override bool Equals(Object obj) { if (obj.GetType() == typeof(SizeF)) { return (SizeF)obj == this; } else { return false; } }
        public override int GetHashCode() { return base.GetHashCode(); }
        public static SizeF Subtract(SizeF sz1, SizeF sz2) { return sz1 - sz2; }
        public PointF ToPointF() { return new PointF(_width, _height); }
        public Size ToSize() { return new Size((int)_width, (int)_height); }
        public override string ToString() { return "(" + _width + "," + _height + ")"; }

        public static SizeF operator +(SizeF sz1, SizeF sz2) { return new SizeF(sz1.Width + sz2.Width, sz1.Height + sz2.Height); }
        public static bool operator ==(SizeF sz1, SizeF sz2) { return sz1.Width == sz2.Width && sz1.Height == sz2.Height; }
        public static explicit operator PointF(SizeF size) { return new PointF(size.Width, size.Height); }
        public static bool operator !=(SizeF sz1, SizeF sz2) { return sz1.Width != sz2.Width || sz1.Height != sz2.Height; }
        public static SizeF operator -(SizeF sz1, SizeF sz2) { return new SizeF(sz1.Width - sz2.Width, sz1.Height - sz2.Height); }

        public static readonly SizeF Empty = new SizeF(0, 0);
    }
}
