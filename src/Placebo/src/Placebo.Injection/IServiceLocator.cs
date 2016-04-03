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
	}
}