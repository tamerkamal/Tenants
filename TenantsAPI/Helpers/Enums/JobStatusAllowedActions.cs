using System.ComponentModel;

namespace TenantsAPI.Helper.Enums
{
    public enum JobStatusAllowedActions
    { 
        [Description("Cancel")]
        Cancel,

        [Description("Close")]
        Close,

        [Description("Closed")]
        Closed,
        [Description("Not Done")]
        NotDone,

        [Description("Open")]
        Open,

        [Description("Pending")]
        Pending,

        [Description("Pending2")]
        Pending2,

        [Description("Reschedule")]
        Reschedule,

        [Description("Start")]
        Start,

        [Description("Started")]
        Started, 
       
    }
}