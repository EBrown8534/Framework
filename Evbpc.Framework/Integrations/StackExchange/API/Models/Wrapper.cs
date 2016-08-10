using Evbpc.Framework.Integrations.StackExchange.API.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.StackExchange.API.Models
{
    /// <summary>
    /// This is a general wrapper for Stack Exchange API request models. All API requests should contain these basic fields.
    /// </summary>
    /// <typeparam name="T">The type of the object list/array returned by the API request.</typeparam>
    [DataContract]
    public class Wrapper<T> : IBaseModel
        where T : IBaseModel
    {
        /// <summary>
        /// A list of the objects returned by the API request.
        /// </summary>
        [DataMember(Name = "items")]
        public List<T> Items { get; set; }

        /// <summary>
        /// Whether or not <see cref="Items"/> returned by this request are the end of the pagination or not.
        /// </summary>
        [DataMember(Name = "has_more")]
        public bool? HasMore { get; set; }

        /// <summary>
        /// The maximum number of API requests that can be performed in a 24 hour period.
        /// </summary>
        [DataMember(Name = "quota_max")]
        public int? QuotaMax { get; set; }

        /// <summary>
        /// The remaining number of API requests that can be performed in the current 24 hour period.
        /// </summary>
        /// <remarks>
        /// As far as I know, this resets to <see cref="QuotaMax"/> at around 00:00:00 UTC+0000.
        /// </remarks>
        [DataMember(Name = "quota_remaining")]
        public int? QuotaRemaining { get; set; }

        /// <summary>
        /// The optional number of seconds that the programme making the API requests should stop submitting requests for.
        /// </summary>
        /// <remarks>
        /// Programmes that fail to follow this backoff may be subject to being banned from making API requests for any period of time.
        /// </remarks>
        [DataMember(Name = "backoff")]
        public int? Backoff { get; set; }

        /// <summary>
        /// Gets the total objects that meet the <see cref="IRequest{T}.Filter"/> criteria.
        /// </summary>
        public int? Total { get; set; }

        /// <summary>
        /// Gets the current page from the <see cref="IRequest{T}"/>.
        /// </summary>
        public int? Page { get; set; }

        /// <summary>
        /// Gets the size of each page from the <see cref="IRequest{T}"/>.
        /// </summary>
        public int? PageSize { get; set; }

        /// <summary>
        /// Gets the type of object returned by the <see cref="IRequest{T}"/>.
        /// </summary>
        public string Type { get; set; }
    }
}
