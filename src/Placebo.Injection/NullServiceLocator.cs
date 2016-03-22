using System;
using System.Collections;

namespace Placebo.Injection
{
	/// <summary>
	/// Null service locator.
	/// </summary>
	public class NullServiceLocator: IServiceLocator
	{
		public static IServiceLocator Instance = new NullServiceLocator();

		/// <summary>Prevents a default instance of the <see cref="NullServiceLocator"/> class from being created.</summary>
		private NullServiceLocator() { }

		#region IServiceLocator Members

		/// <summary>Resolves the object implementing specified interface.</summary>
		/// <param name="serviceType">Type of the service.</param>
		/// <param name="name">The name.</param>
		/// <param name="require">if set to <c>true</c> service is required, so it will throw exception if service is not defined.</param>
		/// <returns>Object implementing given interface.</returns>
		/// <exception cref="System.ArgumentException"></exception>
		public object Resolve(Type serviceType, string name, bool require)
		{
			if (require)
				throw new ArgumentException(string.Format(
					"Service '{0}' could not be resolved",
					serviceType.GetFriendlyName()));
			return serviceType.IsValueType ? Activator.CreateInstance(serviceType) : null;
		}

		/// <summary>Resolves all objects implementing specified interface.</summary>
		/// <param name="serviceType">Type of the service.</param>
		/// <returns>Collection of objects implementing interface.</returns>
		public IEnumerable ResolveAll(Type serviceType)
		{
			return Array.CreateInstance(serviceType, 0);
		}

		#endregion
	}
}