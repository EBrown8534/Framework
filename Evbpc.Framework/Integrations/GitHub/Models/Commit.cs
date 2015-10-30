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

        /// <summary>
        /// Whether this commit is distinct from any that have been pushed before.
        /// </summary>
        [DataMember(Name = "distinct")]
        public bool Distinct { get; set; }

        /// <summary>
        /// The commit message.
        /// </summary>
        [DataMember(Name = "message")]
        public string Message { get; set; }

        /// <summary>
        /// The SHA of the commit.
        /// </summary>
        [DataMember(Name = "sha")]
        public string Sha { get; set; }

        [DataMember(Name = "timestamp")]
        public string Timestamp { get; set; }

        /// <summary>
        /// Points to the commit API resource.
        /// </summary>
        [DataMember(Name = "url")]
        public string Url { get; set; }

        /// <summary>
        /// The git author of the commit.
        /// </summary>
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
