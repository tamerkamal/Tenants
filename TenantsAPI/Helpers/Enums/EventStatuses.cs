using System.ComponentModel;

namespace TenantsAPI.Helper.Enums
{
    public enum EventStatuses
    {
        [Description("Open")]
        Open,
        [Description("Under Investigation")]
        UnderInvestigation,
        [Description("Corrective Actions")]
        CorrectiveActions,
        [Description("Pending Approval")]
        PendingApproval,
        [Description("Closed")]
        Closed
    }
}
