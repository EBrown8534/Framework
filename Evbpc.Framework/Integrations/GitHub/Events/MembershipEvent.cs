using Evbpc.Framework.Integrations.GitHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.GitHub.Events
{
    /// <summary>
    /// Triggered when a user is added or removed from a team.
    ///
    /// Events of this type are not visible in timelines, they are only used to trigger organization webhooks.
    /// </summary>
    [DataContract]
    public class MembershipEvent
    {
        public const string WebhookEventName = "membership";

        /// <summary>
        /// The action that was performed. Can be “added” or “removed”.
        /// </summary>
        [DataMember(Name = "action")]
        public string Action { get; set; }

        /// <summary>
        /// The scope of the membership. Currently, can only be “team”.
        /// </summary>
        [DataMember(Name = "scope")]
        public string Scope { get; set; }

        /// <summary>
        /// The user that was added or removed.
        /// </summary>
        [DataMember(Name = "member")]
        public Sender Member { get; set; }

        /// <summary>
        /// The <see cref="Models.Sender"/> that triggered the event.
        /// </summary>
        [DataMember(Name = "sender")]
        public Sender Sender { get; set; }

        /// <summary>
        /// The <see cref="Models.Team"/> for the membership.
        /// </summary>
        [DataMember(Name = "team")]
        public Team Team { get; set; }

        [DataMember(Name = "organization")]
        public Organization Organization { get; set; }
    }
}
