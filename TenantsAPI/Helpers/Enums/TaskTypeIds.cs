using System.ComponentModel;

namespace TenantsAPI.Helper.Enums
{
    public enum TaskTypeIds
    {
        [Description("TCS Minor Works Project")]
        TCSMinorWorksProject = 4,

        [Description("CIT Minor Works Project")]
        CITMinorWorksProject = 7,

        [Description("MilestoneTaskTypeId")] Milestone = 3
    }
}
