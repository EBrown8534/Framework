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
    public struct Vector2 : IVector2
    {
        /// <summary>
        /// Creates a new instance of <see cref="Vector2"/> with the specified <see cref="X"/> and <see cref="Y"/> values.
        /// </summary>
        /// <param name="x">The <see cref="X"/> value of the <see cref="Vector2"/>.</param>
        /// <param name="y">The <see cref="Y"/> value of the <see cref="Vector2"/>.</param>
        public Vector2(int x, int y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Inherited from <see cref="IVector2"/>. Gets a boolean value indicating whether or not the current <see cref="Vector2"/> is empty or not.
        /// </summary>
        [Browsable(false)]
        public bool IsEmpty => this == Empty;

        /// <summary>
        /// Gets the X component of the <see cref="Vector2"/>.
        /// </summary>
        public int X { get; }
        /// <summary>
        /// Gets the Y component of the <see cref="Vector2"/>.
        /// </summary>
        public int Y { get; }
        /// <summary>
        /// Inherited from <see cref="IVector2"/>. Gets the magnitude of the <see cref="Vector2"/> from the origin.
        /// </summary>
        public double R => Math.Sqrt((double)X * X + (double)Y * Y);
        /// <summary>
        /// Inherited from <see cref="IVector2"/>. Gets the direction of the <see cref="Vector2"/>.
        /// </summary>
        public double Theta => Math.Atan2(Y, X); 

        /// <summary>
        /// Adds two <see cref="Vector2"/> objects together and returns the result.
        /// </summary>
        /// <param name="v1">The first <see cref="Vector2"/> to be added.</param>
        /// <param name="v2">The second <see cref="Vector2"/> to be added.</param>
        /// <returns>A <see cref="Vector2"/> whose elements are the sume of the two input <see cref="Vector2"/> objects.</returns>
        public static Vector2 Add(Vector2 v1, Vector2 v2) => v1 + v2;

        /// <summary>
        /// Creates a new <see cref="Vector2"/> from a <see cref="Vector2F"/> while rounding all floating-point values up to the nearest whole number.
        /// </summary>
        /// <param name="value">The <see cref="Vector2F"/> whose values should be rounded.</param>
        /// <returns>A new <see cref="Vector2"/> with rounded values from the <see cref="Vector2F"/>.</returns>
        public static Vector2 Ceiling(Vector2F value) => new Vector2((int)Math.Ceiling(value.X), (int)Math.Ceiling(value.Y));

        /// <summary>
        /// Determines if an arbitrary <code>object</code> is equal to the current <see cref="Vector2"/>.
        /// </summary>
        /// <param name="obj">The arbitrary <code>object</code> to compare.</param>
        /// <returns>True if the <code>obj</code> is equivalent to the current <see cref="Vector2"/>.</returns>
        public override bool Equals(object obj) => obj is Vector2 && (Vector2)obj == this;

        /// <summary>
        /// Gets a hash code to represent the current <see cref="Vector2"/>.
        /// </summary>
        /// <returns>An integer value representing the current <see cref="Vector2"/>.</returns>
        public override int GetHashCode()
        {
            int hash = 17;

            unchecked
            {
                hash = hash * 23 + X.GetHashCode();
                hash = hash * 23 + Y.GetHashCode();
            }

            return hash;
        }

        /// <summary>
        /// Creates a new <see cref="Vector2"/> from a <see cref="Vector2F"/> by rounding all values to the nearest whole number.
        /// </summary>
        /// <param name="value">The <see cref="Vector2F"/> to round.</param>
        /// <returns>A new <see cref="Vector2"/> with rounded values from the <see cref="Vector2F"/>.</returns>
        public static Vector2 Round(Vector2F value) => new Vector2((int)Math.Round(value.X), (int)Math.Round(value.Y));

        /// <summary>
        /// Subtracts a <see cref="Vector2"/> from another <see cref="Vector2"/> and returns the result.
        /// </summary>
        /// <param name="v1">The <see cref="Vector2"/> to be subtracted from.</param>
        /// <param name="v2">The <see cref="Vector2"/> to subtract.</param>
        /// <returns>A new <see cref="Vector2"/> which is the first <see cref="Vector2"/> subtracted by the second <see cref="Vector2"/>.</returns>
        public static Vector2 Subtract(Vector2 v1, Vector2 v2) => v1 - v2;

        /// <summary>
        /// Returns the string representation of the current <see cref="Vector2"/>.
        /// </summary>
        /// <returns>A string representing the values of the <see cref="X"/> and <see cref="Y"/> properties of the current <see cref="Vector2"/>.</returns>
        public override string ToString() => $"({X},{Y})";

        /// <summary>
        /// Creates a new <see cref="Vector2"/> from a <see cref="Vector2F"/> by truncating all values to the nearest whole number.
        /// </summary>
        /// <param name="value">The <see cref="Vector2F"/> to truncate.</param>
        /// <returns>A new <see cref="Vector2"/> with truncated values from the <see cref="Vector2F"/>.</returns>
        public static Vector2 Truncate(Vector2F value) => new Vector2((int)(value.X), (int)(value.Y));

        /// <summary>
        /// Creates a new <see cref="Vector2"/> from the specified <see cref="R"/> and <see cref="Theta"/>.
        /// </summary>
        /// <param name="r">The <see cref="R"/> of the <see cref="Vector2"/>.</param>
        /// <param name="theta">The <see cref="Theta"/> of the <see cref="Vector2"/>.</param>
        /// <returns>A new instance of <see cref="Vector2"/> from the specified <see cref="R"/> and <see cref="Theta"/>.</returns>
        public static Vector2 FromRTheta(double r, double theta) => new Vector2((int)(r * Math.Cos(theta)), (int)(r * Math.Sin(theta)));

        /// <summary>
        /// Adds two <see cref="Vector2"/> objects together and returns the result.
        /// </summary>
        /// <param name="v1">The first <see cref="Vector2"/> to be added.</param>
        /// <param name="v2">The second <see cref="Vector2"/> to be added.</param>
        /// <returns>A <see cref="Vector2"/> whose elements are the sume of the two input <see cref="Vector2"/> objects.</returns>
        public static Vector2 operator +(Vector2 v1, Vector2 v2) => new Vector2(v1.X + v2.X, v1.Y + v2.Y);

        /// <summary>
        /// Determines if two <see cref="Vector2"/> objects are equivalent.
        /// </summary>
        /// <param name="left">The first <see cref="Vector2"/> to check.</param>
        /// <param name="right">The second <see cref="Vector2"/> to check.</param>
        /// <returns>True if the <see cref="X"/> and <see cref="Y"/> components of the two <see cref="Vector2"/> are equivalent, False otherwise.</returns>
        public static bool operator ==(Vector2 left, Vector2 right) => left.X == right.X && left.Y == right.Y;

        /// <summary>
        /// Implicitly converts a <see cref="Vector2"/> to a <see cref="Vector2F"/>.
        /// </summary>
        /// <param name="v">The <see cref="Vector2"/> to convert.</param>
        public static implicit operator Vector2F(Vector2 v) => new Vector2F(v.X, v.Y);

        /// <summary>
        /// Determines if two <see cref="Vector2"/> objects are not equivalent.
        /// </summary>
        /// <param name="left">The first <see cref="Vector2"/> to check.</param>
        /// <param name="right">The second <see cref="Vector2"/> to check.</param>
        /// <returns>False if the <see cref="X"/> and <see cref="Y"/> components of the two <see cref="Vector2"/> are equivalent, True otherwise.</returns>
        public static bool operator !=(Vector2 left, Vector2 right) => left.X != right.X || left.Y != right.Y;

        /// <summary>
        /// Subtracts a <see cref="Vector2"/> from another <see cref="Vector2"/> and returns the result.
        /// </summary>
        /// <param name="v1">The <see cref="Vector2"/> to be subtracted from.</param>
        /// <param name="v2">The <see cref="Vector2"/> to subtract.</param>
        /// <returns>A new <see cref="Vector2"/> which is the first <see cref="Vector2"/> subtracted by the second <see cref="Vector2"/>.</returns>
        public static Vector2 operator -(Vector2 v1, Vector2 v2) => new Vector2(v1.X - v2.X, v1.Y - v2.Y);

        /// <summary>
        /// Returns an empty instance of <see cref="Vector2"/>.
        /// </summary>
        public static readonly Vector2 Empty = new Vector2(0, 0);
    }
}
