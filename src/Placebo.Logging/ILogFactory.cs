namespace Placebo.Logging
{
	/// <summary>
	/// Basic interface to logging factory.
	/// </summary>
	public interface ILogFactory
	{
		/// <summary>Gets the <see cref="ILogChannel" /> for the specified channel.</summary>
		/// <param name="channelName">Name of the channel.</param>
		/// <returns>Log channel.</returns>
		ILogChannel GetChannel(string channelName);
	}
}