using Evbpc.Framework.Utilities.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Utilities.Prompting
{
    /// <summary>
    /// An interface for message prompts.
    /// </summary>
    public interface IPrompt
    {
        ILogger Logger { get; }

        T Prompt<T>(string message, PromptOptions options, T defaultValue = default(T), string failureMessage = null, Func<T, bool> validationMethod = null, Func<T, T> parseResultMethod = null)
            where T : IConvertible;
    }
}
