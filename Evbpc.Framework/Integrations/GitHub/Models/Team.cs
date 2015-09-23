using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.GitHub.Models
{
    [DataContract]
    public class Team
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "slug")]
        public string Slug { get; set; }

        [DataMember(Name = "permission")]
        public string Permission { get; set; }

        [DataMember(Name = "url")]
        public string Url { get; set; }

        [DataMember(Name = "members_url")]
        public string MembersUrl { get; set; }

        [DataMember(Name = "repositories_url")]
        public string RepositoriesUrl { get; set; }
    }
}
