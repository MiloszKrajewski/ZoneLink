using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

// ReSharper disable once CheckNamespace
namespace Placebo
{
	internal static class Internal
	{
		public static int GetIdentityHashCode(this object subject)
		{
			return RuntimeHelpers.GetHashCode(subject);
		}

		public static string GetFriendlyName(this Type type)
		{
			if (type == null) return "<null>";

			var typeName = type.Name;
			if (!type.IsGenericType)
				return typeName;

			var length = typeName.IndexOf('`');
			if (length < 0) length = typeName.Length;

			return new StringBuilder()
				.Append(typeName, 0, length)
				.Append('<')
				.Append(type.GetGenericArguments().Select(GetFriendlyName).Join(","))
				.Append('>')
				.ToString();
		}

		public static string GetObjectFriendlyName(this object subject)
		{
			if (subject == null) return "<null>";
			return string.Format(
				"{0}@{1:x}", 
				subject.GetType().GetFriendlyName(),
				subject.GetIdentityHashCode());
		}

		public static string Join(this IEnumerable<string> strings, string separator = "")
		{
			return string.Join(separator, strings);
		}

		public static IEnumerable<T> Yield<T>(this T subject)
		{
			yield return subject;
		}

		public static void Iterate<T>(this IEnumerable<T> collection, Action<T> action)
		{
			foreach (var item in collection)
				action(item);
		}


	}
}
