using System.ComponentModel;

namespace TenantsAPI.Helper.Enums
{
    public enum ScheduleStatuses
    {
        [Description("All")]
        All = 0,

        [Description("Finished")]
        Finished = 1,

        [Description("On Schedule")]
        OnSchedule = 2,

        [Description("Behind Schedule")]
        BehindSchedule = 3,

        [Description("On Hold")]
        OnHold,

        [Description("At Risk")]
        AtRisk
    }
}
