using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Evbpc.Framework.Physics
{
    /// <summary>
    /// Represents a value with an X and Y coordinate, that represents a direction and magnitude of a system.
    /// </summary>
    public struct Vector2F : IVector2
    {
        private readonly float _x;
        private readonly float _y;

        /// <summary>
        /// Creates a new instance of <see cref="Vector2F"/> with the specified <see cref="X"/> and <see cref="Y"/> values.
        /// </summary>
        /// <param name="x">The <see cref="X"/> value of the <see cref="Vector2F"/>.</param>
        /// <param name="y">The <see cref="Y"/> value of the <see cref="Vector2F"/>.</param>
        public Vector2F(float x, float y)
        {
            _x = x;
            _y = y;
        }

        /// <summary>
        /// Inherited from <see cref="IVector2"/>. Gets a boolean value indicating whether or not the current <see cref="Vector2F"/> is empty or not.
        /// </summary>
        [Browsable(false)]
        public bool IsEmpty { get { return this == Empty; } }

        /// <summary>
        /// Gets the X component of the <see cref="Vector2F"/>.
        /// </summary>
        public float X { get { return _x; } }
        /// <summary>
        /// Gets the Y component of the <see cref="Vector2F"/>.
        /// </summary>
        public float Y { get { return _y; } }
        /// <summary>
        /// Inherited from <see cref="IVector2"/>. Gets the magnitude of the <see cref="Vector2F"/> from the origin.
        /// </summary>
        public double R { get { return Math.Sqrt((double)_x * _x + (double)_y * _y); } }
        /// <summary>
        /// Inherited from <see cref="IVector2"/>. Gets the direction of the <see cref="Vector2F"/>.
        /// </summary>
        public double Theta { get { return Math.Atan2(_y, _x); } }

        /// <summary>
        /// Adds a <see cref="Vector2F"/> and <see cref="Vector2"/> together and returns the result.
        /// </summary>
        /// <param name="v1">The <see cref="Vector2F"/> to be added.</param>
        /// <param name="v2">The <see cref="Vector2"/> to be added.</param>
        /// <returns>A <see cref="Vector2F"/> whose elements are the sum of the <see cref="Vector2F"/> and <see cref="Vector2"/> objects.</returns>
        public static Vector2F Add(Vector2F v1, Vector2 v2)
        {
            return v1 + v2;
        }

        /// <summary>
        /// Adds two <see cref="Vector2F"/> objects together and returns the result.
        /// </summary>
        /// <param name="v1">The first <see cref="Vector2F"/> to be added.</param>
        /// <param name="v2">The second <see cref="Vector2F"/> to be added.</param>
        /// <returns>A <see cref="Vector2F"/> whose elements are the sume of the two input <see cref="Vector2F"/> objects.</returns>
        public static Vector2F Add(Vector2F v1, Vector2F v2)
        {
            return v1 + v2;
        }

        /// <summary>
        /// Determines if an arbitrary <code>object</code> is equal to the current <see cref="Vector2F"/>.
        /// </summary>
        /// <param name="obj">The arbitrary <code>object</code> to compare.</param>
        /// <returns>True if the <code>obj</code> is equivalent to the current <see cref="Vector2F"/>.</returns>
        public override bool Equals(object obj)
        {
            if (obj is Vector2F)
            {
                return (Vector2F)obj == this;
            }

            return false;
        }

        /// <summary>
        /// Gets a hash code to represent the current <see cref="Vector2F"/>.
        /// </summary>
        /// <returns>An integer value representing the current <see cref="Vector2F"/>.</returns>
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

        /// <summary>
        /// Subtracts a <see cref="Vector2"/> from a <see cref="Vector2F"/> and returns the result.
        /// </summary>
        /// <param name="v1">The <see cref="Vector2F"/> to be subtracted from.</param>
        /// <param name="v2">The <see cref="Vector2"/> to subtract.</param>
        /// <returns>A new <see cref="Vector2F"/> which is the <see cref="Vector2F"/> subtracted by the <see cref="Vector2"/>.</returns>
        public static Vector2F Subtract(Vector2F v1, Vector2 v2)
        {
            return v1 - v2;
        }

        /// <summary>
        /// Subtracts a <see cref="Vector2F"/> from another <see cref="Vector2F"/> and returns the result.
        /// </summary>
        /// <param name="v1">The <see cref="Vector2F"/> to be subtracted from.</param>
        /// <param name="v2">The <see cref="Vector2F"/> to subtract.</param>
        /// <returns>A new <see cref="Vector2F"/> which is the first <see cref="Vector2F"/> subtracted by the second <see cref="Vector2F"/>.</returns>
        public static Vector2F Subtract(Vector2F v1, Vector2F v2)
        {
            return v1 - v2;
        }

        /// <summary>
        /// Returns the string representation of the current <see cref="Vector2F"/>.
        /// </summary>
        /// <returns>A string representing the values of the <see cref="X"/> and <see cref="Y"/> properties of the current <see cref="Vector2F"/>.</returns>
        public override string ToString()
        {
            return string.Format("({0},{1})", _x, _y);
        }

        /// <summary>
        /// Creates a new <see cref="Vector2F"/> from the specified <see cref="R"/> and <see cref="Theta"/>.
        /// </summary>
        /// <param name="r">The <see cref="R"/> of the <see cref="Vector2F"/>.</param>
        /// <param name="theta">The <see cref="Theta"/> of the <see cref="Vector2F"/>.</param>
        /// <returns>A new instance of <see cref="Vector2F"/> from the specified <see cref="R"/> and <see cref="Theta"/>.</returns>
        public static Vector2F FromRTheta(double r, double theta)
        {
            return new Vector2F((float)(r * Math.Cos(theta)), (float)(r * Math.Sin(theta)));
        }

        /// <summary>
        /// Returns a new <see cref="Vector2F"/> which is the inverted variant of the current <see cref="Vector2F"/>.
        /// </summary>
        /// <returns>A new <see cref="Vector2F"/>.</returns>
        public Vector2F Invert()
        {
            return new Vector2F(0 - _x, 0 - _y);
        }

        /// <summary>
        /// Adds a <see cref="Vector2F"/> and <see cref="Vector2"/> together and returns the result.
        /// </summary>
        /// <param name="v1">The <see cref="Vector2F"/> to add.</param>
        /// <param name="v2">The <see cref="Vector2"/> to add.</param>
        /// <returns>A new <see cref="Vector2F"/> which is the addition of all components of the <see cref="Vector2F"/> and <see cref="Vector2"/>.</returns>
        public static Vector2F operator +(Vector2F v1, Vector2 v2)
        {
            return new Vector2F(v1.X + v2.X, v1.Y + v2.Y);
        }
        
        /// <summary>
        /// Adds two <see cref="Vector2F"/> objects together and returns the result.
        /// </summary>
        /// <param name="v1">The first <see cref="Vector2F"/> to be added.</param>
        /// <param name="v2">The second <see cref="Vector2F"/> to be added.</param>
        /// <returns>A <see cref="Vector2F"/> whose elements are the sume of the two input <see cref="Vector2F"/> objects.</returns>
        public static Vector2F operator +(Vector2F v1, Vector2F v2)
        {
            return new Vector2F(v1.X + v2.X, v1.Y + v2.Y);
        }

        /// <summary>
        /// Determines if two <see cref="Vector2F"/> objects are equivalent.
        /// </summary>
        /// <param name="left">The first <see cref="Vector2F"/> to check.</param>
        /// <param name="right">The second <see cref="Vector2F"/> to check.</param>
        /// <returns>True if the <see cref="X"/> and <see cref="Y"/> components of the two <see cref="Vector2F"/> are equivalent, False otherwise.</returns>
        public static bool operator ==(Vector2F left, Vector2F right)
        {
            return left.X == right.X && left.Y == right.Y;
        }

        /// <summary>
        /// Determines if two <see cref="Vector2F"/> objects are not equivalent.
        /// </summary>
        /// <param name="left">The first <see cref="Vector2F"/> to check.</param>
        /// <param name="right">The second <see cref="Vector2F"/> to check.</param>
        /// <returns>False if the <see cref="X"/> and <see cref="Y"/> components of the two <see cref="Vector2F"/> are equivalent, True otherwise.</returns>
        public static bool operator !=(Vector2F left, Vector2F right)
        {
            return left.X != right.X || left.Y != right.Y;
        }

        /// <summary>
        /// Subtracts a <see cref="Vector2"/> from a <see cref="Vector2F"/> and returns the result.
        /// </summary>
        /// <param name="v1">The <see cref="Vector2F"/> to be subtracted from.</param>
        /// <param name="v2">The <see cref="Vector2"/> to subtract.</param>
        /// <returns>A new <see cref="Vector2F"/> which is the <see cref="Vector2F"/> subtracted by the <see cref="Vector2"/>.</returns>
        public static Vector2F operator -(Vector2F v1, Vector2 v2)
        {
            return new Vector2F(v1.X - v2.X, v1.Y - v2.Y);
        }

        /// <summary>
        /// Subtracts a <see cref="Vector2F"/> from another <see cref="Vector2F"/> and returns the result.
        /// </summary>
        /// <param name="v1">The <see cref="Vector2F"/> to be subtracted from.</param>
        /// <param name="v2">The <see cref="Vector2F"/> to subtract.</param>
        /// <returns>A new <see cref="Vector2F"/> which is the first <see cref="Vector2F"/> subtracted by the second <see cref="Vector2F"/>.</returns>
        public static Vector2F operator -(Vector2F v1, Vector2F v2)
        {
            return new Vector2F(v1.X - v2.X, v1.Y - v2.Y);
        }

        /// <summary>
        /// Returns an empty instance of <see cref="Vector2F"/>.
        /// </summary>
        public static readonly Vector2F Empty = new Vector2F(0, 0);
    }
}
