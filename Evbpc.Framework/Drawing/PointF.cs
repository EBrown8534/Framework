using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Evbpc.Framework.Drawing
{
    [Serializable]
    [StructLayout(LayoutKind.Explicit)]
    public struct PointF
    {
        [FieldOffset(0)]
        private ulong _packedValue;
        [FieldOffset(0)]
        private float _x;
        [FieldOffset(4)]
        private float _y;

        public PointF(float x, float y)
            : this()
        {
            _x = x;
            _y = y;
        }

        [Browsable(false)]
        public bool IsEmpty => this == Empty;

        public float X => _x;
        public float Y => _y;

        public static PointF Add(PointF pt, Size sz) => pt + sz;

        public static PointF Add(PointF pt, SizeF sz) => pt + sz;

        public override bool Equals(Object obj) => obj is PointF && (PointF)obj == this;

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

        public static PointF Subtract(PointF pt, Size sz)=>pt - sz;

        public static PointF Subtract(PointF pt, SizeF sz) => pt - sz;

        public override string ToString() => $"({_x},{_y})";

        public static PointF operator +(PointF pt, Size sz) => new PointF(pt.X + sz.Width, pt.Y + sz.Height);

        public static PointF operator +(PointF pt, SizeF sz) => new PointF(pt.X + sz.Width, pt.Y + sz.Height);

        public static bool operator ==(PointF left, PointF right) => left.X == right.X && left.Y == right.Y;

        public static bool operator !=(PointF left, PointF right) => left.X != right.X || left.Y != right.Y;

        public static PointF operator -(PointF pt, Size sz) => new PointF(pt.X - sz.Width, pt.Y - sz.Height);

        public static PointF operator -(PointF pt, SizeF sz) => new PointF(pt.X - sz.Width, pt.Y - sz.Height);

        public static readonly PointF Empty = new PointF(0, 0);
    }
}
