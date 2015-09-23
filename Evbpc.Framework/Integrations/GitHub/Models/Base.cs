using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.GitHub.Models
{
    [DataContract]
    public class Base : Head
    {
        [DataMember(Name = "merged")]
        public bool Merged { get; set; }

        [DataMember(Name = "mergable")]
        public bool Mergeable { get; set; }

        [DataMember(Name = "mergeable_state")]
        public string MergeableState { get; set; }

        [DataMember(Name = "merged_by")]
        public Sender MergedBy { get; set; }

        [DataMember(Name = "comments")]
        public int Comments { get; set; }

        [DataMember(Name = "review_comments")]
        public int ReviewComments { get; set; }

        [DataMember(Name = "commits")]
        public int Commits { get; set; }

        [DataMember(Name = "additions")]
        public int Additions { get; set; }

        [DataMember(Name = "deletions")]
        public int Deletions { get; set; }

        [DataMember(Name = "changed_files")]
        public int ChangedFiles { get; set; }
    }
}
