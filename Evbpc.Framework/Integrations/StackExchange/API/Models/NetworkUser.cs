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
    public class NetworkUser : IBaseModel
    {
        [DataMember(Name = "account_id")]
        public int AccountId { get; set; }

        [DataMember(Name = "answer_count")]
        public int? AnswerCount { get; set; }

        [DataMember(Name = "badge_counts")]
        public List<BadgeCount> BadgeCounts { get; set; }

        /// <summary>
        /// See <code>creation_date</code>
        /// </summary>
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

        /// <summary>
        /// See <code>last_access_date</code>
        /// </summary>
        [DataMember(Name = "last_access_date")]
        public long? LastAccessDate { get; set; }

        /// <summary>
        /// A .NET DateTime? representing the <see cref="LastAccessDate"/>.
        /// </summary>
        public DateTime? LastAccessDateTime
        {
            get { return DateTimeExtensions.FromEpoch(LastAccessDate); }
            set { LastAccessDate = DateTimeExtensions.ToEpoch(value); }
        }

        [DataMember(Name = "question_count")]
        public int? QuestionCount { get; set; }

        [DataMember(Name = "reputation")]
        public int? Reputation { get; set; }

        [DataMember(Name = "site_name")]
        public string SiteName { get; set; }

        [DataMember(Name = "site_url")]
        public string SiteUrl { get; set; }

        [DataMember(Name = "user_id")]
        public int UserId { get; set; }
    }
}
