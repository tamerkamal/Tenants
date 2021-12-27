using System.ComponentModel;

namespace TenantsAPI.Helper.Enums
{
    public enum TaskStatus
    {
        [Description("Approved")]
        POA = 45,

        [Description("Awaiting F&A")]
        FA = 52
    }
}
