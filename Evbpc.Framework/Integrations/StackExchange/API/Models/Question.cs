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
    public class Question : IBaseModel
    {
        [DataMember(Name = "accepted_answer_id")]
        public int? AcceptedAnswerId { get; set; }

        [DataMember(Name = "answer_count")]
        public int? AnswerCount { get; set; }

        [DataMember(Name = "answers")]
        public List<Answer> Answers { get; set; }

        [DataMember(Name = "body")]
        public string Body { get; set; }

        [DataMember(Name = "body_markdown")]
        public string BodyMarkdown { get; set; }

        [DataMember(Name = "bounty_amount")]
        public int? BountyAmount { get; set; }

        [DataMember(Name = "bounty_closes_date")]
        public long? BountyClosesDate { get; set; }

        /// <summary>
        /// A .NET DateTime? representing the <see cref="BountyClosesDate"/>.
        /// </summary>
        public DateTime? BountyClosesDateTime
        {
            get { return DateTimeExtensions.FromEpoch(BountyClosesDate); }
            set { BountyClosesDate = DateTimeExtensions.ToEpoch(value); }
        }

        [DataMember(Name = "bounty_user")]
        public ShallowUser BountyUser { get; set; }

        [DataMember(Name = "can_close")]
        public bool? CanClose { get; set; }

        [DataMember(Name = "can_flag")]
        public bool? CanFlag { get; set; }

        [DataMember(Name = "close_vote_count")]
        public int? CloseVoteCount { get; set; } 

        [DataMember(Name = "closed_date")]
        public long? ClosedDate { get; set; }

        /// <summary>
        /// A .NET DateTime? representing the <see cref="ClosedDate"/>.
        /// </summary>
        public DateTime? ClosedDateTime
        {
            get { return DateTimeExtensions.FromEpoch(ClosedDate); }
            set { ClosedDate = DateTimeExtensions.ToEpoch(value); }
        }

        [DataMember(Name = "closed_details")]
        public ClosedDetails ClosedDetails { get; set; }

        [DataMember(Name = "closed_reason")]
        public string ClosedReason { get; set; }

        [DataMember(Name = "comment_count")]
        public int? CommentCount { get; set; }

        [DataMember(Name = "comments")]
        public List<Comment> Comments { get; set; }

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

        [DataMember(Name = "delete_vote_count")]
        public int? DeleteVoteCount { get; set; }

        [DataMember(Name = "down_vote_count")]
        public int? DownVoteCount { get; set; }

        [DataMember(Name = "downvoted")]
        public bool? Downvoted { get; set; }

        [DataMember(Name = "favorite_count")]
        public int? FavoriteCount { get; set; }

        [DataMember(Name = "favorited")]
        public bool? Favorited { get; set; }

        [DataMember(Name = "is_answered")]
        public bool? IsAnswered { get; set; }

        [DataMember(Name = "last_activity_date")]
        public long? LastActivityDate { get; set; }

        /// <summary>
        /// A .NET DateTime? representing the <see cref="LastActivityDate"/>.
        /// </summary>
        public DateTime? LastActivityDateTime
        {
            get { return DateTimeExtensions.FromEpoch(LastActivityDate); }
            set { LastActivityDate = DateTimeExtensions.ToEpoch(value); }
        }

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

        [DataMember(Name = "last_editor")]
        public ShallowUser LastEditor { get; set; }

        [DataMember(Name = "link")]
        public string Link { get; set; }

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

        [DataMember(Name = "migrated_from")]
        public MigrationInfo MigratedFrom { get; set; }

        [DataMember(Name = "migrated_to")]
        public MigrationInfo MigratedTo { get; set; }

        [DataMember(Name = "notice")]
        public Notice Notice { get; set; }

        [DataMember(Name = "owner")]
        public ShallowUser Owner { get; set; }

        [DataMember(Name = "protected_date")]
        public long? ProtectedDate { get; set; }

        /// <summary>
        /// A .NET DateTime? representing the <see cref="ProtectedDate"/>.
        /// </summary>
        public DateTime? ProtectedDateTime
        {
            get { return DateTimeExtensions.FromEpoch(ProtectedDate); }
            set { ProtectedDate = DateTimeExtensions.ToEpoch(value); }
        }

        [DataMember(Name = "question_id")]
        public int? QuestionId { get; set; }

        [DataMember(Name = "reopen_vote_count")]
        public int? ReopenVoteCount { get; set; }

        [DataMember(Name = "score")]
        public int? Score { get; set; }

        [DataMember(Name = "share_link")]
        public string ShareLink { get; set; }

        [DataMember(Name = "tags")]
        public List<string> Tags { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "up_vote_count")]
        public int? UpVoteCount { get; set; }

        [DataMember(Name = "upvoted")]
        public bool? Upvoted { get; set; }

        [DataMember(Name = "view_count")]
        public int? ViewCount { get; set; }
    }
}
