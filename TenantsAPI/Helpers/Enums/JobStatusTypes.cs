using System.ComponentModel;

namespace TenantsAPI.Helper.Enums
{
    public enum JobStatusTypes
    {
        [Description("Appt")]
        Appt,

        [Description("Cancel")]
        Cancel,

        [Description("Closed")]
        Closed,

        [Description("FClosed")]
        FClosed,

        [Description("Not Done")]
        NotDone,

        [Description("Open")]
        Open,

        [Description("FOpen")]
        FOpen,

        [Description("Pending")]
        Pending,

        [Description("Pending2")]
        Pending2,

        [Description("QT Closed")]
        QtClosed,

        [Description("QT Pending")]
        QtPending,

        [Description("Reschedule")]
        Reschedule,

        [Description("Started")]
        Started,

        [Description("FStarted")]
        FStarted,

        [Description("Incomplete")]
        Incomplete,

        [Description("F Incomplete")]
        FIncomplete
        
    }
}