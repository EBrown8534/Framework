using Evbpc.Framework.Utilities.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace Evbpc.Framework.Drawing
{
    /// <summary>
    /// A structure to represent a generic set of Red, Green, Blue and Alpha to represent the shade to paint an object.
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct Color : ISerializableByteArray
    {
        [FieldOffset(0)]
        private uint _packedValue;
        [FieldOffset(0)]
        private byte _a;
        [FieldOffset(1)]
        private byte _r;
        [FieldOffset(2)]
        private byte _g;
        [FieldOffset(3)]
        private byte _b;

        /// <summary>
        /// Gets or sets the Alpha component of the <see cref="Color"/>.
        /// </summary>
        public byte A { get { return _a; } set { _a = value; } }

        /// <summary>
        /// Gets or sets the Red component of the <see cref="Color"/>.
        /// </summary>
        public byte R { get { return _r; } set { _r = value; } }

        /// <summary>
        /// Gets or sets the Green component of the <see cref="Color"/>.
        /// </summary>
        public byte G { get { return _g; } set { _g = value; } }

        /// <summary>
        /// Gets or sets the Blue component of the <see cref="Color"/>.
        /// </summary>
        public byte B { get { return _b; } set { _b = value; } }

        /// <summary>
        /// Creates an instance of a <see cref="Color"/>.
        /// </summary>
        /// <param name="a">The alpha <c>byte</c> component.</param>
        /// <param name="r">The red <c>byte</c> component.</param>
        /// <param name="g">The green <c>byte</c> component.</param>
        /// <param name="b">The blue <c>byte</c> component.</param>
        public Color(byte r, byte g, byte b, byte a)
            : this()
        {
            R = r;
            G = g;
            B = b;
            A = a;
        }

        /// <summary>
        /// Creates an instance of a <see cref="Color"/> with a default alpha of 255.
        /// </summary>
        /// <param name="r">The red <c>byte</c> component.</param>
        /// <param name="g">The green <c>byte</c> component.</param>
        /// <param name="b">The blue <c>byte</c> component.</param>
        public Color(byte r, byte g, byte b)
            : this(r, g, b, 0xFF)
        {
        }

        /// <summary>
        /// Creates an instance of a <see cref="Color"/> from a packed value.
        /// </summary>
        /// <param name="packedValue">The original packed value of the <see cref="Color"/>.</param>
        public Color(uint packedValue)
            : this()
        {
            _packedValue = packedValue;
        }

        /// <summary>
        /// Returns the packed <c>uint</c> for storage.
        /// </summary>
        /// <returns>A <c>uint</c> representing this <see cref="Color"/> instance.</returns>
        public uint GetPackedValue()
        {
            return _packedValue;
        }

        /// <summary>
        /// Determines whether two <see cref="Color"/> objects have the same value.
        /// </summary>
        /// <param name="a">The first <see cref="Color"/> object.</param>
        /// <param name="b">The second <see cref="Color"/> object.</param>
        /// <returns>True if the objects have the same values, false otherwise.</returns>
        public static bool operator ==(Color a, Color b)
        {
            return a._packedValue == b._packedValue;
        }

        /// <summary>
        /// Determines whether two <see cref="Color"/> objects do not have the same value.
        /// </summary>
        /// <param name="a">The first <see cref="Color"/> object.</param>
        /// <param name="b">The second <see cref="Color"/> object.</param>
        /// <returns>True if the objects do not have the same values, false otherwise.</returns>
        public static bool operator !=(Color a, Color b)
        {
            return a._packedValue != b._packedValue;
        }

        /// <summary>
        /// Determines whether an object is a <see cref="Color"/> and is equal to the current <see cref="Color"/> object.
        /// </summary>
        /// <param name="obj">The object to compare.</param>
        /// <returns>True if the object is a <see cref="Color"/> object and has the same value as the current <see cref="Color"/> object.</returns>
        public override bool Equals(object obj)
        {
            return obj is Color && this == (Color)obj;
        }

        /// <summary>
        /// Gets the hash code for the current <see cref="Color"/> object.
        /// </summary>
        /// <returns>The hash code that represents the current <see cref="Color"/> object.</returns>
        public override int GetHashCode()
        {
            return (int)_packedValue;
        }

        /// <summary>
        /// Implicitly materializes a <see cref="Color.Preset"/> to a <see cref="Color"/>.
        /// </summary>
        /// <param name="preset">The <see cref="Color.Preset"/> to convert.</param>
        /// <returns>The <see cref="Color.Presets"/> value that corrosponds to the <see cref="Color.Preset"/>.</returns>
        /// <remarks>
        /// This method is equivalent to calling <code>Color.Presets[(int)preset];</code>.
        /// </remarks>
        public static implicit operator Color(Color.Preset preset)
        {
            return Presets[(int)preset];
        }

        /// <summary>
        /// A list of <see cref="Color"/> objects that correspond to the <see cref="Color.Preset"/> enumeration values.
        /// </summary>
        public static readonly List<Color> Presets = new List<Color>() {
            new Color(0, 0, 0, 255), // Preset.Black
            new Color(0, 0, 128, 255), // Preset.DarkBlue
            new Color(0, 128, 0, 255), // Preset.DarkGreen
            new Color(0, 128, 128, 255), // Preset.DarkCyan
            new Color(128, 0, 0, 255), // Preset.DarkRed
            new Color(128, 0, 128, 255), // Preset.DarkMagenta
            new Color(128, 128, 0, 255), // Preset.DarkYellow
            new Color(192, 192, 192, 255), // Preset.Gray
            new Color(128, 128, 128, 255), // Preset.DarkGray
            new Color(0, 0, 255, 255), // Preset.Blue
            new Color(0, 255, 0, 255), // Preset.Green
            new Color(0, 255, 255, 255), // Preset.Cyan
            new Color(255, 0, 0, 255), // Preset.Red
            new Color(255, 0, 255, 255), // Preset.Magenta
            new Color(255, 255, 0, 255), // Preset.Yellow
            new Color(255, 255, 255, 255), // Preset.White
        };

        /// <summary>
        /// Provide a list of values to be used to create certain preset colour values.
        /// </summary>
        /// <remarks>
        /// This enum exists, and is layed out in this order to provide compatiblity with the <code>ConsoleColor</code> enumeration.
        /// </remarks>
        public enum Preset : int
        {
            Black = 0,
            DarkBlue = 1,
            DarkGreen = 2,
            DarkCyan = 3,
            DarkRed = 4,
            DarkMagenta = 5,
            DarkYellow = 6,
            Gray = 7,
            DarkGray = 8,
            Blue = 9,
            Green = 10,
            Cyan = 11,
            Red = 12,
            Magenta = 13,
            Yellow = 14,
            White = 15,
        }

        /// <summary>
        /// Inherited from <see cref="ISerializableByteArray"/>. Gets the byte-array for the current <see cref="Color"/> object.
        /// </summary>
        /// <returns>A byte-array representing the current <see cref="Color"/>.</returns>
        public byte[] GetBytes()
        {
            byte[] result = new byte[SizeInBytes];

            result[0] = A;
            result[1] = R;
            result[2] = G;
            result[3] = B;

            return result;
        }

        /// <summary>
        /// Inherited from <see cref="ISerializableByteArray"/>. Builds the current <see cref="Color"/> object from the specified byte-array.
        /// </summary>
        /// <param name="data">A byte-array that represents a <see cref="Color"/> object.</param>
        public void FromBytes(byte[] data)
        {
            if (data.Length == SizeInBytes)
            {
                A = data[0];
                R = data[1];
                G = data[2];
                B = data[3];
            }
            else
                throw new ArgumentException("Parameter \"data\" must be exactly " + SizeInBytes + " bytes.");
        }

        /// <summary>
        /// Gets the number of bytes the <see cref="Color"/> will consume.
        /// </summary>
        public int SizeInBytes
        {
            get { return 4; }
        }
    }
}
