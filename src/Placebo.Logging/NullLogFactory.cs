namespace Placebo.Logging
{
	#region class NullLogFactory

	internal class NullLogFactory: ILogFactory
	{
		#region static fields

		internal static readonly NullLogFactory Instance = new NullLogFactory();

		#endregion

		#region ILogFactory Members

		/// <summary>Gets the <see cref="ILogChannel" /> for the specified channel.</summary>
		/// <param name="channelName">Name of the channel.</param>
		/// <returns>Log channel.</returns>
		public ILogChannel Channel(string channelName)
		{
			return NullLogChannel.Instance;
		}

		#endregion
	}

	#endregion
}