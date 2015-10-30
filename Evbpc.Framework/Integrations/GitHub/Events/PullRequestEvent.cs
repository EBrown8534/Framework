using Evbpc.Framework.Integrations.GitHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.GitHub.Events
{
    [DataContract]
    public class PullRequestEvent
    {
        /// <summary>
        /// The name of the Webhook event for this event.
        /// </summary>
        public const string WebhookEventName = "pull_request";

        /// <summary>
        /// The action that was performed. Can be one of “assigned”, “unassigned”, “labeled”, “unlabeled”, “opened”, “closed”, or “reopened”, or “synchronize”. If the action is “closed” and the merged key is false, the pull request was closed with unmerged commits. If the action is “closed” and the merged key is true, the pull request was merged.
        /// </summary>
        [DataMember(Name = "action")]
        public string Action { get; set; }

        /// <summary>
        /// The pull request number.
        /// </summary>
        [DataMember(Name = "number")]
        public int Number { get; set; }

        /// <summary>
        /// The <see cref="Models.PullRequest"/> itself.
        /// </summary>
        [DataMember(Name = "pull_request")]
        public PullRequest PullRequest { get; set; }

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
