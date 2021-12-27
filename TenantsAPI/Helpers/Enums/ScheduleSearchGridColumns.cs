





using System.ComponentModel;

namespace TenantsAPI.Helper.Enums
{
    public enum ScheduleSearchGridColumns
    {
        [Description("scheduleId")] ScheduleId,
        [Description("scheduleName")] ScheduleName,
        [Description("template")] Template,
        [Description("startDate")] StartDate,
        [Description("endDate")] EndDate,
        [Description("fullName")] FullName,
        [Description("supervisor")] Supervisor,
        [Description("scheduleStatus")] ScheduleStatus,
        [Description("completedPercentage")] CompletedPercentage,
        [Description("milestone")] Milestone,
        [Description("currentTask")] CurrentTask,
        [Description("lastUpdated")] LastUpdated,
        [Description("isActive")] IsActive,

    }
}
