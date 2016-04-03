using System.Linq;
using System.Collections.Generic;

namespace Placebo.Injection
{
	public static class ServiceLocator
	{
		private static IServiceLocator _defaultServiceLocator = NullServiceLocator.Instance;

		/// <summary>Gets the default service locator.</summary>
		/// <value>The default service locator.</value>
		public static IServiceLocator Default { get { return _defaultServiceLocator; } }

		/// <summary>Configures the default service locator.</summary>
		/// <param name="serviceLocator">The default service locator.</param>
		public static void Configure(IServiceLocator serviceLocator)
		{
			_defaultServiceLocator = serviceLocator;
		}

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

		/// <summary>Resolves the th object for given type.</summary>
		/// <typeparam name="T">Type of object.</typeparam>
		/// <param name="require">if set to <c>true</c> object is required so it will throw exception if objects is not registered.</param>
		/// <returns>Object of given type.</returns>
		public static T Resolve<T>(bool require = false)
		{
			return _defaultServiceLocator.Resolve<T>(require);
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

		/// <summary>Resolves the object for given name and type.</summary>
		/// <typeparam name="T">Type of object.</typeparam>
		/// <param name="name">The name.</param>
		/// <param name="require">if set to <c>true</c> object is required so it will throw exception if objects is not registered.</param>
		/// <returns>Object of given type.</returns>
		public static T Resolve<T>(
			string name,
			bool require = false)
		{
			return _defaultServiceLocator.Resolve<T>(name, require);
		}

		/// <summary>Resolves all object for given type.</summary>
		/// <typeparam name="T">Type of object.</typeparam>
		/// <param name="resolver">The resolver.</param>
		/// <returns>Collection of objects.</returns>
		public static IEnumerable<T> ResolveAll<T>(this IServiceLocator resolver)
		{
			return resolver.ResolveAll(typeof(T)).OfType<T>();
		}

		/// <summary>Resolves all object for given type.</summary>
		/// <typeparam name="T">Type of object.</typeparam>
		/// <returns>Collection of objects.</returns>
		public static IEnumerable<T> ResolveAll<T>()
		{
			return _defaultServiceLocator.ResolveAll<T>();
		}
	}
}
