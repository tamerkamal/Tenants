

using System.ComponentModel;

namespace TenantsAPI.Helper.Enums
{
    public enum JobSearchGridColumns
    {
        [Description("jobVisitId")] JobVisitId,

        [Description("Status")] Status,
        [Description("jobStatusCode")] JobStatusCode,
        [Description("jobNumber")] JobNumber,
        [Description("clientJobNumber")] ClientJobNumber,
        [Description("clientVisitNumber")] ClientVisitNumber,
        [Description("bookedDate")] BookedDate,
        [Description("address")] Address,
        [Description("tech")] Tech,
        [Description("entityName")] EntityName,

    }
}
