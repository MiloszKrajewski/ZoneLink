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
		internal static string Join(this IEnumerable<string> strings, string separator = "")
		{
			return string.Join(separator, strings);
		}

		internal static int GetIdentityHashCode(this object subject)
		{
			return RuntimeHelpers.GetHashCode(subject);
		}

		internal static string GetFriendlyName(this Type type)
		{
			if (type == null) return "null";

			var typeName = type.Name;
			if (!type.IsGenericType)
				return typeName;

			var builder = new StringBuilder();
			var length = typeName.IndexOf('`');
			if (length < 0)
				length = typeName.Length;

			builder.Append(typeName, 0, length);
			builder.Append('<');
			builder.Append(type.GetGenericArguments().Select(GetFriendlyName).Join(","));
			builder.Append('>');

			var result = builder.ToString();

			return result;
		}

		internal static string GetObjectFriendlyName(this object subject)
		{
			if (subject == null) return "null";
			return string.Format(
				"{0}@{1:x}", 
				subject.GetType().GetFriendlyName(),
				subject.GetIdentityHashCode());
		}

		internal static IEnumerable<T> Yield<T>(this T subject)
		{
			yield return subject;
		}

		internal static void Iterate<T>(this IEnumerable<T> collection, Action<T> action)
		{
			foreach (var item in collection)
				action(item);
		}

		private static void Explain(
			Exception exception, int level, StringBuilder builder)
		{
			if (exception == null) return;

			builder.AppendFormat(
				"{0}@{1}: {2}\n{3}\n",
				exception.GetType().GetFriendlyName(),
				level,
				exception.Message,
				exception.StackTrace);

			var aggregate = exception as AggregateException;
			var exceptions =
				aggregate != null
				? aggregate.InnerExceptions
				: exception.InnerException.Yield();

			exceptions.Iterate(e => Explain(e, level + 1, builder));
		}

		internal static string Explain(this Exception exception)
		{
			if (exception == null) return "<null>";
			var result = new StringBuilder();
			Explain(exception, 0, result);
			return result.ToString();
		}
	}
}
