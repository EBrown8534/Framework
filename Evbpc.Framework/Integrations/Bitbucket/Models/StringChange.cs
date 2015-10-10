using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.Bitbucket.Models
{
    [DataContract]
    public class StringChange
    {
        [DataMember(Name = "old")]
        public string Old { get; set; }

        [DataMember(Name = "new")]
        public string New { get; set; }
    }
}
