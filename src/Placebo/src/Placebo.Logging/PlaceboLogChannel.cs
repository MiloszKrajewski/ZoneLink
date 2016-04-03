using System;
using System.IO;

namespace Placebo.Logging
{
	public class PlaceboLogChannel: ILogChannel
	{
		private readonly object _lockObject;
		private readonly TextWriter _standardStream;
		private readonly TextWriter _errorStream;

		public PlaceboLogChannel(
			object lockObject,
			TextWriter standardStream,
			TextWriter errorStream)
		{
			_lockObject = lockObject;
			_standardStream = standardStream;
			_errorStream = errorStream;
		}

		private TextWriter SelectStream(Severity severity)
		{
			return severity >= Severity.Warn ? _errorStream : _standardStream;
		}

		#region ILogChannel Members

		public bool IsEnabled(Severity severity)
		{
			return severity > Severity.None;
		}

		public void LogMessage(Severity severity, Func<string> messageFactory)
		{
			if (!IsEnabled(severity))
				return;

			var stream = SelectStream(severity);
			var message = string.Format("[{0}] {1}", severity, messageFactory());

			lock (_lockObject) stream.WriteLine(message);
		}

		#endregion
	}
}
