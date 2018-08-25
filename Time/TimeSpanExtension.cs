using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection;
using Basics.Enumerations;
using Basics.GrammarAndSyntax;
using Basics.Text;
using Microsoft.Extensions.Localization;

namespace Basics.Time
{
    public static class TimeSpanExtension
    {
        public static IDictionary<double, string> ListIntervals(
            this TimeSpan span,
            DateTimeInterval includeIntervals,
            byte maxDepth,
            DateTimeInterval interval,
            long step,
            long start = 0,
            long stop = long.MaxValue)
        {
            IDictionary<double, string> result = new Dictionary<double, string>();

            var startTicks = start.ToTicks(interval);
            var stopTicks = stop == long.MaxValue ? span.Ticks : stop.ToTicks(interval);
            var stepTicks = step.ToTicks(interval);


            for (var ticks = startTicks;
                ticks <= stopTicks;
                ticks = ticks + stepTicks)
            {
                var key = ticks.FromTicks(interval);
                string value = new TimeSpan(ticks).Format(includeIntervals, maxDepth);
                result.Add(new KeyValuePair<double, string>(key, value));
            }

            return result;
        }


        private static string Format(
            DateTimeInterval interval,
            long ticks,
            out long ticksRemainder,
            IStringLocalizer localizer)
        {
            if (interval.GetFlags().Count() > 1)
                throw new ArgumentException(
                    string.Format("This function works with no more than one DateTimeInterval flag." +
                                  "The parameter passed was {0}, which is {1} flags",
                    interval, interval.GetFlags().Count()),
                    nameof(interval));

            var wholeIntervals = ticks.GetWholeInterval(interval, out ticksRemainder);
            var term = interval.GetAppropriateSingularOrPluralTerm(wholeIntervals, localizer);

            return string.Format("{0} {1}", wholeIntervals, term);
        }


        public static string Format(
            this TimeSpan span,
            byte maxDepth = 2,
            IStringLocalizer localizer = null)
        {
            return span.Format(DefaultDateTimeIntervals, maxDepth, localizer);
        }

        public static string Format(
            this TimeSpan span,
            DateTimeInterval includeIntervals,
            byte maxDepth,
            IStringLocalizer localizer = null)
        {
            string result = String.Empty;
            var ticksRemainder = span.Ticks;

            byte depth = 0;

            foreach (Enum flag in includeIntervals.GetFlags(SortOrder.Descending))
            {
                var interval = (DateTimeInterval)flag;
                if (depth < maxDepth)
                {
                    var wholeIntervals = ticksRemainder.GetWholeInterval(interval, out ticksRemainder);

                    if (wholeIntervals > 0)
                    {
                        depth += 1;

                        var term = interval.GetAppropriateSingularOrPluralTerm(wholeIntervals, localizer);

                        result = result.AppendIfRequired(" ", string.Format("{0} {1}", wholeIntervals, term));
                    }
                }
                else
                {
                    break;
                }
            }

            return result;
        }

        public static string Format(
            this TimeSpan span,
            IEnumerable<TimeSpanFormattingRule> formattingRules,
            IStringLocalizer localizer = null)
        {
            foreach (TimeSpanFormattingRule rule in formattingRules.ToList())
            {
                if (rule.Test(span))
                {
                    return rule.Format(span);
                }
            }
            return Format(span);
        }


        public static DateTimeInterval DefaultDateTimeIntervals => DateTimeInterval.Years
                                                                   | DateTimeInterval.Months
                                                                   | DateTimeInterval.Hours
                                                                   | DateTimeInterval.Minutes;
    }

}