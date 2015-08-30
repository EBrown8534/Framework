using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evbpc.Framework.Utilities.Extensions
{
    /// <summary>
    /// Provides certain extension methods for the <code>TimeSpan</code> structure.
    /// </summary>
    public static class TimeSpanExtensions
    {
        /// <summary>
        /// Calculates how far into the target <code>TimeSpan</code> the current <code>TimeSpan</code> is.
        /// </summary>
        /// <param name="t">The <code>TimeSpan</code> to test.</param>
        /// <param name="target">The target <code>TimeSpan</code>.</param>
        /// <returns>A <code>double</code> value representing how long into the target the <code>TimeSpan</code> is.</returns>
        public static double PercentComplete(this TimeSpan t, TimeSpan target)
        {
            return t.TotalMilliseconds / target.TotalMilliseconds;
        }
    }
}
