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
		private static IServiceLocator _defaultServiceLocator;

		public static IServiceLocator Default { get { return _defaultServiceLocator; } }

		public static void Configure(IServiceLocator serviveLocator)
		{
			_defaultServiceLocator = serviveLocator;
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

		public static IEnumerable<T> ResolveAll<T>()
		{
			return _defaultServiceLocator.ResolveAll<T>();
		}
	}

	public class NullServiceLocator: IServiceLocator
	{
		#region IServiceLocator Members

		public object Resolve(Type serviceType, string name, bool require)
		{
			if (require)
				throw new ArgumentException(string.Format(
					"Service '{0}' could not be resolved",
					GetFriendlyName(serviceType)));
			return serviceType.IsValueType ? Activator.CreateInstance(serviceType) : null;
		}

		public IEnumerable ResolveAll(Type serviceType)
		{
			return Array.CreateInstance(serviceType, 0);
		}

		#endregion

		#region utilities

		private static string GetFriendlyName(Type serviceType)
		{
			return serviceType.Name;
		}

		#endregion
	}

}
