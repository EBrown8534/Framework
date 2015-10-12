using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Utilities.Prompting
{
    /// <summary>
    /// Indicates what options should be applied to a <see cref="IPrompt.Prompt{T}(string, PromptOptions, T, string, Func{T, bool}, Func{T, T})"/> method.
    /// </summary>
    public enum PromptOptions
    {
        /// <summary>
        /// Indicates that the parameter is required.
        /// </summary>
        Required,
        /// <summary>
        /// Indicates that the parameter is optional, and a default value may be used.
        /// </summary>
        Optional,
    }
}
