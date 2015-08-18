using Evbpc.Framework.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evbpc.Framework.Utilities.Logging
{
    public class ConsoleLogger : ILogger
    {
        public LoggingType LoggingType { get; private set; }

        public string DateTimeFormat { get; private set; }

        public ConsoleLogger(LoggingType loggingType)
            : this(loggingType, "O")
        {

        }

        public ConsoleLogger(LoggingType loggingType, string dateTimeFormat)
        {
            LoggingType = loggingType;
            DateTimeFormat = dateTimeFormat;
        }

        public void LogMessage(string message, LoggingType type, Color.Preset foreColor = Color.Preset.Gray, Color.Preset backColor = Color.Preset.Black)
        {
            if (type <= LoggingType)
            {
                Console.ForegroundColor = (ConsoleColor)foreColor;
                Console.BackgroundColor = (ConsoleColor)backColor;
                Console.WriteLine("{0}: {1}: {2}", DateTime.UtcNow.ToString(DateTimeFormat), type.ToString(), message);
            }
        }

        public void LogInformation(string message, Color.Preset foreColor = Color.Preset.Gray, Color.Preset backColor = Color.Preset.Black)
        {
            LogMessage(message, LoggingType.Information, foreColor, backColor);
        }

        public void LogWarning(string message, Color.Preset foreColor = Color.Preset.DarkYellow, Color.Preset backColor = Color.Preset.Black)
        {
            LogMessage(message, LoggingType.Warning, foreColor, backColor);
        }

        public void LogError(string message, Color.Preset foreColor = Color.Preset.DarkRed, Color.Preset backColor = Color.Preset.DarkRed)
        {
            LogMessage(message, LoggingType.Error, foreColor, backColor);
        }

        public void LogVerbose(string message, Color.Preset foreColor = Color.Preset.Gray, Color.Preset backColor = Color.Preset.Black)
        {
            LogMessage(message, LoggingType.Verbose, foreColor, backColor);
        }

        public void LogImportant(string message, Color.Preset foreColor = Color.Preset.White, Color.Preset backColor = Color.Preset.Black)
        {
            LogMessage(message, LoggingType.Important, foreColor, backColor);
        }

        public string FormatMessage(string message, params object[] args)
        {
            return string.Format(message, args);
        }

        public void LogInformation(string message, params object[] args)
        {
            LogInformation(FormatMessage(message, args));
        }

        public void LogWarning(string message, params object[] args)
        {
            LogWarning(FormatMessage(message, args));
        }

        public void LogError(string message, params object[] args)
        {
            LogError(FormatMessage(message, args));
        }

        public void LogVerbose(string message, params object[] args)
        {
            LogVerbose(FormatMessage(message, args));
        }

        public void LogImportant(string message, params object[] args)
        {
            LogImportant(FormatMessage(message, args));
        }
    }
}
