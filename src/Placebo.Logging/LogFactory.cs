using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Placebo.Logging
{
	public static class LogFactory
	{
		#region class NullLogFactory

		internal class NullLogFactory: ILogFactory
		{
			public static readonly NullLogFactory Instance = new NullLogFactory();

			#region ILogFactory Members

			/// <summary>Gets the <see cref="ILogChannel" /> for the specified channel.</summary>
			/// <param name="channelName">Name of the channel.</param>
			/// <returns>Log channel.</returns>
			public ILogChannel Channel(string channelName)
			{
				return NullLogChannel.Instance;
			}

			#endregion
		}

		#endregion

		private static ILogFactory _defaultLogFactory = NullLogFactory.Instance;

		public static readonly ILogFactory Null = NullLogFactory.Instance;
		public static ILogFactory Default { get { return _defaultLogFactory; } }

		public static ILogChannel Channel(this ILogFactory logFactory, Type hostingType)
		{
			return logFactory.Channel(GetFriendlyName(hostingType));
		}

		public static ILogChannel Channel(this ILogFactory logFactory, object hostingObject)
		{
			return logFactory.Channel(GetFriendlyName(hostingObject));
		}

		public static void Debug(this ILogChannel logChannel, Func<string> messageFactory)
		{
			if (logChannel == null || !logChannel.IsEnabled(Severity.Debug)) return;
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
			if (logChannel == null || !logChannel.IsEnabled(Severity.Trace)) return;
			logChannel.LogMessage(Severity.Trace, null, messageFactory);
		}

		public static void Trace(this ILogChannel logChannel, string message)
		{
			logChannel.Trace(() => SafeFormat(message));
		}

		public static void Trace(this ILogChannel logChannel, string message, params object[] arguments)
		{
			logChannel.Trace(() => SafeFormat(message, arguments));
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
