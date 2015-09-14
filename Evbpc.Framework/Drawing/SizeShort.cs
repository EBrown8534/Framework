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
        public SizeShort(Point pt)
        {
            Width = (short)(pt.X);
            Height = (short)(pt.Y);
        }

        public SizeShort(PointShort pt)
        {
            Width = (pt.X);
            Height = (pt.Y);
        }

        public SizeShort(short width, short height)
        {
            Width = width;
            Height = height;
        }

        public short Height { get; }

        [BrowsableAttribute(false)]
        public bool IsEmpty { get { return this == Empty; } }

        public short Width { get; }

        public static SizeShort Add(SizeShort sz1, SizeShort sz2) => sz1 + sz2;

        public static SizeShort Ceiling(SizeF value) => new SizeShort((short)Math.Ceiling(value.Width), (short)Math.Ceiling(value.Height));

        public override bool Equals(Object obj) => obj is SizeShort && (SizeShort)obj == this;

        public override int GetHashCode() => base.GetHashCode();

        public static SizeShort Round(SizeF value) => new SizeShort((short)Math.Round(value.Width), (short)Math.Round(value.Height));

        public static SizeShort Subtract(SizeShort sz1, SizeShort sz2) => sz1 - sz2;

        public override string ToString() => $"({Width},{Height})";

        public static SizeShort Truncate(SizeF value) => new SizeShort((short)(value.Width), (short)(value.Height));

        public static SizeShort operator +(SizeShort sz1, SizeShort sz2) => new SizeShort((short)(sz1.Width + sz2.Width), (short)(sz1.Height + sz2.Height));

        public static bool operator ==(SizeShort sz1, SizeShort sz2) => sz1.Width == sz2.Width && sz1.Height == sz2.Height;

        public static explicit operator Point(SizeShort size) => new Point(size.Width, size.Height);

        public static explicit operator PointShort(SizeShort size) => new PointShort(size.Width, size.Height);

        public static implicit operator SizeF(SizeShort p) => new SizeF(p.Width, p.Height);

        public static implicit operator Size(SizeShort p) => new Size(p.Width, p.Height);

        public static bool operator !=(SizeShort sz1, SizeShort sz2) => sz1.Width != sz2.Width || sz1.Height != sz2.Height;

        public static SizeShort operator -(SizeShort sz1, SizeShort sz2) => new SizeShort((short)(sz1.Width - sz2.Width), (short)(sz1.Height - sz2.Height));

        public static readonly SizeShort Empty = new SizeShort(0, 0);

        #region Serialization/Deserialization
        /// <summary>
        /// Inherited from <see cref="ISerializableByteArray"/>. Gets the byte-array for the current <see cref="SizeShort"/> object.
        /// </summary>
        /// <returns>A byte-array representing the current <see cref="SizeShort"/>.</returns>
        public byte[] GetBytes()
        {
            byte[] result = new byte[4];

            result[0] = (byte)((Width & 0xFF00) >> 8);
            result[1] = (byte)((Width & 0x00FF) >> 0);
            result[2] = (byte)((Height & 0xFF00) >> 8);
            result[3] = (byte)((Height & 0x00FF) >> 0);

            return result;
        }

        public void FromBytes(byte[] data)
        {
            if (data.Length == this.SizeInBytes)
            {
                this = new SizeShort(
                    (short)(((uint)data[0]) << 8 | ((uint)data[1])),
                    (short)(((uint)data[2]) << 8 | ((uint)data[3])));
            }
            else
                throw new ArgumentException($"Parameter \"data\" must be exactly {SizeInBytes} bytes.");
        }

        public int SizeInBytes => 4;
        #endregion
    }
}
