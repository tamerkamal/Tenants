
using System.ComponentModel;

namespace TenantsAPI.Helper.Enums
{
    public enum IssueTypes
    {
        [Description("REF")] // Install Fault
        INF = 5,

        [Description("REF")] // Refund
        Ref = 21,

        [Description("JobDefect")]
        JobDefect,
        [Description("JobVisit")]
        JobVisit,
         
        [Description("QC")]
        QC,

        [Description("OSA")]
        OSA,

        [Description("QI")]
        QI
    }
}