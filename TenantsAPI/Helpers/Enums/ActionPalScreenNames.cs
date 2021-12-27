using System.ComponentModel;

namespace TenantsAPI.Helper.Enums
{
    public enum ActionPalScreenNames
    {
        [Description("WizardComponent")]
        Wizard = 0,

        [Description("JobComponent")]
        Job = 1,

        [Description("StoreDetailsComponent")]
        StoreDetails = 2,

        [Description("AcceptRejectComponent")]
        AcceptReject = 3,

        [Description("AssignTechComponent")]
        AssignTech = 4,

        [Description("JobAuditComponent")]
        JobAudit = 5,

        [Description("AllowedJobTypeComponent")]
        AllowedJobType = 6
    }
}
