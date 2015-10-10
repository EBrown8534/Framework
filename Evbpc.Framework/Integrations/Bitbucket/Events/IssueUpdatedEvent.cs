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
    public class IssueUpdatedEvent
    {
        public const string WebhookEventName = "issue:updated";

        [DataMember(Name = "actor")]
        public Actor Actor { get; set; }

        [DataMember(Name = "issue")]
        public Issue Issue { get; set; }

        [DataMember(Name = "repository")]
        public Repository Repository { get; set; }

        [DataMember(Name = "comment")]
        public Comment Comment { get; set; }

        [DataMember(Name = "changes")]
        public IssueChanges Changes { get; set; }
    }
}
