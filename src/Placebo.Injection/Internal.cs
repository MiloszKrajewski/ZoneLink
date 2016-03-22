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

		internal static string GetFriendlyObjectName(this object subject)
		{
			if (subject == null) return "null";
			return string.Format(
				"{0}@{1:x}", 
				subject.GetType().GetFriendlyName(), 
				RuntimeHelpers.GetHashCode(subject));
		}
	}
}
