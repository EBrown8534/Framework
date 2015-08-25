using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Evbpc.Framework.Physics
{
    public struct Vector2 : IVector2
    {
        private readonly int _x;
        private readonly int _y;

        public Vector2(int x, int y)
        {
            _x = x;
            _y = y;
        }

        [Browsable(false)]
        public bool IsEmpty { get { return this == Empty; } }

        public int X { get { return _x; } }
        public int Y { get { return _y; } }
        public double R { get { return Math.Sqrt((double)_x * _x + (double)_y * _y); } }
        public double Theta { get { return Math.Atan2(_y, _x); } }

        public static Vector2 Add(Vector2 v1, Vector2 v2)
        {
            return v1 + v2;
        }

        public static Vector2 Ceiling(Vector2F value)
        {
            return new Vector2((int)Math.Ceiling(value.X), (int)Math.Ceiling(value.Y));
        }

        public override bool Equals(object obj)
        {
            if (obj is Vector2)
            {
                return (Vector2)obj == this;
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

        public static Vector2 Round(Vector2F value)
        {
            return new Vector2((int)Math.Round(value.X), (int)Math.Round(value.Y));
        }

        public static Vector2 Subtract(Vector2 v1, Vector2 v2)
        {
            return v1 - v2;
        }

        public override string ToString()
        {
            return string.Format("({0},{1})", _x, _y);
        }

        public static Vector2 Truncate(Vector2F value)
        {
            return new Vector2((int)(value.X), (int)(value.Y));
        }

        public static Vector2 FromRTheta(double r, double theta)
        {
            return new Vector2((int)(r * Math.Cos(theta)), (int)(r * Math.Sin(theta)));
        }

        public static Vector2 operator +(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.X + v2.X, v1.Y + v2.Y);
        }

        public static bool operator ==(Vector2 left, Vector2 right)
        {
            return left.X == right.X && left.Y == right.Y;
        }

        public static implicit operator Vector2F(Vector2 p)
        {
            return new Vector2F(p.X, p.Y);
        }

        public static bool operator !=(Vector2 left, Vector2 right)
        {
            return left.X != right.X || left.Y != right.Y;
        }

        public static Vector2 operator -(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.X - v2.X, v1.Y - v2.Y);
        }

        public static readonly Vector2 Empty = new Vector2(0, 0);
    }
}
