using System.ComponentModel;

namespace TenantsAPI.Helper.Enums
{
    public enum TasKTypes
    {
        [Description("Milestone")]
        Milestone,

        [Description("Task")]
        Task,

        [Description("ProjectActivity")]
        ProjectActivity,

        [Description("ActivityType")]
        ActivityType,

        [Description("JobType")]
        JobType,

        [Description("IssueType")]
        IssueType
    }
}
