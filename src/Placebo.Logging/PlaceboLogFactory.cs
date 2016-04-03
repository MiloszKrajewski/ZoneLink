using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Placebo.Logging
{
	public class PlaceboLogFactory: ILogFactory
	{
		private readonly object _lockObject = new object();
		private readonly TextWriter _standardStream;
		private readonly TextWriter _errorStream;

		public PlaceboLogFactory(TextWriter standardStream, TextWriter errorStream)
		{
			_standardStream = standardStream;
			_errorStream = errorStream;
		}

		public PlaceboLogFactory(TextWriter stream)
			: this(stream, stream)
		{
		}

		public ILogChannel Channel(string channelName)
		{
			return new PlaceboLogChannel(_lockObject, _standardStream, _errorStream);
		}
	}
}
