using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.GitHub.Models
{
    [DataContract]
    public class MiniCommit
    {
        [DataMember(Name = "author")]
        public CommitAuthor Author { get; set; }

        [DataMember(Name = "committer")]
        public CommitAuthor Committer { get; set; }

        [DataMember(Name = "message")]
        public string Message { get; set; }

        [DataMember(Name = "tree")]
        public Tree Tree { get; set; }

        [DataMember(Name = "url")]
        public string Url { get; set; }

        [DataMember(Name = "comment_count")]
        public int CommentCount { get; set; }
    }
}
