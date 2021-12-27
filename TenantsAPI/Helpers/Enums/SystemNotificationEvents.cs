using System.ComponentModel;

namespace TenantsAPI.Helper.Enums
{
    public enum SystemNotificationEventNames
    {
        #region JobDefect Table (JobDefect || Activity || Issue)

        [Description("JobDefect-Created")]
        JobDefect_Created,

        [Description("JobDefect-Re-Assigned")]
        JobDefect_ReAssigned,

        [Description("JobDefect-StatusChanged")]
        JobDefect_StatusChanged,

        #endregion
    }

    public enum SystemNotificationEventDescriptions
    {
        #region JobDefect Table (JobDefect || Activity || Issue)

        [Description("Activity Created ")]
        JobDefect_Created,

        [Description("Activity ReAssigned ")]
        JobDefect_ReAssigned,

        [Description("ReAssigned ")]
        ReAssigned,

        [Description("Activity Status Changed ")]
        JobDefect_StatusChanged,

        [Description("Status Changed ")]
        StatusChanged,

        #endregion
    }
}