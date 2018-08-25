using System;
using Basics.Enumerations;
using Basics.Mathematics;

namespace Basics.Time
{
    public static class LongExtension
    {
        public static long ToTicks(this long value, DateTimeInterval fromInterval)
        {
            switch (fromInterval)
            {
                case DateTimeInterval.Milliseconds:
                    return value * DateTimeConstants.TicksPerMillisecond * DateTimeConstants.MillisecondsPerSecond;
                case DateTimeInterval.Seconds:
                    return value * DateTimeConstants.TicksPerMillisecond * DateTimeConstants.MillisecondsPerSecond;
                case DateTimeInterval.Minutes:
                    return value
                        * DateTimeConstants.TicksPerMillisecond
                        * DateTimeConstants.MillisecondsPerSecond 
                        * DateTimeConstants.SecondsPerMinute;
                case DateTimeInterval.Hours:
                    return value
                           * DateTimeConstants.TicksPerMillisecond
                           * DateTimeConstants.MillisecondsPerSecond
                           * DateTimeConstants.SecondsPerMinute
                           * DateTimeConstants.MinutesPerHour;
                case DateTimeInterval.Days:
                    return value
                           * DateTimeConstants.TicksPerMillisecond
                           * DateTimeConstants.MillisecondsPerSecond
                           * DateTimeConstants.SecondsPerMinute
                           * DateTimeConstants.MinutesPerHour
                           * DateTimeConstants.HoursPerDay;
                case DateTimeInterval.Weeks:
                    return value
                           * DateTimeConstants.TicksPerMillisecond
                           * DateTimeConstants.MillisecondsPerSecond
                           * DateTimeConstants.SecondsPerMinute
                           * DateTimeConstants.MinutesPerHour
                           * DateTimeConstants.HoursPerDay
                           * DateTimeConstants.DaysPerWeek;
                case DateTimeInterval.Months:
                    return (long)(value
                           * DateTimeConstants.TicksPerMillisecond
                           * DateTimeConstants.MillisecondsPerSecond
                           * DateTimeConstants.SecondsPerMinute
                           * DateTimeConstants.MinutesPerHour
                           * DateTimeConstants.HoursPerDay
                           * DateTimeConstants.DaysPerMonth);
                case DateTimeInterval.Years:
                    return (long)(value
                           * DateTimeConstants.TicksPerMillisecond
                           * DateTimeConstants.MillisecondsPerSecond
                           * DateTimeConstants.SecondsPerMinute
                           * DateTimeConstants.MinutesPerHour
                           * DateTimeConstants.HoursPerDay
                           * DateTimeConstants.DaysPerYear);
                case DateTimeInterval.Centuries:
                    return (long)(value
                           * DateTimeConstants.TicksPerMillisecond
                           * DateTimeConstants.MillisecondsPerSecond
                           * DateTimeConstants.SecondsPerMinute
                           * DateTimeConstants.MinutesPerHour
                           * DateTimeConstants.HoursPerDay
                           * DateTimeConstants.DaysPerYear
                           * DateTimeConstants.YearsPerCentury);
                case DateTimeInterval.Millenia:
                    return (long)(value
                           * DateTimeConstants.TicksPerMillisecond
                           * DateTimeConstants.MillisecondsPerSecond
                           * DateTimeConstants.SecondsPerMinute
                           * DateTimeConstants.MinutesPerHour
                           * DateTimeConstants.HoursPerDay
                           * DateTimeConstants.DaysPerYear
                           * DateTimeConstants.YearsPerCentury
                           * DateTimeConstants.CenturiesPerMillenium);
                default:
                    return value;
            }
        }

        public static double FromTicks(this long ticks, DateTimeInterval toInterval)
        {
            double result;

            switch (toInterval)
            {
                case DateTimeInterval.Milliseconds:
                    // ReSharper disable once PossibleLossOfFraction
                    result = ticks / DateTimeConstants.TicksPerMillisecond;
                    break;
                case DateTimeInterval.Seconds:
                    // ReSharper disable once PossibleLossOfFraction
                    result = ticks / DateTimeConstants.TicksPerMillisecond / DateTimeConstants.MillisecondsPerSecond;
                    break;
                case DateTimeInterval.Minutes:
                    // ReSharper disable once PossibleLossOfFraction
                    result = ticks 
                        / DateTimeConstants.TicksPerMillisecond 
                        / DateTimeConstants.MillisecondsPerSecond 
                        / DateTimeConstants.SecondsPerMinute;
                    break;
                case DateTimeInterval.Hours:
                    // ReSharper disable once PossibleLossOfFraction
                    result = ticks
                             / DateTimeConstants.TicksPerMillisecond
                             / DateTimeConstants.MillisecondsPerSecond
                             / DateTimeConstants.SecondsPerMinute
                             / DateTimeConstants.MinutesPerHour;
                    break;
                case DateTimeInterval.Days:
                    // ReSharper disable once PossibleLossOfFraction
                    result = ticks
                             / DateTimeConstants.TicksPerMillisecond
                             / DateTimeConstants.MillisecondsPerSecond
                             / DateTimeConstants.SecondsPerMinute
                             / DateTimeConstants.MinutesPerHour
                             / DateTimeConstants.HoursPerDay;
                    break;
                case DateTimeInterval.Weeks:
                    // ReSharper disable once PossibleLossOfFraction
                    result = ticks
                             / DateTimeConstants.TicksPerMillisecond
                             / DateTimeConstants.MillisecondsPerSecond
                             / DateTimeConstants.SecondsPerMinute
                             / DateTimeConstants.MinutesPerHour
                             / DateTimeConstants.HoursPerDay
                             / DateTimeConstants.DaysPerWeek;
                    break;
                case DateTimeInterval.Months:
                    // ReSharper disable once PossibleLossOfFraction
                    result = ticks
                             / DateTimeConstants.TicksPerMillisecond
                             / DateTimeConstants.MillisecondsPerSecond
                             / DateTimeConstants.SecondsPerMinute
                             / DateTimeConstants.MinutesPerHour
                             / DateTimeConstants.HoursPerDay
                             / DateTimeConstants.DaysPerMonth;
                    break;
                case DateTimeInterval.Years:
                    // ReSharper disable once PossibleLossOfFraction
                    result = ticks
                             / DateTimeConstants.TicksPerMillisecond
                             / DateTimeConstants.MillisecondsPerSecond
                             / DateTimeConstants.SecondsPerMinute
                             / DateTimeConstants.MinutesPerHour
                             / DateTimeConstants.HoursPerDay
                             / DateTimeConstants.DaysPerYear;
                    break;
                case DateTimeInterval.Centuries:
                    // ReSharper disable once PossibleLossOfFraction
                    result = ticks
                             / DateTimeConstants.TicksPerMillisecond
                             / DateTimeConstants.MillisecondsPerSecond
                             / DateTimeConstants.SecondsPerMinute
                             / DateTimeConstants.MinutesPerHour
                             / DateTimeConstants.HoursPerDay
                             / DateTimeConstants.DaysPerYear
                             / DateTimeConstants.YearsPerCentury;
                    break;
                case DateTimeInterval.Millenia:
                    // ReSharper disable once PossibleLossOfFraction
                    result = ticks
                             / DateTimeConstants.TicksPerMillisecond
                             / DateTimeConstants.MillisecondsPerSecond
                             / DateTimeConstants.SecondsPerMinute
                             / DateTimeConstants.MinutesPerHour
                             / DateTimeConstants.HoursPerDay
                             / DateTimeConstants.DaysPerYear
                             / DateTimeConstants.YearsPerCentury
                             / DateTimeConstants.CenturiesPerMillenium;
                    break;
                default:
                    result = ticks;
                    break;
            }

            return result;
        }

        public static long GetWholeInterval(this long ticks, DateTimeInterval interval, out long ticksRemainder)
        {
            var wholeIntervals = (long)Math.Floor(ticks.FromTicks(interval));
            
            ticksRemainder = (long) (ticks - (wholeIntervals.ToTicks(interval)));
            return wholeIntervals;
        }


        public static double GetNearestInterval(this long ticks,
            DateTimeInterval interval,
            double roundToNearestMultipleOf = 0)
        {
            var result = ticks.FromTicks(interval);
            return result.RoundToNearestMultipleOf(roundToNearestMultipleOf);
        }


        internal static bool HasAllTheseIntervals(this long ticks,
            DateTimeInterval intervals)
        {
            bool result = true;

            foreach (Enum flag in intervals.GetFlags(SortOrder.Descending))
            {
                result &= ticks.HasInterval((DateTimeInterval) flag);
            }

            return result;
        }

        internal static bool HasInterval(this long ticks, DateTimeInterval interval)
        {
            return ticks.GetWholeInterval(interval, out long ticksRemainder) > 0;
        }
    }
}
