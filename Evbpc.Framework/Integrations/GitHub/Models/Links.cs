using System.Runtime.Serialization;

namespace Evbpc.Framework.Integrations.GitHub.Models
{
    [DataContract]
    public class Links
    {
        [DataMember(Name = "self")]
        public string Self { get; set; }

        [DataMember(Name = "html")]
        public string Html { get; set; }

        [DataMember(Name = "issue")]
        public string Issue { get; set; }

        [DataMember(Name = "comments")]
        public string Comments { get; set; }

        [DataMember(Name = "review_comments")]
        public string ReviewComments { get; set; }

        [DataMember(Name = "review_comment")]
        public string ReviewComment { get; set; }

        [DataMember(Name = "commits")]
        public string Commits { get; set; }

        [DataMember(Name = "statuses")]
        public string Statuses { get; set; }
    }
}