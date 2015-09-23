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
    public class PullRequestReviewCommentEvent
    {
        public const string WebhookEventName = "pull_request_review_comment";

        [DataMember(Name = "action")]
        public string Action { get; set; }

        [DataMember(Name = "comment")]
        public PullRequestComment Comment { get; set; }

        [DataMember(Name = "pull_request")]
        public PullRequest PullRequest { get; set; }

        [DataMember(Name = "repository")]
        public Repository Repository { get; set; }

        [DataMember(Name = "sender")]
        public Sender Sender { get; set; }
    }
}
