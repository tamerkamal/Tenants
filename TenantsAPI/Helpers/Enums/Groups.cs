using System.ComponentModel;

namespace TenantsAPI.Helper.Enums
{
    public enum Groups
    {
        [Description("ICT HW")]
        ICTHW = 238,

        [Description("ICT SW")]
        ICTSW = 239,

        [Description("ICT Reports")]
        ICTReports = 241,

        [Description("INSU NCASTNSW Hixwood Insp")]
        InSuncastnswHixwoodInsp = 101,

        [Description("INSU SYDNEYNSW Hixwood Insp")]
        InSusydneynswHixwoodInsp = 172,
    }
}
