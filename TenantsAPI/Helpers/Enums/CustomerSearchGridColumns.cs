






using System.ComponentModel;

namespace TenantsAPI.Helper.Enums
{
    public enum CustomerSearchGridColumns
    {
        [Description("recordId")] RecordId,
        [Description("firstName")] FirstName,
        [Description("lastName")] LastName,
        [Description("email")] Email,
        [Description("state")] State,
        [Description("mobileNumber")] MobileNumber,
        [Description("landLine")] LandLine,
        [Description("address")] Address,
        [Description("company")] Company,
        [Description("entityName")] EntityName,

    }
}
