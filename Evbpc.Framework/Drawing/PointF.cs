using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Evbpc.Framework.Drawing
{
    [SerializableAttribute]
    [StructLayout(LayoutKind.Explicit)]
    public struct PointF
    {
        [FieldOffset(0)]
        private ulong _PackedValue;
        [FieldOffset(0)]
        private float _X;
        [FieldOffset(4)]
        private float _Y;

        public PointF(float x, float y)
            : this()
        {
            _X = x;
            _Y = y;
        }

        [BrowsableAttribute(false)]
        public bool IsEmpty { get { return this == Empty; } }

        public float X { get { return _X; } set { _X = value; } }
        public float Y { get { return _Y; } set { _Y = value; } }

        public static PointF Add(PointF pt, Size sz) { return pt + sz; }
        public static PointF Add(PointF pt, SizeF sz) { return pt + sz; }
        public override bool Equals(Object obj) { if (obj.GetType() == typeof(PointF)) { return (PointF)obj == this; } else { return false; } }
        public override int GetHashCode() { return base.GetHashCode(); }
        public static PointF Subtract(PointF pt, Size sz) { return pt - sz; }
        public static PointF Subtract(PointF pt, SizeF sz) { return pt - sz; }
        public override string ToString() { return "(" + _X + "," + _Y + ")"; }

        public static PointF operator +(PointF pt, Size sz) { return new PointF(pt.X + sz.Width, pt.Y + sz.Height); }
        public static PointF operator +(PointF pt, SizeF sz) { return new PointF(pt.X + sz.Width, pt.Y + sz.Height); }
        public static bool operator ==(PointF left, PointF right) { return left.X == right.X && left.Y == right.Y; }
        public static bool operator !=(PointF left, PointF right) { return left.X != right.X || left.Y != right.Y; }
        public static PointF operator -(PointF pt, Size sz) { return new PointF(pt.X - sz.Width, pt.Y - sz.Height); }
        public static PointF operator -(PointF pt, SizeF sz) { return new PointF(pt.X - sz.Width, pt.Y - sz.Height); }

        public static readonly PointF Empty = new PointF(0, 0);
    }
}
