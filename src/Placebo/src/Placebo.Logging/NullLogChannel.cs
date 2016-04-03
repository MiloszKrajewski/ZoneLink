﻿using System;

namespace Placebo.Logging
{
	#region class NullLogChannel

	internal class NullLogChannel: ILogChannel
	{
		#region static fields

		/// <summary>The singleton.</summary>
		public static readonly NullLogChannel Instance = new NullLogChannel();

		#endregion

		#region constructor

		/// <summary>
		/// Prevents a default instance of the <see cref="NullLogChannel"/> class from being created.
		/// </summary>
		private NullLogChannel() { }

		#endregion

		#region ILogChannel Members

		/// <summary>Determines whether logging for specified severity is enabled.</summary>
		/// <param name="severity">The severity.</param>
		/// <returns><c>true</c> if it is enabled; <c>false</c> otherwise</returns>
		public bool IsEnabled(Severity severity)
		{
			return false;
		}

		/// <summary>Logs the message.</summary>
		/// <param name="severity">The severity.</param>
		/// <param name="exception">The exception (or <c>null</c>).</param>
		/// <param name="messageFactory">A function which will generate message if it is going to be logged.</param>
		public void LogMessage(Severity severity, Func<string> messageFactory)
		{
			// do nothing
		}

		#endregion
	}

	#endregion
}