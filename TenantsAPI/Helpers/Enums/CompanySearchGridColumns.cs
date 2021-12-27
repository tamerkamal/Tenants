



using System.ComponentModel;

namespace TenantsAPI.Helper.Enums
{
    public enum CompanySearchGridColumns
    {
        [Description("CompanyId")] CompanyId,
        [Description("companyName")] CompanyName,
        [Description("owner")] Owner,
        [Description("address")] Address,
        [Description("ABN")] ABN,
        [Description("status")] Status,
        [Description("contactNumber")] ContactNumber,
        [Description("entityName")] EntityName,

    }
}
