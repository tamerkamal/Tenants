using System.ComponentModel;

namespace TenantsAPI.Helper.Enums
{
    public enum CustomerTypes
    {
        [Description("Corporate Clients")]
        Corporate = 1,

        [Description("Residential")]
        Residential = 3,

        [Description("Referral Store")] 
        ReferralStore = 4,

        [Description("Commercial")]
        Commercial = 6
    }
}