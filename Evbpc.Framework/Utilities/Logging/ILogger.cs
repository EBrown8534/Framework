using Evbpc.Framework.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evbpc.Framework.Utilities.Logging
{
    /// <summary>
    /// Defines an interface for common methods all objects that carry logs should share.
    /// </summary>
    /// <remarks>
    /// There are no specifics that say <bold>what</bold> has to be logged or <bold>how</bold>, just that the <see cref="ILogger"/> must implement these methods/properties.
    /// </remarks>
    public interface ILogger
    {
        /// <summary>
        /// Gets the type of logging the <see cref="ILogger"/> should do. I.e. <see cref="Severity.Information"/> to log all information and higher proirity messages.
        /// </summary>
        Severity Severity { get; }
        /// <summary>
        /// Gets the format that date and time stamps in the <see cref="ILogger"/> should use.
        /// </summary>
        string DateTimeFormat { get; }
        /// <summary>
        /// Gets the custom format method for the <see cref="ILogger"/>. If not-null then this will be used in place of the standard messages.
        /// </summary>
        Func<Input, string> CustomFormatter { get; }

        /// <summary>
        /// Logs a message to the <see cref="ILogger"/> with the given type, and colours if appropriate.
        /// </summary>
        /// <param name="severity">The <see cref="Logging.Severity"/> the message is, for filtering.</param>
        /// <param name="message">The message to be sent to the <see cref="ILogger"/>.</param>
        /// <param name="foreColor">The foreground colour if the message is displayed in a graphics environment.</param>
        /// <param name="backColor">The background colour of the message is displayed in a graphics environment.</param>
        void Log(Severity severity, string message, Color.Preset? foreColor = null, Color.Preset? backColor = null);
        
        /// <summary>
        /// Logs a message to the <see cref="ILogger"/> with the given type, and colours if appropriate.
        /// </summary>
        /// <param name="message">The message to be sent to the <see cref="ILogger"/>.</param>
        /// <param name="type">The <see cref="Logging.Severity"/> the message is, for filtering.</param>
        /// <param name="foreColor">The foreground colour if the message is displayed in a graphics environment.</param>
        /// <param name="backColor">The background colour of the message is displayed in a graphics environment.</param>
        [Obsolete("This method is obsolete and may not be implemented, you should prefer " + nameof(Log) + " instead.")]
        void LogMessage(string message, Severity type, Color.Preset foreColor = Color.Preset.Gray, Color.Preset backColor = Color.Preset.Black);

        /// <summary>
        /// Logs a <see cref="Severity.Information"/> message to the <see cref="ILogger"/>, formatted with the specified args.
        /// </summary>
        /// <param name="message">The <code>string</code> to be sent to the <see cref="ILogger"/>.</param>
        /// <param name="args">The arguments to be replaced into the message.</param>
        [Obsolete("This method is obsolete and may not be implemented, you should prefer " + nameof(Log) + " instead.")]
        void LogInformation(string message, params object[] args);

        /// <summary>
        /// Logs a <see cref="Severity.Information"/> message to the <see cref="ILogger"/> with the specified colours if appropriate.
        /// </summary>
        /// <param name="message">The message to be sent to the <see cref="ILogger"/>.</param>
        /// <param name="foreColor">The foreground colour if the message is displayed in a graphics environment.</param>
        /// <param name="backColor">The background colour of the message is displayed in a graphics environment.</param>
        [Obsolete("This method is obsolete and may not be implemented, you should prefer " + nameof(Log) + " instead.")]
        void LogInformation(string message, Color.Preset foreColor = Color.Preset.Gray, Color.Preset backColor = Color.Preset.Black);

        /// <summary>
        /// Logs a <see cref="Severity.Warning"/> message to the <see cref="ILogger"/>, formatted with the specified args.
        /// </summary>
        /// <param name="message">The <code>string</code> to be sent to the <see cref="ILogger"/>.</param>
        /// <param name="args">The arguments to be replaced into the message.</param>
        [Obsolete("This method is obsolete and may not be implemented, you should prefer " + nameof(Log) + " instead.")]
        void LogWarning(string message, params object[] args);

        /// <summary>
        /// Logs a <see cref="Severity.Warning"/> message to the <see cref="ILogger"/> with the specified colours if appropriate.
        /// </summary>
        /// <param name="message">The message to be sent to the <see cref="ILogger"/>.</param>
        /// <param name="foreColor">The foreground colour if the message is displayed in a graphics environment.</param>
        /// <param name="backColor">The background colour of the message is displayed in a graphics environment.</param>
        [Obsolete("This method is obsolete and may not be implemented, you should prefer " + nameof(Log) + " instead.")]
        void LogWarning(string message, Color.Preset foreColor = Color.Preset.DarkYellow, Color.Preset backColor = Color.Preset.Black);

        /// <summary>
        /// Logs a <see cref="Severity.Error"/> message to the <see cref="ILogger"/>, formatted with the specified args.
        /// </summary>
        /// <param name="message">The <code>string</code> to be sent to the <see cref="ILogger"/>.</param>
        /// <param name="args">The arguments to be replaced into the message.</param>
        [Obsolete("This method is obsolete and may not be implemented, you should prefer " + nameof(Log) + " instead.")]
        void LogError(string message, params object[] args);

        /// <summary>
        /// Logs a <see cref="Severity.Error"/> message to the <see cref="ILogger"/> with the specified colours if appropriate.
        /// </summary>
        /// <param name="message">The message to be sent to the <see cref="ILogger"/>.</param>
        /// <param name="foreColor">The foreground colour if the message is displayed in a graphics environment.</param>
        /// <param name="backColor">The background colour of the message is displayed in a graphics environment.</param>
        [Obsolete("This method is obsolete and may not be implemented, you should prefer " + nameof(Log) + " instead.")]
        void LogError(string message, Color.Preset foreColor = Color.Preset.White, Color.Preset backColor = Color.Preset.DarkRed);

        /// <summary>
        /// Logs a <see cref="Severity.Verbose"/> message to the <see cref="ILogger"/>, formatted with the specified args.
        /// </summary>
        /// <param name="message">The <code>string</code> to be sent to the <see cref="ILogger"/>.</param>
        /// <param name="args">The arguments to be replaced into the message.</param>
        [Obsolete("This method is obsolete and may not be implemented, you should prefer " + nameof(Log) + " instead.")]
        void LogVerbose(string message, params object[] args);

        /// <summary>
        /// Logs a <see cref="Severity.Verbose"/> message to the <see cref="ILogger"/> with the specified colours if appropriate.
        /// </summary>
        /// <param name="message">The message to be sent to the <see cref="ILogger"/>.</param>
        /// <param name="foreColor">The foreground colour if the message is displayed in a graphics environment.</param>
        /// <param name="backColor">The background colour of the message is displayed in a graphics environment.</param>
        [Obsolete("This method is obsolete and may not be implemented, you should prefer " + nameof(Log) + " instead.")]
        void LogVerbose(string message, Color.Preset foreColor = Color.Preset.Gray, Color.Preset backColor = Color.Preset.Black);

        /// <summary>
        /// Logs a <see cref="Severity.Important"/> message to the <see cref="ILogger"/>, formatted with the specified args.
        /// </summary>
        /// <param name="message">The <code>string</code> to be sent to the <see cref="ILogger"/>.</param>
        /// <param name="args">The arguments to be replaced into the message.</param>
        [Obsolete("This method is obsolete and may not be implemented, you should prefer " + nameof(Log) + " instead.")]
        void LogImportant(string message, params object[] args);

        /// <summary>
        /// Logs a <see cref="Severity.Important"/> message to the <see cref="ILogger"/> with the specified colours if appropriate.
        /// </summary>
        /// <param name="message">The message to be sent to the <see cref="ILogger"/>.</param>
        /// <param name="foreColor">The foreground colour if the message is displayed in a graphics environment.</param>
        /// <param name="backColor">The background colour of the message is displayed in a graphics environment.</param>
        [Obsolete("This method is obsolete and may not be implemented, you should prefer " + nameof(Log) + " instead.")]
        void LogImportant(string message, Color.Preset foreColor = Color.Preset.White, Color.Preset backColor = Color.Preset.Black);

        /// <summary>
        /// Formats a <code>string</code> with the specified arguments.
        /// </summary>
        /// <param name="message">The <code>string</code> to be formatted.</param>
        /// <param name="args">An array of valus to be replaced into the message.</param>
        /// <returns>The formatted <code>string</code>.</returns>
        [Obsolete("This method is obsolete and may not be implemented, you should prefer " + nameof(Format) + " instead.")]
        string FormatMessage(string message, params object[] args);

        string Format(Input input);
    }
}
