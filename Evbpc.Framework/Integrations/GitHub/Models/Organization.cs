using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.GitHub.Models
{
    [DataContract]
    public class Organization
    {
        [DataMember(Name = "login")]
        public string Login { get; set; }

        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "url")]
        public string Url { get; set; }

        [DataMember(Name = "repos_url")]
        public string ReposUrl { get; set; }

        [DataMember(Name = "events_url")]
        public string EventsUrl { get; set; }

        [DataMember(Name = "members_url")]
        public string MembersUrl { get; set; }

        [DataMember(Name = "public_members_url")]
        public string PublicMembersUrl { get; set; }

        [DataMember(Name = "avatar_url")]
        public string AvatarUrl { get; set; }
    }
}
