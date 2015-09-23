using Evbpc.Framework.Integrations.GitHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.GitHub.Events
{
    [DataContract(Name = "root")]
    public class PushEvent
    {
        public const string WebhookEventName = "push";

        [DataMember(Name = "ref")]
        public string Ref { get; set; }

        [DataMember(Name = "before")]
        public string Before { get; set; }

        [DataMember(Name = "after")]
        public string After { get; set; }

        [DataMember(Name = "created")]
        public bool Created { get; set; }

        [DataMember(Name = "deleted")]
        public bool Deleted { get; set; }

        [DataMember(Name = "forced")]
        public bool Forced { get; set; }

        [DataMember(Name = "base_ref")]
        public string BaseRef { get; set; }

        [DataMember(Name = "compare")]
        public string Compare { get; set; }

        [DataMember(Name = "commits")]
        public List<Commit> Commits { get; set; }

        [DataMember(Name = "head_commit")]
        public Commit HeadCommit { get; set; }

        [DataMember(Name = "repository")]
        public Repository Repository { get; set; }

        [DataMember(Name = "pusher")]
        public Author Pusher { get; set; }

        [DataMember(Name = "sender")]
        public Sender Sender { get; set; }
    }
}
