using System.ComponentModel;

namespace TenantsAPI.Helper.Enums
{
    public enum RecipientTypes
    {
        [Description("Technician")]
        Technician = 1,

        [Description("Customer")]
        Customer = 2,

        [Description("Technician and Customer")]
        Both = 3
    }
}
