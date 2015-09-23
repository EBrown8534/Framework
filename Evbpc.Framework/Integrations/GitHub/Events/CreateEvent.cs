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
    public class CreateEvent
    {
        public const string WebhookEventName = "create";

        [DataMember(Name = "ref")]
        public string Ref { get; set; }

        [DataMember(Name = "ref_type")]
        public string RefType { get; set; }

        [DataMember(Name = "master_branch")]
        public string MasterBranch { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "pusher_type")]
        public string PusherType { get; set; }

        [DataMember(Name = "repository")]
        public Repository Repository { get; set; }

        [DataMember(Name = "sender")]
        public Sender Sender { get; set; }
    }
}
