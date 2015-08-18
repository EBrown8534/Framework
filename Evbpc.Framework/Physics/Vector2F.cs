using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Evbpc.Framework.Physics
{
    public struct Vector2F
    {
        private float _X;
        private float _Y;

        public Vector2F(float x, float y) { _X = x; _Y = y; }
        
        [BrowsableAttribute(false)]
        public bool IsEmpty { get { return this == Empty; } }

        public float X { get { return _X; } set { _X = value; } }
        public float Y { get { return _Y; } set { _Y = value; } }
        public double R { get { return Math.Sqrt((double)_X * _X + (double)_Y * _Y); } }
        public double Theta { get { return Math.Atan2((double)_Y, (double)_X); } }
        
        public static Vector2F Add(Vector2F v1, Vector2 v2) { return v1 + v2; }
        public static Vector2F Add(Vector2F v1, Vector2F v2) { return v1 + v2; }
        public override bool Equals(Object obj) { if (obj is Vector2F) { return (Vector2F)obj == this; } else { return false; } }
        public override int GetHashCode() { return base.GetHashCode(); }
        public static Vector2F Subtract(Vector2F v1, Vector2 v2) { return v1 - v2; }
        public static Vector2F Subtract(Vector2F v1, Vector2F v2) { return v1 - v2; }
        public override string ToString() { return "(" + _X + "," + _Y + ")"; }
        public static Vector2F FromRTheta(double r, double theta) { return new Vector2F((float)(r * Math.Cos(theta)), (float)(r * Math.Sin(theta))); }
        public Vector2F Invert() { return new Vector2F(0 - _X, 0 - _Y); }

        public static Vector2F operator +(Vector2F v1, Vector2 v2) { return new Vector2F(v1._X + v2.X, v1.Y + v2.Y); }
        public static Vector2F operator +(Vector2F v1, Vector2F v2) { return new Vector2F(v1._X + v2._X, v1.Y + v2._Y); }
        public static bool operator ==(Vector2F left, Vector2F right) { return left.X == right.X && left.Y == right.Y; }
        public static bool operator !=(Vector2F left, Vector2F right) { return left.X != right.X || left.Y != right.Y; }
        public static Vector2F operator -(Vector2F v1, Vector2 v2) { return new Vector2F(v1._X - v2.X, v1._Y - v2.Y); }
        public static Vector2F operator -(Vector2F v1, Vector2F v2) { return new Vector2F(v1._X - v2._X, v1._Y - v2._Y); }

        public static readonly Vector2F Empty = new Vector2F(0, 0);
    }
}
