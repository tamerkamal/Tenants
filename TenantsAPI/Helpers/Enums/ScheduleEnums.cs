using System.ComponentModel;

namespace TenantsAPI.Helper.Enums
{
    public enum ScheduleCriteriaTables
    {
        [Description("Job")] Job,
        [Description("JobType")] JobType,
        [Description("IssueType")] IssueType
    }

    public enum ScheduleCriteriaFields

    {
        [Description("ClientJobNumber")] ClientJobNumber,
        [Description("JobTypeId")] JobTypeId,
        [Description("IssueTypeId")] IssueTypeId
    }

    public enum ScheduleCriteriaNames

    {
        [Description("Client Job Number")] ClientJobNumber
    }

    public enum ScheduleCriteriaOperators

    {
        [Description("OR")] Or,
        [Description("AND")] And
    }

    public enum TaskStatuses
    {
        [Description("Pending")] Pending,

        [Description("Completed")] Completed,

        [Description("Cancelled")] Cancelled,
        [Description("In Progress")] InProgress,
        [Description("On Hold")] OnHold,

        [Description("At Risk")] AtRisk,
        [Description("Behind Schedule")] BehindSchedule
    }

    public enum TaskTypes
    {
        [Description("TenantsAPI Task")] TenantsAPITask,

        [Description("TenantsAPI Task Container")]
        TenantsAPITaskContainer,
        [Description("Normal Task")] NormalTask,
        [Description("Mile Stone")] MileStoneTask,

    }

    public enum TaskItemTypes
    {
        [Description("JobDefect")] JobDefect,
        [Description("Job")] Job,
        [Description("JobVisit")] JobVisit,
        [Description("Log")] Log

    }

    public enum TemplateTaskItemTypes
    {
        [Description("JobType")] JobType,
        [Description("IssueType")] IssueType,
        [Description("ProjectActivity")] ProjectActivity,
        [Description("ActivityType")] ActivityType,
    }


    public enum TaskInfoPropertys
    {
        [Description("Start Date")] StartDate,
        [Description("End Date")] EndDate,
        [Description("Task Name")] TaskName,
        [Description("Task Status")] TaskStatus,

    }

    public enum CodeTableTypeNames
    {
        [Description("Task Status")] TaskStatus,
        [Description("Task Type")] TaskType,

    }

    public enum CodeTableSchemeCodes
    {
        [Description("CAN")] Can,
        [Description("COMP")] Comp,
        [Description("ISSUE")] Issue,
        [Description("JPDY")] Jpdy,
        [Description("DLYD")] Dlyd

    }

    public enum TaskInfoProperties

    {
        [Description("Start Date")] StartDate,
        [Description("End Date")] EndDate,
        [Description("Task Name")] TaskName,
        [Description("Task Status")] TaskStatus
    }

    public enum ScheduleCommentType
    {
        [Description("Activity Comments")] ActivityComments,
        [Description("Project Comments")] ProjectComments,
        [Description("Job Comments")] JobComments,
        [Description("All Comments")] AllComments
    }

}
