using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Placebo.Logging
{
	public class PlaceboLogFactory: ILogFactory
	{
		private object _lock = new object();
		private TextWriter _standardStream;
		private TextWriter _errorStream;

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
			return new PlaceboLogChannel(_lock, _standardStream, _errorStream);
		}
	}
}
