using System.ComponentModel;

namespace TenantsAPI.Helper.Enums
{
    public enum BillingEntities
    {
        [Description("Customer")]
        Customer = 100,
        [Description("Source")]
        Source = 200,
        [Description("Partner")]
        Partner = 300
    }
}