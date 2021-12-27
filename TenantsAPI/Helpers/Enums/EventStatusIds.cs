using System.ComponentModel;

namespace TenantsAPI.Helper.Enums
{
    public enum EventStatusIds
    {
        [Description("Open")]
        Open = 1,

        [Description("Under Investigation")]
        UnderInvestigation = 2,

        [Description("Corrective Actions")]
        CorrectiveActions = 3,

        [Description("Pending Approval")]
        PendingApproval = 4,

        [Description("Closed")]
        Closed = 5,

        [Description("Cancelled")]
        Cancelled = 6
    }
}