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
        private short _Width;
        private short _Height;

        public SizeShort(Point pt) { _Width = (short)(pt.X); _Height = (short)(pt.Y); }
        public SizeShort(PointShort pt) { _Width = (pt.X); _Height = (pt.Y); }
        public SizeShort(short width, short height) { _Width = width; _Height = height; }

        public short Height { get { return _Height; } set { _Height = value; } }

        [BrowsableAttribute(false)]
        public bool IsEmpty { get { return this == Empty; } }

        public short Width { get { return _Width; } set { _Width = value; } }

        public static SizeShort Add(SizeShort sz1, SizeShort sz2) { return sz1 + sz2; }
        public static SizeShort Ceiling(SizeF value) { return new SizeShort((short)Math.Ceiling(value.Width), (short)Math.Ceiling(value.Height)); }
        public override bool Equals(Object obj) { if (obj.GetType() == typeof(SizeShort)) { return (SizeShort)obj == this; } else { return false; } }
        public override int GetHashCode() { return base.GetHashCode(); }
        public static SizeShort Round(SizeF value) { return new SizeShort((short)Math.Round(value.Width), (short)Math.Round(value.Height)); }
        public static SizeShort Subtract(SizeShort sz1, SizeShort sz2) { return sz1 - sz2; }
        public override string ToString() { return "(" + _Width + "," + _Height + ")"; }
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
            return new byte[] { (byte)((_Width & 0x0000FF00) >> 8), (byte)((_Width & 0x000000FF) >> 0), (byte)((_Height & 0x0000FF00) >> 8), (byte)((_Height & 0x000000FF) >> 0) };
        }

        public void FromBytes(byte[] data)
        {
            if (data.Length == this.SizeInBytes)
            {
                this._Width = (short)(((uint)data[0]) << 8 | ((uint)data[1]));
                this._Height = (short)(((uint)data[2]) << 8 | ((uint)data[3]));
            }
            else
                throw new ArgumentException("Parameter \"data\" must be exactly " + SizeInBytes + " bytes.");
        }

        public int SizeInBytes { get { return 4; } }
        #endregion
    }
}
