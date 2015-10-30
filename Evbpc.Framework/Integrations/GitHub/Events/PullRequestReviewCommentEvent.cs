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
    /// Triggered when a comment is created on a portion of the unified diff of a pull request.
    /// </summary>
    [DataContract]
    public class PullRequestReviewCommentEvent
    {
        /// <summary>
        /// The name of the Webhook event for this event.
        /// </summary>
        public const string WebhookEventName = "pull_request_review_comment";

        /// <summary>
        /// The action that was performed on the comment. Currently, can only be “created”.
        /// </summary>
        [DataMember(Name = "action")]
        public string Action { get; set; }

        /// <summary>
        /// The <see cref="PullRequestComment"/> itself.
        /// </summary>
        [DataMember(Name = "comment")]
        public PullRequestComment Comment { get; set; }

        /// <summary>
        /// The <see cref="Models.PullRequest"/> the comment belongs to.
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
