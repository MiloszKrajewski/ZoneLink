
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Placebo.Logging
{
    public static partial class LogFactory
    {
        public static void Debug(this ILogChannel logChannel, Func<string> messageFactory)
        {
            if (logChannel == null || !logChannel.IsEnabled(Severity.Debug)) return;
            logChannel.LogMessage(Severity.Debug, null, SafeFormat(messageFactory));
        }

        public static void Debug(this ILogChannel logChannel, string message)
        {
            logChannel.Debug(SafeFormat(message));
        }

        public static void Debug(this ILogChannel logChannel, string message, params object[] arguments)
        {
            logChannel.Debug(SafeFormat(message, arguments));
        }

        public static void Trace(this ILogChannel logChannel, Func<string> messageFactory)
        {
            if (logChannel == null || !logChannel.IsEnabled(Severity.Trace)) return;
            logChannel.LogMessage(Severity.Trace, null, SafeFormat(messageFactory));
        }

        public static void Trace(this ILogChannel logChannel, string message)
        {
            logChannel.Trace(SafeFormat(message));
        }

        public static void Trace(this ILogChannel logChannel, string message, params object[] arguments)
        {
            logChannel.Trace(SafeFormat(message, arguments));
        }

        public static void Info(this ILogChannel logChannel, Func<string> messageFactory)
        {
            if (logChannel == null || !logChannel.IsEnabled(Severity.Info)) return;
            logChannel.LogMessage(Severity.Info, null, SafeFormat(messageFactory));
        }

        public static void Info(this ILogChannel logChannel, string message)
        {
            logChannel.Info(SafeFormat(message));
        }

        public static void Info(this ILogChannel logChannel, string message, params object[] arguments)
        {
            logChannel.Info(SafeFormat(message, arguments));
        }

        public static void Warn(this ILogChannel logChannel, Func<string> messageFactory)
        {
            if (logChannel == null || !logChannel.IsEnabled(Severity.Warn)) return;
            logChannel.LogMessage(Severity.Warn, null, SafeFormat(messageFactory));
        }

        public static void Warn(this ILogChannel logChannel, string message)
        {
            logChannel.Warn(SafeFormat(message));
        }

        public static void Warn(this ILogChannel logChannel, string message, params object[] arguments)
        {
            logChannel.Warn(SafeFormat(message, arguments));
        }

        public static void Error(this ILogChannel logChannel, Func<string> messageFactory)
        {
            if (logChannel == null || !logChannel.IsEnabled(Severity.Error)) return;
            logChannel.LogMessage(Severity.Error, null, SafeFormat(messageFactory));
        }

        public static void Error(this ILogChannel logChannel, string message)
        {
            logChannel.Error(SafeFormat(message));
        }

        public static void Error(this ILogChannel logChannel, string message, params object[] arguments)
        {
            logChannel.Error(SafeFormat(message, arguments));
        }

        public static void Fatal(this ILogChannel logChannel, Func<string> messageFactory)
        {
            if (logChannel == null || !logChannel.IsEnabled(Severity.Fatal)) return;
            logChannel.LogMessage(Severity.Fatal, null, SafeFormat(messageFactory));
        }

        public static void Fatal(this ILogChannel logChannel, string message)
        {
            logChannel.Fatal(SafeFormat(message));
        }

        public static void Fatal(this ILogChannel logChannel, string message, params object[] arguments)
        {
            logChannel.Fatal(SafeFormat(message, arguments));
        }


        public static void Warn(this ILogChannel logChannel, Exception exception, Func<string> messageFactory)
        {
            if (logChannel == null || !logChannel.IsEnabled(Severity.Warn)) return;
            logChannel.LogMessage(Severity.Warn, exception, SafeFormat(messageFactory));
        }

        public static void Warn(this ILogChannel logChannel, Exception exception)
        {
            logChannel.Warn(exception);
        }

        public static void Warn(this ILogChannel logChannel, Exception exception, string message)
        {
            logChannel.Warn(SafeFormat(message));
        }

        public static void Warn(this ILogChannel logChannel, Exception exception, string message, params object[] arguments)
        {
            logChannel.Warn(SafeFormat(message, arguments));
        }

        public static void Error(this ILogChannel logChannel, Exception exception, Func<string> messageFactory)
        {
            if (logChannel == null || !logChannel.IsEnabled(Severity.Error)) return;
            logChannel.LogMessage(Severity.Error, exception, SafeFormat(messageFactory));
        }

        public static void Error(this ILogChannel logChannel, Exception exception)
        {
            logChannel.Error(exception);
        }

        public static void Error(this ILogChannel logChannel, Exception exception, string message)
        {
            logChannel.Error(SafeFormat(message));
        }

        public static void Error(this ILogChannel logChannel, Exception exception, string message, params object[] arguments)
        {
            logChannel.Error(SafeFormat(message, arguments));
        }

        public static void Fatal(this ILogChannel logChannel, Exception exception, Func<string> messageFactory)
        {
            if (logChannel == null || !logChannel.IsEnabled(Severity.Fatal)) return;
            logChannel.LogMessage(Severity.Fatal, exception, SafeFormat(messageFactory));
        }

        public static void Fatal(this ILogChannel logChannel, Exception exception)
        {
            logChannel.Fatal(exception);
        }

        public static void Fatal(this ILogChannel logChannel, Exception exception, string message)
        {
            logChannel.Fatal(SafeFormat(message));
        }

        public static void Fatal(this ILogChannel logChannel, Exception exception, string message, params object[] arguments)
        {
            logChannel.Fatal(SafeFormat(message, arguments));
        }


    }
}