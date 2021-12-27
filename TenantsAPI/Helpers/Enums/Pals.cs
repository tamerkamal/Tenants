using System.ComponentModel;

namespace TenantsAPI.Helper.Enums
{
    public enum Pals
    {
        [Description("Missing Payment")]
        MissingPaymentCDAV = 2,

        [Description("Job Not Closed")]
        JobNotClosedCDAV = 10,

        [Description("Missing Payment")]
        MissingPaymentCDIT = 16,

        [Description("Bulk Recon Inspection")]
        BulkReconInspectionNBNDIR = 67,

        
    }
}