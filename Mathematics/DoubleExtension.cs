using System;
using System.Collections.Generic;
using System.Text;

namespace Basics.Mathematics
{
    public static class DoubleExtension
    {
        /// <summary>
        /// Rounds the number to the nearest multiple of the passed parameter.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="multiple"></param>
        /// <returns></returns>
        /// <example>double instance = 37
        /// instance.RoundToNearestMultipleOf(5)
        /// returns 35.</example>
        public static double RoundToNearestMultipleOf(this double instance, double multiple)
        {
            double result = instance;

            // ReSharper disable once CompareOfFloatsByEqualityOperator because it's a zero tolerance comparison
            if (multiple != 0)
            {
                result = Math.Round((instance / multiple), MidpointRounding.AwayFromZero) * multiple;
            }

            return result;
        }
    }
}
