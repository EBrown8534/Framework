using Evbpc.Framework.Integrations.StackExchange.OAuth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.StackExchange.OAuth.Requests
{

    public class AccessTokenRequest : IRequest<AccessToken>
    {
        public string EndpointUrl => "access_token";

        public string FormattedEndpoint => EndpointUrl;

        public string VerificationError => null;

        public bool VerifyRequiredParameters() => true;
        
        public RequestType RequestType => RequestType.POST;

        public string PostParameters => $"client_id={ClientId}&client_secret={ClientSecret}&redirect_uri={RedirectUri}&code={Code}";

        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string RedirectUri { get; set; }
        public string Code { get; set; }
    }
}
