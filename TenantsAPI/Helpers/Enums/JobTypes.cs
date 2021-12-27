using System.ComponentModel;

namespace TenantsAPI.Helper.Enums
{
    public enum JobTypes
    {
        [Description("VDSL Installation")]
        VDSLInstallation ,

        [Description("Installation")]
        Installation = 28,

        [Description("In Home Quote")]
        InHomeQuote = 34,

        [Description("Power Supply Fault Rectification")]
        PowerSupplyFaultRectification = 44,

        [Description("On Site Assist CD-AV")]
        OnSiteAssistCDAV = 95
       
    }
}