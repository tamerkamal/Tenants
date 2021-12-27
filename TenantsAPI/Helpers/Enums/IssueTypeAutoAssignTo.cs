using System.ComponentModel;

namespace TenantsAPI.Helper.Enums
{
    public enum IssueTypeAutoAssignTo
    {
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

        [Description("REC")]   //ProjectRegionAdminContact
        Rec,

        [Description("ACCOUNTMGR")] //Account Manager
        AccountMgr,

        [Description("NOC")]   // NOC Worker
        Noc,

        [Description("FST")]   // FST Worker
        FST,

        [Description("COR")]   // Company Rep
        CoR,

        [Description("AW")]   // Admin Worker
        AW,

        [Description("T2CO")]   // Tech2 CO (JobField7): can be called T2CO. If a Project does not use this field can display <none>. 
        T2CO

    }
}