using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.StackExchange.API.Models
{
    [DataContract]
    public class ClosedDetails : IBaseModel
    {
        [DataMember(Name = "by_users")]
        public List<ShallowUser> ByUsers { get; set; }
        
        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "on_hold")]
        public bool? OnHold { get; set; }

        [DataMember(Name = "original_questions")]
        public List<OriginalQuestion> OriginalQuestions { get; set; }

        [DataMember(Name = "reason")]
        public string Reason { get; set; }
    }
}
