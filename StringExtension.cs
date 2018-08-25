using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Basics
{
    public static class StringExtension
    {
        public static bool IsNullOrWhiteSpace(this string instance)
        {
            if (instance == null)
                return true;
            return instance == string.Empty;
        }

        public static string Coalesce(this string instance, string defaultValue)
        {
            return instance.IsNullOrWhiteSpace() ? defaultValue : instance;
        }
    }
}
