using System.ComponentModel;

namespace TenantsAPI.Helper.Enums
{
    public enum LogTypes
    {
        [Description("Comment")] Comment,

        [Description("All Comments")] AllComment,

        [Description("Form Comment")] FormComment,

        [Description("Recon Comment")] ReconComment,

        [Description("Audit Comment")] AuditComment,

        [Description("Data update")] DataUpdate,

        [Description("Worker Assistant Add")] WorkerAssistantAdd,

        [Description("Worker Assistant Delete")]
        WorkerAssistantDelete,

        [Description("Desktop Login")] DesktopLogin,

        [Description("Customer Contract Entitlement")]
        CustomerContractEntitlement,

        [Description("IPad")] IPad,

        [Description("Application Error")] ApplicationError,

        [Description("Defect Comment")] DefectComment,

        [Description("Customer comment")] CustomerComment,

        [Description("Dispatch Comment")] DispatchComment,

        [Description("System Comment")] SystemComment,

        [Description("Fulfillment Comment")] FulfillmentComment,

        [Description("Send SMS Error")] SendSmsError,

        [Description("Job")] Job,

        [Description("Customer feedback")] CustomerFeedback,

        [Description("Quote Completed")] QuoteCompleted,

        [Description("Permission")] Permission,

        [Description("Task Comment")] TaskComment,

        [Description("Route Override")] RouteOverride,

        [Description("IT Comment")] ITComment

    }
}