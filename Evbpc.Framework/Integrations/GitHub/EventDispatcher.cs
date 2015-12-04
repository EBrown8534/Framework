using Evbpc.Framework.Integrations.GitHub.Events;
using Evbpc.Framework.Utilities.Serialization;
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
    public class EventDispatcher : IEventDispatcher
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
                    OnCommitCommentReceived(new EventArgs<CommitCommentEvent>(DataContractJsonSerialization.Deserialze<CommitCommentEvent>(json)));
                    break;
                case CreateEvent.WebhookEventName:
                    OnCreateReceived(new EventArgs<CreateEvent>(DataContractJsonSerialization.Deserialze<CreateEvent>(json)));
                    break;
                case DeleteEvent.WebhookEventName:
                    OnDeleteReceived(new EventArgs<DeleteEvent>(DataContractJsonSerialization.Deserialze<DeleteEvent>(json)));
                    break;
                case DeploymentEvent.WebhookEventName:
                    OnDeploymentReceived(new EventArgs<DeploymentEvent>(DataContractJsonSerialization.Deserialze<DeploymentEvent>(json)));
                    break;
                case DeploymentStatusEvent.WebhookEventName:
                    OnDeploymentStatusReceived(new EventArgs<DeploymentStatusEvent>(DataContractJsonSerialization.Deserialze<DeploymentStatusEvent>(json)));
                    break;
                case ForkEvent.WebhookEventName:
                    OnForkReceived(new EventArgs<ForkEvent>(DataContractJsonSerialization.Deserialze<ForkEvent>(json)));
                    break;
                case GollumEvent.WebhookEventName:
                    OnGollumReceived(new EventArgs<GollumEvent>(DataContractJsonSerialization.Deserialze<GollumEvent>(json)));
                    break;
                case IssueCommentEvent.WebhookEventName:
                    OnIssueCommentReceived(new EventArgs<IssueCommentEvent>(DataContractJsonSerialization.Deserialze<IssueCommentEvent>(json)));
                    break;
                case IssuesEvent.WebhookEventName:
                    OnIssuesReceived(new EventArgs<IssuesEvent>(DataContractJsonSerialization.Deserialze<IssuesEvent>(json)));
                    break;
                case MemberEvent.WebhookEventName:
                    OnMemberReceived(new EventArgs<MemberEvent>(DataContractJsonSerialization.Deserialze<MemberEvent>(json)));
                    break;
                case MembershipEvent.WebhookEventName:
                    OnMembershipReceived(new EventArgs<MembershipEvent>(DataContractJsonSerialization.Deserialze<MembershipEvent>(json)));
                    break;
                case PageBuildEvent.WebhookEventName:
                    OnPageBuildReceived(new EventArgs<PageBuildEvent>(DataContractJsonSerialization.Deserialze<PageBuildEvent>(json)));
                    break;
                case PublicEvent.WebhookEventName:
                    OnPublicReceived(new EventArgs<PublicEvent>(DataContractJsonSerialization.Deserialze<PublicEvent>(json)));
                    break;
                case PullRequestEvent.WebhookEventName:
                    OnPullRequestReceived(new EventArgs<PullRequestEvent>(DataContractJsonSerialization.Deserialze<PullRequestEvent>(json)));
                    break;
                case PullRequestReviewCommentEvent.WebhookEventName:
                    OnPullRequestReviewCommentReceived(new EventArgs<PullRequestReviewCommentEvent>(DataContractJsonSerialization.Deserialze<PullRequestReviewCommentEvent>(json)));
                    break;
                case PushEvent.WebhookEventName:
                    OnPushReceived(new EventArgs<PushEvent>(DataContractJsonSerialization.Deserialze<PushEvent>(json)));
                    break;
                case ReleaseEvent.WebhookEventName:
                    OnReleaseReceived(new EventArgs<ReleaseEvent>(DataContractJsonSerialization.Deserialze<ReleaseEvent>(json)));
                    break;
                case RepositoryEvent.WebhookEventName:
                    OnRepositoryReceived(new EventArgs<RepositoryEvent>(DataContractJsonSerialization.Deserialze<RepositoryEvent>(json)));
                    break;
                case StatusEvent.WebhookEventName:
                    OnStatusReceived(new EventArgs<StatusEvent>(DataContractJsonSerialization.Deserialze<StatusEvent>(json)));
                    break;
                case TeamAddEvent.WebhookEventName:
                    OnTeamAddReceived(new EventArgs<TeamAddEvent>(DataContractJsonSerialization.Deserialze<TeamAddEvent>(json)));
                    break;
                case WatchEvent.WebhookEventName:
                    OnWatchReceived(new EventArgs<WatchEvent>(DataContractJsonSerialization.Deserialze<WatchEvent>(json)));
                    break;
            }
        }

        /// <summary>
        /// Throws the <see cref="CommitCommentEventReceived"/> event.
        /// </summary>
        /// <param name="e">The args to throw into the event.</param>
        protected void OnCommitCommentReceived(EventArgs<CommitCommentEvent> e)
        {
            var del = CommitCommentEventReceived;
            del?.Invoke(this, e);
        }
        
        /// <summary>
        /// Throws the <see cref="CreateEventReceived"/> event.
        /// </summary>
        /// <param name="e">The args to throw into the event.</param>
        protected void OnCreateReceived(EventArgs<CreateEvent> e)
        {
            var del = CreateEventReceived;
            del?.Invoke(this, e);
        }

        /// <summary>
        /// Throws the <see cref="DeleteEventReceived"/> event.
        /// </summary>
        /// <param name="e">The args to throw into the event.</param>
        protected void OnDeleteReceived(EventArgs<DeleteEvent> e)
        {
            var del = DeleteEventReceived;
            del?.Invoke(this, e);
        }

        /// <summary>
        /// Throws the <see cref="DeploymentEventReceived"/> event.
        /// </summary>
        /// <param name="e">The args to throw into the event.</param>
        protected void OnDeploymentReceived(EventArgs<DeploymentEvent> e)
        {
            var del = DeploymentEventReceived;
            del?.Invoke(this, e);
        }

        /// <summary>
        /// Throws the <see cref="DeploymentStatusEventReceived"/> event.
        /// </summary>
        /// <param name="e">The args to throw into the event.</param>
        protected void OnDeploymentStatusReceived(EventArgs<DeploymentStatusEvent> e)
        {
            var del = DeploymentStatusEventReceived;
            del?.Invoke(this, e);
        }

        /// <summary>
        /// Throws the <see cref="ForkEventReceived"/> event.
        /// </summary>
        /// <param name="e">The args to throw into the event.</param>
        protected void OnForkReceived(EventArgs<ForkEvent> e)
        {
            var del = ForkEventReceived;
            del?.Invoke(this, e);
        }

        /// <summary>
        /// Throws the <see cref="GollumEventReceived"/> event.
        /// </summary>
        /// <param name="e">The args to throw into the event.</param>
        protected void OnGollumReceived(EventArgs<GollumEvent> e)
        {
            var del = GollumEventReceived;
            del?.Invoke(this, e);
        }

        /// <summary>
        /// Throws the <see cref="IssueCommentEventReceived"/> event.
        /// </summary>
        /// <param name="e">The args to throw into the event.</param>
        protected void OnIssueCommentReceived(EventArgs<IssueCommentEvent> e)
        {
            var del = IssueCommentEventReceived;
            del?.Invoke(this, e);
        }

        /// <summary>
        /// Throws the <see cref="IssuesEventReceived"/> event.
        /// </summary>
        /// <param name="e">The args to throw into the event.</param>
        protected void OnIssuesReceived(EventArgs<IssuesEvent> e)
        {
            var del = IssuesEventReceived;
            del?.Invoke(this, e);
        }

        /// <summary>
        /// Throws the <see cref="MemberEventReceived"/> event.
        /// </summary>
        /// <param name="e">The args to throw into the event.</param>
        protected void OnMemberReceived(EventArgs<MemberEvent> e)
        {
            var del = MemberEventReceived;
            del?.Invoke(this, e);
        }

        /// <summary>
        /// Throws the <see cref="MembershipEventReceived"/> event.
        /// </summary>
        /// <param name="e">The args to throw into the event.</param>
        protected void OnMembershipReceived(EventArgs<MembershipEvent> e)
        {
            var del = MembershipEventReceived;
            del?.Invoke(this, e);
        }

        /// <summary>
        /// Throws the <see cref="PageBuildEventReceived"/> event.
        /// </summary>
        /// <param name="e">The args to throw into the event.</param>
        protected void OnPageBuildReceived(EventArgs<PageBuildEvent> e)
        {
            var del = PageBuildEventReceived;
            del?.Invoke(this, e);
        }

        /// <summary>
        /// Throws the <see cref="PublicEventReceived"/> event.
        /// </summary>
        /// <param name="e">The args to throw into the event.</param>
        protected void OnPublicReceived(EventArgs<PublicEvent> e)
        {
            var del = PublicEventReceived;
            del?.Invoke(this, e);
        }

        /// <summary>
        /// Throws the <see cref="PullRequestEventReceived"/> event.
        /// </summary>
        /// <param name="e">The args to throw into the event.</param>
        protected void OnPullRequestReceived(EventArgs<PullRequestEvent> e)
        {
            var del = PullRequestEventReceived;
            del?.Invoke(this, e);
        }

        /// <summary>
        /// Throws the <see cref="PullRequestReviewCommentEventReceived"/> event.
        /// </summary>
        /// <param name="e">The args to throw into the event.</param>
        protected void OnPullRequestReviewCommentReceived(EventArgs<PullRequestReviewCommentEvent> e)
        {
            var del = PullRequestReviewCommentEventReceived;
            del?.Invoke(this, e);
        }

        /// <summary>
        /// Throws the <see cref="PushEventReceived"/> event.
        /// </summary>
        /// <param name="e">The args to throw into the event.</param>
        protected void OnPushReceived(EventArgs<PushEvent> e)
        {
            var del = PushEventReceived;
            del?.Invoke(this, e);
        }

        /// <summary>
        /// Throws the <see cref="ReleaseEventReceived"/> event.
        /// </summary>
        /// <param name="e">The args to throw into the event.</param>
        protected void OnReleaseReceived(EventArgs<ReleaseEvent> e)
        {
            var del = ReleaseEventReceived;
            del?.Invoke(this, e);
        }

        /// <summary>
        /// Throws the <see cref="RepositoryEventReceived"/> event.
        /// </summary>
        /// <param name="e">The args to throw into the event.</param>
        protected void OnRepositoryReceived(EventArgs<RepositoryEvent> e)
        {
            var del = RepositoryEventReceived;
            del?.Invoke(this, e);
        }

        /// <summary>
        /// Throws the <see cref="StatusEventReceived"/> event.
        /// </summary>
        /// <param name="e">The args to throw into the event.</param>
        protected void OnStatusReceived(EventArgs<StatusEvent> e)
        {
            var del = StatusEventReceived;
            del?.Invoke(this, e);
        }

        /// <summary>
        /// Throws the <see cref="TeamAddEventReceived"/> event.
        /// </summary>
        /// <param name="e">The args to throw into the event.</param>
        protected void OnTeamAddReceived(EventArgs<TeamAddEvent> e)
        {
            var del = TeamAddEventReceived;
            del?.Invoke(this, e);
        }

        /// <summary>
        /// Throws the <see cref="WatchEventReceived"/> event.
        /// </summary>
        /// <param name="e">The args to throw into the event.</param>
        protected void OnWatchReceived(EventArgs<WatchEvent> e)
        {
            var del = WatchEventReceived;
            del?.Invoke(this, e);
        }

        /// <summary>
        /// Fired when a <see cref="CommitCommentEvent"/> event is received.
        /// </summary>
        public event EventHandler<EventArgs<CommitCommentEvent>> CommitCommentEventReceived;

        /// <summary>
        /// Fires when a <see cref="CreateEvent"/> is received.
        /// </summary>
        public event EventHandler<EventArgs<CreateEvent>> CreateEventReceived;

        /// <summary>
        /// Fires when a <see cref="DeleteEvent"/> is received.
        /// </summary>
        public event EventHandler<EventArgs<DeleteEvent>> DeleteEventReceived;

        /// <summary>
        /// Fires when a <see cref="DeploymentEvent"/> is received.
        /// </summary>
        public event EventHandler<EventArgs<DeploymentEvent>> DeploymentEventReceived;

        /// <summary>
        /// Fires when a <see cref="DeploymentStatusEvent"/> is received.
        /// </summary>
        public event EventHandler<EventArgs<DeploymentStatusEvent>> DeploymentStatusEventReceived;

        /// <summary>
        /// Fires when a <see cref="ForkEvent"/> is received.
        /// </summary>
        public event EventHandler<EventArgs<ForkEvent>> ForkEventReceived;

        /// <summary>
        /// Fires when a <see cref="GollumEvent"/> is received.
        /// </summary>
        public event EventHandler<EventArgs<GollumEvent>> GollumEventReceived;

        /// <summary>
        /// Fires when a <see cref="IssueCommentEvent"/> is received.
        /// </summary>
        public event EventHandler<EventArgs<IssueCommentEvent>> IssueCommentEventReceived;

        /// <summary>
        /// Fires when a <see cref="IssuesEvent"/> is received.
        /// </summary>
        public event EventHandler<EventArgs<IssuesEvent>> IssuesEventReceived;

        /// <summary>
        /// Fires when a <see cref="MemberEvent"/> is received.
        /// </summary>
        public event EventHandler<EventArgs<MemberEvent>> MemberEventReceived;

        /// <summary>
        /// Fires when a <see cref="MembershipEvent"/> is received.
        /// </summary>
        public event EventHandler<EventArgs<MembershipEvent>> MembershipEventReceived;

        /// <summary>
        /// Fires when a <see cref="PageBuildEvent"/> is received.
        /// </summary>
        public event EventHandler<EventArgs<PageBuildEvent>> PageBuildEventReceived;

        /// <summary>
        /// Fires when a <see cref="PublicEvent"/> is received.
        /// </summary>
        public event EventHandler<EventArgs<PublicEvent>> PublicEventReceived;

        /// <summary>
        /// Fires when a <see cref="PullRequestEvent"/> is received.
        /// </summary>
        public event EventHandler<EventArgs<PullRequestEvent>> PullRequestEventReceived;

        /// <summary>
        /// Fires when a <see cref="PullRequestReviewCommentEvent"/> is received.
        /// </summary>
        public event EventHandler<EventArgs<PullRequestReviewCommentEvent>> PullRequestReviewCommentEventReceived;

        /// <summary>
        /// Fires when a <see cref="PushEvent"/> is received.
        /// </summary>
        public event EventHandler<EventArgs<PushEvent>> PushEventReceived;

        /// <summary>
        /// Fires when a <see cref="ReleaseEvent"/> is received.
        /// </summary>
        public event EventHandler<EventArgs<ReleaseEvent>> ReleaseEventReceived;

        /// <summary>
        /// Fires when a <see cref="RepositoryEvent"/> is received.
        /// </summary>
        public event EventHandler<EventArgs<RepositoryEvent>> RepositoryEventReceived;

        /// <summary>
        /// Fires when a <see cref="StatusEvent"/> is received.
        /// </summary>
        public event EventHandler<EventArgs<StatusEvent>> StatusEventReceived;

        /// <summary>
        /// Fires when a <see cref="TeamAddEvent"/> is received.
        /// </summary>
        public event EventHandler<EventArgs<TeamAddEvent>> TeamAddEventReceived;

        /// <summary>
        /// Fires when a <see cref="WatchEvent"/> is received.
        /// </summary>
        public event EventHandler<EventArgs<WatchEvent>> WatchEventReceived;
    }
}
