using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Placebo.Logging
{
	public static class LogExtensions
	{
		public static ILogFactory NotNull(this ILogFactory logFactory)
		{
			return logFactory ?? NullLogFactory.Instance;
		}

		public static ILogChannel NotNull(this ILogChannel logChannel)
		{
			return logChannel ?? NullLogChannel.Instance;
		}

		public static ILogChannel ChannelFor(this ILogFactory logFactory, string channelName)
		{
			if (string.IsNullOrWhiteSpace(channelName)) channelName = "root";
			return logFactory.NotNull().GetChannel(channelName).NotNull();
		}

		public static ILogChannel ChannelFor(this ILogFactory logFactory, Type hostingType)
		{
			return logFactory.ChannelFor(GetFriendlyName(hostingType));
		}

		public static ILogChannel ChannelFor(this ILogFactory logFactory, object hostingObject)
		{
			return logFactory.ChannelFor(GetFriendlyName(hostingObject));
		}

		public static void Debug(this ILogChannel logChannel, Func<string> messageFactory)
		{
			if (logChannel == null) return;
			logChannel.LogMessage(Severity.Debug, null, messageFactory);
		}

		public static void Debug(this ILogChannel logChannel, string message)
		{
			logChannel.Debug(() => SafeFormat(message));
		}

		public static void Debug(this ILogChannel logChannel, string message, params object[] arguments)
		{
			logChannel.Debug(() => SafeFormat(message, arguments));
		}

		public static void Trace(this ILogChannel logChannel, Func<string> messageFactory)
		{
			if (logChannel == null) return;
			logChannel.LogMessage(Severity.Trace, null, messageFactory);
		}

		public static void Info() { }
		public static void Warn() { }
		public static void Error() { }
		public static void Fatal() { }

		private static string GetFriendlyName(Type type)
		{
			if (type == null) return null;
			return type.Name;
		}

		private static string GetFriendlyName(object subject)
		{
			if (subject == null) return null;
			return GetFriendlyName(subject.GetType());
		}

		private static string SafeFormat(string message)
		{
			return message ?? "<null>";
		}

		private static string SafeFormat(Func<string> factory)
		{
			if (factory == null) return "<null>";
			try
			{
				return factory() ?? "<null>";
			}
			catch (Exception e)
			{
				return string.Format("<exception {0}>", GetFriendlyName(e.GetType()));
			}
		}

		private static string SafeFormat(string message, object[] arguments)
		{
			if (message == null) return "<null>";
			try
			{
				return string.Format(message, arguments);
			}
			catch (Exception e)
			{
				return string.Format("<exception {0}>", GetFriendlyName(e.GetType()));
			}
		}
	}
}
