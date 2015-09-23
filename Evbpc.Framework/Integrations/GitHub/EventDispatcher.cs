using Evbpc.Framework.Integrations.GitHub.Events;
using Evbpc.Framework.Integrations.GitHub.Events.Args;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.GitHub
{
    public class EventDispatcher
    {
        public void Dispatch(string eventKey, string json)
        {
            switch (eventKey)
            {
                case CommitCommentEvent.WebhookEventName:
                    OnCommitCommentReceived(new CommitCommentEventArgs(Deserialze<CommitCommentEvent>(json)));
                    break;
                case CreateEvent.WebhookEventName:
                    OnCreateReceived(new CreateEventArgs(Deserialze<CreateEvent>(json)));
                    break;
                case DeleteEvent.WebhookEventName:
                    OnDeleteReceived(new DeleteEventArgs(Deserialze<DeleteEvent>(json)));
                    break;
                case DeploymentEvent.WebhookEventName:
                    OnDeploymentReceived(new DeploymentEventArgs(Deserialze<DeploymentEvent>(json)));
                    break;
                case DeploymentStatusEvent.WebhookEventName:
                    OnDeploymentStatusReceived(new DeploymentStatusEventArgs(Deserialze<DeploymentStatusEvent>(json)));
                    break;
                case ForkEvent.WebhookEventName:
                    OnForkReceived(new ForkEventArgs(Deserialze<ForkEvent>(json)));
                    break;
                case GollumEvent.WebhookEventName:
                    OnGollumReceived(new GollumEventArgs(Deserialze<GollumEvent>(json)));
                    break;
                case IssueCommentEvent.WebhookEventName:
                    OnIssueCommentReceived(new IssueCommentEventArgs(Deserialze<IssueCommentEvent>(json)));
                    break;
                case IssuesEvent.WebhookEventName:
                    OnIssuesReceived(new IssuesEventArgs(Deserialze<IssuesEvent>(json)));
                    break;
                case MemberEvent.WebhookEventName:
                    OnMemberReceived(new MemberEventArgs(Deserialze<MemberEvent>(json)));
                    break;
                case MembershipEvent.WebhookEventName:
                    OnMembershipReceived(new MembershipEventArgs(Deserialze<MembershipEvent>(json)));
                    break;
                case PageBuildEvent.WebhookEventName:
                    OnPageBuildReceived(new PageBuildEventArgs(Deserialze<PageBuildEvent>(json)));
                    break;
                case PublicEvent.WebhookEventName:
                    OnPublicReceived(new PublicEventArgs(Deserialze<PublicEvent>(json)));
                    break;
                case PullRequestEvent.WebhookEventName:
                    OnPullRequestReceived(new PullRequestEventArgs(Deserialze<PullRequestEvent>(json)));
                    break;
                case PullRequestReviewCommentEvent.WebhookEventName:
                    OnPullRequestReviewCommentReceived(new PullRequestReviewCommentEventArgs(Deserialze<PullRequestReviewCommentEvent>(json)));
                    break;
                case PushEvent.WebhookEventName:
                    OnPushReceived(new PushEventArgs(Deserialze<PushEvent>(json)));
                    break;
                case ReleaseEvent.WebhookEventName:
                    OnReleaseReceived(new ReleaseEventArgs(Deserialze<ReleaseEvent>(json)));
                    break;
                case RepositoryEvent.WebhookEventName:
                    OnRepositoryReceived(new RepositoryEventArgs(Deserialze<RepositoryEvent>(json)));
                    break;
                case StatusEvent.WebhookEventName:
                    OnStatusReceived(new StatusEventArgs(Deserialze<StatusEvent>(json)));
                    break;
                case TeamAddEvent.WebhookEventName:
                    OnTeamAddReceived(new TeamAddEventArgs(Deserialze<TeamAddEvent>(json)));
                    break;
                case WatchEvent.WebhookEventName:
                    OnWatchReceived(new WatchEventArgs(Deserialze<WatchEvent>(json)));
                    break;
            }
        }

        public T Deserialze<T>(string json)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {
                ms.Position = 0;
                return (T)serializer.ReadObject(ms);
            }
        }

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
