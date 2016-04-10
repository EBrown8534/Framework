using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.StackExchange.API.Models
{
    /// <summary>
    /// Represents a site relation to a <see cref="Site"/> in the <see cref="Site.RelatedSites"/> list.
    /// </summary>
    /// <remarks>
    /// http://api.stackexchange.com/docs/types/related-site
    /// </remarks>
    [DataContract]
    public class RelatedSite : IBaseModel
    {
        /// <summary>
        /// See <code>api_site_parameter</code>
        /// </summary>
        [DataMember(Name = "api_site_parameter")]
        public string ApiSiteParameter { get; set; }

        /// <summary>
        /// See <code>name</code>
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// See <code>relation</code>
        /// </summary>
        [DataMember(Name = "relation")]
        public string Relation { get; set; }

        /// <summary>
        /// See <code>site_url</code>
        /// </summary>
        [DataMember(Name = "site_url")]
        public string SiteUrl { get; set; }
    }
}