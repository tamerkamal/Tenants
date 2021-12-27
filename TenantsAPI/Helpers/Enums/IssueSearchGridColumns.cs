





using System.ComponentModel;

namespace TenantsAPI.Helper.Enums
{
    public enum IssueSearchGridColumns
    {
        [Description("issueId")] IssueId,
        [Description("clientJobNumber")] ClientJobNumber,
        [Description("status")] Status,
        [Description("desc")] Desc,
        [Description("days")] Days,
        [Description("workerFullName")] WorkerFullName,
        [Description("priority")] Priority,
        [Description("entityName")] EntityName,

    }
}
