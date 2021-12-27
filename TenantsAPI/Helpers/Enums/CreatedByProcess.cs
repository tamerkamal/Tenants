using System.ComponentModel;

namespace TenantsAPI.Helper.Enums
{
    public enum CreatedByProcess
    {
        [Description("AutoRefresh")]
        AutoRefresh,
        [Description("New Contract")]
        NewContract,

        [Description("SV Process")]
        SvProcess,

        [Description("Cust Process")]
        CustomerProcess,

        [Description("Batch Creation")]
        BatchCreation,

        [Description("Apply Promo")]
        ApplyPromo,

        [Description("Form Triggers")]
        FormTriggers,

        [Description("Issue")]
        Issue,

        [Description("HN POS Import")]
        HnposImport,

        [Description("NPS SMS")]
        NPSSMS,

        [Description("NPS")]
        NPS,

        [Description("PAL Action")]
        PALAction,

        [Description("NBN PAL Audit")]
        NBNPALAudit,

        [Description("TATA")]
        TATA,

        [Description("Stock Transfer")]
        StockTransfer,

        [Description("Manual")]
        Manual,

        [Description("NBN Audit")]
        NBNAudit,

        [Description("Wizard")]
        Wizard,

        [Description("QI Process")]
        QIProcess,

        [Description("SE Process")]
        SEProcess,

        [Description("HN Helpdesk")]
        HNHelpdesk,

        [Description("Reschedule Wizard")]
        RescheduleWizard,

        [Description("Quote Process Wizard")]
        QuoteProcessWizard,

        [Description("Cust Process")]
        CustProcess,

        [Description("Template Setup")]
        TemplateSetup,

        [Description("TenantsAPIConfigurationScreen")]
        TenantsAPIConfigurationScreen,

        [Description("Project Setup")]
        CreatedByProjectSetup,

        [Description("Manage Schedule Tasks")]
        CreatedByManageScheduleTasks,

        [Description("Initial Setup")]
        InitialSetup,

        [Description("Integration API")]
        IntegrationAPI,
    }
}