using System.ComponentModel;

namespace TenantsAPI.Helper.Enums
{
    public enum CustomerSearchFields
    {
        [Description("First Name")]
        FirstName,

        [Description("Last Name")]
        LastName,

        [Description("Full Name")]
        FullName,

        [Description("Phone No")]
        PhoneNo,

        [Description("Email Address")]
        EmailAddress,

        [Description("Company Name")]
        CompanyName,

        [Description("Pan")]
        Pan,

        [Description("Customer ID")]
        CustomerId,

        [Description("User Name")]
        UserName,

        [Description("Address")]
        Address
    }
}