using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Evbpc.Framework.Physics
{
    public struct Vector2F : IVector2
    {
        private readonly float _x;
        private readonly float _y;

        public Vector2F(float x, float y)
        {
            _x = x;
            _y = y;
        }

        [Browsable(false)]
        public bool IsEmpty { get { return this == Empty; } }

        public float X { get { return _x; } }
        public float Y { get { return _y; } }
        public double R { get { return Math.Sqrt((double)_x * _x + (double)_y * _y); } }
        public double Theta { get { return Math.Atan2(_y, _x); } }

        public static Vector2F Add(Vector2F v1, Vector2 v2)
        {
            return v1 + v2;
        }

        public static Vector2F Add(Vector2F v1, Vector2F v2)
        {
            return v1 + v2;
        }

        public override bool Equals(object obj)
        {
            if (obj is Vector2F)
            {
                return (Vector2F)obj == this;
            }

            return false;
        }

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

        public static Vector2F Subtract(Vector2F v1, Vector2 v2)
        {
            return v1 - v2;
        }

        public static Vector2F Subtract(Vector2F v1, Vector2F v2)
        {
            return v1 - v2;
        }

        public override string ToString()
        {
            return string.Format("({0},{1})", _x, _y);
        }

        public static Vector2F FromRTheta(double r, double theta)
        {
            return new Vector2F((float)(r * Math.Cos(theta)), (float)(r * Math.Sin(theta)));
        }

        public Vector2F Invert()
        {
            return new Vector2F(0 - _x, 0 - _y);
        }

        public static Vector2F operator +(Vector2F v1, Vector2 v2)
        {
            return new Vector2F(v1.X + v2.X, v1.Y + v2.Y);
        }

        public static Vector2F operator +(Vector2F v1, Vector2F v2)
        {
            return new Vector2F(v1.X + v2.X, v1.Y + v2.Y);
        }

        public static bool operator ==(Vector2F left, Vector2F right)
        {
            return left.X == right.X && left.Y == right.Y;
        }

        public static bool operator !=(Vector2F left, Vector2F right)
        {
            return left.X != right.X || left.Y != right.Y;
        }

        public static Vector2F operator -(Vector2F v1, Vector2 v2)
        {
            return new Vector2F(v1.X - v2.X, v1.Y - v2.Y);
        }

        public static Vector2F operator -(Vector2F v1, Vector2F v2)
        {
            return new Vector2F(v1.X - v2.X, v1.Y - v2.Y);
        }

        public static readonly Vector2F Empty = new Vector2F(0, 0);
    }
}
