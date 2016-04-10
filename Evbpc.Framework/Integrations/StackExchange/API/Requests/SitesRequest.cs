using Evbpc.Framework.Integrations.StackExchange.API.Models;
using Evbpc.Framework.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.StackExchange.API.Requests
{
    /// <summary>
    /// Submits a request to the sites API endpoint, to return a <see cref="Site"/> object.
    /// </summary>
    /// <remarks>
    /// Endpoint URL is <see cref="EndpointUrl"/>.
    /// </remarks>
    public class SitesRequest : IRequest<Site>
    {
        private const string _endpointUrl = "sites?";

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

        public int Page { get; set; } = 1;

        /// <summary>
        /// Returns the fully formatted endpoint for this <see cref="SitesRequest"/> instance.
        /// </summary>

        public string FormattedEndpoint
        {
            get
            {
                var values = new Dictionary<string, string>();

                values.Add(nameof(PageSize).ToLower(), PageSize.ToString());
                values.Add(nameof(Page).ToLower(), Page.ToString());

                var qs = StringExtensions.BuildQueryString(values);

                return EndpointUrl + qs;
            }
        }

        /// <summary>
        /// Verifies that the <see cref="PageSize"/> is a valid value.
        /// </summary>
        /// <returns>True if <see cref="PageSize"/> is greater than 0, false otherwise.</returns>
        public bool VerifyRequiredParameters() => PageSize > 0;

        /// <summary>
        /// Gets a message indicating how <see cref="PageSize"/> is validated.
        /// </summary>
        public string VerificationError => $"The value for {nameof(PageSize)} must be an integer greater than 0.";
    }
}
