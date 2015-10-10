using Evbpc.Framework.Integrations.Bitbucket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.Bitbucket.Events
{
    [DataContract]
    public class IssueCommentCreatedEvent
    {
        public const string WebhookEventName = "issue:comment_created";

        [DataMember(Name = "actor")]
        public Actor Actor { get; set; }

        [DataMember(Name = "issue")]
        public Issue Issue { get; set; }

        [DataMember(Name = "repository")]
        public Repository Repository { get; set; }

        [DataMember(Name = "comment")]
        public Comment Comment { get; set; }
    }
}
