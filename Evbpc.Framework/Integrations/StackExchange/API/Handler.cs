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

        public Wrapper<T> SubmitRequest<T>(IRequester request)
        {
            var response = "";

            var httpWebRequest = WebRequest.Create(Configuration.GetFormattedUrl(request));
            var httpWebResponse = httpWebRequest.GetResponse();

            using (var reader = new StreamReader(httpWebResponse.GetResponseStream()))
            {
                response = reader.ReadToEnd();
            }

            return DataContractJsonSerialization.Deserialize<Wrapper<T>>(response);
        }
    }
}
