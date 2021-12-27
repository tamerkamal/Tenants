using System.ComponentModel;

namespace TenantsAPI.Helper.Enums
{
    public enum LocationTypes
    {
        [Description("Stream Warehouse")]
        StreamWarehouse,

        [Description("HN Warehouse")]
        HNWarehouse,

        [Description("T2H Office")]
        T2HOffice,

        [Description("Contractor")]
        Contractor,

        [Description("Customer")]
        Customer,

        [Description("Supplier")]
        Supplier,

        [Description("Worker")]
        Worker,

        [Description("Warehouse")]
        Warehouse,

        [Description("Unknown")]
        Unknown,

        [Description("Deactivated")]
        Deactivated,

    }
}