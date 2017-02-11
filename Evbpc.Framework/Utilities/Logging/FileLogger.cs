using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evbpc.Framework.Drawing;
using System.IO;

namespace Evbpc.Framework.Utilities.Logging
{
    public class FileLogger : ILogger
    {
        public string DateTimeFormat { get; }

        public LoggingType LoggingType { get; }

        public string File { get; }

        public FileLogger(string file, LoggingType loggingType)
            : this(file, loggingType, "O")
        {

        }

        public FileLogger(string file, LoggingType loggingType, string dateTimeFormat)
        {
            LoggingType = loggingType;
            File = file;
            DateTimeFormat = dateTimeFormat;
        }

        public string FormatMessage(string message, params object[] args) =>
            string.Format(message, args);

        public void LogError(string message, params object[] args) =>
            LogMessage(FormatMessage(message, args), LoggingType.Error);

        public void LogError(string message, Color.Preset foreColor = Color.Preset.White, Color.Preset backColor = Color.Preset.DarkRed) =>
            LogMessage(message, LoggingType.Error);

        public void LogImportant(string message, params object[] args) =>
            LogMessage(FormatMessage(message, args), LoggingType.Important);

        public void LogImportant(string message, Color.Preset foreColor = Color.Preset.White, Color.Preset backColor = Color.Preset.Black) =>
            LogMessage(message, LoggingType.Important);

        public void LogInformation(string message, params object[] args) =>
            LogMessage(FormatMessage(message, args), LoggingType.Information);

        public void LogInformation(string message, Color.Preset foreColor = Color.Preset.Gray, Color.Preset backColor = Color.Preset.Black) =>
            LogMessage(message, LoggingType.Information);

        public void LogMessage(string message, LoggingType type, Color.Preset foreColor = Color.Preset.Gray, Color.Preset backColor = Color.Preset.Black)
        {
            if (type <= LoggingType)
            {
                using (var sw = new StreamWriter(File, true))
                {
                    sw.WriteLine(FormatMessage("{0}: {1}: {2}", DateTime.UtcNow.ToString(DateTimeFormat), type.ToString(), message));
                }
            }
        }

        public void LogVerbose(string message, params object[] args) =>
            LogMessage(FormatMessage(message, args), LoggingType.Verbose);

        public void LogVerbose(string message, Color.Preset foreColor = Color.Preset.Gray, Color.Preset backColor = Color.Preset.Black) =>
            LogMessage(message, LoggingType.Verbose);

        public void LogWarning(string message, params object[] args) =>
            LogMessage(FormatMessage(message, args), LoggingType.Warning);

        public void LogWarning(string message, Color.Preset foreColor = Color.Preset.DarkYellow, Color.Preset backColor = Color.Preset.Black) =>
            LogMessage(message, LoggingType.Warning);
    }
}
