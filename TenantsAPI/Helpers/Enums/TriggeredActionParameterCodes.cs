using System.ComponentModel;

namespace TenantsAPI.Helper.Enums
{
    public enum TriggeredActionParameterCodes
    {
        [Description("Address")]
        Address,

        [Description("Tech")]
        Tech,

        [Description("ROM")] // regional operations manager
        Rom,

        [Description("FOM")] // field operations manager
        Fom,

        [Description("CMC")] // CMC manager
        Cmc,

        [Description("TL")] // team leader
        Tl,

        [Description("CR")] // company rep
        Cr,

        [Description("REC")]
        Rec,

        [Description("NOC")]
        Noc,
        
        [Description("ACCOUNTMGR")]
        AccountMgr,

        [Description("FST")]
        FST,

        [Description("Query")]
        Query,

        [Description("IS")]
        Is,

        [Description("IT")]
        It,

        [Description("Task Code")]
        TaskCode,

        [Description("Equipment")]
        Equipment,

        [Description("MessageTemplate")]
        MessageTemplate
    }
}