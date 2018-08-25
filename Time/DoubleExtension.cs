using System;
using System.Collections.Generic;
using System.Text;

namespace Basics.Time
{
    public static class DoubleExtension
    {
        public static long ToTicks(this double value, DateTimeInterval fromInterval)
        {
            long result;

            switch (fromInterval)
            {
                case DateTimeInterval.Milliseconds:
                    result = (long)(value 
                        * DateTimeConstants.TicksPerMillisecond
                        * DateTimeConstants.MillisecondsPerSecond);
                    break;
                case DateTimeInterval.Seconds:
                    result = (long)(value
                        * DateTimeConstants.TicksPerMillisecond
                        * DateTimeConstants.MillisecondsPerSecond);
                    break;
                case DateTimeInterval.Minutes:
                    result = (long)(value
                           * DateTimeConstants.TicksPerMillisecond
                           * DateTimeConstants.MillisecondsPerSecond
                           * DateTimeConstants.SecondsPerMinute);
                    break;
                case DateTimeInterval.Hours:
                    result = (long)(value
                           * DateTimeConstants.TicksPerMillisecond
                           * DateTimeConstants.MillisecondsPerSecond
                           * DateTimeConstants.SecondsPerMinute
                           * DateTimeConstants.MinutesPerHour);
                    break;
                case DateTimeInterval.Days:
                    result = (long)(value
                           * DateTimeConstants.TicksPerMillisecond
                           * DateTimeConstants.MillisecondsPerSecond
                           * DateTimeConstants.SecondsPerMinute
                           * DateTimeConstants.MinutesPerHour
                           * DateTimeConstants.HoursPerDay);
                    break;
                case DateTimeInterval.Weeks:
                    result = (long)(value
                           * DateTimeConstants.TicksPerMillisecond
                           * DateTimeConstants.MillisecondsPerSecond
                           * DateTimeConstants.SecondsPerMinute
                           * DateTimeConstants.MinutesPerHour
                           * DateTimeConstants.HoursPerDay
                           * DateTimeConstants.DaysPerWeek);
                    break;
                case DateTimeInterval.Months:
                    result = (long)(value
                           * DateTimeConstants.TicksPerMillisecond
                           * DateTimeConstants.MillisecondsPerSecond
                           * DateTimeConstants.SecondsPerMinute
                           * DateTimeConstants.MinutesPerHour
                           * DateTimeConstants.HoursPerDay
                           * DateTimeConstants.DaysPerMonth);
                    break;
                case DateTimeInterval.Years:
                    result = (long)(value
                           * DateTimeConstants.TicksPerMillisecond
                           * DateTimeConstants.MillisecondsPerSecond
                           * DateTimeConstants.SecondsPerMinute
                           * DateTimeConstants.MinutesPerHour
                           * DateTimeConstants.HoursPerDay
                           * DateTimeConstants.DaysPerYear);
                    break;
                case DateTimeInterval.Centuries:
                    result = (long)(value
                           * DateTimeConstants.TicksPerMillisecond
                           * DateTimeConstants.MillisecondsPerSecond
                           * DateTimeConstants.SecondsPerMinute
                           * DateTimeConstants.MinutesPerHour
                           * DateTimeConstants.HoursPerDay
                           * DateTimeConstants.DaysPerYear
                           * DateTimeConstants.YearsPerCentury);
                    break;
                case DateTimeInterval.Millenia:
                    result = (long)(value
                        * DateTimeConstants.TicksPerMillisecond
                           * DateTimeConstants.MillisecondsPerSecond
                           * DateTimeConstants.SecondsPerMinute
                           * DateTimeConstants.MinutesPerHour
                           * DateTimeConstants.HoursPerDay
                           * DateTimeConstants.DaysPerYear
                           * DateTimeConstants.YearsPerCentury
                           * DateTimeConstants.CenturiesPerMillenium);
                    break;
                default:
                    result = (long)value;
                    break;
            }
            return result;
        }
    }
}
