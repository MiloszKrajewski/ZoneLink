using System;

namespace Placebo.Logging
{
	/// <summary>Basic interface to logging.</summary>
	public interface ILogChannel
	{
		/// <summary>Logs the message.</summary>
		/// <param name="severity">The severity.</param>
		/// <param name="exception">The exception (or <c>null</c>).</param>
		/// <param name="messageFactory">A function which will generate message if it is going to be logged.</param>
		void LogMessage(Severity severity, Exception exception, Func<string> messageFactory);
	}
}