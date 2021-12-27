using System.ComponentModel;

namespace TenantsAPI.Helper.Enums
{
    public enum CodeTableNames
    {
        [Description("Cancelled")]
        Cancelled,

        [Description("Completed")]
        Completed,

        [Description("In Progress")]
        InProgress,

        [Description("Pending")]
        Pending,

        [Description("Behind Schedule")]
        BehindSchedule,

        [Description("On Schedule")]
        OnSchedule,

        [Description("At Risk")]
        AtRisk,

        [Description("On Hold")]
        OnHold,

        [Description("Finished")]
        Finished,

        [Description("Mile Stone")]
        MileStone
    }
}
