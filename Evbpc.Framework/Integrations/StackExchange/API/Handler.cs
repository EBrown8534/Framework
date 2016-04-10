using Evbpc.Framework.Integrations.StackExchange.API.Models;
using Evbpc.Framework.Integrations.StackExchange.API.Requests;
using Evbpc.Framework.Utilities.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.StackExchange.API
{
    public class Handler
    {
        public Configuration Configuration { get; }

        public Handler(Configuration configuration)
        {
            Configuration = configuration;
        }

        public Wrapper<T> SubmitRequest<T>(IRequest request, bool throwVerificationExceptions = true)
            where T : IBaseModel
        {
            if (!request.VerifyRequiredParameters())
            {
                throw new ArgumentException($"At least one of the required parameters for {nameof(request)} was invalid.", new ArgumentException(request.VerificationError));
            }

            var response = "";

            var url = Configuration.GetFormattedUrl(request);

            var webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip,deflate");
            webRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            var webResponse = webRequest.GetResponse();

            using (var sr = new StreamReader(webResponse.GetResponseStream()))
            {
                response = sr.ReadToEnd();
            }

            return DataContractJsonSerialization.Deserialize<Wrapper<T>>(response);
        }
    }
}
