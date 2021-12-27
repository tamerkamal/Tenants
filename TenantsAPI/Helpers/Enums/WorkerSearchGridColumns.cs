


using System.ComponentModel;

namespace TenantsAPI.Helper.Enums
{
    public enum WorkerSearchGridColumns
    {
        [Description("workerId")] WorkerId,
        [Description("fullName")] FullName,
        [Description("firstContact")] FirstContact,
        [Description("secondContact")] SecondContact,
        [Description("carRego")] CarRego,
        [Description("region")] Region,
        [Description("status")] Status,
        [Description("workerProjectNumber")] WorkerProjectNumber,
        [Description("entityName")] EntityName,

    }
}
