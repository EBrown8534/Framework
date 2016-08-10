using Evbpc.Framework.Integrations.StackExchange.API.Models;
using Evbpc.Framework.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.StackExchange.API.Requests
{
    public class UserRequest : IRequest<User>
    {
        private const string _endpointUrl = "users?";

        /// <summary>
        /// The destination endpoint for the API request.
        /// </summary>
        public string EndpointUrl => _endpointUrl;

        /// <summary>
        /// The Stack Exchange Site to query the <see cref="User"/> list for.
        /// </summary>
        public string Site { get; set; }

        public OrderType Order { get; set; }

        public SortType Sort { get; set; }

        public int PageSize { get; set; } = 10;

        public int Page { get; set; } = 1;

        public string Min { get; set; }

        public string Max { get; set; }

        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }

        public string InName { get; set; }

        public string FormattedEndpoint
        {
            get
            {
                var endpointUrl = EndpointUrl;
                var values = new Dictionary<string, string>();

                values.Add(nameof(Order).ToLower(), Order == OrderType.Ascending ? "asc" : "desc");
                values.Add(nameof(Sort).ToLower(), Sort.ToString().ToLower());
                values.Add(nameof(Site).ToLower(), Site);
                values.Add(nameof(PageSize).ToLower(), PageSize.ToString());
                values.Add(nameof(Page).ToLower(), Page.ToString());

                if (Min != null)
                {
                    values.Add(nameof(Min).ToLower(), Min.ToString());
                }

                if (Max != null)
                {
                    values.Add(nameof(Max).ToLower(), Max.ToString());
                }

                if (ToDate != null)
                {
                    values.Add(nameof(ToDate).ToLower(), DateTimeExtensions.ToEpoch(ToDate.Value).ToString());
                }

                if (FromDate != null)
                {
                    values.Add(nameof(FromDate).ToLower(), DateTimeExtensions.ToEpoch(FromDate.Value).ToString());
                }

                if (InName != null)
                {
                    values.Add(nameof(InName).ToLower(), InName);
                }

                var qs = StringExtensions.BuildQueryString(values);

                return endpointUrl + qs;
            }
        }
        public string VerificationError => $"The value for {nameof(Site)} must be a valid, non-null, and non-whitespace string; the value for {nameof(PageSize)} must be greater than 0 and less than or equal to {Configuration.MaxPageSize}.";

        public bool VerifyRequiredParameters() => !string.IsNullOrWhiteSpace(Site) && PageSize > 0 && PageSize <= Configuration.MaxPageSize;

        public enum SortType
        {
            Reputation,
            Creation,
            Name,
            Modified,
        }
    }
}
