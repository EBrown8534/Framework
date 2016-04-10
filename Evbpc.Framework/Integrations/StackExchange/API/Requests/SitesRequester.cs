using Evbpc.Framework.Integrations.StackExchange.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.StackExchange.API.Requests
{
    /// <summary>
    /// Submits a request to the sites API endpoint.
    /// </summary>
    /// <remarks>
    /// Endpoint URL is <see cref="EndpointUrl"/>.
    /// </remarks>
    public class SitesRequester : IRequester
    {
        private const string _endpointUrl = "sites?pagesize={PageSize}";

        /// <summary>
        /// The destination endpoint for the API request.
        /// </summary>
        public string EndpointUrl => _endpointUrl;

        /// <summary>
        /// Determines how many sites will be returned for each page.
        /// </summary>
        /// <remarks>
        /// As of this writing, this endpoint value is unbounded. Defaults to 1000.
        /// </remarks>
        public int PageSize { get; set; } = 1000;

        /// <summary>
        /// Returns the fully formatted endpoint for this <see cref="SitesRequester"/> instance.
        /// </summary>
        public string FormattedEndpoint => EndpointUrl.Replace("{PageSize}", PageSize.ToString());

        public bool VerifyRequiredParameters() => PageSize > 0;
    }
}
