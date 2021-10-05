using System;
using System.Collections.Generic;
using System.Linq;

namespace Google.Maps.WebServices.Extensions
{
    internal static class EnumerableExtensions
    {
        internal static IEnumerable<string> ToUriValues<T>(this IEnumerable<T> values) where T : Enum
        {
            return values.Select(value => value.ToUriValue());
        }

        internal static string JoinUriValues<T>(this IEnumerable<T> values, string separator = "|") where T : Enum
        {
            return string.Join(separator, values.ToUriValues());
        }

        internal static bool IsNullOrEmpty<T>(this IEnumerable<T> enumerable)
        {
            return enumerable is null || !enumerable.Any();
        }

        internal static ICollection<T> ToICollection<T>(this IEnumerable<T> enumerable)
        {
            if (enumerable is ICollection<T> collection)
                return collection;

            return enumerable.ToList();
        }
    }
}
