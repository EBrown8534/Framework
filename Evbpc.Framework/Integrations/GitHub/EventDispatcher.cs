using Evbpc.Framework.Integrations.GitHub.Events.Args;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.GitHub
{
    public class EventDispatcher
    {
        protected void OnCommitCommentReceived(CommitCommentEventArgs e)
        {
            var del = CommitCommentEventReceived;
            del?.Invoke(this, e);
        }

        protected void OnCreateReceived(CreateEventArgs e)
        {
            var del = CreateEventReceived;
            del?.Invoke(this, e);
        }

        protected void OnDeleteReceived(DeleteEventArgs e)
        {
            var del = DeleteEventReceived;
            del?.Invoke(this, e);
        }

        protected void OnDeploymentReceived(DeploymentEventArgs e)
        {
            var del = DeploymentEventReceived;
            del?.Invoke(this, e);
        }

        protected void OnDeploymentStatusReceived(DeploymentStatusEventArgs e)
        {
            var del = DeploymentStatusEventReceived;
            del?.Invoke(this, e);
        }

        protected void OnForkReceived(ForkEventArgs e)
        {
            var del = ForkEventReceived;
            del?.Invoke(this, e);
        }

        protected void OnGollumReceived(GollumEventArgs e)
        {
            var del = GollumEventReceived;
            del?.Invoke(this, e);
        }

        protected void OnIssueCommentReceived(IssueCommentEventArgs e)
        {
            var del = IssueCommentEventReceived;
            del?.Invoke(this, e);
        }

        protected void OnIssuesReceived(IssuesEventArgs e)
        {
            var del = IssuesEventReceived;
            del?.Invoke(this, e);
        }

        protected void OnMemberReceived(MemberEventArgs e)
        {
            var del = MemberEventReceived;
            del?.Invoke(this, e);
        }

        protected void OnMembershipReceived(MembershipEventArgs e)
        {
            var del = MembershipEventReceived;
            del?.Invoke(this, e);
        }

        protected void OnPageBuildReceived(PageBuildEventArgs e)
        {
            var del = PageBuildEventReceived;
            del?.Invoke(this, e);
        }

        protected void OnPublicReceived(PublicEventArgs e)
        {
            var del = PublicEventReceived;
            del?.Invoke(this, e);
        }

        protected void OnPullRequestReceived(PullRequestEventArgs e)
        {
            var del = PullRequestEventReceived;
            del?.Invoke(this, e);
        }

        protected void OnPullRequestReviewCommentReceived(PullRequestReviewCommentEventArgs e)
        {
            var del = PullRequestReviewCommentEventReceived;
            del?.Invoke(this, e);
        }

        protected void OnPushReceived(PushEventArgs e)
        {
            var del = PushEventReceived;
            del?.Invoke(this, e);
        }

        protected void OnReleaseReceived(ReleaseEventArgs e)
        {
            var del = ReleaseEventReceived;
            del?.Invoke(this, e);
        }

        protected void OnRepositoryReceived(RepositoryEventArgs e)
        {
            var del = RepositoryEventReceived;
            del?.Invoke(this, e);
        }

        protected void OnStatusReceived(StatusEventArgs e)
        {
            var del = StatusEventReceived;
            del?.Invoke(this, e);
        }

        protected void OnTeamAddReceived(TeamAddEventArgs e)
        {
            var del = TeamAddEventReceived;
            del?.Invoke(this, e);
        }

        protected void OnWatchReceived(WatchEventArgs e)
        {
            var del = WatchEventReceived;
            del?.Invoke(this, e);
        }

        public event EventHandler<CommitCommentEventArgs> CommitCommentEventReceived;
        public event EventHandler<CreateEventArgs> CreateEventReceived;
        public event EventHandler<DeleteEventArgs> DeleteEventReceived;
        public event EventHandler<DeploymentEventArgs> DeploymentEventReceived;
        public event EventHandler<DeploymentStatusEventArgs> DeploymentStatusEventReceived;
        public event EventHandler<ForkEventArgs> ForkEventReceived;
        public event EventHandler<GollumEventArgs> GollumEventReceived;
        public event EventHandler<IssueCommentEventArgs> IssueCommentEventReceived;
        public event EventHandler<IssuesEventArgs> IssuesEventReceived;
        public event EventHandler<MemberEventArgs> MemberEventReceived;
        public event EventHandler<MembershipEventArgs> MembershipEventReceived;
        public event EventHandler<PageBuildEventArgs> PageBuildEventReceived;
        public event EventHandler<PublicEventArgs> PublicEventReceived;
        public event EventHandler<PullRequestEventArgs> PullRequestEventReceived;
        public event EventHandler<PullRequestReviewCommentEventArgs> PullRequestReviewCommentEventReceived;
        public event EventHandler<PushEventArgs> PushEventReceived;
        public event EventHandler<ReleaseEventArgs> ReleaseEventReceived;
        public event EventHandler<RepositoryEventArgs> RepositoryEventReceived;
        public event EventHandler<StatusEventArgs> StatusEventReceived;
        public event EventHandler<TeamAddEventArgs> TeamAddEventReceived;
        public event EventHandler<WatchEventArgs> WatchEventReceived;
    }
}
