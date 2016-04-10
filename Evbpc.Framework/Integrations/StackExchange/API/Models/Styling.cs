using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.StackExchange.API.Models
{
    /// <summary>
    /// Represents the <see cref="Site.Styling"/>.
    /// </summary>
    /// <remarks>
    /// http://api.stackexchange.com/docs/types/styling
    /// </remarks>
    [DataContract]
    public class Styling : IBaseModel
    {
        /// <summary>
        /// See <code>link_color</code>
        /// </summary>
        [DataMember(Name = "link_color")]
        public string LinkColor { get; set; }

        /// <summary>
        /// See <code>tag_background_color</code>
        /// </summary>
        [DataMember(Name = "tag_background_color")]
        public string TagBackgroundColor { get; set; }

        /// <summary>
        /// See <code>tag_foreground_color</code>
        /// </summary>
        [DataMember(Name = "tag_foreground_color")]
        public string TagForegroundColor { get; set; }
    }
}