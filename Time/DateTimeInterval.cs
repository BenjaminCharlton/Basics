using System;
using Basics.GrammarAndSyntax;

namespace Basics.Time
{
    [Flags]
    public enum DateTimeInterval
    {
        [Quantifier("Millisecond", "Milliseconds")]
        Milliseconds = 1,
        Seconds = 2,

        [Quantifier("Minutes", "Minutes")]
        Minutes = 4,

        [Quantifier("Hour", "Hours")]
        Hours = 8,

        [Quantifier("Day", "Days")]
        Days = 16,

        [Quantifier("Week", "Weeks")]
        Weeks = 32,

        [Quantifier("Month", "Months")]
        Months = 64,

        [Quantifier("Year", "Years")]
        Years = 128,

        [Quantifier("Century", "Centuries")]
        Centuries = 256,

        [Quantifier("Millenium", "Millenia")]
        Millenia = 512
    }
}
