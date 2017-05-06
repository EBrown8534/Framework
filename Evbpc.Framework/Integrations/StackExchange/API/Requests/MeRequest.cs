using Evbpc.Framework.Integrations.StackExchange.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.StackExchange.API.Requests
{
    public class MeRequest : IRequest<User>
    {
        public string EndpointUrl => "me?";

        public string Filter => null;

        /// <summary>
        /// The Stack Exchange Site to query the <see cref="User"/> for.
        /// </summary>
        public string Site { get; set; }

        public RequestType RequestType => RequestType.GET;

        public string PostParameters => null;

        public string FormattedEndpoint => $"{EndpointUrl}site={Site}";

        public string VerificationError => $"The parameter for '{nameof(Site)}' must be specified.";

        public bool VerifyRequiredParameters() => !string.IsNullOrWhiteSpace(Site);
    }
}
