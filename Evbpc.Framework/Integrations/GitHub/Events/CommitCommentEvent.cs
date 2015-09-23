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
    public class CommitCommentEvent
    {
        public const string WebhookEventName = "commit_comment";

        [DataMember(Name = "action")]
        public string Action { get; set; }

        [DataMember(Name = "comment")]
        public Comment Comment { get; set; }

        [DataMember(Name = "repository")]
        public Repository Repository { get; set; }

        [DataMember(Name = "sender")]
        public Sender Sender { get; set; }
    }
}
