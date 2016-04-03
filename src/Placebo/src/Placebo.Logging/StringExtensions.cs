using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Placebo.Logging
{
	internal static class StringExtensions
	{
		public static Func<string> DeferToString(this string message)
		{
			return () => message ?? "<null>";
		}

		public static Func<string> DeferToString(this Exception exception)
		{
			return () => {
				if (exception == null) return "<null>";
				try
				{
					var result = new StringBuilder();
					ExplainException(exception, 0, result);
					return result.ToString();
				}
				catch (Exception e)
				{
					return string.Format("<exception {0}>", e.GetType().GetFriendlyName());
				}
			};
		}

		public static Func<string> DeferToString(this Func<string> factory)
		{
			return () => {
				if (factory == null) return "<null>";
				try
				{
					return factory() ?? "<null>";
				}
				catch (Exception e)
				{
					return string.Format("<exception {0}>", e.GetType().GetFriendlyName());
				}
			};
		}

		public static Func<string> DeferToString(this string message, object[] arguments)
		{
			return () => {
				if (message == null) return "<null>";
				try
				{
					return string.Format(message, arguments);
				}
				catch (Exception e)
				{
					return string.Format("<exception {0}>", e.GetType().GetFriendlyName());
				}
			};
		}

		private static void ExplainException(
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

			exceptions.Iterate(e => ExplainException(e, level + 1, builder));
		}
	}
}
