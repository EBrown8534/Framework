using Evbpc.Framework.Utilities.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Evbpc.Framework.Drawing
{
    [Serializable]
    public struct SizeShort : ISerializableByteArray
    {
        private short _width;
        private short _height;

        public SizeShort(Point pt) { _width = (short)(pt.X); _height = (short)(pt.Y); }
        public SizeShort(PointShort pt) { _width = (pt.X); _height = (pt.Y); }
        public SizeShort(short width, short height) { _width = width; _height = height; }

        public short Height { get { return _height; } set { _height = value; } }

        [BrowsableAttribute(false)]
        public bool IsEmpty { get { return this == Empty; } }

        public short Width { get { return _width; } set { _width = value; } }

        public static SizeShort Add(SizeShort sz1, SizeShort sz2) { return sz1 + sz2; }
        public static SizeShort Ceiling(SizeF value) { return new SizeShort((short)Math.Ceiling(value.Width), (short)Math.Ceiling(value.Height)); }
        public override bool Equals(Object obj) { if (obj.GetType() == typeof(SizeShort)) { return (SizeShort)obj == this; } else { return false; } }
        public override int GetHashCode() { return base.GetHashCode(); }
        public static SizeShort Round(SizeF value) { return new SizeShort((short)Math.Round(value.Width), (short)Math.Round(value.Height)); }
        public static SizeShort Subtract(SizeShort sz1, SizeShort sz2) { return sz1 - sz2; }
        public override string ToString() { return "(" + _width + "," + _height + ")"; }
        public static SizeShort Truncate(SizeF value) { return new SizeShort((short)(value.Width), (short)(value.Height)); }

        public static SizeShort operator +(SizeShort sz1, SizeShort sz2) { return new SizeShort((short)(sz1.Width + sz2.Width), (short)(sz1.Height + sz2.Height)); }
        public static bool operator ==(SizeShort sz1, SizeShort sz2) { return sz1.Width == sz2.Width && sz1.Height == sz2.Height; }
        public static explicit operator Point(SizeShort size) { return new Point(size.Width, size.Height); }
        public static explicit operator PointShort(SizeShort size) { return new PointShort(size.Width, size.Height); }
        public static implicit operator SizeF(SizeShort p) { return new SizeF(p.Width, p.Height); }
        public static implicit operator Size(SizeShort p) { return new Size(p.Width, p.Height); }
        public static bool operator !=(SizeShort sz1, SizeShort sz2) { return sz1.Width != sz2.Width || sz1.Height != sz2.Height; }
        public static SizeShort operator -(SizeShort sz1, SizeShort sz2) { return new SizeShort((short)(sz1.Width - sz2.Width), (short)(sz1.Height - sz2.Height)); }

        public static readonly SizeShort Empty = new SizeShort(0, 0);

        #region Serialization/Deserialization
        /// <summary>
        /// Inherited from <see cref="ISerializableByteArray"/>. Gets the byte-array for the current <see cref="SizeShort"/> object.
        /// </summary>
        /// <returns>A byte-array representing the current <see cref="SizeShort"/>.</returns>
        public byte[] GetBytes()
        {
            byte[] result = new byte[4];

            result[0] = (byte)((_width & 0xFF00) >> 8);
            result[1] = (byte)((_width & 0x00FF) >> 0);
            result[2] = (byte)((_height & 0xFF00) >> 8);
            result[3] = (byte)((_height & 0x00FF) >> 0);

            return result;
        }

        public void FromBytes(byte[] data)
        {
            if (data.Length == this.SizeInBytes)
            {
                this._width = (short)(((uint)data[0]) << 8 | ((uint)data[1]));
                this._height = (short)(((uint)data[2]) << 8 | ((uint)data[3]));
            }
            else
                throw new ArgumentException("Parameter \"data\" must be exactly " + SizeInBytes + " bytes.");
        }

        public int SizeInBytes { get { return 4; } }
        #endregion
    }
}
