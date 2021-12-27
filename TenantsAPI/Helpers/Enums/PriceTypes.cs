using System.ComponentModel;

namespace TenantsAPI.Helper.Enums
{
    public enum PriceTypes
    {
        [Description("Client")]
        Client = 1,

        [Description("Customer")]
        Customer = 2
    }
}