using Evbpc.Framework.Integrations.StackExchange.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.StackExchange.API.Requests
{
    public interface IRequest
    {
        string EndpointUrl { get; }

        /// <summary>
        /// Gets the formatted endpoint for the <see cref="IRequest"/>. This should <b>NOT</b> contain the Stack Exchange API base URL or key.
        /// </summary>
        string FormattedEndpoint { get; }

        bool VerifyRequiredParameters();

        string VerificationError { get; }
    }
}
