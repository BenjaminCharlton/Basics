using System;

namespace Basics.Time
{
    public static class DateTimeExtension
    {
        public static TimeSpan RelativeToNow(this DateTime when)
        {
            return when.Subtract(DateTime.Now);
        }

        public static bool IsYesterday(this DateTime when)
        {
            var now = DateTime.Now;

            return when.Date == now.AddDays(-1).Date;
        }

        public static bool IsTomorrow(this DateTime when)
        {
            var now = DateTime.Now;

            return when.Date == now.AddDays(1).Date;
        }

        public static bool IsToday(this DateTime when)
        {
            return when.Date == DateTime.Now.Date;
        }

        public static bool IsInThePast(this DateTime when)
        {
            return when < DateTime.Now;
        }

        public static bool IsInTheFuture(this DateTime when)
        {
            return when > DateTime.Now;
        }

        public static bool IsWithin(this DateTime when, TimeSpan tolerance, DateTime compareTo)
        {
            return when.IsBetween(compareTo.Subtract(tolerance), compareTo.Add(tolerance));
        }

        public static bool IsWithin(this DateTime when, TimeSpan tolerance)
        {
            return when.IsWithin(tolerance, DateTime.Now);
        }


        public static TimeOfDay GetTimeOfDay(this DateTime when)
        {
            TimeOfDay result;

            if (when.TimeOfDay < new TimeSpan(5, 0, 0))
            {
                result = TimeOfDay.SmallHours;
            }

            else if (when.TimeOfDay <= new TimeSpan(8, 45, 0))
            {
                result = TimeOfDay.EarlyMorning;
            }

            else if (when.TimeOfDay <= new TimeSpan(10, 15, 0))
            {
                result = TimeOfDay.MidMorning;
            }

            else if (when.TimeOfDay <= new TimeSpan(11, 59, 59))
            {
                result = TimeOfDay.LateMorning;
            }

            else if (when.TimeOfDay <= new TimeSpan(13, 30, 0))
            {
                result = TimeOfDay.Lunchtime;
            }

            else if (when.TimeOfDay <= new TimeSpan(14, 30, 0))
            {
                result = TimeOfDay.EarlyAfternoon;
            }

            else if (when.TimeOfDay <= new TimeSpan(15, 59, 59))
            {
                result = TimeOfDay.MidAfternoon;
            }

            else if (when.TimeOfDay <= new TimeSpan(17, 59, 59))
            {
                result = TimeOfDay.LateAfternoon;
            }

            else if (when.TimeOfDay <= new TimeSpan(19, 30, 0))
            {
                result = TimeOfDay.EarlyEvening;
            }

            else if (when.TimeOfDay <= new TimeSpan(20, 45, 0))
            {
                result = TimeOfDay.Evening;
            }

            else
            {
                result = TimeOfDay.Night;
            }

            return result;
        }
    }
}