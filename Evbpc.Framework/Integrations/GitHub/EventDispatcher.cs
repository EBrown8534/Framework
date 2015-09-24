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
    /// <summary>
    /// A utilitarian class for dispatching GitHub Webhook events.
    /// </summary>
    public class EventDispatcher
    {
        /// <summary>
        /// Determines what event has happened and triggers event as appropriate.
        /// </summary>
        /// <param name="eventKey">The key for the event.</param>
        /// <param name="json">The JSON source for the event.</param>
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

        /// <summary>
        /// Deserializes a JSON string using a <code>DataContractSerializer</code>.
        /// </summary>
        /// <typeparam name="T">The type to deserialize to.</typeparam>
        /// <param name="json">The JSON to deserialize.</param>
        /// <returns>The deserialized JSON to the specified type.</returns>
        public T Deserialze<T>(string json)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {
                ms.Position = 0;
                return (T)serializer.ReadObject(ms);
            }
        }

        /// <summary>
        /// Throws the <see cref="CommitCommentEventReceived"/> event.
        /// </summary>
        /// <param name="e">The <see cref="CommitCommentEventArgs"/> to throw into the event.</param>
        protected void OnCommitCommentReceived(CommitCommentEventArgs e)
        {
            var del = CommitCommentEventReceived;
            del?.Invoke(this, e);
        }
        
        /// <summary>
        /// Throws the <see cref="CreateEventReceived"/> event.
        /// </summary>
        /// <param name="e">The <see cref="CreateEventArgs"/> to throw into the event.</param>
        protected void OnCreateReceived(CreateEventArgs e)
        {
            var del = CreateEventReceived;
            del?.Invoke(this, e);
        }

        /// <summary>
        /// Throws the <see cref="DeleteEventReceived"/> event.
        /// </summary>
        /// <param name="e">The <see cref="DeleteEventArgs"/> to throw into the event.</param>
        protected void OnDeleteReceived(DeleteEventArgs e)
        {
            var del = DeleteEventReceived;
            del?.Invoke(this, e);
        }

        /// <summary>
        /// Throws the <see cref="DeploymentEventReceived"/> event.
        /// </summary>
        /// <param name="e">The <see cref="DeploymentEventArgs"/> to throw into the event.</param>
        protected void OnDeploymentReceived(DeploymentEventArgs e)
        {
            var del = DeploymentEventReceived;
            del?.Invoke(this, e);
        }

        /// <summary>
        /// Throws the <see cref="DeploymentStatusEventReceived"/> event.
        /// </summary>
        /// <param name="e">The <see cref="DeploymentStatusEventArgs"/> to throw into the event.</param>
        protected void OnDeploymentStatusReceived(DeploymentStatusEventArgs e)
        {
            var del = DeploymentStatusEventReceived;
            del?.Invoke(this, e);
        }

        /// <summary>
        /// Throws the <see cref="ForkEventReceived"/> event.
        /// </summary>
        /// <param name="e">The <see cref="ForkEventArgs"/> to throw into the event.</param>
        protected void OnForkReceived(ForkEventArgs e)
        {
            var del = ForkEventReceived;
            del?.Invoke(this, e);
        }

        /// <summary>
        /// Throws the <see cref="GollumEventReceived"/> event.
        /// </summary>
        /// <param name="e">The <see cref="GollumEventArgs"/> to throw into the event.</param>
        protected void OnGollumReceived(GollumEventArgs e)
        {
            var del = GollumEventReceived;
            del?.Invoke(this, e);
        }

        /// <summary>
        /// Throws the <see cref="IssueCommentEventReceived"/> event.
        /// </summary>
        /// <param name="e">The <see cref="IssueCommentEventArgs"/> to throw into the event.</param>
        protected void OnIssueCommentReceived(IssueCommentEventArgs e)
        {
            var del = IssueCommentEventReceived;
            del?.Invoke(this, e);
        }

        /// <summary>
        /// Throws the <see cref="IssuesEventReceived"/> event.
        /// </summary>
        /// <param name="e">The <see cref="IssuesEventArgs"/> to throw into the event.</param>
        protected void OnIssuesReceived(IssuesEventArgs e)
        {
            var del = IssuesEventReceived;
            del?.Invoke(this, e);
        }

        /// <summary>
        /// Throws the <see cref="MemberEventReceived"/> event.
        /// </summary>
        /// <param name="e">The <see cref="MemberEventArgs"/> to throw into the event.</param>
        protected void OnMemberReceived(MemberEventArgs e)
        {
            var del = MemberEventReceived;
            del?.Invoke(this, e);
        }

        /// <summary>
        /// Throws the <see cref="MembershipEventReceived"/> event.
        /// </summary>
        /// <param name="e">The <see cref="MembershipEventArgs"/> to throw into the event.</param>
        protected void OnMembershipReceived(MembershipEventArgs e)
        {
            var del = MembershipEventReceived;
            del?.Invoke(this, e);
        }

        /// <summary>
        /// Throws the <see cref="PageBuildEventReceived"/> event.
        /// </summary>
        /// <param name="e">The <see cref="PageBuildEventArgs"/> to throw into the event.</param>
        protected void OnPageBuildReceived(PageBuildEventArgs e)
        {
            var del = PageBuildEventReceived;
            del?.Invoke(this, e);
        }

        /// <summary>
        /// Throws the <see cref="PublicEventReceived"/> event.
        /// </summary>
        /// <param name="e">The <see cref="PublicEventArgs"/> to throw into the event.</param>
        protected void OnPublicReceived(PublicEventArgs e)
        {
            var del = PublicEventReceived;
            del?.Invoke(this, e);
        }

        /// <summary>
        /// Throws the <see cref="PullRequestEventReceived"/> event.
        /// </summary>
        /// <param name="e">The <see cref="PullRequestEventArgs"/> to throw into the event.</param>
        protected void OnPullRequestReceived(PullRequestEventArgs e)
        {
            var del = PullRequestEventReceived;
            del?.Invoke(this, e);
        }

        /// <summary>
        /// Throws the <see cref="PullRequestReviewCommentEventReceived"/> event.
        /// </summary>
        /// <param name="e">The <see cref="PullRequestReviewCommentEventArgs"/> to throw into the event.</param>
        protected void OnPullRequestReviewCommentReceived(PullRequestReviewCommentEventArgs e)
        {
            var del = PullRequestReviewCommentEventReceived;
            del?.Invoke(this, e);
        }

        /// <summary>
        /// Throws the <see cref="PushEventReceived"/> event.
        /// </summary>
        /// <param name="e">The <see cref="PushEventArgs"/> to throw into the event.</param>
        protected void OnPushReceived(PushEventArgs e)
        {
            var del = PushEventReceived;
            del?.Invoke(this, e);
        }

        /// <summary>
        /// Throws the <see cref="ReleaseEventReceived"/> event.
        /// </summary>
        /// <param name="e">The <see cref="ReleaseEventArgs"/> to throw into the event.</param>
        protected void OnReleaseReceived(ReleaseEventArgs e)
        {
            var del = ReleaseEventReceived;
            del?.Invoke(this, e);
        }

        /// <summary>
        /// Throws the <see cref="RepositoryEventReceived"/> event.
        /// </summary>
        /// <param name="e">The <see cref="RepositoryEventArgs"/> to throw into the event.</param>
        protected void OnRepositoryReceived(RepositoryEventArgs e)
        {
            var del = RepositoryEventReceived;
            del?.Invoke(this, e);
        }

        /// <summary>
        /// Throws the <see cref="StatusEventReceived"/> event.
        /// </summary>
        /// <param name="e">The <see cref="StatusEventArgs"/> to throw into the event.</param>
        protected void OnStatusReceived(StatusEventArgs e)
        {
            var del = StatusEventReceived;
            del?.Invoke(this, e);
        }

        /// <summary>
        /// Throws the <see cref="TeamAddEventReceived"/> event.
        /// </summary>
        /// <param name="e">The <see cref="TeamAddEventArgs"/> to throw into the event.</param>
        protected void OnTeamAddReceived(TeamAddEventArgs e)
        {
            var del = TeamAddEventReceived;
            del?.Invoke(this, e);
        }

        /// <summary>
        /// Throws the <see cref="WatchEventReceived"/> event.
        /// </summary>
        /// <param name="e">The <see cref="WatchEventArgs"/> to throw into the event.</param>
        protected void OnWatchReceived(WatchEventArgs e)
        {
            var del = WatchEventReceived;
            del?.Invoke(this, e);
        }

        /// <summary>
        /// Fired when a <see cref="CommitCommentEvent"/> event is received.
        /// </summary>
        public event EventHandler<CommitCommentEventArgs> CommitCommentEventReceived;

        /// <summary>
        /// Fires when a <see cref="CreateEvent"/> is received.
        /// </summary>
        public event EventHandler<CreateEventArgs> CreateEventReceived;

        /// <summary>
        /// Fires when a <see cref="DeleteEvent"/> is received.
        /// </summary>
        public event EventHandler<DeleteEventArgs> DeleteEventReceived;

        /// <summary>
        /// Fires when a <see cref="DeploymentEvent"/> is received.
        /// </summary>
        public event EventHandler<DeploymentEventArgs> DeploymentEventReceived;

        /// <summary>
        /// Fires when a <see cref="DeploymentStatusEvent"/> is received.
        /// </summary>
        public event EventHandler<DeploymentStatusEventArgs> DeploymentStatusEventReceived;

        /// <summary>
        /// Fires when a <see cref="ForkEvent"/> is received.
        /// </summary>
        public event EventHandler<ForkEventArgs> ForkEventReceived;

        /// <summary>
        /// Fires when a <see cref="GollumEvent"/> is received.
        /// </summary>
        public event EventHandler<GollumEventArgs> GollumEventReceived;

        /// <summary>
        /// Fires when a <see cref="IssueCommentEvent"/> is received.
        /// </summary>
        public event EventHandler<IssueCommentEventArgs> IssueCommentEventReceived;

        /// <summary>
        /// Fires when a <see cref="IssuesEvent"/> is received.
        /// </summary>
        public event EventHandler<IssuesEventArgs> IssuesEventReceived;

        /// <summary>
        /// Fires when a <see cref="MemberEvent"/> is received.
        /// </summary>
        public event EventHandler<MemberEventArgs> MemberEventReceived;

        /// <summary>
        /// Fires when a <see cref="MemberEvent"/> is received.
        /// </summary>
        public event EventHandler<MembershipEventArgs> MembershipEventReceived;

        /// <summary>
        /// Fires when a <see cref="PageBuildEvent"/> is received.
        /// </summary>
        public event EventHandler<PageBuildEventArgs> PageBuildEventReceived;

        /// <summary>
        /// Fires when a <see cref="PublicEvent"/> is received.
        /// </summary>
        public event EventHandler<PublicEventArgs> PublicEventReceived;

        /// <summary>
        /// Fires when a <see cref="PullRequestEvent"/> is received.
        /// </summary>
        public event EventHandler<PullRequestEventArgs> PullRequestEventReceived;

        /// <summary>
        /// Fires when a <see cref="PullRequestReviewCommentEvent"/> is received.
        /// </summary>
        public event EventHandler<PullRequestReviewCommentEventArgs> PullRequestReviewCommentEventReceived;

        /// <summary>
        /// Fires when a <see cref="PushEvent"/> is received.
        /// </summary>
        public event EventHandler<PushEventArgs> PushEventReceived;

        /// <summary>
        /// Fires when a <see cref="ReleaseEvent"/> is received.
        /// </summary>
        public event EventHandler<ReleaseEventArgs> ReleaseEventReceived;

        /// <summary>
        /// Fires when a <see cref="RepositoryEvent"/> is received.
        /// </summary>
        public event EventHandler<RepositoryEventArgs> RepositoryEventReceived;

        /// <summary>
        /// Fires when a <see cref="StatusEvent"/> is received.
        /// </summary>
        public event EventHandler<StatusEventArgs> StatusEventReceived;

        /// <summary>
        /// Fires when a <see cref="TeamAddEvent"/> is received.
        /// </summary>
        public event EventHandler<TeamAddEventArgs> TeamAddEventReceived;

        /// <summary>
        /// Fires when a <see cref="WatchEvent"/> is received.
        /// </summary>
        public event EventHandler<WatchEventArgs> WatchEventReceived;
    }
}
