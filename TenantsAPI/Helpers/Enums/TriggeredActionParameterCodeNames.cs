
using System.ComponentModel;

namespace TenantsAPI.Helper.Enums
{
    public enum TriggeredActionParameterCodeNames
    {
        [Description("Technician")]
        Technician,

        [Description("Field Operation manager")]
        FOM,

        [Description("Region Operational Manager")] // regional operations manager
        ROM,

        [Description("CMC")] // CMC manager
        CMC,

        [Description("Team Leader")] // team leader
        TL,

        [Description("Address")]
        Address,

        [Description("MessageTemplate")]
        MessageTemplate,

        [Description("Activity Type")]
        ActivityType,

        [Description("Activity Status")]
        Is,
    }
}