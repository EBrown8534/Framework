using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.GitHub.Models
{
    [DataContract]
    public class IssueComment : Comment
    {
        [DataMember(Name = "issue_url")]
        public string IssueUrl { get; set; }
    }
}
