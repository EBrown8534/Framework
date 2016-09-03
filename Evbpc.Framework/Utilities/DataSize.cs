using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Utilities
{
    public struct DataSize
    {
        public ulong SizeInBytes { get; }
        public SizeScale Scale { get; }
        public double Size => GetSize(Scale);

        public DataSize(ulong sizeInBytes)
        {
            Scale = SizeScale.Bytes;
            SizeInBytes = sizeInBytes;
        }

        public DataSize(ulong sizeInBytes, SizeScale scale)
        {
            Scale = scale;
            SizeInBytes = sizeInBytes;
        }

        private DataSize(double size, SizeScale scale)
        {
            Scale = scale;

            if (scale == SizeScale.Bits)
            {
                SizeInBytes = (uint)(size / 8);
                return;
            }

            if (((int)scale & 0x03) == (int)SizeScale.Bytes)
            {
                SizeInBytes = (uint)(size * Math.Pow(10, 3 * (((int)scale & 0xFF00) >> 8)));
                return;
            }

            SizeInBytes = (uint)(size * Math.Pow(2, 10 * (((int)scale & 0xFF00) >> 8)));
        }

        public double GetSize(SizeScale scale)
        {
            if (scale == SizeScale.Bits)
            {
                return SizeInBytes * 8.0;
            }

            if (((int)scale & 0x03) == (int)SizeScale.Bytes)
            {
                return SizeInBytes / Math.Pow(10, 3 * (((int)scale & 0xFF00) >> 8));
            }

            return SizeInBytes / Math.Pow(2, 10 * (((int)scale & 0xFF00) >> 8));
        }

        /// <summary>
        /// Returns a <see cref="DataSize"/> that is the highest value which will have a non-zero whole-number <see cref="Size"/> component.
        /// </summary>
        /// <param name="scaleType">When set to <see cref="SizeScale.Bytes"/> the result will be a <code>B</code> type, when set to <see cref="SizeScale.Bits"/> the result will be a <code>iB</code> type. If set to <see cref="SizeScale.None"/> the same base unit as the source value will be used.</param>
        /// <returns>A <see cref="DataSize"/> object.</returns>
        public DataSize GetLargestWholeSize(SizeScale scaleType = SizeScale.None)
        {
            var limit = 1000ul;

            if (scaleType == SizeScale.None)
            {
                scaleType = (SizeScale)((int)Scale & 0x00FF);
            }

            if (scaleType == SizeScale.Bits)
            {
                limit = 1024ul;
            }

            var iterations = 0;
            var currSize = (double)SizeInBytes;

            while (currSize >= limit)
            {
                currSize /= limit;
                iterations++;
            }

            return new DataSize(currSize, (SizeScale)((iterations << 8) | ((int)scaleType & 0x00FF)));
        }

        /// <summary>
        /// Returns a <see cref="DataSize"/> that is the smallest value which will have a zero whole-number <see cref="Size"/> component.
        /// </summary>
        /// <param name="scaleType">When set to <see cref="SizeScale.Bytes"/> the result will be a <code>B</code> type, when set to <see cref="SizeScale.Bits"/> the result will be a <code>iB</code> type. If set to <see cref="SizeScale.None"/> the same base unit as the source value will be used.</param>
        /// <returns>A <see cref="DataSize"/> object.</returns>
        public DataSize GetSmallestPartialSize(SizeScale scaleType = SizeScale.None)
        {
            var limit = 1000ul;

            if (scaleType == SizeScale.None)
            {
                scaleType = (SizeScale)((int)Scale & 0x00FF);
            }

            if (scaleType == SizeScale.Bits)
            {
                limit = 1024ul;
            }

            var iterations = 0;
            var currSize = (double)SizeInBytes;

            while (currSize >= limit)
            {
                currSize /= limit;
                iterations++;
            }

            iterations++;

            return new DataSize(currSize, (SizeScale)((iterations << 8) | ((int)scaleType & 0x00FF)));
        }

        public override bool Equals(object obj) => obj is DataSize && (DataSize)obj == this;

        public override int GetHashCode() => Size.GetHashCode();

        public override string ToString() => $"{Size} {Scale.Abbreviation()}";

        public string ToString(string numberFormat) => $"{Size.ToString(numberFormat)} {Scale.Abbreviation()}";

        public string ToString(SizeScale scale) => $"{GetSize(scale)} {scale.Abbreviation()}";

        public string ToString(string numberFormat, SizeScale scale) => $"{GetSize(scale).ToString(numberFormat)} {scale.Abbreviation()}";

        public bool IsSame(DataSize comparison) => SizeInBytes == comparison.SizeInBytes && Scale == comparison.Scale;

        public static bool IsSame(DataSize left, DataSize right) => left.SizeInBytes == right.SizeInBytes && left.Scale == right.Scale;

        public static bool operator ==(DataSize left, DataSize right) => left.SizeInBytes == right.SizeInBytes;

        public static bool operator !=(DataSize left, DataSize right) => left.SizeInBytes != right.SizeInBytes;

        public static DataSize operator +(DataSize left, DataSize right) => new DataSize(left.SizeInBytes + right.SizeInBytes, left.Scale);

        public static DataSize operator -(DataSize left, DataSize right) => new DataSize(left.SizeInBytes - right.SizeInBytes, left.Scale);

        public static DataSize operator *(DataSize left, ulong right) => new DataSize(left.SizeInBytes * right, left.Scale);

        public static DataSize operator /(DataSize left, ulong right) => new DataSize(left.SizeInBytes / right, left.Scale);

        public static DataSize operator *(DataSize left, double right) => new DataSize((ulong)(left.SizeInBytes * right), left.Scale);

        public static DataSize operator /(DataSize left, double right) => new DataSize((ulong)(left.SizeInBytes / right), left.Scale);

        public static DataSize From(double size, SizeScale scale) => new DataSize(size, scale);
    }
}
