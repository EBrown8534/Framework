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
    public class MembershipEvent
    {
        public const string WebhookEventName = "membership";

        [DataMember(Name = "action")]
        public string Action { get; set; }

        [DataMember(Name = "scope")]
        public string Scope { get; set; }

        [DataMember(Name = "member")]
        public Sender Member { get; set; }

        [DataMember(Name = "sender")]
        public Sender Sender { get; set; }

        [DataMember(Name = "team")]
        public Team Team { get; set; }

        [DataMember(Name = "organization")]
        public Organization Organization { get; set; }
    }
}
