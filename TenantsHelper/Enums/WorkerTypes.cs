using System.ComponentModel;

namespace Tenants.Helpers.Enums
{
    public enum WorkerTypes
    {
        [Description("Full-Time")]
        FullTime= 1,

        [Description("Part-Time")]
        PartTime = 2,

        [Description("Casual")]
        Casual = 3,

        [Description("Contractor")]
        Contractor = 4,

        [Description("Generic User")]
        GenericUser = 5,

        [Description("CST")]
        Cst = 6,

        [Description("Field Supervisor")]
        FieldSupervisor = 7,

        [Description("Field Operation Manager")]
        FieldOperationManager = 8,

        [Description("Store")]
        Store = 9,

        [Description("Ambassador")]
        Ambassador = 10,

        [Description("Account Manager")]
        AccountManager = 11,

        [Description("Service Delivery Manager")]
        ServiceDeliveryManager = 12,

        [Description("Phone Tech")]
        PhoneTech = 13,

        [Description("Trainee")]
        Trainee = 14,

        [Description("Cap Mgmt")]
        CapMgmt = 15,

        [Description("Leading Hand")]
        LeadingHand = 16,

        [Description("Labourer")]
        Labourer = 17,

        [Description("Prescoper")]
        Prescoper = 18,

        [Description("Service Locator")]
        ServiceLocator = 19,

        [Description("State Operation Manager")]
        StateOperationManager = 20,

        [Description("Operation Support")]
        OperationSupport = 21,

        [Description("Area Manager")]
        AreaManager = 22,

        [Description("Admin")]
        Admin = 23,

        [Description("Warehouse Support")]
        WarehouseSupport = 24,

        [Description("Subcontractor Supervisor")]
        SubcontractorSupervisor = 25,

        [Description("NP-Internal-FieldWorker")]
        NPInternalFieldWorker = 26,

        [Description("NP-Internal-FieldManagers")]
        NpInternalFieldManagers = 27,

        [Description("NP-SDP-FieldWorker")]
        NpSdpFieldWorker = 28,

        [Description("NP-SDP-FieldManager")]
        NpSdpFieldManager = 29,

        [Description("NP-Internal-Requestor")]
        NpInternalRequestor = 30,

        [Description("NP-Internal-Manager")]
        NpInternalManager = 31,

        [Description("Partner")]
        Partner = 32,

        [Description("HR")]
        Hr = 33
    }
}