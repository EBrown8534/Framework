using Evbpc.Framework.Integrations.StackExchange.API.Models;
using Evbpc.Framework.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.StackExchange.API.Requests
{
    public class QuestionsRequest : IRequest<Question>
    {
        public string EndpointUrl => "questions?";

        public string Filter { get; set; }

        public string Site { get; set; }

        public OrderType Order { get; set; }

        public SortType Sort { get; set; }

        public int Page { get; set; }

        public int PageSize { get; set; }

        public RequestType RequestType => RequestType.GET;

        public string PostParameters => null;

        public string FormattedEndpoint
        {
            get
            {
                var values = new Dictionary<string, string>();

                values.Add(nameof(Site).ToLower(), Site);

                if (Filter != null)
                {
                    values.Add(nameof(Filter).ToLower(), Filter);
                }

                values.Add(nameof(Order).ToLower(), Order == OrderType.Ascending ? "asc" : "desc");
                values.Add(nameof(Sort).ToLower(), Sort.ToString().ToLower());
                values.Add(nameof(Page).ToLower(), (Page < 2 ? 1 : Page).ToString());
                values.Add("page_size", PageSize.ToString());

                var qs = StringExtensions.BuildQueryString(values);

                return EndpointUrl + qs;
            }
        }

        public string VerificationError => null;

        public bool VerifyRequiredParameters() => true;

        public enum SortType
        {
            Activity,
            Creation,
            Votes,
            Hot,
            Week,
            Month,
        }
    }
}
