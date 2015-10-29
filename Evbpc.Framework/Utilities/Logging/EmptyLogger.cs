using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evbpc.Framework.Drawing;

namespace Evbpc.Framework.Utilities.Logging
{
    /// <summary>
    /// An <see cref="ILogger"/> that logs to nowhere. Useful when logs are not needed.
    /// </summary>
    public class EmptyLogger : ILogger
    {
        /// <summary>
        /// This property is not used in this <see cref="ILogger"/> implementation.
        /// </summary>
        public string DateTimeFormat { get; }

        /// <summary>
        /// This property is not used in this <see cref="ILogger"/> implementation.
        /// </summary>
        public LoggingType LoggingType { get; }

        /// <summary>
        /// Formats a message.
        /// </summary>
        /// <param name="message">The message (with formatting keys) to format.</param>
        /// <param name="args">The arguments to format into the message.</param>
        /// <returns>The formatted message.</returns>
        public string FormatMessage(string message, params object[] args)
        {
            return string.Format(message, args);
        }
        
        /// <summary>
        /// No-op implementation.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="args"></param>
        public void LogError(string message, params object[] args)
        {
        }

        /// <summary>
        /// No-op implementation.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="foreColor"></param>
        /// <param name="backColor"></param>
        public void LogError(string message, Color.Preset foreColor = Color.Preset.DarkRed, Color.Preset backColor = Color.Preset.DarkRed)
        {
        }

        /// <summary>
        /// No-op implementation.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="args"></param>
        public void LogImportant(string message, params object[] args)
        {
        }

        /// <summary>
        /// No-op implementation.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="foreColor"></param>
        /// <param name="backColor"></param>
        public void LogImportant(string message, Color.Preset foreColor = Color.Preset.White, Color.Preset backColor = Color.Preset.Black)
        {
        }

        /// <summary>
        /// No-op implementation.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="args"></param>
        public void LogInformation(string message, params object[] args)
        {
        }

        /// <summary>
        /// No-op implementation.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="foreColor"></param>
        /// <param name="backColor"></param>
        public void LogInformation(string message, Color.Preset foreColor = Color.Preset.Gray, Color.Preset backColor = Color.Preset.Black)
        {
        }

        /// <summary>
        /// No-op implementation.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="type"></param>
        /// <param name="foreColor"></param>
        /// <param name="backColor"></param>
        public void LogMessage(string message, LoggingType type, Color.Preset foreColor = Color.Preset.Gray, Color.Preset backColor = Color.Preset.Black)
        {
        }

        /// <summary>
        /// No-op implementation.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="args"></param>
        public void LogVerbose(string message, params object[] args)
        {
        }

        /// <summary>
        /// No-op implementation.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="foreColor"></param>
        /// <param name="backColor"></param>
        public void LogVerbose(string message, Color.Preset foreColor = Color.Preset.Gray, Color.Preset backColor = Color.Preset.Black)
        {
        }

        /// <summary>
        /// No-op implementation.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="args"></param>
        public void LogWarning(string message, params object[] args)
        {
        }

        /// <summary>
        /// No-op implementation.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="foreColor"></param>
        /// <param name="backColor"></param>
        public void LogWarning(string message, Color.Preset foreColor = Color.Preset.DarkYellow, Color.Preset backColor = Color.Preset.Black)
        {
        }
    }
}
