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
    /// Represents a <see cref="Deployment"/>.
    ///
    /// Events of this type are not visible in timelines, they are only used to trigger hooks.
    /// </summary>
    [DataContract]
    public class DeploymentEvent
    {
        /// <summary>
        /// The name of the Webhook event for this event.
        /// </summary>
        public const string WebhookEventName = "deployment";

        /// <summary>
        /// The <see cref="Models.Deployment"/>.
        /// </summary>
        [DataMember(Name = "deployment")]
        public Deployment Deployment { get; set; }

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
