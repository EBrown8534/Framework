using Evbpc.Framework.Integrations.StackExchange.API.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.StackExchange.API
{
    /// <summary>
    /// Represents a Stack Exchange API configuration for use with API requests.
    /// </summary>
    public class Configuration
    {
        /// <summary>
        /// Represents the base endpoint for the Stack Exchange API url.
        /// </summary>
        public const string ApiUrlBase = "{Protocol}://api.stackexchange.com/{Version}/";

        /// <summary>
        /// The application API key. Can be <code>null</code> for anonymous requests.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// If true then the HTTPS protocol will be used, otherwise the HTTP protocol will be used. Defaults to true.
        /// </summary>
        public bool UseHttps { get; set; } = true;

        /// <summary>
        /// Determines what version of the API will be used. This should never be modified unless absolutely necessary. Defaults to 2.2.
        /// </summary>
        public string Version { get; set; } = "2.2";

        /// <summary>
        /// Returns the <see cref="ApiUrlBase"/> formatted with the provided parameters.
        /// </summary>
        public string FormattedUrl => ApiUrlBase.Replace("{Protocol}", UseHttps ? "https" : "http").Replace("{Version}", Version);

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
        public string GetFormattedUrl(IRequest requester) => AppendKey(FormattedUrl + requester.FormattedEndpoint);
    }
}
