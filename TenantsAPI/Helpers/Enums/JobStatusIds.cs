using System.ComponentModel;

namespace TenantsAPI.Helper.Enums
{
    public enum JobStatusIds
    {
        [Description("Open")]
        Open = 4,

        [Description("Started")]
        Started = 5,

        [Description("Dispatch Closed")]
        DispatchClosed = 6,

        [Description("Recon Closed")]
        ReconClosed = 7,

        [Description("Not Done - Customer")]
        NotDoneCustomer = 8,

        [Description("Incomplete")]
        Incomplete = 9,

        [Description("Not Done - T2H")]
        NotDoneT2H = 10,

        [Description("Cancel by Cust before day")]
        CancelByCustomerBeforeDay = 11,

        [Description("Cancel by Cust on day")]
        CancelByCustomerOnDay = 12,

        [Description("Change Time Slot")]
        ChangeTimeSlot = 23,

        [Description("Quote Lost")]
        Ql = 41,

        [Description("Quote Dispatch Closed")]
        QTSC = 60,

        [Description("Service Completed Inactive")]
        ServiceCompletedInactive = 69
    }
}