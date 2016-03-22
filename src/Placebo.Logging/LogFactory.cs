using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Placebo.Logging
{
	public static class LogFactory
	{
		private static ILogFactory _defaultLogFactory = NullLogFactory.Instance;

		public static readonly ILogFactory Null = NullLogFactory.Instance;
		public static ILogFactory Default { get { return _defaultLogFactory; } }

		public static void Configure(ILogFactory logFactory)
		{
			_defaultLogFactory = logFactory;
		}

		public static ILogChannel Channel(this ILogFactory logFactory, Type hostingType)
		{
			return logFactory.Channel(hostingType.GetFriendlyName());
		}

		public static ILogChannel Channel(this ILogFactory logFactory, object hostingObject)
		{
			return logFactory.Channel(hostingObject.GetFriendlyObjectName());
		}

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

		public static void Info() { }
		public static void Warn() { }
		public static void Error() { }
		public static void Fatal() { }

		private static Func<string> SafeFormat(string message)
		{
			return () => message ?? "<null>";
		}

		private static Func<string> SafeFormat(Func<string> factory)
		{
			return () => {
				if (factory == null) return "<null>";
				try
				{
					return factory() ?? "<null>";
				}
				catch (Exception e)
				{
					return string.Format("<exception {0}>", e.GetType().GetFriendlyName());
				}
			};
		}

		private static Func<string> SafeFormat(string message, object[] arguments)
		{
			return () => {
				if (message == null) return "<null>";
				try
				{
					return string.Format(message, arguments);
				}
				catch (Exception e)
				{
					return string.Format("<exception {0}>", e.GetType().GetFriendlyName());
				}
			};
		}
	}
}
