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
    /// Represents an API request for Stack Exchange Site information.
    /// </summary>
    public class InfoRequest : IRequest<Info>
    {
        private const string _endpointUrl = "info?";

        /// <summary>
        /// The destination endpoint for the API request.
        /// </summary>
        public string EndpointUrl => _endpointUrl;

        /// <summary>
        /// The Stack Exchange Site to query the <see cref="Info"/> for.
        /// </summary>
        public string Site { get; set; }

        public string Filter { get; set; }

        /// <summary>
        /// The final endpoint URL that should be appended to the Stack Exchange API base url.
        /// </summary>
        public string FormattedEndpoint
        {
            get
            {
                var values = new Dictionary<string, string>();

                values.Add(nameof(Site).ToLower(), Site);

                if (Filter != null)
                {
                    values.Add(nameof(Filter).ToLower(), Filter);
                }

                var qs = StringExtensions.BuildQueryString(values);

                return EndpointUrl + qs;
            }
        }

        /// <summary>
        /// Returns whether or not the <see cref="Site"/> passed verification.
        /// </summary>
        /// <returns>True if <see cref="Site"/> is not a null, empty or whitespace string, false otherwise.</returns>
        public bool VerifyRequiredParameters() => !string.IsNullOrWhiteSpace(Site);

        /// <summary>
        /// Gets a message indicating how <see cref="Site"/> is validated. 
        /// </summary>
        public string VerificationError => $"The value for {nameof(Site)} must be a valid, non-null, and non-whitespace string.";
    }
}
