using System;
using System.Collections.Generic;
using System.Linq;

namespace Placebo.Injection
{
	/// <summary>
	/// Extension method augmenting service resolver.
	/// </summary>
	public static class ContainerExtensions
	{
		/// <summary>Resolves the th object for given type.</summary>
		/// <typeparam name="T">Type of object.</typeparam>
		/// <param name="resolver">The resolver.</param>
		/// <param name="require">if set to <c>true</c> object is required so it will throw exception if objects is not registered.</param>
		/// <returns>Object of given type.</returns>
		public static T Resolve<T>(
			this IContainer resolver,
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
			this IContainer resolver,
			string name,
			bool require = false)
		{
			return (T)resolver.Resolve(typeof(T), name, require);
		}

		/// <summary>Resolves all object for given type.</summary>
		/// <typeparam name="T">Type of object.</typeparam>
		/// <param name="resolver">The resolver.</param>
		/// <returns>Collection of objects.</returns>
		public static IEnumerable<T> ResolveAll<T>(this IContainer resolver)
		{
			return resolver.ResolveAll(typeof(T)).OfType<T>();
		}

		/// <summary>Registers the factory method.</summary>
		/// <typeparam name="T">Type of object.</typeparam>
		/// <param name="resolver">The resolver.</param>
		/// <param name="name">The name.</param>
		/// <param name="factory">The factory.</param>
		/// <returns>This resolver.</returns>
		public static IContainer RegisterFactory<T>(
			this IContainer resolver,
			string name,
			Func<IContainer, T> factory)
		{
			return resolver.RegisterFactory(typeof(T), name, r => factory(r));
		}

		/// <summary>Registers the factory method.</summary>
		/// <typeparam name="T">Type of object.</typeparam>
		/// <param name="resolver">The resolver.</param>
		/// <param name="factory">The factory.</param>
		/// <returns>This resolver.</returns>
		public static IContainer RegisterFactory<T>(
			this IContainer resolver,
			Func<IContainer, T> factory)
		{
			return resolver.RegisterFactory(typeof(T), null, r => factory(r));
		}

		/// <summary>Registers the instance.</summary>
		/// <typeparam name="T">Type of object.</typeparam>
		/// <param name="resolver">The resolver.</param>
		/// <param name="name">The name.</param>
		/// <param name="instance">The instance.</param>
		/// <returns>This resolver.</returns>
		public static IContainer RegisterInstance<T>(
			this IContainer resolver, string name, T instance)
		{
			return resolver.RegisterInstance(typeof(T), name, instance);
		}

		/// <summary>Registers the instance.</summary>
		/// <typeparam name="T">Type of object.</typeparam>
		/// <param name="resolver">The resolver.</param>
		/// <param name="instance">The instance.</param>
		/// <returns>This resolver.</returns>
		public static IContainer RegisterInstance<T>(
			this IContainer resolver, T instance)
		{
			return resolver.RegisterInstance(typeof(T), null, instance);
		}

		/// <summary>Registers the type.</summary>
		/// <typeparam name="T">Type of object.</typeparam>
		/// <typeparam name="TActual">The actual type.</typeparam>
		/// <param name="resolver">The resolver.</param>
		/// <param name="name">The name.</param>
		/// <returns>This resolver.</returns>
		public static IContainer RegisterType<T, TActual>(
			this IContainer resolver,
			string name)
			where TActual: T
		{
			return resolver.RegisterType(typeof(T), name, typeof(TActual));
		}

		/// <summary>Registers the type.</summary>
		/// <typeparam name="T">Type of object.</typeparam>
		/// <typeparam name="TActual">The actual type.</typeparam>
		/// <param name="resolver">The resolver.</param>
		/// <returns>This resolver.</returns>
		public static IContainer RegisterType<T, TActual>(
			this IContainer resolver)
			where TActual: T
		{
			return resolver.RegisterType(typeof(T), null, typeof(TActual));
		}
	}
}
