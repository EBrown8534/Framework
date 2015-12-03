namespace Evbpc.Framework.Integrations
{
    /// <summary>
    /// An interface for dispatching API request messages.
    /// </summary>
    public interface IEventDispatcher
    {
        /// <summary>
        /// Dispatches an event corresponding to the specified eventKey and json data.
        /// </summary>
        /// <param name="eventKey">The event key of the event.</param>
        /// <param name="json">The event JSON payload.</param>
        void Dispatch(string eventKey, string json);
    }
}