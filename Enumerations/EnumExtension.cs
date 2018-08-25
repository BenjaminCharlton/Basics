using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Basics.GrammarAndSyntax;
using Basics.Time;

namespace Basics.Enumerations
{
    public static class EnumExtension
    {
        public static IEnumerable<Enum> GetFlags(this Enum input, SortOrder order = SortOrder.Ascending)
        {
            Array values = Enum.GetValues(input.GetType());
            Array.Sort(values);
            if(order == SortOrder.Descending)
                Array.Reverse(values);

            foreach (Enum value in values)
                if (input.HasFlag(value))
                    yield return value;
        }


        public static string GetName<TEnum>(this Enum input)
        {
            return Enum.GetName(typeof(TEnum), input);
        }
    }
}
