using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.StackExchange.API
{
    /// <summary>
    /// Represents a Stack Exchange API configuration for use with API requests.
    /// </summary>
    public class Configuration
    {
        /// <summary>
        /// The application API key. Can be <code>null</code> for anonymous requests.
        /// </summary>
        public string Key { get; set; }
    }
}
