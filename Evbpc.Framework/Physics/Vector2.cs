using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Evbpc.Framework.Physics
{
    public struct Vector2
    {
        private int _X;
        private int _Y;

        public Vector2(int x, int y) { _X = x; _Y = y; }

        [BrowsableAttribute(false)]
        public bool IsEmpty { get { return this == Empty; } }

        public int X { get { return _X; } set { _X = value; } }
        public int Y { get { return _Y; } set { _Y = value; } }
        public double R { get { return Math.Sqrt((double)_X * _X + (double)_Y * _Y); } }
        public double Theta { get { return Math.Atan2((double)_Y, (double)_X); } }

        public static Vector2 Add(Vector2 v1, Vector2 v2) { return v1 + v2; }
        public static Vector2 Ceiling(Vector2F value) { return new Vector2((int)Math.Ceiling(value.X), (int)Math.Ceiling(value.Y)); }
        public override bool Equals(Object obj) { if (obj is Vector2) { return (Vector2)obj == this; } else { return false; } }
        public override int GetHashCode() { return base.GetHashCode(); }
        public void Offset(Vector2 p) { _X += p.X; _Y += p.Y; }
        public void Offset(int dx, int dy) { _X += dx; _Y += dy; }
        public static Vector2 Round(Vector2F value) { return new Vector2((int)Math.Round(value.X), (int)Math.Round(value.Y)); }
        public static Vector2 Subtract(Vector2 v1, Vector2 v2) { return v1 - v2; }
        public override string ToString() { return "(" + _X + "," + _Y + ")"; }
        public static Vector2 Truncate(Vector2F value) { return new Vector2((int)(value.X), (int)(value.Y)); }
        public static Vector2 FromRTheta(double r, double theta) { return new Vector2((int)(r * Math.Cos(theta)), (int)(r * Math.Sin(theta))); }

        public static Vector2 operator +(Vector2 v1, Vector2 v2) { return new Vector2(v1._X + v2._X, v1._Y + v2._Y); }
        public static bool operator ==(Vector2 left, Vector2 right) { return left.X == right.X && left.Y == right.Y; }
        //public static explicit operator Size(Point p) { return new Size(p.X, p.Y); }
        public static implicit operator Vector2F(Vector2 p) { return new Vector2F(p._X, p._Y); }
        public static bool operator !=(Vector2 left, Vector2 right) { return left._X != right._X || left._Y != right._Y; }
        public static Vector2 operator -(Vector2 v1, Vector2 v2) { return new Vector2(v1._X - v2._X, v1._Y - v2._Y); }

        public static readonly Vector2 Empty = new Vector2(0, 0);
    }
}
