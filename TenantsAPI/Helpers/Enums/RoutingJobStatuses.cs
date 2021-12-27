using System.ComponentModel;

namespace TenantsAPI.Helper.Enums
{
    public enum RoutingJobStatuses
    {
        [Description("Active Jobs Only")]
        ActiveJobsOnly = 1,

        [Description("All Jobs")]
        AllJobs = 2,

        [Description("Jeopardy Jobs")]
        JeopardyJobs = 3
    }
}
