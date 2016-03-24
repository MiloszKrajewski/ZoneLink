using System;

namespace Placebo.Logging
{
	/// <summary>Severity of log message.</summary>
	public enum Severity
	{
		/// <summary>None.</summary>
		None = 0,

		/// <summary>Debug.</summary>
		Debug = 1,
		/// <summary>Debug.</summary>
		Trace = 2,
		/// <summary>Information.</summary>
		Info = 3,
		/// <summary>Warning.</summary>
		Warn = 4,
		/// <summary>Error.</summary>
		Error = 5,
		/// <summary>Fatal.</summary>
		Fatal = 6,

		/// <summary>All.</summary>
		All = 7
	}
}