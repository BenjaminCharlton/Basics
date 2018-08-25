using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics
{
    public static class ComparableExtension
    {
        /// <summary>
        /// Checks to see if an object falls between the two bounds passed as parameters when they are compared.
        /// </summary>
        public static bool IsBetween<T>(this IComparable<T> instance, T bound1, T bound2)
            where T : IComparable<T>
        {
            bool result;

            if(bound1.CompareTo(bound2) <= 0)
            {
                result = instance.CompareTo(bound1) >= 0 && instance.CompareTo(bound2) <= 0;
            }
            else
            {
                result = instance.CompareTo(bound1) <= 0 && instance.CompareTo(bound2) >= 0;
            }

            return result;
        }
    }
}
