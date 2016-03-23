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
			return logFactory.Channel(hostingObject.GetObjectFriendlyName());
		}

		public static void LogException(this ILogChannel logChannel, Severity serverity, Exception exception)
		{
			if (exception == null) return;
			if (logChannel == null || !logChannel.IsEnabled(serverity)) return;
			logChannel.LogMessage(serverity, SafeFormat(() => Explain(exception));
		}

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
