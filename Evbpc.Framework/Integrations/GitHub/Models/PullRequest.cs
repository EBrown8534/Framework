using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.GitHub.Models
{
    [DataContract]
    public class PullRequest
    {
        [DataMember(Name = "url")]
        public string Url { get; set; }

        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "html_url")]
        public string HtmlUrl { get; set; }

        [DataMember(Name = "diff_url")]
        public string DiffUrl { get; set; }

        [DataMember(Name = "patch_url")]
        public string PatchUrl { get; set; }

        [DataMember(Name = "issue_url")]
        public string IssueUrl { get; set; }

        [DataMember(Name = "number")]
        public int Number { get; set; }

        [DataMember(Name = "state")]
        public string State { get; set; }

        [DataMember(Name = "locked")]
        public bool Locked { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "user")]
        public Sender User { get; set; }

        [DataMember(Name = "body")]
        public string Body { get; set; }

        [DataMember(Name = "created_at")]
        public string CreatedAt { get; set; }

        [DataMember(Name = "updated_at")]
        public string UpdatedAt { get; set; }

        [DataMember(Name = "closed_at")]
        public string ClosedAt { get; set; }

        [DataMember(Name = "merged_at")]
        public string MergedAt { get; set; }

        [DataMember(Name = "merge_commit_sha")]
        public string MergeCommitSha { get; set; }

        [DataMember(Name = "assignee")]
        public string Assignee { get; set; }

        [DataMember(Name = "milestone")]
        public object Milestone { get; set; }

        [DataMember(Name = "commits_url")]
        public string CommitsUrl { get; set; }

        [DataMember(Name = "review_comments_url")]
        public string ReviewCommentsUrl { get; set; }

        [DataMember(Name = "review_comment_url")]
        public string ReviewCommentUrl { get; set; }

        [DataMember(Name = "comments_url")]
        public string CommentsUrl { get; set; }

        [DataMember(Name = "statuses_url")]
        public string StatusesUrl { get; set; }

        [DataMember(Name = "head")]
        public Head Head { get; set; }

        [DataMember(Name = "base")]
        public Base Base { get; set; }

        [DataMember(Name = "_links")]
        public Links Links { get; set; }

        [DataMember(Name = "repository")]
        public Repository Repository { get; set; }

        [DataMember(Name = "sender")]
        public Sender Sender { get; set; }
    }
}
