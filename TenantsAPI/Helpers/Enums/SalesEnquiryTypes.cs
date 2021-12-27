using System.ComponentModel;

namespace TenantsAPI.Helper.Enums
{
    public enum SalesEnquiryTypes
    {
        [Description("Sales Enquiry from SL")]
        SalesEnquiryFromSL = 1,

        [Description("Newsletter Signup from the website")]
        NewsletterSignupFromTheWebsite = 2,

        [Description("Sales Enquiry from Gizmo Website")]
        SalesEnquiryFromGizmoWebsite = 3,

        [Description("TPG Sales Enquiry")]
        TPGSalesEnquiry = 5,

        [Description("TPG Splice Sales Enquiry")]
        TPGSpliceSalesEnquiry = 6

    }
}