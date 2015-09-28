namespace Evbpc.Framework.Integrations
{
    /// <summary>
    /// An interface for dispatching API request messages.
    /// </summary>
    public interface IEventDispatcher
    {
        /// <summary>
        /// Deserializes a type with a <code>DataContractJsonSerializer</code>.
        /// </summary>
        /// <typeparam name="T">The type that should be deserialized.</typeparam>
        /// <param name="json">The JSON to deserialize.</param>
        /// <returns>The deserialized object.</returns>
        T Deserialze<T>(string json);

        /// <summary>
        /// Dispatches an event corresponding to the specified eventKey and json data.
        /// </summary>
        /// <param name="eventKey">The event key of the event.</param>
        /// <param name="json">The event JSON payload.</param>
        void Dispatch(string eventKey, string json);
    }
}