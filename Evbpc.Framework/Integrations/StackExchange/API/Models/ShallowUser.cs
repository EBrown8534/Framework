using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.StackExchange.API.Models
{
    /// <summary>
    /// Represents a partial user on the Stack Exchange API.
    /// </summary>
    /// <remarks>
    /// http://api.stackexchange.com/docs/types/shallow-user
    /// </remarks>
    [DataContract]
    public class ShallowUser
    {
        /// <summary>
        /// See <code>accept_rate</code>
        /// </summary>
        [DataMember(Name = "accept_rate")]
        public int? AcceptRate { get; set; }

        /// <summary>
        /// See <code>display_name</code>
        /// </summary>
        [DataMember(Name = "display_name")]
        public string DisplayName { get; set; }

        /// <summary>
        /// See <code>link</code>
        /// </summary>
        [DataMember(Name = "link")]
        public string Link { get; set; }

        /// <summary>
        /// See <code>profile_image</code>
        /// </summary>
        [DataMember(Name = "profile_image")]
        public string ProfileImage { get; set; }

        /// <summary>
        /// See <code>reputation</code>
        /// </summary>
        [DataMember(Name = "reputation")]
        public int? Reputation { get; set; }

        /// <summary>
        /// See <code>user_id</code>
        /// </summary>
        [DataMember(Name = "user_id")]
        public int? UserId { get; set; }

        /// <summary>
        /// See <code>user_type</code>
        /// </summary>
        [DataMember(Name = "user_type")]
        public string UserType { get; set; }
    }
}