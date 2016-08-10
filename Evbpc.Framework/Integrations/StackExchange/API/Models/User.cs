using Evbpc.Framework.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.StackExchange.API.Models
{
    /// <summary>
    /// Represents a user on the Stack Exchange API.
    /// </summary>
    /// <remarks>
    /// http://api.stackexchange.com/docs/types/user
    /// </remarks>
    [DataContract]
    public class User : ShallowUser, IBaseModel
    {
        /// <summary>
        /// See <code>about_me</code>
        /// </summary>
        [DataMember(Name = "about_me")]
        public string AboutMe { get; set; }

        /// <summary>
        /// See <code>account_id</code>
        /// </summary>
        [DataMember(Name = "account_id")]
        public int AccountId { get; set; }

        /// <summary>
        /// See <code>age</code>
        /// </summary>
        [DataMember(Name = "age")]
        public int? Age { get; set; }

        /// <summary>
        /// See <code>answer_count</code>
        /// </summary>
        [DataMember(Name = "answer_count")]
        public int? AnswerCount { get; set; }

        /// <summary>
        /// See <code>badge_counts</code>
        /// </summary>
        [DataMember(Name = "badge_counts")]
        public BadgeCount BadgeCounts { get; set; }

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
        /// See <code>down_vote_count</code>
        /// </summary>
        [DataMember(Name = "down_vote_count")]
        public int? DownVoteCount { get; set; }

        /// <summary>
        /// See <code>is_employee</code>
        /// </summary>
        [DataMember(Name = "is_employee")]
        public bool IsEmployee { get; set; }

        /// <summary>
        /// See <code>last_access_date</code>
        /// </summary>
        [DataMember(Name = "last_access_date")]
        public long LastAccessDate { get; set; }

        /// <summary>
        /// A .NET DateTime? representing the <see cref="LastAccessDate"/>.
        /// </summary>
        public DateTime LastAccessDateTime
        {
            get { return DateTimeExtensions.FromEpoch(LastAccessDate); }
            set { LastAccessDate = DateTimeExtensions.ToEpoch(value); }
        }

        /// <summary>
        /// See <code>last_modified_date</code>
        /// </summary>
        [DataMember(Name = "last_modified_date")]
        public long? LastModifiedDate { get; set; }

        /// <summary>
        /// A .NET DateTime? representing the <see cref="LastModifiedDate"/>.
        /// </summary>
        public DateTime? LastModifiedDateTime
        {
            get { return DateTimeExtensions.FromEpoch(LastModifiedDate); }
            set { LastModifiedDate = DateTimeExtensions.ToEpoch(value); }
        }

        /// <summary>
        /// See <code>location</code>
        /// </summary>
        [DataMember(Name = "location")]
        public string Location { get; set; }

        /// <summary>
        /// See <code>question_count</code>
        /// </summary>
        [DataMember(Name = "question_count")]
        public int? QuestionCount { get; set; }

        /// <summary>
        /// See <code>reputation_change_day</code>
        /// </summary>
        [DataMember(Name = "reputation_change_day")]
        public int ReputationChangeDay { get; set; }

        /// <summary>
        /// See <code>reputation_change_month</code>
        /// </summary>
        [DataMember(Name = "reputation_change_month")]
        public int ReputationChangeMonth { get; set; }

        /// <summary>
        /// See <code>reputation_change_quarter</code>
        /// </summary>
        [DataMember(Name = "reputation_change_quarter")]
        public int ReputationChangeQuarter { get; set; }

        /// <summary>
        /// See <code>reputation_change_week</code>
        /// </summary>
        [DataMember(Name = "reputation_change_week")]
        public int ReputationChangeWeek { get; set; }

        /// <summary>
        /// See <code>reputation_change_year</code>
        /// </summary>
        [DataMember(Name = "reputation_change_year")]
        public int ReputationChangeYear { get; set; }

        /// <summary>
        /// See <code>timed_penalty_date</code>
        /// </summary>
        [DataMember(Name = "timed_penalty_date")]
        public long? TimedPenaltyDate { get; set; }

        /// <summary>
        /// A .NET DateTime? representing the <see cref="TimedPenaltyDate"/>.
        /// </summary>
        public DateTime? TimedPenaltyDateTime
        {
            get { return DateTimeExtensions.FromEpoch(TimedPenaltyDate); }
            set { TimedPenaltyDate = DateTimeExtensions.ToEpoch(value); }
        }

        /// <summary>
        /// See <code>up_vote_count</code>
        /// </summary>
        [DataMember(Name = "up_vote_count")]
        public int? UpVoteCount { get; set; }

        /// <summary>
        /// See <code>view_count</code>
        /// </summary>
        [DataMember(Name = "view_count")]
        public int? ViewCount { get; set; }

        /// <summary>
        /// See <code>website_url</code>
        /// </summary>
        [DataMember(Name = "website_url")]
        public string WebsiteUrl { get; set; }
    }
}
