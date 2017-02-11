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
                logger.LogError(message, args);
            }
        }

        public void LogError(string message, Color.Preset foreColor = Color.Preset.White, Color.Preset backColor = Color.Preset.DarkRed)
        {
            foreach (var logger in Loggers)
            {
                logger.LogError(message, foreColor, backColor);
            }
        }

        public void LogImportant(string message, params object[] args)
        {
            foreach (var logger in Loggers)
            {
                logger.LogImportant(message, args);
            }
        }

        public void LogImportant(string message, Color.Preset foreColor = Color.Preset.White, Color.Preset backColor = Color.Preset.Black)
        {
            foreach (var logger in Loggers)
            {
                logger.LogImportant(message, foreColor, backColor);
            }
        }

        public void LogInformation(string message, params object[] args)
        {
            foreach (var logger in Loggers)
            {
                logger.LogInformation(message, args);
            }
        }

        public void LogInformation(string message, Color.Preset foreColor = Color.Preset.Gray, Color.Preset backColor = Color.Preset.Black)
        {
            foreach (var logger in Loggers)
            {
                logger.LogInformation(message, foreColor, backColor);
            }
        }

        public void LogMessage(string message, LoggingType type, Color.Preset foreColor = Color.Preset.Gray, Color.Preset backColor = Color.Preset.Black)
        {
            foreach (var logger in Loggers)
            {
                logger.LogMessage(message, type, foreColor, backColor);
            }
        }

        public void LogVerbose(string message, params object[] args)
        {
            foreach (var logger in Loggers)
            {
                logger.LogVerbose(message, args);
            }
        }

        public void LogVerbose(string message, Color.Preset foreColor = Color.Preset.Gray, Color.Preset backColor = Color.Preset.Black)
        {
            foreach (var logger in Loggers)
            {
                logger.LogVerbose(message, foreColor, backColor);
            }
        }

        public void LogWarning(string message, params object[] args)
        {
            foreach (var logger in Loggers)
            {
                logger.LogWarning(message, args);
            }
        }

        public void LogWarning(string message, Color.Preset foreColor = Color.Preset.DarkYellow, Color.Preset backColor = Color.Preset.Black)
        {
            foreach (var logger in Loggers)
            {
                logger.LogWarning(message, foreColor, backColor);
            }
        }
    }
}
