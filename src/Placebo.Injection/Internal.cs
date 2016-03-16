using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Placebo.Injection
{
	internal static class Internal
	{
		public static IEnumerable<T> ApplyToEach<T>(this IEnumerable<T> collection, Action<T> action)
		{
			foreach (var item in collection)
			{
				action(item);
				yield return item;
			}
		}
	}
}
