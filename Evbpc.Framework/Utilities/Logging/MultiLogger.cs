using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evbpc.Framework.Drawing;

namespace Evbpc.Framework.Utilities.Logging
{
    public class MultiLogger : ILogger
    {
        public string DateTimeFormat { get; } = string.Empty;

        public LoggingType LoggingType { get; } = LoggingType.All;

        public IEnumerable<ILogger> Loggers { get; }

        public MultiLogger(IEnumerable<ILogger> loggers)
        {
            Loggers = loggers;
        }

        public MultiLogger(params ILogger[] loggers)
        {
            Loggers = loggers;
        }

        public string FormatMessage(string message, params object[] args) =>
            string.Format(message, args);

        public void LogError(string message, params object[] args)
        {
            foreach (var logger in Loggers)
            {
                logger.Log(LoggingType.Error, FormatMessage(message, args));
            }
        }

        public void LogError(string message, Color.Preset foreColor = Color.Preset.White, Color.Preset backColor = Color.Preset.DarkRed)
        {
            foreach (var logger in Loggers)
            {
                logger.Log(LoggingType.Error, message, foreColor, backColor);
            }
        }

        public void LogImportant(string message, params object[] args)
        {
            foreach (var logger in Loggers)
            {
                logger.Log(LoggingType.Important, FormatMessage(message, args));
            }
        }

        public void LogImportant(string message, Color.Preset foreColor = Color.Preset.White, Color.Preset backColor = Color.Preset.Black)
        {
            foreach (var logger in Loggers)
            {
                logger.Log(LoggingType.Important, message, foreColor, backColor);
            }
        }

        public void LogInformation(string message, params object[] args)
        {
            foreach (var logger in Loggers)
            {
                logger.Log(LoggingType.Information, FormatMessage(message, args));
            }
        }

        public void LogInformation(string message, Color.Preset foreColor = Color.Preset.Gray, Color.Preset backColor = Color.Preset.Black)
        {
            foreach (var logger in Loggers)
            {
                logger.Log(LoggingType.Information, message, foreColor, backColor);
            }
        }

        public void LogMessage(string message, LoggingType type, Color.Preset foreColor = Color.Preset.Gray, Color.Preset backColor = Color.Preset.Black)
        {
            foreach (var logger in Loggers)
            {
                logger.Log(type, message, foreColor, backColor);
            }
        }

        public void LogVerbose(string message, params object[] args)
        {
            foreach (var logger in Loggers)
            {
                logger.Log(LoggingType.Verbose, FormatMessage(message, args));
            }
        }

        public void LogVerbose(string message, Color.Preset foreColor = Color.Preset.Gray, Color.Preset backColor = Color.Preset.Black)
        {
            foreach (var logger in Loggers)
            {
                logger.Log(LoggingType.Verbose, message, foreColor, backColor);
            }
        }

        public void LogWarning(string message, params object[] args)
        {
            foreach (var logger in Loggers)
            {
                logger.Log(LoggingType.Warning, FormatMessage(message, args));
            }
        }

        public void LogWarning(string message, Color.Preset foreColor = Color.Preset.DarkYellow, Color.Preset backColor = Color.Preset.Black)
        {
            foreach (var logger in Loggers)
            {
                logger.Log(LoggingType.Warning, message, foreColor, backColor);
            }
        }

        public void Log(LoggingType type, string message, Color.Preset foreColor = Color.Preset.Gray, Color.Preset backColor = Color.Preset.Black)
        {
            foreach (var logger in Loggers)
            {
                Log(type, message, foreColor, backColor);
            }
        }
    }
}
