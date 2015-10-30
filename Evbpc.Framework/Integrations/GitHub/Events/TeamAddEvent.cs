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
    /// Triggered when a repository is added to a team.
    ///
    /// Events of this type are not visible in timelines.These events are only used to trigger hooks.
    /// </summary>
    [DataContract]
    public class TeamAddEvent
    {
        public const string WebhookEventName = "team_add";

        /// <summary>
        /// The <see cref="Models.Team"/> that was modified. Note: older events may not include this in the payload.
        /// </summary>
        [DataMember(Name = "team")]
        public Team Team { get; set; }

        [DataMember(Name = "organization")]
        public Organization Organization { get; set; }

        /// <summary>
        /// The <see cref="Models.Repository"/> for this event.
        /// </summary>
        [DataMember(Name = "repository")]
        public Repository Repository { get; set; }

        /// <summary>
        /// The <see cref="Models.Sender"/> that triggered the event.
        /// </summary>
        [DataMember(Name = "sender")]
        public Sender Sender { get; set; }
    }
}
