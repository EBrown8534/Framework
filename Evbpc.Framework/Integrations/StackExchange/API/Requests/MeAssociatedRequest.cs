using Evbpc.Framework.Integrations.StackExchange.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.StackExchange.API.Requests
{
    public class MeAssociatedRequest : IRequest<NetworkUser>
    {
        public string EndpointUrl => "me/associated?";

        public string Filter => null;

        public string FormattedEndpoint => $"{EndpointUrl}";

        public string VerificationError => null;

        public bool VerifyRequiredParameters() => true;

        public RequestType RequestType => RequestType.GET;

        public string PostParameters => null;
    }
}
