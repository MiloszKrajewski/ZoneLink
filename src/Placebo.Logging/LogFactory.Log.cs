using System;

namespace Placebo.Logging
{
    public static partial class LogFactory
    {
        /// <summary>Logs a Debug message.</summary>
        /// <param name="logChannel">The log channel.</param>
        /// <param name="messageFactory">The message factory.</param>
        public static void Debug(this ILogChannel logChannel, Func<string> messageFactory)
        {
            if (logChannel == null || !logChannel.IsEnabled(Severity.Debug)) return;
            logChannel.LogMessage(Severity.Debug, messageFactory.DeferToString());
        }

        /// <summary>Logs a exception as Debug message.</summary>
        /// <param name="logChannel">The log channel.</param>
        /// <param name="exception">The exception.</param>
        public static void Debug(this ILogChannel logChannel, Exception exception)
        {
            if (logChannel == null || exception == null || !logChannel.IsEnabled(Severity.Debug)) return;
            logChannel.LogMessage(Severity.Debug, exception);
        }

        /// <summary>Logs a Debug message.</summary>
        /// <param name="logChannel">The log channel.</param>
        /// <param name="messageFactory">The message.</param>
        public static void Debug(this ILogChannel logChannel, string message)
        {
            if (logChannel == null || !logChannel.IsEnabled(Severity.Debug)) return;
            logChannel.LogMessage(Severity.Debug, message.DeferToString());
        }

        /// <summary>Debugs the specified message.</summary>
        /// <param name="logChannel">The log channel.</param>
        /// <param name="messageFormat">The message format.</param>
        /// <param name="arguments">The arguments.</param>
        public static void Debug(this ILogChannel logChannel, string messageFormat, params object[] arguments)
        {
            if (logChannel == null || !logChannel.IsEnabled(Severity.Debug)) return;
            logChannel.LogMessage(Severity.Debug, messageFormat.DeferToString(arguments));
        }

        /// <summary>Logs a Trace message.</summary>
        /// <param name="logChannel">The log channel.</param>
        /// <param name="messageFactory">The message factory.</param>
        public static void Trace(this ILogChannel logChannel, Func<string> messageFactory)
        {
            if (logChannel == null || !logChannel.IsEnabled(Severity.Trace)) return;
            logChannel.LogMessage(Severity.Trace, messageFactory.DeferToString());
        }

        /// <summary>Logs a exception as Trace message.</summary>
        /// <param name="logChannel">The log channel.</param>
        /// <param name="exception">The exception.</param>
        public static void Trace(this ILogChannel logChannel, Exception exception)
        {
            if (logChannel == null || exception == null || !logChannel.IsEnabled(Severity.Trace)) return;
            logChannel.LogMessage(Severity.Trace, exception);
        }

        /// <summary>Logs a Trace message.</summary>
        /// <param name="logChannel">The log channel.</param>
        /// <param name="messageFactory">The message.</param>
        public static void Trace(this ILogChannel logChannel, string message)
        {
            if (logChannel == null || !logChannel.IsEnabled(Severity.Trace)) return;
            logChannel.LogMessage(Severity.Trace, message.DeferToString());
        }

        /// <summary>Debugs the specified message.</summary>
        /// <param name="logChannel">The log channel.</param>
        /// <param name="messageFormat">The message format.</param>
        /// <param name="arguments">The arguments.</param>
        public static void Trace(this ILogChannel logChannel, string messageFormat, params object[] arguments)
        {
            if (logChannel == null || !logChannel.IsEnabled(Severity.Trace)) return;
            logChannel.LogMessage(Severity.Trace, messageFormat.DeferToString(arguments));
        }

        /// <summary>Logs a Info message.</summary>
        /// <param name="logChannel">The log channel.</param>
        /// <param name="messageFactory">The message factory.</param>
        public static void Info(this ILogChannel logChannel, Func<string> messageFactory)
        {
            if (logChannel == null || !logChannel.IsEnabled(Severity.Info)) return;
            logChannel.LogMessage(Severity.Info, messageFactory.DeferToString());
        }

        /// <summary>Logs a exception as Info message.</summary>
        /// <param name="logChannel">The log channel.</param>
        /// <param name="exception">The exception.</param>
        public static void Info(this ILogChannel logChannel, Exception exception)
        {
            if (logChannel == null || exception == null || !logChannel.IsEnabled(Severity.Info)) return;
            logChannel.LogMessage(Severity.Info, exception);
        }

        /// <summary>Logs a Info message.</summary>
        /// <param name="logChannel">The log channel.</param>
        /// <param name="messageFactory">The message.</param>
        public static void Info(this ILogChannel logChannel, string message)
        {
            if (logChannel == null || !logChannel.IsEnabled(Severity.Info)) return;
            logChannel.LogMessage(Severity.Info, message.DeferToString());
        }

        /// <summary>Debugs the specified message.</summary>
        /// <param name="logChannel">The log channel.</param>
        /// <param name="messageFormat">The message format.</param>
        /// <param name="arguments">The arguments.</param>
        public static void Info(this ILogChannel logChannel, string messageFormat, params object[] arguments)
        {
            if (logChannel == null || !logChannel.IsEnabled(Severity.Info)) return;
            logChannel.LogMessage(Severity.Info, messageFormat.DeferToString(arguments));
        }

        /// <summary>Logs a Warn message.</summary>
        /// <param name="logChannel">The log channel.</param>
        /// <param name="messageFactory">The message factory.</param>
        public static void Warn(this ILogChannel logChannel, Func<string> messageFactory)
        {
            if (logChannel == null || !logChannel.IsEnabled(Severity.Warn)) return;
            logChannel.LogMessage(Severity.Warn, messageFactory.DeferToString());
        }

        /// <summary>Logs a exception as Warn message.</summary>
        /// <param name="logChannel">The log channel.</param>
        /// <param name="exception">The exception.</param>
        public static void Warn(this ILogChannel logChannel, Exception exception)
        {
            if (logChannel == null || exception == null || !logChannel.IsEnabled(Severity.Warn)) return;
            logChannel.LogMessage(Severity.Warn, exception);
        }

        /// <summary>Logs a Warn message.</summary>
        /// <param name="logChannel">The log channel.</param>
        /// <param name="messageFactory">The message.</param>
        public static void Warn(this ILogChannel logChannel, string message)
        {
            if (logChannel == null || !logChannel.IsEnabled(Severity.Warn)) return;
            logChannel.LogMessage(Severity.Warn, message.DeferToString());
        }

        /// <summary>Debugs the specified message.</summary>
        /// <param name="logChannel">The log channel.</param>
        /// <param name="messageFormat">The message format.</param>
        /// <param name="arguments">The arguments.</param>
        public static void Warn(this ILogChannel logChannel, string messageFormat, params object[] arguments)
        {
            if (logChannel == null || !logChannel.IsEnabled(Severity.Warn)) return;
            logChannel.LogMessage(Severity.Warn, messageFormat.DeferToString(arguments));
        }

        /// <summary>Logs a Error message.</summary>
        /// <param name="logChannel">The log channel.</param>
        /// <param name="messageFactory">The message factory.</param>
        public static void Error(this ILogChannel logChannel, Func<string> messageFactory)
        {
            if (logChannel == null || !logChannel.IsEnabled(Severity.Error)) return;
            logChannel.LogMessage(Severity.Error, messageFactory.DeferToString());
        }

        /// <summary>Logs a exception as Error message.</summary>
        /// <param name="logChannel">The log channel.</param>
        /// <param name="exception">The exception.</param>
        public static void Error(this ILogChannel logChannel, Exception exception)
        {
            if (logChannel == null || exception == null || !logChannel.IsEnabled(Severity.Error)) return;
            logChannel.LogMessage(Severity.Error, exception);
        }

        /// <summary>Logs a Error message.</summary>
        /// <param name="logChannel">The log channel.</param>
        /// <param name="messageFactory">The message.</param>
        public static void Error(this ILogChannel logChannel, string message)
        {
            if (logChannel == null || !logChannel.IsEnabled(Severity.Error)) return;
            logChannel.LogMessage(Severity.Error, message.DeferToString());
        }

        /// <summary>Debugs the specified message.</summary>
        /// <param name="logChannel">The log channel.</param>
        /// <param name="messageFormat">The message format.</param>
        /// <param name="arguments">The arguments.</param>
        public static void Error(this ILogChannel logChannel, string messageFormat, params object[] arguments)
        {
            if (logChannel == null || !logChannel.IsEnabled(Severity.Error)) return;
            logChannel.LogMessage(Severity.Error, messageFormat.DeferToString(arguments));
        }

        /// <summary>Logs a Fatal message.</summary>
        /// <param name="logChannel">The log channel.</param>
        /// <param name="messageFactory">The message factory.</param>
        public static void Fatal(this ILogChannel logChannel, Func<string> messageFactory)
        {
            if (logChannel == null || !logChannel.IsEnabled(Severity.Fatal)) return;
            logChannel.LogMessage(Severity.Fatal, messageFactory.DeferToString());
        }

        /// <summary>Logs a exception as Fatal message.</summary>
        /// <param name="logChannel">The log channel.</param>
        /// <param name="exception">The exception.</param>
        public static void Fatal(this ILogChannel logChannel, Exception exception)
        {
            if (logChannel == null || exception == null || !logChannel.IsEnabled(Severity.Fatal)) return;
            logChannel.LogMessage(Severity.Fatal, exception);
        }

        /// <summary>Logs a Fatal message.</summary>
        /// <param name="logChannel">The log channel.</param>
        /// <param name="messageFactory">The message.</param>
        public static void Fatal(this ILogChannel logChannel, string message)
        {
            if (logChannel == null || !logChannel.IsEnabled(Severity.Fatal)) return;
            logChannel.LogMessage(Severity.Fatal, message.DeferToString());
        }

        /// <summary>Debugs the specified message.</summary>
        /// <param name="logChannel">The log channel.</param>
        /// <param name="messageFormat">The message format.</param>
        /// <param name="arguments">The arguments.</param>
        public static void Fatal(this ILogChannel logChannel, string messageFormat, params object[] arguments)
        {
            if (logChannel == null || !logChannel.IsEnabled(Severity.Fatal)) return;
            logChannel.LogMessage(Severity.Fatal, messageFormat.DeferToString(arguments));
        }
    }
}