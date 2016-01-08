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
        /// <summary>
        /// A <see cref="ILogger"/> that <see cref="IPrompt"/> errors/messages should be posted to.
        /// </summary>
        ILogger Logger { get; }

        /// <summary>
        /// Prompts the user for input.
        /// </summary>
        /// <typeparam name="T">The type of input that should be returned.</typeparam>
        /// <param name="message">The message to initally display to the user.</param>
        /// <param name="options">The <see cref="PromptOptions"/> that specify how the prompt should be treated.</param>
        /// <param name="defaultValue">The default value to be returned if a user enters an empty line (`""`).</param>
        /// <param name="failureMessage">An optional message to display on a failure. If null, then the `message` parameter will be displayed on failure.</param>
        /// <param name="validationMethod">An optional delegate to a method which can perform additional validation if the input is of the target type.</param>
        /// <param name="parseResultMethod">An optional delegate to a method which will parse the final result (assuming validity checks all pass).</param>
        /// <returns>The input collected from the user when it is deemed valid.</returns>
        T Prompt<T>(string message, PromptOptions options, T defaultValue = default(T), string failureMessage = null, Func<T, bool> validationMethod = null, Func<T, T> parseResultMethod = null)
            where T : IConvertible;

        /// <summary>
        /// Prompts the user for input.
        /// </summary>
        /// <typeparam name="T">The type of input that should be returned.</typeparam>
        /// <param name="result">Filled with the result of collecting the input from the user and applying it to the specified type.</param>
        /// <param name="message">The message to initally display to the user.</param>
        /// <param name="options">The <see cref="PromptOptions"/> that specify how the prompt should be treated.</param>
        /// <param name="defaultValue">The default value to be returned if a user enters an empty line (`""`).</param>
        /// <param name="failureMessage">An optional message to display on a failure. If null, then the `message` parameter will be displayed on failure.</param>
        /// <param name="validationMethod">An optional delegate to a method which can perform additional validation if the input is of the target type.</param>
        /// <param name="parseResultMethod">An optional delegate to a method which will parse the final result (assuming validity checks all pass).</param>
        /// <param name="maxTries">An optional integer specifying the maximum number of attempts to make. If <code>0</code> or smaller then the number of attempts will not be limited.</param>
        /// <returns>A boolean value indicating success. If <code>true</code> then result is filled with the user specified input, or the default value. If <code>false</code> then result will be <code>default(T)</code>.</returns>
        bool Prompt<T>(out T result, string message, PromptOptions options, T defaultValue = default(T), string failureMessage = null, Func<T, bool> validationMethod = null, Func<T, T> parseResultMethod = null, int maxTries = 0)
            where T : IConvertible;
    }
}
