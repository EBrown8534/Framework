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
    public class MigrationInfo : IBaseModel
    {
        [DataMember(Name = "on_date")]
        public long? OnDate { get; set; }

        /// <summary>
        /// A .NET DateTime? representing the <see cref="OnDate"/>.
        /// </summary>
        public DateTime? OnDateTime
        {
            get { return DateTimeExtensions.FromEpoch(OnDate); }
            set { OnDate = DateTimeExtensions.ToEpoch(value); }
        }

        [DataMember(Name = "site")]
        public Site OtherSite { get; set; }

        [DataMember(Name = "question_id")]
        public int? QuestionId { get; set; }
    }
}
