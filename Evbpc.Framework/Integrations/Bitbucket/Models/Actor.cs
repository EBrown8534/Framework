using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.Bitbucket.Models
{
    /// <summary>
    /// Represents a Bitbucket API actor.
    /// </summary>
    [DataContract]
    public class Actor
    {
        /// <summary>
        /// The string type of the <see cref="Actor"/>.
        /// </summary>
        [DataMember(Name = "type")]
        public string Type { get; set; }

        /// <summary>
        /// The string display name of the <see cref="Actor"/>.
        /// </summary>
        [DataMember(Name = "display_name")]
        public string DisplayName { get; set; }

        /// <summary>
        /// The string username of the <see cref="Actor"/>.
        /// </summary>
        [DataMember(Name = "username")]
        public string Username { get; set; }

        /// <summary>
        /// The unique identifier or primary key for the <see cref="Actor"/>.
        /// </summary>
        [DataMember(Name = "uuid")]
        public string UUID { get; set; }

        /// <summary>
        /// A <see cref="Links"/> object representing the links for the current <see cref="Actor"/>.
        /// </summary>
        [DataMember(Name = "links")]
        public Links Links { get; set; }
    }
}
