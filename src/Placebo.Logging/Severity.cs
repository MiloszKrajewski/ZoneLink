using System;

namespace Placebo.Logging
{
	/// <summary>Severity of log message.</summary>
	[Flags]
	public enum Severity
	{
		/// <summary>None.</summary>
		None = 0,

		/// <summary>Debug.</summary>
		Debug = 0x01,
		/// <summary>Debug.</summary>
		Trace = 0x02,
		/// <summary>Information.</summary>
		Info = 0x04,
		/// <summary>Warning.</summary>
		Warn = 0x08,
		/// <summary>Error.</summary>
		Error = 0x10,
		/// <summary>Fatal.</summary>
		Fatal = 0x20,

		/// <summary>All.</summary>
		All = Debug | Trace | Info | Warn | Error | Fatal
	}
}