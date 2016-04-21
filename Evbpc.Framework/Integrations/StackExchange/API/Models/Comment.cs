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
    /// Represents a Stack Exchange comment.
    /// </summary>
    /// <remarks>
    /// http://api.stackexchange.com/docs/types/comment
    /// </remarks>
    [DataContract]
    public class Comment
    {
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
        /// See <code>comment_id</code>
        /// </summary>
        [DataMember(Name = "comment_id")]
        public int CommentId { get; set; }

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
        /// See <code>edited</code>
        /// </summary>
        [DataMember(Name = "edited")]
        public bool Edited { get; set; }

        /// <summary>
        /// See <code>link</code>
        /// </summary>
        [DataMember(Name = "link")]
        public string Link { get; set; }

        /// <summary>
        /// See <code>owner</code>
        /// </summary>
        [DataMember(Name = "owner")]
        public ShallowUser Owner { get; set; }

        /// <summary>
        /// See <code>post_id</code>
        /// </summary>
        [DataMember(Name = "post_id")]
        public int PostId { get; set; }

        /// <summary>
        /// See <code>post_type</code>
        /// </summary>
        [DataMember(Name = "post_type")]
        public string PostType { get; set; }

        /// <summary>
        /// See <code>reply_to_user</code>
        /// </summary>
        [DataMember(Name = "reply_to_user")]
        public ShallowUser ReplyToUser { get; set; }

        /// <summary>
        /// See <code>score</code>
        /// </summary>
        [DataMember(Name = "score")]
        public int Score { get; set; }

        /// <summary>
        /// See <code>upvoted</code>
        /// </summary>
        [DataMember(Name = "upvoted")]
        public bool? Upvoted { get; set; }
    }
}
