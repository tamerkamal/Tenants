using System.ComponentModel;

namespace TenantsAPI.Helper.Enums
{
    public enum DispatchJobGridColumns
    {
        [Description("jobTypeCode")]
        JobTypeCode,

        [Description("clientJobNumber")]
        ClientJobNumber,

        [Description("jobStatusCode")]
        JobStatusCode,

        [Description("startTime")]
        StartTime,

        [Description("finishTime")]
        FinishTime,

        [Description("jobPoints")]
        JobPoints,

        [Description("custContactName")]
        CustContactName,

        [Description("siteInfo")]
        SiteInfo, 

        [Description("simpleAddress")]
        SimpleAddress,

        [Description("bookedTimeSlot")]
        BookedTimeSlot,

        [Description("projectNumberName")]
        ProjectNumberName,

        [Description("routeSeq")]
        RouteSeq,

        [Description("priority")]
        Priority,

        [Description("iPadUpdatesPending")]
        iPadUpdatesPending,

        [Description("audit")]
        Audit,

        [Description("fdh")]
        Fdh,

        [Description("fda")]
        Fda,

        [Description("fsam")]
        Fsam,

        [Description("zoneCodeName")]
        ZoneCodeName,

        [Description("jobSource")]
        JobSource,
         

    }
}
