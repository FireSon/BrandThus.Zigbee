using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace BrandThus.Zigbee
{

    public delegate void LogEvent(LogType logType, string File, string Member, int line, string message);

    public static class Logger
    {
        internal static LogEvent? LogEvent;
        internal static LogType LogLevel { get; set; }

        public static void Trace(string message, [CallerMemberName] string? member = null, [CallerFilePath] string? file = null, [CallerLineNumberAttribute] int? line = null)
            => Log(LogType.Verbose, file, member, line, message);
        public static void Info(string message, [CallerMemberName] string? member = null, [CallerFilePath] string? file = null, [CallerLineNumberAttribute] int? line = null)
            => Log(LogType.Info, file, member, line, message);
        public static void Error(string message, [CallerMemberName] string? member = null, [CallerFilePath] string? file = null, [CallerLineNumberAttribute] int? line = null)
            => Log(LogType.Error, file, member, line, message);
        public static void Trace(this Exception ex, [CallerMemberName] string? member = null, [CallerFilePath] string? file = null, [CallerLineNumberAttribute] int? line = null)
            => Log(LogType.Error, file, member, line, ex.Message);

        private static void Log(LogType logType, string? file, string? member, int? line, string message)
        {
            if (LogEvent != null && logType >= LogLevel)
                LogEvent(logType, Path.GetFileName(file ?? ""), member ?? "", line ?? 0, message);
        }
    }

    public enum LogType
    {
        Verbose,
        Info,
        Error,
    }
}