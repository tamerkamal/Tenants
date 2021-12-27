using System.ComponentModel;

namespace TenantsAPI.Helper.Enums
{
    public enum DispatchJobStatuses
    {
        [Description("Active Jobs")]
        ActiveJobs = 1,
         
        [Description("Jeopardy Jobs")]
        JeopardyJobs = 2
    }
}
