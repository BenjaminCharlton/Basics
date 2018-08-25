using System.ComponentModel;

namespace Basics.Time
{
    public static class TimeOfDayExtension
    {
        public static string GetFormatString(this TimeOfDay instance)
        {
            return instance.GetAttribute<DescriptionAttribute, TimeOfDay>().Description;
        }
    }
}
