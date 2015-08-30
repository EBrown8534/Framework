using Evbpc.Framework.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evbpc.Framework.Utilities.Logging
{
    /// <summary>
    /// An <see cref="ILogger"/> that writes output directly to the <code>Console</code>.
    /// </summary>
    public class ConsoleLogger : ILogger
    {
        /// <summary>
        /// Inherited from <see cref="ILogger"/>. Represents the sensitivity of the <see cref="ConsoleLogger"/>.
        /// </summary>
        public LoggingType LoggingType { get; }

        /// <summary>
        /// Inherited from <see cref="ILogger"/>. Represents the format that dates will be presented in the <see cref="ConsoleLogger"/>.
        /// </summary>
        public string DateTimeFormat { get; }

        /// <summary>
        /// Creates a new instance of a <see cref="ConsoleLogger"/> with the specified <see cref="LoggingType"/> and a <see cref="DateTimeFormat"/> of <code>"O"</code>.
        /// </summary>
        /// <param name="loggingType">The <see cref="ConsoleLogger.LoggingType"/>.</param>
        public ConsoleLogger(LoggingType loggingType)
            : this(loggingType, "O")
        {

        }

        /// <summary>
        /// Creates a new instance of a <see cref="ConsoleLogger"/> with the specified <see cref="LoggingType"/> and <see cref="DateTimeFormat"/>.
        /// </summary>
        /// <param name="loggingType">The <see cref="ConsoleLogger.LoggingType"/>.</param>
        /// <param name="dateTimeFormat">The <see cref="ConsoleLogger.DateTimeFormat"/>.</param>
        public ConsoleLogger(LoggingType loggingType, string dateTimeFormat)
        {
            LoggingType = loggingType;
            DateTimeFormat = dateTimeFormat;
        }

        /// <summary>
        /// Inherited from <see cref="ILogger"/>. Writes a generic message with the specified parameters to the <see cref="ConsoleLogger"/>.
        /// </summary>
        /// <param name="message">The <code>string</code> to write to the <see cref="ConsoleLogger"/>.</param>
        /// <param name="type">The <see cref="Logging.LoggingType"/> of the message.</param>
        /// <param name="foreColor">The colour that the foreground of the message should be.</param>
        /// <param name="backColor">The colour that the background of the message should be.</param>
        public void LogMessage(string message, LoggingType type, Color.Preset foreColor = Color.Preset.Gray, Color.Preset backColor = Color.Preset.Black)
        {
            if (type <= LoggingType)
            {
                Console.ForegroundColor = (ConsoleColor)foreColor;
                Console.BackgroundColor = (ConsoleColor)backColor;
                Console.WriteLine("{0}: {1}: {2}", DateTime.UtcNow.ToString(DateTimeFormat), type.ToString(), message);
            }
        }

        /// <summary>
        /// Inherited from <see cref="ILogger"/>. Logs a message with <see cref="LoggingType.Information"/> and the specified colours to the <see cref="ConsoleLogger"/>.
        /// </summary>
        /// <param name="message">The <code>string</code> to write to the <see cref="ConsoleLogger"/>.</param>
        /// <param name="foreColor">The colour that the foreground of the message should be.</param>
        /// <param name="backColor">The colour that the background of the message should be.</param>
        public void LogInformation(string message, Color.Preset foreColor = Color.Preset.Gray, Color.Preset backColor = Color.Preset.Black)
        {
            LogMessage(message, LoggingType.Information, foreColor, backColor);
        }

        /// <summary>
        /// Inherited from <see cref="ILogger"/>. Logs a message with <see cref="LoggingType.Warning"/> and the specified colours to the <see cref="ConsoleLogger"/>.
        /// </summary>
        /// <param name="message">The <code>string</code> to write to the <see cref="ConsoleLogger"/>.</param>
        /// <param name="foreColor">The colour that the foreground of the message should be.</param>
        /// <param name="backColor">The colour that the background of the message should be.</param>
        public void LogWarning(string message, Color.Preset foreColor = Color.Preset.DarkYellow, Color.Preset backColor = Color.Preset.Black)
        {
            LogMessage(message, LoggingType.Warning, foreColor, backColor);
        }

        /// <summary>
        /// Inherited from <see cref="ILogger"/>. Logs a message with <see cref="LoggingType.Error"/> and the specified colours to the <see cref="ConsoleLogger"/>.
        /// </summary>
        /// <param name="message">The <code>string</code> to write to the <see cref="ConsoleLogger"/>.</param>
        /// <param name="foreColor">The colour that the foreground of the message should be.</param>
        /// <param name="backColor">The colour that the background of the message should be.</param>
        public void LogError(string message, Color.Preset foreColor = Color.Preset.DarkRed, Color.Preset backColor = Color.Preset.DarkRed)
        {
            LogMessage(message, LoggingType.Error, foreColor, backColor);
        }

        /// <summary>
        /// Inherited from <see cref="ILogger"/>. Logs a message with <see cref="LoggingType.Verbose"/> and the specified colours to the <see cref="ConsoleLogger"/>.
        /// </summary>
        /// <param name="message">The <code>string</code> to write to the <see cref="ConsoleLogger"/>.</param>
        /// <param name="foreColor">The colour that the foreground of the message should be.</param>
        /// <param name="backColor">The colour that the background of the message should be.</param>
        public void LogVerbose(string message, Color.Preset foreColor = Color.Preset.Gray, Color.Preset backColor = Color.Preset.Black)
        {
            LogMessage(message, LoggingType.Verbose, foreColor, backColor);
        }

        /// <summary>
        /// Inherited from <see cref="ILogger"/>. Logs a message with <see cref="LoggingType.Important"/> and the specified colours to the <see cref="ConsoleLogger"/>.
        /// </summary>
        /// <param name="message">The <code>string</code> to write to the <see cref="ConsoleLogger"/>.</param>
        /// <param name="foreColor">The colour that the foreground of the message should be.</param>
        /// <param name="backColor">The colour that the background of the message should be.</param>
        public void LogImportant(string message, Color.Preset foreColor = Color.Preset.White, Color.Preset backColor = Color.Preset.Black)
        {
            LogMessage(message, LoggingType.Important, foreColor, backColor);
        }

        /// <summary>
        /// Inherited from <see cref="ILogger"/>. Formats a message with the specified arguments. This is equivalent to <code>string.Format(message, args)</code>.
        /// </summary>  
        /// <param name="message">The <code>string</code> to be formatted.</param>
        /// <param name="args">An array of valus to be replaced into the message.</param>
        /// <returns>The formatted <code>string</code>.</returns>
        public string FormatMessage(string message, params object[] args)
        {
            return string.Format(message, args);
        }

        /// <summary>
        /// Inherited from <see cref="ILogger"/>. Logs a message with <see cref="LoggingType.Information"/> and the specified arguments to the <see cref="ConsoleLogger"/>.
        /// </summary>
        /// <param name="message">The unformatted <code>string</code> to be logged.</param>
        /// <param name="args">An array of values to be replaced into the message.</param>
        public void LogInformation(string message, params object[] args)
        {
            LogInformation(FormatMessage(message, args));
        }

        /// <summary>
        /// Inherited from <see cref="ILogger"/>. Logs a message with <see cref="LoggingType.Warning"/> and the specified arguments to the <see cref="ConsoleLogger"/>.
        /// </summary>
        /// <param name="message">The unformatted <code>string</code> to be logged.</param>
        /// <param name="args">An array of values to be replaced into the message.</param>
        public void LogWarning(string message, params object[] args)
        {
            LogWarning(FormatMessage(message, args));
        }
        
        /// <summary>
        /// Inherited from <see cref="ILogger"/>. Logs a message with <see cref="LoggingType.Error"/> and the specified arguments to the <see cref="ConsoleLogger"/>.
        /// </summary>
        /// <param name="message">The unformatted <code>string</code> to be logged.</param>
        /// <param name="args">An array of values to be replaced into the message.</param>
        public void LogError(string message, params object[] args)
        {
            LogError(FormatMessage(message, args));
        }

        /// <summary>
        /// Inherited from <see cref="ILogger"/>. Logs a message with <see cref="LoggingType.Verbose"/> and the specified arguments to the <see cref="ConsoleLogger"/>.
        /// </summary>
        /// <param name="message">The unformatted <code>string</code> to be logged.</param>
        /// <param name="args">An array of values to be replaced into the message.</param>
        public void LogVerbose(string message, params object[] args)
        {
            LogVerbose(FormatMessage(message, args));
        }

        /// <summary>
        /// Inherited from <see cref="ILogger"/>. Logs a message with <see cref="LoggingType.Important"/> and the specified arguments to the <see cref="ConsoleLogger"/>.
        /// </summary>
        /// <param name="message">The unformatted <code>string</code> to be logged.</param>
        /// <param name="args">An array of values to be replaced into the message.</param>
        public void LogImportant(string message, params object[] args)
        {
            LogImportant(FormatMessage(message, args));
        }
    }
}
