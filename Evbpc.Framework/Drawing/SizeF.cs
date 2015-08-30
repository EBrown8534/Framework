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
        private readonly float _width;
        private readonly float _height;

        public SizeF(PointF pt) { _width = pt.X; _height = pt.Y; }
        public SizeF(SizeF size) { _width = size.Width; _height = size.Height; }
        public SizeF(float width, float height) { _width = width; _height = height; }

        public float Height { get { return _height; } set { this = new SizeF(_width, value); } }

        [Browsable(false)]
        public bool IsEmpty { get { return this == Empty; } }

        public float Width { get { return _width; } set { this = new SizeF(value, _height); } }

        public static SizeF Add(SizeF sz1, SizeF sz2)
        {
            return sz1 + sz2;
        }

        public override bool Equals(Object obj)
        {
            if (obj is SizeF)
                return (SizeF)obj == this;

            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static SizeF Subtract(SizeF sz1, SizeF sz2)
        {
            return sz1 - sz2;
        }

        public PointF ToPointF()
        {
            return new PointF(_width, _height);
        }

        public Size ToSize()
        {
            return new Size((int)_width, (int)_height);
        }

        public override string ToString()
        {
            return $"({_width},{_height})";
        }

        public static SizeF operator +(SizeF sz1, SizeF sz2)
        {
            return new SizeF(sz1.Width + sz2.Width, sz1.Height + sz2.Height);
        }

        public static bool operator ==(SizeF sz1, SizeF sz2)
        {
            return sz1.Width == sz2.Width && sz1.Height == sz2.Height;
        }

        public static explicit operator PointF(SizeF size)
        {
            return new PointF(size.Width, size.Height);
        }

        public static bool operator !=(SizeF sz1, SizeF sz2)
        {
            return sz1.Width != sz2.Width || sz1.Height != sz2.Height;
        }

        public static SizeF operator -(SizeF sz1, SizeF sz2)
        {
            return new SizeF(sz1.Width - sz2.Width, sz1.Height - sz2.Height);
        }

        public static readonly SizeF Empty = new SizeF(0, 0);
    }
}
