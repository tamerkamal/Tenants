using System.ComponentModel;

namespace TenantsAPI.Helper.Enums
{
    public enum TableNames
    {
        [Description("ComplianceStatus")]
        ComplianceStatus,

        [Description("WorkerZone")]
        WorkerZone,

        [Description("WorkerAssistant")]
        WorkerAssistant,

        [Description("WorkerAsset")]
        WorkerAsset,

        [Description("WorkerSkill")]
        WorkerSkill,

        [Description("Job")]
        Job,

        [Description("Job Defect")]
        JobDefect,

        [Description("JobItem")]
        JobItem,

        [Description("JobVisit")]
        JobVisit,

        [Description("SalesEnquiry")]
        SalesEnquiry
    }
}