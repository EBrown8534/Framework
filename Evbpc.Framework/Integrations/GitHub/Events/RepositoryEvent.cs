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
    /// Triggered when a repository is created.
    ///
    /// Events of this type are not visible in timelines, they are only used to trigger organization webhooks.
    /// </summary>
    [DataContract]
    public class RepositoryEvent
    {
        /// <summary>
        /// The name of the Webhook event for this event.
        /// </summary>
        public const string WebhookEventName = "repository";

        /// <summary>
        /// The action that was performed. Currently, can only be “created”.
        /// </summary>
        [DataMember(Name = "action")]
        public string Action { get; set; }

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
