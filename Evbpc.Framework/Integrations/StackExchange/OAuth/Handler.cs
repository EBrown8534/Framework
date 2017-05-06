using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evbpc.Framework.Integrations.StackExchange.OAuth.Models;
using Evbpc.Framework.Integrations.StackExchange.OAuth.Requests;
using System.Net;
using System.IO;
using Evbpc.Framework.Utilities.Serialization;

namespace Evbpc.Framework.Integrations.StackExchange.OAuth
{

    /// <summary>
    /// Fires and processes the actual SE API requests.
    /// </summary>
    public class Handler
    {
        /// <summary>
        /// The <see cref="Configuration"/> to use for general API access.
        /// </summary>
        public Configuration Configuration { get; }

        /// <summary>
        /// Creates a new instance of the <see cref="Handler"/> with the specified <see cref="Configuration"/>.
        /// </summary>
        /// <param name="configuration">The <see cref="Configuration"/> to use for SE API requests.</param>
        public Handler(Configuration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Submits a request to the SE API.
        /// </summary>
        /// <typeparam name="T">The type of the object to be returned. This should be inferred from the <see cref="IRequest{T}"/>.</typeparam>
        /// <param name="request">The <see cref="IRequest{T}"/> being performed.</param>
        /// <param name="throwVerificationExceptions">If true, verification errors will result in exceptions. If false, a <code>null</code> object will simply be returned.</param>
        /// <returns>The JSON result for the API request.</returns>
        public string SubmitRequest<T>(IRequest<T> request, bool throwVerificationExceptions = true)
            where T : IBaseModel
        {
            if (!request.VerifyRequiredParameters())
            {
                if (throwVerificationExceptions)
                {
                    throw new ArgumentException($"At least one of the required parameters for {nameof(request)} was invalid.", new ArgumentException(request.VerificationError));
                }
                else
                {
                    return null;
                }
            }

            var response = "";

            var url = Configuration.GetFormattedUrl(request);

            var webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip,deflate");
            webRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            if (request.RequestType == RequestType.POST)
            {
                webRequest.Method = "POST";
                webRequest.ContentType = "application/x-www-form-urlencoded";

                using (var ds = webRequest.GetRequestStream())
                {
                    var postParams = Encoding.ASCII.GetBytes(request.PostParameters);
                    ds.Write(postParams, 0, postParams.Length);
                    ds.Close();
                }
            }

            try
            {
                using (var webResponse = webRequest.GetResponse())
                using (var sr = new StreamReader(webResponse.GetResponseStream()))
                {
                    response = sr.ReadToEnd();
                }
            }
            catch (WebException ex)
            {
                throw;
            }

            return response;
        }

        /// <summary>
        /// Processes a request from the SE API.
        /// </summary>
        /// <typeparam name="T">The type of the object to be returned. This should be inferred from the <see cref="IRequest{T}"/>.</typeparam>
        /// <param name="response">The JSON response from the API.</param>
        /// <returns>A <see cref="Wrapper{T}"/> representing the JSON data.</returns>
        public T ProcessResponse<T>(string response)
            where T : IBaseModel =>
            DataContractJsonSerialization.Deserialize<T>(response);
    }
}
