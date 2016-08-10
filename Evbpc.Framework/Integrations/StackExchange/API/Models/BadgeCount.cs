using System.Runtime.Serialization;

namespace Evbpc.Framework.Integrations.StackExchange.API.Models
{
    /// <summary>
    /// Represents the number of badges of each type earned by a <see cref="User"/> on the Stack Exchange API.
    /// </summary>
    /// <remarks>
    /// http://api.stackexchange.com/docs/types/badge-count
    /// </remarks>
    [DataContract]
    public class BadgeCount
    {
        /// <summary>
        /// See <code>bronze</code>
        /// </summary>
        [DataMember(Name = "bronze")]
        public int Bronze { get; set; }

        /// <summary>
        /// See <code>silver</code>
        /// </summary>
        [DataMember(Name = "silver")]
        public int Silver { get; set; }

        /// <summary>
        /// See <code>gold</code>
        /// </summary>
        [DataMember(Name = "gold")]
        public int Gold { get; set; }
    }
}