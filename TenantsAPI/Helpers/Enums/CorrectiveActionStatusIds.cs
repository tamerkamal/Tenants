using System.ComponentModel;

namespace TenantsAPI.Helper.Enums
{
    public enum CorrectiveActionStatusIds
    {
        [Description("Open")]
        Open = 1,

        [Description("Pending Approval")]
        PendingApproval = 2,

        [Description("Approved")]
        Approved = 3
    }
}