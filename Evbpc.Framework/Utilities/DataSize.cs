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
        public SizeUnit Unit { get; }
        public double Size => GetSize(Unit);

        public DataSize(ulong sizeInBytes)
        {
            Unit = SizeUnit.Bytes;
            SizeInBytes = sizeInBytes;
        }

        public DataSize(ulong sizeInBytes, SizeUnit unit)
        {
            Unit = unit;
            SizeInBytes = sizeInBytes;
        }

        private DataSize(double size, SizeUnit unit)
        {
            Unit = unit;

            if (unit == SizeUnit.Bits)
            {
                SizeInBytes = (uint)(size / 8);
                return;
            }

            if (((int)unit & 0x03) == (int)SizeUnit.Bytes)
            {
                SizeInBytes = (uint)(size * Math.Pow(10, 3 * (((int)unit & 0xFF00) >> 8)));
                return;
            }

            SizeInBytes = (uint)(size * Math.Pow(2, 10 * (((int)unit & 0xFF00) >> 8)));
        }

        public double GetSize(SizeUnit unit)
        {
            if (unit == SizeUnit.Bits)
            {
                return SizeInBytes * 8.0;
            }

            if (((int)unit & 0x03) == (int)SizeUnit.Bytes)
            {
                return SizeInBytes / Math.Pow(10, 3 * (((int)unit & 0xFF00) >> 8));
            }

            return SizeInBytes / Math.Pow(2, 10 * (((int)unit & 0xFF00) >> 8));
        }

        /// <summary>
        /// Returns a <see cref="DataSize"/> that is the highest value which will have a non-zero whole-number <see cref="Size"/> component.
        /// </summary>
        /// <param name="unit">When set to <see cref="SizeUnit.Bytes"/> the result will be a <code>B</code> type, when set to <see cref="SizeUnit.Bits"/> the result will be a <code>iB</code> type. If set to <code>null</code> the same base unit as the source value will be used.</param>
        /// <returns>A <see cref="DataSize"/> object.</returns>
        public DataSize GetLargestWholeSize(SizeUnit? unit = null)
        {
            var limit = 1000ul;

            if (unit == null)
            {
                unit = (SizeUnit)((int)Unit & 0x00FF);
            }

            if (unit == SizeUnit.Bits)
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

            return new DataSize(currSize, (SizeUnit)((iterations << 8) | ((int)unit & 0x00FF)));
        }

        /// <summary>
        /// Returns a <see cref="DataSize"/> that is the smallest value which will have a zero whole-number <see cref="Size"/> component.
        /// </summary>
        /// <param name="unit">When set to <see cref="SizeUnit.Bytes"/> the result will be a <code>B</code> type, when set to <see cref="SizeUnit.Bits"/> the result will be a <code>iB</code> type. If set to <code>null</code> the same base unit as the source value will be used.</param>
        /// <returns>A <see cref="DataSize"/> object.</returns>
        public DataSize GetSmallestPartialSize(SizeUnit? unit = null)
        {
            var limit = 1000ul;

            if (unit == null)
            {
                unit = (SizeUnit)((int)Unit & 0x00FF);
            }

            if (unit == SizeUnit.Bits)
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

            return new DataSize(currSize, (SizeUnit)((iterations << 8) | ((int)unit & 0x00FF)));
        }

        public override bool Equals(object obj) => obj is DataSize && (DataSize)obj == this;

        public override int GetHashCode() => Size.GetHashCode();

        public override string ToString() => $"{Size} {Unit.Abbreviation()}";

        public string ToString(string numberFormat) => $"{Size.ToString(numberFormat)} {Unit.Abbreviation()}";

        public string ToString(SizeUnit unit) => $"{GetSize(unit)} {unit.Abbreviation()}";

        public string ToString(string numberFormat, SizeUnit unit) => $"{GetSize(unit).ToString(numberFormat)} {unit.Abbreviation()}";

        public bool IsSame(DataSize comparison) => SizeInBytes == comparison.SizeInBytes && Unit == comparison.Unit;

        public static bool IsSame(DataSize left, DataSize right) => left.SizeInBytes == right.SizeInBytes && left.Unit == right.Unit;

        public static bool operator ==(DataSize left, DataSize right) => left.SizeInBytes == right.SizeInBytes;

        public static bool operator !=(DataSize left, DataSize right) => left.SizeInBytes != right.SizeInBytes;

        public static DataSize operator +(DataSize left, DataSize right) => new DataSize(left.SizeInBytes + right.SizeInBytes, left.Unit);

        public static DataSize operator -(DataSize left, DataSize right) => new DataSize(left.SizeInBytes - right.SizeInBytes, left.Unit);

        public static DataSize operator *(DataSize left, ulong right) => new DataSize(left.SizeInBytes * right, left.Unit);

        public static DataSize operator /(DataSize left, ulong right) => new DataSize(left.SizeInBytes / right, left.Unit);

        public static DataSize operator *(DataSize left, double right) => new DataSize((ulong)(left.SizeInBytes * right), left.Unit);

        public static DataSize operator /(DataSize left, double right) => new DataSize((ulong)(left.SizeInBytes / right), left.Unit);

        public static DataSize From(double size, SizeUnit unit) => new DataSize(size, unit);
    }
}
