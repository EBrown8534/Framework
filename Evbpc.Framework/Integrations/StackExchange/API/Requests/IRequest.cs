using Evbpc.Framework.Integrations.StackExchange.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.StackExchange.API.Requests
{
    /// <summary>
    /// This representes a generic request against the Stack Exchange API. Though this does not make use of the type parameter intrinsically, it's necessary for generic inference and type constraints.
    /// </summary>
    /// <typeparam name="T">A <see cref="IBaseModel"/> representing the returned model from the request. When used with <see cref="Handler.SubmitRequest{T}(IRequest{T}, bool)"/> this will return a type of <see cref="Wrapper{TObject}"/> where <code>TObject</code> is this type.</typeparam>
    public interface IRequest<T>
        where T : IBaseModel
    {
        /// <summary>
        /// The basic endpoint for the <see cref="IRequest{T}"/>.
        /// </summary>
        string EndpointUrl { get; }

        /// <summary>
        /// Gets the formatted endpoint for the <see cref="IRequest{T}"/>. This should <b>NOT</b> contain the Stack Exchange API base URL or key.
        /// </summary>
        string FormattedEndpoint { get; }

        /// <summary>
        /// This should verify that all the provided parameters required for the <see cref="IRequest{T}"/> are present.
        /// </summary>
        /// <returns>True if the required parameters pass verification, false otherwise.</returns>
        bool VerifyRequiredParameters();

        /// <summary>
        /// This should return a message to be used to indicate to the user what the verification should be, ir order to pass <see cref="VerifyRequiredParameters()"/>.
        /// </summary>
        string VerificationError { get; }
    }
}
