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
    /// Represents a deleted branch or tag.
    /// </summary>
    [DataContract]
    public class DeleteEvent
    {
        /// <summary>
        /// The name of the Webhook event for this event.
        /// </summary>
        public const string WebhookEventName = "delete";

        /// <summary>
        /// The full git ref.
        /// </summary>
        [DataMember(Name = "ref")]
        public string Ref { get; set; }

        /// <summary>
        /// The object that was deleted. Can be “branch” or “tag”.
        /// </summary>
        [DataMember(Name = "ref_type")]
        public string RefType { get; set; }

        [DataMember(Name = "pusher_type")]
        public string PusherType { get; set; }

        /// <summary>
        /// The <see cref="Models.Repository"/> for this <see cref="Models.Deployment"/>.
        /// </summary>
        [DataMember(Name = "repository")]
        public Repository Repository { get; set; }

        [DataMember(Name = "sender")]
        public Sender Sender { get; set; }
    }
}
