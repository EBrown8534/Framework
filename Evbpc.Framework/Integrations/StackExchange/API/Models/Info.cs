using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.StackExchange.API.Models
{
    /// <summary>
    /// Represents certain statistical data about a Stack Exchange <see cref="Site"/>.
    /// </summary>
    /// <remarks>
    /// http://api.stackexchange.com/docs/types/info
    /// </remarks>
    [DataContract]
    public class Info
    {
        /// <summary>
        /// See <code>answers_per_minute</code>
        /// </summary>
        [DataMember(Name = "answers_per_minute")]
        public decimal AnswersPerMinute { get; set; }

        /// <summary>
        /// See <code>api_revision</code>
        /// </summary>
        [DataMember(Name = "api_revision")]
        public string ApiRevision { get; set; }

        /// <summary>
        /// See <code>badges_per_minute</code>
        /// </summary>
        [DataMember(Name = "badges_per_minute")]
        public decimal BadgesPerMinute { get; set; }

        /// <summary>
        /// See <code>new_active_users</code>
        /// </summary>
        [DataMember(Name = "new_active_users")]
        public int NewActiveUsers { get; set; }

        /// <summary>
        /// See <code>questions_per_minute</code>
        /// </summary>
        [DataMember(Name = "questions_per_minute")]
        public decimal QuestionsPerMinute { get; set; }

        /// <summary>
        /// See <code>total_accepted</code>
        /// </summary>
        [DataMember(Name = "total_accepted")]
        public int TotalAccepted { get; set; }

        /// <summary>
        /// See <code>total_answers</code>
        /// </summary>
        [DataMember(Name = "total_answers")]
        public int TotalAnswers { get; set; }

        /// <summary>
        /// See <code>total_badges</code>
        /// </summary>
        [DataMember(Name = "total_badges")]
        public int TotalBadges { get; set; }

        /// <summary>
        /// See <code>total_comments</code>
        /// </summary>
        [DataMember(Name = "total_comments")]
        public int TotalComments { get; set; }

        /// <summary>
        /// See <code>total_questions</code>
        /// </summary>
        [DataMember(Name = "total_questions")]
        public int TotalQuestions { get; set; }

        /// <summary>
        /// See <code>total_unanswered</code>
        /// </summary>
        [DataMember(Name = "total_unanswered")]
        public int TotalUnanswered { get; set; }

        /// <summary>
        /// See <code>total_users</code>
        /// </summary>
        [DataMember(Name = "total_users")]
        public int TotalUsers { get; set; }

        /// <summary>
        /// See <code>total_votes</code>
        /// </summary>
        [DataMember(Name = "total_votes")]
        public int TotalVotes { get; set; }
    }
}
