using System.ComponentModel;

namespace Tenants.Helpers.Enums
{
    public enum WorkerStatuses
    {
        [Description("Current")]
        C = 1,

        [Description("De-activated")]
        D = 2,

        [Description("Not-Activated")]
        N = 3,

        [Description("Onboarding")]
        Onb = 5,

        [Description("Offboarding")]
        Ofb = 6,

       
    }
}