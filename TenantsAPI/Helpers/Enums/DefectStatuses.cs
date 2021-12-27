using System.ComponentModel;

namespace TenantsAPI.Helper.Enums
{
    public enum DefectStatuses
    {
        [Description("Open")]
        Open = 1,

        [Description("Closed")]
        Closed = 2,

        [Description("Pending")]
        Pending = 3,

        [Description("On Hold")]
        OnHold = 4,

        [Description("Cancelled")]
        Cancelled = 5,

        [Description("Review")]
        Review = 6,

        [Description("(All)")]
        All
    }
}