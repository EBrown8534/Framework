using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.StackExchange.API.Models
{
    /// <summary>
    /// Represents a badge from the Stack Exchange API.
    /// </summary>
    /// <remarks>
    /// http://api.stackexchange.com/docs/types/badge
    /// </remarks>
    [DataContract]
    public class Badge : IBaseModel
    {
        /// <summary>
        /// See <code>award_count</code>
        /// </summary>
        [DataMember(Name = "award_count")]
        public int AwardCount { get; set; }

        /// <summary>
        /// See <code>badge_id</code>
        /// </summary>
        [DataMember(Name = "badge_id")]
        public int BadgeId { get; set; }

        /// <summary>
        /// See <code>badge_type</code>
        /// </summary>
        [DataMember(Name = "badge_type")]
        public string BadgeType { get; set; }

        /// <summary>
        /// See <code>link</code>
        /// </summary>
        [DataMember(Name = "link")]
        public string Link { get; set; }

        /// <summary>
        /// See <code>name</code>
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// See <code>rank</code>
        /// </summary>
        [DataMember(Name = "rank")]
        public string Rank { get; set; }

        /// <summary>
        /// See <code>user</code>
        /// </summary>
        [DataMember(Name = "user")]
        public ShallowUser User { get; set; }
    }
}
