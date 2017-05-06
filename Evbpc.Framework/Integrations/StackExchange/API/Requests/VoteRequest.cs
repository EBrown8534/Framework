using Evbpc.Framework.Integrations.StackExchange.API.Models;
using Evbpc.Framework.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.StackExchange.API.Requests
{
    public class VoteRequest : IRequest<Question>
    {
        public string EndpointUrl => "questions/{id}/{voteAction}?";

        public string Filter { get; set; }

        public string Site { get; set; }

        public VoteType VoteAction { get; set; }

        public int Id { get; set; }

        public RequestType RequestType => RequestType.POST;

        public string Key { get; set; }
        
        public string AccessToken { get; set; }

        public string PostParameters
        {
            get
            {
                var values = new Dictionary<string, string>();

                values.Add(nameof(Site).ToLower(), Site);
                values.Add(nameof(Key).ToLower(), Key);
                values.Add("access_token", AccessToken);
                
                if (Filter != null)
                {
                    values.Add(nameof(Filter).ToLower(), Filter);
                }

                var qs = StringExtensions.BuildQueryString(values);
                return qs;
            }
        }

        public string FormattedEndpoint
        {
            get
            {
                var url = EndpointUrl;
                url = url.Replace("{id}", Id.ToString());
                url = url.Replace("{voteAction}", VoteAction.ToString().ToLower());
                return url;
            }
        }

        public string VerificationError => null;

        public bool VerifyRequiredParameters() => true;

        public enum VoteType
        {
            Upvote,
            Downvote,
        }
    }
}
