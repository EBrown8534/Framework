using Evbpc.Framework.Integrations.Bitbucket.Events;
using Evbpc.Framework.Utilities.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.Bitbucket
{
    /// <summary>
    /// Dispatches events received from the Bitbucket API.
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
                case PushEvent.WebhookEventName:
                    OnPushReceived(new EventArgs<PushEvent>(DataContractJsonSerialization.Deserialze<PushEvent>(json)));
                    break;
                case IssueCommentCreatedEvent.WebhookEventName:
                    OnIssueCommentCreatedReceived(new EventArgs<IssueCommentCreatedEvent>(DataContractJsonSerialization.Deserialze<IssueCommentCreatedEvent>(json)));
                    break;
                case IssueCreatedEvent.WebhookEventName:
                    OnIssueCreatedEventReceived(new EventArgs<IssueCreatedEvent>(DataContractJsonSerialization.Deserialze<IssueCreatedEvent>(json)));
                    break;
                case IssueUpdatedEvent.WebhookEventName:
                    OnIssueUpdatedEventReceived(new EventArgs<IssueUpdatedEvent>(DataContractJsonSerialization.Deserialze<IssueUpdatedEvent>(json)));
                    break;
            }
        }

        /// <summary>
        /// Throws the <see cref="PushReceived"/> event.
        /// </summary>
        /// <param name="e">The args to throw into the event.</param>
        protected void OnPushReceived(EventArgs<PushEvent> e)
        {
            var del = PushReceived;
            del?.Invoke(this, e);
        }

        /// <summary>
        /// Throws the <see cref="IssueCommentCreatedReceived"/> event.
        /// </summary>
        /// <param name="e">The args to throw into the event.</param>
        protected void OnIssueCommentCreatedReceived(EventArgs<IssueCommentCreatedEvent> e)
        {
            var del = IssueCommentCreatedReceived;
            del?.Invoke(this, e);
        }

        /// <summary>
        /// Throws the <see cref="IssueCreatedEventReceived"/> event.
        /// </summary>
        /// <param name="e">The args to throw into the event.</param>
        protected void OnIssueCreatedEventReceived(EventArgs<IssueCreatedEvent> e)
        {
            var del = IssueCreatedEventReceived;
            del?.Invoke(this, e);
        }

        /// <summary>
        /// Throws the <see cref="IssueUpdatedEventReceived"/> event.
        /// </summary>
        /// <param name="e">The args to throw into the event.</param>
        protected void OnIssueUpdatedEventReceived(EventArgs<IssueUpdatedEvent> e)
        {
            var del = IssueUpdatedEventReceived;
            del?.Invoke(this, e);
        }

        /// <summary>
        /// Fired when a <see cref="PushEvent"/> event is received.
        /// </summary>
        public event EventHandler<EventArgs<PushEvent>> PushReceived;

        /// <summary>
        /// Fired when a <see cref="IssueCommentCreatedEvent"/> event is received.
        /// </summary>
        public event EventHandler<EventArgs<IssueCommentCreatedEvent>> IssueCommentCreatedReceived;

        /// <summary>
        /// Fired when a <see cref="IssueCreatedEvent"/> event is received.
        /// </summary>
        public event EventHandler<EventArgs<IssueCreatedEvent>> IssueCreatedEventReceived;

        /// <summary>
        /// Fired when a <see cref="IssueUpdatedEvent"/> event is received.
        /// </summary>
        public event EventHandler<EventArgs<IssueUpdatedEvent>> IssueUpdatedEventReceived;
    }
}
