using System.ComponentModel;

namespace Basics.Time
{
    public enum TimeOfDay
    {
        [Description("in the small hours {0}")]
        SmallHours = 1,

        [Description("early {0}")]
        EarlyMorning = 2,

        [Description("mid-morning {0}")]
        MidMorning = 3,

        [Description("late {0} morning")]
        LateMorning = 4,

        [Description("{0} lunchtime")]
        Lunchtime = 5,

        [Description("early afternoon {0}")]
        EarlyAfternoon = 6,

        [Description("mid-afternoon {0}")]
        MidAfternoon = 7,

        [Description("late afternoon {0}")]
        LateAfternoon = 8,

        [Description("early {0} evening")]
        EarlyEvening = 9,

        [Description("late evening {0}")]
        Evening = 10,

        [Description("{0} night")]
        Night = 11
    }
}
