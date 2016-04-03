using System;
using System.Collections;

namespace Placebo.Injection
{
	/// <summary>ServiceResolver interface.</summary>
	public interface IServiceLocator
	{
		/// <summary>Resolves the object implementing specified interface.</summary>
		/// <param name="serviceType">Type of the service.</param>
		/// <param name="name">The name.</param>
		/// <param name="require">if set to <c>true</c> service is required, so it will throw exception if service is not defined.</param>
		/// <returns>Object implementing given interface.</returns>
		object Resolve(Type serviceType, string name, bool require);

		/// <summary>Resolves all objects implementing specified interface.</summary>
		/// <param name="serviceType">Type of the service.</param>
		/// <returns>Collection of objects implementing interface.</returns>
		IEnumerable ResolveAll(Type serviceType);

		/// <summary>Registers the factory method.</summary>
		/// <param name="serviceType">Type of the service.</param>
		/// <param name="name">The name (optional).</param>
		/// <param name="factory">The factory method.</param>
		/// <returns>This resolver.</returns>
		IServiceLocator Register(Type serviceType, string name, Func<IServiceLocator, object> factory);

		/// <summary>Spawns child resolver.</summary>
		/// <returns>Child resolver.</returns>
		IServiceLocator Spawn();

	}
}