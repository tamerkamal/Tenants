using System.ComponentModel;

namespace TenantsAPI.Helper.Enums
{
    public enum Processes
    {
        [Description("Reschedule Wizard")]
        RescheduleWizard = 2,

        [Description("Manual")]
        Manual
    }
}