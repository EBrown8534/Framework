using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Evbpc.Framework.Physics
{
    public struct Vector2
    {
        private int _x;
        private int _y;

        public Vector2(int x, int y) { _x = x; _y = y; }

        [BrowsableAttribute(false)]
        public bool IsEmpty { get { return this == Empty; } }

        public int X { get { return _x; } set { _x = value; } }
        public int Y { get { return _y; } set { _y = value; } }
        public double R { get { return Math.Sqrt((double)_x * _x + (double)_y * _y); } }
        public double Theta { get { return Math.Atan2((double)_y, (double)_x); } }

        public static Vector2 Add(Vector2 v1, Vector2 v2) { return v1 + v2; }
        public static Vector2 Ceiling(Vector2F value) { return new Vector2((int)Math.Ceiling(value.X), (int)Math.Ceiling(value.Y)); }
        public override bool Equals(Object obj) { if (obj is Vector2) { return (Vector2)obj == this; } else { return false; } }
        public override int GetHashCode() { return base.GetHashCode(); }
        public void Offset(Vector2 p) { _x += p.X; _y += p.Y; }
        public void Offset(int dx, int dy) { _x += dx; _y += dy; }
        public static Vector2 Round(Vector2F value) { return new Vector2((int)Math.Round(value.X), (int)Math.Round(value.Y)); }
        public static Vector2 Subtract(Vector2 v1, Vector2 v2) { return v1 - v2; }
        public override string ToString() { return "(" + _x + "," + _y + ")"; }
        public static Vector2 Truncate(Vector2F value) { return new Vector2((int)(value.X), (int)(value.Y)); }
        public static Vector2 FromRTheta(double r, double theta) { return new Vector2((int)(r * Math.Cos(theta)), (int)(r * Math.Sin(theta))); }

        public static Vector2 operator +(Vector2 v1, Vector2 v2) { return new Vector2(v1._x + v2._x, v1._y + v2._y); }
        public static bool operator ==(Vector2 left, Vector2 right) { return left.X == right.X && left.Y == right.Y; }
        //public static explicit operator Size(Point p) { return new Size(p.X, p.Y); }
        public static implicit operator Vector2F(Vector2 p) { return new Vector2F(p._x, p._y); }
        public static bool operator !=(Vector2 left, Vector2 right) { return left._x != right._x || left._y != right._y; }
        public static Vector2 operator -(Vector2 v1, Vector2 v2) { return new Vector2(v1._x - v2._x, v1._y - v2._y); }

        public static readonly Vector2 Empty = new Vector2(0, 0);
    }
}
