using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evbpc.Framework.Utilities.Extensions
{
    public static class TimeSpanExtensions
    {
        public static double PercentComplete(this TimeSpan t, TimeSpan target)
        {
            return t.TotalMilliseconds / target.TotalMilliseconds;
        }
    }
}
