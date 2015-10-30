using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.GitHub.Models
{
    /// <summary>
    /// Represents page in a GitHub Wiki.
    /// </summary>
    [DataContract]
    public class Page
    {
        /// <summary>
        /// The name of the page.
        /// </summary>
        [DataMember(Name = "page_name")]
        public string PageName { get; set; }

        /// <summary>
        /// The current page title.
        /// </summary>
        [DataMember(Name = "title")]
        public string Title { get; set; }
        
        [DataMember(Name = "summary")]
        public string Summary { get; set; }

        /// <summary>
        /// The action that was performed on the page. Can be “created” or “edited”.
        /// </summary>
        [DataMember(Name = "action")]
        public string Action { get; set; }

        /// <summary>
        /// The latest commit SHA of the page.
        /// </summary>
        [DataMember(Name = "sha")]
        public string Sha { get; set; }

        /// <summary>
        /// Points to the HTML wiki page.
        /// </summary>
        [DataMember(Name = "html_url")]
        public string HtmlUrl { get; set; }
    }
}
