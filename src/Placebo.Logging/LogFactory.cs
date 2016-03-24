using System;

namespace Placebo.Logging
{
	public static partial class LogFactory
	{
		#region static fields

		private static ILogFactory _defaultLogFactory = NullLogFactory.Instance;

		#endregion

		#region singletons

		/// <summary>The null log factory.</summary>
		public static readonly ILogFactory Null = NullLogFactory.Instance;

		/// <summary>Gets the default log factory.</summary>
		/// <value>The default log factory.</value>
		public static ILogFactory Default { get { return _defaultLogFactory; } }

		#endregion

		/// <summary>Configures the default log factory.</summary>
		/// <param name="logFactory">The default log factory.</param>
		public static void Configure(ILogFactory logFactory)
		{
			_defaultLogFactory = logFactory;
		}

		/// <summary>Gets the log channel with given channel name.</summary>
		/// <param name="channelName">Name of the channel.</param>
		/// <returns>Log channel.</returns>
		public static ILogChannel Channel(string channelName)
		{
			return _defaultLogFactory.Channel(channelName);
		}

		/// <summary>Get the log channel for given type.</summary>
		/// <param name="logFactory">The log factory.</param>
		/// <param name="hostingType">The type.</param>
		/// <returns>Log channel.</returns>
		public static ILogChannel Channel(this ILogFactory logFactory, Type hostingType)
		{
			return logFactory.Channel(hostingType.GetFriendlyName());
		}

		/// <summary>Get the log channel for given type.</summary>
		/// <param name="hostingType">The type.</param>
		/// <returns>Log channel.</returns>
		public static ILogChannel Channel(Type hostingType)
		{
			return _defaultLogFactory.Channel(hostingType);
		}

		/// <summary>Get the log channel for given type.</summary>
		/// <typeparam name="T">The type.</typeparam>
		/// <param name="logFactory">The log factory.</param>
		/// <returns>Log channel.</returns>
		public static ILogChannel Channel<T>(this ILogFactory logFactory)
		{
			return logFactory.Channel(typeof(T));
		}

		/// <summary>Get the log channel for given type.</summary>
		/// <typeparam name="T">The type.</typeparam>
		/// <returns>Log channel.</returns>
		public static ILogChannel Channel<T>()
		{
			return _defaultLogFactory.Channel<T>();
		}

		/// <summary>Get the log channel for given object.</summary>
		/// <param name="logFactory">The log factory.</param>
		/// <param name="hostingObject">The hosting object.</param>
		/// <returns>Log channel.</returns>
		public static ILogChannel Channel(this ILogFactory logFactory, object hostingObject)
		{
			return logFactory.Channel(hostingObject.GetObjectFriendlyName());
		}

		/// <summary>Get the log channel for given object.</summary>
		/// <param name="hostingObject">The hosting object.</param>
		/// <returns>Log channel.</returns>
		public static ILogChannel Channel(object hostingObject)
		{
			return _defaultLogFactory.Channel(hostingObject);
		}

		/// <summary>Logs the exception as a message.</summary>
		/// <param name="logChannel">The log channel.</param>
		/// <param name="severity">The severity.</param>
		/// <param name="exception">The exception.</param>
		public static void LogMessage(this ILogChannel logChannel, Severity severity, Exception exception)
		{
			logChannel.LogMessage(severity, exception.DeferToString());
		}
	}
}
