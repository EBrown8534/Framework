using Evbpc.Framework.Integrations.GitHub.Events;
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
                    OnCommitCommentReceived(new GenericEventArgs<CommitCommentEvent>(Deserialze<CommitCommentEvent>(json)));
                    break;
                case CreateEvent.WebhookEventName:
                    OnCreateReceived(new GenericEventArgs<CreateEvent>(Deserialze<CreateEvent>(json)));
                    break;
                case DeleteEvent.WebhookEventName:
                    OnDeleteReceived(new GenericEventArgs<DeleteEvent>(Deserialze<DeleteEvent>(json)));
                    break;
                case DeploymentEvent.WebhookEventName:
                    OnDeploymentReceived(new GenericEventArgs<DeploymentEvent>(Deserialze<DeploymentEvent>(json)));
                    break;
                case DeploymentStatusEvent.WebhookEventName:
                    OnDeploymentStatusReceived(new GenericEventArgs<DeploymentStatusEvent>(Deserialze<DeploymentStatusEvent>(json)));
                    break;
                case ForkEvent.WebhookEventName:
                    OnForkReceived(new GenericEventArgs<ForkEvent>(Deserialze<ForkEvent>(json)));
                    break;
                case GollumEvent.WebhookEventName:
                    OnGollumReceived(new GenericEventArgs<GollumEvent>(Deserialze<GollumEvent>(json)));
                    break;
                case IssueCommentEvent.WebhookEventName:
                    OnIssueCommentReceived(new GenericEventArgs<IssueCommentEvent>(Deserialze<IssueCommentEvent>(json)));
                    break;
                case IssuesEvent.WebhookEventName:
                    OnIssuesReceived(new GenericEventArgs<IssuesEvent>(Deserialze<IssuesEvent>(json)));
                    break;
                case MemberEvent.WebhookEventName:
                    OnMemberReceived(new GenericEventArgs<MemberEvent>(Deserialze<MemberEvent>(json)));
                    break;
                case MembershipEvent.WebhookEventName:
                    OnMembershipReceived(new GenericEventArgs<MembershipEvent>(Deserialze<MembershipEvent>(json)));
                    break;
                case PageBuildEvent.WebhookEventName:
                    OnPageBuildReceived(new GenericEventArgs<PageBuildEvent>(Deserialze<PageBuildEvent>(json)));
                    break;
                case PublicEvent.WebhookEventName:
                    OnPublicReceived(new GenericEventArgs<PublicEvent>(Deserialze<PublicEvent>(json)));
                    break;
                case PullRequestEvent.WebhookEventName:
                    OnPullRequestReceived(new GenericEventArgs<PullRequestEvent>(Deserialze<PullRequestEvent>(json)));
                    break;
                case PullRequestReviewCommentEvent.WebhookEventName:
                    OnPullRequestReviewCommentReceived(new GenericEventArgs<PullRequestReviewCommentEvent>(Deserialze<PullRequestReviewCommentEvent>(json)));
                    break;
                case PushEvent.WebhookEventName:
                    OnPushReceived(new GenericEventArgs<PushEvent>(Deserialze<PushEvent>(json)));
                    break;
                case ReleaseEvent.WebhookEventName:
                    OnReleaseReceived(new GenericEventArgs<ReleaseEvent>(Deserialze<ReleaseEvent>(json)));
                    break;
                case RepositoryEvent.WebhookEventName:
                    OnRepositoryReceived(new GenericEventArgs<RepositoryEvent>(Deserialze<RepositoryEvent>(json)));
                    break;
                case StatusEvent.WebhookEventName:
                    OnStatusReceived(new GenericEventArgs<StatusEvent>(Deserialze<StatusEvent>(json)));
                    break;
                case TeamAddEvent.WebhookEventName:
                    OnTeamAddReceived(new GenericEventArgs<TeamAddEvent>(Deserialze<TeamAddEvent>(json)));
                    break;
                case WatchEvent.WebhookEventName:
                    OnWatchReceived(new GenericEventArgs<WatchEvent>(Deserialze<WatchEvent>(json)));
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
        /// <param name="e">The args to throw into the event.</param>
        protected void OnCommitCommentReceived(GenericEventArgs<CommitCommentEvent> e)
        {
            var del = CommitCommentEventReceived;
            del?.Invoke(this, e);
        }
        
        /// <summary>
        /// Throws the <see cref="CreateEventReceived"/> event.
        /// </summary>
        /// <param name="e">The args to throw into the event.</param>
        protected void OnCreateReceived(GenericEventArgs<CreateEvent> e)
        {
            var del = CreateEventReceived;
            del?.Invoke(this, e);
        }

        /// <summary>
        /// Throws the <see cref="DeleteEventReceived"/> event.
        /// </summary>
        /// <param name="e">The args to throw into the event.</param>
        protected void OnDeleteReceived(GenericEventArgs<DeleteEvent> e)
        {
            var del = DeleteEventReceived;
            del?.Invoke(this, e);
        }

        /// <summary>
        /// Throws the <see cref="DeploymentEventReceived"/> event.
        /// </summary>
        /// <param name="e">The args to throw into the event.</param>
        protected void OnDeploymentReceived(GenericEventArgs<DeploymentEvent> e)
        {
            var del = DeploymentEventReceived;
            del?.Invoke(this, e);
        }

        /// <summary>
        /// Throws the <see cref="DeploymentStatusEventReceived"/> event.
        /// </summary>
        /// <param name="e">The args to throw into the event.</param>
        protected void OnDeploymentStatusReceived(GenericEventArgs<DeploymentStatusEvent> e)
        {
            var del = DeploymentStatusEventReceived;
            del?.Invoke(this, e);
        }

        /// <summary>
        /// Throws the <see cref="ForkEventReceived"/> event.
        /// </summary>
        /// <param name="e">The args to throw into the event.</param>
        protected void OnForkReceived(GenericEventArgs<ForkEvent> e)
        {
            var del = ForkEventReceived;
            del?.Invoke(this, e);
        }

        /// <summary>
        /// Throws the <see cref="GollumEventReceived"/> event.
        /// </summary>
        /// <param name="e">The args to throw into the event.</param>
        protected void OnGollumReceived(GenericEventArgs<GollumEvent> e)
        {
            var del = GollumEventReceived;
            del?.Invoke(this, e);
        }

        /// <summary>
        /// Throws the <see cref="IssueCommentEventReceived"/> event.
        /// </summary>
        /// <param name="e">The args to throw into the event.</param>
        protected void OnIssueCommentReceived(GenericEventArgs<IssueCommentEvent> e)
        {
            var del = IssueCommentEventReceived;
            del?.Invoke(this, e);
        }

        /// <summary>
        /// Throws the <see cref="IssuesEventReceived"/> event.
        /// </summary>
        /// <param name="e">The args to throw into the event.</param>
        protected void OnIssuesReceived(GenericEventArgs<IssuesEvent> e)
        {
            var del = IssuesEventReceived;
            del?.Invoke(this, e);
        }

        /// <summary>
        /// Throws the <see cref="MemberEventReceived"/> event.
        /// </summary>
        /// <param name="e">The args to throw into the event.</param>
        protected void OnMemberReceived(GenericEventArgs<MemberEvent> e)
        {
            var del = MemberEventReceived;
            del?.Invoke(this, e);
        }

        /// <summary>
        /// Throws the <see cref="MembershipEventReceived"/> event.
        /// </summary>
        /// <param name="e">The args to throw into the event.</param>
        protected void OnMembershipReceived(GenericEventArgs<MembershipEvent> e)
        {
            var del = MembershipEventReceived;
            del?.Invoke(this, e);
        }

        /// <summary>
        /// Throws the <see cref="PageBuildEventReceived"/> event.
        /// </summary>
        /// <param name="e">The args to throw into the event.</param>
        protected void OnPageBuildReceived(GenericEventArgs<PageBuildEvent> e)
        {
            var del = PageBuildEventReceived;
            del?.Invoke(this, e);
        }

        /// <summary>
        /// Throws the <see cref="PublicEventReceived"/> event.
        /// </summary>
        /// <param name="e">The args to throw into the event.</param>
        protected void OnPublicReceived(GenericEventArgs<PublicEvent> e)
        {
            var del = PublicEventReceived;
            del?.Invoke(this, e);
        }

        /// <summary>
        /// Throws the <see cref="PullRequestEventReceived"/> event.
        /// </summary>
        /// <param name="e">The args to throw into the event.</param>
        protected void OnPullRequestReceived(GenericEventArgs<PullRequestEvent> e)
        {
            var del = PullRequestEventReceived;
            del?.Invoke(this, e);
        }

        /// <summary>
        /// Throws the <see cref="PullRequestReviewCommentEventReceived"/> event.
        /// </summary>
        /// <param name="e">The args to throw into the event.</param>
        protected void OnPullRequestReviewCommentReceived(GenericEventArgs<PullRequestReviewCommentEvent> e)
        {
            var del = PullRequestReviewCommentEventReceived;
            del?.Invoke(this, e);
        }

        /// <summary>
        /// Throws the <see cref="PushEventReceived"/> event.
        /// </summary>
        /// <param name="e">The args to throw into the event.</param>
        protected void OnPushReceived(GenericEventArgs<PushEvent> e)
        {
            var del = PushEventReceived;
            del?.Invoke(this, e);
        }

        /// <summary>
        /// Throws the <see cref="ReleaseEventReceived"/> event.
        /// </summary>
        /// <param name="e">The args to throw into the event.</param>
        protected void OnReleaseReceived(GenericEventArgs<ReleaseEvent> e)
        {
            var del = ReleaseEventReceived;
            del?.Invoke(this, e);
        }

        /// <summary>
        /// Throws the <see cref="RepositoryEventReceived"/> event.
        /// </summary>
        /// <param name="e">The args to throw into the event.</param>
        protected void OnRepositoryReceived(GenericEventArgs<RepositoryEvent> e)
        {
            var del = RepositoryEventReceived;
            del?.Invoke(this, e);
        }

        /// <summary>
        /// Throws the <see cref="StatusEventReceived"/> event.
        /// </summary>
        /// <param name="e">The args to throw into the event.</param>
        protected void OnStatusReceived(GenericEventArgs<StatusEvent> e)
        {
            var del = StatusEventReceived;
            del?.Invoke(this, e);
        }

        /// <summary>
        /// Throws the <see cref="TeamAddEventReceived"/> event.
        /// </summary>
        /// <param name="e">The args to throw into the event.</param>
        protected void OnTeamAddReceived(GenericEventArgs<TeamAddEvent> e)
        {
            var del = TeamAddEventReceived;
            del?.Invoke(this, e);
        }

        /// <summary>
        /// Throws the <see cref="WatchEventReceived"/> event.
        /// </summary>
        /// <param name="e">The args to throw into the event.</param>
        protected void OnWatchReceived(GenericEventArgs<WatchEvent> e)
        {
            var del = WatchEventReceived;
            del?.Invoke(this, e);
        }

        /// <summary>
        /// Fired when a <see cref="CommitCommentEvent"/> event is received.
        /// </summary>
        public event EventHandler<GenericEventArgs<CommitCommentEvent>> CommitCommentEventReceived;

        /// <summary>
        /// Fires when a <see cref="CreateEvent"/> is received.
        /// </summary>
        public event EventHandler<GenericEventArgs<CreateEvent>> CreateEventReceived;

        /// <summary>
        /// Fires when a <see cref="DeleteEvent"/> is received.
        /// </summary>
        public event EventHandler<GenericEventArgs<DeleteEvent>> DeleteEventReceived;

        /// <summary>
        /// Fires when a <see cref="DeploymentEvent"/> is received.
        /// </summary>
        public event EventHandler<GenericEventArgs<DeploymentEvent>> DeploymentEventReceived;

        /// <summary>
        /// Fires when a <see cref="DeploymentStatusEvent"/> is received.
        /// </summary>
        public event EventHandler<GenericEventArgs<DeploymentStatusEvent>> DeploymentStatusEventReceived;

        /// <summary>
        /// Fires when a <see cref="ForkEvent"/> is received.
        /// </summary>
        public event EventHandler<GenericEventArgs<ForkEvent>> ForkEventReceived;

        /// <summary>
        /// Fires when a <see cref="GollumEvent"/> is received.
        /// </summary>
        public event EventHandler<GenericEventArgs<GollumEvent>> GollumEventReceived;

        /// <summary>
        /// Fires when a <see cref="IssueCommentEvent"/> is received.
        /// </summary>
        public event EventHandler<GenericEventArgs<IssueCommentEvent>> IssueCommentEventReceived;

        /// <summary>
        /// Fires when a <see cref="IssuesEvent"/> is received.
        /// </summary>
        public event EventHandler<GenericEventArgs<IssuesEvent>> IssuesEventReceived;

        /// <summary>
        /// Fires when a <see cref="MemberEvent"/> is received.
        /// </summary>
        public event EventHandler<GenericEventArgs<MemberEvent>> MemberEventReceived;

        /// <summary>
        /// Fires when a <see cref="MembershipEvent"/> is received.
        /// </summary>
        public event EventHandler<GenericEventArgs<MembershipEvent>> MembershipEventReceived;

        /// <summary>
        /// Fires when a <see cref="PageBuildEvent"/> is received.
        /// </summary>
        public event EventHandler<GenericEventArgs<PageBuildEvent>> PageBuildEventReceived;

        /// <summary>
        /// Fires when a <see cref="PublicEvent"/> is received.
        /// </summary>
        public event EventHandler<GenericEventArgs<PublicEvent>> PublicEventReceived;

        /// <summary>
        /// Fires when a <see cref="PullRequestEvent"/> is received.
        /// </summary>
        public event EventHandler<GenericEventArgs<PullRequestEvent>> PullRequestEventReceived;

        /// <summary>
        /// Fires when a <see cref="PullRequestReviewCommentEvent"/> is received.
        /// </summary>
        public event EventHandler<GenericEventArgs<PullRequestReviewCommentEvent>> PullRequestReviewCommentEventReceived;

        /// <summary>
        /// Fires when a <see cref="PushEvent"/> is received.
        /// </summary>
        public event EventHandler<GenericEventArgs<PushEvent>> PushEventReceived;

        /// <summary>
        /// Fires when a <see cref="ReleaseEvent"/> is received.
        /// </summary>
        public event EventHandler<GenericEventArgs<ReleaseEvent>> ReleaseEventReceived;

        /// <summary>
        /// Fires when a <see cref="RepositoryEvent"/> is received.
        /// </summary>
        public event EventHandler<GenericEventArgs<RepositoryEvent>> RepositoryEventReceived;

        /// <summary>
        /// Fires when a <see cref="StatusEvent"/> is received.
        /// </summary>
        public event EventHandler<GenericEventArgs<StatusEvent>> StatusEventReceived;

        /// <summary>
        /// Fires when a <see cref="TeamAddEvent"/> is received.
        /// </summary>
        public event EventHandler<GenericEventArgs<TeamAddEvent>> TeamAddEventReceived;

        /// <summary>
        /// Fires when a <see cref="WatchEvent"/> is received.
        /// </summary>
        public event EventHandler<GenericEventArgs<WatchEvent>> WatchEventReceived;
    }
}
