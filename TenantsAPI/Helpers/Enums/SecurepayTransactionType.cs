using System.ComponentModel;

namespace TenantsAPI.Helper.Enums
{
    public enum SecurepayTransactionType
    {
        [Description("Payment")]
        Payment = 0,

        [Description("Pre-Authorisation")]
        PreAuthorisation = 1,
    }
}
