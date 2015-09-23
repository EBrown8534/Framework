using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.GitHub.Models
{
    [DataContract]
    public class Commit
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "distinct")]
        public bool Distinct { get; set; }

        [DataMember(Name = "message")]
        public string Message { get; set; }

        [DataMember(Name = "timestamp")]
        public string Timestamp { get; set; }

        [DataMember(Name = "url")]
        public string Url { get; set; }

        [DataMember(Name = "author")]
        public Author Author { get; set; }

        [DataMember(Name = "committer")]
        public Author Committer { get; set; }

        [DataMember(Name = "added")]
        public List<string> Added { get; set; }

        [DataMember(Name = "removed")]
        public List<string> Removed { get; set; }

        [DataMember(Name = "modified")]
        public List<string> Modified { get; set; }
    }
}
