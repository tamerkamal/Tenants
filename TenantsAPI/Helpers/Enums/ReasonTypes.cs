using System.ComponentModel;

namespace TenantsAPI.Helper.Enums
{
    public enum ReasonTypes
    {
        [Description("Issue-Originator")]
        IssueOriginator = 1,

        [Description("Defect")]
        Defect = 2,

        [Description("Issue-Priority")]
        IssuePriority = 3,

        [Description("CapacityUR")]
        CapacityUR = 4
    }
}
