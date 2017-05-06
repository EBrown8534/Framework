using Evbpc.Framework.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.StackExchange.API.Models
{
    [DataContract]
    public class Notice : IBaseModel
    {
        [DataMember(Name = "body")]
        public string Body { get; set; }

        [DataMember(Name = "creation_date")]
        public long? CreationDate { get; set; }

        /// <summary>
        /// A .NET DateTime? representing the <see cref="CreationDate"/>.
        /// </summary>
        public DateTime? CreationDateTime
        {
            get { return DateTimeExtensions.FromEpoch(CreationDate); }
            set { CreationDate = DateTimeExtensions.ToEpoch(value); }
        }

        [DataMember(Name = "owner_user_id")]
        public int? OwnerUserId { get; set; }
    }
}
