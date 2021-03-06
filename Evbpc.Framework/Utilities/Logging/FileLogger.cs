﻿using System;
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

        public Severity Severity { get; }

        public string File { get; private set; }

        public string BaseFile { get; }

        private const string _fileNameDateFormat = "yyyy.MM.dd.HH.mm.ss.fffffff";

        /// <summary>
        /// The maximum size of the file in bytes. This is checked pre-write so a file may grow *slightly* beyond this size depending on the next message being written.
        /// </summary>
        public int MaxFileSize { get; } = -1;

        public Func<Input, string> CustomFormatter { get; }

        public FileLogger(string file, Severity loggingType, int maxFileSize = -1, Func<Input, string> customFormatter = null)
            : this(file, loggingType, "O", maxFileSize, customFormatter)
        {

        }

        public FileLogger(string file, Severity loggingType, string dateTimeFormat, int maxFileSize, Func<Input, string> customFormatter)
        {
            Severity = loggingType;
            BaseFile = file;
            File = BaseFile + "." + DateTime.UtcNow.ToString(_fileNameDateFormat);
            DateTimeFormat = dateTimeFormat;
            MaxFileSize = maxFileSize;
            CustomFormatter = customFormatter;
        }

        public string FormatMessage(string message, params object[] args) =>
            string.Format(message, args);

        public void LogError(string message, params object[] args) =>
            LogMessage(FormatMessage(message, args), Severity.Error);

        public void LogError(string message, Color.Preset foreColor = Color.Preset.White, Color.Preset backColor = Color.Preset.DarkRed) =>
            LogMessage(message, Severity.Error);

        public void LogImportant(string message, params object[] args) =>
            LogMessage(FormatMessage(message, args), Severity.Important);

        public void LogImportant(string message, Color.Preset foreColor = Color.Preset.White, Color.Preset backColor = Color.Preset.Black) =>
            LogMessage(message, Severity.Important);

        public void LogInformation(string message, params object[] args) =>
            LogMessage(FormatMessage(message, args), Severity.Information);

        public void LogInformation(string message, Color.Preset foreColor = Color.Preset.Gray, Color.Preset backColor = Color.Preset.Black) =>
            LogMessage(message, Severity.Information);

        public void LogMessage(string message, Severity type, Color.Preset foreColor = Color.Preset.Gray, Color.Preset backColor = Color.Preset.Black) =>
            Log(type, message, foreColor, backColor);

        public void LogVerbose(string message, params object[] args) =>
            LogMessage(FormatMessage(message, args), Severity.Verbose);

        public void LogVerbose(string message, Color.Preset foreColor = Color.Preset.Gray, Color.Preset backColor = Color.Preset.Black) =>
            LogMessage(message, Severity.Verbose);

        public void LogWarning(string message, params object[] args) =>
            LogMessage(FormatMessage(message, args), Severity.Warning);

        public void LogWarning(string message, Color.Preset foreColor = Color.Preset.DarkYellow, Color.Preset backColor = Color.Preset.Black) =>
            LogMessage(message, Severity.Warning);

        public void Log(Severity severity, string message, Color.Preset? foreColor = null, Color.Preset? backColor = null)
        {
            if (severity <= Severity)
            {
                var file = File + ".txt";

                if (System.IO.File.Exists(file))
                {
                    var fileSize = new FileInfo(file).Length;

                    while (fileSize > MaxFileSize)
                    {
                        File = BaseFile + "." + DateTime.UtcNow.ToString(_fileNameDateFormat);
                        file = File + ".txt";
                        if (System.IO.File.Exists(file))
                        {
                            fileSize = new FileInfo(file).Length;
                        }
                        else
                        {
                            fileSize = 0;
                        }
                    }
                }

                file = File + ".txt";

                using (var sw = new StreamWriter(file, true))
                {
                    sw.WriteLine(Format(new Input { DateTime = DateTime.UtcNow, Message = message, Severity = severity, DateTimeFormat = DateTimeFormat }));
                }
            }
        }

        public string Format(Input input) =>
            CustomFormatter?.Invoke(input) ?? $"{input.DateTime.ToString(DateTimeFormat)}: {input.Severity.ToString()}: {input.Message}";
    }
}
