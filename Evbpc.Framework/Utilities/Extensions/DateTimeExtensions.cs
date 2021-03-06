﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evbpc.Framework.Utilities.Extensions
{
    /// <summary>
    /// A collection of methods which may be used with the <code>DateTime</code> structure.
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Represents January 1, 1970 which is Unix Epoch time 0.
        /// </summary>
        public static readonly DateTime EpochBase = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

        /// <summary>
        /// Converts an <code>IList&lt;DateTime&gt;</code> to the <code>IList&lt;long&gt;</code> equivalent.
        /// </summary>
        /// <param name="dateList">An <code>IList&lt;DateTime&gt;</code> to be converted.</param>
        /// <returns>An <code>IList&lt;long&gt;</code> representing the input list.</returns>
        public static IList<long> ToBinaryList(IList<DateTime> dateList) => dateList.Select(x => x.ToBinary()).ToList();

        /// <summary>
        /// Converts an <code>IList&lt;long&gt;</code> to the <code>IList&lt;DateTime&gt;</code> equivalent.
        /// </summary>
        /// <param name="binaryList">An <code>IList&lt;long&gt;</code> to be converted.</param>
        /// <returns>An <code>IList&lt;DateTime&gt;</code> representing the input list.</returns>
        public static IList<DateTime> FromBinaryList(IList<long> binaryList) => binaryList.Select(x => DateTime.FromBinary(x)).ToList();

        /// <summary>
        /// Converts a DateTime to the long representation which is the number of seconds since the unix epoch.
        /// </summary>
        /// <param name="dateTime">A DateTime to convert to epoch time.</param>
        /// <returns>The long number of seconds since the unix epoch.</returns>
        public static long ToEpoch(DateTime dateTime)
        {
            if (dateTime.Kind != DateTimeKind.Utc)
            {
                throw new ArgumentException($"The value for {nameof(dateTime)} must be a UTC DateTime object.");
            }

            // Round the milliseconds down.
            if (dateTime.Millisecond > 0)
            {
                dateTime = dateTime.AddMilliseconds(0 - dateTime.Millisecond);
            }

            return (long)(dateTime - EpochBase).TotalSeconds;
        }

        /// <summary>
        /// Converts a long representation of time since the unix epoch to a DateTime.
        /// </summary>
        /// <param name="epoch">The number of seconds since Jan 1, 1970.</param>
        /// <returns>A DateTime representing the time since the epoch.</returns>
        public static DateTime FromEpoch(long epoch) => EpochBase.AddSeconds(epoch);

        /// <summary>
        /// Converts a DateTime? to the long? representation which is the number of seconds since the unix epoch.
        /// </summary>
        /// <param name="dateTime">A DateTime? to convert to epoch time.</param>
        /// <returns>The long? number of seconds since the unix epoch.</returns>
        public static long? ToEpoch(DateTime? dateTime) => dateTime.HasValue ? (long?)ToEpoch(dateTime.Value) : null;

        /// <summary>
        /// Converts a long? representation of time since the unix epoch to a DateTime?.
        /// </summary>
        /// <param name="epoch">The number of seconds since Jan 1, 1970.</param>
        /// <returns>A DateTime? representing the time since the epoch.</returns>
        public static DateTime? FromEpoch(long? epoch) => epoch.HasValue ? (DateTime?)FromEpoch(epoch.Value) : null;
    }
}
