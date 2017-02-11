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
        public Severity Severity { get; }

        /// <summary>
        /// Inherited from <see cref="ILogger"/>. Represents the format that dates will be presented in the <see cref="ConsoleLogger"/>.
        /// </summary>
        public string DateTimeFormat { get; }

        /// <summary>
        /// Inherited from <see cref="ILogger"/>. If not-null then this formatter will be used in place of the standard log format.
        /// </summary>
        public Func<Input, string> CustomFormatter { get; }

        private readonly Dictionary<Severity, Tuple<Color.Preset, Color.Preset>> DefaultColorMap =
            new Dictionary<Severity, Tuple<Color.Preset, Color.Preset>>
            {
                [Severity.Important] = Tuple.Create(Color.Preset.White, Color.Preset.Black),
                [Severity.Error] = Tuple.Create(Color.Preset.White, Color.Preset.DarkRed),
                [Severity.Warning] = Tuple.Create(Color.Preset.DarkYellow, Color.Preset.Black),
                [Severity.All] = Tuple.Create(Color.Preset.Gray, Color.Preset.Black),
            };

        /// <summary>
        /// Creates a new instance of a <see cref="ConsoleLogger"/> with the specified <see cref="Logging.Severity"/> and a <see cref="DateTimeFormat"/> of <code>"O"</code>.
        /// </summary>
        /// <param name="loggingType">The <see cref="Severity"/>.</param>
        public ConsoleLogger(Severity loggingType)
            : this(loggingType, "O", null)
        {

        }

        /// <summary>
        /// Creates a new instance of a <see cref="ConsoleLogger"/> with the specified <see cref="Logging.Severity"/> and a <see cref="DateTimeFormat"/> of <code>"O"</code>.
        /// </summary>
        /// <param name="loggingType">The <see cref="Severity"/>.</param>
        public ConsoleLogger(Severity loggingType, Func<Input, string> customFormatter)
            : this(loggingType, "O", customFormatter)
        {

        }

        /// <summary>
        /// Creates a new instance of a <see cref="ConsoleLogger"/> with the specified <see cref="Logging.Severity"/> and <see cref="DateTimeFormat"/>.
        /// </summary>
        /// <param name="loggingType">The <see cref="Severity"/>.</param>
        /// <param name="dateTimeFormat">The <see cref="DateTimeFormat"/>.</param>
        public ConsoleLogger(Severity loggingType, string dateTimeFormat)
            : this(loggingType, dateTimeFormat, null)
        {

        }

        /// <summary>
        /// Creates a new instance of a <see cref="ConsoleLogger"/> with the specified <see cref="Logging.Severity"/> and <see cref="DateTimeFormat"/>.
        /// </summary>
        /// <param name="loggingType">The <see cref="Severity"/>.</param>
        /// <param name="dateTimeFormat">The <see cref="DateTimeFormat"/>.</param>
        public ConsoleLogger(Severity loggingType, string dateTimeFormat, Func<Input, string> customFormatter)
        {
            Severity = loggingType;
            DateTimeFormat = dateTimeFormat;
            CustomFormatter = customFormatter;
        }

        public void Log(Severity severity, string message, Color.Preset? foreColor = null, Color.Preset? backColor = null)
        {
            if (severity <= Severity)
            {
                if (foreColor == null)
                {
                    foreColor = DefaultColorMap.First(kvp => kvp.Key >= severity).Value.Item1;
                }

                if (backColor == null)
                {
                    backColor = DefaultColorMap.First(kvp => kvp.Key >= severity).Value.Item2;
                }

                Console.ForegroundColor = (ConsoleColor)foreColor;
                Console.BackgroundColor = (ConsoleColor)backColor;
                Console.WriteLine(Format(new Input { Message = message, Severity = severity, DateTime = DateTime.UtcNow, DateTimeFormat = DateTimeFormat }));
            }
        }

        public string Format(Input input) =>
            CustomFormatter?.Invoke(input) ?? $"{input.DateTime.ToString(DateTimeFormat)}: {input.Severity.ToString()}: {input.Message}";

        /// <summary>
        /// Inherited from <see cref="ILogger"/>. Writes a generic message with the specified parameters to the <see cref="ConsoleLogger"/>.
        /// </summary>
        /// <param name="message">The <code>string</code> to write to the <see cref="ConsoleLogger"/>.</param>
        /// <param name="type">The <see cref="Logging.Severity"/> of the message.</param>
        /// <param name="foreColor">The colour that the foreground of the message should be.</param>
        /// <param name="backColor">The colour that the background of the message should be.</param>
        public void LogMessage(string message, Severity type, Color.Preset foreColor = Color.Preset.Gray, Color.Preset backColor = Color.Preset.Black)
        {
            Log(type, message, foreColor, backColor);
        }

        /// <summary>
        /// Inherited from <see cref="ILogger"/>. Logs a message with <see cref="Severity.Information"/> and the specified colours to the <see cref="ConsoleLogger"/>.
        /// </summary>
        /// <param name="message">The <code>string</code> to write to the <see cref="ConsoleLogger"/>.</param>
        /// <param name="foreColor">The colour that the foreground of the message should be.</param>
        /// <param name="backColor">The colour that the background of the message should be.</param>
        public void LogInformation(string message, Color.Preset foreColor = Color.Preset.Gray, Color.Preset backColor = Color.Preset.Black)
        {
            Log(Severity.Information, message, foreColor, backColor);
        }

        /// <summary>
        /// Inherited from <see cref="ILogger"/>. Logs a message with <see cref="Severity.Warning"/> and the specified colours to the <see cref="ConsoleLogger"/>.
        /// </summary>
        /// <param name="message">The <code>string</code> to write to the <see cref="ConsoleLogger"/>.</param>
        /// <param name="foreColor">The colour that the foreground of the message should be.</param>
        /// <param name="backColor">The colour that the background of the message should be.</param>
        public void LogWarning(string message, Color.Preset foreColor = Color.Preset.DarkYellow, Color.Preset backColor = Color.Preset.Black)
        {
            Log(Severity.Warning, message, foreColor, backColor);
        }

        /// <summary>
        /// Inherited from <see cref="ILogger"/>. Logs a message with <see cref="Severity.Error"/> and the specified colours to the <see cref="ConsoleLogger"/>.
        /// </summary>
        /// <param name="message">The <code>string</code> to write to the <see cref="ConsoleLogger"/>.</param>
        /// <param name="foreColor">The colour that the foreground of the message should be.</param>
        /// <param name="backColor">The colour that the background of the message should be.</param>
        public void LogError(string message, Color.Preset foreColor = Color.Preset.White, Color.Preset backColor = Color.Preset.DarkRed)
        {
            Log(Severity.Error, message, foreColor, backColor);
        }

        /// <summary>
        /// Inherited from <see cref="ILogger"/>. Logs a message with <see cref="Severity.Verbose"/> and the specified colours to the <see cref="ConsoleLogger"/>.
        /// </summary>
        /// <param name="message">The <code>string</code> to write to the <see cref="ConsoleLogger"/>.</param>
        /// <param name="foreColor">The colour that the foreground of the message should be.</param>
        /// <param name="backColor">The colour that the background of the message should be.</param>
        public void LogVerbose(string message, Color.Preset foreColor = Color.Preset.Gray, Color.Preset backColor = Color.Preset.Black)
        {
            Log(Severity.Verbose, message, foreColor, backColor);
        }

        /// <summary>
        /// Inherited from <see cref="ILogger"/>. Logs a message with <see cref="Severity.Important"/> and the specified colours to the <see cref="ConsoleLogger"/>.
        /// </summary>
        /// <param name="message">The <code>string</code> to write to the <see cref="ConsoleLogger"/>.</param>
        /// <param name="foreColor">The colour that the foreground of the message should be.</param>
        /// <param name="backColor">The colour that the background of the message should be.</param>
        public void LogImportant(string message, Color.Preset foreColor = Color.Preset.White, Color.Preset backColor = Color.Preset.Black)
        {
            Log(Severity.Important, message, foreColor, backColor);
        }

        /// <summary>
        /// Inherited from <see cref="ILogger"/>. Formats a message with the specified arguments. This is equivalent to <code>string.Format(message, args)</code>.
        /// </summary>  
        /// <param name="message">The <code>string</code> to be formatted.</param>
        /// <param name="args">An array of valus to be replaced into the message.</param>
        /// <returns>The formatted <code>string</code>.</returns>
        public string FormatMessage(string message, params object[] args) =>
            string.Format(message, args);

        /// <summary>
        /// Inherited from <see cref="ILogger"/>. Logs a message with <see cref="Severity.Information"/> and the specified arguments to the <see cref="ConsoleLogger"/>.
        /// </summary>
        /// <param name="message">The unformatted <code>string</code> to be logged.</param>
        /// <param name="args">An array of values to be replaced into the message.</param>
        public void LogInformation(string message, params object[] args)
        {
            Log(Severity.Information, string.Format(message, args));
        }

        /// <summary>
        /// Inherited from <see cref="ILogger"/>. Logs a message with <see cref="Severity.Warning"/> and the specified arguments to the <see cref="ConsoleLogger"/>.
        /// </summary>
        /// <param name="message">The unformatted <code>string</code> to be logged.</param>
        /// <param name="args">An array of values to be replaced into the message.</param>
        public void LogWarning(string message, params object[] args)
        {
            Log(Severity.Warning, string.Format(message, args));
        }

        /// <summary>
        /// Inherited from <see cref="ILogger"/>. Logs a message with <see cref="Severity.Error"/> and the specified arguments to the <see cref="ConsoleLogger"/>.
        /// </summary>
        /// <param name="message">The unformatted <code>string</code> to be logged.</param>
        /// <param name="args">An array of values to be replaced into the message.</param>
        public void LogError(string message, params object[] args)
        {
            Log(Severity.Error, string.Format(message, args));
        }

        /// <summary>
        /// Inherited from <see cref="ILogger"/>. Logs a message with <see cref="Severity.Verbose"/> and the specified arguments to the <see cref="ConsoleLogger"/>.
        /// </summary>
        /// <param name="message">The unformatted <code>string</code> to be logged.</param>
        /// <param name="args">An array of values to be replaced into the message.</param>
        public void LogVerbose(string message, params object[] args)
        {
            Log(Severity.Verbose, string.Format(message, args));
        }

        /// <summary>
        /// Inherited from <see cref="ILogger"/>. Logs a message with <see cref="Severity.Important"/> and the specified arguments to the <see cref="ConsoleLogger"/>.
        /// </summary>
        /// <param name="message">The unformatted <code>string</code> to be logged.</param>
        /// <param name="args">An array of values to be replaced into the message.</param>
        public void LogImportant(string message, params object[] args)
        {
            Log(Severity.Important, string.Format(message, args));
        }
    }
}
