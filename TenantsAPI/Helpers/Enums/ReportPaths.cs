using System.ComponentModel;

namespace TenantsAPI.Helper.Enums
{
    public enum ReportPaths
    {
        [Description("/IT/Customer Contract Invoice")]
        CustomerContractInvoice,

        [Description("/IT/Customer Invoice")]
        CustomerInvoice,

        [Description("/IT/TenantsAPI/Form Response Details")]
        FormResponseDetails,

        [Description("/Operations/HN Logistics Confirmation")]
        HNLogisticsConfirmation,

       [Description("/IT/TenantsAPI/Commercial Invoice")]
        CommercialInvoice,

        [Description("/IT/TenantsAPI/Payment Collection Letter")]
        PaymentCollectionReport
    }
}