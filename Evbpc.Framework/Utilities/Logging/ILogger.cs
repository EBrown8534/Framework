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
        string DateTimeFormat { get; }

        /// <summary>
        /// Logs a message to the <see cref="ILogger"/> with the given type, and colours if appropriate.
        /// </summary>
        /// <param name="message">The message to be sent to the <see cref="ILogger"/>.</param>
        /// <param name="type">The <see cref="LoggingType"/> the message is, for filtering.</param>
        /// <param name="foreColor">The foreground color if the message is displayed in a graphics environment.</param>
        /// <param name="backColor">The background color of the message is displayed in a graphics environment.</param>
        void LogMessage(string message, LoggingType type, Color.Preset foreColor = Color.Preset.Gray, Color.Preset backColor = Color.Preset.Black);
        void LogInformation(string message, params Object[] args);
        void LogInformation(string message, Color.Preset foreColor = Color.Preset.Gray, Color.Preset backColor = Color.Preset.Black);
        void LogWarning(string message, params Object[] args);
        void LogWarning(string message, Color.Preset foreColor = Color.Preset.DarkYellow, Color.Preset backColor = Color.Preset.Black);
        void LogError(string message, params Object[] args);
        void LogError(string message, Color.Preset foreColor = Color.Preset.DarkRed, Color.Preset backColor = Color.Preset.DarkRed);
        void LogVerbose(string message, params Object[] args);
        void LogVerbose(string message, Color.Preset foreColor = Color.Preset.Gray, Color.Preset backColor = Color.Preset.Black);
        void LogImportant(string message, params Object[] args);
        void LogImportant(string message, Color.Preset foreColor = Color.Preset.White, Color.Preset backColor = Color.Preset.Black);

        string FormatMessage(string message, params Object[] args);
    }
}
