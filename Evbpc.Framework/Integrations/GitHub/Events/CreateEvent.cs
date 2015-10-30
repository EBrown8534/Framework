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
    /// Represents a created repository, branch, or tag.
    ///
    /// Note: webhooks will not receive this event for created repositories.
    /// </summary>
    [DataContract]
    public class CreateEvent
    {
        /// <summary>
        /// The name of the Webhook event for this event.
        /// </summary>
        public const string WebhookEventName = "create";

        /// <summary>
        /// The git ref (or null if only a repository was created).
        /// </summary>
        [DataMember(Name = "ref")]
        public string Ref { get; set; }

        /// <summary>
        /// The object that was created. Can be one of “repository”, “branch”, or “tag”
        /// </summary>
        [DataMember(Name = "ref_type")]
        public string RefType { get; set; }

        /// <summary>
        /// The name of the repository’s default branch (usually master).
        /// </summary>
        [DataMember(Name = "master_branch")]
        public string MasterBranch { get; set; }

        /// <summary>
        /// The repository’s current description.
        /// </summary>
        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "pusher_type")]
        public string PusherType { get; set; }

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
