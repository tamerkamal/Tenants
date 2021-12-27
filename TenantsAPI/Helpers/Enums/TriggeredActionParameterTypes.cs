using System.ComponentModel;

namespace TenantsAPI.Helper.Enums
{
    public enum TriggeredActionParameterTypes
    {
        [Description("To")]
        To,

        [Description("CC")]
        Cc,

        [Description("Bcc")]
        Bcc,

        [Description("Add")]
        Add,

        [Description("Subtract")]
        Subtract,

        [Description("Job Status")]
        JobStatus
    }
}