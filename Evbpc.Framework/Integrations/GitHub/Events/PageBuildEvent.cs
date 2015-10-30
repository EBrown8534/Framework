using Evbpc.Framework.Integrations.GitHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.GitHub.Events
{
    /// <summary>
    /// Represents an attempted build of a GitHub Pages site, whether successful or not.
    ///
    /// Triggered on push to a GitHub Pages enabled branch(gh-pages for project pages, master for user and organization pages).
    ///
    /// Events of this type are not visible in timelines, they are only used to trigger hooks.
    /// </summary>
    [DataContract]
    public class PageBuildEvent
    {
        /// <summary>
        /// The name of the Webhook event for this event.
        /// </summary>
        public const string WebhookEventName = "page_build";

        [DataMember(Name = "id")]
        public int Id { get; set; }

        /// <summary>
        /// The page <see cref="Models.Build"/> itself.
        /// </summary>
        [DataMember(Name = "build")]
        public Build Build { get; set; }

        /// <summary>
        /// The <see cref="Models.Repository"/> for this event.
        /// </summary>
        [DataMember(Name = "repository")]
        public Repository Repository { get; set; }

        /// <summary>
        /// The <see cref="Models.Sender"/> that triggered the event.
        /// </summary>
        [DataMember(Name = "sender")]
        public Sender Sender { get; set; }
    }
}
