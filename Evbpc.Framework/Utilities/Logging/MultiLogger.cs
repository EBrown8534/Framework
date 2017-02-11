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

        public Severity Severity { get; } = Severity.All;

        public IEnumerable<ILogger> Loggers { get; }

        public Func<Input, string> CustomFormatter { get; }

        public MultiLogger(IEnumerable<ILogger> loggers, Func<Input, string> customFormatter = null)
        {
            Loggers = loggers;
            CustomFormatter = customFormatter;
        }

        public MultiLogger(Func<Input, string> customFormatter, params ILogger[] loggers)
            : this(loggers, customFormatter)
        {

        }

        public MultiLogger(params ILogger[] loggers)
            : this(loggers, null)
        {

        }

        public string FormatMessage(string message, params object[] args) =>
            string.Format(message, args);

        public void LogError(string message, params object[] args)
        {
            foreach (var logger in Loggers)
            {
                logger.Log(Severity.Error, FormatMessage(message, args));
            }
        }

        public void LogError(string message, Color.Preset foreColor = Color.Preset.White, Color.Preset backColor = Color.Preset.DarkRed)
        {
            foreach (var logger in Loggers)
            {
                logger.Log(Severity.Error, message, foreColor, backColor);
            }
        }

        public void LogImportant(string message, params object[] args)
        {
            foreach (var logger in Loggers)
            {
                logger.Log(Severity.Important, FormatMessage(message, args));
            }
        }

        public void LogImportant(string message, Color.Preset foreColor = Color.Preset.White, Color.Preset backColor = Color.Preset.Black)
        {
            foreach (var logger in Loggers)
            {
                logger.Log(Severity.Important, message, foreColor, backColor);
            }
        }

        public void LogInformation(string message, params object[] args)
        {
            foreach (var logger in Loggers)
            {
                logger.Log(Severity.Information, FormatMessage(message, args));
            }
        }

        public void LogInformation(string message, Color.Preset foreColor = Color.Preset.Gray, Color.Preset backColor = Color.Preset.Black)
        {
            foreach (var logger in Loggers)
            {
                logger.Log(Severity.Information, message, foreColor, backColor);
            }
        }

        public void LogMessage(string message, Severity type, Color.Preset foreColor = Color.Preset.Gray, Color.Preset backColor = Color.Preset.Black)
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
                logger.Log(Severity.Verbose, FormatMessage(message, args));
            }
        }

        public void LogVerbose(string message, Color.Preset foreColor = Color.Preset.Gray, Color.Preset backColor = Color.Preset.Black)
        {
            foreach (var logger in Loggers)
            {
                logger.Log(Severity.Verbose, message, foreColor, backColor);
            }
        }

        public void LogWarning(string message, params object[] args)
        {
            foreach (var logger in Loggers)
            {
                logger.Log(Severity.Warning, FormatMessage(message, args));
            }
        }

        public void LogWarning(string message, Color.Preset foreColor = Color.Preset.DarkYellow, Color.Preset backColor = Color.Preset.Black)
        {
            foreach (var logger in Loggers)
            {
                logger.Log(Severity.Warning, message, foreColor, backColor);
            }
        }

        public void Log(Severity type, string message, Color.Preset? foreColor = null, Color.Preset? backColor = null)
        {
            foreach (var logger in Loggers)
            {
                logger.Log(type, message, foreColor, backColor);
            }
        }

        public string Format(Input input) =>
            CustomFormatter?.Invoke(input) ?? $"{input.DateTime.ToString(DateTimeFormat)}: {input.Severity.ToString()}: {input.Message}";
    }
}
