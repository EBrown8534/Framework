using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evbpc.Framework.Integrations.StackExchange.OAuth.Requests;
using Evbpc.Framework.Integrations.StackExchange.OAuth.Models;

namespace Evbpc.Framework.Integrations.StackExchange.OAuth
{
    public class Configuration
    {
        /// <summary>
        /// Represents the base endpoint for the Stack Exchange API url.
        /// </summary>
        public const string ApiUrlBase = "https://stackexchange.com/oauth/";

        /// <summary>
        /// Represents the Client Id / client_id for a Stack Exchange Application.
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// Represents the Client Secret / client_secret for a Stack Exchange Application. DO NOT EVER EMBED THIS IN A CLIENT-SIDE APPLICATION.
        /// </summary>
        public string ClientSecret { get; set; }

        /// <summary>
        /// The application API key. Cannot be <code>null</code>.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Returns the <see cref="ApiUrlBase"/> formatted with the provided parameters.
        /// </summary>
        public string FormattedUrl => ApiUrlBase;

        /// <summary>
        /// Appends the current <see cref="Key"/> to the provided url.
        /// </summary>
        /// <param name="url">The URL to append to. Should be the result of <see cref="FormattedUrl"/>, then the API </param>
        /// <returns></returns>
        public string AppendKey(string url) => string.IsNullOrWhiteSpace(Key) ? url : url + (url.Contains('?') ? '&' : '?') + "key=" + Key;

        /// <summary>
        /// Returns the fully formatted URL for Stack Exchange API requests.
        /// </summary>
        /// <param name="requester">The fully filled <see cref="IRequest"/> making the request.</param>
        /// <returns>The formatted url.</returns>
        public string GetFormattedUrl<T>(IRequest<T> requester) where T : IBaseModel =>
            requester.RequestType == RequestType.GET ? AppendKey(FormattedUrl + requester.FormattedEndpoint) : FormattedUrl + requester.FormattedEndpoint;
    }
}
