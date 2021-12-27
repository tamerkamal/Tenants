using System.ComponentModel;

namespace TenantsAPI.Helper.Enums
{
    public enum CompanyStatuses
    {
        [Description("Current")]
        C = 1,

        [Description("De-activated")]
        D = 2,

        [Description("Supplier")]
        S = 3,

        [Description("Sub-Supplier")]
        Ss = 4,

        [Description("Onboarding")]
        Onb = 5,

        [Description("Offboarding")]
        Ofb = 6
    }
}