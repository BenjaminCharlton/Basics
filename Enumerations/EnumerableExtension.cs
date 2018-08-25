using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Basics.Enumerations
{
    public static class EnumerableExtension
    {
        public static IEnumerable<T> RemoveNullOrDefaultValues<T>(this IEnumerable<T> instance)
        {
            var list = instance.ToList();

            list.RemoveAll(i => i.IsNullOrDefault());

            return list;
        }

        public static IEnumerable<T> RemoveNullValues<T>(this IEnumerable<T> instance)
        {
            var list = instance.ToList();

            list.RemoveAll(i => i == null);

            return list;
        }

        public static bool IsNullOrWhiteSpace<T>(this IEnumerable<T> instance)
        {
            var enumerable = instance as T[] ?? instance.ToArray();
            return enumerable.IsNullOrDefault() || !enumerable.Any();
        }
    }
}