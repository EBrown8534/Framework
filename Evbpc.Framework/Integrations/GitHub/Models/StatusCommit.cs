using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.GitHub.Models
{
    [DataContract]
    public class StatusCommit : Commit
    {
        [DataMember(Name = "commit")]
        public MiniCommit Commit { get; set; }

        [DataMember(Name = "html_url")]
        public string HtmlUrl { get; set; }

        [DataMember(Name = "comments_url")]
        public string CommentsUrl { get; set; }

        [DataMember(Name = "parents")]
        public List<object> Parents { get; set; }
    }
}
