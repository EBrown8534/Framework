using Evbpc.Framework.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.StackExchange.API.Models
{
    /// <summary>
    /// Represents a Stack Exchange site.
    /// </summary>
    /// <remarks>
    /// http://api.stackexchange.com/docs/types/site
    /// </remarks>
    [DataContract]
    public class Site : IBaseModel
    {
        /// <summary>
        /// See <code>aliases</code>
        /// </summary>
        [DataMember(Name = "aliases")]
        public List<string> Aliases { get; set; }
        
        /// <summary>
        /// See <code>api_site_parameter</code>
        /// </summary>
        [DataMember(Name = "api_site_parameter")]
        public string ApiSiteParameter { get; set; }

        /// <summary>
        /// See <code>audience</code>
        /// </summary>
        [DataMember(Name = "audience")]
        public string Audience { get; set; }

        /// <summary>
        /// See <code>closed_beta_date</code>
        /// </summary>
        [DataMember(Name = "closed_beta_date")]
        public long? ClosedBetaDate { get; set; }

        /// <summary>
        /// A .NET DateTime? representing the <see cref="ClosedBetaDate"/>.
        /// </summary>
        public DateTime? ClosedBetaDateTime
        {
            get { return DateTimeExtensions.FromEpoch(ClosedBetaDate); }
            set { ClosedBetaDate = DateTimeExtensions.ToEpoch(value); }
        }

        /// <summary>
        /// See <code>favicon_url</code>
        /// </summary>
        [DataMember(Name = "favicon_url")]
        public string FaviconUrl { get; set; }

        /// <summary>
        /// See <code>high_resolution_icon_url</code>
        /// </summary>
        [DataMember(Name = "high_resolution_icon_url")]
        public string HighResolutionIconUrl { get; set; }

        /// <summary>
        /// See <code>icon_url</code>
        /// </summary>
        [DataMember(Name = "icon_url")]
        public string IconUrl { get; set; }

        /// <summary>
        /// See <code>launch_date</code>
        /// </summary>
        /// <remarks>
        /// This isn't noted in the SE API docs, but this value can be null. (If a site is closed or open beta, this value is null.)
        /// </remarks>
        [DataMember(Name = "launch_date")]
        public long? LaunchDate { get; set; }

        /// <summary>
        /// A .NET DateTime representing the <see cref="LaunchDate"/>.
        /// </summary>
        public DateTime? LaunchDateTime
        {
            get { return DateTimeExtensions.FromEpoch(LaunchDate); }
            set { LaunchDate = DateTimeExtensions.ToEpoch(value); }
        }

        /// <summary>
        /// See <code>logo_url</code>
        /// </summary>
        [DataMember(Name = "logo_url")]
        public string LogoUrl { get; set; }

        /// <summary>
        /// See <code>markdown_extensions</code>
        /// </summary>
        [DataMember(Name = "markdown_extensions")]
        public List<string> MarkdownExtensions { get; set; }

        /// <summary>
        /// See <code>name</code>
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// See <code>open_beta_date</code>
        /// </summary>
        [DataMember(Name = "open_beta_date")]
        public long? OpenBetaDate { get; set; }

        /// <summary>
        /// A .NET DateTime? representing the <see cref="OpenBetaDate"/>.
        /// </summary>
        public DateTime? OpenBetaDateTime
        {
            get { return DateTimeExtensions.FromEpoch(OpenBetaDate); }
            set { OpenBetaDate = DateTimeExtensions.ToEpoch(value); }
        }

        /// <summary>
        /// See <code>related_sites</code>
        /// </summary>
        [DataMember(Name = "related_sites")]
        public List<RelatedSite> RelatedSites { get; set; }

        /// <summary>
        /// See <code>site_state</code>
        /// </summary>
        [DataMember(Name = "site_state")]
        public string SiteState { get; set; }

        /// <summary>
        /// See <code>site_type</code>
        /// </summary>
        [DataMember(Name = "site_type")]
        public string SiteType { get; set; }

        /// <summary>
        /// See <code>site_url</code>
        /// </summary>
        [DataMember(Name = "site_url")]
        public string SiteUrl { get; set; }

        /// <summary>
        /// See <code>styling</code>
        /// </summary>
        [DataMember(Name = "styling")]
        public Styling Styling { get; set; }

        /// <summary>
        /// See <code>twitter_account</code>
        /// </summary>
        [DataMember(Name = "twitter_account")]
        public string TwitterAccount { get; set; }
    }
}
