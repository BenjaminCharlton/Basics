using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Basics
{
    public static class Extension
    {
        public static bool IsNull<T>(this T instance)
        {
            return instance == null;
        }

        public static bool IsNotNull<T>(this T instance)
        {
            return !instance.IsNull();
        }

        public static bool IsNullOrDefault<T>(this T instance)
        {
            if (instance == null)
                return true;
            return instance.Equals(default(T));
        }

        public static bool IsNotNullOrDefault<T>(this T instance)
        {
            return !instance.IsNullOrDefault();
        }

        public static TAttribute GetAttribute<TAttribute, TInstance>(this TInstance instance)
            where TAttribute : Attribute
        {
            return (TAttribute)instance.GetAttributes<TAttribute, TInstance>().First();
        }


        public static IEnumerable<TAttribute> GetAttributes<TAttribute, TInstance>(this TInstance instance)
            where TAttribute : Attribute
        {
            var memberInfo = typeof(TInstance).GetMember(instance.ToString());
            return (IEnumerable<TAttribute>)memberInfo[0].GetCustomAttributes(typeof(TAttribute), false);
        }
    }
}
