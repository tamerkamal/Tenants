using System.ComponentModel;

namespace TenantsAPI.Helper.Enums
{
    public enum DaysOfWeek
    {
        [Description("Saturday")]
        Saturday = 0,

        [Description("Sunday")]
        Sunday,

        [Description("Monday")]
        Monday,

        [Description("Tuesday")]
        Tuesday,

        [Description("Wednesday")]
        Wednesday,

        [Description("Thursday")]
        Thursday,

        [Description("Friday")]
        Friday
    }
}
