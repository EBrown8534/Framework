using Evbpc.Framework.Integrations.Bitbucket.Events;
using Evbpc.Framework.Integrations.Bitbucket.Events.Args;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.Bitbucket
{
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
                    OnPushReceived(new PushEventArgs(Deserialze<PushEvent>(json)));
                    break;
                case IssueCommentCreatedEvent.WebhookEventName:
                    OnIssueCommentCreatedReceived(new IssueCommentCreatedEventArgs(Deserialze<IssueCommentCreatedEvent>(json)));
                    break;
                case IssueCreatedEvent.WebhookEventName:
                    OnIssueCreatedEventReceived(new IssueCreatedEventArgs(Deserialze<IssueCreatedEvent>(json)));
                    break;
                case IssueUpdatedEvent.WebhookEventName:
                    OnIssueUpdatedEventReceived(new IssueUpdatedEventArgs(Deserialze<IssueUpdatedEvent>(json)));
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
        /// Throws the <see cref="PushReceived"/> event.
        /// </summary>
        /// <param name="e">The <see cref="PushEventArgs"/> to throw into the event.</param>
        protected void OnPushReceived(PushEventArgs e)
        {
            var del = PushReceived;
            del?.Invoke(this, e);
        }

        /// <summary>
        /// Throws the <see cref="IssueCommentCreatedReceived"/> event.
        /// </summary>
        /// <param name="e">The <see cref="IssueCommentCreatedEventArgs"/> to throw into the event.</param>
        protected void OnIssueCommentCreatedReceived(IssueCommentCreatedEventArgs e)
        {
            var del = IssueCommentCreatedReceived;
            del?.Invoke(this, e);
        }

        /// <summary>
        /// Throws the <see cref="IssueCreatedEventReceived"/> event.
        /// </summary>
        /// <param name="e">The <see cref="IssueCreatedEventArgs"/> to throw into the event.</param>
        protected void OnIssueCreatedEventReceived(IssueCreatedEventArgs e)
        {
            var del = IssueCreatedEventReceived;
            del?.Invoke(this, e);
        }

        /// <summary>
        /// Throws the <see cref="IssueUpdatedEventReceived"/> event.
        /// </summary>
        /// <param name="e">The <see cref="IssueUpdatedEventArgs"/> to throw into the event.</param>
        protected void OnIssueUpdatedEventReceived(IssueUpdatedEventArgs e)
        {
            var del = IssueUpdatedEventReceived;
            del?.Invoke(this, e);
        }

        /// <summary>
        /// Fired when a <see cref="PushEvent"/> event is received.
        /// </summary>
        public event EventHandler<PushEventArgs> PushReceived;

        /// <summary>
        /// Fired when a <see cref="IssueCommentCreatedEvent"/> event is received.
        /// </summary>
        public event EventHandler<IssueCommentCreatedEventArgs> IssueCommentCreatedReceived;

        /// <summary>
        /// Fired when a <see cref="IssueCreatedEvent"/> event is received.
        /// </summary>
        public event EventHandler<IssueCreatedEventArgs> IssueCreatedEventReceived;

        /// <summary>
        /// Fired when a <see cref="IssueUpdatedEvent"/> event is received.
        /// </summary>
        public event EventHandler<IssueUpdatedEventArgs> IssueUpdatedEventReceived;
    }
}
