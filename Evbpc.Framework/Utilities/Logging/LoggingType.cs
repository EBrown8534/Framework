using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Utilities.Logging
{
    /// <summary>
    /// Represents a type of message or an <see cref="ILogger.LoggingType"/>.
    /// </summary>
    public enum LoggingType : byte
    {
        /// <summary>
        /// Should be logged regardless of <see cref="ILogger.LoggingType"/>.
        /// </summary>
        Important = 0, // here for completeness, if the log is set to only include important messages then these are considered to be **extremely important** messages
        /// <summary>
        /// Represents an issue that cannot be recovered from.
        /// </summary>
        Error = 50, // anything from 0 to 50 is an error
        /// <summary>
        /// Represents an issue that can be recovered from.
        /// </summary>
        Warning = 100, // anything from 51 to 100 is a warning, this subset should include the error subset as well
        /// <summary>
        /// Represents an issue that is merely a status update.
        /// </summary>
        Information = 150, // anything from 101 to 150 is an informational message, this subset should include the warning subset and all encased subsets as well
        /// <summary>
        /// Represents a general debug message.
        /// </summary>
        Verbose = 200, // anything from 151 to 200 is a verbose message, this subset should include the informational subset and all encased subsets as well
        /// <summary>
        /// This should never be directly used by a message, but only be <see cref="ILogger.LoggingType"/>. Indicates that all messages will be logged.
        /// </summary>
        All = 255, // include anything and everything.
    }
}
