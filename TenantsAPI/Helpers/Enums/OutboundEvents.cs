using System.ComponentModel;

namespace TenantsAPI.Helper.Enums
{
    public enum OutboundEvents
    {
        [Description("CompanyDetailsAdded")]
        CompanyDetailsAdded,

        [Description("CompanyDetailsUpdated")]
        CompanyDetailsUpdated,

        [Description("WorkerDetailsUpdated")]
        WorkerDetailsUpdated,

        [Description("NavMapAdded")]
        NavMapAdded,

        [Description("NavMapUpdated")]
        NavMapUpdated,


    }
}