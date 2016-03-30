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
        /// Gets the type of logging the <see cref="ILogger"/> should do. I.e. <see cref="LoggingType.Information"/> to log all information and higher proirity messages.
        /// </summary>
        LoggingType LoggingType { get; }
        /// <summary>
        /// Gets the format that date and time stamps in the <see cref="ILogger"/> should use.
        /// </summary>
        string DateTimeFormat { get; }

        /// <summary>
        /// Logs a message to the <see cref="ILogger"/> with the given type, and colours if appropriate.
        /// </summary>
        /// <param name="message">The message to be sent to the <see cref="ILogger"/>.</param>
        /// <param name="type">The <see cref="Logging.LoggingType"/> the message is, for filtering.</param>
        /// <param name="foreColor">The foreground colour if the message is displayed in a graphics environment.</param>
        /// <param name="backColor">The background colour of the message is displayed in a graphics environment.</param>
        void LogMessage(string message, LoggingType type, Color.Preset foreColor = Color.Preset.Gray, Color.Preset backColor = Color.Preset.Black);

        /// <summary>
        /// Logs a <see cref="LoggingType.Information"/> message to the <see cref="ILogger"/>, formatted with the specified args.
        /// </summary>
        /// <param name="message">The <code>string</code> to be sent to the <see cref="ILogger"/>.</param>
        /// <param name="args">The arguments to be replaced into the message.</param>
        void LogInformation(string message, params object[] args);

        /// <summary>
        /// Logs a <see cref="LoggingType.Information"/> message to the <see cref="ILogger"/> with the specified colours if appropriate.
        /// </summary>
        /// <param name="message">The message to be sent to the <see cref="ILogger"/>.</param>
        /// <param name="foreColor">The foreground colour if the message is displayed in a graphics environment.</param>
        /// <param name="backColor">The background colour of the message is displayed in a graphics environment.</param>
        void LogInformation(string message, Color.Preset foreColor = Color.Preset.Gray, Color.Preset backColor = Color.Preset.Black);

        /// <summary>
        /// Logs a <see cref="LoggingType.Warning"/> message to the <see cref="ILogger"/>, formatted with the specified args.
        /// </summary>
        /// <param name="message">The <code>string</code> to be sent to the <see cref="ILogger"/>.</param>
        /// <param name="args">The arguments to be replaced into the message.</param>
        void LogWarning(string message, params object[] args);

        /// <summary>
        /// Logs a <see cref="LoggingType.Warning"/> message to the <see cref="ILogger"/> with the specified colours if appropriate.
        /// </summary>
        /// <param name="message">The message to be sent to the <see cref="ILogger"/>.</param>
        /// <param name="foreColor">The foreground colour if the message is displayed in a graphics environment.</param>
        /// <param name="backColor">The background colour of the message is displayed in a graphics environment.</param>
        void LogWarning(string message, Color.Preset foreColor = Color.Preset.DarkYellow, Color.Preset backColor = Color.Preset.Black);

        /// <summary>
        /// Logs a <see cref="LoggingType.Error"/> message to the <see cref="ILogger"/>, formatted with the specified args.
        /// </summary>
        /// <param name="message">The <code>string</code> to be sent to the <see cref="ILogger"/>.</param>
        /// <param name="args">The arguments to be replaced into the message.</param>
        void LogError(string message, params object[] args);

        /// <summary>
        /// Logs a <see cref="LoggingType.Error"/> message to the <see cref="ILogger"/> with the specified colours if appropriate.
        /// </summary>
        /// <param name="message">The message to be sent to the <see cref="ILogger"/>.</param>
        /// <param name="foreColor">The foreground colour if the message is displayed in a graphics environment.</param>
        /// <param name="backColor">The background colour of the message is displayed in a graphics environment.</param>
        void LogError(string message, Color.Preset foreColor = Color.Preset.White, Color.Preset backColor = Color.Preset.DarkRed);

        /// <summary>
        /// Logs a <see cref="LoggingType.Verbose"/> message to the <see cref="ILogger"/>, formatted with the specified args.
        /// </summary>
        /// <param name="message">The <code>string</code> to be sent to the <see cref="ILogger"/>.</param>
        /// <param name="args">The arguments to be replaced into the message.</param>
        void LogVerbose(string message, params object[] args);

        /// <summary>
        /// Logs a <see cref="LoggingType.Verbose"/> message to the <see cref="ILogger"/> with the specified colours if appropriate.
        /// </summary>
        /// <param name="message">The message to be sent to the <see cref="ILogger"/>.</param>
        /// <param name="foreColor">The foreground colour if the message is displayed in a graphics environment.</param>
        /// <param name="backColor">The background colour of the message is displayed in a graphics environment.</param>
        void LogVerbose(string message, Color.Preset foreColor = Color.Preset.Gray, Color.Preset backColor = Color.Preset.Black);

        /// <summary>
        /// Logs a <see cref="LoggingType.Important"/> message to the <see cref="ILogger"/>, formatted with the specified args.
        /// </summary>
        /// <param name="message">The <code>string</code> to be sent to the <see cref="ILogger"/>.</param>
        /// <param name="args">The arguments to be replaced into the message.</param>
        void LogImportant(string message, params object[] args);

        /// <summary>
        /// Logs a <see cref="LoggingType.Important"/> message to the <see cref="ILogger"/> with the specified colours if appropriate.
        /// </summary>
        /// <param name="message">The message to be sent to the <see cref="ILogger"/>.</param>
        /// <param name="foreColor">The foreground colour if the message is displayed in a graphics environment.</param>
        /// <param name="backColor">The background colour of the message is displayed in a graphics environment.</param>
        void LogImportant(string message, Color.Preset foreColor = Color.Preset.White, Color.Preset backColor = Color.Preset.Black);

        /// <summary>
        /// Formats a <code>string</code> with the specified arguments.
        /// </summary>
        /// <param name="message">The <code>string</code> to be formatted.</param>
        /// <param name="args">An array of valus to be replaced into the message.</param>
        /// <returns>The formatted <code>string</code>.</returns>
        string FormatMessage(string message, params object[] args);
    }
}
