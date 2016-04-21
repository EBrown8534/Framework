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
    /// Represents an answer from the Stack Exchange API.
    /// </summary>
    /// <remarks>
    /// http://api.stackexchange.com/docs/types/answer
    /// </remarks>
    [DataContract]
    public class Answer : IBaseModel
    {
        /// <summary>
        /// See <code>accepted</code>
        /// </summary>
        [DataMember(Name = "accepted")]
        public bool? Accepted { get; set; }

        /// <summary>
        /// See <code>answer_id</code>
        /// </summary>
        [DataMember(Name = "answer_id")]
        public int AnswerId { get; set; }

        /// <summary>
        /// See <code>awarded_bounty_amount</code>
        /// </summary>
        [DataMember(Name = "awarded_bounty_amount")]
        public int? AwardedBountyAmount { get; set; }

        /// <summary>
        /// See <code>awarded_bouny_users</code>
        /// </summary>
        [DataMember(Name = "awarded_bouny_users")]
        public List<ShallowUser> AwardedBountyUsers { get; set; }

        /// <summary>
        /// See <code>body</code>
        /// </summary>
        [DataMember(Name = "body")]
        public string Body { get; set; }

        /// <summary>
        /// See <code>body_markdown</code>
        /// </summary>
        [DataMember(Name = "body_markdown")]
        public string BodyMarkdown { get; set; }

        /// <summary>
        /// See <code>can_flag</code>
        /// </summary>
        [DataMember(Name = "can_flag")]
        public bool? CanFlag { get; set; }

        /// <summary>
        /// See <code>comment_count</code>
        /// </summary>
        [DataMember(Name = "comment_count")]
        public int? CommentCount { get; set; }

        /// <summary>
        /// See <code>comments</code>
        /// </summary>
        [DataMember(Name = "comments")]
        public List<Comment> Comments { get; set; }

        /// <summary>
        /// See <code>community_owned_date</code>
        /// </summary>
        [DataMember(Name = "community_owned_date")]
        public long? CommunityOwnedDate { get; set; }

        /// <summary>
        /// A .NET DateTime? representing the <see cref="CommunityOwnedDate"/>.
        /// </summary>
        public DateTime? CommunityOwnedDateTime
        {
            get { return DateTimeExtensions.FromEpoch(CommunityOwnedDate); }
            set { CommunityOwnedDate = DateTimeExtensions.ToEpoch(value); }
        }

        /// <summary>
        /// See <code>creation_date</code>
        /// </summary>
        [DataMember(Name = "creation_date")]
        public long CreationDate { get; set; }

        /// <summary>
        /// A .NET DateTime representing the <see cref="CreationDate"/>.
        /// </summary>
        public DateTime CreationDateTime
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
        /// See <code>downvoted</code>
        /// </summary>
        [DataMember(Name = "downvoted")]
        public bool? Downvoted { get; set; }

        /// <summary>
        /// See <code>is_accepted</code>
        /// </summary>
        [DataMember(Name = "is_accepted")]
        public bool IsAccepted { get; set; }

        /// <summary>
        /// See <code>last_activity_date</code>
        /// </summary>
        [DataMember(Name = "last_activity_date")]
        public long LastActivityDate { get; set; }

        /// <summary>
        /// A .NET DateTime representing the <see cref="LastActivityDate"/>.
        /// </summary>
        public DateTime LastActivityDateTime
        {
            get { return DateTimeExtensions.FromEpoch(LastActivityDate); }
            set { LastActivityDate = DateTimeExtensions.ToEpoch(value); }
        }

        /// <summary>
        /// See <code>last_edit_date</code>
        /// </summary>
        [DataMember(Name = "last_edit_date")]
        public long? LastEditDate { get; set; }

        /// <summary>
        /// A .NET DateTime? representing the <see cref="LastEditDate"/>.
        /// </summary>
        public DateTime? LastEditDateTime
        {
            get { return DateTimeExtensions.FromEpoch(LastEditDate); }
            set { LastEditDate = DateTimeExtensions.ToEpoch(value); }
        }

        /// <summary>
        /// See <code>last_editor</code>
        /// </summary>
        [DataMember(Name = "last_editor")]
        public ShallowUser LastEditor { get; set; }

        /// <summary>
        /// See <code>link</code>
        /// </summary>
        [DataMember(Name = "link")]
        public string Link { get; set; }

        /// <summary>
        /// See <code>locked_date</code>
        /// </summary>
        [DataMember(Name = "locked_date")]
        public long? LockedDate { get; set; }

        /// <summary>
        /// A .NET DateTime? representing the <see cref="LockedDate"/>.
        /// </summary>
        public DateTime? LockedDateTime
        {
            get { return DateTimeExtensions.FromEpoch(LockedDate); }
            set { LockedDate = DateTimeExtensions.ToEpoch(value); }
        }

        /// <summary>
        /// See <code>owner</code>
        /// </summary>
        [DataMember(Name = "owner")]
        public ShallowUser Owner { get; set; }

        /// <summary>
        /// See <code>question_id</code>
        /// </summary>
        [DataMember(Name = "question_id")]
        public int QuestionId { get; set; }

        /// <summary>
        /// See <code>score</code>
        /// </summary>
        [DataMember(Name = "score")]
        public int Score { get; set; }

        /// <summary>
        /// See <code>share_link</code>
        /// </summary>
        [DataMember(Name = "share_link")]
        public string ShareLink { get; set; }

        /// <summary>
        /// See <code>rags</code>
        /// </summary>
        [DataMember(Name = "tags")]
        public List<string> Tags { get; set; }

        /// <summary>
        /// See <code>title</code>
        /// </summary>
        [DataMember(Name = "title")]
        public string Title { get; set; }

        /// <summary>
        /// See <code>up_vote_count</code>
        /// </summary>
        [DataMember(Name = "up_vote_count")]
        public int? UpVoteCount { get; set; }

        /// <summary>
        /// See <code>upvoted</code>
        /// </summary>
        [DataMember(Name = "upvoted")]
        public bool? Upvoted { get; set; }
    }
}
