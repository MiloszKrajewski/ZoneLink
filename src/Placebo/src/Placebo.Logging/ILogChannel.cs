using System;

namespace Placebo.Logging
{
	/// <summary>Basic interface to logging.</summary>
	public interface ILogChannel
	{
		/// <summary>Determines whether logging for specified severity is enabled.</summary>
		/// <param name="severity">The severity.</param>
		/// <returns><c>true</c> if it is enabled; <c>false</c> otherwise</returns>
		bool IsEnabled(Severity severity);

		/// <summary>Logs the message.</summary>
		/// <param name="severity">The severity.</param>
		/// <param name="messageFactory">A function which will generate message if it is going to be logged.</param>
		void LogMessage(Severity severity, Func<string> messageFactory);
	}
}