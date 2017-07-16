using Evbpc.Framework.Integrations.StackExchange.API.Models;
using Evbpc.Framework.Utilities.Extensions;
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

        public string FormattedEndpoint
        {
            get
            {
                var url = EndpointUrl;
                
                var values = new Dictionary<string, string>();
                values.Add(nameof(Page).ToLower(), (Page < 2 ? 1 : Page).ToString());
                values.Add(nameof(PageSize).ToLower(), PageSize.ToString());

                if (Types != AccountTypes.None)
                {
                    var types = string.Empty;

                    if ((Types & AccountTypes.MainSite) == AccountTypes.MainSite)
                    {
                        types += "main_site";
                    }
                    if ((Types & AccountTypes.MetaSite) == AccountTypes.MetaSite)
                    {
                        types += types.Length > 0 ? ";" : "";
                        types += "meta_site";
                    }

                    values.Add(nameof(Types).ToLower(), types);
                }

                var qs = StringExtensions.BuildQueryString(values);

                return url + qs;
            }
        }

        public int Page { get; set; }

        public int PageSize { get; set; } = 30;

        public AccountTypes Types { get; set; }

        public string VerificationError => null;

        public bool VerifyRequiredParameters() => true;

        public RequestType RequestType => RequestType.GET;

        public string PostParameters => null;

        [Flags]
        public enum AccountTypes
        {
            None = 0x00,
            MainSite = 0x01,
            MetaSite = 0x02,
        }
    }
}
