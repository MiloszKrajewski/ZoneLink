using System.Linq;
using System.Collections.Generic;
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

	public static class ServiceLocator
	{
		public static IServiceLocator Root = null;

		/// <summary>Resolves the th object for given type.</summary>
		/// <typeparam name="T">Type of object.</typeparam>
		/// <param name="resolver">The resolver.</param>
		/// <param name="require">if set to <c>true</c> object is required so it will throw exception if objects is not registered.</param>
		/// <returns>Object of given type.</returns>
		public static T Resolve<T>(
			this IServiceLocator resolver,
			bool require = false)
		{
			return (T)resolver.Resolve(typeof(T), null, require);
		}

		/// <summary>Resolves the object for given name and type.</summary>
		/// <typeparam name="T">Type of object.</typeparam>
		/// <param name="resolver">The resolver.</param>
		/// <param name="name">The name.</param>
		/// <param name="require">if set to <c>true</c> object is required so it will throw exception if objects is not registered.</param>
		/// <returns>Object of given type.</returns>
		public static T Resolve<T>(
			this IServiceLocator resolver,
			string name,
			bool require = false)
		{
			return (T)resolver.Resolve(typeof(T), name, require);
		}

		/// <summary>Resolves all object for given type.</summary>
		/// <typeparam name="T">Type of object.</typeparam>
		/// <param name="resolver">The resolver.</param>
		/// <returns>Collection of objects.</returns>
		public static IEnumerable<T> ResolveAll<T>(this IServiceLocator resolver)
		{
			return resolver.ResolveAll(typeof(T)).OfType<T>();
		}
	}
}
