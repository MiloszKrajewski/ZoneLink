using System;
using System.Collections;

namespace Placebo.Injection
{
	/// <summary>ServiceResolver interface.</summary>
	public interface IContainer
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
		IContainer RegisterFactory(Type serviceType, string name, Func<IContainer, object> factory);

		/// <summary>Registers the instance.</summary>
		/// <param name="serviceType">Type of the service.</param>
		/// <param name="name">The name.</param>
		/// <param name="instance">The instance.</param>
		/// <returns>This resolver.</returns>
		IContainer RegisterInstance(Type serviceType, string name, object instance);

		/// <summary>Registers the type.</summary>
		/// <param name="serviceType">Type of the service.</param>
		/// <param name="name">The name.</param>
		/// <param name="actualType">The actual type.</param>
		/// <returns>This resolver.</returns>
		IContainer RegisterType(Type serviceType, string name, Type actualType);

		/// <summary>Spawns child resolver.</summary>
		/// <returns>Child resolver.</returns>
		IContainer Spawn();
	}
}
