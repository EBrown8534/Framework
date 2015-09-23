using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.GitHub.Models
{
    [DataContract]
    public class PullRequestComment : Comment
    {
        [DataMember(Name = "diff_hunk")]
        public string DiffHunk { get; set; }

        [DataMember(Name = "original_position")]
        public int OriginalPosition { get; set; }

        [DataMember(Name = "original_commit_id")]
        public string OriginalCommitId { get; set; }

        [DataMember(Name = "pull_request_url")]
        public string PullRequestUrl { get; set; }

        [DataMember(Name = "_links")]
        public Links Links { get; set; }
    }
}
