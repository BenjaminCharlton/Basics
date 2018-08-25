using System;
using System.Collections.Generic;
using Basics.Enumerations;
using Basics.Mathematics;
using Basics.Text;
using Microsoft.Extensions.Localization;

namespace Basics.Time
{
    public class TimeSpanFormattingRule
    {
        private readonly long _lowerThresholdTicks;
        private readonly long _upperThresholdTicks;
        private readonly DateTimeInterval _intervals;
        private readonly Func<TimeSpan, string> _formatter;

        public TimeSpanFormattingRule(
            DateTimeInterval interval,
            double upperThreshold,
            string output,
            IStringLocalizer localizer = null)
            : this(interval, 0, upperThreshold, interval, ts => output.Localize(localizer))
        {
        }

        public TimeSpanFormattingRule(
            DateTimeInterval interval,
            double lowerThreshold,
            double upperThreshold,
            string output,
            IStringLocalizer localizer = null) :
        this(interval, lowerThreshold, upperThreshold, interval, ts => output.Localize(localizer))
        {
        }

        public TimeSpanFormattingRule(
            DateTimeInterval interval,
            double upperThreshold,
            Func<TimeSpan, string> formatter) : this(interval, 0, upperThreshold, interval, formatter)
        {
        }

        public TimeSpanFormattingRule(
            DateTimeInterval interval,
            double lowerThreshold,
            double upperThreshold,
            Func<TimeSpan, string> formatter) : this(interval, lowerThreshold, upperThreshold, interval, formatter)
        {
        }


        public TimeSpanFormattingRule(
            DateTimeInterval interval,
            double lowerThreshold,
            double upperThreshold,
            DateTimeInterval intervals,
            Func<TimeSpan, string> formatter)
        {
            if (upperThreshold > lowerThreshold)
            {
                _lowerThresholdTicks = lowerThreshold.ToTicks(interval);
                _upperThresholdTicks = upperThreshold.ToTicks(interval);
            }
            else
            {
                _upperThresholdTicks = lowerThreshold.ToTicks(interval);
                _lowerThresholdTicks = upperThreshold.ToTicks(interval);
            }

            _intervals = intervals;
            _formatter = formatter ?? throw new ArgumentNullException(nameof(formatter));
        }

        public TimeSpanFormattingRule(
            DateTimeInterval interval,
            long upperThreshold,
            string output,
            IStringLocalizer localizer = null) :
            this(interval, 0, upperThreshold, interval, ts => output.Localize(localizer))
        {
        }

        public TimeSpanFormattingRule(
            DateTimeInterval interval,
            long lowerThreshold,
            long upperThreshold,
            string output,
            IStringLocalizer localizer = null) :
            this(interval, lowerThreshold, upperThreshold, interval, ts => output.Localize(localizer))
        {
        }

        public TimeSpanFormattingRule(
            DateTimeInterval interval,
            long upperThreshold,
            Func<TimeSpan, string> formatter) :
            this(interval, 0, upperThreshold, interval, formatter)
        {
        }

        public TimeSpanFormattingRule(
            DateTimeInterval interval,
            long lowerThreshold,
            long upperThreshold,
            Func<TimeSpan, string> formatter) :
            this(interval, lowerThreshold, upperThreshold, interval, formatter)
        {
        }


        public TimeSpanFormattingRule(
            DateTimeInterval interval,
            long lowerThreshold,
            long upperThreshold,
            DateTimeInterval intervals,
            Func<TimeSpan, string> formatter)
        {
            if (upperThreshold > lowerThreshold)
            {
                _lowerThresholdTicks = lowerThreshold.ToTicks(interval);
                _upperThresholdTicks = upperThreshold.ToTicks(interval);
            }
            else
            {
                _upperThresholdTicks = lowerThreshold.ToTicks(interval);
                _lowerThresholdTicks = upperThreshold.ToTicks(interval);
            }

            _intervals = intervals;
            _formatter = formatter ?? throw new ArgumentNullException(nameof(formatter));
        }

        public bool Test(TimeSpan span)
        {
            return span.Ticks.IsBetween(_lowerThresholdTicks, _upperThresholdTicks) &&
                   span.Ticks.HasAllTheseIntervals(_intervals);
        }

        public string Format(TimeSpan span)
        {
            if (Test(span))
            {
                return _formatter(span);
            }
            throw new ArgumentException(
                string.Format("This rule is supposed to be used to format TimeSpans between {0} and {1} ticks. The instance passed is: {2}",
                    _lowerThresholdTicks,
                    _lowerThresholdTicks,
                    span.Ticks), nameof(span));
        }


        public static IEnumerable<TimeSpanFormattingRule> RoughlyHowLong(IStringLocalizer localizer = null)
        {
            return new List<TimeSpanFormattingRule>
            {
                new TimeSpanFormattingRule(DateTimeInterval.Seconds, 10, "just a moment"),
                new TimeSpanFormattingRule(DateTimeInterval.Seconds, 10, 30, "a few seconds"),
                new TimeSpanFormattingRule(DateTimeInterval.Seconds, 30, 50, "less than a minute"),
                new TimeSpanFormattingRule(DateTimeInterval.Seconds, 50, 70, "about a minute"),
                new TimeSpanFormattingRule(DateTimeInterval.Seconds, 70, 80, "just over a minute"),
                new TimeSpanFormattingRule(DateTimeInterval.Seconds, 80, 150, "a couple of minutes"),
                new TimeSpanFormattingRule(DateTimeInterval.Minutes, 2.5, 12.5, "a few minutes"),
                new TimeSpanFormattingRule(DateTimeInterval.Minutes, 12.5, 17, "about a quarter of an hour"),
                new TimeSpanFormattingRule(DateTimeInterval.Minutes, 17, 24, "about 20 minutes"),
                new TimeSpanFormattingRule(DateTimeInterval.Minutes, 24, 37, "about half an hour"),

                new TimeSpanFormattingRule(DateTimeInterval.Minutes, 37, 52,
                    ts => "about {0} minutes".Localize(localizer, ts.TotalMinutes.RoundToNearestMultipleOf(5))),

                new TimeSpanFormattingRule(DateTimeInterval.Minutes, 52, 69, "about an hour"),

                new TimeSpanFormattingRule(DateTimeInterval.Hours, 1.15, 1.87,
                    ts => "about an hour and {0} minutes".Localize(localizer, ts.TotalMinutes.RoundToNearestMultipleOf(5))),

                new TimeSpanFormattingRule(DateTimeInterval.Hours, 1.87, 2.13, "a couple of hours"),

                new TimeSpanFormattingRule(DateTimeInterval.Hours, 2.13, 2.83,
                    ts => "about {0} hours {1} minutes".Localize(localizer,
                        ts.Ticks.GetWholeInterval(DateTimeInterval.Hours, out long ticksRemainder),
                        ticksRemainder.FromTicks(DateTimeInterval.Minutes).RoundToNearestMultipleOf(15))),

                new TimeSpanFormattingRule(DateTimeInterval.Days, 0.25, 3,
                    ts => {var then = DateTime.Now + ts;
                        if (then.IsToday()) return "earlier today".Localize(localizer);
                        var timeOfDay = then.GetTimeOfDay();
                        return timeOfDay.GetFormatString().Localize(localizer, GetDayRelativeToToday(then, true, localizer));
                    }),

                new TimeSpanFormattingRule(DateTimeInterval.Hours, 2.83, 24,
                    ts => "about {0} hours".Localize(localizer, ts.TotalHours.RoundToNearestMultipleOf(1))),

                new TimeSpanFormattingRule(DateTimeInterval.Days, 5.75, 8.75, "about a week"),

                new TimeSpanFormattingRule(DateTimeInterval.Days, 3, 12.75,
                    ts => "{0} days".Localize(localizer, ts.TotalDays.RoundToNearestMultipleOf(1))),

                new TimeSpanFormattingRule(DateTimeInterval.Days, 12.75, 16.5, "a couple of weeks"),
                new TimeSpanFormattingRule(DateTimeInterval.Days, 16.5, 19.5, "about two and a half weeks"),
                new TimeSpanFormattingRule(DateTimeInterval.Days, 19.5, 23.5, "about three weeks"),
                new TimeSpanFormattingRule(DateTimeInterval.Days, 23.5, 28.5, "just under a month"),
                new TimeSpanFormattingRule(DateTimeInterval.Days, 28.5, 33.5, "about a month"),
                new TimeSpanFormattingRule(DateTimeInterval.Weeks, 7.4, 8.75, "a couple of months"),
                new TimeSpanFormattingRule(DateTimeInterval.Weeks, 4.79, 11, "a few weeks"),
                new TimeSpanFormattingRule(DateTimeInterval.Months, 11, 12.75, "about a year"),
                new TimeSpanFormattingRule(DateTimeInterval.Months, 12.75, 14, "just over a year"),
                new TimeSpanFormattingRule(DateTimeInterval.Months, 16.5, 19.5, "about one and a half years"),

                new TimeSpanFormattingRule(DateTimeInterval.Months, 2.53, 16.5,
                    ts => "about {0} months".Localize(localizer,
                        ts.Ticks.FromTicks(DateTimeInterval.Months).RoundToNearestMultipleOf(1))),

                new TimeSpanFormattingRule(DateTimeInterval.Years, 1.37, 47, "{0} years"),

                new TimeSpanFormattingRule(DateTimeInterval.Years, 47, 970,
                    ts =>
                    {
                        var years = ts.Ticks.FromTicks(DateTimeInterval.Years);
                        var estimate = years.RoundToNearestMultipleOf(10);
                        return estimate <= years ?
                        "almost {0} years".Localize(localizer, estimate) :
                        "over {0} years".Localize(localizer, estimate);
                    }),

                new TimeSpanFormattingRule(DateTimeInterval.Years, 970, 1030, "about a century"),
                new TimeSpanFormattingRule(DateTimeInterval.Years, 1030, long.MaxValue, "over a century")
            };
        }



        private static string FormatSoonAndRecentDays(TimeSpan span, IStringLocalizer localizer = null)
        {
            var then = DateTime.Now + span;
            if (then.IsToday()) return "earlier today".Localize(localizer);
            var timeOfDay = then.GetTimeOfDay();
            return timeOfDay.GetFormatString().Localize(localizer, GetDayRelativeToToday(then, true, localizer));
        }


        private static string GetDayRelativeToToday(DateTime when, bool includeOn, IStringLocalizer localizer = null)
        {
            if(!when.IsWithin(new TimeSpan(7, 0, 0, 0)))
                throw new ArgumentException("This function can only deal with DateTime objects whose value is within 7 days of DateTime.Now", nameof(when));

            if (when.IsTomorrow())
             return "tomorrow".Localize(localizer);
            if (when.IsYesterday())
            return "yesterday".Localize(localizer);
           
                 var day = Enum.GetName(typeof(DayOfWeek), when.DayOfWeek);

            return includeOn ? string.Format("on {0}".Localize(localizer), day) : day;
        }
    }
}
