using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Placebo.Injection
{
	/// <summary>
	/// Default implementation of IContainer.
	/// It is very simplistic yet might be enough for simple applications and does 
	/// not require external dependencies.
	/// </summary>
	public class PlaceboContainer: IContainer
	{
		#region const

		/// <summary>The default (root) container.</summary>
		public static readonly PlaceboContainer Root = new PlaceboContainer();

		#endregion

		#region fields

		/// <summary>The dictionary of factories.</summary>
		private readonly Dictionary<Tuple<Type, string>, Func<IContainer, object>> _factories =
			new Dictionary<Tuple<Type, string>, Func<IContainer, object>>();

		/// <summary>The parent service resolver.</summary>
		private readonly PlaceboContainer _parent;

		#endregion

		#region constructor

		/// <summary>Initializes a new instance of the <see cref="PlaceboContainer"/> class.</summary>
		public PlaceboContainer()
		{
			RegisterInstance(typeof(IContainer), null, this);
			RegisterInstance(typeof(PlaceboContainer), null, this);
		}

		/// <summary>Initializes a new instance of the <see cref="PlaceboContainer"/> class.</summary>
		/// <param name="parent">The parent resolver.</param>
		private PlaceboContainer(PlaceboContainer parent)
			: this()
		{
			_parent = parent;
		}

		#endregion

		#region IServiceResolver Members

		/// <summary>Resolves the object implementing specified interface.</summary>
		/// <param name="serviceType">Type of the service.</param>
		/// <param name="name">The name.</param>
		/// <param name="require">if set to <c>true</c> service is required, so it will throw exception if service is not defined.</param>
		/// <returns>Object implementing given interface.</returns>
		/// <exception cref="System.Collections.Generic.KeyNotFoundException"></exception>
		public object Resolve(Type serviceType, string name, bool require)
		{
			var key = Tuple.Create(serviceType, name);
			foreach (var factories in EnumerateChain().Select(r => r._factories))
			{
				lock (factories)
				{
					Func<IContainer, object> factory;
					if (factories.TryGetValue(key, out factory))
						return factory(this);
				}
			}
			if (require)
				throw new KeyNotFoundException(
					string.Format("Factory for '{0}:{1}' could not be found",
						serviceType.Name,
						name ?? "<null>"));
			return DefaultValue(serviceType);
		}

		/// <summary>Resolves all objects implementing specified interface.</summary>
		/// <param name="serviceType">Type of the service.</param>
		/// <returns>Collection of objects implementing interface.</returns>
		public IEnumerable ResolveAll(Type serviceType)
		{
			var visited = new HashSet<string>();
			return EnumerateChain()
				.SelectMany(r => { lock (r._factories) return r._factories.ToArray(); })
				.Select(kv => new { Type = kv.Key.Item1, Name = kv.Key.Item2, Func = kv.Value })
				.Where(e => e.Type == serviceType && !visited.Contains(e.Name))
				.ApplyToEach(e => visited.Add(e.Name))
				.Select(e => SafeFactory(e.Func, false))
				.Where(o => o != null)
				.ToArray();
		}

		/// <summary>Registers the factory method.</summary>
		/// <param name="serviceType">Type of the service.</param>
		/// <param name="name">The name (optional).</param>
		/// <param name="factory">The factory method.</param>
		/// <returns>This resolver.</returns>
		public IContainer RegisterFactory(Type serviceType, string name, Func<IContainer, object> factory)
		{
			var key = Tuple.Create(serviceType, name);
			lock (_factories)
			{
				_factories[key] = factory;
			}
			return this;
		}

		/// <summary>Registers the instance.</summary>
		/// <param name="serviceType">Type of the service.</param>
		/// <param name="name">The name.</param>
		/// <param name="instance">The instance.</param>
		/// <returns>This resolver.</returns>
		public IContainer RegisterInstance(Type serviceType, string name, object instance)
		{
			var key = Tuple.Create(serviceType, name);
			lock (_factories)
			{
				_factories[key] = _ => instance;
			}
			return this;
		}

		/// <summary>Registers the type.</summary>
		/// <param name="serviceType">Type of the service.</param>
		/// <param name="name">The name.</param>
		/// <param name="actualType">The actual type.</param>
		/// <returns>This resolver.</returns>
		public IContainer RegisterType(Type serviceType, string name, Type actualType)
		{
			var key = Tuple.Create(serviceType, name);
			lock (_factories)
			{
				_factories[key] = _ => Activator.CreateInstance(actualType);
			}
			return this;
		}

		/// <summary>Spawns child resolver.</summary>
		/// <returns>Child resolver.</returns>
		public IContainer Spawn()
		{
			return new PlaceboContainer(this);
		}

		#endregion

		#region private implementation

		/// <summary>Enumerates the chain of parent resolvers (including this one).</summary>
		/// <returns>Collection of resolvers.</returns>
		private IEnumerable<PlaceboContainer> EnumerateChain()
		{
			var current = this;
			while (current != null)
			{
				yield return current;
				current = current._parent;
			}
		}

		/// <summary>Default value of given type.</summary>
		/// <param name="serviceType">Type of the service.</param>
		/// <returns>Default values of given type. Empty value for value types, <c>null</c> for classes.</returns>
		private static object DefaultValue(Type serviceType)
		{
			return serviceType.IsValueType
				? Activator.CreateInstance(serviceType)
				: null;
		}

		/// <summary>Safe wrapper for factory method.</summary>
		/// <param name="factory">The factory.</param>
		/// <param name="require">if set to <c>true</c> values is required 
		/// so failure to run the factory rethrows an exception.</param>
		/// <returns>Result of factory method.</returns>
		private object SafeFactory(Func<IContainer, object> factory, bool require)
		{
			try
			{
				return factory(this);
			}
			catch
			{
				if (require)
					throw;
				return null;
			}
		}

		#endregion
	}
}