using Evbpc.Framework.Integrations.StackExchange.API.Models;
using Evbpc.Framework.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.StackExchange.API.Requests
{
    public class InfoRequest : IRequest<Info>
    {
        private const string _endpointUrl = "info?";

        /// <summary>
        /// The destination endpoint for the API request.
        /// </summary>
        public string EndpointUrl => _endpointUrl;

        public string Site { get; set; }

        public string FormattedEndpoint
        {
            get
            {
                var values = new Dictionary<string, string>();

                values.Add(nameof(Site).ToLower(), Site);

                var qs = StringExtensions.BuildQueryString(values);

                return EndpointUrl + qs;
            }
        }

        public bool VerifyRequiredParameters() => !string.IsNullOrWhiteSpace(Site);

        public string VerificationError => $"The value for {nameof(Site)} must be a valid, non-null, and non-whitespace string.";
    }
}
